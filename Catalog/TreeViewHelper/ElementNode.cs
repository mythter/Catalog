namespace BookCatalog.TreeViewHelper
{
    public class ElementNode : TreeNode
    {
        public Element Element { get; private set; }

        public ElementNode(Element element)
        {
            this.Text = element.Name;
            this.Element = element;
        }
    }
}
