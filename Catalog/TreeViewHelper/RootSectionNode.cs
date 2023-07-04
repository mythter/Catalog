namespace BookCatalog.TreeViewHelper
{
    public class RootSectionNode : TreeNode
    {
        public Catalog Catalog { get; private set; }

        public RootSectionNode(Catalog catalog)
        {
            this.Text = catalog.ToString();
            this.Catalog = catalog;
            this.Catalog?.RootItems?.ForEach(x => this.Nodes.Add(new SectionNode(x)));
        }
    }
}
