using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_v1._0
{
    class Pion : Piesa
    {

        public Pion(int i, int j, PictureBox piesa0, bool piesaAlba) : base(i, j, piesaAlba)
        {
            numePiesa = "pion";
            imagine = piesa0;
            imagine.Location = new Point(calculLocatie(i), calculLocatie(j));
        }

        override public void desenareAlbastru(Patrat[,] patrat, int currentTurn)
        {
            if (currentTurn == 0 && imagine.Tag.ToString() == "alb")
            {
                if (j > 0)
                {
                    if (j == 6 && !patrat[i, j - 2].ocupat && !patrat[i, j - 1].ocupat)
                        patrat[i, j - 2].getPanel().BackColor = Color.Blue;
                    if (!patrat[i, j - 1].ocupat)
                        patrat[i, j - 1].getPanel().BackColor = Color.Blue;
                    if (i - 1 >= 0 && patrat[i - 1, j - 1].ocupat && !patrat[i - 1, j - 1].piesa.piesaAlba)
                        patrat[i - 1, j - 1].getPanel().BackColor = Color.Blue;
                    if (i + 1 < 8 && patrat[i + 1, j - 1].ocupat && !patrat[i + 1, j - 1].piesa.piesaAlba)
                        patrat[i + 1, j - 1].getPanel().BackColor = Color.Blue;
                }
            }
            else if (currentTurn == 1 && imagine.Tag.ToString() == "negru")
            {
                if (j < 8)
                {
                    if (j == 1 && !patrat[i, j + 2].ocupat && !patrat[i, j + 1].ocupat)
                        patrat[i, j + 2].getPanel().BackColor = Color.Blue;
                    if (!patrat[i, j + 1].ocupat)
                        patrat[i, j + 1].getPanel().BackColor = Color.Blue;
                    if (i - 1 >= 0 && patrat[i - 1, j + 1].ocupat && patrat[i - 1, j + 1].piesa.piesaAlba)
                        patrat[i - 1, j + 1].getPanel().BackColor = Color.Blue;
                    if (i + 1 < 8 && patrat[i + 1, j + 1].ocupat && patrat[i + 1, j + 1].piesa.piesaAlba)
                        patrat[i + 1, j + 1].getPanel().BackColor = Color.Blue;
                }
            }
        }

        /*override public bool testareSah(Patrat[,] patrat, Piesa rege)
        {
            int i = rege.GetI();
            int j = rege.GetJ();
            if (j >= 0 && patrat[i,j].piesaAlba)
            {
                if (i - 1 >= 0 && patrat[i - 1, j - 1].ocupat)
                {
                    if (patrat[i - 1, j - 1].piesa.numePiesa == "pion" && patrat[i - 1, j - 1].piesaAlba != patrat[i, j].piesaAlba)
                    {
                        patrat[i, j].getPanel().BackColor = Color.Red;
                        return true;
                    }
                }
                if (i + 1 < 8 && patrat[i + 1, j - 1].ocupat)
                {
                    if (patrat[i + 1, j - 1].piesa.numePiesa == "pion" && patrat[i + 1, j - 1].piesaAlba != patrat[i, j].piesaAlba)
                    {
                        patrat[i, j].getPanel().BackColor = Color.Red;
                        return true;
                    }
                }
            }
            if (j < 8 && !patrat[i, j].piesaAlba)
            {
                if (i - 1 >= 0 && patrat[i - 1, j + 1].ocupat)
                {
                    if (patrat[i - 1, j + 1].piesa.numePiesa == "pion" && patrat[i - 1, j + 1].piesaAlba != patrat[i, j].piesaAlba)
                    {
                        patrat[i, j].getPanel().BackColor = Color.Red;
                        return true;
                    }
                }
                if (i + 1 < 8 && patrat[i + 1, j + 1].ocupat)
                {
                    if (patrat[i + 1, j + 1].piesa.numePiesa == "pion" && patrat[i + 1, j + 1].piesaAlba != patrat[i, j].piesaAlba)
                    {
                        patrat[i, j].getPanel().BackColor = Color.Red;
                        return true;
                    }
                }
            }
            return false;
        }*/
    }
}
