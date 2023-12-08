using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class WebDriverService
{
    public IWebDriver Driver { get; private set; }

    public WebDriverService()
    {
        Driver = new ChromeDriver();
    }

    public void Dispose()
    {
        Driver.Quit();
    }
}
