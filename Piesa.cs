using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_v1._0
{
    public class Piesa: Pozitie
    {
        public PictureBox imagine;
        public string numePiesa;
        public bool piesaAlba;

        public Piesa(int i0, int j0, bool piesaAlba):base(i0, j0)
        {
            this.piesaAlba = piesaAlba;
        }

        public virtual bool Muta(int x, int y, Patrat [,]patrat, bool ok = false) {

            if (x >= 0 && x <= 7 && x >= 0 && x <= 7)
            {
                if (patrat[x, y].getPanel().BackColor == Color.Blue || ok)
                {
                    patrat[i, j].piesa = null;
                    i = x;
                    j = y;
                    imagine.Location = new Point(calculLocatie(i), calculLocatie(j));
                    return true;
                }
            }
            imagine.Location = new Point(calculLocatie(i), calculLocatie(j));
            return false;
        }
        public virtual void desenareAlbastru(Patrat[,] patrat, int CurentTurn) { }
        public bool testareSah(Patrat[,] patrat, Piesa rege) {
            int i = rege.GetI();
            int j = rege.GetJ();

            //Pion
            if (j > 0 && patrat[i, j].piesa.piesaAlba)
            {
                if (i - 1 > 0 && patrat[i - 1, j - 1].ocupat)
                {
                    if (patrat[i - 1, j - 1].piesa.numePiesa == "pion" && patrat[i - 1, j - 1].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
                    {
                        return true;
                    }
                }
                if (i + 1 > 0 && patrat[i + 1, j - 1].ocupat)
                {
                    if (patrat[i + 1, j - 1].piesa.numePiesa == "pion" && patrat[i + 1, j - 1].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
                    {
                        return true;
                    }
                }
            }
            if (j < 7 && !patrat[i, j].piesa.piesaAlba)
            {
                if (i - 1 > 0 && patrat[i - 1, j + 1].ocupat)
                {
                    if (patrat[i - 1, j + 1].piesa.numePiesa == "pion" && patrat[i - 1, j + 1].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
                    {
                        return true;
                    }
                }
                if (i + 1 > 0 && patrat[i + 1, j + 1].ocupat)
                {
                    if (patrat[i + 1, j + 1].piesa.numePiesa == "pion" && patrat[i + 1, j + 1].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
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
                        if ((patrat[i + k, j].piesa.numePiesa == "turn" || patrat[i + k, j].piesa.numePiesa == "regina") && patrat[i + k, j].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
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
                        if ((patrat[i - k, j].piesa.numePiesa == "turn" || patrat[i - k, j].piesa.numePiesa == "regina") && patrat[i - k, j].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
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
                        if ((patrat[i, j + k].piesa.numePiesa == "turn" || patrat[i, j + k].piesa.numePiesa == "regina") && patrat[i, j + k].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
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
                        if ((patrat[i, j - k].piesa.numePiesa == "turn" || patrat[i, j - k].piesa.numePiesa == "regina") && patrat[i, j - k].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
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
                    if (patrat[i - 2, j + 1].piesa.numePiesa == "cal" && patrat[i - 2, j + 1].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
                    {
                        return true;
                    }
                }
                if (j - 1 >= 0 && patrat[i - 2, j - 1].ocupat)
                {
                    if (patrat[i - 2, j - 1].piesa.numePiesa == "cal" && patrat[i - 2, j - 1].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
                    {
                        return true;
                    }
                }
            }
            if (i - 1 >= 0)
            {
                if (j + 2 < 8 && patrat[i - 1, j + 2].ocupat)
                {
                    if (patrat[i - 1, j + 2].piesa.numePiesa == "cal" && patrat[i - 1, j + 2].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
                    {
                        return true;
                    }
                }
                if (j - 2 >= 0 && patrat[i - 1, j - 2].ocupat)
                {
                    if (patrat[i - 1, j - 2].piesa.numePiesa == "cal" && patrat[i - 1, j - 2].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
                    {
                        return true;
                    }
                }
            }
            if (i + 1 < 8)
            {
                if (j + 2 < 8 && patrat[i + 1, j + 2].ocupat)
                {
                    if (patrat[i + 1, j + 2].piesa.numePiesa == "cal" && patrat[i + 1, j + 2].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
                    {
                        return true;
                    }
                }
                if (j - 2 >= 0 && patrat[i + 1, j - 2].ocupat)
                {
                    if (patrat[i + 1, j - 2].piesa.numePiesa == "cal" && patrat[i + 1, j - 2].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
                    {
                        return true;
                    }
                }
            }
            if (i + 2 < 8)
            {
                if (j + 1 < 8 && patrat[i + 2, j + 1].ocupat)
                {
                    if (patrat[i + 2, j + 1].piesa.numePiesa == "cal" && patrat[i + 2, j + 1].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
                    {
                        return true;
                    }
                }
                if (j - 1 >= 0 && patrat[i + 2, j - 1].ocupat)
                {
                    if (patrat[i + 2, j - 1].piesa.numePiesa == "cal" && patrat[i + 2, j - 1].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
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
                        if ((patrat[i + k, j + k].piesa.numePiesa == "nebun" || patrat[i + k, j + k].piesa.numePiesa == "regina") && patrat[i + k, j + k].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
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
                        if ((patrat[i + k, j - k].piesa.numePiesa == "nebun" || patrat[i + k, j - k].piesa.numePiesa == "regina") && patrat[i + k, j - k].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
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
                        if ((patrat[i - k, j + k].piesa.numePiesa == "nebun" || patrat[i - k, j + k].piesa.numePiesa == "regina") && patrat[i - k, j + k].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
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
                        if ((patrat[i - k, j - k].piesa.numePiesa == "nebun" || patrat[i - k, j - k].piesa.numePiesa == "regina") && patrat[i - k, j - k].piesa.piesaAlba != patrat[i, j].piesa.piesaAlba)
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
        }

        public int calculIndice(int f)
        {
            return (f - 105) / 60;
        }
        public int calculLocatie(int f)
        {
            return 60 * f + 105;
        }
    }
}
