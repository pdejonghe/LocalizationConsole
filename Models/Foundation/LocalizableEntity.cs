using System.Collections.Generic;

namespace Models.Foundation
{
    /// <summary>
    /// Base class of entities that contain localizable properties.
    /// </summary>
    /// <typeparam name="TLocalizedEntity">The full entity that contains the correctly localized property set</typeparam>
    /// <typeparam name="TLocalizablePropertySet">The localizable property set</typeparam>
    public abstract class LocalizableEntity<TLocalizedEntity, TLocalizablePropertySet> : ILocalizableEntity<TLocalizedEntity, TLocalizablePropertySet> 
        where TLocalizablePropertySet : ILocalizedPropertySet
    {
        /// <summary>
        /// All localized property sets for the master entity.
        /// </summary>
        public ICollection<TLocalizablePropertySet> LocalizablePropertySets { get; set; }

        /// <summary>
        /// Method that merges the master entity with the appropriate localizable property set (based on the passed in cultureCode).
        /// </summary>
        /// <param name="cultureCode">The culture code used for the localization <see cref="System.Globalization.CultureInfo"/></param>
        /// <returns>An entity, localized with the passed in cultureCode</returns>
        public abstract TLocalizedEntity GetLocalizedEntity(string cultureCode);
    }
}
