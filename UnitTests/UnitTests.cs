using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvraAutomatedTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void chromeLoginTest()
        {
            Boolean pass = false;
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Program program = new Program();
            program.loadLoginPage(driver);
            program.sumbitLoginDetails(driver);
            if (program.isSearchPageLoaded(driver))
            {
                pass = true;
            }
            if (pass == false)
            {
                string filename = System.Reflection.MethodBase.GetCurrentMethod().Name;
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile("C:\\Users\\Mike.McCormick\\Desktop\\Testing\\" + filename + ".png", ScreenshotImageFormat.Png);
            }
            driver.Close();
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void chromeSubmitValuationTest()
        {
            Boolean pass = false;
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Program program = new Program();
            program.loadLoginPage(driver);
            program.sumbitLoginDetails(driver);
            program.submitSearch(driver);
            if (program.isResultsPageLoaded(driver))
            {
                pass = true;
            }
            if (pass == false)
            {
                string filename = System.Reflection.MethodBase.GetCurrentMethod().Name;
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile("C:\\Users\\Mike.McCormick\\Desktop\\Testing\\" + filename + ".png", ScreenshotImageFormat.Png);
            }
            driver.Close();
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void fireFoxLoginTest()
        {
            Boolean pass = false;
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Program program = new Program();
            program.loadLoginPage(driver);
            program.sumbitLoginDetails(driver);
            if (program.isSearchPageLoaded(driver))
            {
                pass = true;
            }
            if (pass == false)
            {
                string filename = System.Reflection.MethodBase.GetCurrentMethod().Name;
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile("C:\\Users\\Mike.McCormick\\Desktop\\Testing\\" + filename + ".png", ScreenshotImageFormat.Png);
            }
            driver.Close();
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void fireFoxSubmitValuationTest()
        {
            Boolean pass = false;
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Program program = new Program();
            program.loadLoginPage(driver);
            program.sumbitLoginDetails(driver);
            program.submitSearch(driver);
            if (program.isResultsPageLoaded(driver))
            {
                pass = true;
            }
            if (pass == false)
            {
                string filename = System.Reflection.MethodBase.GetCurrentMethod().Name;
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile("C:\\Users\\Mike.McCormick\\Desktop\\Testing\\" + filename + ".png", ScreenshotImageFormat.Png);
            }
            driver.Close();
            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void IeLoginTest()
        {
            Boolean pass = false;
            InternetExplorerOptions ieoptions = new InternetExplorerOptions();
            ieoptions.IgnoreZoomLevel = true;
            ieoptions.EnsureCleanSession = true;
            ieoptions.BrowserCommandLineArguments = "-private";
            IWebDriver driver = new InternetExplorerDriver(ieoptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Cookies.DeleteAllCookies();
            Program program = new Program();
            program.loadLoginPage(driver);
            program.sumbitLoginDetails(driver);
            if (program.isSearchPageLoaded(driver))
            {
                pass = true;
            }
            if (pass == false)
            {
                string filename = System.Reflection.MethodBase.GetCurrentMethod().Name;
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile("C:\\Users\\Mike.McCormick\\Desktop\\Testing\\"+filename+".png", ScreenshotImageFormat.Png);
            }
            driver.Close();
            Assert.IsTrue(pass);
        }
    }
}
