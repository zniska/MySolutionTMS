using MySolution.Core.Helpers;
using OpenQA.Selenium.Support.UI;

namespace MySolution.Core.PageObjects.Elements;

public partial class BaseElement
{
    private WebDriverWait Wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    
    public void WaitForToBeDisplayed()
    {
        LogHelper.Info($"Waiting for the {_name} element to be displayed");
        Wait.Until(e=> IsDisplayed());
    }
    
    public void WaitForElementToBeEnabled()
    {
        LogHelper.Info($"Waiting for the {_name} element to be enabled");
        Wait.Until(e=> IsEnabled());
    }
}