using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto2_Test
{
    public class Hausaufgabe
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.saucedemo.com/";
        }

        [OneTimeTearDown]
        public void OneTearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test3()
        {
            driver.Navigate();


            IWebElement elementLogin = driver.FindElement(By.XPath("//*//input[@id= 'user-name']"));
            elementLogin.Click();

            elementLogin.SendKeys("performance_glitch_user");


            string checklog = driver.FindElement(By.XPath("//*//input[@id= 'user-name']")).GetAttribute("value");

            Assert.AreEqual(checklog, "performance_glitch_user");

            IWebElement elementPass = driver.FindElement(By.XPath("//*//input[@id= 'password']"));
            elementPass.Click();

            elementPass.SendKeys("secret_sauce");

            string checkpass = driver.FindElement(By.XPath("//*//input[@id= 'password']")).GetAttribute("value");

            Assert.AreEqual(checkpass, "secret_sauce");

            IWebElement elementIn = driver.FindElement(By.XPath("//*//input[@id= 'login-button']"));
            elementIn.Click();

            Thread.Sleep(10000);

        }
    }
}
