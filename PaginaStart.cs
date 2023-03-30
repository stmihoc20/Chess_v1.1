using System;
using System.Windows.Forms;

namespace Chess_v1._0
{
    public partial class fMain : Form
    {
        private fGame gameForms;
        public fMain()
        {
            gameForms = new fGame(this);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           gameForms.Show();
           this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
