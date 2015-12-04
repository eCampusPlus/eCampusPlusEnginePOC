using System;
using System.Diagnostics;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace eCampusPlus.Engine.Configuration.Drivers
{
    /// <summary>
    ///     Class that enable to interact with the brower through the webdriver
    /// </summary>
    public static class Browser
    {
        /// <summary>
        ///     The webdriver
        /// </summary>
        public static IWebDriver WebDriver;

        /// <summary>
        ///     The drivers' programs folder path
        /// </summary>
        public static string driversPath = "..\\Drivers\\";

        /// <summary>
        ///     The port used by the driver
        /// </summary>
        public static string driverPort;

        /// <summary>
        ///     The driver's URL
        /// </summary>
        public static string driverUrl = "http://localhost";

        /// <summary>
        ///     The driver Unique Name
        /// </summary>
        public static string driverName;

        public static ISearchContext Driver
        {
            get { return WebDriver; }
        }

        /// <summary>
        ///     The title displayed in the browser
        /// </summary>
        public static string Title
        {
            get { return WebDriver.Title; }
        }

        /// <summary>
        ///     The content of the current page
        /// </summary>
        public static string PageContent
        {
            get { return WebDriver.PageSource; }
        }

        /// <summary>
        ///     Configure and lunch the driver
        /// </summary>
        /// <param name="driverUID">The driver Unique Name</param>
        public static void SetWebDriver(string driverUID)
        {
            driversPath = eCampusPlusEngineDriversConfiguration.DriversPath;
            driverName = driverUID.ToUpper();
            switch (driverUID.ToUpper())
            {
                case "FIREFOX":
                    WebDriver = new FirefoxDriver();
                    break;
                case "CHROME":
                    driverPort = eCampusPlusEngineDriversConfiguration.ChromeDriverPort;
                    Process.Start(driversPath + "chromedriver.exe");
                    WebDriver = new RemoteWebDriver(new Uri(driverUrl + ":" + driverPort, UriKind.Absolute),
                        DesiredCapabilities.Chrome());
                    break;
                case "IE":
                    driverPort = eCampusPlusEngineDriversConfiguration.IeDriverPort;
                    Process.Start(driversPath + "IEDriverServer.exe");
                    WebDriver = new RemoteWebDriver(new Uri(driverUrl + ":" + driverPort, UriKind.Absolute),
                        DesiredCapabilities.InternetExplorer());
                    break;
                default:
                    throw new InvalidOperationException("Driver UID not recognized");
            }
        }

        /// <summary>
        ///     Navirate to a page
        /// </summary>
        /// <param name="url">the URL of the target page</param>
        public static void GoTo(string url)
        {
            WebDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
            WebDriver.Url = url;
        }

        public static void SetImplicitWait(int seconds)
        {
            WebDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, seconds));
        }

        /// <summary>
        ///     Redirect to a page
        /// </summary>
        /// <param name="url">the URL of the target page</param>
        public static void RedirectTo(string url)
        {
            WebDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
            WebDriver.Navigate().GoToUrl(url);
        }

        /// <summary>
        ///     Open new tab
        /// </summary>
        public static void OpenTab()
        {
            var body = Driver.FindElement(By.TagName("body"));
            body.SendKeys(Keys.Control + 't');
        }

        /// <summary>
        ///     Close the browser
        /// </summary>
        public static void Close()
        {
            var windowIterator = WebDriver.WindowHandles.ToList();

            if (windowIterator != null && windowIterator.Count > 0)
            {
                for (var i = (windowIterator.Count - 1); i >= 0; i--)
                {
                    WebDriver.SwitchTo().Window(windowIterator[i]).Close();
                }
            }
            //WebDriver.Close();
        }

        /// <summary>
        ///     Access a frame elment in the page by it's ID
        /// </summary>
        /// <param name="frameId">The frame identifier</param>
        public static void SwitchToFrameById(string frameId)
        {
            WebDriver.SwitchTo().Frame(frameId);
        }

        /// <summary>
        ///     Access a frame elment in the page by it's UI element reference
        /// </summary>
        /// <param name="frameId">The frame identifier</param>
        public static void SwitchToFrameByElement(IWebElement frameElement)
        {
            WebDriver.SwitchTo().Frame(frameElement);
        }

        /// <summary>
        ///     Go back to the frame's parent page
        /// </summary>
        /// <param name="frameId">The frame identifier</param>
        public static void SwitchToParent()
        {
            var windowIterator = WebDriver.WindowHandles.ToList();

            if (windowIterator != null && windowIterator.Count > 0)
            {
                if (windowIterator.Count > 1)
                {
                    for (var i = 1; i < windowIterator.Count; i++)
                    {
                        WebDriver.SwitchTo().Window(windowIterator[1]).Close();
                    }
                }
                WebDriver.SwitchTo().Window(windowIterator[0]);
                WebDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
            }
        }

        /// <summary>
        ///     Access a opened popup window by page name
        ///     Case of many popups
        /// </summary>
        /// <param name="frameId">The frame identifier</param>
        public static void SwitchToPopup(string popupPageName)
        {
            var windowIterator = WebDriver.WindowHandles.ToList();
            if (windowIterator != null && windowIterator.Count > 0)
            {
                windowIterator.ForEach(h =>
                {
                    WebDriver.SwitchTo().Window(h);
                    if (WebDriver.Url.Contains(popupPageName)) return;
                });
                WebDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
            }
        }

        /// <summary>
        ///     Access a opened popup window
        /// </summary>
        /// <param name="frameId">The frame identifier</param>
        public static void SwitchToPopup()
        {
            var windowIterator = WebDriver.WindowHandles.ToList();
            if (windowIterator != null && windowIterator.Count > 1)
            {
                WebDriver.SwitchTo().Window(windowIterator[1]);
                WebDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
            }
        }
    }
}