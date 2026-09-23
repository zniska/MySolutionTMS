using Allure.NUnit;
using Allure.NUnit.Attributes;
using MySolution.Core.Models.Dto;
using MySolution.Core.PageObjects;
using MySolution.Core.Steps;

namespace MySolution.Test;

[TestFixture("chrome")]
//[TestFixture("firefox")]
[Parallelizable(ParallelScope.Fixtures)]
[AllureNUnit]
[AllureFeature("Login")]
public class LogoutTests(string browser) : BaseTest(browser)
{
    private readonly Users User = new Users()
    {
        Username = "standard_user",
        Password = "secret_sauce"
    };

    [Test]
    [Category("smoke")]
    public void LogoutSuccess()
    {
        LoginSteps loginSteps = new LoginSteps(Driver);
        ProductsPage productsPage = loginSteps.Login(User);
        var newLoginPage = productsPage.Header.Logout();
        Assert.That(newLoginPage.IsLoginPageDisplayed(), Is.True);
    }
}