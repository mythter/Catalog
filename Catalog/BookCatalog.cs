using BookCatalog.TreeViewHelper;
using Newtonsoft.Json.Bson;
using System.Drawing.Text;

namespace BookCatalog
{
    public class BookCatalog : Catalog
    {
        #region Constructors

        public BookCatalog()
        {
            Root = new EBookSection("root");
        }

        public BookCatalog(Section section)
        {
            Root = new EBookSection("root")
            {
                ChildSections = new List<Section> { section }
            };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method to add all catalog items to <paramref name="treeView"/> object
        /// </summary>
        /// <param name="treeView"> The object where need to add catalog items </param>
        public void AddNodesToTreeView(TreeView treeView)
        {
            Root.ChildSections.ForEach(r => treeView.Nodes.Add(new SectionNode(r)));
        } 

        #endregion
    }
}
