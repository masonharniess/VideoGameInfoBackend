using Microsoft.EntityFrameworkCore;
using VideoGameInfo.API.DbContexts;
using VideoGameInfo.API.Entities;

namespace VideoGameInfo.API.Services
{
    public class VideoGameInfoRepository : IVideoGameInfoRepository
    {
        private readonly VideoGameInfoContext _context;

        public VideoGameInfoRepository(VideoGameInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }    
        
        public async Task<IEnumerable<Developer>> GetDevelopersAsync()
        {
            return await _context.Developers.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Developer?> GetDeveloperAsync(int developerId, bool includeGames)
        {
            if (includeGames)
            {
                return await _context.Developers.Where(c => c.Id == developerId).FirstOrDefaultAsync();
            }
            else
            {
                return await _context.Developers.Where(c => c.Id == developerId).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> DeveloperExistsAsync(int developerId)
        {
            return await _context.Developers.AnyAsync(c  => c.Id == developerId);
        }

        public async Task<IEnumerable<Game>> GetGamesForDeveloperAsync(int developerId) 
        {
            return await _context.Games.Where(p => p.DeveloperId == developerId).ToListAsync();
        }

        public async Task<Game?> GetGameForDeveloperAsync(int developerId, int gameId)
        {
            return await _context.Games.Where(p => p.DeveloperId == developerId && p.Id == gameId).FirstOrDefaultAsync();
        }

        public async Task AddGameForDeveloperAsync(int developerId, Game game)
        {
            var developer = await GetDeveloperAsync(developerId, false);
            if (developer != null)
            {
                developer.Games.Add(game);
            }
        }

        public  void DeleteGameAsync(Game game)
        {
            _context.Games.Remove(game);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
