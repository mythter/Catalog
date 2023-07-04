namespace BookCatalog
{
    public abstract class Section
    {
        #region Properties

        public List<Section>? ChildSections { get; set; }
        public Section? ParentSection { get; set; }
        public List<Element>? Elements { get; set; }
        public string Name { get; set; }

        #endregion

        #region Constructors

        protected Section(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument must not be null or empty", nameof(name));
            }

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

            if (ChildSections is null)
            {
                ChildSections = new List<Section>() { };
            }

            if (ChildSections.Contains(section, new SectionComparer()))
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
        public void RemoveSection(Section section)
        {
            if (section is null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            if (ChildSections is null)
            {
                ChildSections = new List<Section>() { };
            }

            if (ChildSections.Contains(section))
            {
                ChildSections.Remove(section);
            }
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

            if (ChildSections is null)
            {
                ChildSections = new List<Section>() { };
            }

            foreach (var section in ChildSections)
            {
                if (section.Name == sectionName)
                {
                    ChildSections.Remove(section);
                    break;
                }
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

            if (Elements is null)
            {
                Elements = new List<Element>() { };
            }

            if (Elements.Contains(element, new ElementComparer()))
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
        public void RemoveElement(Element element)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (Elements is null)
            {
                Elements = new List<Element>() { };
            }

            if (Elements.Contains(element))
            {
                Elements.Remove(element);
            }
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

            if (Elements is null)
            {
                Elements = new List<Element>() { };
            }

            foreach (var element in Elements)
            {
                if (element.Name == elementName)
                {
                    Elements.Remove(element);
                    break;
                }
            }
        }

        #endregion
    }
}