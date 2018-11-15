using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppiumSetup
{
    class Class1
    {
        IWebDriver driver;
        protected EnquiryPage enquiryPage;
        //AppiumDriver<IWebElement> appDri;

        DesiredCapabilities cap = new DesiredCapabilities();

        [Test]
        public void launch()
        {
            //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver",
            //    @"C:\DevAppium\appium\packages\Selenium.WebDriver.ChromeDriver.2.43.0\driver\win32\chromedriver.exe");
            cap.SetCapability("browserName", "Chrome");
            cap.SetCapability("deviceName", "HTC One_M8");
            cap.SetCapability("platformName", "Android");
            cap.SetCapability(MobileCapabilityType.PlatformVersion, "5.0.1");

            // cap.SetCapability("chrome.binary", this.binaryLocation);
            //var options = new ChromeOptions();
            //options.AddArgument("no-sandbox");

            //cap.SetCapability("apppackage", "com.android.chrome");

            //  cap.SetCapability("2.38", "66.0.3359");
            //cap.SetCapability("chromedriverExecutable", @"C:\Users\dakanca1\Documents\Visual Studio 2015\Projects\AppiumSetup\packages\Selenium.WebDriver.ChromeDriver.2.43.0\driver\win32\chromedriver.exe");

            //  dri = new ChromeDriver();

            driver = new RemoteWebDriver(new Uri("http://localhost:4723/wd/hub"), cap, TimeSpan.FromMinutes(5));
           // Assert.IsNotNull(driver.Context);

            //AppiumDriver<IWebElement> appdri;
            // appdri = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), cap);

            driver.Navigate().GoToUrl("https://www.vanquis.co.uk");
            driver.Quit();
            //IWebDriver driver2 = new ChromeDriver();
            //driver2.Navigate().GoToUrl("https://www.vanquis.co.uk");
            //driver2.Quit();
        }

        [Test]
        public void Abc()
        {
            System.Environment.SetEnvironmentVariable("webdriver.chrome.driver",
               @"C:\DevAppium\appium\packages\Selenium.WebDriver.ChromeDriver.2.28.0\driver\chromedriver.exe");

            cap.SetCapability(MobileCapabilityType.BrowserName, "Chrome");
            cap.SetCapability(MobileCapabilityType.PlatformName, "Android");
            cap.SetCapability(MobileCapabilityType.DeviceName, "QVGA25");
           // cap.SetCapability(MobileCapabilityType.PlatformVersion, "9.0");
            IWebDriver driver2 = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap, TimeSpan.FromSeconds(180));
            driver2.Navigate().GoToUrl("https://www.vanquis.co.uk");
        }

        [Test]
        public void RealDevice()
        {
            cap.SetCapability("browserName", "Chrome");
            cap.SetCapability("deviceName", "HTC One_M8");
            cap.SetCapability("platformName", "Android");

            driver = new RemoteWebDriver(new Uri("http://localhost:4723/wd/hub"), cap, TimeSpan.FromMinutes(2));
            enquiryPage = new EnquiryPage(driver);

            // driver.Navigate().GoToUrl("https://vanquis..co.uk/enquiry");
            driver.Navigate().GoToUrl("https://www.vanquis.co.uk/enquiry");

            enquiryPage.TitleMiss.SendKeys(Keys.Space);
            driver.Quit();
        }


        [Test]
        public void Web()
        {


            driver = new ChromeDriver();
            enquiryPage = new EnquiryPage(driver);


            // driver.Navigate().GoToUrl("https://vanquis..co.uk/enquiry");
            driver.Navigate().GoToUrl("https://www.vanquis.co.uk/enquiry");

            enquiryPage.TitleMiss.SendKeys(Keys.Space);
            driver.Quit();
        }
    }
}
