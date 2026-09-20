using MySolution.Core.Helpers;
using MySolution.Core.Models;
using MySolution.Core.PageObjects.Elements;
using OpenQA.Selenium;

namespace MySolution.Core.PageObjects;

public class LoginPage : BasePage
{
    private readonly By _inpUsername = By.Id("user-name");
    private readonly By _inpPassword = By.CssSelector("input[data-test='password']");
    private readonly By _btnLogin = By.Id("login-button");
    private readonly By _msgError = By.CssSelector("h3[data-test='error']");
    
    [FindBy(How.Id, "user-name", "UserName field")]
    private Input UserName { get; set; }
    
    [FindBy(How.CssSelector, "input[data-test='password']", "Password field")]
    private Input Password { get; set; }
    
    [FindBy(How.Id, "login-button", "Login Button")]
    private BaseElement LoginButton { get; set; }
    
    public LoginPage(IWebDriver driver) : base(driver)
    {
        _driver = driver;
    }

    public LoginPage SetUserName(string username)
    {
        //new Input(_driver, _inpUsername, "Username input").SendKeys(username);
        UserName.SendKeys(username);
        return this;
    }

    public string GetUserNameValue()
    {
        return new Input(_driver, _inpUsername, "Username input").GetValue();
    }

    public LoginPage SetPassword(string password)
    {
        //new UiElement(_driver, "Password input", _inpPassword).SendKeys(password);
        Password.SendKeys(password);
        return this;
    }

    public ProductsPage ClickLoginButton()
    {
        //new UiElement(_driver, "Login button", _btnLogin).Click();
        LoginButton.Click();
        return new ProductsPage(_driver);
    }
    
    public string GetErrorMessage() =>
        new UiElement(_driver, "Error Message", _msgError).GetText();
    
    public bool IsLoginPageDisplayed() =>
        UserName.IsDisplayed()
        && Password.IsDisplayed()
        && LoginButton.IsDisplayed();
}