using OpenQA.Selenium;

namespace MySolution.Core.PageObjects.HerokuApp;

public class NestedFramesPage : BasePage
{
    public NestedFramesPage(IWebDriver _driver) : base(_driver)
    {
        
    }

    public string SwitchToTopLeftFrame()
    {
        var topFrame = _driver.FindElement(By.XPath("//frame[@name='frame-top']"));
        _driver.SwitchTo().Frame(topFrame);
        _driver.SwitchTo().Frame("frame-left");
        return _driver.FindElement(By.XPath("//html")).Text;
    }

    public string SwitchToParentFrame()
    {
        _driver.SwitchTo().ParentFrame();
        return _driver.PageSource;
    }
    
    
    public string SwitchToDefaultContent()
    {
        _driver.SwitchTo().DefaultContent();
        return _driver.PageSource;
    }
}