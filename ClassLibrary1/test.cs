using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ClassLibrary1
{
    [TestFixture]
    public class test
    {
        IWebDriver webDriver = new ChromeDriver();

        [TestCase]
        public void mainTitle()
        {
            webDriver.Url = "https://sibsutis.ru/";
            Assert.AreEqual("Сибирский государственный университет телекоммуникаций и информатики", webDriver.Title);
            webDriver.Close();
        }

        [TearDown]
        public void testEnd()
        {
            webDriver.Quit();
        }

        [TestCase]
        public void search_test()
        {
            webDriver.Url = "https://sibsutis.ru/";
            IWebElement search = webDriver.FindElement(By.XPath("//*[@id=\"qqq\"]"));
            search.SendKeys("мрм");

            IWebElement button = webDriver.FindElement(By.XPath("//*[@id=\"layout\"]/div[2]/div[2]/div[2]/div[3]/form/input[2]"));
            button.Click();
        }

        [TestCase]
        public void see_test()
        {
            webDriver.Url = "https://sibsutis.ru/";
            IWebElement element = webDriver.FindElement(By.XPath("//*[@id=\"layout\"]/div[2]/div[2]/div[1]/ul/li[2]/a"));
            bool status = element.Enabled;
        }
    }
}
