using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExample.DataModel;
using System.Linq;

namespace SeleniumExample.PageObjects;
public class AllResults
{
    private IWebDriver driver;
    private By title = By.XPath("//a[@data-testid='result-title-a']/span");
    private By description = By.XPath("//div[@data-result='snippet']/span/span");
    private By url = By.XPath("//a[@data-testid='result-title-a']");
    private IEnumerable<IWebElement> CompleteResults => driver.FindElements(By.XPath("//article[@data-testid='result']"));

    public AllResults(IWebDriver driver)
    {
        this.driver = driver;

        new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            .Until((d) => 
            {
                if(d.FindElements(title).Count > 5){
                    return d;
                }
                return null;
            });
        
    }

    public IEnumerable<TextResult> GetAllResults()
    {
        var results = new List<TextResult>();
        var allResults = CompleteResults;

        foreach(var r in allResults)
        {
            var i = new TextResult()
            {
                Title = r.FindElement(title).Text,
                Link = r.FindElement(url).GetAttribute("href"),
                Description = r.FindElements(description).Last().Text

            };
            results.Add(i);
        }
        return results;
    }


} 