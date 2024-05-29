using BloodCare.Application.Abstractions;
using BloodCare.Domain.Entities;
using MediatR;

namespace BloodCare.Application.Commands.Donations.CreateDonation
{
    public sealed record CreateDonationCommand(string DonorId, int Milliliters) : IRequest<Result<Donation>>;
}
