namespace ObjectTreeViewControlLibrary;

public class ItemColor
{
    public string ItemType { get; }
    public Brush BackgroundColor { get; }
    public Brush ForegroundColor { get; }

    public ItemColor(string itemType, Brush itemBackgroundColor, Brush itemForegroundColor)
    {
        ItemType = itemType;
        BackgroundColor = itemBackgroundColor;
        ForegroundColor = itemForegroundColor;
    }
}