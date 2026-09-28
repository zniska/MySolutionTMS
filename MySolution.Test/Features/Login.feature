Feature: Login

@smoke
Scenario Outline: Successful login
    Given I open the login page by "https://www.saucedemo.com"
    When I login with credentials. Username "<username>" and password "<password>"
    Then I should "<action>" the products page
    
    Examples:
    | username        | password     | action
    | standard_user   | secret_sauce | see
    | locked_out_user | secret_sauce | not see
    
    
    
    