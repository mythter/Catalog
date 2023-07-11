﻿using BookCatalog.TreeViewHelper;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;

namespace BookCatalog
{
    public class Presenter
    {
        private readonly IView form;
        private TreeNode? _nodeToMove;
        private TreeNode? _selectedNode;
        private readonly BookCatalog catalog;

        public Presenter(IView form)
        {
            this.form = form;

            form.PdfViewer.CanPrint = false;
            form.PdfViewer.CanSave = false;

            form.AttributesDataGrid.RowTemplate.Height = 35;

            form.TreeViewDragEnter += TreeViewDragEnter;
            form.TreeViewDragDrop += TreeViewDragDrop;
            form.TreeNodeMouseHover += TreeNodeMouseHover;
            form.TreeNodeNameEdited += TreeNodeNameEdited;

            form.ShowAttributes += ShowAttributes;
            form.OpenFile += OpenFile;
            form.CloseEvent += Close;
            form.ChangeAttributeValue += ChangeAttributeValue;
            form.SearchTextBoxKeyPressEvent += SearchTextBoxKeyPress;

            form.Remove += Remove;
            form.AddSection += AddSection;
            form.AddRootSection += AddRootSection;
            form.AddElement += AddElement;
            form.Search += Search;

            if (File.Exists("catalog.json"))
            {
                string json = File.ReadAllText("catalog.json");
                catalog = JsonConvert.DeserializeObject<BookCatalog>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    NullValueHandling = NullValueHandling.Ignore,
                }) ?? new BookCatalog();

                catalog.AddNodesToTreeView(form.CatalogTree);
            }
            else
            {
                File.Create("catalog.json");
                catalog = new BookCatalog();
            }
        }

        public void TreeViewDragEnter(object? sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            SelectNode(_nodeToMove);
        }

        private void TreeViewDragDrop(object? sender, DragEventArgs e)
        {
            TreeNode? sourceNode = _nodeToMove;

            if (sourceNode is not null)
            {
                Point pt = form.CatalogTree.PointToClient(new Point(e.X, e.Y));
                TreeNode destinationNode = form.CatalogTree.GetNodeAt(pt);

                if (destinationNode == sourceNode.Parent
                    || destinationNode == sourceNode
                    || (sourceNode is SectionNode secNode
                    && destinationNode is SectionNode secDestNode
                    && secNode.Section.ContainsChild(secDestNode.Section)))
                {
                    return;
                }

                if (destinationNode is SectionNode sectionDestinationNode)
                {
                    if ((sourceNode is SectionNode sNode
                        && sectionDestinationNode.Section.ChildSections.Exists(s => s.Name == sNode.Section.Name))
                        || (sourceNode is ElementNode eNode
                        && sectionDestinationNode.Section.Elements.Exists(s => s.Name == eNode.Element.Name)))
                    {
                        MessageBox.Show("Section or element with such name already exists in the current section.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    form.CatalogTree.Nodes.Remove(sourceNode);
                    destinationNode.Nodes.Add(sourceNode);

                    if (sourceNode is SectionNode s)
                    {
                        catalog.RemoveSection(s.Section);
                        sectionDestinationNode.Section.AddSection(s.Section);
                    }
                    else if (sourceNode is ElementNode el)
                    {
                        catalog.RemoveElement(el.Element);
                        sectionDestinationNode.Section.AddElement(el.Element);
                    }

                    form.CatalogTree.SelectedNode = sourceNode;
                }

                if (sourceNode is SectionNode sectionNode && destinationNode is null)
                {
                    if (sourceNode is SectionNode sNode && catalog.SectionExists(sNode.Name))
                    {
                        MessageBox.Show("Section with such name already exists in the current section.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    form.CatalogTree.Nodes.Remove(sectionNode);
                    form.CatalogTree.Nodes.Add(sectionNode);

                    catalog.RemoveSection(sectionNode.Section);
                    catalog.AddSection(sectionNode.Section);

                    form.CatalogTree.SelectedNode = sectionNode;
                }
            }
        }

        private void TreeNodeMouseHover(object? sender, TreeNodeMouseHoverEventArgs e)
        {
            _nodeToMove = e.Node;
        }

        private void ShowAttributes(object? sender, TreeNodeMouseClickEventArgs e)
        {
            _selectedNode = e.Node;
            form.CatalogTree.SelectedNode = _selectedNode;
            ShowAttributes(_selectedNode);
        }

        private void ShowAttributes(TreeNode node)
        {
            if (node is SectionNode sectionNode)
            {
                var section = sectionNode.Section;

                if (section is EBookSection ebookSection)
                {
                    form.AttributesDataGrid.Columns.Clear();
                    form.AttributesDataGrid.ColumnCount = 2;
                    form.AttributesDataGrid.Columns[0].ReadOnly = true;
                    form.AttributesDataGrid.Columns[0].Width =
                    form.AttributesDataGrid.Columns[1].Width = (form.AttributesDataGrid.Width / 2) - 2;
                    form.AttributesDataGrid.Columns[0].DefaultCellStyle.Font = new Font(form.AttributesDataGrid.Font, FontStyle.Bold);

                    form.AttributesDataGrid.Rows.Add("Theme", ebookSection.Theme ?? "");
                }
            }

            if (node is ElementNode elementNode)
            {
                var element = elementNode.Element;

                if (element is EBook eBook)
                {
                    form.AttributesDataGrid.Columns.Clear();
                    form.AttributesDataGrid.ColumnCount = 2;
                    form.AttributesDataGrid.Columns[0].ReadOnly = true;
                    form.AttributesDataGrid.Columns[0].Width =
                    form.AttributesDataGrid.Columns[1].Width = (form.AttributesDataGrid.Width / 2) - 2;
                    form.AttributesDataGrid.Columns[0].DefaultCellStyle.Font = new Font(form.AttributesDataGrid.Font, FontStyle.Bold);

                    form.AttributesDataGrid.Rows.Add("Title", eBook.Title ?? "");
                    form.AttributesDataGrid.Rows.Add("Author", eBook.Author ?? "");
                    form.AttributesDataGrid.Rows.Add("Year", eBook.Year.ToString());
                    form.AttributesDataGrid.Rows.Add("Path", eBook.Path ?? "");
                }
            }
        }

        private void OpenFile(object? sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node is ElementNode elementNode
                && elementNode.Element is EBook)
            {
                string? path = ((EBook)((ElementNode)e.Node).Element).Path;

                if (path is null || !File.Exists(path))
                {
                    MessageBox.Show("File path is not correct.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                    catch (Exception)
                    {
                        MessageBox.Show("An error occurred while opening the file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void Close(object? sender, FormClosingEventArgs e)
        {
            JsonSerializer serializer = new();
            serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.TypeNameHandling = TypeNameHandling.Auto;
            serializer.Formatting = Formatting.Indented;
            serializer.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

            using (StreamWriter sw = new("catalog.json"))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, catalog, typeof(BookCatalog));
                }
            }
        }

        private void ChangeAttributeValue(object? sender, DataGridViewCellEventArgs e)
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
                        else
                        {
                            MessageBox.Show("The Year value is not correct.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            form.AttributesDataGrid[e.ColumnIndex, e.RowIndex].Value = null;
                        }
                        break;

                    case "Path":
                        eBook.Path = value;
                        break;
                }
            }
        }

        private void AddSection(object? sender, EventArgs e)
        {
            if (_selectedNode is SectionNode sectionNode)
            {
                int i = -1;
                string name;

                do
                {
                    i++;
                    name = $"Section {i}";
                }
                while (sectionNode.Section.ChildSections.Exists(s => s.Name == name));

                EBookSection newSection = new(name);
                SectionNode newNode = new(newSection);

                sectionNode.Section.AddSection(newSection);
                sectionNode.Nodes.Add(newNode);

                SelectNode(newNode);
            }
        }

        private void AddRootSection(object? sender, EventArgs e)
        {
            int i = -1;
            string name;

            do
            {
                i++;
                name = $"Section {i}";
            }
            while (catalog.SectionExists(name));

            EBookSection newSection = new(name);
            SectionNode newNode = new(newSection);

            catalog.AddSection(newSection);
            form.CatalogTree.Nodes.Add(newNode);

            SelectNode(newNode);
        }

        private void AddElement(object? sender, EventArgs e)
        {
            if (_selectedNode is SectionNode sectionNode)
            {
                int i = -1;
                string name;

                do
                {
                    i++;
                    name = $"Element {i}";
                }
                while (sectionNode.Section.Elements.Exists(s => s.Name == name));

                EBook newElement = new(name);
                ElementNode newNode = new(newElement);

                sectionNode.Section.AddElement(newElement);
                sectionNode.Nodes.Add(newNode);

                SelectNode(newNode);
            }
        }

        private void Remove(object? sender, EventArgs e)
        {
            if (_selectedNode is SectionNode sectionNode)
            {
                form.CatalogTree.Nodes.Remove(sectionNode);
                catalog.RemoveSection(sectionNode.Section);
                form.AttributesDataGrid.Columns.Clear();
            }

            if (_selectedNode is ElementNode elementNode)
            {
                form.CatalogTree.Nodes.Remove(elementNode);
                catalog.RemoveElement(elementNode.Element);
                form.AttributesDataGrid.Columns.Clear();
            }

            _selectedNode = null;
        }

        private void TreeNodeNameEdited(object? sender, NodeLabelEditEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Label))
            {
                if (_selectedNode is SectionNode sectionNode)
                {
                    if ((sectionNode.Section.ParentSection is not null
                        && !sectionNode.Section.ParentSection.ChildSections.Exists(s => s.Name == e.Label))
                        || (sectionNode.Section.ParentSection is null
                        && !catalog.SectionExists(e.Label)))
                    {
                        sectionNode.Section.Name = e.Label;
                    }
                    else
                    {
                        MessageBox.Show("Section with such name already exists in the current section.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _selectedNode.Text = sectionNode.Section.Name;
                    }
                }

                if (_selectedNode is ElementNode elementNode)
                {
                    if (!elementNode.Element.ParentSection!.Elements.Exists(el => el.Name == e.Label))
                    {
                        elementNode.Element.Name = e.Label;
                    }
                    else
                    {
                        MessageBox.Show("Element with such name already exists in the current section.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        _selectedNode.Text = elementNode.Element.Name;
                    }
                }
            }
        }

        private void SearchTextBoxKeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SearchElement();
            }
        }

        private void Search(object? sender, EventArgs e)
        {
            SearchElement();
        }

        private void SearchElement()
        {
            string search = form.SearchTextBox.ToLower();

            if (string.IsNullOrEmpty(search))
            {
                return;
            }

            ElementNode? elementNode;
            foreach (var node in form.CatalogTree.Nodes)
            {
                elementNode = FindNode(search, (TreeNode)node);
                if (elementNode is not null)
                {
                    SelectNode(elementNode);
                    return;
                }
            }
        }

        private ElementNode? FindNode(string search, TreeNode treeNode)
        {
            foreach (var node in treeNode.Nodes)
            {
                if (node is ElementNode elementNode
                    && elementNode.Element is EBook eBook
                    && (eBook.Name.ToLower().Contains(search) || eBook.Title.ToLower().Contains(search)))
                {
                    return elementNode;
                }
            }

            foreach (var node in treeNode.Nodes)
            {
                if (node is SectionNode sectionNode)
                {
                    ElementNode? elementNode = FindNode(search, sectionNode);
                    if (elementNode is not null)
                    {
                        return elementNode;
                    }
                }
            }

            return null;
        }

        private void SelectNode(TreeNode? node)
        {
            if (node is not null)
            {
                _selectedNode = node;
                form.CatalogTree.SelectedNode = _selectedNode;
                form.CatalogTree.Focus();
                ShowAttributes(_selectedNode);
            }
        }
    }
}
