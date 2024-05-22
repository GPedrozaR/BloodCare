using BloodCare.Application.Abstractions;
using BloodCare.Domain.Entities;
using BloodCare.Domain.Repositories;
using MediatR;

namespace BloodCare.Application.Commands.Donors.CreateDonor
{
    public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, Result<Donor>>
    {
        public CreateDonorCommandHandler(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        private readonly IDonorRepository _donorRepository;

        public async Task<Result<Donor>> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = new Donor(request.FullName, request.Email, request.DateOfBirth, request.Gender, request.Weight, request.BloodType, request.RhFactor, request.Address);
            await _donorRepository.AddAsync(donor);

            return Result<Donor>.Success(donor, $"Donor {donor.FullName} cadastrado com sucesso.");
        }
    }
}

