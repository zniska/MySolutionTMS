using Allure.NUnit;
using MySolution.Core.PageObjects;
using MySolution.Core.PageObjects.HerokuApp;

namespace MySolution.Test;

[AllureNUnit]
public class CheckboxTests(string browser) : BaseTest(browser)
{
    [Test]
    public void CheckboxTest1()
    {
        new LoginPage(Driver).OpenSauceDemo("https://the-internet.herokuapp.com/checkboxes");
        
        var checkboxPage = new CheckboxPage(Driver);
        
        checkboxPage.SetFirstCheckbox(true);
        checkboxPage.SetSecondCheckbox(true);
        Assert.Multiple(() =>
        {
            Assert.That(checkboxPage.IsFirstCheckboxChecked(), Is.True);
            Assert.That(checkboxPage.IsSecondCheckboxChecked, Is.True);
        });
    }

    [Test]
    public void HoverTest()
    {
        new LoginPage(Driver).OpenSauceDemo("https://the-internet.herokuapp.com/hovers");
        var checkboxPage = new CheckboxPage(Driver);
        checkboxPage.HoverFirst();
        
        Assert.That(checkboxPage.IsFirstViewButtonDisplayed(), Is.True);
    }

    [Test]
    [TestCase("5")]
    public void InputTest(string number)
    {
        var checkboxPage = new LoginPage(Driver);
        checkboxPage.SetUserName(number);
        Thread.Sleep(3000);
        Assert.That(checkboxPage.GetUserNameValue(), Is.EqualTo(number));
    }
}