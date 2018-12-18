using System;
using System.Collections.Generic;
using System.Text;

namespace Models.EF
{
    /// <summary>
    /// Product is merged with LocalizableProduct to generate a LocalizedProduct. Refer to LocalizableEntityRepository to see this happen.
    /// </summary>
    public class ProductRepository : LocalizableEntityRepository<Product, LocalizableProduct, LocalizedProduct>
    {
        public ProductRepository(LocalizationDbContext context) : base(context) { }
    }
}
