using System.Collections.Generic;

namespace Models
{
    public interface ILocalizableEntity<out TLocalizedEntity, TLocalizablePropertySet> where TLocalizablePropertySet : ILocalizablePropertySet
    {
        ICollection<TLocalizablePropertySet> LocalizablePropertySets { get; set; }
        TLocalizedEntity GetLocalizedEntity(string cultureCode);
    }
}
