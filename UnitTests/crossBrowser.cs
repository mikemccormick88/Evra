using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvraAutomatedTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;


namespace UnitTests
{
    [TestClass]
    public class crossBrowser
    {
        string fileDir = "C:\\Users\\Mike.McCormick\\Documents\\Testing\\Evra\\";
        [TestMethod]
        public void LoginCheckEmailElementExists()
        {
            //set up test
            Boolean pass = false;
            IWebDriver driver = setUpDriver();
            Program program = new Program();
            program.loadLoginPage(driver);

            //check test passes
            if (program.ElementIdExists(driver, "email"))
            {
                pass = true;
            }

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

        [TestMethod]
        public void LoginCheckPasswordElementExists()
        {
            //set up test
            Boolean pass = false;
            IWebDriver driver = setUpDriver();
            Program program = new Program();
            program.loadLoginPage(driver);

            //check test passes
            if (program.ElementIdExists(driver, "password"))
            {
                pass = true;
            }

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

        [TestMethod]
        public void LoginCheckLogInButtonExists()
        {
            //set up test
            Boolean pass = false;
            IWebDriver driver = setUpDriver();
            Program program = new Program();
            program.loadLoginPage(driver);

            //check test passes
            if (program.ElementXpathExists(driver, "//*[@class='button button--primary']"))
            {
                pass = true;
            }

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
        
        [TestMethod]
        public void LoginCheckSignUpButtonExists()
        {
            //set up test
            Boolean pass = false;
            IWebDriver driver = setUpDriver();
            Program program = new Program();
            program.loadLoginPage(driver);

            //check test passes
            if (program.ElementXpathExists(driver, "//*[@class='button button--secondary']"))
            {
                pass = true;
            }

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

        [TestMethod]
        public void LoginCheckPasswordResetLinkExists()
        {
            //set up test
            Boolean pass = false;
            IWebDriver driver = setUpDriver();
            Program program = new Program();
            program.loadLoginPage(driver);

            //check test passes
            if (program.ElementLinkTextExists(driver, "Forgot password? Click here to reset"))
            {
                pass = true;
            }

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

        [TestMethod]
        public void LoginCheckSignUpLinkExists()
        {
            //set up test
            Boolean pass = false;
            IWebDriver driver = setUpDriver();
            Program program = new Program();
            program.loadLoginPage(driver);

            //check test passes
            if (program.ElementLinkTextExists(driver, "Don't have an acount yet? Sign up here"))
            {
                pass = true;
            }

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

        public IWebDriver setUpDriver()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return chromeDriver;
            //IWebDriver firefoxDriver = new FirefoxDriver();
            //InternetExplorerOptions ieoptions = new InternetExplorerOptions();
            //ieoptions.IgnoreZoomLevel = true;
            //ieoptions.EnsureCleanSession = true;
            //IWebDriver ieDriver = new InternetExplorerDriver(ieoptions);
            //ieDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //return ieDriver;
        }
    }
}
