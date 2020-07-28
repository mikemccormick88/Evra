using System;
using EvraAutomatedTests;
using OpenQA.Selenium;
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
            program = new Program();
            driver = program.getDriver("Chrome", 20);
            program.endToEnd(driver);
        }

        [Test]
        public void valuationAboveZero()
        {
            Boolean pass = false;
            if (program.ElementExists(driver, "XPath", "//*[@id='property-section']"))
            {
                int valuation = program.getValuation(driver);
                //check test passes
                if (valuation > 0)
                {
                    //test passes if valuation is above 0
                    pass = true;
                }
            }
            //take screenshot if valuation is <=0
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

                    if (savedText == "Report Favorited")
                    {
                        //test passes if correct text is displayed
                        pass = true;
                    }
                }
            }
            if (pass == false)
            {
                //save screenshot with name of failing test if test fails
                program.takeScreenshot(driver, System.Reflection.MethodBase.GetCurrentMethod().Name, this.GetType().Name);
            }
            Assert.IsTrue(pass);
        }
    }
}