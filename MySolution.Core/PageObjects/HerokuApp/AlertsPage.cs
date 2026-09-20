using MySolution.Core.Helpers;
using OpenQA.Selenium;

namespace MySolution.Core.PageObjects.HerokuApp;

public class AlertsPage : BasePage
{
    private readonly IWebElement _alert;
    private readonly By _btnClickJs = By.XPath("//button[text()='Click for JS Alert']");
    private readonly By _btnClickJsConfirm = By.XPath("//button[text()='Click for JS Confirm']");
    private readonly By _btnClickJsPrompt = By.XPath("//button[text()='Click for JS Prompt']");
    private readonly By _lblResult = By.Id("result");
    
    public AlertsPage(IWebDriver _driver) : base(_driver)
    {
        
    }

    public void ClickJs()
    {
        LogHelper.Info($"Clicking JS Alert by {_btnClickJs}");
        _driver.FindElement(_btnClickJs).Click();
    }

    public void ClickJsConfirm()
    {
        _driver.FindElement(_btnClickJsConfirm).Click();
    }
    
    
    public void ClickJsPrompt()
    {
        _driver.FindElement(_btnClickJsPrompt).Click();
    }

    public string GetAlertText()
    {
        return _driver.SwitchTo().Alert().Text;
    }

    public void AcceptAlert()
    {
        LogHelper.Info("Accepting Alert");
        _driver.SwitchTo().Alert().Accept();
    }

    public void DismissAlert()
    {
        _driver.SwitchTo().Alert().Dismiss();
    }

    public void SendValueAlert(string message)
    {
        _driver.SwitchTo().Alert().SendKeys(message);
    }

    public string GetResult()
    {
        LogHelper.Info("Getting Alert Result");
        return _driver.FindElement(_lblResult).Text;
    }
}