using ObjectTreeViewControlLibrary;

namespace ObjectTreeViewTestProgram;

public class SuperDuperItem : TreeItem
{
    public SuperDuperItem(string text) : base(nameof(SuperDuperItem), text)
    {
    }

    public int IntProperty { get; set; }

    public string StringProperty { get; set; }
}