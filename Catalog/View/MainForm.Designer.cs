namespace BookCatalog
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            CatalogTreeView = new TreeView();
            CatalogGroup = new GroupBox();
            CatalogButtonsTableLayoutPanel = new TableLayoutPanel();
            AddRootSectionBtn = new FontAwesome.Sharp.IconButton();
            AddSectionBtn = new FontAwesome.Sharp.IconButton();
            AddElementBtn = new FontAwesome.Sharp.IconButton();
            RemoveBtn = new FontAwesome.Sharp.IconButton();
            SearchBtn = new FontAwesome.Sharp.IconButton();
            TextBoxSearch = new TextBox();
            AttributesGroup = new GroupBox();
            AttributesDataGridView = new DataGridView();
            AddRootTip = new ToolTip(components);
            AddSectionTip = new ToolTip(components);
            AddElementTip = new ToolTip(components);
            RemoveTip = new ToolTip(components);
            PdfViewerControl = new Spire.PdfViewer.Forms.PdfViewer();
            MainTableLayoutPanel = new TableLayoutPanel();
            CatalogGroup.SuspendLayout();
            CatalogButtonsTableLayoutPanel.SuspendLayout();
            AttributesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AttributesDataGridView).BeginInit();
            MainTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // CatalogTreeView
            // 
            CatalogTreeView.AllowDrop = true;
            CatalogTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CatalogTreeView.HideSelection = false;
            CatalogTreeView.LabelEdit = true;
            CatalogTreeView.Location = new Point(9, 64);
            CatalogTreeView.Name = "CatalogTreeView";
            CatalogTreeView.Size = new Size(360, 294);
            CatalogTreeView.TabIndex = 0;
            CatalogTreeView.AfterLabelEdit += treeView_AfterLabelEdit;
            CatalogTreeView.ItemDrag += treeView_ItemDrag;
            CatalogTreeView.NodeMouseHover += treeView_NodeMouseHover;
            CatalogTreeView.NodeMouseClick += treeView_NodeMouseClick;
            CatalogTreeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
            CatalogTreeView.DragDrop += treeView_DragDrop;
            CatalogTreeView.DragEnter += treeView_DragEnter;
            // 
            // CatalogGroup
            // 
            CatalogGroup.Controls.Add(CatalogButtonsTableLayoutPanel);
            CatalogGroup.Controls.Add(SearchBtn);
            CatalogGroup.Controls.Add(TextBoxSearch);
            CatalogGroup.Controls.Add(CatalogTreeView);
            CatalogGroup.Dock = DockStyle.Fill;
            CatalogGroup.Font = new Font("Montserrat", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            CatalogGroup.Location = new Point(3, 3);
            CatalogGroup.Name = "CatalogGroup";
            CatalogGroup.Size = new Size(380, 406);
            CatalogGroup.TabIndex = 1;
            CatalogGroup.TabStop = false;
            CatalogGroup.Text = "Catalog";
            // 
            // CatalogButtonsTableLayoutPanel
            // 
            CatalogButtonsTableLayoutPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CatalogButtonsTableLayoutPanel.ColumnCount = 4;
            CatalogButtonsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            CatalogButtonsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            CatalogButtonsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            CatalogButtonsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            CatalogButtonsTableLayoutPanel.Controls.Add(AddRootSectionBtn, 0, 0);
            CatalogButtonsTableLayoutPanel.Controls.Add(AddSectionBtn, 1, 0);
            CatalogButtonsTableLayoutPanel.Controls.Add(AddElementBtn, 2, 0);
            CatalogButtonsTableLayoutPanel.Controls.Add(RemoveBtn, 3, 0);
            CatalogButtonsTableLayoutPanel.Location = new Point(6, 361);
            CatalogButtonsTableLayoutPanel.Name = "CatalogButtonsTableLayoutPanel";
            CatalogButtonsTableLayoutPanel.RowCount = 1;
            CatalogButtonsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            CatalogButtonsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            CatalogButtonsTableLayoutPanel.Size = new Size(367, 42);
            CatalogButtonsTableLayoutPanel.TabIndex = 10;
            // 
            // AddRootSectionBtn
            // 
            AddRootSectionBtn.Dock = DockStyle.Fill;
            AddRootSectionBtn.IconChar = FontAwesome.Sharp.IconChar.FolderTree;
            AddRootSectionBtn.IconColor = Color.Black;
            AddRootSectionBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            AddRootSectionBtn.IconSize = 30;
            AddRootSectionBtn.Location = new Point(3, 3);
            AddRootSectionBtn.Name = "AddRootSectionBtn";
            AddRootSectionBtn.Size = new Size(85, 36);
            AddRootSectionBtn.TabIndex = 8;
            AddRootTip.SetToolTip(AddRootSectionBtn, "Add new root section");
            AddRootSectionBtn.UseVisualStyleBackColor = true;
            AddRootSectionBtn.Click += AddRootSectionBtn_Click;
            // 
            // AddSectionBtn
            // 
            AddSectionBtn.Dock = DockStyle.Fill;
            AddSectionBtn.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            AddSectionBtn.IconColor = Color.Black;
            AddSectionBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            AddSectionBtn.IconSize = 30;
            AddSectionBtn.Location = new Point(94, 3);
            AddSectionBtn.Name = "AddSectionBtn";
            AddSectionBtn.Size = new Size(85, 36);
            AddSectionBtn.TabIndex = 5;
            AddSectionTip.SetToolTip(AddSectionBtn, "Add new section to current section");
            AddSectionBtn.UseVisualStyleBackColor = true;
            AddSectionBtn.Click += AddSection_Click;
            // 
            // AddElementBtn
            // 
            AddElementBtn.Dock = DockStyle.Fill;
            AddElementBtn.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            AddElementBtn.IconColor = Color.Black;
            AddElementBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            AddElementBtn.IconSize = 30;
            AddElementBtn.Location = new Point(185, 3);
            AddElementBtn.Name = "AddElementBtn";
            AddElementBtn.Size = new Size(85, 36);
            AddElementBtn.TabIndex = 6;
            AddElementTip.SetToolTip(AddElementBtn, "Add new element");
            AddElementBtn.UseVisualStyleBackColor = true;
            AddElementBtn.Click += AddElementBtn_Click;
            // 
            // RemoveBtn
            // 
            RemoveBtn.Dock = DockStyle.Fill;
            RemoveBtn.IconChar = FontAwesome.Sharp.IconChar.Trash;
            RemoveBtn.IconColor = Color.Black;
            RemoveBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            RemoveBtn.IconSize = 30;
            RemoveBtn.Location = new Point(276, 3);
            RemoveBtn.Name = "RemoveBtn";
            RemoveBtn.Size = new Size(88, 36);
            RemoveBtn.TabIndex = 7;
            RemoveTip.SetToolTip(RemoveBtn, "Remove element or section");
            RemoveBtn.UseVisualStyleBackColor = true;
            RemoveBtn.Click += Remove_Click;
            // 
            // SearchBtn
            // 
            SearchBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SearchBtn.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            SearchBtn.IconColor = Color.Black;
            SearchBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SearchBtn.IconSize = 25;
            SearchBtn.Location = new Point(321, 26);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(48, 30);
            SearchBtn.TabIndex = 9;
            SearchBtn.UseVisualStyleBackColor = true;
            SearchBtn.Click += SearchBtn_Click;
            // 
            // TextBoxSearch
            // 
            TextBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxSearch.Location = new Point(9, 27);
            TextBoxSearch.Name = "TextBoxSearch";
            TextBoxSearch.Size = new Size(304, 28);
            TextBoxSearch.TabIndex = 1;
            TextBoxSearch.KeyPress += searchTextBox_KeyPress;
            // 
            // AttributesGroup
            // 
            AttributesGroup.Controls.Add(AttributesDataGridView);
            AttributesGroup.Dock = DockStyle.Fill;
            AttributesGroup.Font = new Font("Montserrat", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            AttributesGroup.Location = new Point(3, 415);
            AttributesGroup.Name = "AttributesGroup";
            AttributesGroup.Size = new Size(380, 217);
            AttributesGroup.TabIndex = 2;
            AttributesGroup.TabStop = false;
            AttributesGroup.Text = "Attributes";
            // 
            // AttributesDataGridView
            // 
            AttributesDataGridView.AllowUserToAddRows = false;
            AttributesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AttributesDataGridView.ColumnHeadersVisible = false;
            AttributesDataGridView.Dock = DockStyle.Fill;
            AttributesDataGridView.Location = new Point(3, 24);
            AttributesDataGridView.Name = "AttributesDataGridView";
            AttributesDataGridView.RowHeadersVisible = false;
            AttributesDataGridView.RowHeadersWidth = 51;
            AttributesDataGridView.RowTemplate.Height = 29;
            AttributesDataGridView.Size = new Size(374, 190);
            AttributesDataGridView.TabIndex = 0;
            AttributesDataGridView.CellEndEdit += dataGridView_CellEndEdit;
            // 
            // PdfViewerControl
            // 
            PdfViewerControl.Dock = DockStyle.Fill;
            PdfViewerControl.FindTextHighLightColor = Color.FromArgb(200, 153, 193, 218);
            PdfViewerControl.FormFillEnabled = false;
            PdfViewerControl.IgnoreCase = false;
            PdfViewerControl.IsToolBarVisible = true;
            PdfViewerControl.Location = new Point(389, 3);
            PdfViewerControl.Name = "PdfViewerControl";
            PdfViewerControl.OnRenderPageExceptionEvent = null;
            MainTableLayoutPanel.SetRowSpan(PdfViewerControl, 2);
            PdfViewerControl.Size = new Size(896, 629);
            PdfViewerControl.TabIndex = 3;
            PdfViewerControl.Text = "pdfViewer1";
            PdfViewerControl.ViewerBackgroundColor = Color.FromArgb(229, 229, 229);
            // 
            // MainTableLayoutPanel
            // 
            MainTableLayoutPanel.ColumnCount = 2;
            MainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            MainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            MainTableLayoutPanel.Controls.Add(CatalogGroup, 0, 0);
            MainTableLayoutPanel.Controls.Add(AttributesGroup, 0, 1);
            MainTableLayoutPanel.Controls.Add(PdfViewerControl, 1, 0);
            MainTableLayoutPanel.Dock = DockStyle.Fill;
            MainTableLayoutPanel.Location = new Point(0, 0);
            MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            MainTableLayoutPanel.RowCount = 2;
            MainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 65F));
            MainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            MainTableLayoutPanel.Size = new Size(1288, 635);
            MainTableLayoutPanel.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1288, 635);
            Controls.Add(MainTableLayoutPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(700, 400);
            Name = "MainForm";
            Text = "Catalog";
            FormClosing += MainForm_FormClosing;
            CatalogGroup.ResumeLayout(false);
            CatalogGroup.PerformLayout();
            CatalogButtonsTableLayoutPanel.ResumeLayout(false);
            AttributesGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AttributesDataGridView).EndInit();
            MainTableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TreeView CatalogTreeView;
        private GroupBox CatalogGroup;
        private GroupBox AttributesGroup;
        private DataGridView AttributesDataGridView;
        private TextBox TextBoxSearch;
        private FontAwesome.Sharp.IconButton AddRootSectionBtn;
        private FontAwesome.Sharp.IconButton AddSectionBtn;
        private FontAwesome.Sharp.IconButton AddElementBtn;
        private FontAwesome.Sharp.IconButton RemoveBtn;
        private ToolTip AddRootTip;
        private ToolTip AddSectionTip;
        private ToolTip AddElementTip;
        private ToolTip RemoveTip;
        private FontAwesome.Sharp.IconButton SearchBtn;
        private Spire.PdfViewer.Forms.PdfViewer PdfViewerControl;
        private TableLayoutPanel MainTableLayoutPanel;
        private TableLayoutPanel CatalogButtonsTableLayoutPanel;
    }
}