using MySolution.Core.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MySolution.Core.PageObjects;

public class BasePage
{
    protected IWebDriver _driver;
    protected WebDriverWait _wait;
    
    public BasePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    public void OpenSauceDemo(string url = "https://www.saucedemo.com")
    {
        //LogHelper.Info("Opening Sauce Demo page");
        _driver.Navigate().GoToUrl(url);
        _driver.Manage().Window.Maximize();
    }

    public string GetUrl()
    {
        return _driver.Url;
    }

    public string GetPageTitle()
    {
        return _driver.Title;
    }
}