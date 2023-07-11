using Newtonsoft.Json;
using System.Xml.Linq;

namespace BookCatalog
{
    public class Catalog
    {
        #region Properties

        /// <summary>
        /// Property that contains all catalog items.
        /// </summary>
        [JsonProperty]
        protected Section Root { get; set; }

        #endregion

        #region Constructors

        public Catalog()
        {
            Root = new Section("root");
        }

        public Catalog(Section section)
        {
            Root = new Section("root")
            {
                ChildSections = new List<Section> { section }
            };
        }

        #endregion

        /// <summary>
        /// Method to add subsection to root section.
        /// </summary>
        /// <param name="section"> Section to add. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="section"/> is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when <paramref name="section"/> with the same name has already been added to <see cref="ChildSections"/> list </exception>
        public void AddSection(Section section)
        {
            Root.AddSection(section);
        }

        /// <summary>
        /// Method to remove subsection from root section.
        /// </summary>
        /// <param name="section"> Section to remove. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="section"/> is null. </exception>
        /// <returns> <see langword="true"/> if section successfully removed from catalog; otherwise <see langword="false"/> </returns>
        public bool RemoveSection(Section section)
        {
            return Root.RemoveSection(section);
        }

        /// <summary>
        /// Method to remove element from subsections of root section.
        /// </summary>
        /// <param name="element"> Element to remove. </param>
        /// <exception cref="ArgumentNullException"> Thrown when <paramref name="element"/> is null. </exception>
        /// <returns> <see langword="true"/> if element successfully removed from catalog; otherwise <see langword="false"/> </returns>
        public bool RemoveElement(Element element)
        {
            return Root.RemoveElement(element);
        }

        /// <summary>
        /// Method to check if section with specific name exists in catalog
        /// </summary>
        /// <param name="sectionName"> Section name to search </param>
        /// <returns> <see langword="true"/> if section exists in catalog; otherwise <see langword="false"/> </returns>
        public bool SectionExists(string sectionName)
        {
            return Root.ChildSections.Exists(s => s.Name == sectionName);
        }
    }
}