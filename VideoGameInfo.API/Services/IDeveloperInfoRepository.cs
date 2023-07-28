using VideoGameInfo.API.Entities;

namespace VideoGameInfo.API.Services
{
    public interface IDeveloperInfoRepository
    {
        Task<IEnumerable<Developer>> GetDevelopersAsync();
        Task<Developer?> GetDeveloperAsync(int developerId, bool includeVideoGames);
        Task<bool> DeveloperExistsAsync(int developerId);
        Task<IEnumerable<VideoGame>> GetVideoGamesForDeveloperAsync(int developerId);
        Task<VideoGame?> GetVideoGameForDeveloperAsync(int developerId, int gameId);
        Task AddVideoGameForDeveloperAsync(int developerId, VideoGame game);
        void DeleteVideoGameAsync(VideoGame game);
        Task<bool> SaveChangesAsync();
    }
}
