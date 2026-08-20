using OpenQA.Selenium;

namespace MySolution.Core.PageObjects;

public class ProductsPage : BasePage
{
    #region Locators
    private readonly By imgCart = By.CssSelector("a[data-test='shopping-cart-link']");
    #endregion

    public HeaderSection Header => new (_driver);

    public ProductsPage(IWebDriver driver) : base(driver)
    {
        _driver = driver;
    }

    #region Methods

    public bool IsCartIconDisplayed()
    {
        return _driver.FindElement(imgCart)?.Displayed ?? false;
    }
    
    #endregion
}