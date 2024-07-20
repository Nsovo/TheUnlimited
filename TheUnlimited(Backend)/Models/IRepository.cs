using System.Threading.Tasks;

namespace TheUnlimited_Backend_.Models
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Agent
        Task<Agent[]> GetAllAgentsAsync();
        Task<Agent> GetAgentAsync(int agentId);
        void Update<T>(T entity) where T : class;
        Task<UserProfile> GetUserProfileByID(int UserProfileId);
    }
}
