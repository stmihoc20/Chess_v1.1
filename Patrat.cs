using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_v1._0
{
    public class Patrat:Pozitie
    {
        private const int latura = 60;
        private const int offset = 100;
        private Panel panou;
        public Piesa piesa;
        public bool ocupat = false;

        public Patrat(int i, int j, fGame f2):base(i, j)
        {
            initializarePanou(f2);
        }
        public void setCuloare()
        {
            if (panou.BackColor != Color.Red)
            {
                if ((i + j) % 2 == 0)
                {
                    panou.BackColor = Color.White;
                }
                else
                {
                    panou.BackColor = Color.Gray;
                }
            }
        }
        public void initializarePanou(fGame f2)
        {
            panou = new Panel
            {
                Size = new Size(latura, latura),
                Location = new Point(offset + latura * i, offset + latura * j),
            };

            if ((i + j) % 2 == 0)
            {
                panou.BackColor = Color.White;
            }
            else
            {
                panou.BackColor = Color.Gray;
            }
            if (j < 2)
            {
                ocupat = true;
            }
            if( j > 5 )
            {
                ocupat = true;
            }

            panou.SendToBack();
            f2.Controls.Add(panou);
        }
        public Panel getPanel()
        {
            return panou;
        }
        public int getLatura()
        {
            return latura;
        }
        public int getOffset()
        {
            return offset;
        }
    }
}
