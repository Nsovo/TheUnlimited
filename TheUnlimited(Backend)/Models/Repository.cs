using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TheUnlimited_Backend_.Models
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        // Agent
        public async Task<Agent[]> GetAllAgentsAsync()
        {
            return await _context.Agents
                .Include(a => a.AgentLevel)
                .Include(a => a.AgentStatus)
                .Include(a => a.Office)
                .ToArrayAsync();
        }

        public async Task<Agent> GetAgentAsync(int agentId)
        {
            return await _context.Agents
                .Include(a => a.AgentLevel)
                .Include(a => a.AgentStatus)
                .Include(a => a.Office)
                .FirstOrDefaultAsync(a => a.AgentID == agentId);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<UserProfile> GetUserProfileByID(int UserProfileId)
        {
            return await _context.UserProfiles.FindAsync(UserProfileId);
        }
    }
}
