using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Models.EF
{
    public abstract class LocalizableEntityRepository<TEntity, TLocalizableContent, TTranslatedEntity>
        where TEntity : class, ILocalizableEntity<TTranslatedEntity, TLocalizableContent>
        where TLocalizableContent : class, ILocalizablePropertySet
    {
        private DbContext Context { get; }

        protected LocalizableEntityRepository(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Adds an object of type TEntity to the repository.
        /// Note that TEntity is a ILocalizableEntity, and hence contains a collection of ILocalizablePropertySet instances.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        /// <summary>
        /// TEntity is merged with TLocalizableContent to produce a localized entity (of type TTranslatedEntity). The magic happens in the
        /// override of GetTranslatedEntity of the TEntity class.
        /// TLocalizedContent instances are fetched with the Include method.
        /// </summary>
        /// <param name="cultureCode">The ISO code of the culture</param>
        /// <returns>A list of localized entities</returns>
        public IEnumerable<TTranslatedEntity> GetAll(string cultureCode)
        {
            return Context.Set<TEntity>().Include(entity => entity.LocalizablePropertySets).ToList().Select(entity => entity.GetLocalizedEntity(cultureCode));
        }

        /// <summary>
        /// TEntity is merged with TLocalizableContent to produce a localized entity (of type TTranslatedEntity). The magic happens in the
        /// override of GetTranslatedEntity of the TEntity class.
        /// TLocalizedContent instances are fetched with the Load method.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cultureCode">The ISO code of the culture</param>
        /// <returns>A localized entity</returns>
        public TTranslatedEntity Get(int id, string cultureCode)
        {
            var entity = Context.Set<TEntity>().Find(id);
            Context.Entry(entity).Collection(e => e.LocalizablePropertySets).Load();
            return entity.GetLocalizedEntity(cultureCode);
        }
    }
}
