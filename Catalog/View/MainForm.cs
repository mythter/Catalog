using System.Drawing.Text;

namespace BookCatalog
{
    public partial class MainForm : Form, IView
    {
        #region Custom font
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection? fonts = new PrivateFontCollection();

        Font? MontserratFontRegular;
        #endregion

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Critical Code Smell", "S4487:Unread \"private\" fields should be removed", Justification = "Presenter module needs to do all main logic")]
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
        public int FormWidth => this.Width;
        public int FormHeight => this.Height;
        public int FormX => this.Location.X;
        public int FormY => this.Location.Y;

#pragma warning restore S2292 // Trivial properties should be auto-implemented

        // Implementing IView interface events
        public event ItemDragEventHandler? TreeViewItemDrag;
        public event DragEventHandler? TreeViewDragDrop;
        public event DragEventHandler? TreeViewDragEnter;
        public event TreeNodeMouseClickEventHandler? ShowAttributes;
        public event TreeNodeMouseHoverEventHandler? TreeNodeMouseHover;
        public event NodeLabelEditEventHandler? TreeNodeNameEdited;
        public event TreeNodeMouseClickEventHandler? OpenFile;
        public event FormClosingEventHandler? CloseEvent;
        public event DataGridViewCellEventHandler? ChangeAttributeValue;
        public event EventHandler? AddRootSection;
        public event EventHandler? AddSection;
        public event EventHandler? AddElement;
        public event EventHandler? Remove;
        public event EventHandler? Search;
        public event KeyPressEventHandler? SearchTextBoxKeyPressEvent;

        private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Item is not null)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
            //TreeViewItemDrag?.Invoke(sender, e);
        }
        private void treeView_DragEnter(object sender, DragEventArgs e)
        {
            TreeViewDragEnter?.Invoke(sender, e);
        }
        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            TreeViewDragDrop?.Invoke(sender, e);
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

        private void treeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            this.BeginInvoke(new Action(() => TreeNodeNameEdited?.Invoke(sender, e)));
            //TreeNodeNameEdited?.Invoke(sender, e);
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Search?.Invoke(sender, e);
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SearchTextBoxKeyPressEvent?.Invoke(sender, e);
        }
    }
}