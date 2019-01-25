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
            //Console.WriteLine($"Displaying {obj.GetType().Name}");
            //Console.WriteLine();
            foreach (var prop in obj.GetType().GetProperties().Where(p => p.CanRead))
            {
                Console.WriteLine($"{prop.Name}: {prop.GetValue(obj)}");
            }
            Console.WriteLine();
        }

        private static void AddABucket(ProductRepository productRepository)
        {
            var bucket = new Product
            {
                Price = 15.78m,
                LocalizedPropertySets = new List<LocalizedProductPropertySet>
                {
                    new LocalizedProductPropertySet
                    {
                        CultureCode = "de-de",
                        Name = "Eimer",
                        Description = "Ein Eimer dient zum Transport von Wasser"
                    }
                }
            };
            productRepository.Add(bucket);
        }

        static void Main(string[] args)
        {
            var productRepository = new ProductRepository(GetContext());
            AddABucket(productRepository);

            var cultureCodes = new[] {"fr-FR", "nl-BE", "xx-XX"};
            foreach (var cultureCode in cultureCodes)
            {
                Console.WriteLine(cultureCode);
                Console.WriteLine("--------------------------");
                foreach (var product in productRepository.GetAll(cultureCode))
                {
                    PrintProperties(product);
                }
            }

            Console.ReadKey();
        }
    }
}
