using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Model;
using GitHubAutomation.Service;
using GitHubAutomation.Driver;

namespace GitHubAutomation.Pages
{
    public class MyTicketsPage
    {
        private IWebDriver driver;

        public MyTicketsPage(IWebDriver webDriver)
        {
            this.driver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div.cabinet-menu > div > ul > li.js_data_user > a")]
        private IWebElement buyerData;

        [FindsBy(How = How.ClassName, Using = "btn save_userdata save_userdata__nomargin")]
        private IWebElement saveChangesButton;

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement nameSpace;

        [FindsBy(How = How.ClassName, Using = "btn js-popup-btn")]
        private IWebElement continueButtonOnAlertPopup;

        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div.cabinet-menu > div > ul > li.js_data_passenger > a")]
        private IWebElement passengerData;   
        
        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div.col-9.col-l-12 > div.cabinet-content > div.add_passenger_link > a")]
        private IWebElement addNewPassengerButton;

        [FindsBy(How = How.Id, Using = "passenger_last_name")]
        private IWebElement passengerLastNameInput;

        [FindsBy(How = How.Id, Using = "passenger_first_name")]
        private IWebElement passengerFirstNameInput;

        [FindsBy(How = How.Id, Using = "passenger_gender_M")]
        private IWebElement passengerGenderInput;

        [FindsBy(How = How.Id, Using = "passenger_birth_day")]
        private IWebElement passengerBirthDayInput;

        [FindsBy(How = How.Id, Using = "passenger_birth_month")]
        private IWebElement passengerBirthMonthInput;

        [FindsBy(How = How.Id, Using = "passenger_birth_year")]
        private IWebElement passengerBirthYearInput; 

        [FindsBy(How = How.Id, Using = "passenger_docnum")]
        private IWebElement passengerDocNUmInput;

        [FindsBy(How = How.Id, Using = "passenger_doc_expire_date_month")]
        private IWebElement passengeDocExpireDataMonthInput;

        [FindsBy(How = How.Id, Using = "passenger_doc_expire_date_day")]
        private IWebElement passengerDocExpireDateDayInput;

        [FindsBy(How = How.Id, Using = "passenger_doc_expire_date_year")]
        private IWebElement passengerDocExpireDateYearInput; 
        
        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div.col-9.col-l-12 > div.cabinet-content > div:nth-child(6) > form > div > div.confirm_passenger.row > a.btn.js-submit")]
        private IWebElement addPassengerButton;

        [FindsBy(How = How.CssSelector, Using = "#content > div.container > div > div.cabinet-menu.l-hide > div > ul > li.js_settings > a")]
        private IWebElement settingsSpace;

        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div.col-9.col-l-12 > div.cabinet-content.change-password-page > div > form > div.col-3.col-l-6.col-s-12 > a")]
        private IWebElement resaveButton;

        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div.col-9.col-l-12 > div.cabinet-content > div > form > div.col-3.col-l-6.col-s-12 > a")]
        private IWebElement resaveButtonForData;

        [FindsBy(How = How.ClassName, Using = "btn js-popup-btn")]
        private IWebElement continueButton;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement passwordInput;

        [FindsBy(How = How.Id, Using = "password_confirm")]
        private IWebElement passwordConfirmUnput;

        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div.col-9.col-l-12 > div.cabinet-content.change-password-page > div > form > div:nth-child(2) > samp")]
        public IWebElement confirmPasswordSpace;

        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div.col-9.col-l-12 > div.cabinet-content > div:nth-child(6) > form > div > div.db-col.db-col__gender > ul > li:nth-child(1) > div > samp")]
        public IWebElement withoutGenderMessage;

        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div.col-9.col-l-12 > div.cabinet-content > div:nth-child(6) > form > div > div.db-col.js-first-name > samp")]
        public IWebElement withoutName;

        [FindsBy(How = How.CssSelector, Using = "#alert_popup > div.popup__header")]
        public IWebElement alertAboutResave;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[1]/div/div[1]")]
        public IWebElement alertAboutPassword;

        public MyTicketsPage ClickPassengerData()
        {
            passengerData.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(addNewPassengerButton));
            return this;
        }

        public MyTicketsPage FillAllValuesInLabels(PassengerData passengerData)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
             .Until(ExpectedConditions.ElementToBeClickable(addNewPassengerButton));
            addNewPassengerButton.Click();
            passengerLastNameInput.SendKeys(passengerData.LastName);
            passengerFirstNameInput.SendKeys(passengerData.FirstName);
            passengerBirthDayInput.SendKeys(passengerData.BirthDay);
            passengerBirthMonthInput.SendKeys(passengerData.BirthMonth);
            passengerBirthYearInput.SendKeys(passengerData.BirthYear);
            passengerDocNUmInput.SendKeys(passengerData.DocNum);
            passengerDocExpireDateDayInput.SendKeys(passengerData.DocDay);
            passengerDocExpireDateYearInput.SendKeys(passengerData.DocYear);
            passengerBirthMonthInput.SendKeys(passengerData.DocMonth);
            addPassengerButton.Click();
            return this;
        }

        public MyTicketsPage FillAllValuesInLabelsWithoutFirstName(PassengerData passengerData)
        {
            passengerLastNameInput.SendKeys(passengerData.LastName); 
            passengerGenderInput.Click();
            passengerBirthDayInput.SendKeys(passengerData.BirthDay);
            passengerBirthMonthInput.SendKeys(passengerData.BirthMonth);
            passengerBirthYearInput.SendKeys(passengerData.BirthYear);
            passengerDocNUmInput.SendKeys(passengerData.DocNum);
            passengerDocExpireDateDayInput.SendKeys(passengerData.DocDay);
            passengerDocExpireDateYearInput.SendKeys(passengerData.DocYear);
            passengerBirthMonthInput.SendKeys(passengerData.DocMonth);
            addPassengerButton.Click();
            return this;
        }

        public MyTicketsPage ClickToResaveBuyerData()
        {
            buyerData.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
          .Until(ExpectedConditions.ElementToBeClickable(resaveButtonForData));
            resaveButtonForData.Click();
            return this;
        }

        public MyTicketsPage ChangePassword(ChangePasssword passwordRe)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
          .Until(ExpectedConditions.ElementToBeClickable(settingsSpace));
            settingsSpace.Click();
            passwordInput.SendKeys(passwordRe.NewPassword);
            passwordConfirmUnput.SendKeys(passwordRe.RepeatNewPassword);
            resaveButton.Click();         
            return this;
        }

    
    





    }
}
