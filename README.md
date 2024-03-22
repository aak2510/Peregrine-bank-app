# Peregrine Acme Bank Application

## Overview

This repository contains the C# application for Acme Bank, designed to facilitate bank tellers in accessing customer accounts. The application handles three types of accounts: Personal, ISA, and Business, each with unique features and rules.

## Features

- **Teller and User Login**: Handles Passport and Address based verification
- **Personal Account Management**: Direct debits, and Standing orders.
- **ISA Account Management**: Manages accounts with an annual APR of 2.75% and adheres to ISA regulations.
- **Business Account Management**: Supports existing businesses with features like cheque books, cards, overdrafts, international trading, and loans.

## General Rules

- A customer can own one of each account type.
- The software includes authentication methods with direct customer access.
- Exception handling is implemented to maintain functionality with unexpected data entries.
- A simple menu system for validated information submission.

## Project Structure

- /AcmeBank.Domain: Contains business logic and domain models.
  - /Models: Domain entities.
    - Customer.cs: Defines the customer entity.
    - Account.cs: Base class for accounts.
    - PersonalAccount.cs: Represents a personal account.
    - ISAaccount.cs: Represents an ISA account.
    - BusinessAccount.cs: Represents a business account.
  - /Enums: Enums and constants.
    - AccountType.cs: Enumerates the types of accounts.
- /AcmeBank.Application: Application layer (Use cases, application services).
  - /Services: Implementations of application services.
    - CustomerAppService.cs: Implements customer application services.
    - AccountAppService.cs: Implements account application services.
    - PaymentAppService.cs: Implements payment application services.
  - /Interfaces: Interfaces for application services.
    - ICustomerAppService.cs: Interface for customer application services.
    - IAccountAppService.cs: Interface for account application services.
    - IPaymentAppService.cs: Interface for payment application services.
- /AcmeBank.Infrastructure: Infrastructure layer (Data access, external services).
  - /Persistence: Database context and repositories.
    - /Repositories:
      - ICustomerRepository.cs: Interface for customer repository.
      - IAccountRepository.cs: Interface for account repository.
      - ITransactionRepository.cs: Interface for transaction repository.
    - /EntityConfigurations: EF configurations.
      - AcmeBankDbContext.cs: Database context for Entity Framework.
    - /Scripts: Scripts to instantiate the Database and Data
      - /Seed
        - 01_SeedUsers.sql: Data for Users Table
        - 02_SeedPersonalAccounts.sql: Data for Personal Accounts Table
        - 03_SeedISAAccounts.sql: Data for ISA Accounts Table
        - 04_SeedBusinessAccounts.sql: Data for Business Accounts Table
        - 05_SeedTellers.sql: Data for Tellers Table
        - 06_SeedTransactions.sql: Data for Transactions Table
        - 07_SeedSecurityQA.sql: Data for Security QA Table
      - /Setup
        - 01_CreateTables.sql: Creates Tables for Database
- /AcmeBank.Presentation: UI and presentation layer.
  - /ConsoleApp: Console application for teller interactions.
    - Program.cs: Entry point for the console application.
    - MenuSystem.cs: Handles the user interface for the console application.
    - TellerLoginHandler.cs: The Database Request for the teller log in
    - UserLoginHandler.cs: The Database Request for the user log in
- README.md: The main documentation file for the project.

## Setup

1. git clone https://github.com/aak2510/Peregrine-bank-app.git
2. Set up your pgadmin Database 'acmebankdb'
3. Create the structure and insert Data into the Database using the SQL commands
4. Set up your Environment Variable to connect to the database


## Usage

1. Open the project in Visual Studio.
2. Run 'dotnet build' in the root directory
3. Run 'dotnet run' in the backend/AcmeBank.Presentation/AcmeBank.ConsoleApp folder
4. Interact with the CLI using your keyboard
5. The information on users and passwords is provided within the SQL files in the AcmeBank.Infrastructure folder

## Contributors

- Anish
- Misha
- Nikhil
- Elliot

## License

This project is licensed under the MIT License - see the LICENSE.md file for details.

