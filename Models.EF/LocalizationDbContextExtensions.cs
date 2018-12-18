using Models;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.EF
{
    public static class LocalizationDbContextExtensions
    {
        public static void Seed(this LocalizationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Products.Add
            (
                new Models.Product
                {
                    Price = 12.5m,
                    LocalizableContents = new List<LocalizableProduct>
                    {
                        new LocalizableProduct
                        {
                            CultureCode = "en-US",
                            Name = "Screwdriver",
                            Description = "A nice tool to put screws into all kinds of material"
                        },
                        new LocalizableProduct
                        {
                            CultureCode = "fr-FR",
                            Name = "Tournevis",
                            Description = "Outil pour tourner les vis, tige d'acier emmanchée, aplatie ou cruciforme à son extrémité."
                        }
                    }
                }
            );

            context.Products.Add
            (
                new Models.Product
                {
                    Price = 20.05m,
                    LocalizableContents = new List<LocalizableProduct>
                    {
                        new LocalizableProduct
                        {
                            CultureCode = "en-US",
                            Name = "Hammer",
                            Description = "Nails, watch out!"
                        },
                        new LocalizableProduct
                        {
                            CultureCode = "fr-FR",
                            Name = "Marteau",
                            Description = "Clous, faites attention!"
                        }
                    }
                }
            );

            context.Products.Add
            (
                new Models.Product
                {
                    Price = 7.45m,
                    LocalizableContents = new List<LocalizableProduct>
                    {
                        new LocalizableProduct
                        {
                            CultureCode = "es-ES",
                            Name = "Vio",
                            Description = "Bueno para hacer estantes en dos"
                        },
                        new LocalizableProduct
                        {
                            CultureCode = "nl-BE",
                            Name = "Zaag",
                            Description = "Goed om planken in twee te doen"
                        }
                    }
                }
            );

            context.SaveChanges();
        }
    }
}
