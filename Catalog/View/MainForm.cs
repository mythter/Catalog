using BookCatalog.TreeViewHelper;

namespace BookCatalog
{
    public partial class MainForm : Form, IView
    {
        Presenter presenter;
        public MainForm()
        {
            InitializeComponent();
            presenter = new Presenter(this);
        }

        // Implementing IView interface properties
        public string SearchTextBox { get => searchTextBox.Text; set => searchTextBox.Text = value; }

#pragma warning disable S2292 // Trivial properties should be auto-implemented

        public TreeView CatalogTree { get => treeView; set => treeView = value; }
        public DataGridView AttributesDataGrid { get => dataGridView; set => dataGridView = value; }
        public Spire.PdfViewer.Forms.PdfViewer PdfViewer { get => pdfViewer; set => pdfViewer = value; }

#pragma warning restore S2292 // Trivial properties should be auto-implemented

        // Implementing IView interface events
        public event ItemDragEventHandler TreeViewItemDrag;
        public event DragEventHandler TreeViewDragDrop;
        public event DragEventHandler TreeViewDragEnter;
        public event TreeNodeMouseClickEventHandler ShowAttributes;
        public event TreeNodeMouseHoverEventHandler TreeNodeMouseHover;
        public event TreeNodeMouseClickEventHandler OpenFile;
        public event FormClosingEventHandler CloseEvent;
        public event DataGridViewCellEventHandler ChangeAttributeValue;
        public event EventHandler AddSection;
        public event EventHandler AddElement;
        public event EventHandler Remove;
        public event NodeLabelEditEventHandler TreeNodeNameEdited;

        private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
            //TreeViewItemDrag?.Invoke(sender, e);
        }
        private void treeView_DragEnter(object sender, DragEventArgs e)
        {
            TreeViewDragEnter?.Invoke(sender, e);
        }
        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            TreeViewDragDrop.Invoke(sender, e);
        }

        private void treeView_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            TreeNodeMouseHover?.Invoke(sender, e);
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ShowAttributes?.Invoke(sender, e);
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            OpenFile?.Invoke(sender, e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseEvent?.Invoke(sender, e);
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ChangeAttributeValue?.Invoke(sender, e);
        }

        private void AddSection_Click(object sender, EventArgs e)
        {
            AddSection?.Invoke(sender, e);
        }

        private void AddElementBtn_Click(object sender, EventArgs e)
        {
            AddElement?.Invoke(sender, e);
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            Remove?.Invoke(sender, e);
        }

        private void treeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            this.BeginInvoke(new Action(() => TreeNodeNameEdited?.Invoke(sender, e)));
            //TreeNodeNameEdited?.Invoke(sender, e);
        }
    }
}