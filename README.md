# Peregrine Acme Bank Application

## Overview

This repository contains the C# application for Acme Bank, designed to facilitate bank tellers in accessing customer accounts. The application handles three types of accounts: Personal, ISA, and Business, each with unique features and rules.

## Features

- **Personal Account Management**: Handles photo ID and address-based ID verification, direct debits, and standing orders.
- **ISA Account Management**: Manages accounts with an annual APR of 2.75% and adheres to ISA regulations.
- **Business Account Management**: Supports existing businesses with features like cheque books, cards, overdrafts, international trading, and loans.

## General Rules

- A customer can own one of each account type.
- The software includes authentication methods without direct customer access.
- Exception handling is implemented to maintain functionality with unexpected data entries.
- A simple menu system for validated information submission.
- Help system is linked to user actions for support.

## Project Structure

- README.md: The main documentation file for the project.
- /AcmeBank.Domain: Contains business logic and domain models.
- /Models: Domain entities.
  - Customer.cs: Defines the customer entity.
  - Account.cs: Base class for accounts.
  - PersonalAccount.cs: Represents a personal account.
  - ISAaccount.cs: Represents an ISA account.
  - BusinessAccount.cs: Represents a business account.
- /Services: Interfaces for services in the domain.
  - IAccountService.cs: Interface for account-related services.
  - IPaymentService.cs: Interface for payment services.
  - ITransactionService.cs: Interface for transaction services.
- /Enums: Enums and constants.
  - AccountType.cs: Enumerates the types of accounts.
  - /AcmeBank.Application: Application layer (Use cases, application services).
- /Interfaces: Interfaces for application services.
  - ICustomerAppService.cs: Interface for customer application services.
  - IAccountAppService.cs: Interface for account application services.
  - IPaymentAppService.cs: Interface for payment application services.
- /DTOs: Data Transfer Objects.
  - CustomerDto.cs: Data transfer object for customer information.
  - AccountDto.cs: Data transfer object for account information.
  - TransactionDto.cs: Data transfer object for transaction information.
- /Services: Implementations of application services.
  - CustomerAppService.cs: Implements customer application services.
  - AccountAppService.cs: Implements account application services.
  - PaymentAppService.cs: Implements payment application services.
  - /AcmeBank.Infrastructure: Infrastructure layer (Data access, external services).
- /Persistence: Database context and repositories.
    - /Repositories:
      - ICustomerRepository.cs: Interface for customer repository.
      - IAccountRepository.cs: Interface for account repository.
      - ITransactionRepository.cs: Interface for transaction repository.
    - /EntityConfigurations: EF configurations.
      - AcmeBankDbContext.cs: Database context for Entity Framework.
- /PaymentServices: Payment service implementations.
  - DirectDebitService.cs: Handles direct debit operations.
  - StandingOrderService.cs: Manages standing orders.
- /Logging: Logging infrastructure.
  - Logger.cs: Application-wide logger.
  - /AcmeBank.Presentation: UI and presentation layer.
- /ConsoleApp: Console application for teller interactions.
  - Program.cs: Entry point for the console application.
  - MenuSystem.cs: Handles the user interface for the console application.
- /WebAPI: Optional future web interface.
    - /Controllers: Web API controllers.
      - Startup.cs: Configuration for Web API startup.
      - /AcmeBank.Tests: Unit and integration tests.
- /Domain.Tests: Tests for domain models.
- /Application.Tests: Tests for application services.
- /Infrastructure.Tests: Tests for infrastructure services.
- /Presentation.Tests: Tests for presentation and UI.

## Setup

git clone https://github.com/aak2510/Peregrine-bank-app.git

## Usage

1. Open the project in Visual Studio.
2. Run the application.

## Contributors

- Anish
- Misha
- Nikhil
- Elliot

## License

This project is licensed under the MIT License - see the LICENSE.md file for details.

