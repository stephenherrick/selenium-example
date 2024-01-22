using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExample.DataModel;
using Microsoft.Extensions.Configuration;
using System.Text.Json;


namespace SeleniumExample;

public class TestBase
{
    public IWebDriver driver;
    private SeleniumOptions seleniumOptions;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var config = new ConfigurationManager()
        .AddJsonFile("appsettings.json")
        .Build();

        seleniumOptions = config.GetSection("SeleniumOptions").Get<SeleniumOptions>();
    }

    [SetUp]
    public void StartUp()
    {
        var options = new ChromeOptions();
        options.AddArguments(seleniumOptions.DriverArguments);

        driver = new ChromeDriver(options);
        driver.Url = seleniumOptions.BaseUrl;
    }

    [TearDown]
    public void TearDown(){
        driver.Quit();
    }
}