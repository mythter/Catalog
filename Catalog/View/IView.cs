namespace BookCatalog
{
    public interface IView
    {
        string SearchTextBox { get; set; }

        TreeView CatalogTree { get; set; }

        DataGridView AttributesDataGrid { get; set; }

        Spire.PdfViewer.Forms.PdfViewer PdfViewer { get; set; }

        event ItemDragEventHandler TreeViewItemDrag;
        event DragEventHandler TreeViewDragDrop;
        event DragEventHandler TreeViewDragEnter;
        event TreeNodeMouseHoverEventHandler TreeNodeMouseHover;

        event TreeNodeMouseClickEventHandler ShowAttributes;
        event TreeNodeMouseClickEventHandler OpenFile;

        event FormClosingEventHandler CloseEvent;

        event DataGridViewCellEventHandler ChangeAttributeValue;
    }
}
