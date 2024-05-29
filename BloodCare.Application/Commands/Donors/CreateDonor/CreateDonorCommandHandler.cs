using BloodCare.Application.Abstractions;
using BloodCare.Domain.Entities;
using BloodCare.Domain.Enums;
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
            var donor = await _donorRepository.GetFirstByQueryAsync(x => x.Email == request.Email && x.Situation == DonorSituation.Active);
             if (donor != null)
                return Result<Donor>.Failure($"Já existe um doador cadastrado com o email {donor.Email}.");

            donor = new Donor(request.FullName, request.Email, request.DateOfBirth, request.Cpf, request.Gender, request.Weight, request.BloodType, request.RhFactor, request.Address);

            await _donorRepository.InsertAsync(donor);

            return Result<Donor>.Success(donor, $"Donor {donor.FullName} cadastrado com sucesso.");
        }
    }
}

