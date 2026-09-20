using MySolution.Core.PageObjects.Elements;
using OpenQA.Selenium;

namespace MySolution.Core.PageObjects.HerokuApp;

public class HerokuPage : BasePage
{
    private readonly By lnkBottom = By.LinkText("WYSIWYG Editor");
    
    public HerokuPage(IWebDriver driver) : base(driver)
    {
        
    }

    public void ScrollToLastOption()
    {
        var btnBottom = new BaseElement(_driver, lnkBottom, "");
        
        
        var jsExecutor = (IJavaScriptExecutor)_driver;
        jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", btnBottom);
    }

    public void ClickLastOptionViaJs()
    {
        var btnBottom = _driver.FindElement(lnkBottom);
        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", btnBottom);
    }

    public void HideFrame()
    {
        ((IJavaScriptExecutor)_driver).ExecuteScript("document.getElementsByTagName('iframe').style.display='none';");
    }
}