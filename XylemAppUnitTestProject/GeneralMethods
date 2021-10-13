using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;
using XylectSeleniumTest.PageObject;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Diagnostics;

using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA;
using System.Reflection;
using OpenQA.Selenium.Chrome;

using SeleniumExtras.PageObjects;

using XylectSeleniumTest;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace XylectSeleniumTest.General
{
    public class GeneralMethods : BaseSetUp
    {

        public GeneralMethods() { }

        //------------------------------------------------------WAIT FUNCTIONS----------------------------------//

        public void SleepThread()
        {
            Thread.Sleep(2000);
        }
        public void Wait(int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
            //driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(time);

        }

        private static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return driver =>
            {


                if (element.Displayed)
                {
                    return true;
                }

                return false;

            };
        }

        public void WaitForElement(IWebElement element)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(75)).Until(ElementIsVisible(element));
            SleepThread();
        }

        public void WaitForElementVisible(string locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id(locator)));
        }

        public void WaitForElementHidden(string locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.Id(locator)));

        }

        public void WaitUntilElementContains(string text, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(element, text));
        }

        public void WaitJS()
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(120));
            wait.Until((x) =>
            {
                return ((IJavaScriptExecutor)this.driver).ExecuteScript("return document.readyState").Equals("complete");
            });
        }
        public void WaitForElementClickable(IWebElement element)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
            SleepThread();
        }


        //----------------------------------------GENERAL FUNCTIONS--------------------------------//

        public string username = "xylectautomatictest";
        public readonly string password = Properties.Resources.PASSWORD;


        public void FrequencyChange(string freq)
        {
            HomePage.btnUnitHeader.Click();
            Thread.Sleep(7000);
            SelectElement selectValue = new SelectElement(HomePage.ddlFrequency);
            string resultValue = selectValue.SelectedOption.Text;
            if (resultValue.Contains(freq))
            {
                HomePage.btnClosePopupBox.Click();
                SleepThread();
                WaitForElementHidden(HomePage.loadspinner);
            }
            else 
            {
                SelectFromDropDownByValue(freq, HomePage.ddlFrequency);
                PreferencesPage.btnSaveChanges.Click();
                SleepThread();
                WaitForElementHidden(HomePage.loadspinner);
            }         
        }

        public void ChangePresets(IWebElement el)
        {

            HomePage.btnUnitHeader.Click();
            el.Click();
            PreferencesPage.btnSaveChanges.Click();
            SleepThread();
            WaitForElementHidden(HomePage.loadspinner);          
        }


        public void ChangeLanguage(string language)
        {
            PreferencesPage.btnHeaderPreferences.Click();
            PreferencesPage.btnPreferences.Click();
            SelectFromDropDownByValue(language, PreferencesPage.cobLanguage);
            PreferencesPage.btnSaveChanges.Click();
            WaitForElementHidden(HomePage.loadspinner);
            driver.Navigate().Refresh();
            SleepThread();
        }


        public void NavigateFromCountryPageToHomePage(IWebElement country)
        {

            WaitForElement(country);
            country.Click();
            WaitForElement(HomePage.btnacceptPrivacy);
            HomePage.btnacceptPrivacy.Click();
            WaitForElement(HomePage.btnacceptCookies);
            HomePage.btnacceptCookies.Click();
        }

        public void SwitchToIFrame(string iframeID)
        {
            driver.SwitchTo().Frame(iframeID);
        }

        public void SwitchToMain()
        {
            driver.SwitchTo().DefaultContent();
        }

        public void LogIn()
        {

                HomePage.btnLogInHeader.Click();
                HomePage.txtUserName.SendKeys(username);
                HomePage.txtPassword.SendKeys(password);
                HomePage.btnLogInPopup.Click();
                WaitForElementHidden(HomePage.loginBox);
        }
        public void LogIn(string username,string password)
        {
            try
            {
                HomePage.btnLogInHeader.Click();
                HomePage.txtUserName.SendKeys(username);
                HomePage.txtPassword.SendKeys(password);
                HomePage.btnLogInPopup.Click();
                WaitForElementHidden(HomePage.loginBox);
            }
            catch (Exception e)
            {
                ErrorLogging(e, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ReadError(System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw e;
            }
        }


        public void NavigateFromCountryPageToHomePageUK()
        {
            WaitForElement(CountrySelectPage.selectUK);
            CountrySelectPage.selectUK.Click();
            WaitForElement(HomePage.btnacceptPrivacy);
            HomePage.btnacceptPrivacy.Click();
            WaitForElement(HomePage.btnacceptCookies);
            HomePage.btnacceptCookies.Click();

        }

        public void NavigateToHomePage()
        {
            HomePage.btnStart.Click();
        }

        //----------------------------------------SEARCH-------------------------//////
        public void ReplacementGuideSearchTTD(string brand, string series, string product, string variant, string outletDia)
        {
            MoveToElementAndClick(HomePage.replacementGuide);
            SelectFromDropDownByValue(brand, ReplacementGuide.ddlBrand);
            SleepThread();
            SelectFromDropDownByValue(series, ReplacementGuide.ddlSeries);
            SleepThread();
            SelectFromDropDownByValue(product, ReplacementGuide.ddlProduct);
            SleepThread();
            SelectFromDropDownByValue(variant, ReplacementGuide.ddlVariant);
            SleepThread();
            MoveToElement(ReplacementGuide.ddlOutletDiameter);
            SelectFromDropDownByValue(outletDia, ReplacementGuide.ddlOutletDiameter);
        }

        public void ReplacementGuideSearchAWS(string brand, string series, string product, string expextedResult)
        {
            MoveToElementAndClick(HomePage.replacementGuide);
            SelectFromDropDownByValue(brand, ReplacementGuide.ddlBrand);
            Thread.Sleep(200);
            SelectFromDropDownByValue(series, ReplacementGuide.ddlSeries);
            WaitForElementHidden(HomePage.loadspinner);
            SelectFromDropDownByValue(product, ReplacementGuide.ddlProduct);
            ClickElementJava(ReplacementGuide.BtnViewReplaceResults);
            WaitForElementHidden(HomePage.loadspinner);
            try
            {
                ClickElementJava(ReplacementGuide.BtnCloseRecommendation);
                SleepThread();
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Exception caught", e);
            }
            ArrayList ProductList = FetchListOfProducts();
            Assert.IsTrue(ProductList.Contains(expextedResult), "Result 1 not found");
            //Assert.IsTrue(FindElementByLinkText(expextedResult).Displayed, "Result 1 not found");
        }


        public void SearchAPumpWithoutDutyPoint(string model, string productddl, string desingUnit, string headUnit)
        {
            try
            {
                HomePage.txtModel.SendKeys(model);
                MoveToElement(HomePage.ddlProposalProduct);
                SleepThread();
                FindElementByLinkText(productddl).Click();
                SelectFromDropDownByValue(desingUnit, HomePage.ddlTotalDesignUnit);
                SelectFromDropDownByValue(headUnit, HomePage.ddlTotalHeadUnit);
                WaitUntilElementContains("We found ", HomePage.loadSpinnerSmall);
                HomePage.btnViewResults.Click();
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                ErrorLogging(e, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ReadError(System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw e;
            }
        }

        public void SearchAPumpLink(string model, string productddl)
        {
            HomePage.txtModel.SendKeys(model);
            MoveToElement(HomePage.ddlProposalProduct);
            SleepThread();
            FindElementByLinkText(productddl).Click();
        }

        public void SearchAPump(string model, string designFlow, string totalHead, string staticHead, string desingUnit, string headUnit)
        {
            HomePage.txtModel.SendKeys(model);
            HomePage.txtTotalDesignFlow.Clear();
            HomePage.txtTotalDesignFlow.SendKeys(designFlow);
            SelectFromDropDownByValue(desingUnit, HomePage.ddlTotalDesignUnit);
            HomePage.txtTotalHead.Clear();
            HomePage.txtTotalHead.SendKeys(totalHead);
            SelectFromDropDownByValue(headUnit, HomePage.ddlTotalHeadUnit);
            HomePage.txtStaticHead.Clear();
            HomePage.txtStaticHead.SendKeys(staticHead);
            HomePage.divHomepage.Click();
            WaitUntilElementContains("We found ", HomePage.loadSpinnerSmall);
            Thread.Sleep(3000);
            HomePage.btnViewResults.Click();
        }

        public void SearchProduct(string ProductSeries, string expectedResult/*, string name*/)
        {
            HomePage.txtModel.SendKeys(ProductSeries);
            HomePage.txtModel.SendKeys(Keys.Enter);
            WaitForElementHidden(HomePage.loadspinner);
            WaitForElementVisible(SearchResultPage.resultCount);
            SleepThread();
            WaitJS();
            string result = SearchResultPage.txtResultCount.Text;


            if (expectedResult == "0")
            {

                Assert.IsTrue(result.Contains("Loading ..."), "The actual result did not match expected: " + expectedResult + " results, the actual result was: " + result + "");
                SearchResultPage.btnClosePopup.Click();
                SleepThread();
            }
            else if (expectedResult == "1")
            {
                if (result == "Loading ...")
                {
                    SearchResultPage.btnClosePopup.Click();
                    Assert.Fail("No products was found");
                    Thread.Sleep(600);
                }
                else
                {
                    Assert.IsTrue(result.Contains("" + expectedResult + " result"), "The actual result did not match expected: " + expectedResult + " results, the actual result was: " + result + "");

                }
            }
            else
            {
                if (result == "Loading ...")
                {
                    SearchResultPage.btnClosePopup.Click();
                    Assert.Fail("No products was found");
                    Thread.Sleep(600);

                }
                else
                {
                    Assert.IsTrue(result.Contains("" + expectedResult + " results"), "The actual result did not match expected: " + expectedResult + " results, the actual result was: " + result + "");
                    SleepThread();
                }
            }        
        }


        //------------------------------------------------ASSERTS------------------------------//
        public void AssertSeries(string series, string xpath, string testcase)
        {
            try
            {
                IWebElement element = ProductType.FindSeries("//*[@id='baurB']/tbody/tr[" + xpath + "]/td[3]");
                MoveToElement(element);
                string textAssert = element.Text;
                Assert.IsTrue(textAssert.Contains(series), "Expected: " + series + "Was: " + textAssert);
            }
            catch (Exception e)
            {
                ErrorLogging(e, testcase);
                ReadError(testcase);
                throw e;
            }

        }

        public void AssertSeriesWithName(string series, string position,string testcase)
        {
            try
            {
                IWebElement element = ProductType.FindSeries("//table[@id='baurB']//tr[td[*[@value='Xylem###"+series+"']]]");
                int actualposition = driver.FindElements(By.XPath("//table[@id='baurB']//tr[td[*[@value='Xylem###"+series+"']]]/preceding-sibling::tr[@class!='clickable']")).Count+1;//Xpath for only products list excluding product type checkboxes
                MoveToElement(element);
                string textAssert = element.Text;
                Assert.IsTrue(textAssert.Contains(series), "Expected: " + series + "Was: " + textAssert);
                //Assert.IsTrue(actualposition==(int.Parse(position)), "The series "+series+" is expected to be in position:"+position+",but it is at position:"+ actualposition);
            }
            catch (Exception e)
            {
                ErrorLogging(e, testcase);
                ReadError(testcase);
                throw e;
            }
        }

        public void AssertSeriesWithDisplayName(string series,string displayName, string position, string testcase)
        {
            try
            {
                IWebElement element = ProductType.FindSeries("//table[@id='baurB']//tr[td[*[@value='Xylem###" + series + "']]]");
                int actualposition = driver.FindElements(By.XPath("//table[@id='baurB']//tr[td[*[@value='Xylem###" + series + "']]]/preceding-sibling::tr[@class!='clickable']")).Count + 1;//Xpath for count of only products list excluding product type checkboxes
                MoveToElement(element);
                string textAssert = element.Text;
                Assert.IsTrue(textAssert.Contains(displayName), "Expected: " + series + "Was: " + textAssert);
                //Assert.IsTrue(actualposition == (int.Parse(position)), "The series " + series + " is expected to be in position:" + position + ",but it is at position:" + actualposition);
            }
            catch (Exception e)
            {
                ErrorLogging(e, testcase);
                ReadError(testcase);
                throw e;
            }

        }
        public void AssertSeriesList(ArrayList expectedSeriesList,string seriesCount, string testcase)
        { 
            ArrayList actualSeriesList = FetchListOfSeries();
            CollectionAssert.AreEquivalent(expectedSeriesList, actualSeriesList, "The list of series available do not match with the expected list of series");
            MoveToElement(ProductType.NumberOfPoducts);
            string num = ProductType.NumberOfPoducts.Text;
            Assert.IsTrue(num.Contains(seriesCount), "Expected: " + seriesCount + "Was: " + num);
        }

        public ArrayList FetchListOfSeries()
        {
            ArrayList seriesList = new ArrayList();
            for (int i = 0; i < ProductType.SeriesList.Count; i++)
            {
                String seriesName = ProductType.SeriesList[i].GetAttribute("value");
                seriesList.Add(seriesName.Substring(8));
            }
            return seriesList;
        }

        public ArrayList FetchListOfProducts()
        {
            ArrayList ProductsList = new ArrayList();
            for (int i = 0; i < ReplacementGuide.ProductsList.Count; i++)
            {
                String Product = ReplacementGuide.ProductsList[i].Text;
                ProductsList.Add(Product);
            }
            return ProductsList;
        }

        public void AssertNumberOfPumps(string pumps)
        {
            try
            {
                MoveToElement(ProductType.NumberOfPoducts);
                string num = ProductType.NumberOfPoducts.Text;
                Assert.IsTrue(num.Contains(pumps), "Expected: " + pumps + "Was: " + num);

            }
            catch (Exception e)
            {
                ErrorLogging(e, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ReadError(System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw e;
            }

        }

        public static void AssertDownloadedFile(string fileName, long fileSize)
        {
            string userProfile = System.Environment.GetEnvironmentVariable("USERPROFILE");
            string downloadFolder = Path.Combine(userProfile, "Downloads");
            string path = downloadFolder + "\\" + fileName;
            long file = new System.IO.FileInfo(path).Length;
            long exp = fileSize;
            Assert.IsTrue(file.Equals(exp), "Filesize is: " + file.ToString() + " Expected: " + fileSize);
            File.Delete(path);

        }

        public static void AssertDownloadedFileSizeWithWait(string fileName, long fileSize)
        {
            string userProfile = System.Environment.GetEnvironmentVariable("USERPROFILE");
            string downloadFolder = Path.Combine(userProfile, "Downloads");
            string path = downloadFolder + "\\" + fileName;
            long startTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            long endTime = startTime + (15 * 60 * 1000); // Max. wait is 15 minutes.
            while(!File.Exists(path))
            {
                long currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                if (currentTime > endTime)
                {
                    Console.WriteLine("Time out while downloading the file");
                    Assert.Fail("File "+fileName+" download failed");
                    break;
                }
            }
            long file = new System.IO.FileInfo(path).Length;
            long exp = fileSize;
            Assert.GreaterOrEqual(file,exp, "Filesize is: " + file.ToString() + " Expected: " + fileSize);
            File.Delete(path);
        }

        public static void AssertPDF(string fileName, long expectedFileSize)
        {
            string fullPath = "";
            string userProfile = System.Environment.GetEnvironmentVariable("USERPROFILE");
            string downloadFolder = Path.Combine(userProfile, "Downloads");
            string path = downloadFolder;

            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(path);
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + fileName + "*");
            foreach (FileInfo foundFile in filesInDir)
            {
                fullPath = foundFile.FullName;
                Console.WriteLine(fullPath);
            }
            string p = fullPath;
            long file = new System.IO.FileInfo(p).Length;
            Assert.Greater(file, expectedFileSize, "Filesize is: " + file.ToString() + " Expected to bigger than:" + expectedFileSize);
            File.Delete(p);
        }


        //-----------------------------ERROR LOGGING-------------------------------------///

        public static string ErrorLogPath()
        {
            string strPath;
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin", "");
            DirectoryInfo di = Directory.CreateDirectory(dir + "\\ErrorLog");
            string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "\\ErrorLog\\Error " + date + ".txt";
            return strPath = new Uri(finalpth).LocalPath;
        }


        public static void ErrorLogging(Exception ex, string testName)
        {
            string strPath = ErrorLogPath();
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("  ");
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine(testName);
                sw.WriteLine("Time: " + DateTime.Now.ToString("HH:mm:ss tt"));
                sw.WriteLine("===========Start============= ");
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("Inner Exception: " + ex.InnerException);
                sw.WriteLine("===========End=============");
            }
        }

        public static void ReadError(string testName)
        {
            string strPath = ErrorLogPath();

            using (StreamReader sr = new StreamReader(strPath))
            {
                bool start = false;
                string line;
                string text = "";
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == testName || start)
                    {
                        start = true;
                        text += line;
                    }
                    if (line == "===========End=============")
                    {
                        break;
                    }
                    Console.WriteLine(text);
                }
            }
        }

        //------------------------------------ELEMENT METHODS------------------------//
        public IWebElement FindElementByLinkText(string linktext)
        {
            var el = driver.FindElement(By.LinkText(linktext));
            return el;
        }

        public IWebElement FindElementByXpath(string xpath)
        {
            var el = driver.FindElement(By.XPath(xpath));
            return el;
        }


        public static void SelectFromDropDownByValue(string inputText, IWebElement dropDown)
        {
            SelectElement list = new SelectElement(dropDown);
            list.SelectByValue(inputText);
            Thread.Sleep(350);
        }


        public void MoveToElement(IWebElement element)
        {
            try
            {
                Actions action = new Actions(driver);
                action.MoveToElement(element).Perform();
                Thread.Sleep(40);
            }
            catch (Exception e)
            {
                ErrorLogging(e, System.Reflection.MethodBase.GetCurrentMethod().Name);
                ReadError(System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw e;
            }
        }

        public void MoveToElementAndClick(IWebElement element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click().Perform();
            //Waiting for the menu to be displayed    
            Thread.Sleep(2000);
        }


        public void ClickElementJava(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        public void SendKeysJS(IWebElement element,string value)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].value='"+value+"';",element);
        }

        public ArrayList FetchList(string xpath)
        {
            IList<IWebElement> elements = driver.FindElements(By.XPath(xpath));
            ArrayList list = new ArrayList();
            for (int i = 0; i < elements.Count; i++)
            {
                list.Add(elements[i].Text);
            }
            return list;
        }

        public string FetchDynamicId(IWebElement element)
        {
            string Id = element.GetAttribute("id");
            return Id;
        }


        //---------------------------DOWNLOAD DWGs---------------//
        public void Download3dDWG()
        {
            ConfigurationPage.download3dDWG.Click();
        }

        public void Download3dSTP()
        {
            ConfigurationPage.download3dSTP.Click();
        }

        public void ValidateDrawings(string frequency, string units, string model, string product, string dwgFilename, long expectedDwgSize, string stpFilename, long expectedStpSize)
        {
            SwitchToMain();
            NavigateToHomePage();
            FrequencyChange(frequency);
            Thread.Sleep(3000);
            ChangePresets(FindElementByXpath("//a[@id='" + units + "']"));
            Wait(3000);
            SearchAPumpLink(model, product);
            SleepThread();
            HomePage.btnViewResults.Click();
            FindElementByLinkText(model).Click();
            ConfigurationPage.tabDrawings.Click();
            Thread.Sleep(5000);
            SwitchToIFrame("pumpdata");
            ConfigurationPage.tabDownloadDrawings.Click();
            Wait(3000);
            //Fetch the file names
            String DwgFilename = ConfigurationPage.DWGfileName.Text;
            DwgFilename = DwgFilename.Substring(DwgFilename.IndexOf(":") + 2);
            String StpFilename = ConfigurationPage.STPfileName.Text;
            StpFilename = StpFilename.Substring(StpFilename.IndexOf(":") + 2);

            Download3dDWG();
            AssertDownloadedFileSizeWithWait(DwgFilename, expectedDwgSize);
            Download3dSTP();
            AssertDownloadedFileSizeWithWait(StpFilename, expectedStpSize);
            SwitchToMain();
         }

        //-------------------------------------------Head Loss Calculation Page---------------------//
        public void InputPipeRoughness(string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('txtPipeRoughness').value = '0'");
            HeadLossCalculationPage.txtPipeRoughness.SendKeys(value + "" + Keys.Tab);
        }

        public void InputPipeLength(string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('txtPipeLength').value = '"+value+"'");
            //HeadLossCalculationPage.txtPipeLength.SendKeys(value + "" + Keys.Tab);
        }

        public void InputPipeDiameter(string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('txtPipeDiameter').value = '"+value+"'");
            //HeadLossCalculationPage.txtInnerPipeDiameter.SendKeys(value + "" + Keys.Tab);
        }
        public void SelectPipeCalcNatureOfSystem(string natureOfSystem)
        {
            FindElementByXpath("//*[contains(@id,'ui-id') and (text()='" + natureOfSystem + "')]").Click();
            Thread.Sleep(3000);
        }

        public void SelectPipeCalcPipe(string pipe)
        {
            FindElementByXpath("//*[@id='pipeSection_Area']//span[text()='"+ pipe + "']").Click();
            Thread.Sleep(5000);
        }

        public void SelectPipeMaterial(string material)
        {
            HeadLossCalculationPage.MaterialDropdown.Click();
            FindElementByXpath("//*[@id='cb_Name_DropDown']//li[text()='" + material + "']").Click();
            Thread.Sleep(5000);
        }

        public void SelectPressure(string pressure)
        {
            HeadLossCalculationPage.PressureDropdown.Click();
            FindElementByXpath("//*[@id='cb_PN_DropDown']//li[text()='" + pressure + "']").Click();
            Thread.Sleep(5000);
        }

        public void SelectPipeSize(string size)
        {
            HeadLossCalculationPage.PipeSizeDropdown.Click();
            FindElementByXpath("//*[@id='cb_DN_DropDown']//li[contains(text(),'" + size + "')]").Click();
            Thread.Sleep(5000);
        }

        public void SelectStandard(string standard)
        {
            HeadLossCalculationPage.StandardDropdown.Click();
            FindElementByXpath("//*[@id='cb_Series_DropDown']//li[contains(text(),'" + standard + "')]").Click();
            Thread.Sleep(5000);
        }

        public void AddItems(string name)
        {
            FindElementByXpath("//tr[contains(@id,'jqg')]//td[div[contains(text(),'"+name+"')]]/following-sibling::td//div[@class='lossElmQuantPlus']").Click();
            Thread.Sleep(3000);
        }

        public void DeleteItems(string name)
        {
            FindElementByXpath("//tr[contains(@id,'jqg')]//td[div[contains(text(),'"+name+"')]]/following-sibling::td//div[@class='lossElmQuantMinus']").Click();
            Thread.Sleep(3000);
        }

        public void SelectHlc()
        {
            HeadLossCalculationPage.cancelPipeCalc.Click();
            SleepThread();
            SwitchToMain();
            WaitForElement(HomePage.btnHeadLossCalculation);
            HomePage.btnHeadLossCalculation.Click();
            Thread.Sleep(20000);
            SwitchToIFrame("PipeCalc");
            HeadLossCalculationPage.selectLayoutDropdown.Click();
            SleepThread();
            HeadLossCalculationPage.selectDryWellInstallation.Click();
            SleepThread();
            HeadLossCalculationPage.SelectPumpsDropdown.Click();
            SleepThread();
            SelectPipeCalcNatureOfSystem("Single pumps as parallel circuit");
            HeadLossCalculationPage.txtFlow.SendKeys("450"+Keys.Tab);
            HeadLossCalculationPage.txtStaticHead.Click();
            HeadLossCalculationPage.txtStaticHead.SendKeys("1"+Keys.Tab);
        }


        //-----------------PRODUCT TYPE----------------------------------//
        public void SelectSeriesCheckbox(string series)
        {
            //FindElementByXpath("//table[@id='baurB']//td[contains(text(),'"+series+"')]//preceding-sibling::td/label").Click();
            FindElementByXpath("//table[@id='baurB']//input[@value='Xylem###"+series+"']/parent::td//label").Click();
        }


        //----------------------------------------------------------------CONFIGURE TAB-----------------------------------------------//
        public void SelectVersionCode(string versionCode)
        {
            ConfigurationPage.SelectVersionCodeDropdown.Click();
            String tableId = FetchDynamicId(ConfigurationPage.SelectVersionCode);
            FindElementByXpath("//table[@id='"+ tableId.Replace("BaseTable", "ExtTable") + "']//td[contains(text(),'"+versionCode+"')]").Click();
            Thread.Sleep(5000);
        }

        public void SelectJetring(string jetring)
        {
            ConfigurationPage.SelectJetringDropdown.Click();
            String tableId = FetchDynamicId(ConfigurationPage.SelectJetring);
            FindElementByXpath("//table[@id='" + tableId.Replace("BaseTable", "ExtTable") + "']//td[contains(text(),'" + jetring + "')]").Click();
            Thread.Sleep(5000);
        }

        public void SelectMaterial(string material)
        {
            ConfigurationPage.SelectMaterialsDropdown.Click();
            String tableId = FetchDynamicId(ConfigurationPage.SelectMaterial);
            FindElementByXpath("//table[@id='" + tableId.Replace("BaseTable", "ExtTable") + "']//td[contains(text(),'" + material + "')]").Click();
            Thread.Sleep(5000);
        }

        public void SelectPropellerMaterial(string material)
        {
            ConfigurationPage.SelectPropellerDropdown.Click();
            String tableId = FetchDynamicId(ConfigurationPage.SelectPropeller);
            FindElementByXpath("//table[@id='" + tableId.Replace("BaseTable", "ExtTable") + "']//td[contains(text(),'" + material + "')]").Click();
            Thread.Sleep(5000);
        }

        public void SelectFluid(string fluidName)
        {
            HomePage.SearchOptions.Click();
            SleepThread();
            HomePage.FluidLink.Click();
            SleepThread();
            HomePage.SelectFluidDropdown.Click();
            HomePage.InputFluid.SendKeys(fluidName);
            SleepThread();
            FindElementByXpath("//td[contains(text(),'"+fluidName+"')]").Click();
            Thread.Sleep(10000);
        }

        public void InputValueUsingJS(string name, string value)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementsByName('" + name+"')[0].value = '0';");
            FindElementByXpath("//input[@name='"+name+"']").SendKeys(value+""+ Keys.Tab);
        }

        /// <summary>
        /// Compares if the string value is present in the given list
        /// </summary>
        /// <returns><c>true</c>if actual string is present in the given list<c>false</c>otherwise</returns>
        public static bool VerifyIfStringisPresentInList(string expected, List<string> option)
        {
            for (int i = 0; i < option.Count; i++)
            {
                if (option[i].Contains(expected))
                {
                    return true;
                }
            }
            return false;
        }
    }
    
}
