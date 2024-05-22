using BloodCare.Application.Abstractions;
using BloodCare.Domain.Entities;
using BloodCare.Domain.Enums;
using MediatR;

namespace BloodCare.Application.Commands.Donors.CreateDonor
{
    public sealed record CreateDonorCommand(
    string FullName,
    string Email,
    string Gender,
    DateTime DateOfBirth,
    double Weight,
    BloodType BloodType,
    RhFactor RhFactor,
    Address? Address) : IRequest<Result<Donor>>;
}
