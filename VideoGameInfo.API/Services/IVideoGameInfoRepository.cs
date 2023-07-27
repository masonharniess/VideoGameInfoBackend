using VideoGameInfo.API.Entities;

namespace VideoGameInfo.API.Services
{
    public interface IVideoGameInfoRepository
    {
        Task<IEnumerable<Developer>> GetDevelopersAsync();
        Task<Developer?> GetDeveloperAsync(int developerId, bool includeGames);
        Task<bool> DeveloperExistsAsync(int developerId);
        Task<IEnumerable<Game>> GetGamesForDeveloperAsync(int developerId);
        Task<Game?> GetGameForDeveloperAsync(int developerId, int gameId);
        Task AddGameForDeveloperAsync(int developerId, Game game);
        void DeleteGameAsync(Game game);
        Task<bool> SaveChangesAsync();
    }
}
