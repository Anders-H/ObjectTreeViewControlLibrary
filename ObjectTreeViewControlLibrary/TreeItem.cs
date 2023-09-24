namespace ObjectTreeViewControlLibrary;

public abstract class TreeItem
{
    private bool _selected;
    public static int ItemHeight { get; set; }
    public string ItemType { get; set; }
    public string Text { get; set; }
    public Brush BackgroundColor { get; set; }
    public Brush ForegroundColor { get; set; }
    public int Indentation { get; internal set; }
    public TreeItemList Items { get; }
    public TreeView? Parent { get; internal set; }
    
    static TreeItem()
    {
        ItemHeight = 23;
    }

    protected TreeItem(string itemType, string text)
    {
        ItemType = itemType;
        Text = text;
        BackgroundColor = Brushes.DarkGray;
        ForegroundColor = Brushes.White;
        Items = new TreeItemList();
    }

    public bool Selected
    {
        get => _selected;
        set
        {
            if (value)
            {
                Parent?.Deselect();
                _selected = true;
            }
            else
            {
                _selected = false;
            }

            Parent?.Invalidate();
        }
    }

    public virtual void Paint(Graphics g, Font font, int y, int width)
    {
        const int indentationWidth = 12;
        g.FillRectangle(BackgroundColor, Indentation * indentationWidth, y, width - Indentation, ItemHeight - 1);
        var measure = g.MeasureString(Text, font);
        var textY = (double)ItemHeight / 2 - measure.Height / 2;
        g.DrawString(Text, font, ForegroundColor, Indentation * indentationWidth + 2, (float)textY + y - 1);

        if (Selected)
        {
            var w = Parent?.Width ?? 100;
            g.DrawRectangle(Pens.Black, -1, y, w, ItemHeight - 2);
            g.DrawRectangle(Pens.White, -1, y + 1, w, ItemHeight - 4);
        }
    }

    public TreeItem Add(TreeItem item)
    {
        item.Parent = Parent;
        item.Indentation = Indentation + 1;
        Items.Add(item);
        Parent?.UpdateScrollbar();
        return item;
    }

    public override string ToString() =>
        $"Item indentation {Indentation}: {Text}";
}