using BloodCare.Application.Abstractions;
using BloodCare.Domain.Entities;
using BloodCare.Domain.Repositories;
using MediatR;

namespace BloodCare.Application.Commands.Donations.CreateDonation
{
    public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, Result<Donation>>
    {
        public CreateDonationCommandHandler(IDonorRepository donorRepository, IDonationRepository donationRepository, IBloodStockRepository bloodStockRepository)
        {
            _donorRepository = donorRepository;
            _donationRepository = donationRepository;
            _bloodStockRepository = bloodStockRepository;
        }

        private readonly IDonorRepository _donorRepository;
        private readonly IDonationRepository _donationRepository;
        private readonly IBloodStockRepository _bloodStockRepository;

        public async Task<Result<Donation>> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetFirstByQueryAsync(d => d.Id == request.DonorId && d.Situation == Domain.Enums.DonorSituation.Active);
            if (donor is null || !donor.CanDonate())
                return Result<Donation>.Failure();

            var donations = await _donationRepository.GetAllByQueryAsync(x => x.DonorId == request.DonorId);
            
            var lastDonation = donations?.OrderBy(d => d.CreatedAt).LastOrDefault();
            if (lastDonation is not null)
            {
                var differenceDays = (DateTime.UtcNow - lastDonation.CreatedAt).TotalDays;

                var maxDaysBetweenDonations = donor.Gender.Equals("Feminino", StringComparison.OrdinalIgnoreCase) ? 90 : 60;

                if (differenceDays < maxDaysBetweenDonations)
                    return Result<Donation>.Failure("Donation frequency exceeded");
            }

            var donation = new Donation(request.DonorId, request.Milliliters);
            if (!donation.ValidateMilliliters()) 
                return Result<Donation>.Failure();

            await _donationRepository.InsertAsync(donation);

            await UpdateBloodStock(request, donor);

            return Result<Donation>.Success(donation, $"Donation {donation.Id} created");
        }

        private async Task UpdateBloodStock(CreateDonationCommand request, Donor donor)
        {
            var bloodStock = await _bloodStockRepository.GetFirstByQueryAsync(bs => bs.RhFactor == donor.RhFactor && bs.BloodType == donor.BloodType);
            if (bloodStock is null)
                bloodStock = new BloodStock(donor.BloodType, donor.RhFactor, request.Milliliters);
            else
                bloodStock.UpdateMilliliters(request.Milliliters);

            await _bloodStockRepository.InsertAsync(bloodStock);
        }
    }
}
