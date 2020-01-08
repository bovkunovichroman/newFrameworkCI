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
    public class StartPage
    {
        private IWebDriver driver;

        private const string BASE_URL = "http://bilet.aviakassa.by/";

        public StartPage(IWebDriver webDriver)
        {
            this.driver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "#header > div > div > div > div.cabinet.right.js-cabinet > a.js-login.do-login > span")]
        private IWebElement signInButton;

        [FindsBy(How = How.CssSelector, Using = "#email_login")]
        private IWebElement memberIdInput;

        [FindsBy(How = How.CssSelector, Using = "#pass_login")]
        private IWebElement passwordInput;

        [FindsBy(How = How.CssSelector, Using = "#login_popup > div.popup__content > form > div.row.login-popup__footer > div > input")]
        private IWebElement enterButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div/table[1]/tbody/tr[2]/td[2]/a")]
        private IWebElement plansPage;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div/div[1]/div[1]/ul/li[1]/label")]
        private IWebElement radioButtonOnlyTo;

        [FindsBy(How = How.Id, Using = "to_name")]
        private IWebElement takePlaceTo;
    
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div/div[1]/div[2]/form/div[2]/div/div[1]/div/input")]
        private IWebElement searchButton;

        [FindsBy(How = How.CssSelector, Using = "#header > div > div > div > div.cabinet.right.js-cabinet.logged_ico > a.js-my.login")]
        private IWebElement myTicketSpace;

        [FindsBy(How = How.CssSelector, Using = "#base_direction > div > div.fields_block > div.form-item.form-item--date.input-block.search_field.date_field > div > samp")]
        private IWebElement errorMessage;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/header/div/div/div/div[3]/a[1]")]
        private IWebElement textSignInButton;

        [FindsBy(How = How.ClassName, Using = "tooltip-btn")]
        private IWebElement feedBackClicker;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/footer/div[2]/div[2]/div[1]/div/div[1]/div[3]/div/div/div[2]/form/div[4]/input")]
        private IWebElement submitButton;
    
        [FindsBy(How = How.CssSelector, Using = "#footer > div.footer_contacts > div.footer-contacts-content > div.contacts_wrapper.show > div > div.row.first_sector > div.col-3.col-l-3.col-m-6.col-s-12.info-block_chat > div > div > div.tooltip__content > form > div:nth-child(2) > samp")]
        private IWebElement errorTextBeforeSubmitButton;

        [FindsBy(How = How.CssSelector, Using = "#base_direction > div > div.fields_block > div.form-item.form-item--date.input-block.search_field.date_field > div > samp")]
        private IWebElement errorTextToName;

        [FindsBy(How = How.CssSelector, Using = "#login_popup > div.form_row > a")]
        private IWebElement registrationLabel;

        public StartPage OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            return this;
        }

        public string GetTextSignInButton()
        {
            return textSignInButton.Text;
        }

        public string GetErrorMessage()
        {
            return errorMessage.Text;
        }

        public string GetErrorMessageTextToName()
        {
            return errorTextToName.Text;
        }

        public string GetErrorMessageTextBeforeSubmitButton()
        {
            return errorTextBeforeSubmitButton.Text;
        }

        public StartPage OpenRegistrationPage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
              .Until(ExpectedConditions.ElementToBeClickable(registrationLabel));
            registrationLabel.Click();
            return this;
        }

        public StartPage ClickSignInAccountButton()
        {
            signInButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(enterButton));
            return this;
        }

        public StartPage ClickMyTicket()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                  .Until(ExpectedConditions.ElementToBeClickable(myTicketSpace));
            myTicketSpace.Click();
            return this;
        }

        public StartPage FillInLoginAndPassword(SignIn signIn)
        {
            memberIdInput.SendKeys(signIn.MemberId);          
            passwordInput.SendKeys(signIn.Password);
            enterButton.Click();
            return this;
        }

        public StartPage GoToSearch(SearchResultWithoutDate SearchResultWithoutDate)
        {
            radioButtonOnlyTo.Click();
            takePlaceTo.SendKeys(SearchResultWithoutDate.InputSityTo);
            Thread.Sleep(2000);
            searchButton.Click();
            searchButton.Click();
            return this;
        }
        
        public StartPage CheckFeedBack()
        {
            feedBackClicker.Click();
            submitButton.Click();
            return this;
        }
    }
}
