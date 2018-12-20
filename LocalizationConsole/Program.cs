using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using Models.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LocalizationConsole
{
    public static class Program
    {
        private static LocalizationDbContext GetContext()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            var optionBuilder = new DbContextOptionsBuilder<LocalizationDbContext>().UseSqlServer(configuration.GetConnectionString("Db")).EnableSensitiveDataLogging().UseLazyLoadingProxies();
            var context = new LocalizationDbContext(optionBuilder.Options);
            context.Seed();

            return context;
        }

        private static void PrintProperties(object obj)
        {
            Console.WriteLine($"Displaying {obj.GetType().Name}");
            Console.WriteLine("--------------------------------");
            foreach (var prop in obj.GetType().GetProperties().Where(p => p.CanRead))
            {
                Console.WriteLine($"{prop.Name}: {prop.GetValue(obj)}");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var productRepository = new ProductRepository(GetContext());
            var bucket = new Product
            {
                Price = 15.78m,
                LocalizablePropertySets = new List<LocalizableProductPropertySet>
                {
                    new LocalizableProductPropertySet
                    {
                        CultureCode = "de-de",
                        Name = "Eimer",
                        Description = "Ein Eimer dient zum Transport von Wasser"
                    }
                }
            };
            productRepository.Add(bucket);

            Console.WriteLine("fr-FR");
            foreach (var product in productRepository.GetAll("fr-FR"))
            {
                PrintProperties(product);
            }

            Console.WriteLine("nl-BE");
            foreach (var product in productRepository.GetAll("nl-BE"))
            {
                PrintProperties(product);
            }

            Console.ReadKey();
        }
    }
}
