using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace XylemAppUnitTestProject.Pages.SearchResultPage
{
    public class SearchResultPage : XylectPageBase
    {
        public SearchResultPage(IWebDriver driver) : base(driver){}

        #region PageObjects
        private IWebElement ProductCountText => Driver.FindElement(By.Id("head_result_count"));

        #endregion

        /// <summary>
        /// Get the count of the products from search result
        /// </summary>
        /// <returns>string</returns>
        public string GetCountOfProducts()
        {
            return ProductCountText.Text;
        }
    }
}