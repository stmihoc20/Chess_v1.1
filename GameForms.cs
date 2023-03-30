using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_v1._0
{
    public partial class fGame : Form
    {
        private fMain f1;
        private Game g;
        public fGame(fMain f1)
        {
            this.f1 = f1;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            g = new Game(this);
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            this.Hide();
            f1.Show();
        }
    }
    
}
