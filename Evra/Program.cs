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
            //main program allows user to submit valuations in chome, ff or ie
            Program Program = new Program();
            Console.WriteLine("g for google, f for firefox, i for ie, esc to quit");
            string go = Console.ReadLine();
            if (go == "g")
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
            if (isLoginPageLoaded(driver))
            {
                //find and populate username by id
                //make sure element exists first
                if (ElementIdExists(driver, "email"))
                {
                    IWebElement userTextBox = driver.FindElement(By.Id("email"));
                    userTextBox.SendKeys(user);
                }
                //find and populate password by id
                //make sure element exists first
                if (ElementIdExists(driver, "password"))
                {
                    IWebElement passwordTextBox = driver.FindElement(By.Id("password"));
                    passwordTextBox.SendKeys(password);
                    passwordTextBox.Submit();
                }
            }
            else
            {
                Console.ReadLine();
            }
        }

        public void populateSearch(IWebDriver driver)
        {
            if (isSearchPageLoaded(driver))
            {
                //populate address
                if (ElementIdExists(driver, "address_input"))
                {
                    IWebElement addressInput = driver.FindElement(By.Id("address_input"));
                    addressInput.SendKeys("555 N. College Avenue, Tempe, AZ, 85281");

                    //select first address matched from dropdown
                    if (driver.FindElements(By.ClassName("pac-matched")).Count() != 0)
                    {
                        addressInput.SendKeys(Keys.ArrowDown);
                        addressInput.SendKeys(Keys.Return);
                    }
                }

                //populate noi
                if (ElementIdExists(driver, "noi"))
                {
                    IWebElement noiInput = driver.FindElement(By.Id("noi"));
                    noiInput.SendKeys("2000000");
                }

                //populate number of units
                if (ElementXpathExists(driver, "//*[@name='number_of_units']"))
                {
                    IWebElement numberOfUnitsInput = driver.FindElement(By.XPath("//*[@name='number_of_units']"));
                    numberOfUnitsInput.SendKeys("200");
                }

                //populate year built
                if (ElementXpathExists(driver, "//*[@name='year_built']"))
                {
                    IWebElement yearInput = driver.FindElement(By.XPath("//*[@name='year_built']"));
                    yearInput.SendKeys("2000");
                }

                //populate occupancy
                if (ElementXpathExists(driver, "//*[@name='occupancy']"))
                {
                    IWebElement occupancyInput = driver.FindElement(By.XPath("//*[@name='occupancy']"));
                    occupancyInput.SendKeys("80");
                }
            }
            else
            {
                Console.ReadLine();
            }
        }

        public Boolean isLoginPageLoaded(IWebDriver driver)
        {
            Boolean isLoaded = false;
            if (driver.FindElements(By.XPath("//*[@id='email']")).Count() != 0)
            {
                isLoaded = true;
            }
            return isLoaded;
        }

        public Boolean isSearchPageLoaded(IWebDriver driver)
        {
            Boolean isLoaded=false;
            if (driver.FindElements(By.Id("introjsAddressInputForm")).Count() != 0)
                {
                    isLoaded = true;
                }
            return isLoaded;
        }

        public Boolean isResultsPageLoaded(IWebDriver driver)
        {
            Boolean isLoaded = false;
            if (driver.FindElements(By.Id("property-section")).Count() != 0)
            {
                isLoaded = true;
            }
            return isLoaded;
        }

        public Boolean ElementIdExists(IWebDriver driver, string elementId)
        {
            if (driver.FindElements(By.Id(elementId)).Count() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean ElementXpathExists(IWebDriver driver, string path)
        {
            if (driver.FindElements(By.XPath(path)).Count() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean ElementLinkTextExists(IWebDriver driver, string link)
        {
            if (driver.FindElements(By.LinkText(link)).Count() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean ElementCssSelectorExists(IWebDriver driver, string selector)
        {
            if (driver.FindElements(By.CssSelector(selector)).Count() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void submitValuation(IWebDriver driver)
        {
            if (ElementIdExists(driver, "introjsRunValuationButton"))
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
        }
    }
}
