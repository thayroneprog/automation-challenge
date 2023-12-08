using AutomationChallenge.Infrastructure;
using AutomationChallenge.Services;
using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

class Program
{
    static async Task Main()
    {
        var serviceProvider = ConfigureServices();
        var aluraSearchService = serviceProvider.GetRequiredService<IAluraSearchService>();

        Console.Write("Digite o termo de busca: ");
        var termo = Console.ReadLine();

        var results = aluraSearchService.RealizarBusca(termo);

        if(results.Count > 0)
        {
            var dbContext = new AutomationChallengeDbContext();
            var courseRepository = new CourseRepository(dbContext);

            foreach (var result in results)
            {
                courseRepository.InsertCourse(result);
            }
        }

        Console.WriteLine("Busca realizada com sucesso!");
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IWebDriver>(provider => new ChromeDriver());
        services.AddTransient<IAluraSearchService, AluraSearchService>();


        return services.BuildServiceProvider();
    }
}