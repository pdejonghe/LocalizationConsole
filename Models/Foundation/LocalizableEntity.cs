using System.Collections.Generic;

namespace Models
{
    public abstract class LocalizableEntity<TLocalizedEntity, TLocalizableContent> : ILocalizableEntity<TLocalizedEntity, TLocalizableContent> 
        where TLocalizableContent : ILocalizableContent
    {
        public ICollection<TLocalizableContent> LocalizableContents { get; set; }
        public abstract TLocalizedEntity GetLocalizedEntity(string cultureCode);
    }
}
