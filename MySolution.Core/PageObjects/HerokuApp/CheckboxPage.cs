using MySolution.Core.PageObjects.Elements;
using OpenQA.Selenium;

namespace MySolution.Core.PageObjects.HerokuApp;

public class CheckboxPage : BasePage
{
    
    private By checkboxLocator = By.XPath("//form/input");
    private By checkboxFirstInput = By.XPath("//input[@type='checkbox'][1]");
    private By checkboxSecondInput = By.XPath("//input[@type='checkbox'][2]");

    private By button = By.XPath("//button");
    private By hoverloctator = By.XPath("(//img[@alt='User Avatar'])[1]");
    private By firstViewPage = By.XPath("//h5[text()='name: user1']");
    private By inputNumberLocator = By.XPath("//input[@type='number']");
    
    public CheckboxPage(IWebDriver _driver) : base(_driver)
    {
        
    }

    public void SetFirstCheckbox(bool isChecked)
    {
        new Checkbox(_driver, checkboxFirstInput, "Checkbox 1").SetState(isChecked);
    }

    public void SetSecondCheckbox(bool isChecked)
    {
        new Checkbox(_driver, checkboxSecondInput, "Checkbox 2").SetState(isChecked);
    }

    public bool IsFirstCheckboxChecked()
    {
        return new Checkbox(_driver, checkboxFirstInput, "Checkbox 1").IsChecked();
    }

    public bool IsSecondCheckboxChecked()
    {
        return new Checkbox(_driver, checkboxSecondInput, "Checkbox 2").IsChecked();
    }

    public bool IsButtonDisplayed()
    {
        return new BaseElement(_driver, button, "Random Button").IsDisplayed();
    }

    public void HoverFirst()
    {
        new BaseElement(_driver, hoverloctator, "First avatar icon").Hover();
    }

    public bool IsFirstViewButtonDisplayed()
    {
        var firstViewElement = new BaseElement(_driver, firstViewPage, "First 'View Page' button");
        firstViewElement.WaitForToBeDisplayed();
        return firstViewElement.IsDisplayed();
    }

    public void InputNumber(string number)
    {
        var input = new Input(_driver, inputNumberLocator, "Number Input");
        input.SendKeys(number);
    }

    public string GetNumberInputValue()
    {
        var input = new Input(_driver, inputNumberLocator, "Number Input");
        return input.GetValue();
    }
    
    /*
    public ElementCollection<Checkbox> Checkboxes => new ElementCollection<Checkbox>(_driver, "Checkboxes", checkboxLocator,
        (driver, name, element) => new Checkbox(driver, name, element));*/
}