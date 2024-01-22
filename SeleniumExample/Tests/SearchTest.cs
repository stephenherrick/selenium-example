using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExample.PageObjects;

namespace SeleniumExample.Tests;

public class SearchTest : TestBase
{

    [Test]
    public void Test1()
    {
        var search = new Search(driver);
        search.InputSearchAndExecute("test");

        var results = new AllResults(driver);
        var resultItems = results.GetAllResults();
        foreach(var item in resultItems)
        {
            Console.WriteLine(item.Description);
        }

        Assert.That(resultItems.Any(d => d.Description.Contains("test", StringComparison.InvariantCultureIgnoreCase)), Is.True);
    }
}