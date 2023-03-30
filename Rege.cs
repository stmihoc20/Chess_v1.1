using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_v1._0
{
    class Rege: Piesa
    {
        public Rege(int i, int j, PictureBox rege0, bool piesaAlba) : base(i, j, piesaAlba)
        {
            numePiesa = "rege";
            imagine = rege0;
            imagine.Location = new Point(calculLocatie(i), calculLocatie(j));
        }

        override public void desenareAlbastru(Patrat[,] patrat, int currentTurn)
        {
            if (currentTurn == 0 && imagine.Tag.ToString() == "alb")
            {
                desenareRege(patrat, currentTurn);
            }
            else if(currentTurn == 1 && imagine.Tag.ToString() == "negru")
            {
                desenareRege(patrat, currentTurn);
            }
        }
        public void desenareRege(Patrat [,] patrat, int currentTurn)
        {
            for (int k = -1; k <= 1; k++)
            {
                for (int l = -1; l <= 1; l++)
                {
                    if (i - k < 8 && j - l < 8 && i - k >= 0 && j - l >= 0 && (k != 0 || l != 0))
                    {
                        if(!patrat[i - k, j - l].ocupat)
                            patrat[i - k, j - l].getPanel().BackColor = Color.Blue;
                        else if(currentTurn == 0 && !patrat[i - k, j - l].piesa.piesaAlba)
                            patrat[i - k, j - l].getPanel().BackColor = Color.Blue;
                        else if (currentTurn == 1 && patrat[i - k, j - l].piesa.piesaAlba)
                            patrat[i - k, j - l].getPanel().BackColor = Color.Blue;
                    }
                }
            }
        }

        /*override public bool testareSah(Patrat[,] patrat, Piesa rege)
        {
            int i = rege.GetI();
            int j = rege.GetJ();

            //Pion
            if (j > 0 && patrat[i, j].piesaAlba)
            {
                if (i - 1 > 0 && patrat[i - 1, j - 1].ocupat)
                {
                    if (patrat[i - 1, j - 1].piesa.numePiesa == "pion" && patrat[i - 1, j - 1].piesaAlba != patrat[i, j].piesaAlba)
                    {
                        return true;
                    }
                }
                if (i + 1 > 0 && patrat[i + 1, j - 1].ocupat)
                {
                    if (patrat[i + 1, j - 1].piesa.numePiesa == "pion" && patrat[i + 1, j - 1].piesaAlba != patrat[i, j].piesaAlba)
                    {
                        return true;
                    }
                }
            }
            if (j < 8 && !patrat[i, j].piesaAlba)
            {
                if (i - 1 > 0 && patrat[i - 1, j + 1].ocupat)
                {
                    if (patrat[i - 1, j + 1].piesa.numePiesa == "pion" && patrat[i - 1, j + 1].piesaAlba != patrat[i, j].piesaAlba)
                    {
                        return true;
                    }
                }
                if (i + 1 > 0 && patrat[i + 1, j + 1].ocupat)
                {
                    if (patrat[i + 1, j + 1].piesa.numePiesa == "pion" && patrat[i + 1, j + 1].piesaAlba != patrat[i, j].piesaAlba)
                    {
                        return true;
                    }
                }
            }

            //Turn si Regina
            for (int k = 1; k < 8; k++)
            {
                if (i + k < 8)
                {
                    if (patrat[i + k, j].ocupat)
                    {
                        if ((patrat[i + k, j].piesa.numePiesa == "turn" || patrat[i + k, j].piesa.numePiesa == "regina") && patrat[i + k, j].piesaAlba != patrat[i, j].piesaAlba)
                        {
                            return true;
                        }
                        else
                            break;
                    }
                }
                else
                    break;
            }
            for (int k = 1; k < 8; k++)
            {
                if (i - k >= 0)
                {
                    if (patrat[i - k, j].ocupat)
                    {
                        if ((patrat[i - k, j].piesa.numePiesa == "turn" || patrat[i - k, j].piesa.numePiesa == "regina") && patrat[i - k, j].piesaAlba != patrat[i, j].piesaAlba)
                        {
                            return true;
                        }
                        else
                            break;
                    }
                }
                else
                    break;
            }
            for (int k = 1; k < 8; k++)
            {
                if (j + k < 8)
                {
                    if (patrat[i, j + k].ocupat)
                    {
                        if ((patrat[i, j + k].piesa.numePiesa == "turn" || patrat[i, j + k].piesa.numePiesa == "regina") && patrat[i, j + k].piesaAlba != patrat[i, j].piesaAlba)
                        {
                            return true;
                        }
                        else
                            break;
                    }
                }
                else
                    break;
            }
            for (int k = 1; k < 8; k++)
            {
                if (j - k >= 0)
                {
                    if (patrat[i, j - k].ocupat)
                    {
                        if ((patrat[i, j - k].piesa.numePiesa == "turn" || patrat[i, j - k].piesa.numePiesa == "regina") && patrat[i, j - k].piesaAlba != patrat[i, j].piesaAlba)
                        {
                            return true;
                        }
                        else
                            break;
                    }
                }
                else
                    break;
            }
            //Cal
            if (i - 2 >= 0)
            {
                if (j + 1 < 8 && patrat[i - 2, j + 1].ocupat)
                {
                    if (patrat[i - 2, j + 1].piesa.numePiesa == "cal" && patrat[i - 2, j + 1].piesaAlba != patrat[i, j].piesaAlba)
                    {
                        return true;
                    }
                }
                if (j - 1 >= 0 && patrat[i - 2, j - 1].ocupat)
                {
                    if (patrat[i - 2, j - 1].piesa.numePiesa == "cal" && patrat[i - 2, j - 1].piesaAlba != patrat[i, j].piesaAlba)
                    {
                        return true;
                    }
                }
            }
            if (i - 1 >= 0)
            {
                if (j + 2 < 8 && patrat[i - 1, j + 2].ocupat)
                {
                    if (patrat[i - 1, j + 2].piesa.numePiesa == "cal" && patrat[i - 1, j + 2].piesaAlba != patrat[i, j].piesaAlba)
                    {
                        return true;
                    }
                }
                if (j - 2 >= 0 && patrat[i - 1, j - 2].ocupat)
                {
                    if (patrat[i - 1, j - 2].piesa.numePiesa == "cal" && patrat[i - 1, j - 2].piesaAlba != patrat[i, j].piesaAlba)
                    {
                        return true;
                    }
                }
            }
            if (i + 1 < 8)
            {
                if (j + 2 < 8 && patrat[i + 1, j + 2].ocupat)
                {
                    if (patrat[i + 1, j + 2].piesa.numePiesa == "cal" && patrat[i + 1, j + 2].piesaAlba != patrat[i, j].piesaAlba)
                    {
                        return true;
                    }
                }
                if (j - 2 >= 0 && patrat[i + 1, j - 2].ocupat)
                {
                    if (patrat[i + 1, j - 2].piesa.numePiesa == "cal" && patrat[i + 1, j - 2].piesaAlba != patrat[i, j].piesaAlba)
                    {
                        return true;
                    }
                }
            }
            if (i + 2 < 8)
            {
                if (j + 1 < 8 && patrat[i + 2, j + 1].ocupat)
                {
                    if (patrat[i + 2, j + 1].piesa.numePiesa == "cal" && patrat[i + 2, j + 1].piesaAlba != patrat[i, j].piesaAlba)
                    {
                        return true;
                    }
                }
                if (j - 1 >= 0 && patrat[i + 2, j - 1].ocupat)
                {
                    if (patrat[i + 2, j - 1].piesa.numePiesa == "cal" && patrat[i + 2, j - 1].piesaAlba != patrat[i, j].piesaAlba)
                    {
                        return true;
                    }
                }
            }
            //Nebun si Regina
            bool[] flags = { true, true, true, true };
            for (int k = 1; k < 8; k++)
            {
                if (i + k < 8 && j + k < 8 && flags[0])
                {
                    if (patrat[i + k, j + k].ocupat)
                    {
                        if ((patrat[i + k, j + k].piesa.numePiesa == "nebun" || patrat[i + k, j + k].piesa.numePiesa == "regina") && patrat[i + k, j + k].piesaAlba != patrat[i, j].piesaAlba)
                        {
                            return true;
                        }
                        else
                            flags[0] = false;
                    }
                }
                else
                    flags[0] = false;
                if (i + k < 8 && j - k >= 0 && flags[1])
                {
                    if (patrat[i + k, j - k].ocupat)
                    {
                        if ((patrat[i + k, j - k].piesa.numePiesa == "nebun" || patrat[i + k, j - k].piesa.numePiesa == "regina") && patrat[i + k, j - k].piesaAlba != patrat[i, j].piesaAlba)
                        {
                            return true;
                        }
                        else
                            flags[1] = false;
                    }
                }
                else
                    flags[1] = false;
                if (i - k >= 0 && j + k < 8 && flags[2])
                {
                    if (patrat[i - k, j + k].ocupat)
                    {
                        if ((patrat[i - k, j + k].piesa.numePiesa == "nebun" || patrat[i - k, j + k].piesa.numePiesa == "regina") && patrat[i - k, j + k].piesaAlba != patrat[i, j].piesaAlba)
                        {
                            return true;
                        }
                        else
                            flags[2] = false;
                    }
                }
                else
                    flags[2] = false;
                if (i - k >= 0 && j - k >= 0 && flags[3])
                {
                    if (patrat[i - k, j - k].ocupat)
                    {
                        if ((patrat[i - k, j - k].piesa.numePiesa == "nebun" || patrat[i - k, j - k].piesa.numePiesa == "regina") && patrat[i - k, j - k].piesaAlba != patrat[i, j].piesaAlba)
                        {
                            return true;
                        }
                        else
                            flags[3] = false;
                    }
                }
                else
                    flags[3] = false;
            }

            return false;
        }*/
    }
}
