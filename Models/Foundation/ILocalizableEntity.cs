using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public interface ILocalizableEntity<out TTranslatedEntity, TLocalizableContent> where TLocalizableContent : ILocalizableContent
    {
        ICollection<TLocalizableContent> LocalizableContents { get; set; }
        TTranslatedEntity GetTranslatedEntity(string cultureCode);
    }
}
