namespace BookCatalog
{
    public abstract class Element
    {
        public Section? ParentSection { get; set; }
        public string Name { get; set; }

        protected Element(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument must not be null or empty", nameof(name));
            }

            Name = name;
        }
    }
}