namespace Models.EF
{
    /// <summary>
    /// Product is merged with LocalizableProductPropertySet to generate a LocalizedProduct. Refer to LocalizableEntityRepository to see this happen.
    /// </summary>
    public class ProductRepository : LocalizableEntityRepository<Product, LocalizableProductPropertySet, LocalizedProduct>
    {
        public ProductRepository(LocalizationDbContext context) : base(context) { }
    }
}
