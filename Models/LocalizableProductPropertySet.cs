using Models.Foundation;

namespace Models
{
    /// <summary>
    /// The localizable property set of a Product.
    /// Inherits from <see cref="LocalizablePropertySet"/>
    /// </summary>
    public class LocalizableProductPropertySet : LocalizablePropertySet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
