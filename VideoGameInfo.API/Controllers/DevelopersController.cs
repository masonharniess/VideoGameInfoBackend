using Microsoft.AspNetCore.Mvc;
using VideoGameInfo.API.Models;

namespace VideoGameInfo.API.Controllers
{

    [ApiController]
    [Route("api/developers")]
    public class DevelopersController : ControllerBase
    {

        public DevelopersController() { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DevelopersWithoutGamesDto>>> GetDevelopers()
        {

            return Ok();
        }
    }
}
