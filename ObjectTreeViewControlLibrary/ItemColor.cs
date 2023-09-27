namespace ObjectTreeViewControlLibrary;

public class ItemColor
{
    public string ItemType { get; }
    public Brush Color { get; }

    public ItemColor(string itemType, Brush itemColor)
    {
        ItemType = itemType;
        Color = itemColor;
    }
}