namespace Models
{
    public abstract class LocalizablePropertySet : ILocalizablePropertySet
    {
        public string CultureCode { get; set; }
    }
}
