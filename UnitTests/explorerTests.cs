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
        string fileDir = "C:\\Users\\Mike.McCormick\\Documents\\Testing\\Evra\\";
        [TestMethod]
        public void IeLoginTest()
        {
            //set up test
            Boolean pass = false;
            InternetExplorerOptions ieoptions = getIeOptions();
            IWebDriver driver = new InternetExplorerDriver(ieoptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Program program = new Program();
            program.loadLoginPage(driver);
            program.sumbitLoginDetails(driver, "qaskillschallenge@geophy.com", "qaskillschallenge@geophy.com");

            //check test passes
            if (program.isSearchPageLoaded(driver))
            {
                //test passes if search page loads successfully
                pass = true;
            }

            //take screenshot if search page failed to load
            if (pass == false)
            {
                //save screenshot with name of current failing test
                string filename = System.Reflection.MethodBase.GetCurrentMethod().Name;
                string folder = this.GetType().Name;
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                System.IO.Directory.CreateDirectory(fileDir + "FailedTests\\" + folder + "\\");
                image.SaveAsFile(fileDir + "FailedTests\\" + folder + "\\" + filename + ".png", ScreenshotImageFormat.Png);
            }
            driver.Close();
            Assert.IsTrue(pass);
        }

        public InternetExplorerOptions getIeOptions()
        {
            InternetExplorerOptions ieoptions = new InternetExplorerOptions();
            //causes exception when zoom settings are inconsistent
            ieoptions.IgnoreZoomLevel = true;
            //stop login page being redirected to search page in explorer
            ieoptions.EnsureCleanSession = true;
            //ieoptions.BrowserCommandLineArguments = "-private";
            //driver.Manage().Cookies.DeleteAllCookies();
            return ieoptions;
        }
    }
}
