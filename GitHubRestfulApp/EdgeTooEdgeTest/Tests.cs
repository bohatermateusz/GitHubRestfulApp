using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace EdgeTooEdgeTest
{
    [TestFixture]
    public class Tests
    {
        private string homeURL;
        internal string user;

        [SetUp]
        public void Setup()
        {
            user = "John";
            homeURL = $"https://localhost:44301/api/github/{user}";
        }

        [Test(Description = "Must be lunch in antoher instance of Visual Studio, when main project is lunched")]
        public void CheckData()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.Navigate().GoToUrl(homeURL);
                var element = driver.FindElement(By.XPath("/html/body/pre")).Text;
                Assert.AreNotEqual("[]", element);
            }
        }
    }
}