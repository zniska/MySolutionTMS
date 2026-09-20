using OpenQA.Selenium;

namespace MySolution.Core.PageObjects;

public class HeaderSection : BasePage
{
    private readonly By _btnBurgerMenu = By.Id("react-burger-menu-btn");
    private readonly By _btnLogout = By.Id("logout_sidebar_link");
    
    public HeaderSection(IWebDriver driver) : base(driver)
    {
    }

    public HeaderSection OpenSideMenu()
    {
        WaitForBurgerMenu();
        _driver.FindElement(_btnBurgerMenu).Click();
        
        return this;
    }

    public LoginPage ClickLogoutButton()
    {
        _driver.FindElement(_btnLogout).Click();
        return new LoginPage(_driver);
    }

    public LoginPage Logout()
    {
        return OpenSideMenu().WaitForLogoutButton().ClickLogoutButton();
    }

    public HeaderSection WaitForBurgerMenu()
    {
        _wait.Until(e => e.FindElement(_btnBurgerMenu).Displayed);
        return this;
    }

    public HeaderSection WaitForLogoutButton()
    {
        _wait.Until(e => e.FindElement(_btnLogout).Displayed);
        return this;
    }
}