using Microsoft.AspNetCore.Mvc;

namespace BloodCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BloodStocksController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(int skip = 0, int take = 50)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }

        [HttpGet("bloodData")]
        public async Task<IActionResult> GetByBloodType(string bloodType, string rhFactor)
        {

            return Ok();
        }
    }
}
