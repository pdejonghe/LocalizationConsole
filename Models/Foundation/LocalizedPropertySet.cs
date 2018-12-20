namespace Models.Foundation
{
    /// <summary>
    /// An abstract localizable property set that groups the localizable (translatable) properties of the master entity.
    /// Implements <see cref="ILocalizedPropertySet"/>
    /// </summary>
    public abstract class LocalizedPropertySet : ILocalizedPropertySet
    {
        /// <summary>
        /// The culture code used for localization <see cref="System.Globalization.CultureInfo"/>
        /// </summary>
        public string CultureCode { get; set; }
    }
}
