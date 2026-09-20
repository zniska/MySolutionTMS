namespace MySolutionMsTest;

[TestClass]
public sealed class Test1
{
    [TestInitialize]
    public void Initialize()
    {
        Console.WriteLine("TestInitialize");
    }

    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        Console.WriteLine("ClassInitialize");
    }
    
    [TestMethod]
    public void TestMethod1()
    {
        Console.WriteLine("Test");
        Assert.AreEqual("test", "netest", "Test was failed");

    }

    [TestMethod]
    public void TestMethod2()
    {
        Console.WriteLine("Test");
    }
    
    [TestCleanup]
    public void Cleanup()
    {
        Console.WriteLine("TestCleanup");
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        Console.WriteLine("ClassCleanup");
    }
}