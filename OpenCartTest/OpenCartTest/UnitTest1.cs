using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Data.SqlTypes;
using MySql.Data.MySqlClient;

namespace OpenCart414Test
{
    [TestFixture]
    public class SeleniumSecond
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("http://192.168.147.128/opencart/upload/");
            Thread.Sleep(1000);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            // Return to previous state
            // Check if Loggined and logout driver.Navigate().GoToUrl(".../logout");
        }

        //[Test]
        public void EmptySearch()
        {
            Thread.Sleep(1000); // for presentation only
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.CssSelector("#search > span > button")).Click();
            Thread.Sleep(1000); // for presentation only

            string actual = driver.FindElement(By.CssSelector("#content > h2 + p")).Text;
            Assert.AreEqual("There is no product that matches the search criteria.", actual);
            Thread.Sleep(1000);
        }

        [Test]
        public void SqlTest()
        {
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys("Mac");
            driver.FindElement(By.CssSelector("#search > span > button")).Click();
            Thread.Sleep(2000); // for presentation only

            IList<IWebElement> list = driver.FindElements(By.CssSelector(".caption > h4"));

            string conn = "server=192.168.147.128;user=lv414;database=opencart;password=lv414_TAQC";
            MySqlConnection connect = new MySqlConnection(conn);
            connect.Open();
            string sql1 = "SELECT COUNT(name) FROM oc_product_description WHERE name LIKE '%Mac%'";
            MySqlCommand command1 = new MySqlCommand(sql1, connect);
            int expected = Convert.ToInt32(command1.ExecuteScalar().ToString());
            Console.WriteLine(expected);
            connect.Close();

            Assert.AreEqual(list.Count, expected);

            Thread.Sleep(2000); // for presentation only
        }

        //[Test]
        public void GridListTest()
        {
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys("Mac");
            driver.FindElement(By.CssSelector("#search > span > button")).Click();
            Thread.Sleep(2000); // for presentation only

            driver.FindElement(By.Id("grid-view")).Click();
            string expected = driver.FindElement(By.CssSelector("div.col-sm-6.text-right")).Text;

            driver.FindElement(By.Id("list-view")).Click();
            string actual = driver.FindElement(By.CssSelector("div.col-sm-6.text-right")).Text;

            Assert.AreEqual(expected, actual);

            Thread.Sleep(2000); // for presentation only
        }
    
        //[Test]
        public void SortTest2()
        {
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys("%");
            driver.FindElement(By.CssSelector("#search > span > button")).Click();
            Thread.Sleep(2000); // for presentation only
            driver.FindElement(By.Id("input-sort")).Click();
            Thread.Sleep(2000); // for presentation only
            SelectElement s1 = new SelectElement(driver.FindElement(By.CssSelector("#input-sort")));
            s1.SelectByText("Price (Low > High)");
            Thread.Sleep(2000); // for presentation onaly

            IList<IWebElement> list1 = driver.FindElements(By.CssSelector(".price-tax"));
            bool result = IsSorted(list1);
            
            Assert.IsTrue(result);
        }
        
        //[TestCase("Mac")]
        //[TestCase("941")]
        //[TestCase(".")]
        public void TestSearchAllTypes(string value)
        {
            driver.FindElement(By.Name("search")).Clear();
            driver.FindElement(By.Name("search")).SendKeys(value);
            driver.FindElement(By.CssSelector("#search > span > button")).Click();
            bool result = true;
            IList<IWebElement> list1 = driver.FindElements(By.CssSelector(".caption > h4 > a"));
            foreach (var e in list1)
            {
                string text = e.Text;
                if (!text.Contains(value)) result = false;
            }
            Assert.IsTrue(result);
        }
        public bool IsSorted(IList<IWebElement> list)
        {
            bool result = true;
            double previous = 0;
            foreach (var e in list)
            {
                string value = e.Text;
                int indexOfDolar = value.IndexOf('$');
                string curentPrice = value.Substring(indexOfDolar + 1, value.Length - indexOfDolar - 4);
                double price = Convert.ToDouble(curentPrice);
                if (price < previous)
                {
                    result = false;
                }
                previous = price;
            }
            return result;
        }


    }
}