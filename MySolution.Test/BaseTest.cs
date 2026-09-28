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

public class BaseTest
{
    private string _browser;
    public IWebDriver Driver = null!;
    private ILog logger = LogManager.GetLogger(typeof(BaseTest));

    [SetUp]
    public void Setup()
    {
        StartDriver();
    }
    
    [TearDown]
    public void TearDown()
    {
        StopDriver();
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

    public void StartDriver()
    {
        var settings = GetBrowserOptions();

        var browser = Environment.GetEnvironmentVariable("BROWSER");
        if (browser != null)
        {
            settings.Browser = Enum.Parse<Browser>(browser);
        }
        
        settings.BrowserToRun = "Chrome";
        Driver = WebDriverFactory.Create(settings);
        
        AllureApi.Step("Open Sauce Demo.", () =>
        {
            logger.Info("Open Sauce Demo.");
            PageFactory.Create<LoginPage>(Driver).OpenSauceDemo();
        });
    }

    public void StopDriver()
    {
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
}