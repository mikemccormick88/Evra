using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace EvraAutomatedTests
{
    public class Program
    {
        static void Main(string[] args)
        {
            //main program allows user to submit valuations in chrome, ff or ie
            Program Program = new Program();
            Console.WriteLine("c for chrome, f for firefox, i for ie,");
            string go = Console.ReadLine();
            if (go == "c")
            {
                IWebDriver driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Program.endToEnd(driver);
                Console.ReadLine();
            }
            else if (go == "f")
            {
                IWebDriver driver = new FirefoxDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Program.endToEnd(driver);
                Console.ReadLine();
            }
            else if (go == "i")
            {
                InternetExplorerOptions ieoptions = new InternetExplorerOptions();
                ieoptions.IgnoreZoomLevel = true;
                IWebDriver driver = new InternetExplorerDriver(ieoptions);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Program.endToEnd(driver);
                Console.ReadLine();
            }
        }
        public void loadLoginPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://evra.geophy.com/login");
            driver.Manage().Window.Maximize();
        }

        public void sumbitLoginDetails(IWebDriver driver, string user, string password)
        {
            if (driver.Url == "https://evra.geophy.com/login")
            {
                //find and populate username by id
                if (ElementExists(driver, "Id", "email"))
                {
                    IWebElement userTextBox = driver.FindElement(By.Id("email"));
                    userTextBox.SendKeys(user);
                }
                //find and populate password by id
                if (ElementExists(driver, "Id", "password"))
                {
                    IWebElement passwordTextBox = driver.FindElement(By.Id("password"));
                    passwordTextBox.SendKeys(password);
                    passwordTextBox.Submit();
                }
            }
        }

        public void populateSearch(IWebDriver driver)
        {
            //populate address
            if (ElementExists(driver, "Id", "address_input"))
            {
                IWebElement addressInput = driver.FindElement(By.Id("address_input"));
                addressInput.SendKeys("555 N. College Avenue, Tempe, AZ, 85281");

                //select first address matched from dropdown
                if (ElementExists(driver, "ClassName", "pac-matched"))
                {
                    addressInput.SendKeys(Keys.ArrowDown);
                    addressInput.SendKeys(Keys.Return);
                }
            }

            //populate noi
            if (ElementExists(driver, "Id", "noi"))
            {
                IWebElement noiInput = driver.FindElement(By.Id("noi"));
                noiInput.SendKeys("2000000");
            }

            //populate number of units
            if (ElementExists(driver, "XPath", "//*[@name='number_of_units']"))
            {
                IWebElement numberOfUnitsInput = driver.FindElement(By.XPath("//*[@name='number_of_units']"));
                numberOfUnitsInput.SendKeys("200");
            }

            //populate year built
            if (ElementExists(driver, "XPath", "//*[@name='year_built']"))
            {
                IWebElement yearInput = driver.FindElement(By.XPath("//*[@name='year_built']"));
                yearInput.SendKeys("2000");
            }

            //populate occupancy
            if (ElementExists(driver, "XPath", "//*[@name='occupancy']"))
            {
                IWebElement occupancyInput = driver.FindElement(By.XPath("//*[@name='occupancy']"));
                occupancyInput.SendKeys("80");
            }
        }

        public Boolean ElementExists(IWebDriver driver, string identifier, string search)
        {
            if (identifier.ToUpper() == "CSSSELECTOR")
            {
                if (driver.FindElements(By.CssSelector(search)).Count() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (identifier.ToUpper() == "ID")
            {
                if (driver.FindElements(By.Id(search)).Count() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (identifier.ToUpper() == "XPATH")
            {
                if (driver.FindElements(By.XPath(search)).Count() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (identifier.ToUpper() == "LINKTEXT")
            {
                if (driver.FindElements(By.LinkText(search)).Count() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (identifier.ToUpper() == "CLASSNAME")
            {
                if (driver.FindElements(By.ClassName(search)).Count() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (identifier.ToUpper() == "NAME")
            {
                if (driver.FindElements(By.Name(search)).Count() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (identifier.ToUpper() == "TAGNAME")
            {
                if (driver.FindElements(By.TagName(search)).Count() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
 
        public void submitValuation(IWebDriver driver)
        {
            if (ElementExists(driver, "Id", "introjsRunValuationButton"))
            {
                IWebElement submitButton = driver.FindElement(By.Id("introjsRunValuationButton"));
                submitButton.Click();
            }
        }

        public void endToEnd(IWebDriver driver)
        {
            loadLoginPage(driver);
            sumbitLoginDetails(driver, "qaskillschallenge@geophy.com", "qaskillschallenge@geophy.com");
            populateSearch(driver);
            submitValuation(driver);
        }

        public void takeScreenshot(IWebDriver driver, string filename, string folder)
        {
            string fileDir = "C:\\temp\\Evra\\";
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            System.IO.Directory.CreateDirectory(fileDir + "FailedTests\\" + folder + "\\");
            image.SaveAsFile(fileDir + "FailedTests\\" + folder + "\\" + filename + ".png", ScreenshotImageFormat.Png);
        }
    }
}
