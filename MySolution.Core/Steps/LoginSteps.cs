using MySolution.Core.Helpers;
using MySolution.Core.Models.Dto;
using MySolution.Core.PageObjects;
using OpenQA.Selenium;

namespace MySolution.Core.Steps;

public class LoginSteps
{
    private IWebDriver _driver;
    
    public LoginSteps(IWebDriver driver)
    {
        _driver = driver;
    }
    
    public ProductsPage Login(Users user)
    {
        var loginPage = PageFactory.Create<LoginPage>(_driver);
        return loginPage.SetUserName(user.Username).SetPassword(user.Password).ClickLoginButton();
    }
}