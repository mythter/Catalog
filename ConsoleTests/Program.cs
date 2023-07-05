using BookCatalog;

namespace ConsoleTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookCatalog.BookCatalog catalog = new BookCatalog.BookCatalog();

            catalog.Add(new EBookSection("Section 1"));
            catalog.Add(new EBookSection("Section 2"));
            catalog.Add(new EBookSection("Section 3"));

            catalog.RootItems[0].AddSection(new EBookSection("Section 4"));
            catalog.RootItems[0].AddSection(new EBookSection("Section 5"));
            var book = new EBook("Good book", "Good author");
            catalog.RootItems[0].ChildSections![0].AddElement(book);
            catalog.RootItems[0].ChildSections![0].AddElement(new EBook($"Book 14"));
            catalog.RootItems[0].ChildSections![0].AddSection(new EBookSection($"Section 6"));
            catalog.RootItems[0].ChildSections![0].ChildSections![0].AddSection(new EBookSection($"Section 7"));
            catalog.RootItems[0].ChildSections![0].ChildSections![0].AddElement(new EBook($"Book 123"));
            catalog.RootItems[0].ChildSections![0].ChildSections![0].AddElement(new EBook($"Book 345"));
            catalog.RootItems[0].ChildSections![0].ChildSections![0].AddElement(new EBook($"Book 563"));

            int i = 1;
            foreach(var sec in catalog.RootItems)
            {
                sec.AddElement(new EBook($"Book {i++}"));
                sec.AddElement(new EBook($"Book {i++}"));
                sec.AddElement(new EBook($"Book {i++}"));
            }

            catalog.PrintCatalogTree();
        }
    }
}