using MySolution.Core.Models;

namespace MySolution.Core.Helpers;

[AttributeUsage(AttributeTargets.Property)]
public class FindByAttribute : Attribute
{
    public How How { get; }
    
    public string Locator { get; }
    
    public string Name { get; }

    public FindByAttribute(How how, string locator, string name)
    {
        How = how;
        Locator = locator;
        Name = name;
    }
}