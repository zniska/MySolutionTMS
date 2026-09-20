namespace MySolutionsXUnit;

public class UnitTest1 
{
    public UnitTest1()
    {
        Console.WriteLine("UnitTest1");
    }
    
    [Fact]
    public void Test1()
    {
        Console.WriteLine("Test1");
    }
    
    public void Dispose()
    {
        Console.WriteLine("Dispose");
    }
}