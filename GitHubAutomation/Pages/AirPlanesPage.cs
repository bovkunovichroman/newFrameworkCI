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
    public class AirPlanesPage

    {
        private IWebDriver driver;

        private const string BASE_URL = "https://aviakassa.by/airplanes";

        public AirPlanesPage(IWebDriver webDriver)
        {
            this.driver = webDriver;
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[2]/div/table/tbody/tr[25]/td[2]/a")]
        private IWebElement infoAboutBoeing707;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[2]/div/h1")]
        public IWebElement namePlane;

        public AirPlanesPage ClickOnBoeing707()
        {
            infoAboutBoeing707.Click();
            return this;
        }
        public AirPlanesPage OpenAirPlanesPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            return this;
        }


    }
}
