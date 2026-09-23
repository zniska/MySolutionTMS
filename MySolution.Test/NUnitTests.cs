using System.Text.Json;
using MySolution.Core.Models;

namespace MySolution.Test;

[TestFixture]
public class NUnitTests(string browser) : BaseTest(browser)
{
    
    private static UserData[] testData =
    {
        new UserData{ Username = "username 1", Password = "password 1" },
        new UserData{ Username = "username 2", Password = "password 2" },
        new UserData{ Username = "username 3", Password = "password 3" }

    };

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        Console.WriteLine("OneTimeSetup");
    }

    [SetUp]
    public void Setup()
    {
        Console.WriteLine("Setup");
    }
    
    [Test]
    [TestCaseSource(nameof(testData))]
    [Category("smoke")]
    [Parallelizable(ParallelScope.Self)]
    public void Test1(UserData data)
    {
        Thread.Sleep(3000);
    }

    [Test]
    public void Test2()
    {
        Console.WriteLine("Test2");
        Thread.Sleep(3000);
    }

    [TearDown]
    public void TearDown()
    {
        Console.WriteLine("TearDown");
    }
    
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        Console.WriteLine("OneTimeTearDown");
    }
    
    private static IEnumerable<TestCaseData> GetUsers()
    {
        string filePath = Path.Combine(
            AppContext.BaseDirectory,
            "TestData",
            "Users.json");

        string json = File.ReadAllText(filePath);

        var users = JsonSerializer.Deserialize<List<UserData>>(json);

        foreach (var user in users!)
        {
            yield return new TestCaseData(user);
        }
    }
}