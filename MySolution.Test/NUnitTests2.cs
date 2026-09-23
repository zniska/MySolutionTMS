using Allure.Net.Commons;
using Allure.Net.Commons.Attributes;
using Allure.NUnit;

namespace MySolution.Test;

[Parallelizable(ParallelScope.All)]
[AllureNUnit]
public class NUnitTests2(string browser) : BaseTest(browser)
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    [Category("smoke")]
    [AllureTag("Smoke")]
    [AllureName("Check&&&")]
    public void Test3()
    {
        AllureApi.Step("Test is started", () =>
        {
            Console.WriteLine("Test3");
            Thread.Sleep(3000);
        }); 
    }

    [Parallelizable(ParallelScope.None)]
    [Test]
    public void Test4()
    {
        Thread.Sleep(3000);
    }
    
    
    [Test]
    public void Test5()
    {
        Thread.Sleep(3000);
    }
    
    
    [Test]
    public void Test6()
    {
        Thread.Sleep(3000);
    }
    
    
    [Test]
    public void Test7()
    {
        Thread.Sleep(3000);
    }
    
    
    [Test]
    public void Test8()
    {
        Thread.Sleep(3000);
    }
    
    [Test]
    public void Test9()
    {
        Thread.Sleep(3000);
    }
    
    [Test]
    public void Test10()
    {
        Thread.Sleep(3000);
        Assert.Fail();
    }
}