using System.Text.Json;
using System.Text.Json.Serialization;
using Allure.Net.Commons;
using log4net;
using MySolution.Core.Helpers;
using MySolution.Core.Models;
using MySolution.Core.PageObjects;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace MySolution.Test;

[TestFixture("chrome")]
[TestFixture("firefox")]
public class BaseTest
{
    private string _browser;
    protected IWebDriver Driver = null!;
    private ILog logger = LogManager.GetLogger(typeof(BaseTest));

    public BaseTest(string browser)
    {
        _browser = browser;
    }

    [SetUp]
    public void Setup()
    {
        Console.WriteLine("BaseSetup");

        var settings = GetBrowserOptions();
        settings.Browser = Enum.Parse<Browser>(
            Environment.GetEnvironmentVariable("BROWSER")!
        );
        
        settings.BrowserToRun = _browser;
        Driver = WebDriverFactory.Create(settings);
        
        AllureApi.Step("Open Sauce Demo.", () =>
        {
            logger.Info("Open Sauce Demo.");
            PageFactory.Create<LoginPage>(Driver).OpenSauceDemo();
        });
    }
    
    [TearDown]
    public void TearDown()
    {
        Console.WriteLine("BaseTeardown");

        try
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            
            if (status == TestStatus.Failed && Driver != null)
            {
                logger.Error("Test Failed: " + TestContext.CurrentContext.Result.Message);
                byte[] screenshotBytes =
                    ((ITakesScreenshot)Driver).GetScreenshot().AsByteArray;

                AllureApi.AddAttachment(
                    "Screenshot",
                    "image/png",
                    screenshotBytes);
                LogHelper.Info("Screenshot added.");
            }
        }
        finally
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }

    private BrowserOptions GetBrowserOptions()
    {
        var json = File.ReadAllText("appsettings.json");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        options.Converters.Add(new JsonStringEnumConverter());

        return JsonSerializer.Deserialize<BrowserOptions>(json, options);
    }
}