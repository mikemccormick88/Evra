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
    public class resultsPageTests
    {
        Program program;
        IWebDriver driver;

        [OneTimeSetUp]
        public void Init()
        {
            driver = setUpDriver();
            program = new Program();
            program.endToEnd(driver);
        }

        [Test]
        public void valuationAboveZero()
        {
            Boolean pass = false;
            //get valuation as int in nasty way
            if (program.ElementExists(driver, "XPath", "//*[@id='property-section']"))
            {
                IWebElement element = driver.FindElement(By.XPath("//*[@id='property-section']"));
                string html = element.GetAttribute("innerHTML");
                html = html.Substring(html.IndexOf('$')+2, 10);
                string valuation = html.Replace(",", "");
                int valInt = Int32.Parse(valuation);
                //check test passes
                if (valInt > 0)
                {
                    //test passes if valuation is above 0
                    pass = true;
                }
            }
            //take screenshot if valuation is >=0
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            driver.Close();
            Assert.IsTrue(pass);
        }

        [Test]
        [Ignore("disabled because saved text doesn't always appear making test flaky")]
        public void saveReport()
        {
            Boolean pass = false;
            //get valuation as int in very nasty way
            if (program.ElementExists(driver, "ClassName", "button--secondary"))
            {
                IWebElement saveReportButton = driver.FindElement(By.ClassName("button--secondary"));
                saveReportButton.Click();
                if (program.ElementExists(driver, "TagName", "label"))
                    {
                    IWebElement reportFavourited = driver.FindElement(By.TagName("label"));
                    string savedText = reportFavourited.GetAttribute("value");
                    //check test passes
                    if (savedText == "Report Favorited")
                    {
                        pass = true;
                    }
                }
            }
            //take screenshot if report saved test does not display
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
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