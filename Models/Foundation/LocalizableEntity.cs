using System.Collections.Generic;

namespace Models
{
    public abstract class LocalizableEntity<TTranslatedEntity, TLocalizableContent> : ILocalizableEntity<TTranslatedEntity, TLocalizableContent> 
        where TLocalizableContent : ILocalizableContent
    {
        public ICollection<TLocalizableContent> LocalizableContents { get; set; }
        public abstract TTranslatedEntity GetTranslatedEntity(string cultureCode);
    }
}
