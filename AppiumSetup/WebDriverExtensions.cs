using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Vanquis.Originations.APM.Core.Webtests.Helper
{
    public static class WebDriverExtensions
    {
        public enum RandomOptions
        {
            Alpha,
            Numeric,
        }
        public enum AlertOptions
        {
            Accept,
            Dismiss
        }

        public static bool IsElementDisplayed(this IWebDriver driver, By elementLocator)
        {
            try
            {
                bool isElementDisplayed = driver.FindElement(elementLocator).Displayed;

                return isElementDisplayed;
            }

            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public static IWebElement FindElement(this IWebDriver driver, By elementLocator, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(elementLocator));
            }
            return driver.FindElement(elementLocator);
        }
        public static IWebElement WaitUntilElementExists(this IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementLocator));
            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
        public static IWebElement WaitUntilAllExists(this IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(elementLocator));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
        public static IWebElement WaitUntilElementVisible(this IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementLocator));
            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found.");
                throw;
            }
        }
        public static IWebElement WaitUntilElementClickable(this IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elementLocator));
            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
        public static void ClickAndWaitForPageToLoad(this IWebDriver driver, By elementLocator, int timeout = 10)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                var element = driver.FindElement(elementLocator);
                element.Click();
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(element));
            }

            catch (NoSuchElementException)
            {
                Console.WriteLine("Element with locator: '" + elementLocator + "' was not found in current context page.");
                throw;
            }
        }
        public static void ClickAndHighlight(this IWebElement Locator, IWebDriver driver)
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", Locator, "background-color: yellow; outline: 1px solid rgb(136, 255, 136);");
                }
                Locator.Click();
            }

            catch (System.Exception t)
            {
                Console.WriteLine("Error came : " + t.Message);
            }
        }
        public static void Highlight(this IWebDriver driver, IWebElement Locator)
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", Locator, "background-color: yellow; outline: 1px solid rgb(136, 255, 136);");
                }
            }

            catch (System.Exception t)
            {
                Console.WriteLine("Error came : " + t.Message);
            }
        }
        internal static bool ImageElementDisplayed(this IWebElement imageElement, IWebDriver driver)
        {
            var script = driver is InternetExplorerDriver
                                   ? "return arguments[0].complete"
                                   : "return (typeof arguments[0].naturalWidth!=\"undefined\"" +
                                   " && arguments[0].naturalWidth>0)";
            var imageLoaded = (bool)((IJavaScriptExecutor)driver).ExecuteScript(script, imageElement);

            if (!imageLoaded)
                Debug.WriteLine($"Image not loaded. Image path: {imageElement.GetAttribute("src")}");

            return imageLoaded;
        }
        public static void HighlightAndSendKeys(this IWebElement Locator, IWebDriver driver, string text)
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", Locator, "background-color: yellow; outline: 1px solid rgb(136, 255, 136);");
                }
                Locator.SendKeys(text);
            }

            catch (System.Exception t)
            {
                Console.WriteLine("Error came : " + t.Message);
            }

        }
        public static void TakeScreenshot(IWebDriver driver)
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "TestResults\\" + DateTime.Now.ToString("dd_MMMM_hh_mm_ss_tt");
            string subPath = AppDomain.CurrentDomain.BaseDirectory + "TestResults\\"; // your code goes here

            bool exists = System.IO.Directory.Exists(subPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);

            var screenshot = driver.TakeScreenshot();
            screenshot.SaveAsFile($@"{fileName}.png", ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(fileName + ".png");

            Console.WriteLine("A screenshot was saved to {0}", fileName);
        }

        public static void ClickAndKeyInText(this IWebElement element, string keyInText)
        {
            element.Click();
            element.Clear();
            element.SendKeys(keyInText);
        }
        public static void SelectMenu(this IWebElement element, IWebDriver driver, string selectByText)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(selectByText);
        }

        public static IList<IWebElement> GetSelectOptionsList(this IWebElement element, IWebDriver driver)
        {
            var selectElement = new SelectElement(element);
            return selectElement.Options;
        }
        public static string GetSelectOptionsString(this IWebElement element, IWebDriver driver)
        {
            var selectElement = new SelectElement(element);
            return selectElement.Options.ToString();
        }
        public static bool SelectValuesCheck(this IWebElement element, string dropDownOption)
        {
            string optionsMissing = "";
            SelectElement selectElement = new SelectElement(element);

            if (!selectElement.Options.Any())
            {
                throw new Exception($"The following drop down options have no options {selectElement.ToString()} drop down");
            }

            else if (selectElement.Options.Any(e => e.Text == dropDownOption))
            {
                return true;
            }

            else
            {
                optionsMissing = dropDownOption.TrimEnd(',');
                throw new Exception($"The following drop down options are not present in the {element.TagName.ToString()} drop down: {optionsMissing.TrimEnd(',')}");
            }
        }

        public static bool SelectValuesCheckInTwoLists(this IWebElement element, IWebElement element2, string dropDownOption)
        {
            string optionsMissing = "";
            SelectElement selectElement = new SelectElement(element);
            SelectElement selectElement2 = new SelectElement(element2);

            if (!selectElement.Options.Any())
            {
                throw new Exception($"The following drop down options have no options {selectElement.ToString()} drop down");
            }

            else if (selectElement.Options.Any(e => e.Text == dropDownOption) || selectElement2.Options.Any(e => e.Text == dropDownOption))
            {
                return true;
            }

            else
            {
                optionsMissing = dropDownOption.TrimEnd(',');
                throw new Exception($"The following drop down options are not present in the {element.TagName.ToString()} drop down: {optionsMissing.TrimEnd(',')}");
            }
        }

        public static void EnterRandomString(this IWebElement element, IWebDriver driver, int length, RandomOptions randomoptions)
        {
            Random random = new Random();
            string chars;
            string randomString;

            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
                throw new ArgumentException("length is too big", "length");
            if (length == 0)
                throw new ArgumentException("length must be greater than 0", "length");
            if (randomoptions == RandomOptions.Alpha)
            {
                chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            }

            else
            {
                chars = "0123456789";
            }
            randomString = new string(Enumerable.Repeat(chars, length)
                                            .Select(s => s[random.Next(s.Length)]).ToArray());
            driver.Highlight(element);

            element.Clear();
            element.SendKeys(randomString);
        }
        public static bool IsAlertPresent(IWebDriver driver)
        {
            IAlert alert = SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent().Invoke(driver);
            return (alert != null);
        }
        public static void AcceptAlert(IWebDriver driver, AlertOptions option)
        {
            bool alertPresent = IsAlertPresent(driver);
            if (alertPresent == true && option == AlertOptions.Accept)
            {
                IAlert alert = SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent().Invoke(driver);
                alert.Accept();
            }

            if (alertPresent == true && option == AlertOptions.Dismiss)
            {
                IAlert alert = SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent().Invoke(driver);
                alert.Dismiss();
            }
        }
        public static SelectElement GetSelectElement(this IWebElement webElement)
        {
            SelectElement selectWebElement = new SelectElement(webElement);
            return selectWebElement;
        }
        public static bool IsElementActive(this IWebElement webElement)
        {
            bool isEnabled;
            isEnabled = webElement.Enabled;
            return isEnabled;
        }
        internal static void FocusAndClick(this IWebElement webElement, IWebDriver driver)
        {
            var element = webElement;
            Actions act = new Actions(driver);
            act.MoveToElement(element).Click().Build().Perform();
        }
        internal static void Focus(this IWebDriver driver, IWebElement webElement = null)
        {
            if (webElement != null)
            {
                Actions act = new Actions(driver);
                act.MoveToElement(webElement).Build().Perform();
            }
            else
            {
                var element = webElement;
                Actions act = new Actions(driver);
                act.MoveToElement(element).Build().Perform();
            }
        }
        public static void ScrollUp(this IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,-1000)");
        }

        public static void ScrollTo(this IWebElement webElement, IWebDriver driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true); ", webElement);
        }
        public static void ScrollToView(IWebElement element)
        {
            if (element.Location.Y > 200)
            {
                //ScrollTo(driver, 0, element.Location.Y - 100); // Make sure element is in the view but below the top navigation pane            }
            }
        }
        internal static bool ElementExists(this IWebDriver driver, By identifier, TimeSpan timeout)
        {
            bool result = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, timeout);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(identifier));
                result = true;
            }
            catch (WebDriverTimeoutException)
            {
                result = false;
            }
            return result;
        }
        internal static string GetElementReadOnly(this IWebDriver driver, By identifier, string readonlyAttr)
        {
            if (ElementExists(driver, identifier, TimeSpan.FromSeconds(10)))
            {
                IWebElement element = driver.FindElement(identifier);
                string className = element.GetAttribute(readonlyAttr);

                return className.TrimEnd();
            }

            return "Element doesn't exist";
        }

        internal static bool IsElementReadOnly(this IWebElement webElement)
        {
            if (webElement.GetAttribute("readonly") == "true" || webElement.GetAttribute("disabled") == "true")
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        public static int GetEnteredTextLength(this IWebElement webElement)
        {
            int length;
            length = webElement.GetAttribute("value").Length;
            return length;
        }
    }
}

