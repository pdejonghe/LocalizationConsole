using System;
using System.Linq;

namespace Models
{
    public class Product : LocalizableEntity<LocalizedProduct, LocalizableProduct>
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public override LocalizedProduct GetTranslatedEntity(string cultureCode)
        {
            var translatedEntity = Activator.CreateInstance<LocalizedProduct>();
            var localizableProduct = LocalizableContents.FirstOrDefault(p => p.CultureCode == cultureCode)
                                        ?? LocalizableContents.FirstOrDefault(p => p.CultureCode == "en-US")
                                        ?? LocalizableContents.FirstOrDefault();

            translatedEntity.Id = this.Id;
            translatedEntity.Price = this.Price;

            if (null != localizableProduct)
            {
                translatedEntity.Name = localizableProduct.Name;
                translatedEntity.Description = localizableProduct.Description;
            }

            return translatedEntity;
        }
    }
}
