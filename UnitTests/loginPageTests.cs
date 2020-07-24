using System;
using EvraAutomatedTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class loginPageTests
    {
        string fileDir = "C:\\Testing\\Evra\\";
        Program program;
        IWebDriver driver;

        [OneTimeSetUp]
        public void Init()
        {
            driver = setUpDriver();
            program = new Program();
            program.loadLoginPage(driver);
        }

        [Test]
        public void isLoginPageLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (driver.Url== "https://evra.geophy.com/login")
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
            Assert.IsTrue(pass);
        }

        [Test]
        public void LoginPageEmailElementExists()
        {
            Boolean pass = false;
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
            Assert.IsTrue(pass);
        }

        [Test]
        public void LoginPagePasswordElementExists()
        {
            Boolean pass = false;

            //check test passes
            if (program.ElementCssSelectorExists(driver, "input#password"))
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
            Assert.IsTrue(pass);
        }

        [Test]
        public void LoginPageLogInButtonExists()
        {
            Boolean pass = false;

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
            Assert.IsTrue(pass);
        }

        [Test]
        public void LoginPageSignUpButtonExists()
        {
            Boolean pass = false;

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
            Assert.IsTrue(pass);
        }

        [Test]
        public void LoginPagePasswordResetLinkExists()
        {
            Boolean pass = false;

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
            Assert.IsTrue(pass);
        }

        [Test]
        public void LoginPageSignUpLinkExists()
        {
            Boolean pass = false;

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
            Assert.IsTrue(pass);
        }

        [Test]
        public void LoginPageViewPasswordImageExists()
        {
            Boolean pass = false;

            //check test passes
            if (program.ElementCssSelectorExists(driver, "img#password-icon"))
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

        [Test]
        public void LoginCheckbox()
        {
            //set up test
            Boolean pass = false;

            IWebElement checkbox = driver.FindElement(By.XPath("//div[@class='checkbox']/span[@class='checkmark']"));

            checkbox.Click();
            //check box is clicked somehow
        }

        [OneTimeTearDown]
        public void Close()
        {
            driver.Close();
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
