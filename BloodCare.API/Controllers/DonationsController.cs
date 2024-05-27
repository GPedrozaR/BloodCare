using BloodCare.Application.Commands.Donations.CreateDonation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonationsController : ControllerBase
    {
        public DonationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

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
        public async Task<IActionResult> CreateNewDonation(CreateDonationCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess
                ? Created(result.Message, result.Data)
                : NoContent();
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
