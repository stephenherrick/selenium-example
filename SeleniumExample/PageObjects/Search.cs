using OpenQA.Selenium;

namespace SeleniumExample.PageObjects;
public class Search 
{
    private IWebDriver driver;
    private IWebElement SearchBox =>  driver.FindElement(By.Id("searchbox_input"));
    private IWebElement SearchButton => driver.FindElement(By.XPath("//button[@aria-label='Search']"));


    public Search(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void InputSearchText(string searchText)
    {
        SearchBox.SendKeys(searchText);
    }

    public void ExecuteSearch()
    {
        SearchButton.Click();
    }

    public void InputSearchAndExecute(string searchText)
    {
        InputSearchText(searchText);
        ExecuteSearch();
    }

}

