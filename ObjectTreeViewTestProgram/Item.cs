using ObjectTreeViewControlLibrary;

namespace ObjectTreeViewTestProgram;

public class Item : TreeItem
{
    public Item(string text) : base("Test", text)
    {
    }

    public Item(string text, string itemType) : base(itemType, text)
    {
    }
}