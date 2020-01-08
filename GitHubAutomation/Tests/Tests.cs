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
        private const string REQUIRED_LABEL_AFTER_AUTHORIZATION = "Мой билет";
        private const string REQUIRED_LABEL_TO_FILL = "Это поле необходимо заполнить";
        private const string BASE_MESSAGE = "СООБЩЕНИЕ";
        private const string REQUIRED_TO_TAKE_GENDER = "Укажите пол пассажира";
        private const string SELECTED_PLANE = "Боинг 707";

        [Test]
        public void SignInToAccount()
        {       
                Logger.Log.Info("Start SignInToAccount test.");
                StartPage startPage = new StartPage(DriverInstance.GetInstance())
                .OpenPage()
                .ClickSignInAccountButton()
                .FillInLoginAndPassword(Service.Service.WithUserPropertiesForSignIn());             
                Assert.AreEqual(REQUIRED_LABEL_AFTER_AUTHORIZATION, startPage.GetTextSignInButton());      
        }
        [Test]
        public void InputInvalidInputSityToWhenViewingSearchResultWithoutDateStatus()
        {
                Logger.Log.Info("Start InputInvalidInputSityToWhenViewingSearchResultWithoutDateStatus test.");
                StartPage startPage = new StartPage(DriverInstance.GetInstance())
               .OpenPage()
               .GoToSearch(Service.Service.WithSearchResultWithoutDateProperties());
                Assert.AreEqual(REQUIRED_LABEL_TO_FILL, startPage.GetErrorMessageTextToName());
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
            //Assert.AreEqual(BASE_MESSAGE, myTicketsPage.GetErrorMessageAlertAboutResave());
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
                Assert.AreEqual(REQUIRED_TO_TAKE_GENDER, myTicketsPage.GetwithoutGenderMessage());
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
                Assert.AreEqual(REQUIRED_LABEL_TO_FILL, myTicketsPage.GetConfirmPasswordSpace());

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
                Assert.AreEqual(REQUIRED_LABEL_TO_FILL, myTicketsPage.GetErrorMessageWithoutName());

        }
        [Test]
        public void LookInformationAboutBoeing707()
        {
                Logger.Log.Info("Start LookInformationAboutBoeing707 test.");      
                AirPlanesPage airPlanesPage = new AirPlanesPage(DriverInstance.GetInstance())
                .OpenAirPlanesPage()
                .ClickOnBoeing707();
                Assert.AreEqual(SELECTED_PLANE, airPlanesPage.GetNamePlane());
                 
        }
        [Test]
        public void FeedBackWithoutText()
        {
                Logger.Log.Info("Start FeedBackWithoutText test.");
                StartPage startPage = new StartPage(DriverInstance.GetInstance())
                .OpenPage()
                .CheckFeedBack();
                Assert.AreEqual(REQUIRED_LABEL_TO_FILL, startPage.GetErrorMessageTextBeforeSubmitButton());
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
            //Assert.AreEqual(BASE_MESSAGE, myTicketsPage.GetMessageAlertAboutPassword());
        }
        [Test]
        public void SingInWithoutPassword()
        {
                Logger.Log.Info("Start SingInWithoutPassword test.");
                StartPage startPage = new StartPage(DriverInstance.GetInstance())
                .OpenPage()
                .ClickSignInAccountButton()
                .FillInLoginAndPassword(Service.Service.WithUserPropertiesForSignInWithoutPassword());
                Assert.AreEqual(REQUIRED_LABEL_AFTER_AUTHORIZATION, startPage.GetTextSignInButton());
        }
 
    }
}