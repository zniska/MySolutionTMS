using MySolution.Core.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MySolution.Core.PageObjects.Elements;

public partial class BaseElement
{
    protected IWebDriver _driver;
    protected By _locator;
    protected string _name;

    public BaseElement(IWebDriver driver, By locator, string name)
    {
        _driver = driver;
        _locator = locator;
        _name = name;
    }
    
    public IWebElement Element => _driver.FindElement(_locator);

    public void Click()
    {
        LogHelper.Info($"Clicking the {_name} element by locator: {_locator}");
        _driver.FindElement(_locator).Click();
    }
    
    public void Hover()
    {
        LogHelper.Info($"Hovering the {_name} element by {_locator}");
        Actions action = new Actions(_driver);
        action.MoveToElement(_driver.FindElement(_locator)).Perform();
    }

    public void SendKeys(string text)
    {
        LogHelper.Info($"Sending keys {_name} by locator: {_locator}");
        _driver.FindElement(_locator).SendKeys(text);
    }

    public bool IsDisplayed()
    {
        LogHelper.Info($"Checking that the {_name} element is displayed: {_locator}");
        try
        {
            return _driver.FindElement(_locator).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
    
    public bool IsEnabled()
    {
        LogHelper.Info($"Checking that the {_name} element is enabled: {_locator}");
        try
        {
            return _driver.FindElement(_locator).Enabled;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    public string GetText()
    {
        return _driver.FindElement(_locator).Text;
    }

    public string GetAttribute(string attributeName)
    {
        return _driver.FindElement(_locator).GetAttribute(attributeName);
    }
}