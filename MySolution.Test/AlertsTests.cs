using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using MySolution.Core.PageObjects;
using MySolution.Core.PageObjects.HerokuApp;

namespace MySolution.Test;

[AllureNUnit]
[AllureFeature("Alerts")]
public class AlertsTests : BaseTest
{
    [Test]
    public void AlertTest()
    {
        AllureApi.Step("Open Heroku App", () =>
        {
            new BasePage(Driver).OpenSauceDemo("https://the-internet.herokuapp.com/javascript_alerts");
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
        new BasePage(Driver).OpenSauceDemo("https://the-internet.herokuapp.com/javascript_alerts");
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
    
    [Test]
    public void AlertTest3()
    {
        string expectedValue = "test";
        new BasePage(Driver).OpenSauceDemo("https://the-internet.herokuapp.com/javascript_alerts");
        var alertsPage = new AlertsPage(Driver);
        
        alertsPage.ClickJsPrompt();
        Thread.Sleep(3000);
        Assert.That(alertsPage.GetAlertText(), Is.EqualTo("I am a JS prompt"));
        alertsPage.SendValueAlert(expectedValue);
        Thread.Sleep(3000);
        alertsPage.AcceptAlert();
        Thread.Sleep(3000);
        Assert.That(alertsPage.GetResult(), Is.EqualTo($"You entered: {expectedValue}"));
    }
}