namespace MySolution.Test;

[Parallelizable(ParallelScope.Children)]
public class JavascriptTests(string browser) : BaseTest(browser)
{
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        Console.WriteLine("OneTimeSetup");
    }
    
    [SetUp]
    public void Setup()
    {
        Console.WriteLine("TestSetup");
    }
    /*
    [Test]
    public void JsTest()
    {        
        new BasePage(driver).OpenSauceDemo("https://the-internet.herokuapp.com");
        HerokuPage herokuPage = new HerokuPage(driver);
        Thread.Sleep(2000);
        herokuPage.ScrollToLastOption();
        Thread.Sleep(2000);
        herokuPage.ClickLastOptionViaJs();
        Thread.Sleep(2000);
        herokuPage.HideFrame();
        Thread.Sleep(10000);
    }*/

    [TestCase(3, 4, ExpectedResult=12)]
    [TestCase(3, 5, ExpectedResult=15)]
    [TestCase(3, 6, ExpectedResult=18)]
    public int Test1(int x, int y)
    {
        Thread.Sleep(3000);
        return x * y;
    }
    
    [Test]
    public void Test2()
    {
        Thread.Sleep(3000);
        Console.WriteLine("Test1");
    }


    [TearDown]
    public void Teardown()
    {
        Console.WriteLine("TestTeardown");
    }
    
    
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Console.WriteLine("OneTimeTearDown");
    }

}