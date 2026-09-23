using MySolution.Core.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

namespace MySolution.Core.Helpers;

public static class WebDriverFactory
{
    public static IWebDriver Create(BrowserOptions options)
    {
        return options.Browser switch
        {
            Browser.Chrome => CreateChrome(options),
            Browser.Firefox => CreateFirefox(options),
            Browser.Safari => CreateSafari(options),
            Browser.Remote => CreateRemote(options),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private static IWebDriver CreateChrome(BrowserOptions browserOptions)
    {
        var options = new BrowserOptionsBuilder()
            .SetHeadless(browserOptions.Headless)
            .SetMaximized(browserOptions.Maximize)
            .SetGuest(browserOptions.Guest)
            .Build();
        return new ChromeDriver(options);
    }
    
    private static IWebDriver CreateFirefox(BrowserOptions browserOptions)
    {
        var options = new FirefoxOptions();
        if (browserOptions.Guest)
        {
            options.AddArgument("--guest");
        }

        if (browserOptions.Maximize)
        {
            options.AddArgument("--start-maximized");
        }

        return new FirefoxDriver(options);
    }
    
    private static IWebDriver CreateSafari(BrowserOptions browserOptions)
    {
        var options = new SafariOptions();

        return new SafariDriver(options);
    }

    private static IWebDriver CreateRemote(BrowserOptions browserOptions)
    {
        DriverOptions options;

        switch (browserOptions.
                BrowserToRun?.ToLower())
        {
            case "firefox":
                var firefoxOptions = new FirefoxOptions();
                if (browserOptions.Guest) firefoxOptions.AddArgument("--guest");
                options = firefoxOptions;
                break;
            default:
                var chromeOptions = new ChromeOptions();
                if (browserOptions.Guest) chromeOptions.AddArgument("--guest");
                if (browserOptions.Maximize) chromeOptions.AddArgument("--start-maximized");
                options = chromeOptions;
                break;
        }

        LogHelper.Info($"Starting remote WebDriver for browser: {browserOptions.BrowserToRun}");

        return new RemoteWebDriver(
            new Uri(browserOptions.RemoteRunUrl),
            options.ToCapabilities());
    }
}