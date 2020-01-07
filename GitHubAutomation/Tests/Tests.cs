using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using GitHubAutomation.Driver;
using GitHubAutomation.Service;
using GitHubAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.Extensions;
using GitHubAutomation.Utils;
using System.Threading;

namespace GitHubAutomation.Tests
{
    [TestFixture]
    public class Tests : TestListener
    {
        [Test]
        public void SignInToAccount()
        {       
                Logger.Log.Info("Start SignInToAccount test.");
                StartPage startPage = new StartPage(DriverInstance.GetInstance())
                .OpenPage()
                .ClickSignInAccountButton()
                .FillInLoginAndPassword(Service.Service.WithUserPropertiesForSignIn());             
                Assert.AreEqual("Мой билет", startPage.textSignInButton.Text);      
        }

        [Test]
        public void InputInvalidInputSityToWhenViewingSearchResultWithoutDateStatus()
        {
                Logger.Log.Info("Start InputInvalidInputSityToWhenViewingSearchResultWithoutDateStatus test.");
                StartPage startPage = new StartPage(DriverInstance.GetInstance())
               .OpenPage()
               .GoToSearch(Service.Service.WithSearchResultWithoutDateProperties());
                Assert.AreEqual("Это поле необходимо заполнить", startPage.errorTextToName.Text);
        }
        [Test]
        public void ResaveValuesInBuyerDataWithoutChanges()
        {
                Logger.Log.Info("Start ResaveValuesInBuyerDataWithoutChanges test.");
                StartPage startPage = new StartPage(DriverInstance.GetInstance())
                .OpenPage()
                .ClickSignInAccountButton()
                .FillInLoginAndPassword(Service.Service.WithUserPropertiesForSignIn())
                .ClickMyTicket();
                MyTicketsPage myTicketsPage = new MyTicketsPage(DriverInstance.GetInstance())
                .ClickToResaveBuyerData();
        }
        [Test]
        public void AddNewPassengerWithoutGender()
        {
                Logger.Log.Info("Start AddNewPassenger test.");
                StartPage startPage = new StartPage(DriverInstance.GetInstance())
                .OpenPage()
                .ClickSignInAccountButton()
                .FillInLoginAndPassword(Service.Service.WithUserPropertiesForSignIn())
                .ClickMyTicket();
                MyTicketsPage myTicketsPage = new MyTicketsPage(DriverInstance.GetInstance())
                .ClickPassengerData()
                .FillAllValuesInLabels(Service.Service.WithPassengerDataProperties());
                Assert.AreEqual("Укажите пол пассажира", myTicketsPage.withoutGenderMessage.Text);
        }
        [Test]
        public void ChangePasswordWithoutConfirm()
        {
                Logger.Log.Info("Start ChangePasswordWithoutConfirm test.");
                StartPage startPage = new StartPage(DriverInstance.GetInstance())
                .OpenPage()
                .ClickSignInAccountButton()
                .FillInLoginAndPassword(Service.Service.WithUserPropertiesForSignIn())
                .ClickMyTicket();
                Thread.Sleep(100);
                MyTicketsPage myTicketsPage = new MyTicketsPage(DriverInstance.GetInstance())
                .ChangePassword(Service.Service.WithUserPropertiesWithoutRepeat());
                Assert.AreEqual("Это поле необходимо заполнить", myTicketsPage.confirmPasswordSpace.Text);

        }
        [Test]
        public void AddNewPassengerWithoutName()
        {
                Logger.Log.Info("Start AddNewPassengerWithoutName test.");
                StartPage startPage = new StartPage(DriverInstance.GetInstance())
                .OpenPage()
                .ClickSignInAccountButton()
                .FillInLoginAndPassword(Service.Service.WithUserPropertiesForSignIn())
                .ClickMyTicket();
                MyTicketsPage myTicketsPage = new MyTicketsPage(DriverInstance.GetInstance())
                .ClickPassengerData()
                .FillAllValuesInLabels(Service.Service.WithPassengerDataPropertiesWithoutName());
                Assert.AreEqual("Это поле необходимо заполнить", myTicketsPage.withoutName.Text);

        }
        [Test]
        public void LookInformationAboutBoeing707()
        {
                Logger.Log.Info("Start LookInformationAboutBoeing707 test.");      
                AirPlanesPage airPlanesPage = new AirPlanesPage(DriverInstance.GetInstance())
                .OpenAirPlanesPage()
                .ClickOnBoeing707();
                Assert.AreEqual("Боинг 707", airPlanesPage.namePlane.Text);
                 
        }
        [Test]
        public void RegistrationWithoutNumber()
        {
                Logger.Log.Info("Start RegistrationWithoutNumber test.");
                StartPage startPage = new StartPage(DriverInstance.GetInstance())
                .OpenPage()
                .ClickSignInAccountButton()
                .OpenRegistrationPage();
                RegistrationPage registrationPage = new RegistrationPage(DriverInstance.GetInstance())
                .FillRegistrationPage(Service.Service.WithPropertiesAboutRegistration());            
        }
        [Test]
        public void FeedBackWithoutText()
        {
                Logger.Log.Info("Start FeedBackWithoutText test.");
                StartPage startPage = new StartPage(DriverInstance.GetInstance())
                .OpenPage()
                .CheckFeedBack();
                Assert.AreEqual("Это поле необходимо заполнить", startPage.errorTextBeforeSubmitButton.Text);
        }
        [Test]
        public void ChangePassword()
        {
            Logger.Log.Info("Start ChangePassword test.");
            StartPage startPage = new StartPage(DriverInstance.GetInstance())
            .OpenPage()
            .ClickSignInAccountButton()
            .FillInLoginAndPassword(Service.Service.WithUserPropertiesForSignIn())
            .ClickMyTicket();
            MyTicketsPage myTicketsPage = new MyTicketsPage(DriverInstance.GetInstance())
            .ChangePassword(Service.Service.WithUserPropertiesRepeatNewPassword());

        }

    }
}
