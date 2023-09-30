namespace ObjectTreeViewControlLibrary;

public class ItemColor
{
    public string ItemType { get; }
    public Brush BackgroundColor { get; }
    public Brush ForegroundColor { get; }

    public ItemColor(string itemType, string itemBackgroundColor, string itemForegroundColor) : this(itemType, ToBrush(itemBackgroundColor), ToBrush(itemForegroundColor))
    {
    }

    public ItemColor(string itemType, Brush itemBackgroundColor, Brush itemForegroundColor)
    {
        ItemType = itemType;
        BackgroundColor = itemBackgroundColor;
        ForegroundColor = itemForegroundColor;
    }

    private static Brush ToBrush(string color)
    {
        var csColor = color.Replace("#", "#ff").ToLower();
        var ccv = new ColorConverter();
        var c = (Color)ccv.ConvertFromString(csColor)!;
        return new SolidBrush(c);
    }
}