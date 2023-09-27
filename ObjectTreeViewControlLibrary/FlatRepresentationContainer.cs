namespace ObjectTreeViewControlLibrary;

internal class FlatRepresentationContainer
{
    public TreeItem Item { get; }
    public TreeItem? ParentItem { get; }

    public FlatRepresentationContainer(TreeItem item, TreeItem? parentItem)
    {
        Item = item;
        ParentItem = parentItem;
    }

    public override string ToString() =>
        $"Container for item: {Item}";
}