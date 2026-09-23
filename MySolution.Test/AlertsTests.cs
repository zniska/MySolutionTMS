using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using MySolution.Core.PageObjects;
using MySolution.Core.PageObjects.HerokuApp;

namespace MySolution.Test;

[AllureNUnit]
[AllureFeature("Alerts")]
public class AlertsTests(string browser) : BaseTest(browser)
{
    [Test]
    public void AlertTest()
    {
        AllureApi.Step("Open Heroku App", () =>
        {
            new AlertsPage(Driver).OpenSauceDemo("https://the-internet.herokuapp.com/javascript_alerts");
        });
        
        var alertsPage = new AlertsPage(Driver);
        
        AllureApi.Step("Do Javascript Click on alert", () =>
        {
            alertsPage.ClickJs();
            Assert.That(alertsPage.GetAlertText(), Is.EqualTo("I am a JS Alert"));
        });
        
        AllureApi.Step("Accept Alert", () =>
        {
            alertsPage.AcceptAlert();
            Assert.That(alertsPage.GetResult(), Is.EqualTo("You successfully clicked an alert"));
        });
    }
    
    [Test]
    public void AlertTest2()
    {
        new LoginPage(Driver).OpenSauceDemo("https://the-internet.herokuapp.com/javascript_alerts");
        var alertsPage = new AlertsPage(Driver);
        
        alertsPage.ClickJsConfirm();
        Assert.That(alertsPage.GetAlertText(), Is.EqualTo("I am a JS Confirm"));
        alertsPage.AcceptAlert();
        Assert.That(alertsPage.GetResult(), Is.EqualTo("You clicked: Ok"));
        alertsPage.ClickJsConfirm();

        Assert.That(alertsPage.GetAlertText(), Is.EqualTo("I am a JS Confirm"));
        alertsPage.DismissAlert();
        Assert.That(alertsPage.GetResult(), Is.EqualTo("You clicked: Cancel"));

    }
}