using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoGameInfo.API.Models;
using VideoGameInfo.API.Services;

namespace VideoGameInfo.API.Controllers
{
    [ApiController]
    [Route("api/developers/{developerId}/pointsOfInterest")]
    public class VideoGamesController : ControllerBase
    {
        private readonly IDeveloperInfoRepository _developerInfoRepository;
        private readonly IMapper _mapper;

        public VideoGamesController(IDeveloperInfoRepository developerInfoRepository, IMapper mapper)
        {
            _developerInfoRepository = developerInfoRepository ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoGameDto>>> GetVideoGames(int developerId)
        {
            if (!await _developerInfoRepository.DeveloperExistsAsync(developerId))
            {
                return NotFound($"{nameof(GetVideoGames)}");
            }

            var videoGamesForDeveloper = await
                _developerInfoRepository.GetVideoGamesForDeveloperAsync(developerId);

            return Ok(_mapper.Map<IEnumerable<VideoGameDto>>(videoGamesForDeveloper));
        }


        [HttpGet("{videoGameId}", Name = "GetVideoGame")]
        public async Task<ActionResult<VideoGameDto>> GetVideoGame(int developerId, int videoGameId)
        {
            if (!await _developerInfoRepository.DeveloperExistsAsync(developerId))
            {
                return NotFound();
            }

            var videoGame = await _developerInfoRepository.GetVideoGameForDeveloperAsync(
                developerId, videoGameId);

            if (videoGame == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<VideoGameDto>(videoGame));
            }
        }
    }
}
