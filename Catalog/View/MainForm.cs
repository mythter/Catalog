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

        private void MainForm_Load(object sender, EventArgs e)
        {
            BookCatalog catalog = new BookCatalog();

            catalog.Add(new EBookSection("Section 1"));
            catalog.Add(new EBookSection("Section 2"));
            catalog.Add(new EBookSection("Section 3"));

            catalog.RootItems[0].AddSection(new EBookSection("Section 4"));
            catalog.RootItems[0].AddSection(new EBookSection("Section 5"));
            var book = new EBook("Good book", "Good author", path : @"D:\Универ\Операционные системы\crictecs2023-1 certificate.pdf");
            catalog.RootItems[0].ChildSections![0].AddElement(book);
            catalog.RootItems[0].ChildSections![0].AddElement(new EBook($"Book 14"));
            catalog.RootItems[0].ChildSections![0].AddSection(new EBookSection($"Section 6"));
            catalog.RootItems[0].ChildSections![0].ChildSections![0].AddSection(new EBookSection($"Section 7"));
            catalog.RootItems[0].ChildSections![0].ChildSections![0].AddElement(new EBook($"Book 123"));
            catalog.RootItems[0].ChildSections![0].ChildSections![0].AddElement(new EBook($"Book 345"));
            catalog.RootItems[0].ChildSections![0].ChildSections![0].AddElement(new EBook($"Book 563"));

            catalog.RootItems.ForEach(r => treeView.Nodes.Add(new SectionNode(r)));
        }

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
    }
}