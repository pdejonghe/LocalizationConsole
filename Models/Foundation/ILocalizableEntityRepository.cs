using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public interface ILocalizableEntityRepository<in TEntity, TLocalizableContent, out TTranslatedEntity>
        where TEntity : ILocalizableEntity<TTranslatedEntity, TLocalizableContent>
        where TLocalizableContent : ILocalizableContent
    {
        void Add(TEntity entity);
        IEnumerable<TTranslatedEntity> GetAll(string cultureCode);
        TTranslatedEntity Get(int Id, string cultureCode);
    }
}
