using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public interface ILocalizableEntity<out TLocalizedEntity, TLocalizableContent> where TLocalizableContent : ILocalizableContent
    {
        ICollection<TLocalizableContent> LocalizableContents { get; set; }
        TLocalizedEntity GetLocalizedEntity(string cultureCode);
    }
}
