namespace Models
{
    public abstract class LocalizableContent : ILocalizableContent
    {
        public string CultureCode { get; set; }
    }
}
