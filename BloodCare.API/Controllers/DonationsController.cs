namespace BloodCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllDonations(int id)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonationById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewDonation()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDonation()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonation(int id)
        {
            return Ok();
        }

    }
}
