using OpenQA.Selenium;
using System;
using System.Configuration;
using OpenQA.Selenium.Chrome;

namespace XylemAppUnitTestProject.Pages.LoginPage
{
    public class LoginPage : XylectPageBase
    {
        public LoginPage(IWebDriver driver) : base(driver){}

        #region PageObjects

        private IWebElement AcceptPrivacyButton => Driver.FindElement(By.XPath("//a[@id='xyl-privacy-accept']"));
        private IWebElement AcceptCookiesButton => Driver.FindElement(By.XPath("//a[@id='xyl-cookies-accept']"));
        private IWebElement CountryName(string country) => Driver.FindElement(By.XPath("//*[@title= '" + country + "']"));
        private IWebElement UserNameTextBox => Driver.FindElement(By.XPath("//input[@id='inpage_login_user']"));
        private IWebElement PasswordTextBox => Driver.FindElement(By.XPath("//input[@id='inpage_login_passwd']"));
        private IWebElement LogonButton => Driver.FindElement(By.XPath("//a[@id='inpage_login_submit']"));

        #endregion PageObjects


        /// <summary>
        /// Verify Login Page Exists
        /// </summary>
        public bool VerifyLoginPageExists()
        {
            return (Driver.Title.Contains("Xylect"));
        }

        /// <summary>
        /// Open Xylect Application
        /// </summary>
        public void GoToXylect()
        {
            Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("Environment"));
        }

        /// <summary>
        /// Select the country name
        /// </summary>
        /// <param name="country"></param>
        /// <returns>Loginpage</returns>
        public LoginPage SelectCountry(string country)
        {
            CountryName(country).Click();
            return new LoginPage(Driver);
        }

        /// <summary>
        /// Accepts the Privacy and Cookies
        /// </summary>
        /// <returns></returns>
        public LoginPage AcceptPrivacy()
        {
            AcceptPrivacyButton.Click();
            AcceptCookiesButton.Click();

            return new LoginPage(Driver);
        }

        /// <summary>
        /// Enter Username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public LoginPage EnterUserName()
        {
            UserNameTextBox.SendKeys(ConfigurationManager.AppSettings.Get("Username"));
            return new LoginPage(Driver);
        }

        /// <summary>
        /// Enter Password
        /// </summary>
        /// <param name="password"></param>
        /// <returns>loginpage</returns>
        public LoginPage EnterPassword()
        {
            PasswordTextBox.SendKeys(ConfigurationManager.AppSettings.Get("Password"));
            return new LoginPage(Driver);
        }

        /// <summary>
        /// Click Logon Button
        /// </summary>
        /// <returns>LoginPage</returns>
        public LoginPage ClickLogonButton()
        {
            LogonButton.Click();
            return new LoginPage(Driver);
        }

        /// <summary>
        /// Enters Username password and click logon
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>LoginPage</returns>
        public LoginPage loginToXylectWorkflow()
        {
            
            EnterUserName()
            .EnterPassword()
            .ClickLogonButton();
            return new LoginPage(Driver);
        }

    }
}