using System;
using System.Linq;
using Models.Foundation;

namespace Models
{
    public class Product : LocalizableEntity<LocalizedProduct, LocalizableProductPropertySet>
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public override LocalizedProduct GetLocalizedEntity(string cultureCode)
        {
            var localizedProduct = Activator.CreateInstance<LocalizedProduct>();
            var localizableProduct = LocalizablePropertySets.FirstOrDefault(p => p.CultureCode == cultureCode)
                                        ?? LocalizablePropertySets.FirstOrDefault(p => p.CultureCode == "en-US")
                                        ?? LocalizablePropertySets.FirstOrDefault();

            localizedProduct.Id = this.Id;
            localizedProduct.Price = this.Price;

            if (null != localizableProduct)
            {
                localizedProduct.Name = localizableProduct.Name;
                localizedProduct.Description = localizableProduct.Description;
            }

            return localizedProduct;
        }
    }
}
