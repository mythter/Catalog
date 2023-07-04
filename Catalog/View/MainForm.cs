using BookCatalog.TreeViewHelper;

namespace BookCatalog
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Catalog catalog = new Catalog();

            catalog.Add(new EBookSection("Section 1"));
            catalog.Add(new EBookSection("Section 2"));
            catalog.Add(new EBookSection("Section 3"));

            catalog.RootItems[0].AddSection(new EBookSection("Section 4"));
            catalog.RootItems[0].AddSection(new EBookSection("Section 5"));
            var book = new EBook("Good book", "Good author");
            catalog.RootItems[0].ChildSections![0].AddElement(book);
            catalog.RootItems[0].ChildSections![0].AddElement(new EBook($"Book 14"));
            catalog.RootItems[0].ChildSections![0].AddSection(new EBookSection($"Section 6"));
            catalog.RootItems[0].ChildSections![0].ChildSections![0].AddSection(new EBookSection($"Section 7"));
            catalog.RootItems[0].ChildSections![0].ChildSections![0].AddElement(new EBook($"Book 123"));
            catalog.RootItems[0].ChildSections![0].ChildSections![0].AddElement(new EBook($"Book 345"));
            catalog.RootItems[0].ChildSections![0].ChildSections![0].AddElement(new EBook($"Book 563"));

            catalog.RootItems.ForEach(r => treeView.Nodes.Add(new SectionNode(r)));

            this.treeView.ItemDrag += new ItemDragEventHandler(treeView_ItemDrag);
            this.treeView.DragDrop += new DragEventHandler(treeView_DragDrop);
            this.treeView.DragEnter += new DragEventHandler(treeView_DragEnter);
        }

        private TreeNode _selectedNode;

        private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
            _selectedNode = (TreeNode)e.Item;
        }
        private void treeView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode sourceNode = _selectedNode;
            if (sourceNode != null /*&& e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false)*/)
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode destinationNode = ((TreeView)sender).GetNodeAt(pt);
                if (destinationNode != null)
                {
                    //ur target
                    ((TreeView)sender).Nodes.Remove(sourceNode);

                    destinationNode.Nodes.Add(sourceNode);
                }
            }
        }
    }
}