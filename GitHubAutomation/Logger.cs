using System;
using log4net;
using log4net.Config;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using GitHubAutomation.Pages;
using GitHubAutomation.Driver;
using NUnit.Framework.Interfaces;

namespace GitHubAutomation
{
    public class Logger
    {
        static private ILog log = LogManager.GetLogger(typeof(Logger));

        public static ILog Log
        {
            get { return log; }
        }

        public static void WhenTestFails()
        {
            Log.Error("TestFails");
        }

        public static void WhenTestSuccess()
        {
            Log.Info("TestSuccess");
        }
    }
}
