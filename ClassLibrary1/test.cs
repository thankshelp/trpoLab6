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
        public void google_test()
        {
            webDriver.Url = "https://www.google.ru/";
            IWebElement search = webDriver.FindElement(By.XPath("//*[@id=\"tsf\"]/div[2]/div/div[1]/div/div[1]/input"));
            search.SendKeys("Функциональное тестирование");

            IWebElement button = webDriver.FindElement(By.XPath("//*[@id=\"tsf\"]/div[2]/div/div[3]/center/input[1]"));
            button.Click();
        }
    }
}
