using MySolution.Core.Models;

namespace MySolution.Core.Helpers;

public class BrowserOptions
{
    public Browser Browser { get; set; }
    public bool Headless { get; set; }
    public bool Maximize { get; set; }
    public bool Guest { get; set; }
}