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
    public class searchPageTests
    {
        string fileDir = "C:\\Users\\Mike.McCormick\\Documents\\Testing\\Evra\\";
        Program program;
        IWebDriver driver;

        [OneTimeSetUp]
        public void Init()
        {
            driver = setUpDriver();
            program = new Program();
            program.loadLoginPage(driver);
            program.sumbitLoginDetails(driver, "qaskillschallenge@geophy.com", "qaskillschallenge@geophy.com");
        }

        [Test]
        public void isSearchPageLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (driver.Url == "https://evra.geophy.com/search")
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
        public void isAddressInputLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (program.ElementIdExists(driver, "address_input"))
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
        public void isNoiInputLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (program.ElementIdExists(driver, "noi"))
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
        public void isNumberOfUnitsInputLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (program.ElementXpathExists(driver, "//*[@name='number_of_units']"))
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
        public void isYearBuiltLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (program.ElementXpathExists(driver, "//*[@name='year_built']"))
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
        public void isOccupancyInputLoaded()
        {
            Boolean pass = false;
            //check test passes
            if (program.ElementXpathExists(driver, "//*[@name='occupancy']"))
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
        public void NumberOfUnitsInputTest()
        {
            Boolean pass = false;
            if (program.ElementXpathExists(driver, "//*[@name='number_of_units']"))
            {
                IWebElement numberOfUnitsInput = driver.FindElement(By.XPath("//*[@name='number_of_units']"));
                numberOfUnitsInput.SendKeys(Keys.ArrowUp);
                string text = numberOfUnitsInput.GetAttribute("value");

                //check test passes
                if (text == "1")
                {
                    //test passes if text box=1
                    pass = true;
                }
                else
                {
                    pass = false;
                }

                //take screenshot if text box value was not 1
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
        }

        [Test]
        public void DisableValuationButtonWithoutNoiInput()
        {
            Boolean pass = false;
            if (program.ElementIdExists(driver, "noi"))
            {
                IWebElement noiInput = driver.FindElement(By.Id("noi"));
                for (int i = 0; i < 7; i++)
                {
                    noiInput.SendKeys(Keys.Backspace);
                    i += 1;
                }
            }

            //check test passes
            if (program.ElementIdExists(driver, "introjsRunValuationButton"))
            {
                IWebElement submitButton = driver.FindElement(By.Id("introjsRunValuationButton"));
                //check button is disabled here
                //pass=true;
            }

            //take screenshot if valuation button is enabled
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
