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
            treeWiew1.Add(new Item("Root 1"));
            var root2 = treeWiew1.Add(new Item("Root 2"));
            treeWiew1.Add(new Item("Root 3"));

            var ur2 = root2.Add(new Item("Under Root 2"));
            var tjohej =  ur2.Add(new Item("Tjohej 3"));
            var sista = tjohej.Add(new Item("Under tjohej 3"));
            var supersista = sista.Add(new Item("Näst längst ut i världen"));
            var x = supersista.Add(new Item("Sist"));
            x.Add(new Item("X"));

            for (var i = 4; i < 20; i++)
                treeWiew1.Add(new Item($"Root {i}"));
        }
    }
}