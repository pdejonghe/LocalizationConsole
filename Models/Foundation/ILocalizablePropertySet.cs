namespace Models.Foundation
{
    /// <summary>
    /// An implementation of ILocalizablePropertySet groups the localizable (translatable) properties of the master entity.
    /// </summary>
    public interface ILocalizablePropertySet
    {
        /// <summary>
        /// The culture code used for localization <see cref="System.Globalization.CultureInfo"/>
        /// </summary>
        string CultureCode { get; set; }
    }
}
