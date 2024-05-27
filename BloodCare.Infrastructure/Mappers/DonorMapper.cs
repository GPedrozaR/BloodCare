﻿using BloodCare.Domain.Entities;
using BloodCare.Domain.Interfaces;
using BloodCare.Infrastructure.MongoDbEntities.Entities;
using MongoDB.Bson;
using System.Linq.Expressions;

namespace BloodCare.Infrastructure.Mappers
{
    public class DonorMapper : IMapper<Donor, DonorMongoDb>
    {
        public DonorMongoDb ToInfrastructure(Donor donor)
        {
            return new DonorMongoDb
            {
                Id = ObjectId.Parse(donor.Id),
                FullName = donor.FullName,
                Email = donor.Email,
                Cpf = donor.Cpf,
                Gender = donor.Gender,
                Weight = donor.Weight,
                DateOfBirth = donor.DateOfBirth,
                BloodType = donor.BloodType,
                RhFactor = donor.RhFactor,
                Situation = donor.Situation,
                UpdatedAt = donor.UpdatedAt,
                Address = donor.Address
            };
        }

        public Donor ToDomain(DonorMongoDb donorMongo)
        {
            return new Donor(
                donorMongo.FullName,
                donorMongo.Email,
                donorMongo.DateOfBirth,
                donorMongo.Cpf,
                donorMongo.Gender,
                donorMongo.Weight,
                donorMongo.BloodType,
                donorMongo.RhFactor,
                donorMongo.Address
            )
            {
                Id = donorMongo.Id.ToString(),
                UpdatedAt = donorMongo.UpdatedAt,
                Situation = donorMongo.Situation
            };
        }

        public Expression<Func<TInfrastructure, bool>> ToInfrastructureFilter(Expression<Func<TDomain, bool>> domainFilter)
        {
            return Mapper.Map<Expression<Func<TInfrastructure, bool>>>(domainFilter);
        }
    }
}

