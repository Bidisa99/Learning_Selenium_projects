using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Collections;

namespace SeleniumProjects
{
    public class SortWebEliments
    {
        IWebDriver driver;

        [SetUp]

        public void StartBrowser()

        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }

        [Test]

        public void SortTable()
        {
            ArrayList a = new ArrayList();
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByText("20");

            // step 1 - Get all veggie names into arraylist A
            //Thread.Sleep(3000);
            IList<IWebElement> veggies = driver.FindElements(By.XPath("//tr/td[1]"));

            foreach(IWebElement veggie in veggies)
            {
                a.Add(veggie.Text);
                
            }

            //step 2- sort the arraylist
            foreach (String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            TestContext.Progress.WriteLine("After sorting");
            a.Sort();
            foreach (String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            //step 3 - click on the option
            //Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//span[@class='sort-icon sort-ascending']")).Click();

            driver.FindElement(By.CssSelector("th[aria-label *= 'fruit name']")).Click();


            //step 4 - Get all veggie names into arraylist B
            ArrayList b = new ArrayList();
            IList<IWebElement> sveggies = driver.FindElements(By.XPath("//td[1]"));

            foreach(IWebElement sveggie in sveggies)
            {
                b.Add(sveggie.Text);
            }

            //step 5 - checking if both the list are equal

            Assert.AreEqual(a, b);

            driver.Quit();
            


        }
    }
}
