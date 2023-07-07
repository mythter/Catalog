﻿namespace BookCatalog
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
        event NodeLabelEditEventHandler TreeNodeNameEdited;
        event TreeNodeMouseClickEventHandler ShowAttributes;
        event TreeNodeMouseClickEventHandler OpenFile;
        event FormClosingEventHandler CloseEvent;
        event DataGridViewCellEventHandler ChangeAttributeValue;
        event KeyPressEventHandler SearchTextBoxKeyPressEvent;

        // Buttons
        event EventHandler AddRootSection;
        event EventHandler AddSection;
        event EventHandler AddElement;
        event EventHandler Remove;
        event EventHandler Search;

        // Main form properties
        int FormWidth { get; }
        int FormHeight { get; }
        int FormX { get; }
        int FormY { get; }
    }
}
