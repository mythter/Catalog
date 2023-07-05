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
            treeView = new TreeView();
            catalogGroup = new GroupBox();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            searchTextBox = new TextBox();
            attributesGroup = new GroupBox();
            dataGridView = new DataGridView();
            pdfViewer = new Spire.PdfViewer.Forms.PdfViewer();
            catalogGroup.SuspendLayout();
            attributesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // treeView
            // 
            treeView.AllowDrop = true;
            treeView.Location = new Point(6, 64);
            treeView.Name = "treeView";
            treeView.Size = new Size(361, 294);
            treeView.TabIndex = 0;
            treeView.ItemDrag += treeView_ItemDrag;
            treeView.NodeMouseHover += treeView_NodeMouseHover;
            treeView.NodeMouseClick += treeView_NodeMouseClick;
            treeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
            treeView.DragDrop += treeView_DragDrop;
            treeView.DragEnter += treeView_DragEnter;
            // 
            // catalogGroup
            // 
            catalogGroup.Controls.Add(button3);
            catalogGroup.Controls.Add(button2);
            catalogGroup.Controls.Add(button1);
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
            // button3
            // 
            button3.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(257, 364);
            button3.Name = "button3";
            button3.Size = new Size(110, 30);
            button3.TabIndex = 4;
            button3.Text = "Remove";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(122, 364);
            button2.Name = "button2";
            button2.Size = new Size(129, 30);
            button2.TabIndex = 3;
            button2.Text = "Add element";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Font = new Font("Montserrat", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(6, 364);
            button1.Name = "button1";
            button1.Size = new Size(110, 30);
            button1.TabIndex = 2;
            button1.Text = "Add section";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
        private Button button1;
        private Button button3;
        private Button button2;
    }
}