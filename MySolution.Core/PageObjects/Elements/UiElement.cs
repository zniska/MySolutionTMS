using MySolution.Core.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace MySolution.Core.PageObjects.Elements;

public class UiElement
{
    private string _name;
    private By _locator;
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private const int timeout = 10;
    
    public UiElement(IWebDriver driver, string name, By locator)
    {
        _driver = driver;
        _name = name;
        _locator = locator;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
    }

    public IWebElement Find()
    {
        return _driver.FindElement(_locator);
    }

    public void Click()
    {
        LogHelper.Info($"Clicking {_name} located by {_locator}");
        Find().Click();
    }

    public void ClickJs()
    {
        LogHelper.Info($"Clicking using JavaScript {_name} located by {_locator}");
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", Find());
    }

    public void SendKeys(string text)
    {
        LogHelper.Info($"Sending {text} to {_name} located by {_locator}");
        Find().SendKeys(text);
    }

    public void Submit()
    {
        LogHelper.Info($"Submitting {_name} located by {_locator}");
        Find().Submit();
    }

    public string GetText()
    {
        LogHelper.Info($"Getting text from {_name} located by {_locator}");
        return Find().Text;
    }

    public string GetAttribute(string attributeName)
    {
        LogHelper.Info($"Getting attribute value named {attributeName} from {_name} element located by {_locator}");
        return Find().GetAttribute(attributeName);
    }

    public bool IsEnabled()
    {
        try
        {
            return Find().Enabled;
        }
        catch (Exception)
        {
            return false;
        }
    }
    
    public bool IsDisplayed()
    {
        try
        {
            return Find().Displayed;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void ScrollToElement()
    {
        LogHelper.Info($"Scrolling to {_name} located by {_locator}");
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", Find());
    }

    public void DragAndDropToElement(By locator)
    {
        Actions actions = new Actions(_driver);
        actions.DragAndDrop(Find(), _driver.FindElement(locator)).Perform();
    }

    public void WaitForElementDisplayed()
    {
        LogHelper.Info($"Waiting for {_name} located by {_locator}");
        _wait.Until(e => e.FindElement(_locator).Displayed);
    }

    public void GetChildren(By childLocator)
    {
        Find().FindElements(childLocator);
    }
}