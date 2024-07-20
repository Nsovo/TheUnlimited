using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using TheUnlimited_Backend_.Models;
using TheUnlimited_Backend_.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class AgentsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IRepository _repository;
    private readonly IEmailSender _emailSender;
    private readonly ProductSalesService _productSalesService;

    public AgentsController(AppDbContext context, UserManager<User> userManager, SignInManager<User> signInManager, IRepository repository, IEmailSender emailSender, ProductSalesService productSalesService)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _repository = repository;
        _emailSender = emailSender;
        _productSalesService = productSalesService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.UserName);
        if (user == null)
        {
            return Unauthorized("Invalid login attempt.");
        }

        var result = await _signInManager.PasswordSignInAsync(user.UserName, loginDto.Password, false, false);
        if (result.Succeeded)
        {
            var agent = await _context.Agents
                                      .Include(a => a.AgentLevel)
                                      .Include(a => a.AuditTrails)
                                      .FirstOrDefaultAsync(a => a.AgentID == user.AgentID);

            var agentLevel = agent?.AgentLevel?.LevelDescription ?? "Agent";

            var auditTrail = new AuditTrail
            {
                AgentID = agent?.AgentID,
                UserID = user.Id,
                Action = "Login",
                LoginTimestamp = DateTime.UtcNow
            };
            _context.AuditTrails.Add(auditTrail);
            await _context.SaveChangesAsync();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, agentLevel)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Login");
            await _signInManager.SignInAsync(user, new AuthenticationProperties { IsPersistent = false }, "Login");

            return Ok(new { message = "Login successful", user, role = agentLevel });
        }

        return Unauthorized("Invalid login attempt.");
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            var agent = await _context.Agents.FindAsync(user.AgentID);

            var auditTrail = await _context.AuditTrails
                .Where(a => a.UserID == user.Id && a.Action == "Login")
                .OrderByDescending(a => a.LoginTimestamp)
                .FirstOrDefaultAsync();

            if (auditTrail != null)
            {
                auditTrail.LogoutTimestamp = DateTime.UtcNow;
                _context.AuditTrails.Update(auditTrail);
                await _context.SaveChangesAsync();
            }
        }

        await _signInManager.SignOutAsync();
        return Ok(new { message = "Logout successful" });
    }

    [HttpPost("CreateAgent")]
    public async Task<IActionResult> CreateAgent([FromBody] CreateAgentDto createAgentDto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var agent = new Agent
            {
                Name = createAgentDto.Name,
                Surname = createAgentDto.Surname,
                ContactNumber = createAgentDto.ContactNumber,
                AgentLevelID = createAgentDto.AgentLevelID,
                AgentStartDate = createAgentDto.AgentStartDate,
                AgentStatusID = createAgentDto.AgentStatusID,
                OfficeCode = createAgentDto.OfficeCode,
                AgentTerminationDate = createAgentDto.AgentTerminationDate,
                ScheduleID = createAgentDto.ScheduleID,
                SalesChannelID = createAgentDto.SalesChannelID
            };

            _context.Agents.Add(agent);
            await _context.SaveChangesAsync();

            var user = new User
            {
                UserName = createAgentDto.UserName,
                Email = createAgentDto.UserName,
                ContactNumber = createAgentDto.ContactNumber,
                UserProfileID = createAgentDto.UserProfileID,
                AgentID = agent.AgentID,
                Name = createAgentDto.Name,
                Surname = createAgentDto.Surname 
            };

            var generatedPassword = GenerateRandomPassword();
            var result = await _userManager.CreateAsync(user, generatedPassword);

            if (!result.Succeeded)
            {
                await transaction.RollbackAsync();
                return BadRequest(result.Errors);
            }

            var emailSubject = "Your new agent account details";
            var emailBody = $"Dear {createAgentDto.Name},<br/><br/>Your agent account has been created. Here are your login details:<br/><br/>Username: {createAgentDto.UserName}<br/>Password: {generatedPassword}<br/><br/>Please change your password after logging in for the first time.<br/><br/>Best regards,<br/>Tech-26 Team 26";
            await _emailSender.SendEmailAsync(createAgentDto.UserName, emailSubject, emailBody);

            // Generate ProductSales for the new agent
            var generatedProductSales = _productSalesService.GenerateProductSales(agent.AgentID, 10); // Generate 10 ProductSales

            // Ensure only ProductSales are added to the context
            _context.ProductSales.AddRange(generatedProductSales);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
            return Ok(agent);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            var errorMessage = ex.InnerException?.Message ?? ex.Message;
            return StatusCode(500, $"An error occurred while creating the agent: {errorMessage}");
        }
    }



    [HttpGet]
    public async Task<IActionResult> GetAllAgents()
    {
        var agents = await _context.Agents
                                   .Include(a => a.AuditTrails)
                                   .Include(a => a.AgentLevel)
                                   .Include(a => a.AgentStatus)
                                   .Include(a => a.Office)
                                   .Include(a => a.Schedule)
                                   .Include(a => a.SalesChannel)
                                   .Include(a => a.Users) 
                                   .Include(a => a.ProductSales) 
                                   .ToListAsync();

        var agentDtos = agents.Select(a => new AgentDto
        {
            AgentID = a.AgentID,
            Name = a.Name,
            Surname = a.Surname,
            ContactNumber = a.ContactNumber,
            AgentLevelDescription = a.AgentLevel?.LevelDescription,
            AgentStatusDescription = a.AgentStatus?.StatusDescription,
            OfficeLocation = a.Office?.OfficeLocation,
            ScheduleDescription = a.Schedule?.Description,
            SalesChannelDescription = a.SalesChannel?.ChannelDescription,
            UserName = a.Users.FirstOrDefault()?.UserName, 
            UplineID = a.UplineID,
           ProductSales = a.ProductSales.Select(ps => new ProductSalesDto
           {
                ProductSalesID = ps.ProductSalesID,
                AgentID = ps.AgentID,
                ProductID = ps.ProductID,
                SalesAmount = ps.SalesAmount,
                SalesDate = ps.SalesDate,
                SalesChannelID = ps.SalesChannelID
            }).ToList(),
            AuditTrails = a.AuditTrails.Select(at => new AuditTrailDto
            {
                LoginTimestamp = (DateTime)(at.LoginTimestamp.HasValue ? at.LoginTimestamp.Value : (DateTime?)null),
                LogoutTimestamp = at.LogoutTimestamp.HasValue ? at.LogoutTimestamp.Value : (DateTime?)null
            }).ToList()
        }).ToList();

        return Ok(agentDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAgentById(int id)
    {
        var agent = await _context.Agents
                                  .Include(a => a.AgentLevel)
                                  .Include(a => a.AgentStatus)
                                  .Include(a => a.Office)
                                  .Include(a => a.Schedule)
                                  .Include(a => a.SalesChannel)
                                  .Include(a => a.Users)
                                  .Include(a => a.AuditTrails)
                                  .FirstOrDefaultAsync(a => a.AgentID == id);

        if (agent == null)
        {
            return NotFound();
        }

        var agentDto = new AgentDto
        {
            AgentID = agent.AgentID,
            Name = agent.Name,
            Surname = agent.Surname,
            ContactNumber = agent.ContactNumber,
            AgentLevelDescription = agent.AgentLevel?.LevelDescription,
            AgentStatusDescription = agent.AgentStatus?.StatusDescription,
            OfficeLocation = agent.Office?.OfficeLocation,
            ScheduleDescription = agent.Schedule?.Description,
            SalesChannelDescription = agent.SalesChannel?.ChannelDescription,
            UserName = agent.Users?.FirstOrDefault()?.UserName,
            AuditTrails = agent.AuditTrails?.Select(at => new AuditTrailDto
            {
                LoginTimestamp = at.LoginTimestamp ?? DateTime.MinValue,
                LogoutTimestamp = at.LogoutTimestamp ?? DateTime.MinValue
            }).ToList() ?? new List<AuditTrailDto>()
        };

        return Ok(agentDto);
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> EditAgent(int id, [FromBody] CreateAgentDto editAgentDto)
    {
        var agent = await _context.Agents.FindAsync(id);
        if (agent == null)
        {
            return NotFound();
        }

        agent.Name = editAgentDto.Name;
        agent.Surname = editAgentDto.Surname;
        agent.ContactNumber = editAgentDto.ContactNumber;
        agent.AgentLevelID = editAgentDto.AgentLevelID;
        agent.AgentStartDate = editAgentDto.AgentStartDate;
        agent.AgentStatusID = editAgentDto.AgentStatusID;
        agent.OfficeCode = editAgentDto.OfficeCode;
        agent.AgentTerminationDate = editAgentDto.AgentTerminationDate;
        //agent.UplineName = editAgentDto.UplineName;
        agent.ScheduleID = editAgentDto.ScheduleID;
        agent.SalesChannelID = editAgentDto.SalesChannelID;

        _context.Agents.Update(agent);

        var user = await _userManager.FindByIdAsync(agent.AgentID.ToString());
        if (user != null)
        {
            user.UserName = editAgentDto.UserName;
            user.Email = editAgentDto.UserName;
            user.UserProfileID = editAgentDto.UserProfileID;
            user.AgentID = agent.AgentID;
            await _userManager.UpdateAsync(user);
        }

        var saveResult = await _context.SaveChangesAsync();
        if (saveResult == 0)
        {
            return BadRequest("Failed to update the agent.");
        }

        return Ok(agent);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAgent(int id)
    {
        var agent = await _context.Agents.FindAsync(id);
        if (agent == null)
        {
            return NotFound();
        }

        var user = await _context.Users.FirstOrDefaultAsync(u => u.AgentID == agent.AgentID);
        if (user != null)
        {
            var userDeletionResult = await _userManager.DeleteAsync(user);
            if (!userDeletionResult.Succeeded)
            {
                return BadRequest("Failed to delete the associated user.");
            }
        }

        _context.Agents.Remove(agent);
        var saveResult = await _context.SaveChangesAsync();

        if (saveResult == 0)
        {
            return BadRequest("Failed to delete the agent.");
        }

        return Ok();
    }

    private string GenerateRandomPassword(int length = 8)
    {
        const string upperCaseChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
        const string lowerCaseChars = "abcdefghijklmnopqrstuvwxyz";
        const string digitChars = "0123456789";
        const string specialChars = "!@#$%^&*?_-";

        var random = new Random();

        // Ensure the password has at least one of each required character type
        var passwordChars = new List<char>
    {
        upperCaseChars[random.Next(upperCaseChars.Length)],
        lowerCaseChars[random.Next(lowerCaseChars.Length)],
        digitChars[random.Next(digitChars.Length)],
        specialChars[random.Next(specialChars.Length)]
    };

        // Fill the rest of the password length with random characters
        var allChars = upperCaseChars + lowerCaseChars + digitChars + specialChars;
        for (int i = passwordChars.Count; i < length; i++)
        {
            passwordChars.Add(allChars[random.Next(allChars.Length)]);
        }

        // Shuffle the list to ensure randomness
        return new string(passwordChars.OrderBy(_ => random.Next()).ToArray());
    }

}
