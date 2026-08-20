using MySolution.Core.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MySolution.Test;

public class BaseTest
{
    protected IWebDriver driver;
    
    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--guest"); 
        driver = new ChromeDriver(options);
        new BasePage(driver).OpenSauceDemo();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }
}