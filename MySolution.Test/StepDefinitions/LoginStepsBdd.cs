using MySolution.Core.PageObjects;
using MySolution.Core.Steps;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace MySolution.Test.StepDefinitions;

[Binding]
public class LoginStepsBdd
{
    private IWebDriver _driver;
    private LoginPage _loginPage;
    private ProductsPage _productsPage;
    
    public LoginStepsBdd(ScenarioContext scenarioContext)
    {
        _driver = scenarioContext.Get<IWebDriver>();
        _loginPage = new LoginPage(_driver);
    }
    
    [Given("I open the login page by {string}")]
    public void GivenIAmOnTheLoginPage(string url)
    {
        _loginPage.Open(url);
    }

    [When("I login with credentials. Username {string} and password {string}")]
    public void WhenILoginWithValidCredentials(string username, string password)
    {
        _loginPage.SetUserName(username);
        _loginPage.SetPassword(password);
        _productsPage = _loginPage.ClickLoginButton();
    }

    [Then("I should {string} the products page")]
    public void ThenIShouldSeeTheProductsPage(string action)
    {
        if(action == "see")
        {
            Assert.That(_productsPage.IsCartIconDisplayed(), 
                Is.True,
                "Product page was not displayed");
        }
        {
            Assert.That(_productsPage.IsCartIconDisplayed(), 
                Is.False,
                "Product page is displayed");
        }
    }

    [Then("I should see an error message: {string}")]
    public void ThenIShouldSeeAnErrorMessage(string message)
    {
        Assert.That(_loginPage.GetErrorMessage(), 
            Is.EqualTo(message),
            "The correct error message was not displayed");
    }
}