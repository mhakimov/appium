using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
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
        
        //AppiumDriver<IWebElement> appDri;

        DesiredCapabilities cap = new DesiredCapabilities();

        [Test]
        public void launch()
        {
            System.Environment.SetEnvironmentVariable("webdriver.chrome.driver",
                @"C:\Users\dakanca1\Documents\Visual Studio 2015\Projects\AppiumSetup\packages\Selenium.WebDriver.ChromeDriver.2.43.0\driver\win32\chromedriver.exe");
            cap.SetCapability("browserName", "Chrome");
            cap.SetCapability("deviceName", "Pixel");
            cap.SetCapability("platformName", "Android");
            //var options = new ChromeOptions();
            //options.AddArgument("no-sandbox");

            //cap.SetCapability("apppackage", "com.android.chrome");
            //cap.SetCapability("2.43", "66.0.3359");
            //cap.SetCapability("chromedriverExecutable", @"C:\Users\dakanca1\Documents\Visual Studio 2015\Projects\AppiumSetup\packages\Selenium.WebDriver.ChromeDriver.2.43.0\driver\win32\chromedriver.exe");

            //  dri = new ChromeDriver();
 
            driver = new RemoteWebDriver(new Uri("http://localhost:4723/wd/hub"), cap, TimeSpan.FromMinutes(5));
           // Assert.IsNotNull(driver.Context);

            //AppiumDriver<IWebElement> appdri;
            // appdri = new AndroidDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), cap);

            driver.Navigate().GoToUrl("https://www.vanquis.co.uk");
            driver.Quit();
        }
        
    }
}
