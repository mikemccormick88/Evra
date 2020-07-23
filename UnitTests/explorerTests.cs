using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvraAutomatedTests;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace UnitTests
{
    [TestClass]
    public class explorerTests
    {
        [TestMethod]
        public void IeLoginTest()
        {
            Boolean pass = false;
            InternetExplorerOptions ieoptions = getIeOptions();
            IWebDriver driver = new InternetExplorerDriver(ieoptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Program program = new Program();
            program.loadLoginPage(driver);
            program.sumbitLoginDetails(driver, "qaskillschallenge@geophy.com", "qaskillschallenge@geophy.com");
            //check search page has loaded successfully
            if (program.isSearchPageLoaded(driver))
            {
                pass = true;
            }
            //take screenshot if search page failed to load
            if (pass == false)
            {
                //save screenshot with name of current failing test
                string filename = System.Reflection.MethodBase.GetCurrentMethod().Name;
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile("C:\\Users\\Mike.McCormick\\Desktop\\Testing\\" + filename + ".png", ScreenshotImageFormat.Png);
            }
            driver.Close();
            Assert.IsTrue(pass);
        }

        public InternetExplorerOptions getIeOptions()
        {
            InternetExplorerOptions ieoptions = new InternetExplorerOptions();
            ieoptions.IgnoreZoomLevel = true;
            ieoptions.EnsureCleanSession = true;
            //ieoptions.BrowserCommandLineArguments = "-private";
            //driver.Manage().Cookies.DeleteAllCookies();
            return ieoptions;
        }
    }
}
