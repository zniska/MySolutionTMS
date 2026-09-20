using OpenQA.Selenium;

namespace MySolution.Core.PageObjects;

public class ProductsPage : BasePage
{
    #region Locators
    
    private readonly By imgCart = By.CssSelector("a[data-test='shopping-cart-link']");
    private readonly By secItem = By.XPath("//div[@data-test='inventory-item-description']");
    private readonly By btnAddToCard = By.XPath("//button[@data-test='add-to-cart-sauce-labs-backpack']");
    #endregion

    public HeaderSection Header => new (_driver);

    public ProductsPage(IWebDriver driver) : base(driver)
    {
    }

    #region Methods

    public bool IsCartIconDisplayed()
    {
        try
        {
            return _driver.FindElement(imgCart).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }

    public ProductsPage AddItemToCart(string itemName)
    {
        var item = _driver.FindElements(secItem).First(e => e.Text.Contains(itemName));
        var buttonAddToCart = item.FindElement(btnAddToCard);
        buttonAddToCart.Click();
        return this;
    }

    public ProductsPage WaitForCartIcon()
    {
        _wait.Until(e => IsCartIconDisplayed());
        return this;
    }
    
    #endregion
}