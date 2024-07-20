using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheUnlimited_Backend_.Models;
using TheUnlimited_Backend_.ViewModels;

namespace TheUnlimited_Backend_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IRepository _repository;

        public DataController(AppDbContext context, UserManager<User> userManager, IRepository repository)
        {
            _context = context;
            _userManager = userManager;
            _repository = repository;
        }

        [HttpGet("agent-levels")]
        public async Task<ActionResult<IEnumerable<AgentLevel>>> GetAgentLevels()
        {
            return await _context.AgentLevels.ToListAsync();
        }

        [HttpGet("reward-types")]
        public async Task<ActionResult<IEnumerable<RewardType>>> GetRewardTypes()
        {
            return await _context.RewardTypes.ToListAsync();
        }

        [HttpGet("query-statuses")]
        public async Task<ActionResult<IEnumerable<QueryStatus>>> GetQueryStatuses()
        {
            return await _context.QueryStatuses.ToListAsync();
        }

        [HttpGet("agent-statuses")]
        public async Task<ActionResult<IEnumerable<AgentStatus>>> GetAgentStatuses()
        {
            return await _context.AgentStatuses.ToListAsync();
        }

        [HttpGet("user-profiles")]
        public async Task<ActionResult<IEnumerable<UserProfile>>> GetUserProfiles()
        {
            return await _context.UserProfiles.ToListAsync();
        }

        [HttpGet]
        [Route("GetUserProfileByID/{UserProfileId}")]
        public async Task<IActionResult> GetUserProfileByID(int UserProfileId)
        {
            return Ok(await _repository.GetUserProfileByID(UserProfileId));
        }

        [HttpPost("addUserProfile")]
        public async Task<UserProfileDto> AddUserProfile(UserProfileDto userProfileDto)
        {
            var userProfile = new UserProfile
            {
                ProfileDescription = userProfileDto.ProfileDescription
            };

            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();

            //userProfileDto.UserProfileID = userProfile.UserProfileID;

            return userProfileDto;
        }


        [HttpPut("EditUserProfileByID{UserProfileID}")]
        public async Task<IActionResult> EditUserProfile(int UserProfileID, [FromBody] UserProfileDto userProfileDto)
        {
            var user = await _context.UserProfiles.FindAsync(UserProfileID);
            if (user == null)
            {
                return NotFound();
            }

            user.UserProfileID = userProfileDto.UserProfileID;
            user.ProfileDescription = userProfileDto.ProfileDescription;
            _context.UserProfiles.Update(user);

            var result = await _userManager.FindByIdAsync(user.UserProfileID.ToString());
            if (result != null)
            {
                user.UserProfileID = userProfileDto.UserProfileID;
                user.ProfileDescription = userProfileDto.ProfileDescription;
                await _userManager.UpdateAsync(result);
            }

            var saveResult = await _context.SaveChangesAsync();
            if (saveResult == 0)
            {
                return BadRequest("Failed to update the agent.");
            }

            return Ok(user);
        }

        [HttpDelete("DeleteUserProfileByID{UserProfileID}")]
        public async Task DeleteUserProfile(int UserProfileID)
        {
            var userProfile = await _context.UserProfiles.FindAsync(UserProfileID);
            if (userProfile == null) return;

            _context.UserProfiles.Remove(userProfile);
            await _context.SaveChangesAsync();
        }


        [HttpGet("provinces")]
        public async Task<ActionResult<IEnumerable<Province>>> GetProvinces()
        {
            return await _context.Provinces.ToListAsync();
        }

        [HttpGet("offices")]
        public async Task<ActionResult<IEnumerable<Office>>> GetOffices()
        {
            return await _context.Offices.ToListAsync();
        }

        [HttpGet("owner-types")]
        public async Task<ActionResult<IEnumerable<OwnerType>>> GetOwnerTypes()
        {
            return await _context.OwnerTypes.ToListAsync();
        }

        [HttpGet("owners")]
        public async Task<ActionResult<IEnumerable<Owner>>> GetOwners()
        {
            return await _context.Owners.ToListAsync();
        }

        [HttpGet("parent-levels")]
        public async Task<ActionResult<IEnumerable<ParentLevel>>> GetParentLevels()
        {
            return await _context.ParentLevels.ToListAsync();
        }

        [HttpGet("earned-types")]
        public async Task<ActionResult<IEnumerable<EarnedType>>> GetEarnedTypes()
        {
            return await _context.EarnedTypes.ToListAsync();
        }

        [HttpGet("sales-channels")]
        public async Task<ActionResult<IEnumerable<SalesChannel>>> GetSalesChannels()
        {
            return await _context.SalesChannels.ToListAsync();
        }

        [HttpGet("schedules")]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedules()
        {
            return await _context.Schedules.ToListAsync();
        }
    }
}
