using System.Collections.Generic;

namespace Models
{
    public interface ILocalizableEntityRepository<in TLocalizableEntity, TLocalizableContent, out TLocalizedEntity>
        where TLocalizableEntity : ILocalizableEntity<TLocalizedEntity, TLocalizableContent>
        where TLocalizableContent : ILocalizableContent
    {
        void Add(TLocalizableEntity entity);
        IEnumerable<TLocalizedEntity> GetAll(string cultureCode);
        TLocalizedEntity Get(int Id, string cultureCode);
    }
}
