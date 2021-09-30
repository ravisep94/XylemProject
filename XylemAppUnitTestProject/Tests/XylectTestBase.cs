using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace XylemAppUnitTestProject
{
    public class XylectTestBase
    {
        public IWebDriver Driver { get; set; }
        internal Pages.LoginPage.LoginPage loginPage { get; private set; }
        internal Pages.HomePage.HomePage homePage { get; private set; }
        internal Pages.SearchResultPage.SearchResultPage searchResultPage { get; private set; }
        internal Pages.ChangePreferencesPage.ChangePreferencesPage changePreferencesPage { get; private set; }

        /// <summary>
        /// Initialization for individual test
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            Driver = GetChromeDriver();
            Driver.Manage().Window.Maximize();

            loginPage = new Pages.LoginPage.LoginPage(Driver);
            homePage = new Pages.HomePage.HomePage(Driver);
            searchResultPage = new Pages.SearchResultPage.SearchResultPage(Driver);
            changePreferencesPage = new Pages.ChangePreferencesPage.ChangePreferencesPage(Driver);

        }

        private IWebDriver GetChromeDriver()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outputDirectory);
        }

        /// <summary>
        /// Cleanup for individual test
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}