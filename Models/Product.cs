using System;
using System.Linq;
using Models.Foundation;

namespace Models
{
    public class Product : LocalizableEntity<LocalizedProduct, LocalizedProductPropertySet>
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public override LocalizedProduct GetLocalizedEntity(string cultureCode)
        {
            var localizedProduct = Activator.CreateInstance<LocalizedProduct>();
            var localizedProductPropertySet = LocalizedPropertySets.FirstOrDefault(p => p.CultureCode == cultureCode)
                                        ?? LocalizedPropertySets.FirstOrDefault(p => p.CultureCode == "en-US")
                                        ?? LocalizedPropertySets.FirstOrDefault();

            localizedProduct.Id = this.Id;
            localizedProduct.Price = this.Price;

            if (null != localizedProductPropertySet)
            {
                localizedProduct.Name = localizedProductPropertySet.Name;
                localizedProduct.Description = localizedProductPropertySet.Description;
            }

            return localizedProduct;
        }
    }
}
