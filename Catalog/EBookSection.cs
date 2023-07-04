namespace BookCatalog
{
    public class EBookSection : Section
    {
        public string? Theme { get; set; }

        #region Constructors

        public EBookSection(string name) : base(name) { }

        public EBookSection(string name, string? theme) : base(name)
        {
            Theme = theme;
        }

        #endregion
    }
}
