using System.Collections.Generic;

namespace Models
{
    public interface ILocalizableEntityRepository<in TLocalizableEntity, TLocalizablePropertySet, out TLocalizedEntity>
        where TLocalizableEntity : ILocalizableEntity<TLocalizedEntity, TLocalizablePropertySet>
        where TLocalizablePropertySet : ILocalizablePropertySet
    {
        void Add(TLocalizableEntity entity);
        IEnumerable<TLocalizedEntity> GetAll(string cultureCode);
        TLocalizedEntity Get(int Id, string cultureCode);
    }
}
