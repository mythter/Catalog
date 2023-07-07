namespace BookCatalog
{
    public class BookCatalog : Catalog
    {
        #region Constructors

        public BookCatalog()
        {
            Root = new EBookSection("root");
        }

        public BookCatalog(Section section)
        {
            Root = new EBookSection("root");
            Root.ChildSections = new List<Section> { section };
        }

        #endregion
    }
}
