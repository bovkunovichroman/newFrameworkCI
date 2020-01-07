using System;
using System.IO;
using GitHubAutomation.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using NUnit.Framework.Interfaces;

namespace GitHubAutomation.Utils
{
    public class TestListener
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void Setter()
        {
            Logger.Log.Warn("Start driver initializing.");
            Driver = DriverInstance.GetInstance();
            Logger.Log.Info("Driver initialized.");
        }

        [TearDown]
        public void ClearDriver()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
                Logger.WhenTestSuccess();

            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure ||
                TestContext.CurrentContext.Result.Outcome == ResultState.Error)
            {
                Logger.WhenTestFails();
                Logger.Log.Error("Test failed. Taking screenshot.");
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screens";
                Directory.CreateDirectory(screenFolder);
                var screen = Driver.TakeScreenshot();
                screen.SaveAsFile(screenFolder + @"\screen" + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                    ScreenshotImageFormat.Png);
                Logger.Log.Info("Took screenshot.");
            }

            DriverInstance.CloseBrowser();
        }
    }
}
