namespace BookCatalog
{
    public class Catalog
    {
        #region Properties

        /// <summary>
        /// List of all catalog items.
        /// </summary>
        public List<Section> RootItems { get; set; }

        #endregion

        #region Constructors

        public Catalog()
        {
            RootItems = new List<Section>();
        }

        public Catalog(Section section)
        {
            RootItems = new List<Section>() { section };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method to add section to catalog.
        /// </summary>
        /// <param name="section"> Section to add. </param>
        /// <exception cref="ArgumentNullException"> Throws when <paramref name="section"/> is null. </exception>
        public void Add(Section section)
        {
            if (section is null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            if (RootItems.Exists(s => s.Name == section.Name))
            {
                throw new ArgumentException("Subsection with such name has already exist in the current section.", nameof(section));
            }

            RootItems.Add(section);
        }

        /// <summary>
        /// Method to remove section from catalog.
        /// </summary>
        /// <param name="section"> Section to remove. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="section"/> is null. </exception>
        public bool Remove(Section section)
        {
            if (section is null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            if (RootItems.Remove(section))
            {
                return true;
            }

            foreach (var s in RootItems)
            {
                if (s.ChildSections.Remove(section))
                {
                    section.ParentSection = null;
                    return true;
                }
                s.RemoveSection(section);
            }

            return false;
        }

        /// <summary>
        /// Method to remove section by name from catalog.
        /// </summary>
        /// <param name="sectionName"> Name of the section to remove. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="sectionName"/> is null. </exception>
        public void Remove(string sectionName)
        {
            if (sectionName is null)
            {
                throw new ArgumentNullException(nameof(sectionName));
            }

            var sectionToRemove = RootItems.Find(x => x.Name == sectionName);

            if (sectionToRemove is not null)
            {
                RootItems.Remove(sectionToRemove);
            }
        }

        public bool RemoveElementFromRootItems(Element element)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            foreach (var s in RootItems)
            {
                if (s.Elements.Remove(element))
                {
                    element.ParentSection = null;
                    return true;
                }
                s.RemoveElement(element);
            }

            return false;
        }

        public void PrintCatalogTree()
        {
            foreach (var section in RootItems)
            {
                Console.WriteLine(section.Name);
                PrintSection(section, 1);
            }
        }

        private void PrintSection(Section section, int depth)
        {
            if (section.ChildSections is not null)
            {
                foreach (var s in section.ChildSections)
                {
                    Console.WriteLine(new string(' ', depth * 2) + '-' + s.Name);
                    PrintSection(s, depth + 1);
                }
            }

            if (section.Elements is not null)
            {
                foreach (var element in section.Elements)
                {
                    Console.WriteLine(new string(' ', depth * 2) + '-' + element.Name);
                }
            }
        }

        #endregion
    }
}