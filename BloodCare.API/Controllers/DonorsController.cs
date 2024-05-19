namespace BloodCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllDonors(string query)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonorById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewDonor()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDonor()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonor(int id)
        {
            return Ok();
        }
    }
}
