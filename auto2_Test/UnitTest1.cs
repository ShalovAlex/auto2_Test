using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lesson2_Test
{
    public class Tests
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://jira.bars.group/";
        }

        [OneTimeTearDown]
        public void OneTearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate();

            Thread.Sleep(1000);

            IWebElement elementId = driver.FindElement(By.XPath("//*[contains(text(), 'ароль')]/../input"));       
            elementId.Click();

            elementId.SendKeys("1234");

            Thread.Sleep(1500);

            string check = driver.FindElement(By.XPath("//*[contains(text(), 'ароль')]/../input")).GetAttribute("value");

            Thread.Sleep(1500);

            Assert.AreEqual(check, "1234");

            elementId.SendKeys(Keys.LeftControl + 'a');
            elementId.SendKeys(Keys.Backspace);

            Thread.Sleep(1500);
            check = driver.FindElement(By.XPath("//*[contains(text(), 'ароль')]/../input")).GetAttribute("value");

            Assert.AreEqual(check, string.Empty);

        }

        [Test]
        public void Test2()
        {
            driver.Navigate();

            Thread.Sleep(1000);

            int elementId = driver.FindElements(By.XPath("//div")).Count;

            Assert.AreEqual(elementId, 64);
        }
    }
}