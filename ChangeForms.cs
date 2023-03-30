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
    public partial class fDialog : Form
    {
        private fGame f2;
        PictureBox imagine;
        private Piesa a;
        private bool[] flags = { false, false, false, false };

        public fDialog(fGame f2, Piesa piesaMutata)
        {
            InitializeComponent();
            this.f2 = f2;
            this.a = piesaMutata;
        }

        private void fDialog_Load(object sender, EventArgs e)
        {
            int i = a.GetI();
            int j = a.GetJ();

            if (a.piesaAlba)
            {
                this.pictureBox1.Image = new Bitmap(Properties.Resources.reginaA);
                this.pictureBox2.Image = new Bitmap(Properties.Resources.turnA);
                this.pictureBox3.Image = new Bitmap(Properties.Resources.calA);
                this.pictureBox4.Image = new Bitmap(Properties.Resources.nebunA);
            }
            else
            {
                this.pictureBox1.Image = new Bitmap(Properties.Resources.reginaN);
                this.pictureBox2.Image = new Bitmap(Properties.Resources.turnN);
                this.pictureBox3.Image = new Bitmap(Properties.Resources.calN);
                this.pictureBox4.Image = new Bitmap(Properties.Resources.nebunN);
            }

            imagine = new PictureBox
            {
                Location = new Point(i, j),
                Width = 50,
                Height = 50,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            f2.Controls.Add(imagine);
            f2.Controls.SetChildIndex(imagine, 2);
        }

        private void regina_Click(object sender, EventArgs e)
        {
            if (a.piesaAlba)
            {
                imagine.Image = new Bitmap(Properties.Resources.reginaA);
                imagine.Tag = "alb";
            }
            else
            {
                imagine.Image = new Bitmap(Properties.Resources.reginaN);
                imagine.Tag = "negru";
            }

            int i = a.GetI();
            int j = a.GetJ();

            a = new Regina(i, j, imagine, true);
            this.Hide();
        }

        private void turn_Click(object sender, EventArgs e)
        {
            if (a.piesaAlba)
            {
                imagine.Image = new Bitmap(Properties.Resources.turnA);
                imagine.Tag = "alb";
            }
            else
            {
                imagine.Image = new Bitmap(Properties.Resources.turnN);
                imagine.Tag = "negru";
            }

            int i = a.GetI();
            int j = a.GetJ();

            a = new Turn(i, j, imagine, true);
            this.Hide();
        }

        private void cal_Click(object sender, EventArgs e)
        {
            if (a.piesaAlba)
            {
                imagine.Image = new Bitmap(Properties.Resources.calA);
                imagine.Tag = "alb";
            }
            else
            {
                imagine.Image = new Bitmap(Properties.Resources.calN);
                imagine.Tag = "negru";
            }

            int i = a.GetI();
            int j = a.GetJ();

            a = new Cal(i, j, imagine, true);
            this.Hide();
        }

        private void nebun_Click(object sender, EventArgs e)
        {
            if (a.piesaAlba)
            {
                imagine.Image = new Bitmap(Properties.Resources.nebunA);
                imagine.Tag = "alb";
            }
            else
            {
                imagine.Image = new Bitmap(Properties.Resources.nebunN);
                imagine.Tag = "negru";
            }

            int i = a.GetI();
            int j = a.GetJ();

            a = new Nebun(i, j, imagine, true);
            this.Hide();
        }

        public Piesa transformare()
        {
            ShowDialog();
            return a;
        }
    }
}
