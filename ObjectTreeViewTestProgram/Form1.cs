namespace ObjectTreeViewTestProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeView.RegisterItemColor("Test", Brushes.Red, Brushes.Yellow);
            treeView.RegisterItemColor("Specialtyp", Brushes.Blue, Brushes.Cyan);

            treeView.Add(new Item("Root 1"));
            var root2 = treeView.Add(new Item("Root 2"));
            treeView.Add(new Item("Root 3"));

            var ur2 = treeView.AddChild(root2, new Item("Under Root 2", "Specialtyp"));
            var tjohej = treeView.AddChild(ur2, new Item("Tjohej 3"));
            var sista = treeView.AddChild(tjohej, new Item("Under tjohej 3"));
            var supersista = treeView.AddChild(sista, new Item("Näst längst ut i världen"));
            var x = treeView.AddChild(supersista, new Item("Sist"));
            treeView.AddChild(x, new Item("X"));

            for (var i = 4; i < 20; i++)
                treeView.Add(new Item($"Root {i}"));
        }
    }
}