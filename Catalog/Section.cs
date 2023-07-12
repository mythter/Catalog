namespace BookCatalog
{
    public class Section
    {
        #region Properties

        public List<Section> ChildSections { get; set; }
        public Section? ParentSection { get; set; }
        public List<Element> Elements { get; set; }
        public string Name { get; set; }

        #endregion

        #region Constructors

        public Section(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument must not be null or empty", nameof(name));
            }

            ChildSections = new List<Section>();
            Elements = new List<Element>();

            Name = name;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method to add subsection to current section.
        /// </summary>
        /// <param name="section"> Section to add. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="section"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="section"/> with the same name has already been added to <see cref="ChildSections"/> list </exception>
        public void AddSection(Section section)
        {
            if (section is null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            if (ChildSections.Exists(s => s.Name == section.Name))
            {
                throw new ArgumentException("Subsection with the same name has already exist in the current section.", nameof(section));
            }

            ChildSections.Add(section);

            section.ParentSection = this;
        }

        /// <summary>
        /// Method to remove subsection from current section.
        /// </summary>
        /// <param name="section"> Section to remove. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="section"/> is null. </exception>
        public bool RemoveSection(Section section)
        {
            if (section is null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            if (ChildSections.Remove(section))
            {
                section.ParentSection = null;
                return true;
            }

            foreach (var s in ChildSections)
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
        /// Method to remove subsection by name from current section.
        /// </summary>
        /// <param name="sectionName"> Name of the subsection to remove. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="sectionName"/> is null. </exception>
        public void RemoveSection(string sectionName)
        {
            if (sectionName is null)
            {
                throw new ArgumentNullException(nameof(sectionName));
            }

            var sectionToRemove = ChildSections.Find(x => x.Name == sectionName);

            if (sectionToRemove is not null)
            {
                ChildSections.Remove(sectionToRemove);
            }
        }

        /// <summary>
        /// Method to add element to current section.
        /// </summary>
        /// <param name="element"> Element to add. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="element"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="element"/> with the same name has already been added to <see cref="ChildSections"/> list </exception>
        public void AddElement(Element element)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (Elements.Exists(e => e.Name == element.Name))
            {
                throw new ArgumentException("Element with the same name has already exist in the current section.", nameof(element));
            }

            Elements.Add(element);
            element.ParentSection = this;
        }

        /// <summary>
        /// Method to remove element from current section.
        /// </summary>
        /// <param name="element"> Element to remove. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="element"/> is null. </exception>
        public bool RemoveElement(Element element)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (Elements.Remove(element))
            {
                element.ParentSection = null;
                return true;
            }

            foreach (var s in ChildSections)
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

        /// <summary>
        /// Method to remove element by name from current section.
        /// </summary>
        /// <param name="elementName"> Name of the element to remove. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="elementName"/> is null. </exception>
        public void RemoveElement(string elementName)
        {
            if (elementName is null)
            {
                throw new ArgumentNullException(nameof(elementName));
            }

            var elementToRemove = ChildSections.Find(x => x.Name == elementName);

            if (elementToRemove is not null)
            {
                ChildSections.Remove(elementToRemove);
            }
        }

        /// <summary>
        /// Method that recursively searches for subsection in current section.
        /// </summary>
        /// <param name="section"> section to search </param>
        /// <returns> <see langword="true"/> if section contains given child; otherwise <see langword="false"/> </returns>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="section"/> is null. </exception>
        public bool ContainsChild(Section section)
        {
            if (section is null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            if (ChildSections.Contains(section))
            {
                return true;
            }

            foreach (var s in ChildSections)
            {
                if (s.ChildSections.Contains(section))
                {
                    return true;
                }
                s.ContainsChild(section);
            }

            return false;
        }

        /// <summary>
        /// Method to check if subsection with specific name exists in current section
        /// </summary>
        /// <param name="sectionName"> Section name to search </param>
        /// <returns> <see langword="true"/> if subsection exists in current section; otherwise <see langword="false"/> </returns>
        public bool SectionExists(string sectionName)
        {
            return ChildSections.Exists(s => s.Name == sectionName);
        }

        /// <summary>
        /// Method to check if element with specific name exists in current section
        /// </summary>
        /// <param name="elementName"> Element name to search </param>
        /// <returns> <see langword="true"/> if element exists in current section; otherwise <see langword="false"/> </returns>
        public bool ElementExists(string elementName)
        {
            return Elements.Exists(e => e.Name == elementName);
        }

        #endregion
    }
}