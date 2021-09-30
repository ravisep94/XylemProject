using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace XylemAppUnitTestProject
{
    public class XylectPageBase
    {
        protected IWebDriver Driver { get; set; }

        public XylectPageBase(IWebDriver driver)
        {
            Driver = driver;
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("disable-infobars");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }
    }
}