using MySolution.Core.Helpers;
using OpenQA.Selenium;

namespace MySolution.Core.PageObjects.Elements;

public class Checkbox : BaseElement
{
    public Checkbox(IWebDriver driver, By locator, string name) : base(driver, locator, name)
    {
        
    }

    public bool IsChecked()
    {
        LogHelper.Info($"Checking {_name} located by {_locator} if checkbox is checked");
        return !string.IsNullOrEmpty(Element.GetAttribute("checked"));
    }
    
    public void SetState(bool checkedState = true)
    {
        LogHelper.Info($"Checking {_name} located by {_locator} if checkbox is checked");
        if (checkedState != IsChecked())
        {
            Click();
        }
    }
    
}