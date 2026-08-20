using MySolution.Core.PageObjects;

namespace MySolution.Test;

public class LogoutTests : BaseTest
{
    [Test]
    public void LoginSuccess()
    {
        LoginPage loginPage = new LoginPage(driver);
        ProductsPage productsPage = loginPage.Login();
        var newLoginPage = productsPage.Header.Logout();
        Assert.That(newLoginPage.IsLoginPageDisplayed(), Is.True);
    }
}