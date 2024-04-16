using System;
using MagentoUITests.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;



namespace MagentoUITests
{
    public class MagentoWebAppShould
    {
        private const string HomeUrl = "https://magento.softwaretestingboard.com/";
        private const string HomeTitle = "Home Page";

        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadApplicationPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Navigate().GoToUrl(HomeUrl);
                var homePage = new HomePage(driver);

                DemoHelper.Pause();

                Assert.Equal(HomeTitle, driver.Title);
                Assert.Equal(HomeUrl, driver.Url);

            }
        }
        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadHomePage() 
        {
            using (IWebDriver driver = new ChromeDriver())
            { 

                driver.Navigate ().GoToUrl(HomeUrl);
                var homePage = new HomePage(driver);
                DemoHelper.Pause();

                driver.Navigate().Refresh();

                Assert.Equal("Home Page", driver.Title);
                Assert.Equal(HomeUrl, driver.Url);

            }

        }
        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadHomePageAndClickWhatsNew()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                var homePage = new HomePage(driver);
                driver.Manage().Window.Maximize();
                DemoHelper.Pause();

                IWebElement whatNewLink = driver.FindElement(By.LinkText("What's New"));
                whatNewLink.Click();
                DemoHelper.Pause();

                Assert.True(driver.Title.Contains("What's New"));
            }
        }
    }
}
