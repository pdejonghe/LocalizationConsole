using System.Collections.Generic;

namespace Models.Foundation
{
    /// <summary>
    /// Interface for a localizable entity repository.
    /// </summary>
    /// <typeparam name="TLocalizableEntity">Base class of entities that contain localizable properties <see cref="ILocalizableEntity{TLocalizedEntity,TLocalizablePropertySet}"/>.</typeparam>
    /// <typeparam name="TLocalizablePropertySet">An abstract localizable property set that groups the localizable (translatable) properties of the master entity. Implements <see cref="ILocalizedPropertySet"/></typeparam>
    /// <typeparam name="TLocalizedEntity">The localized entity</typeparam>
    public interface ILocalizableEntityRepository<in TLocalizableEntity, TLocalizablePropertySet, out TLocalizedEntity>
        where TLocalizableEntity : ILocalizableEntity<TLocalizedEntity, TLocalizablePropertySet>
        where TLocalizablePropertySet : ILocalizedPropertySet
    {
        /// <summary>
        /// Adds an entity, together with its localized property set.
        /// </summary>
        /// <param name="entity">The master entity</param>
        void Add(TLocalizableEntity entity);

        /// <summary>
        /// Gets all localized entities for the given culture code.
        /// </summary>
        /// <param name="cultureCode">The culture code <see cref="System.Globalization.CultureInfo"/></param>
        /// <returns></returns>
        IEnumerable<TLocalizedEntity> GetAll(string cultureCode);

        /// <summary>
        /// Gets a single localized entity.
        /// </summary>
        /// <param name="id">The unique identifier of the localized entity to fetch.</param>
        /// <param name="cultureCode">The culture code <see cref="System.Globalization.CultureInfo"/></param>
        /// <returns>The appropriately localized entity</returns>
        TLocalizedEntity Get(int id, string cultureCode);
    }
}
