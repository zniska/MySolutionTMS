using OpenQA.Selenium;

namespace MySolution.Core.PageObjects;

public class LoginPage : BasePage
{
    private readonly By _inpUsername = By.Id("user-name");
    private readonly By _inpPassword = By.CssSelector("input[data-test='password']");
    private readonly By _btnLogin = By.Id("login-button");
    private readonly By _msgError = By.CssSelector("h3[data-test='error']");

    public LoginPage(IWebDriver driver) : base(driver)
    {
        _driver = driver;
    }

    public LoginPage SetUserName(string username)
    {
        _driver.FindElement(_inpUsername).SendKeys(username);
        return this;
    }

    public LoginPage SetPassword(string password)
    {
        _driver.FindElement(_inpPassword).SendKeys(password);
        return this;
    }

    public ProductsPage ClickLoginButton()
    {
        _driver.FindElement(_btnLogin).Click();
        return new ProductsPage(_driver);
    }

    public ProductsPage Login(string username = "standard_user", string password = "secret_sauce") =>
        SetUserName(username).SetPassword(password).ClickLoginButton();
    
    public string GetErrorMessage() => 
        _driver.FindElement(_msgError)?.Text;
    
    public bool IsLoginPageDisplayed() =>
        _driver.FindElement(_btnLogin).Displayed 
        && _driver.FindElement(_inpUsername).Displayed 
        && _driver.FindElement(_inpPassword).Displayed;
}