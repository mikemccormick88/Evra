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
            Program Program = new Program();
            Console.WriteLine("g for google, f for firefox, i for ie, esc to quit");
            string go = Console.ReadLine();
            if (go == "g")
            {
                IWebDriver driver = new ChromeDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                Program.loadLoginPage(driver);
                Program.sumbitLoginDetails(driver);
                Program.submitSearch(driver);
                Console.ReadLine();
            }
            else if (go == "f")
            {
                IWebDriver driver = new FirefoxDriver();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                Program.loadLoginPage(driver);
                Program.sumbitLoginDetails(driver);
                Program.submitSearch(driver);
                Console.ReadLine();
            }
            else if (go == "i")
            {
                InternetExplorerOptions ieoptions = new InternetExplorerOptions();
                ieoptions.IgnoreZoomLevel = true;
                ieoptions.BrowserCommandLineArguments = "-private";
                IWebDriver driver = new InternetExplorerDriver(ieoptions);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                Program.loadLoginPage(driver);
                Program.sumbitLoginDetails(driver);
                Program.submitSearch(driver);
                Console.ReadLine();
            }
        }
        public void loadLoginPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://evra.geophy.com/login");
            driver.Manage().Window.Maximize();
        }

        public void sumbitLoginDetails(IWebDriver driver)
        {
            if (isLoginPageLoaded(driver))
            {
                //find and populate username
                IWebElement userTextBox = driver.FindElement(By.XPath("//*[@id='email']"));
                userTextBox.SendKeys("qaskillschallenge@geophy.com");

                //find and populate password
                IWebElement passwordTextBox = driver.FindElement(By.XPath("//*[@id='password']"));
                passwordTextBox.SendKeys("qaskillschallenge@geophy.com");

                //submit form
                passwordTextBox.Submit();
            }
            else
            {

            }
        }

        public void submitSearch(IWebDriver driver)
        {
            if (isSearchPageLoaded(driver))
            {
                IWebElement addressInput = driver.FindElement(By.Id("address_input"));
                addressInput.SendKeys("555 N. College Avenue, Tempe, AZ, 85281");

                if (driver.FindElements(By.ClassName("pac-matched")).Count() != 0)
                {
                    addressInput.SendKeys(Keys.ArrowDown);
                    addressInput.SendKeys(Keys.Return);
                }

                IWebElement noiInput = driver.FindElement(By.Id("noi"));
                noiInput.SendKeys("2000000");

                IWebElement numberOfUnitsInput = driver.FindElement(By.XPath("//*[@name='number_of_units']"));
                numberOfUnitsInput.SendKeys("200");

                IWebElement yearInput = driver.FindElement(By.XPath("//*[@name='year_built']"));
                yearInput.SendKeys("2000");

                IWebElement occupancyInput = driver.FindElement(By.XPath("//*[@name='occupancy']"));
                occupancyInput.SendKeys("80");

                IWebElement submitButton = driver.FindElement(By.Id("introjsRunValuationButton"));
                submitButton.Click();
            }
            else
            {

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
    }
}
