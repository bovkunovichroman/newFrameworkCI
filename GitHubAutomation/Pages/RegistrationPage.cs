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
    public class RegistrationPage
    {
        private IWebDriver driver;

        private const string BASE_URL = "https://aviakassa.by/airplanes";

        public RegistrationPage(IWebDriver webDriver)
        {
            this.driver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }
        
        [FindsBy(How = How.Id, Using = "first_name")]
        private IWebElement registrationFirstName;

        [FindsBy(How = How.Id, Using = "last_name")]
        private IWebElement registrationLastName;

        [FindsBy(How = How.Id, Using = "email_register")]
        private IWebElement registrationEmail;

        [FindsBy(How = How.Id, Using = "pass_register")]
        private IWebElement registrationPassword;

        [FindsBy(How = How.ClassName, Using = "error _idx_5")]
        public IWebElement registrationError;

        [FindsBy(How = How.ClassName, Using = "form-submit btn_reg")]
        private IWebElement registrationButton;
    
        public RegistrationPage FillRegistrationPage(Registration registration)
        {
            registrationFirstName.SendKeys(registration.FirstName);
            registrationLastName.SendKeys(registration.LastName);
            registrationEmail.SendKeys(registration.Email);
            registrationButton.Click();
            return this;
        }
    }
}
