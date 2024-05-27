using BloodCare.Application.Commands.Donors.CreateDonor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonorsController : ControllerBase
    {
        public DonorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

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
        public async Task<IActionResult> CreateNewDonor(CreateDonorCommand command)
        {
            var result = await _mediator.Send(command);
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
