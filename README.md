# BloodCare

## Description

BloodCare is a blood donation database management system that offers functionalities such as donor registration, blood stock control, donation recording, donor lookup, and report generation.

## Features

- **Donor Registration**
  - Data validation

- **Donation Recording**
  - Updates blood stock upon recording a donation

- **Donor Lookup**
  - View donation history of a donor

- **Report Generation**
  - Total blood quantity by type available
    
## Business Rules

- Do not allow registration of a donor with the same email
- Minors can be registered but cannot donate
- Minimum weight for donation: 50KG
- Women can donate every 90 days
- Men can donate every 60 days
- Blood donation volume must be between 420ml and 470ml

## Technologies Used

- C#
- ASP.NET Core 8.0
- MongoDB

## Project Structure

### Checklist

- [x] Clean Architecture
- [x] Entities
- [x] API Extensions
- [x] Result Pattern
- [x] CQRS
- [x] Mapper
- [ ] Controllers
- [ ] IUnitOfWork
- [ ] JWT
- [ ] UnitTest
- [ ] HostedService

## Installation and Setup

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [MongoDB](https://www.mongodb.com/try/download/community)

### Cloning the Repository

```bash
git clone https://github.com/GPedrozaR/BloodCare.git
cd BloodCare
