using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace XylemAppUnitTestProject.Pages.ChangePreferencesPage
{
    public class ChangePreferencesPage : XylectPageBase
    {
        public ChangePreferencesPage(IWebDriver driver) : base(driver){}

        #region PageObjects
        private IWebElement LanguageDropdown => Driver.FindElement(By.Id("TP__LGG"));

        #endregion

        /// <summary>
        /// Verify All the Languages are Present in the language dropdown
        /// </summary>
        /// <returns><c>true</c>If all of the languages are present in the list<c>Exception</c>Otherwise</returns>
        public bool VerifyAllLanguagaExistsInDropdown()
        {
            IList actualDropdownValue = new ArrayList();

            IWebElement allLanguage = LanguageDropdown;
            SelectElement select = new SelectElement(allLanguage);

            foreach (var item in select.Options)
            {
                actualDropdownValue.Add(item.Text);
            }

            IList ExpectedDropdownValue = new ArrayList();
            ExpectedDropdownValue.Add("Bulgarian (Български)");
            ExpectedDropdownValue.Add("Chinese (中文)");
            ExpectedDropdownValue.Add("Croatian");
            ExpectedDropdownValue.Add("Czech");
            ExpectedDropdownValue.Add("Danish (Dansk)");
            ExpectedDropdownValue.Add("Dutch");
            ExpectedDropdownValue.Add("English (UK)");
            ExpectedDropdownValue.Add("English (US)");
            ExpectedDropdownValue.Add("Finnish (Suomi)");
            ExpectedDropdownValue.Add("French (Français)");
            ExpectedDropdownValue.Add("French (Canadian)");
            ExpectedDropdownValue.Add("German (Deutsch)");
            ExpectedDropdownValue.Add("Greek (Ελληνικά)");
            ExpectedDropdownValue.Add("Hungarian (Magyar)");
            ExpectedDropdownValue.Add("Italian (Italiano)");
            ExpectedDropdownValue.Add("Japanese");
            ExpectedDropdownValue.Add("Korean (독일어)");
            ExpectedDropdownValue.Add("Lithuanian");
            ExpectedDropdownValue.Add("Norwegian (Norsk)");
            ExpectedDropdownValue.Add("Polski");
            ExpectedDropdownValue.Add("Português (Portugal)");
            ExpectedDropdownValue.Add("Portuguese (Brazil)");
            ExpectedDropdownValue.Add("Romanian");
            ExpectedDropdownValue.Add("Russian (Русский)");
            ExpectedDropdownValue.Add("Serbian");
            ExpectedDropdownValue.Add("Slovak");
            ExpectedDropdownValue.Add("Slovenian");
            ExpectedDropdownValue.Add("Español tradicional");
            ExpectedDropdownValue.Add("Swedish (Svenska)");
            ExpectedDropdownValue.Add("Thai");
            ExpectedDropdownValue.Add("Translation Mode");
            ExpectedDropdownValue.Add("Turkish (Türkçe)");

            for (int i = 0; i < actualDropdownValue.Count; i++)
            {
                object actualLanguageValue = actualDropdownValue[i];
                object expectedLanguageValue = ExpectedDropdownValue[i];

                Assert.IsTrue(actualLanguageValue.Equals(expectedLanguageValue));

            }

            return true;
        }

    }
}