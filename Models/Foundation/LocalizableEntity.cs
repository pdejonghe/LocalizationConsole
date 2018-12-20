using System.Collections.Generic;

namespace Models
{
    public abstract class LocalizableEntity<TLocalizedEntity, TLocalizablePropertySet> : ILocalizableEntity<TLocalizedEntity, TLocalizablePropertySet> 
        where TLocalizablePropertySet : ILocalizablePropertySet
    {
        public ICollection<TLocalizablePropertySet> LocalizablePropertySets { get; set; }
        public abstract TLocalizedEntity GetLocalizedEntity(string cultureCode);
    }
}
