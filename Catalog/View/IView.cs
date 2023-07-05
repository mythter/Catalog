namespace BookCatalog
{
    public interface IView
    {
        // Controls
        string SearchTextBox { get; set; }
        TreeView CatalogTree { get; set; }
        DataGridView AttributesDataGrid { get; set; }
        Spire.PdfViewer.Forms.PdfViewer PdfViewer { get; set; }

        // Events
        event ItemDragEventHandler TreeViewItemDrag;
        event DragEventHandler TreeViewDragDrop;
        event DragEventHandler TreeViewDragEnter;
        event TreeNodeMouseHoverEventHandler TreeNodeMouseHover;
        event TreeNodeMouseClickEventHandler ShowAttributes;
        event TreeNodeMouseClickEventHandler OpenFile;
        event FormClosingEventHandler CloseEvent;
        event DataGridViewCellEventHandler ChangeAttributeValue;

        // Buttons
        event EventHandler AddSection;
        event EventHandler AddElement;
        event EventHandler Remove;
    }
}
