using BookCatalog;

namespace ConsoleTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookCatalog.BookCatalog catalog = new();

            catalog.Root.AddSection(new EBookSection("Section 1"));
            catalog.Root.AddSection(new EBookSection("Section 2"));
            catalog.Root.AddSection(new EBookSection("Section 3"));

            catalog.Root.ChildSections[0].AddSection(new EBookSection("Section 4"));
            catalog.Root.ChildSections[0].AddSection(new EBookSection("Section 5"));
            var book = new EBook("Good book", "Good author");
            catalog.Root.ChildSections[0].ChildSections![0].AddElement(book);
            catalog.Root.ChildSections[0].ChildSections![0].AddElement(new EBook($"Book 14"));
            catalog.Root.ChildSections[0].ChildSections![0].AddSection(new EBookSection($"Section 6"));
            catalog.Root.ChildSections[0].ChildSections![0].ChildSections![0].AddSection(new EBookSection($"Section 7"));
            catalog.Root.ChildSections[0].ChildSections![0].ChildSections![0].AddElement(new EBook($"Book 123"));
            catalog.Root.ChildSections[0].ChildSections![0].ChildSections![0].AddElement(new EBook($"Book 345"));
            catalog.Root.ChildSections[0].ChildSections![0].ChildSections![0].AddElement(new EBook($"Book 563"));

            int i = 1;
            foreach(var sec in catalog.Root.ChildSections)
            {
                sec.AddElement(new EBook($"Book {i++}"));
                sec.AddElement(new EBook($"Book {i++}"));
                sec.AddElement(new EBook($"Book {i++}"));
            }
        }
    }
}