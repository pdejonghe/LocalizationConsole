using Microsoft.EntityFrameworkCore;
using Models.EF.Foundation;

namespace Models.EF
{
    /// <summary>
    /// Product is merged with LocalizedProductPropertySet to generate a LocalizedProduct. Refer to <see cref="LocalizableEntityRepository{TEntity,TLocalizableContent,TTranslatedEntity}"/> to see this happen.
    /// </summary>
    public class ProductRepository : LocalizableEntityRepository<Product, LocalizedProductPropertySet, LocalizedProduct>
    {
        public ProductRepository(DbContext context) : base(context) { }
    }
}
