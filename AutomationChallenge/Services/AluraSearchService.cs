using Domain.Entities;
using Domain.Interfaces.Services;
using OpenQA.Selenium;

namespace AutomationChallenge.Services
{
    public class AluraSearchService : IAluraSearchService
    {
        private readonly IWebDriver _driver;

        public AluraSearchService(IWebDriver driver)
        {
            _driver = driver;
        }

        public List<CourseInformationEntity> RealizarBusca(string termo)
        {
            _driver.Navigate().GoToUrl("https://www.alura.com.br/");

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));

            var campoBusca = _driver.FindElement(By.CssSelector("input[type='search']"));
            campoBusca.SendKeys(termo);
            campoBusca.SendKeys(Keys.Enter);

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));

            var courseElements = _driver.FindElements(By.CssSelector(".busca-resultado"));

            var courseInformationList = new List<CourseInformationEntity>();
            List<string> teatcherList = new List<string>();
            foreach (var courseElement in courseElements)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));

                var courseNameElement = courseElement.FindElement(By.CssSelector(".busca-resultado-nome"));

                if (courseNameElement.Text.Contains("Formação"))
                {
                    courseElement.Click();

                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));

                    var title = _driver.FindElement(By.CssSelector(".formacao-headline-titulo")).Text + " " +
                        _driver.FindElement(By.CssSelector(".formacao-headline-subtitulo")).Text;
                    var teachers = _driver.FindElements(By.CssSelector(".formacao-instrutores"));

                    foreach(var teatcher in teachers)
                    {
                        var teatcherName = teatcher.FindElement(By.CssSelector(".formacao-instrutor-nome")).Text;
                        teatcherList.Add(teatcherName);
                    }
                    var workload = _driver.FindElement(By.CssSelector(".formacao__info-destaque")).Text;
                    var description = _driver.FindElement(By.CssSelector(".formacao-descricao-texto")).Text;

                    _driver.Navigate().Back();

                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(3));

                    var courseInformation = new CourseInformationEntity
                    {
                        Title = title,
                        Teatchers = teatcherList,
                        Workload = workload,
                        Description = description
                    };

                    courseInformationList.Add(courseInformation);
                }
            }
            return courseInformationList;
        }
    }
}
