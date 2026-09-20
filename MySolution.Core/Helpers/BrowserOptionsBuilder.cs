using OpenQA.Selenium.Chrome;

namespace MySolution.Core.Helpers;

public class BrowserOptionsBuilder
{
    private readonly ChromeOptions _options = new ChromeOptions();

    public BrowserOptionsBuilder SetMaximized(bool isMaximized)
    {
        if (isMaximized)
        {
            _options.AddArgument("--start-maximized");
        }
        
        return this;
    }

    public BrowserOptionsBuilder SetHeadless(bool isHeadless)
    {
        if (isHeadless)
        {
            _options.AddArgument("--headless");
        }

        return this;
    }
    
    
    public BrowserOptionsBuilder SetGuest(bool isGuest)
    {
        if (isGuest)
        {
            _options.AddArgument("--guest");
        }

        return this;
    }
    
    public ChromeOptions Build()
    {
        return _options;
    }
}