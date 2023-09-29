namespace ObjectTreeViewControlLibrary;

public class ItemColorPalette : List<ItemColor>
{
    public bool Has(string itemType) =>
        this.Any(i => string.Compare(i.ItemType, itemType, StringComparison.CurrentCultureIgnoreCase) == 0);

    public void Remove(string itemType)
    {
        foreach (var i in this.Where(i => string.Compare(i.ItemType, itemType, StringComparison.CurrentCultureIgnoreCase) == 0))
        {
            Remove(i);
            return;
        }
    }

    public ItemColor? Get(string itemType) =>
        this.FirstOrDefault(i => string.Compare(i.ItemType, itemType, StringComparison.CurrentCultureIgnoreCase) == 0);
}