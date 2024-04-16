using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Xunit;

namespace MagentoUITests
{
    [Trait("Category", "Applications")]

    public class MagentoAppShould

    {
        private const string HomeUrl = "https://magento.softwaretestingboard.com/";
        private const string CreateNewCustomerAccountUrl = "https://magento.softwaretestingboard.com/customer/account/create/";
        


        [Fact]
        public void BeInitiatedFromHomePage_CreateNewAccount()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(HomeUrl);
                DemoHelper.Pause();

                IWebElement applyLink = driver.FindElement(By.XPath("/html/body/div[2]/header/div[1]/div/ul/li[3]/a"));
                applyLink.Click();
                DemoHelper.Pause();

                Assert.Equal("Create New Customer Account", driver.Title);
                Assert.Equal(CreateNewCustomerAccountUrl, driver.Url);

            }

        }
        [Fact]

        public void SubmitedWhenValid()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(CreateNewCustomerAccountUrl);
                driver.Manage().Window.Maximize();
                DemoHelper.Pause();

                driver.FindElement(By.Id("firstname")).SendKeys("Sara");
                DemoHelper.Pause();
                driver.FindElement(By.Id("lastname")).SendKeys("Smith");
                DemoHelper.Pause();
                driver.FindElement(By.Id("email_address")).SendKeys("sarasmith12345@gmail.com");
                DemoHelper.Pause();
                driver.FindElement(By.Id("password")).SendKeys("12345678sS");
                DemoHelper.Pause();
                driver.FindElement(By.Id("password-confirmation")).SendKeys("12345678sS");
                DemoHelper.Pause();
                driver.FindElement(By.XPath("//*[@id=\"form-validate\"]/div/div[1]/button/span"));
                DemoHelper.Pause();

              

            }
        }
        [Fact]

        public void SelectProductAndSaveToCart()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://magento.softwaretestingboard.com/women/tops-women/tees-women.html");
                driver.Manage().Window.Maximize();
                DemoHelper.Pause();

                IWebElement teesLink = driver.FindElement(By.XPath("//*[@id=\"maincontent\"]/div[3]/div[1]/div[4]/ol/li[9]/div/a/span/span/img"));
                teesLink.Click();
                DemoHelper.Pause();

                IWebElement SizeButton = driver.FindElement(By.XPath("//*[@id=\"option-label-size-143-item-168\"]"));
                SizeButton.Click();
                DemoHelper.Pause();

                IWebElement Colour = driver.FindElement(By.XPath("//*[@id=\"option-label-color-93-item-57\"]"));
                Colour.Click();
                DemoHelper.Pause();

                IWebElement AddToCart = driver.FindElement(By.XPath("//*[@id=\"product-addtocart-button\"]/span"));
                AddToCart.Click();
                DemoHelper.Pause();


                WebElement element = (WebElement)driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div[1]/a/span[2]/span[1]"));
                Actions act = new Actions(driver);
                act.MoveToElement(element).Perform();
                DemoHelper.Pause(1000);
            }

        }



    }


}
