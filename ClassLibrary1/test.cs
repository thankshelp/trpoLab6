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
            webDriver.Url = "https://shikimori.org/";
            Assert.AreEqual("Шикимори - энциклопедия аниме и манги", webDriver.Title);
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
            webDriver.Url = "https://shikimori.org/";
            IWebElement button = webDriver.FindElement(By.XPath("//*[@id=\"dashboards_show\"]/header/div[2]/div[1]/div[2]"));
            button.Click();

            IWebElement search = webDriver.FindElement(By.XPath("//*[@id=\"dashboards_show\"]/header/div[2]/div[3]/div/div/input"));
            search.SendKeys("хёка");
            
        }

        [TestCase]
        public void see_test()
        {
            webDriver.Url = "https://shikimori.org/";
            IWebElement element = webDriver.FindElement(By.XPath("//*[@id=\"dashboards_show\"]/section/div[2]/div[1]/div[1]/a"));
            bool status = element.Enabled;
        }

        [TestCase]
        public void link_test()
        {
            webDriver.Url = "https://shikimori.org/";
            IWebElement button = webDriver.FindElement(By.XPath("//*[@id=\"dashboards_show\"]/header/div[2]/div[1]/div[2]"));
            button.Click();

            IWebElement element = webDriver.FindElement(By.XPath("//*[@id=\"dashboards_show\"]/header/div[2]/div[3]/div/ul/li[1]"));
            element.Click();
        }
    }
}
