using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;

namespace SeleniumProjects
{
    public class AIIn
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            //driver = new EdgeDriver();
            //driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

            driver.Url = "https://www.airindia.com/in/en/flights.html?" +
                "route=&Header=true&Carousel=false&promocode=true&usepoints=" +
                "true&offers=false&FlywithMaharaja=true&utm_source=google&utm_medium=" +
                "cpc&utm_campaign=Acquisition_Perform_SEM_Alltraveltype_India_BAU_Prospecting_" +
                "Brand_Terms_Allrout_Allsector_NullHaul_NullB_Desktop_EM&gad_source=1&gclid=Cj0KCQj" +
                "w5cOwBhCiARIsAJ5njubOt-beHvzx9hFb0Ub-4x4DkBHFfzu4E8cVvH0zYyaI_H3CjSj8u4QaAo1qEALw_wcB";
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);

            IWebElement acceptButton = null;
            try
            {
                acceptButton = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("onetrust-accept-btn-handler")));

            }
            catch
            {
                // If the element is not found, acceptButton will remain null
            }

            // Check if the acceptButton WebElement is not null (i.e., the button is present)
            if (acceptButton != null && acceptButton.Displayed)
            {
                // Click on the accept button
                acceptButton.Click();
                TestContext.Progress.WriteLine("Cookiee button found and closed...");
            }
            else
            {
                // If the button is not present or not visible, perform the next step of your automation
                TestContext.Progress.WriteLine("Accept button not found or not visible. Proceeding to the next step...");
            }

            driver.FindElement(By.Id("From")).Click();
            driver.FindElement(By.XPath("//div[@title=' Abu Dhabi, United Arab Emirates, AE']")).Click();

            driver.FindElement(By.Id("To")).Click();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);",
                    driver.FindElement(By.XPath("//div[@title=' Bengaluru, India, IN']")));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible
                (By.XPath("//div[@title=' Bengaluru, India, IN']")));

            driver.FindElement(By.XPath("//div[@title=' Bengaluru, India, IN']")).Click();

            TestContext.Progress.WriteLine(driver.FindElement(By.Id("To")).GetAttribute("value"));

            //TestContext.Progress.WriteLine(driver.PageSource);

            driver.Quit();
        }
    }
}
