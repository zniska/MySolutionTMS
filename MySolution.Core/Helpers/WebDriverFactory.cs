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
        var options = new ChromeOptions();
        if (browserOptions.Guest)
        {
            options.AddArgument("--guest");
        }

        if (browserOptions.Maximize)
        {
            options.AddArgument("--start-maximized");
        }
        
        return new RemoteWebDriver(
            new Uri("http://selenium:4444"),
            options);
    }
}