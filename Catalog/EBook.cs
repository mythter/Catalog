namespace BookCatalog
{
    public class EBook : Element
    {
        #region Properties
        public string Title { get; set; }
        public string? Author { get; set; }
        public int? Year { get; set; }
        public string? Path { get; set; }

        #endregion

        #region Constructors

        public EBook(string title, string? author = null, int? year = null, string? path = null) : base(title)
        {
            if (title is null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            Title = title;
            Author = author;
            Year = year;
            Path = path;
            Name = Author is null ? Title : $"{Author} - {Title}";
        }

        #endregion
    }
}