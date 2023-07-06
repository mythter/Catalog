namespace BookCatalog
{
    public class Catalog
    {
        #region Properties

        /// <summary>
        /// List of all catalog items.
        /// </summary>
        public Section Root { get; set; }

        #endregion

        #region Constructors

        public Catalog()
        {
            Root = new Section("root");
        }

        public Catalog(Section section)
        {
            Root = new Section("root");
            Root.ChildSections = new List<Section> { section };
        }

        #endregion
    }
}