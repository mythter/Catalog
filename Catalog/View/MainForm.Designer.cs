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
            treeView = new TreeView();
            catalogGroup = new GroupBox();
            AddRootSectionBtn = new FontAwesome.Sharp.IconButton();
            RemoveBtn = new FontAwesome.Sharp.IconButton();
            AddElementBtn = new FontAwesome.Sharp.IconButton();
            AddSectionBtn = new FontAwesome.Sharp.IconButton();
            searchTextBox = new TextBox();
            attributesGroup = new GroupBox();
            dataGridView = new DataGridView();
            pdfViewer = new Spire.PdfViewer.Forms.PdfViewer();
            AddRootTip = new ToolTip(components);
            AddSectionTip = new ToolTip(components);
            AddElementTip = new ToolTip(components);
            RemoveTip = new ToolTip(components);
            catalogGroup.SuspendLayout();
            attributesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // treeView
            // 
            treeView.AllowDrop = true;
            treeView.HideSelection = false;
            treeView.LabelEdit = true;
            treeView.Location = new Point(6, 64);
            treeView.Name = "treeView";
            treeView.Size = new Size(360, 294);
            treeView.TabIndex = 0;
            treeView.AfterLabelEdit += treeView_AfterLabelEdit;
            treeView.ItemDrag += treeView_ItemDrag;
            treeView.NodeMouseHover += treeView_NodeMouseHover;
            treeView.NodeMouseClick += treeView_NodeMouseClick;
            treeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
            treeView.DragDrop += treeView_DragDrop;
            treeView.DragEnter += treeView_DragEnter;
            // 
            // catalogGroup
            // 
            catalogGroup.Controls.Add(AddRootSectionBtn);
            catalogGroup.Controls.Add(RemoveBtn);
            catalogGroup.Controls.Add(AddElementBtn);
            catalogGroup.Controls.Add(AddSectionBtn);
            catalogGroup.Controls.Add(searchTextBox);
            catalogGroup.Controls.Add(treeView);
            catalogGroup.Font = new Font("Montserrat", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            catalogGroup.Location = new Point(4, 2);
            catalogGroup.Name = "catalogGroup";
            catalogGroup.Size = new Size(372, 403);
            catalogGroup.TabIndex = 1;
            catalogGroup.TabStop = false;
            catalogGroup.Text = "Catalog";
            // 
            // AddRootSectionBtn
            // 
            AddRootSectionBtn.IconChar = FontAwesome.Sharp.IconChar.FolderTree;
            AddRootSectionBtn.IconColor = Color.Black;
            AddRootSectionBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            AddRootSectionBtn.IconSize = 30;
            AddRootSectionBtn.Location = new Point(6, 364);
            AddRootSectionBtn.Name = "AddRootSectionBtn";
            AddRootSectionBtn.Size = new Size(85, 33);
            AddRootSectionBtn.TabIndex = 8;
            AddRootTip.SetToolTip(AddRootSectionBtn, "Add new root section");
            AddRootSectionBtn.UseVisualStyleBackColor = true;
            AddRootSectionBtn.Click += AddRootSectionBtn_Click;
            // 
            // RemoveBtn
            // 
            RemoveBtn.IconChar = FontAwesome.Sharp.IconChar.Trash;
            RemoveBtn.IconColor = Color.Black;
            RemoveBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            RemoveBtn.IconSize = 30;
            RemoveBtn.Location = new Point(279, 364);
            RemoveBtn.Name = "RemoveBtn";
            RemoveBtn.Size = new Size(85, 33);
            RemoveBtn.TabIndex = 7;
            RemoveTip.SetToolTip(RemoveBtn, "Remove element or section");
            RemoveBtn.UseVisualStyleBackColor = true;
            RemoveBtn.Click += Remove_Click;
            // 
            // AddElementBtn
            // 
            AddElementBtn.IconChar = FontAwesome.Sharp.IconChar.FileCirclePlus;
            AddElementBtn.IconColor = Color.Black;
            AddElementBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            AddElementBtn.IconSize = 30;
            AddElementBtn.Location = new Point(188, 364);
            AddElementBtn.Name = "AddElementBtn";
            AddElementBtn.Size = new Size(85, 33);
            AddElementBtn.TabIndex = 6;
            AddElementTip.SetToolTip(AddElementBtn, "Add new element");
            AddElementBtn.UseVisualStyleBackColor = true;
            AddElementBtn.Click += AddElementBtn_Click;
            // 
            // AddSectionBtn
            // 
            AddSectionBtn.IconChar = FontAwesome.Sharp.IconChar.FolderPlus;
            AddSectionBtn.IconColor = Color.Black;
            AddSectionBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            AddSectionBtn.IconSize = 30;
            AddSectionBtn.Location = new Point(97, 364);
            AddSectionBtn.Name = "AddSectionBtn";
            AddSectionBtn.Size = new Size(85, 33);
            AddSectionBtn.TabIndex = 5;
            AddSectionTip.SetToolTip(AddSectionBtn, "Add new section to current section");
            AddSectionBtn.UseVisualStyleBackColor = true;
            AddSectionBtn.Click += AddSection_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(6, 27);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(361, 28);
            searchTextBox.TabIndex = 1;
            // 
            // attributesGroup
            // 
            attributesGroup.Controls.Add(dataGridView);
            attributesGroup.Font = new Font("Montserrat", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            attributesGroup.Location = new Point(4, 411);
            attributesGroup.Name = "attributesGroup";
            attributesGroup.Size = new Size(373, 220);
            attributesGroup.TabIndex = 2;
            attributesGroup.TabStop = false;
            attributesGroup.Text = "Attributes";
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.ColumnHeadersVisible = false;
            dataGridView.Location = new Point(6, 27);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(360, 187);
            dataGridView.TabIndex = 0;
            dataGridView.CellEndEdit += dataGridView_CellEndEdit;
            // 
            // pdfViewer
            // 
            pdfViewer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pdfViewer.FindTextHighLightColor = Color.FromArgb(200, 153, 193, 218);
            pdfViewer.FormFillEnabled = false;
            pdfViewer.IgnoreCase = false;
            pdfViewer.IsToolBarVisible = true;
            pdfViewer.Location = new Point(383, 2);
            pdfViewer.MultiPagesThreshold = 60;
            pdfViewer.Name = "pdfViewer";
            pdfViewer.OnRenderPageExceptionEvent = null;
            pdfViewer.Size = new Size(899, 629);
            pdfViewer.TabIndex = 3;
            pdfViewer.Text = "pdfViewer1";
            pdfViewer.Threshold = 60;
            pdfViewer.ViewerBackgroundColor = Color.FromArgb(229, 229, 229);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1285, 635);
            Controls.Add(pdfViewer);
            Controls.Add(attributesGroup);
            Controls.Add(catalogGroup);
            Name = "MainForm";
            Text = "EBooks Catalog";
            FormClosing += MainForm_FormClosing;
            catalogGroup.ResumeLayout(false);
            catalogGroup.PerformLayout();
            attributesGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView;
        private GroupBox catalogGroup;
        private GroupBox attributesGroup;
        private DataGridView dataGridView;
        private Spire.PdfViewer.Forms.PdfViewer pdfViewer;
        private TextBox searchTextBox;
        private FontAwesome.Sharp.IconButton AddRootSectionBtn;
        private FontAwesome.Sharp.IconButton AddSectionBtn;
        private FontAwesome.Sharp.IconButton AddElementBtn;
        private FontAwesome.Sharp.IconButton RemoveBtn;
        private ToolTip AddRootTip;
        private ToolTip AddSectionTip;
        private ToolTip AddElementTip;
        private ToolTip RemoveTip;
    }
}