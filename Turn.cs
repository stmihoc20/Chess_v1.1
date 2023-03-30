using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_v1._0
{
    class Turn: Piesa
    {

        public Turn(int i, int j, PictureBox turn0, bool piesaAlba) : base(i, j, piesaAlba)
        {
            numePiesa = "turn";
            imagine = turn0;
            imagine.Location = new Point(calculLocatie(i), calculLocatie(j));
        }

        override public void desenareAlbastru(Patrat[,] patrat, int currentTurn)
        {
            if (currentTurn == 0 && imagine.Tag.ToString() == "alb")
            {
                desenareTurn(patrat, currentTurn);
            }
            else if (currentTurn == 1 && imagine.Tag.ToString() == "negru")
            {
                desenareTurn(patrat, currentTurn);
            }
        }
        public void desenareTurn(Patrat [,] patrat, int currentTurn)
        {
            int[] op1 = { 1, -1, 0, 0 };
            int[] op2 = { 0, 0, 1, -1 };

            for(int l = 0; l <4; l++)
            {
                for (int k = 1; k < 8; k++)
                {
                    if (i + op1[l]*k < 8 && i + op1[l]*k >= 0 && j + op2[l] * k < 8 && j + op2[l] * k >= 0)
                    {
                        if (!patrat[i + op1[l]*k, j + op2[l]*k].ocupat)
                            patrat[i + op1[l]*k, j + op2[l]*k].getPanel().BackColor = Color.Blue;
                        else if (currentTurn == 0 && !patrat[i + op1[l]*k, j + op2[l]*k].piesa.piesaAlba)
                        {
                            patrat[i + op1[l]*k, j + op2[l]*k].getPanel().BackColor = Color.Blue;
                            break;
                        }
                        else if (currentTurn == 1 && patrat[i + op1[l]*k, j + op2[l]*k].piesa.piesaAlba)
                        {
                            patrat[i + op1[l]*k, j + op2[l]*k].getPanel().BackColor = Color.Blue;
                            break;
                        }
                        else
                            break;
                    }
                    else
                        break;
                }
            }
        }

/*        override public bool testareSah(Patrat[,] patrat, Piesa rege)
        {
            int i = rege.GetI();
            int j = rege.GetJ();

            int[] op1 = { 1, -1, 0, 0 };
            int[] op2 = { 0, 0, 1, -1 };

            for (int l = 0; l < 4; l++)
            {
                for (int k = 1; k < 8; k++)
                {
                    if (i + op1[l] * k < 8 && i + op1[l] * k >= 0 && j + op2[l] * k < 8 && j + op2[l] * k >= 0)
                    {
                        if (patrat[i + op1[l] * k, j + op2[l] * k].ocupat)
                        {
                            if (patrat[i + op1[l] * k, j + op2[l] * k].piesa.numePiesa == "turn" && patrat[i + op1[l] * k, j + op2[l] * k].piesaAlba != patrat[i, j].piesaAlba)
                            {
                                patrat[i, j].getPanel().BackColor = Color.Red;
                                return true;
                            }
                            else
                                break;
                        }
                    }
                    else
                        break;
                }
            }
            return false;
        }*/
    }
}
