using Microsoft.EntityFrameworkCore;
using VideoGameInfo.API.DbContexts;
using VideoGameInfo.API.Entities;

namespace VideoGameInfo.API.Services
{
    public class DeveloperInfoRepository : IDeveloperInfoRepository
    {
        private readonly VideoGameInfoContext _context;

        public DeveloperInfoRepository(VideoGameInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }    
        
        public async Task<IEnumerable<Developer>> GetDevelopersAsync()
        {
            return await _context.Developers.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Developer?> GetDeveloperAsync(int developerId, bool includeVideoGames)
        {
            if (includeVideoGames)
            {
                return await _context.Developers.Include(c => c.VideoGames).Where(c => c.Id == developerId).FirstOrDefaultAsync();
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

        public async Task<IEnumerable<VideoGame>> GetVideoGamesForDeveloperAsync(int developerId) 
        {
            return await _context.Games.Where(p => p.DeveloperId == developerId).ToListAsync();
        }

        public async Task<VideoGame?> GetVideoGameForDeveloperAsync(int developerId, int gameId)
        {
            return await _context.Games.Where(p => p.DeveloperId == developerId && p.Id == gameId).FirstOrDefaultAsync();
        }

        public async Task AddVideoGameForDeveloperAsync(int developerId, VideoGame videoGame)
        {
            var developer = await GetDeveloperAsync(developerId, false);
            if (developer != null)
            {
                developer.VideoGames.Add(videoGame);
            }
        }

        public  void DeleteVideoGameAsync(VideoGame videoGame)
        {
            _context.Games.Remove(videoGame);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
