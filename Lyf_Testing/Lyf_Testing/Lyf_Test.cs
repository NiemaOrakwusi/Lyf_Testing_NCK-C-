/*Selenium and NUnit testing for Lyg.ng webpage, high-level* By: Niema Kitt*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Windows.Forms;
using System.Linq;

namespace Lyf_Testing
{
    [TestClass]
    public class Lyf_Test
    {
        //Initialize a the IWebdriver in static
        static IWebDriver drs;
        

        [AssemblyInitialize]
        public static void Setup(TestContext context)
        {
            //Assign the Driver to Null on Start of Application
            drs = null;
        }

         [TestMethod]
         public void Movies()
         {
            //Set Json geo-location to true and share
             var profile = new FirefoxProfile { EnableNativeEvents = false };
             profile.SetPreference(" geo.prompt.testing ", true);
             profile.SetPreference(" geo.prompt.testing.allow ", true);
             profile.SetPreference("geo.wifi.uri ", " file:///C:/Dev/brussels.json");

            //Set the Driver for FirefoxDriver to the Json Profile
             drs = new FirefoxDriver(profile);

            //Open Url being tested
             drs.Navigate().GoToUrl("http://www.lyf.ng");

            //Maximize the window to when the page open
            drs.Manage().Window.Maximize();

            //Wait 90 seconds for the page to open
            drs.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(90));

            //Initialize and Assign the Iwebdriver to locate the element 
             IWebElement od = drs.FindElement(By.CssSelector("[href*='http://www.lyf.ng/movies']"));

            //Click the Element
             od.Click();

            //Wait 90 seconds for the page to open
            drs.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(90));

            //Verify the page has open and verify it is the same URL that was open with the current URL open
            Assert.AreEqual("http://www.lyf.ng/movies", drs.SwitchTo().Window(drs.WindowHandles.Last()).Url);


         }

        [TestMethod]
        public void Air_Bill()
        {
            //Set Json geo-location to true and share
            var profiles = new FirefoxProfile { EnableNativeEvents = false };
            profiles.SetPreference(" geo.prompt.testing ", true);
            profiles.SetPreference(" geo.prompt.testing.allow ", true);
            profiles.SetPreference("geo.wifi.uri ", " file:///C:/Dev/brussels.json");

            //Set the Driver for FirefoxDriver to the Json Profile
            drs = new FirefoxDriver(profiles);

            //Open Url being tested
            drs.Navigate().GoToUrl("http://www.lyf.ng");

            //Maximize the window to when the page open
            drs.Manage().Window.Maximize();

            //Wait 90 seconds for the page to open
            drs.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
           
            IWebElement od = drs.FindElement(By.CssSelector("[href*='http://lyf.ng/bills-airtime']"));
            od.Click();

            //Initialize and Assign the Iwebdriver to locate the element
            drs.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(90));

            //Verify the page has open and verify it is the same URL that was open with the current URL open           
            Assert.AreEqual("http://www.lyf.ng/bills-airtime", drs.SwitchTo().Window(drs.WindowHandles.Last()).Url);




        }

       [TestMethod]
        public void TCleanup()
        {
            //Verify testing complete with message
            MessageBox.Show("Testing Complete");

            //Quit all testing 
            drs.Quit();
        }

    }
}
