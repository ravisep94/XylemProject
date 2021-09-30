using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace XylemAppUnitTestProject.Pages.HomePage
{
    public class HomePage : XylectPageBase
    {
        public HomePage(IWebDriver driver) : base(driver){}

        #region PageObjects

        private IWebElement GreetingMessageText => Driver.FindElement(By.XPath("//span[@class='HiName_text']"));
        private IWebElement ModelNumberTextBox => Driver.FindElement(By.Id("quicksearch_inpproduct"));
        private IWebElement ModelDropDownValue(string option) => Driver.FindElement(By.XPath("//a[@title='" + option + "']"));
        private IWebElement ProductCountText => Driver.FindElement(By.ClassName("wichtig"));
        private IWebElement ViewResultsButton => Driver.FindElement(By.Id("btn_quick_view_results"));
        private IWebElement UserIcon => Driver.FindElement(By.Id("HeaderBtnOpts"));
        private IWebElement PreferenceButton => Driver.FindElement(By.XPath("//*[@id='peakMenuItems']/a[1]/p"));

        #endregion PageObjects

        /// <summary>
        /// Gets the Greeting message
        /// </summary>
        /// <returns>string</returns>
        public string GetGreetingMessage()
        {
            return GreetingMessageText.Text;
        }

        /// <summary>
        /// test
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public HomePage EnterModelOrName(string model)
        {
            ModelNumberTextBox.SendKeys(model);
            return new HomePage(Driver);
        }

        /// <summary>
        /// Select Model from the dropdown list
        /// </summary>
        /// <param name="option"></param>
        /// <returns>HomePage</returns>
        public HomePage SelectModel(string option)
        {
            ModelDropDownValue(option).Click();
            return new HomePage(Driver);
        }

        /// <summary>
        /// Get the Product count
        /// </summary>
        /// <returns>string</returns>
        public string GetCountOfProducts()
        {
            return ProductCountText.Text;
        }

        /// <summary>
        /// Click View Results Button
        /// </summary>
        /// <returns>SearchResultPage</returns>
        public HomePage ClickViewResultsButton()
        {
            ViewResultsButton.Click();
            return new HomePage(Driver);
        }

        public HomePage ClickUserIcon()
        {
            UserIcon.Click();
            return new HomePage(Driver);
        }

        public HomePage ClickPreferenceButton()
        {
            PreferenceButton.Click();
            System.Threading.Thread.Sleep(7000);
            return new HomePage(Driver);
        }

    }
}