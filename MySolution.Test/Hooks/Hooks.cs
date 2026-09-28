using Reqnroll;

namespace MySolution.Test.Hooks;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;
    private readonly BaseTest _baseTest;

    public Hooks(
        ScenarioContext scenarioContext,
        BaseTest baseTest)
    {
        _scenarioContext = scenarioContext;
        _baseTest = baseTest;
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        _baseTest.StartDriver();
        _scenarioContext.Set(_baseTest.Driver);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        _baseTest.StopDriver();
    }
}