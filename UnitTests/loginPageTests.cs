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
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void LoginPageEmailElementExists()
        {
            Boolean pass = false;
            //check test passes
            if (program.ElementExists(driver, "Id", "email"))
            {
                pass = true;
            }
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void isEmailValueEmpty()
        {
            Boolean pass = false;
            //check test passes
            if (program.ElementExists(driver, "Id", "email"))
            {
                IWebElement userTextBox = driver.FindElement(By.Id("email"));
                string email = userTextBox.GetAttribute("value");
                if (email=="")
                {
                    pass = true;
                }
            }
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void LoginPagePasswordElementExists()
        {
            Boolean pass = false;

            //check test passes
            if (program.ElementExists(driver, "Id", "password"))
            {
                pass = true;
            }
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void LoginPageLogInButtonExists()
        {
            Boolean pass = false;

            //check test passes
            if (program.ElementExists(driver, "XPath", "//*[@class='button button--primary']"))
            {
                pass = true;
            }
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void LoginPageSignUpButtonExists()
        {
            Boolean pass = false;

            //check test passes
            if (program.ElementExists(driver, "XPath", "//*[@class='button button--secondary']"))
            {
                pass = true;
            }
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void LoginPagePasswordResetLinkExists()
        {
            Boolean pass = false;

            //check test passes
            if (program.ElementExists(driver, "LinkText", "Forgot password? Click here to reset"))
            {
                pass = true;
            }
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void LoginPageSignUpLinkExists()
        {
            Boolean pass = false;

            //check test passes
            if (program.ElementExists(driver, "LinkText", "Don't have an acount yet? Sign up here"))
            {
                pass = true;
            }
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void LoginPageViewPasswordImageExists()
        {
            Boolean pass = false;

            //check test passes 
            if (program.ElementExists(driver, "CssSelector", "img#password-icon"))
            {
                pass = true;
            }
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }

        [Test]
        public void isCheckboxTicked()
        {
            Boolean pass = false; // 
            if (program.ElementExists(driver, "ClassName", "checkbox"))
            {
                IWebElement checkbox = driver.FindElement(By.ClassName("checkbox"));
                checkbox.Click();
                if (program.ElementExists(driver, "CssSelector", "input:checked[type='checkbox']"))
                {
                    pass = true;
                }
            }
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
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
