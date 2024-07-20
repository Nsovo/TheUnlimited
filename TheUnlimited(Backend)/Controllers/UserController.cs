using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TheUnlimited_Backend_.Models;
using TheUnlimited_Backend_.ViewModels;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IEmailSender _emailSender;
    private readonly ILogger<UsersController> _logger;
    private readonly AppDbContext _context;

    public UsersController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender, ILogger<UsersController> logger, AppDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailSender = emailSender;
        _logger = logger;
        _context = context;
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
            var userProfile = await _context.UserProfiles.FindAsync(user.UserProfileID);
            var userRole = userProfile?.ProfileDescription ?? "User";

            // Log the login activity
            var auditTrail = new AuditTrail
            {
                UserID = user.Id,
                Action = "Login",
                LoginTimestamp = DateTime.UtcNow
            };
            _context.AuditTrails.Add(auditTrail);
            await _context.SaveChangesAsync();

            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName),
               new Claim(ClaimTypes.Role, userRole)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Login");
            await _signInManager.SignInAsync(user, new AuthenticationProperties { IsPersistent = false }, "Login");

            return Ok(new { message = "Login successful", user, role = userRole });
        }

        return Unauthorized("Invalid login attempt.");
    }


    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user != null)
        {
            // Find the latest login entry
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

    [HttpPost("addUser")]
    public async Task<IActionResult> AddUser([FromBody] CreateUserDto createUserDto)
    {
        var user = new User
        {
            UserName = createUserDto.UserName,
            Email = createUserDto.Email,
            Name = createUserDto.Name,
            Surname = createUserDto.Surname,
            ContactNumber = createUserDto.ContactNumber,
            UserProfileID = createUserDto.UserProfileID
        };

        var result = await _userManager.CreateAsync(user, createUserDto.Password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        // Explicitly load the UserProfile if needed
        // Note: This requires the DbContext instance, adjust as necessary
        user = await _context.Users.Include(u => u.UserProfile).FirstOrDefaultAsync(u => u.Id == user.Id);

        return Ok(user);
    }


    // New method to get all users
    [HttpGet("getAllUsers")]
    public IActionResult GetAllUsers()
    {
        var users = _userManager.Users
            .Include(u => u.UserProfile)
            .Include(u => u.AuditTrails)
            .Include(u => u.Agent)
            .ToList();

     
        var userDtos = users.Select(user => new UserDto
        {
            Name = user.Name,
            Surname = user.Surname,
            ContactNumber = user.ContactNumber,
            UserProfileID = user.UserProfileID,
            UserProfileDescription = user.UserProfile?.ProfileDescription,
            AuditTrails = user.AuditTrails.Select(at => new AuditTrailDto
            {
                LoginTimestamp = (DateTime)(at.LoginTimestamp.HasValue ? at.LoginTimestamp.Value : (DateTime?)null),
                LogoutTimestamp = at.LogoutTimestamp.HasValue ? at.LogoutTimestamp.Value : (DateTime?)null
            }).ToList(),
            AgentID = user.AgentID,
            VerificationCode = user.VerificationCode,
            VerificationCodeExpiration = user.VerificationCodeExpiration,
            Id = user.Id,
            UserName = user.UserName,
            NormalizedUserName = user.NormalizedUserName,
            Email = user.Email,
            NormalizedEmail = user.NormalizedEmail,
            EmailConfirmed = user.EmailConfirmed,
            PasswordHash = user.PasswordHash,
            SecurityStamp = user.SecurityStamp,
            ConcurrencyStamp = user.ConcurrencyStamp,
            TwoFactorEnabled = user.TwoFactorEnabled,
            LockoutEnd = user.LockoutEnd,
            LockoutEnabled = user.LockoutEnabled,
            AccessFailedCount = user.AccessFailedCount
        }).ToList();

        return Ok(userDtos);
    }


    [HttpGet("getUserByUsername/{username}")]
    public async Task<IActionResult> GetUserByUsername(string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPut("editUserByUsername/{username}")]
    public async Task<IActionResult> EditUserByUsername(string username, [FromBody] EditUserDto editUserDto)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user == null)
        {
            return NotFound();
        }

        user.UserName = editUserDto.UserName;
        user.Surname = editUserDto.Surname;
        user.ContactNumber = editUserDto.ContactNumber;
        user.Email = editUserDto.UserName;
        user.UserProfileID = editUserDto.UserProfileID;

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok(user);
    }

    [HttpDelete("deleteUserByUsername/{username}")]
    public async Task<IActionResult> DeleteUserByUsername(string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null)
        {
            return NotFound();
        }

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok("User deleted successfully.");
    }

    

    [HttpPost("forgotPassword")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.UserName);
            if (user == null)
            {
                _logger.LogWarning("User not found: {UserName}", forgotPasswordDto.UserName);
                return BadRequest("User not found.");
            }

            var verificationCode = new Random().Next(1000, 9999).ToString();
            user.VerificationCode = verificationCode;
            user.VerificationCodeExpiration = DateTime.UtcNow.AddMinutes(5);

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                _logger.LogError("Could not save the verification code for user: {UserId}", user.Id);
                return BadRequest("Could not save the verification code.");
            }

            await _emailSender.SendEmailAsync(user.Email, "Password Reset Verification Code", $"Your verification code is: {verificationCode}");
            _logger.LogInformation("Verification code sent to user: {UserId}", user.Id);

            return Ok(new { message = "Verification code sent." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while processing forgot password for user: {UserName}", forgotPasswordDto.UserName);
            return StatusCode(500, "Internal server error.");
        }
    }

    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPasswordResult = await _userManager.ResetPasswordAsync(
                        user, token, model.NewPassword);

                    if (resetPasswordResult.Succeeded)
                    {
                        return Ok(new { Message = "Password reset successful" });
                    }
                    else
                    {
                        return BadRequest(new { Errors = resetPasswordResult.Errors.Select(e => e.Description) });
                    }
                }
                return NotFound("User not found.");
            }

            return BadRequest(new { Message = "Invalid data provided" });
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error resetting password for user {model.UserName}: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost("VerifyCode")]
    public async Task<IActionResult> VerifyCode([FromBody] VerificationModel model)
    {
        _logger.LogInformation($"Verifying code for user: {model.UserName}");
        try
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    _logger.LogInformation($"Found user: {model.UserName}");
                    _logger.LogInformation($"Stored verification code: {user.VerificationCode}, Provided verification code: {model.VerificationCode}");
                    _logger.LogInformation($"Current time: {DateTime.UtcNow}, Code expiration time: {user.VerificationCodeExpiration}");

                    if (user.VerificationCode == model.VerificationCode && user.VerificationCodeExpiration > DateTime.UtcNow)
                    {
                        _logger.LogInformation("Verification code is valid");
                        return Ok(new { isValid = true });
                    }
                    else
                    {
                        if (user.VerificationCode != model.VerificationCode)
                        {
                            _logger.LogWarning("Verification code does not match");
                        }
                        if (user.VerificationCodeExpiration <= DateTime.UtcNow)
                        {
                            _logger.LogWarning("Verification code has expired");
                        }
                    }
                }
                else
                {
                    _logger.LogWarning($"User not found: {model.UserName}");
                }
            }
            else
            {
                _logger.LogWarning("Model state is invalid");
            }

            return Ok(new { isValid = false });
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error verifying code for user {model.UserName}: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }

    // Add the SendVerificationEmail method here
    [HttpPost("SendVerificationEmail")]
    public async Task<IActionResult> SendVerificationEmail([FromBody] string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user != null)
        {
            var token = await _userManager.GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, "ResetPassword");
            _logger.LogInformation($"Generated token for user {email}: {token}");

            // Code to send the token via email
            await _emailSender.SendEmailAsync(user.Email, "Verification Code", $"Your verification code is: {token}");

            return Ok(new { Message = "Verification email sent." });
        }
        return BadRequest(new { Message = "Invalid email address." });
    }
}