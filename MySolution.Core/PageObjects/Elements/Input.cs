using OpenQA.Selenium;

namespace MySolution.Core.PageObjects.Elements;

public class Input : BaseElement
{
    
    public Input(IWebDriver driver, By locator, string name) : base(driver, locator, name)
    {
        
    }

    public string GetValue()
    {
        return Element.GetAttribute("value");
    }
    
    public string GetPlaceHolder()
    {
        return Element.GetAttribute("placeholder");
    }
}