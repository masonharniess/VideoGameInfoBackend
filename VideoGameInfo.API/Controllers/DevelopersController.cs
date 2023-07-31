using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VideoGameInfo.API.Entities;
using VideoGameInfo.API.Models;
using VideoGameInfo.API.Services;

namespace VideoGameInfo.API.Controllers
{

    [ApiController]
    [Route("api/developers")]
    public class DevelopersController : ControllerBase
    {
        private readonly IDeveloperInfoRepository _developerInfoRepository;
        private readonly IMapper _mapper;

        public DevelopersController(IDeveloperInfoRepository developerInfoRepository, IMapper mapper) {
            _developerInfoRepository = developerInfoRepository
                ?? throw new ArgumentNullException(nameof(developerInfoRepository));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DevelopersWithoutGamesDto>>> GetDevelopers() {
            IEnumerable<Developer> developerEntities = await _developerInfoRepository.GetDevelopersAsync();
            return Ok(_mapper.Map<IEnumerable<DevelopersWithoutGamesDto>>(developerEntities));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeveloper(int id, bool includeVideoGames = false) {

            Developer? developer = await _developerInfoRepository.GetDeveloperAsync(id, includeVideoGames);
            
            if (developer == null)
            {
                return NotFound();
            }
            
            if (includeVideoGames)
            {
                return Ok(_mapper.Map<DeveloperDto>(developer));
            }
            else
            {
                return Ok(_mapper.Map<DevelopersWithoutGamesDto>(developer));
            }
        }
    }
}
