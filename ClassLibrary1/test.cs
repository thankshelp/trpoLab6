using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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
            
        }
        
        [TestCase]
        public void search_test()
        {
            webDriver.Url = "https://shikimori.org/";
            IWebElement button = webDriver.FindElement(By.XPath("//*[@id=\"dashboards_show\"]/header/div[2]/div[1]/div[2]"));
            button.Click();

            IWebElement search = webDriver.FindElement(By.XPath("//*[@id=\"dashboards_show\"]/header/div[2]/div[3]/div/div/input"));
            search.SendKeys("наруто");
            search.SendKeys(Keys.Return);

            Assert.AreEqual("https://shikimori.org/animes?search=%D0%BD%D0%B0%D1%80%D1%83%D1%82%D0%BE", webDriver.Url);

        }

        [TestCase]
        public void see_test()
        {
            webDriver.Url = "https://shikimori.org/";
            IWebElement element = webDriver.FindElement(By.XPath("//*[@id=\"dashboards_show\"]/section/div[2]/div[1]/div[1]/a"));
            bool status = element.Enabled;
            Assert.AreEqual(true, status);
        }

        [TestCase]
        public void link_test()
        {
            webDriver.Url = "https://shikimori.org/";
            
            IWebElement element = webDriver.FindElement(By.XPath("//*[@id=\"dashboards_show\"]/section/div[2]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/a[2]"));
            element.Click();

            //element = webDriver.FindElement(By.XPath("//*[@id=\"animes_collection_index\"]/section/div/header/h1"));
            //bool status = element.Displayed;

            //Assert.AreEqual(true, status);


            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 30));
            //установка условия окончания ожидания
            var ele = wait.Until(condition =>
            {
                try
                {
                    //до тех пор, пока указанный элемент не станет видим (Displayed == true)
                    if (webDriver.Title == "Аниме лета 2019")
                        return true;
                    else return false;
                }
                //в случае, если такого элемента нет
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });

            Assert.AreEqual("Аниме лета 2019", webDriver.Title);

          //  Assert.AreEqual("https://shikimori.org/animes/season/summer_2019", webDriver.Url);

        }
       
        //[TearDown]
        //public void testEnd()
        //{
        //    webDriver.Quit();
        //}
       
    }
}
