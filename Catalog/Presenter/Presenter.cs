using BookCatalog.TreeViewHelper;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;
using System.Net.Security;

namespace BookCatalog
{
    public class Presenter
    {
        private readonly IView form;
        private TreeNode? _nodeToMove;
        private TreeNode? _selectedNode;
        private BookCatalog catalog;

        public Presenter(IView form)
        {
            this.form = form;

            form.PdfViewer.CanPrint = false;

            form.TreeViewItemDrag += TreeViewItemDrag;
            form.TreeViewDragEnter += TreeViewDragEnter;
            form.TreeViewDragDrop += TreeViewDragDrop;
            form.TreeNodeMouseHover += TreeNodeMouseHover;

            form.ShowAttributes += ShowAttributes;
            form.OpenFile += OpenFile;
            form.CloseEvent += Close;
            form.ChangeAttributeValue += ChangeAttributeValue;

            form.Remove += Remove;
            form.AddSection += AddSection;
            form.AddElement += AddElement;

            string json = File.ReadAllText("catalog.json");
            catalog = JsonConvert.DeserializeObject<BookCatalog>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
            }) ?? new BookCatalog();

            catalog.RootItems.ForEach(r => form.CatalogTree.Nodes.Add(new SectionNode(r)));
        }

        public void TreeViewItemDrag(object sender, ItemDragEventArgs e)
        {
            _nodeToMove = e.Item as TreeNode;
        }

        public void TreeViewDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void TreeViewDragDrop(object sender, DragEventArgs e)
        {
            TreeNode? sourceNode = _nodeToMove;
            //System.Windows.Forms.TreeView? tree = sender as System.Windows.Forms.TreeView;

            if (sourceNode is not null /* && tree is not null*/)
            {
                Point pt = form.CatalogTree.PointToClient(new Point(e.X, e.Y));
                TreeNode destinationNode = form.CatalogTree.GetNodeAt(pt);


                if (destinationNode is SectionNode sectionDestinationNode)
                {
                    form.CatalogTree.Nodes.Remove(sourceNode);
                    destinationNode.Nodes.Add(sourceNode);

                    Section? parentSection;

                    if (sourceNode is SectionNode s)
                    {
                        catalog.Remove(s.Section);
                        sectionDestinationNode.Section.AddSection(s.Section);
                    }
                    else if (sourceNode is ElementNode el)
                    {
                        catalog.RemoveElementFromRootItems(el.Element);
                        sectionDestinationNode.Section.AddElement(el.Element);
                    }

                    form.CatalogTree.SelectedNode = sourceNode;
                }

                if (sourceNode is SectionNode sectionNode && destinationNode is null)
                {
                    form.CatalogTree.Nodes.Remove(sectionNode);
                    form.CatalogTree.Nodes.Add(sectionNode);

                    catalog.Remove(sectionNode.Section);
                    catalog.Add(sectionNode.Section);

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
                    form.AttributesDataGrid.Columns[0].DefaultCellStyle.Font = new Font(form.AttributesDataGrid.Font, FontStyle.Bold);

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
                    form.AttributesDataGrid.Columns[0].DefaultCellStyle.Font = new Font(form.AttributesDataGrid.Font, FontStyle.Bold);

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
                && File.Exists(eBook.Path))
            {
                string path = eBook.Path;
                if (path.Substring(path.LastIndexOf('.') + 1) == "pdf")
                {
                    form.PdfViewer.LoadFromFile(path);
                }
                else
                {
                    try
                    {
                        var pi = new ProcessStartInfo(path)
                        {
                            Arguments = Path.GetFileName(path),
                            UseShellExecute = true,
                            WorkingDirectory = Path.GetDirectoryName(path),
                            Verb = "OPEN"
                        };
                        Process.Start(pi);
                    }
                    catch (Exception )
                    {
                        MessageBox.Show("An error occurred while opening the file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void Close(object sender, FormClosingEventArgs e)
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.TypeNameHandling = TypeNameHandling.Auto;
            serializer.Formatting = Formatting.Indented;
            serializer.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

            using (StreamWriter sw = new StreamWriter("catalog.json"))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, catalog, typeof(BookCatalog));
                }
            }
        }

        private void ChangeAttributeValue(object sender, DataGridViewCellEventArgs e)
        {
            if (_selectedNode is SectionNode sectionNode)
            {
                var eBookSection = (EBookSection)sectionNode.Section;
                switch (form.AttributesDataGrid.Rows[e.RowIndex].Cells[0].Value)
                {
                    case "Theme":
                        eBookSection.Theme = (string)form.AttributesDataGrid[e.ColumnIndex, e.RowIndex].Value;
                        break;
                }
            }

            if (_selectedNode is ElementNode elementNode)
            {
                var eBook = (EBook)elementNode.Element;
                string value = (string)form.AttributesDataGrid[e.ColumnIndex, e.RowIndex].Value;
                switch (form.AttributesDataGrid.Rows[e.RowIndex].Cells[0].Value)
                {
                    case "Title":
                        eBook.Title = value;
                        break;

                    case "Author":
                        eBook.Author = value;
                        break;

                    case "Year":
                        int temp;
                        if (int.TryParse(value, CultureInfo.InvariantCulture, out temp))
                        {
                            eBook.Year = temp;
                        }
                        break;

                    case "Path":
                        eBook.Path = value;
                        break;
                }
            }
        }

        private void AddSection(object sender, EventArgs e)
        {
            
        }

        private void AddElement(object sender, EventArgs e)
        {

        }

        private void Remove(object sender, EventArgs e)
        {
            if (_selectedNode is SectionNode sectionNode)
            {
                form.CatalogTree.Nodes.Remove(sectionNode);
                catalog.Remove(sectionNode.Section);
                form.AttributesDataGrid.Columns.Clear();
            }

            if (_selectedNode is ElementNode elementNode)
            {
                form.CatalogTree.Nodes.Remove(elementNode);
                catalog.RemoveElementFromRootItems(elementNode.Element);
                form.AttributesDataGrid.Columns.Clear();
            }
        }
    }
}
