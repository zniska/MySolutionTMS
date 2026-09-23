using Allure.Net.Commons;
using Allure.Net.Commons.Attributes;
using Allure.NUnit;
using MySolution.Core.Models.Dto;
using MySolution.Core.PageObjects;
using MySolution.Core.Steps;

namespace MySolution.Test;

[AllureNUnit]
[TestFixture("chrome")]
//[TestFixture("firefox")]
[Parallelizable(ParallelScope.Fixtures)]
[AllureFeature("Login")]
public class LoginTests(string browser) : BaseTest(browser)
{
    private readonly Users User = new Users()
    {
        Username = "standard_user",
        Password = "secret_sauce"
    };
        
    [Test]
    [AllureName("Successfully logged in")]
    [Category("smoke")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureDescription("The test logins with valid username and checks that cart icon is displayed.")]
    public void LoginSuccess()
    {
        LoginSteps loginSteps = new LoginSteps(Driver);
        AllureApi.Step("Login with valid user.", () =>
        {
            ProductsPage productsPage = loginSteps.Login(User);
            Assert.That(productsPage.IsCartIconDisplayed(), Is.True);
        });
    }
    
    [Test]
    [AllureName("Login with locked user")]
    [Category("regression")]
    [AllureSeverity(SeverityLevel.minor)]
    public void LoginLockedUser()
    {
        LoginSteps loginSteps = new LoginSteps(Driver);
        User.Username = "locked_out";
        
        AllureApi.Step("Login with locked user.", () =>
        {
            loginSteps.Login(User);
        });
        
        AllureApi.Step("Verify an error message for locked user.", () =>
        {
            //Assert.That(loginPage.GetErrorMessage(), Is.EqualTo("Epic sadface: Sorry, this user has been locked out."));
        });
    }
}