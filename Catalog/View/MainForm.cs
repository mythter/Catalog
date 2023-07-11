using System.Drawing.Text;

namespace BookCatalog
{
    public partial class MainForm : Form, IView
    {
        #region Custom font
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection? fonts = new();

        Font? MontserratFontRegular;
        #endregion

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Critical Code Smell", "S4487:Unread \"private\" fields should be removed", Justification = "Presenter needs to implement MVP pattern")]
        private Presenter? presenter;

        public MainForm()
        {
            InitializeComponent();
            presenter = new Presenter(this);

            #region Custom font
            byte[] fontData = Properties.Resources.Montserrat_Regular;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.Montserrat_Regular.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.Montserrat_Regular.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            MontserratFontRegular = new Font(fonts.Families[0], 10.0F);

            TextBoxSearch.Font = MontserratFontRegular;
            CatalogTreeView.Font = MontserratFontRegular;
            CatalogGroup.Font = MontserratFontRegular;
            AttributesGroup.Font = MontserratFontRegular;
            AttributesDataGridView.Font = MontserratFontRegular;
            #endregion
        }

#pragma warning disable S2292 // Trivial properties should be auto-implemented

        // Implementing IView interface properties
        public string SearchTextBox { get => TextBoxSearch.Text; set => TextBoxSearch.Text = value; }
        public TreeView CatalogTree { get => CatalogTreeView; set => CatalogTreeView = value; }
        public DataGridView AttributesDataGrid { get => AttributesDataGridView; set => AttributesDataGridView = value; }
        public Spire.PdfViewer.Forms.PdfViewer PdfViewer { get => PdfViewerControl; set => PdfViewerControl = value; }

#pragma warning restore S2292 // Trivial properties should be auto-implemented

        // Implementing IView interface events
        public event DragEventHandler? TreeViewDragDrop;
        public event DragEventHandler? TreeViewDragEnter;
        public event TreeNodeMouseClickEventHandler? ShowAttributes;
        public event TreeNodeMouseHoverEventHandler? TreeNodeMouseHover;
        public event NodeLabelEditEventHandler? TreeNodeNameEdited;
        public event TreeNodeMouseClickEventHandler? OpenFile;
        public event FormClosingEventHandler? CloseEvent;
        public event DataGridViewCellEventHandler? ChangeAttributeValue;
        public event KeyPressEventHandler? SearchTextBoxKeyPressEvent;

        // Implementing IView interface events for buttons
        public event EventHandler? AddRootSection;
        public event EventHandler? AddSection;
        public event EventHandler? AddElement;
        public event EventHandler? Remove;
        public event EventHandler? Search;

        private void TreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Item is not null)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void TreeView_DragEnter(object sender, DragEventArgs e)
        {
            TreeViewDragEnter?.Invoke(sender, e);
        }

        private void TreeView_DragDrop(object sender, DragEventArgs e)
        {
            TreeViewDragDrop?.Invoke(sender, e);
        }

        private void TreeView_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {
            TreeNodeMouseHover?.Invoke(sender, e);
        }

        private void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ShowAttributes?.Invoke(sender, e);
        }

        private void TreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            OpenFile?.Invoke(sender, e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseEvent?.Invoke(sender, e);
        }

        private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ChangeAttributeValue?.Invoke(sender, e);
        }

        private void AddRootSectionBtn_Click(object sender, EventArgs e)
        {
            AddRootSection?.Invoke(sender, e);
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

        private void TreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            this.BeginInvoke(new Action(() => TreeNodeNameEdited?.Invoke(sender, e)));
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Search?.Invoke(sender, e);
        }

        private void SearchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SearchTextBoxKeyPressEvent?.Invoke(sender, e);
        }
    }
}