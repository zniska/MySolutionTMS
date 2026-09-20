using MySolution.Core.PageObjects;
using MySolution.Core.PageObjects.HerokuApp;

namespace MySolution.Test;

public class NestedFrameTests : BaseTest
{
    [Test]
    public void NestedFrame()
    {
        new BasePage(Driver).OpenSauceDemo("https://the-internet.herokuapp.com/nested_frames");
        
        var nestedFramesPage = new NestedFramesPage(Driver);
        var text = nestedFramesPage.SwitchToTopLeftFrame();

        var textParentFrame = nestedFramesPage.SwitchToDefaultContent();
    }
}