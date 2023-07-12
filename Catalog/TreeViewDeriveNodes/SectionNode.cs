namespace BookCatalog.TreeViewHelper
{
    public class SectionNode : TreeNode
    {
        public Section Section { get; private set; }

        public SectionNode(Section section)
        {
            this.Text = section.Name;
            this.Section = section;
            this.Section?.ChildSections?.ForEach(x => this.Nodes.Add(new SectionNode(x)));
            this.Section?.Elements?.ForEach(x => this.Nodes.Add(new ElementNode(x)));
        }
    }
}