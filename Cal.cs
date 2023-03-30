using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_v1._0
{
    class Cal: Piesa
    {
        public Cal(int i, int j, PictureBox cal0, bool piesaAlba) : base(i, j, piesaAlba)
        {
            numePiesa = "cal";
            imagine = cal0;
            imagine.Location = new Point(calculLocatie(i), calculLocatie(j));
        }

        override public void desenareAlbastru(Patrat[,] patrat, int currentTurn)
        {
            if (currentTurn == 0 && imagine.Tag.ToString() == "alb")
            {
                desenareCal(patrat, currentTurn);
            }
            else if (currentTurn == 1 && imagine.Tag.ToString() == "negru")
            {
                desenareCal(patrat, currentTurn);
            }
        }

        public void desenareCal(Patrat[,] patrat , int currentTurn)
        {
            int[] locX = { -2, -2, -1, -1, 1, 1, 2, 2 };
            int[] locY = { 1, -1, 2, -2, 2, -2, 1, -1 };

            for(int k=0; k<8; k++)
            {
                if (i + locX[k] >= 0 && i + locX[k] < 8)
                {
                    if (j + locY[k] >= 0 && j + locY[k] < 8)
                    {
                        if (!patrat[i + locX[k], j + locY[k]].ocupat)
                            patrat[i + locX[k], j + locY[k]].getPanel().BackColor = Color.Blue;
                        else if (currentTurn == 0 && !patrat[i + locX[k], j + locY[k]].piesa.piesaAlba)
                            patrat[i + locX[k], j + locY[k]].getPanel().BackColor = Color.Blue;
                        else if(currentTurn == 1 && patrat[i + locX[k], j + locY[k]].piesa.piesaAlba)
                            patrat[i + locX[k], j + locY[k]].getPanel().BackColor = Color.Blue;
                    }
                }
            }
        }
        /*override public bool testareSah(Patrat[,] patrat, Piesa rege)
        {
            int i = rege.GetI();
            int j = rege.GetJ();

            int[] locX = { -2, -2, -1, -1, 1, 1, 2, 2 };
            int[] locY = { 1, -1, 2, -2, 2, -2, 1, -1 };

            for (int k = 0; k < 8; k++)
            {
                if (i + locX[k] >= 0 && i + locX[k] < 8)
                {
                    if (j + locY[k] >= 0 && j + locY[k] < 8 && patrat[i + locX[k], j + locY[k]].ocupat)
                    {
                        if(patrat[i + locX[k], j + locY[k]].piesa.numePiesa == "cal" && patrat[i + locX[k], j + locY[k]].piesaAlba != patrat[i, j].piesaAlba)
                        {
                            patrat[i, j].getPanel().BackColor = Color.Red;
                            return true;
                        }
                    }
                }
            }
            return false;
        }*/
    }
}
