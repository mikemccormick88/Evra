using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvraAutomatedTests;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace UnitTests
{
    [TestClass]
    public class explorerEndToEnd
    {
        string fileDir = "C:\\Users\\Mike.McCormick\\Documents\\Testing\\Evra\\";
        [TestMethod]
        public void IeLoginTest()
        {
            //set up test
            Boolean pass = false;

            //set up driver and options
            InternetExplorerOptions ieoptions = new InternetExplorerOptions();
            //causes exception when zoom settings are inconsistent
            ieoptions.IgnoreZoomLevel = true;
            //stop login page being redirected to search page in explorer
            ieoptions.EnsureCleanSession = true;
            //ieoptions.BrowserCommandLineArguments = "-private";
            //driver.Manage().Cookies.DeleteAllCookies();
            IWebDriver driver = new InternetExplorerDriver(ieoptions);

            Program program = new Program();
            program.endToEnd(driver);

            //check test passes
            if (driver.Url == "https://evra.geophy.com/search")
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
    }
}
