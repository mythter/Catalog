using BookCatalog.TreeViewHelper;
using System.Windows.Forms;

namespace BookCatalog
{
    public class Presenter
    {
        private readonly IView form;
        private TreeNode _nodeToMove;
        private TreeNode _selectedNode;

        public Presenter(IView form)
        {
            this.form = form;

            form.TreeViewItemDrag += TreeViewItemDrag;
            form.TreeViewDragEnter += TreeViewDragEnter;
            form.TreeViewDragDrop += TreeViewDragDrop;
            form.TreeNodeMouseHover += TreeNodeMouseHover;

            form.ShowAttributes += ShowAttributes;

            form.OpenFile += OpenFile;
        }

        public void TreeViewItemDrag(object sender, ItemDragEventArgs e)
        {
            _nodeToMove = (TreeNode)e.Item;
        }

        public void TreeViewDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void TreeViewDragDrop(object sender, DragEventArgs e)
        {
            TreeNode sourceNode = _nodeToMove;

            if (sourceNode != null)
            {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode destinationNode = ((TreeView)sender).GetNodeAt(pt);


                if (destinationNode is not null && destinationNode is not ElementNode)
                {
                    ((TreeView)sender).Nodes.Remove(sourceNode);
                    destinationNode.Nodes.Add(sourceNode);

                    form.CatalogTree.SelectedNode = sourceNode;
                }

                if (sourceNode is SectionNode sectionNode && destinationNode is null)
                {
                    ((TreeView)sender).Nodes.Remove(sectionNode);
                    form.CatalogTree.Nodes.Add(sectionNode);

                    form.CatalogTree.SelectedNode = sectionNode;
                }
            }
        }

        private void TreeNodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            _nodeToMove = e.Node;
        }

        private void ShowAttributes(object sender, TreeNodeMouseClickEventArgs e)
        {
            _selectedNode = e.Node;
            if (_selectedNode is SectionNode sectionNode)
            {
                var section = sectionNode.Section;

                if (section is EBookSection ebookSection)
                {
                    form.AttributesDataGrid.Columns.Clear();
                    form.AttributesDataGrid.ColumnCount = 2;
                    form.AttributesDataGrid.Columns[0].Width =
                    form.AttributesDataGrid.Columns[1].Width = 178;

                    form.AttributesDataGrid.Rows.Add("Theme", ebookSection.Theme ?? "");
                }
            }

            if (_selectedNode is ElementNode elementNode)
            {
                var element = elementNode.Element;

                if (element is EBook eBook)
                {
                    form.AttributesDataGrid.Columns.Clear();
                    form.AttributesDataGrid.ColumnCount = 2;
                    form.AttributesDataGrid.Columns[0].Width =
                    form.AttributesDataGrid.Columns[1].Width = 178;

                    form.AttributesDataGrid.Rows.Add("Title", eBook.Title ?? "");
                    form.AttributesDataGrid.Rows.Add("Author", eBook.Author ?? "");
                    form.AttributesDataGrid.Rows.Add("Year", eBook.Year.ToString());
                    form.AttributesDataGrid.Rows.Add("Path", eBook.Path ?? "");
                }
            }
        }

        private void OpenFile(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node is ElementNode elementNode
                && elementNode.Element is EBook eBook
                && !string.IsNullOrEmpty(eBook.Path))
            {
                string path = eBook.Path;
                if (path.Substring(path.LastIndexOf('.') + 1) == "pdf" && File.Exists(path))
                {
                    form.PdfViewer.LoadFromFile(path);
                }
            }
        }
    }
}
