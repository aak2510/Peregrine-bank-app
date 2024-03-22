<?xml version="1.0" encoding="UTF-8"?>
<PeregrineAcmeBankApplication>
    <Overview>
        <Repository>
            <Description>
                This repository contains the C# application for Acme Bank, designed to facilitate bank tellers in accessing customer accounts.
            </Description>
            <Features>
                <AccountManagement>
                    <Type>Personal</Type>
                    <Type>ISA</Type>
                    <Type>Business</Type>
                </AccountManagement>
            </Features>
        </Repository>
    </Overview>
    <GeneralRules>
        <CustomerOwnership>One customer can own one of each account type.</CustomerOwnership>
        <AuthenticationMethods>Software includes authentication methods without direct customer access.</AuthenticationMethods>
        <ExceptionHandling>Exception handling is implemented to maintain functionality with unexpected data entries.</ExceptionHandling>
        <MenuSystem>A simple menu system for validated information submission is implemented.</MenuSystem>
        <HelpSystem>Help system is linked to user actions for support.</HelpSystem>
    </GeneralRules>
    <ProjectStructure>
        <!-- Structure details here -->
    </ProjectStructure>
    <Setup>
        <CloneCommand>
            git clone https://github.com/aak2510/Peregrine-bank-app.git
        </CloneCommand>
    </Setup>
    <Usage>
        <Step>
            Open the project in Visual Studio.
        </Step>
        <Step>
            Run the application.
        </Step>
    </Usage>
    <Contributors>
        <Contributor>Anish</Contributor>
        <Contributor>Misha</Contributor>
        <Contributor>Nikhil</Contributor>
        <Contributor>Elliot</Contributor>
    </Contributors>
    <License>
        <Type>MIT License</Type>
        <Details>See the LICENSE.md file for details.</Details>
    </License>
</PeregrineAcmeBankApplication>
