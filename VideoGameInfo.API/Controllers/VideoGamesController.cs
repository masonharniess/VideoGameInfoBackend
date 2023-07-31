using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoGameInfo.API.Entities;
using VideoGameInfo.API.Models;
using VideoGameInfo.API.Services;

namespace VideoGameInfo.API.Controllers
{
    [ApiController]
    [Route("api/developers/{developerId}/videogames")]
    public class VideoGamesController : ControllerBase
    {
        private readonly IDeveloperInfoRepository _developerInfoRepository;
        private readonly IMapper _mapper;

        public VideoGamesController(IDeveloperInfoRepository developerInfoRepository, IMapper mapper) {
            _developerInfoRepository = developerInfoRepository ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoGameDto>>> GetVideoGames(int developerId) {
            if (!await _developerInfoRepository.DeveloperExistsAsync(developerId))
            {
                return NotFound();
            }

            //IEnumerable<VideoGame> videoGamesForDeveloper = await
            //    _developerInfoRepository.GetVideoGamesForDeveloperAsync(developerId);

            //IEnumerable<VideoGameDto> results = videoGamesForDeveloper.ToDtos();

            IEnumerable<VideoGame> videoGamesForDeveloper = 
                await _developerInfoRepository.GetVideoGamesForDeveloperAsync(developerId);

            IEnumerable<VideoGameDto> results = _mapper.Map<IEnumerable<VideoGameDto>>(videoGamesForDeveloper);

            return Ok(results);
        }

        [HttpGet("{videoGameId}", Name = "GetVideoGame")]
        public async Task<ActionResult<VideoGameDto>> GetVideoGame(int developerId, int videoGameId) {
            if (!await _developerInfoRepository.DeveloperExistsAsync(developerId))
            {
                return NotFound();
            }

            VideoGame? videoGame = await _developerInfoRepository.GetVideoGameForDeveloperAsync(
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

        [HttpPost]
        public async Task<ActionResult<VideoGameDto>> CreateVideoGame(int developerId, [FromBody] VideoGameForCreationDto videoGame) {
            if (!await _developerInfoRepository.DeveloperExistsAsync(developerId))
            {
                return NotFound();
            }
            else
            {
                VideoGame finalVideoGame = _mapper.Map<VideoGame>(videoGame);

                await _developerInfoRepository.AddVideoGameForDeveloperAsync(developerId, finalVideoGame);
                await _developerInfoRepository.SaveChangesAsync();

                VideoGameDto createdVideoGameToReturn = _mapper.Map<VideoGameDto>(finalVideoGame);

                return CreatedAtRoute("GetVideoGame",
                    new
                    {
                        developerId = developerId,
                        videoGameId = finalVideoGame.Id
                    },
                    createdVideoGameToReturn);
            }
        }
    }

    //public static class VideoGameConversionExtension
    //{
    //    public static VideoGameDto ToDto(this Entities.VideoGame entity)
    //    {
    //        return new VideoGameDto(entity.Id, entity.Title)
    //        {
    //            Description = entity.Description,
    //        };
    //    }
        
    //    public static IEnumerable<VideoGameDto> ToDtos(this IEnumerable<Entities.VideoGame> entities)
    //    {
    //        IEnumerable<VideoGameDto> dtos = entities.Select(e => e.ToDto());
    //        return dtos;
    //    }
    //}

    public sealed class MyFrameworkClass
    {
        public int MyProperty { get; set; }
        public int MyProperty1 { get; set; }    

        public void DoStuff()
        {
            return;
        }
    }
}
