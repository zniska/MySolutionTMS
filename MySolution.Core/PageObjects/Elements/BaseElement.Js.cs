using MySolution.Core.Helpers;
using OpenQA.Selenium;

namespace MySolution.Core.PageObjects.Elements;

public partial class BaseElement
{
    private IJavaScriptExecutor Js => ((IJavaScriptExecutor)_driver);
    
    public void ClickJs()
    {
        LogHelper.Info($"Clicking using JS the {_name} element by locator: {_locator}");
        Js.ExecuteScript("arguments[0].click();", _driver);
    }

    public void ScrollToElement()
    {
        LogHelper.Info($"Scrolling using JS the {_name} element by locator: {_locator}");
        Js.ExecuteScript("arguments[0].scrollIntoView(true);", _driver);
    }
}