using Microsoft.VisualStudio.TestTools.UnitTesting;
using XylemAppUnitTestProject.Pages.SearchResultPage;

namespace XylemAppUnitTestProject
{
    [TestClass]
    public class XylemAppTests : XylectTestBase
    {
        /// <summary>
        /// Login to Xylect Application and Verify Home Page
        /// </summary>
        [TestMethod]
        [TestCategory("Login")]
        [Priority(1)]
        [Owner("Ravi")]
        public void LoginToXylect()
        {
            //Test Data
            string country = "USA";
            string greetingMessage = "Hi, Ramya";
            
            loginPage.GoToXylect();
            Assert.IsTrue(loginPage.VerifyLoginPageExists(), "Login page was not visible.");

            loginPage.SelectCountry(country);
            loginPage.AcceptPrivacy();

            loginPage.loginToXylectWorkflow();
            Assert.IsTrue(homePage.GetGreetingMessage().Equals(greetingMessage), "Greeting message was not displayed");
        }

        /// <summary>
        /// Search for pump and verify the results
        /// </summary>
        [TestMethod]
        [TestCategory("Search")]
        [Priority(2)]
        [Owner("Ravi")]
        public void QuickSearchForPumpTest()
        {
            //Test Data
            string country = "USA";
            string greetingMessage = "Hi, Ramya";
            string modelNumber = "N3000";
            string modelName = "N 3000, N-technology pumps, Flygt";
            string productCount = "91 product(s)";
            string resultCount = "91 results";

            loginPage.GoToXylect();
            Assert.IsTrue(loginPage.VerifyLoginPageExists(), "Login page was not visible.");

            loginPage.SelectCountry(country);
            loginPage.AcceptPrivacy();

            loginPage.loginToXylectWorkflow();
            Assert.IsTrue(homePage.GetGreetingMessage().Equals(greetingMessage), "Greeting message was not displayed");

            homePage.EnterModelOrName(modelNumber);
            homePage.SelectModel(modelName);

            Assert.IsTrue(homePage.GetCountOfProducts().Equals(productCount),"Counts of products does not match on home page.");
            homePage.ClickViewResultsButton();

            Assert.IsTrue(searchResultPage.GetCountOfProducts().Equals(resultCount), "Result Counts of products does not match on search result page.");
        }

        /// <summary>
        /// Verify All Languages are Present in Language dropdown
        /// </summary>
        [TestMethod]
        [TestCategory("Search")]
        [Priority(3)]
        [Owner("Ravi")]
        public void VerifyAllLanguageInPreferenceTest()
        {
            //Test Data
            string country = "USA";
            string greetingMessage = "Hi, Ramya";

            loginPage.GoToXylect();
            Assert.IsTrue(loginPage.VerifyLoginPageExists(), "Login page was not visible.");

            loginPage.SelectCountry(country);
            loginPage.AcceptPrivacy();

            loginPage.loginToXylectWorkflow();
            Assert.IsTrue(homePage.GetGreetingMessage().Equals(greetingMessage), "Greeting message was not displayed");

            homePage.ClickUserIcon();
            homePage.ClickPreferenceButton();

            changePreferencesPage.VerifyAllLanguagaExistsInDropdown();

        }
    }
}
