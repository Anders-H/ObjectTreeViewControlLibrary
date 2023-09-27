namespace ObjectTreeViewControlLibrary;

public partial class TreeView : UserControl
{
    private int _viewOffset;
    public TreeItemList Items { get; }
    public int VisibleItemsCount { get; private set; }
    public event ItemClickDelegate? ItemClick;
    public ItemColorPalette ItemColors { get; }

    public TreeView()
    {
        Items = new TreeItemList();
        ItemColors = new ItemColorPalette();
        VisibleItemsCount = 0;
        InitializeComponent();
    }

    private void UserControl1_Load(object sender, EventArgs e)
    {

    }

    private void vScrollBar1_Scroll(object sender, ScrollEventArgs e) =>
        ViewOffset = vScrollBar1.Value;

    private void vScrollBar1_ValueChanged(object sender, EventArgs e) =>
        ViewOffset = vScrollBar1.Value;

    public int ViewOffset
    {
        get => _viewOffset;
        set
        {
            _viewOffset = value;
            Invalidate();
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Invalidate();
    }

    public TreeItem Add(TreeItem item)
    {
        item.Parent = this;
        item.Indentation = 0;
        SetItemColor(item);
        Items.Add(item);
        Invalidate();
        UpdateScrollbar();
        return item;
    }

    public TreeItem AddChild(TreeItem parent, TreeItem item)
    {
        item.Parent = this;
        SetItemColor(item);
        parent.Add(item);
        return item;
    }

    public void Deselect()
    {
        var items = GetFlatRepresentation();

        foreach (var item in items)
            item.Item.Selected = false;
    }

    internal void UpdateScrollbar()
    {
        var max = Items.Count - VisibleItemsCount;

        if (max < 1)
            max = 1;

        vScrollBar1.Maximum = max;

        if (max > 30)
            vScrollBar1.LargeChange = 6;
        else if (max > 10)
            vScrollBar1.LargeChange = 3;
        else
            vScrollBar1.LargeChange = 2;
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        UpdateScrollbar();
        base.OnSizeChanged(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.Clear(Color.Gray);

        var items = GetFlatRepresentation();

        if (items.Count <= 0 || items.Count < _viewOffset)
            return;

        var yPos = 0;
        var visibleItemsCount = 0;
        
        for (var y = _viewOffset; y < items.Count; y++)
        {
            items[y].Item.Paint(e.Graphics, Font, yPos, Width);
            visibleItemsCount++;
            yPos += TreeItem.ItemHeight;

            if (yPos > Height)
                break;
        }

        VisibleItemsCount = visibleItemsCount;

        base.OnPaint(e);
    }

    private FlatRepresentationContainerList GetFlatRepresentation()
    {
        var result = new FlatRepresentationContainerList();
        foreach (var item in Items)
        {
            item.Indentation = 0;
            result.Add(new FlatRepresentationContainer(item, null));

            foreach (var subItem in item.Items)
            {
                subItem.Indentation = 1;
                result.Add(new FlatRepresentationContainer(subItem, item));
                AddChildren(ref result, subItem, 1);
            }
        }
        return result;
    }

    private void AddChildren(ref FlatRepresentationContainerList result, TreeItem parent, int indentationLevel)
    {
        foreach (var childItem in parent.Items)
        {
            childItem.Indentation = indentationLevel + 1;
            result.Add(new FlatRepresentationContainer(childItem, parent));

            foreach (var childChildItem in childItem.Items)
            {
                childChildItem.Indentation = childItem.Indentation + 1;
                result.Add(new FlatRepresentationContainer(childChildItem, childItem));
                AddChildren(ref result, childChildItem, indentationLevel + 2);
            }
        }
    }

    public TreeItem? GetItemAt(int y)
    {
        var items = GetFlatRepresentation();

        var index = y / TreeItem.ItemHeight + _viewOffset;

        if (index < items.Count && index >= 0)
            return items[index].Item;

        return null;
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        var item = GetItemAt(e.Y);

        if (item != null)
        {
            item.Selected = true;
            ItemClick?.Invoke(this, item);
        }

        base.OnMouseClick(e);
    }
}