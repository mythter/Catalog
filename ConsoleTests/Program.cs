using BookCatalog;

namespace ConsoleTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookCatalog.BookCatalog catalog = new();

            catalog._root.AddSection(new EBookSection("Section 1"));
            catalog._root.AddSection(new EBookSection("Section 2"));
            catalog._root.AddSection(new EBookSection("Section 3"));

            catalog._root.ChildSections[0].AddSection(new EBookSection("Section 4"));
            catalog._root.ChildSections[0].AddSection(new EBookSection("Section 5"));
            var book = new EBook("Good book", "Good author");
            catalog._root.ChildSections[0].ChildSections![0].AddElement(book);
            catalog._root.ChildSections[0].ChildSections![0].AddElement(new EBook($"Book 14"));
            catalog._root.ChildSections[0].ChildSections![0].AddSection(new EBookSection($"Section 6"));
            catalog._root.ChildSections[0].ChildSections![0].ChildSections![0].AddSection(new EBookSection($"Section 7"));
            catalog._root.ChildSections[0].ChildSections![0].ChildSections![0].AddElement(new EBook($"Book 123"));
            catalog._root.ChildSections[0].ChildSections![0].ChildSections![0].AddElement(new EBook($"Book 345"));
            catalog._root.ChildSections[0].ChildSections![0].ChildSections![0].AddElement(new EBook($"Book 563"));

            int i = 1;
            foreach(var sec in catalog._root.ChildSections)
            {
                sec.AddElement(new EBook($"Book {i++}"));
                sec.AddElement(new EBook($"Book {i++}"));
                sec.AddElement(new EBook($"Book {i++}"));
            }
        }
    }
}