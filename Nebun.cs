using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_v1._0
{
    class Nebun: Piesa
    {
        public Nebun(int i, int j, PictureBox nebun0, bool piesaAlba) : base(i, j, piesaAlba)
        {
            numePiesa = "nebun";
            imagine = nebun0;
            imagine.Location = new Point(calculLocatie(i), calculLocatie(j));
        }

        override public void desenareAlbastru(Patrat[,] patrat, int currentTurn)
        {
            if (currentTurn == 0 && imagine.Tag.ToString() == "alb")
            {
                desenareNebun(patrat, currentTurn);
            }
            else if (currentTurn == 1 && imagine.Tag.ToString() == "negru")
            {
                desenareNebun(patrat, currentTurn);
            }
        }
        public void desenareNebun(Patrat [,] patrat, int currentTurn)
        {
            bool []flags = { true, true, true, true };
            for (int k = 1; k < 8; k++)
            {
                if (i + k < 8 && j + k < 8 && flags[0])
                {
                    if (!patrat[i + k, j + k].ocupat)
                        patrat[i + k, j + k].getPanel().BackColor = Color.Blue;
                    else if (currentTurn == 0 && !patrat[i + k, j + k].piesa.piesaAlba)
                    {
                        patrat[i + k, j + k].getPanel().BackColor = Color.Blue;
                        flags[0] = false;
                    }
                    else if (currentTurn == 1 && patrat[i + k, j + k].piesa.piesaAlba)
                    {
                        patrat[i + k, j + k].getPanel().BackColor = Color.Blue;
                        flags[0] = false;
                    }
                    else
                        flags[0] = false;

                }
                else
                    flags[0] = false;
                if (i + k < 8 && j - k >= 0 && flags[1])
                {
                    if (!patrat[i + k, j - k].ocupat)
                        patrat[i + k, j - k].getPanel().BackColor = Color.Blue;
                    else if (currentTurn == 0 && !patrat[i + k, j - k].piesa.piesaAlba)
                    {
                        patrat[i + k, j - k].getPanel().BackColor = Color.Blue;
                        flags[1] = false;
                    }
                    else if (currentTurn == 1 && patrat[i + k, j - k].piesa.piesaAlba)
                    {
                        patrat[i + k, j - k].getPanel().BackColor = Color.Blue;
                        flags[1] = false;
                    }
                    else
                        flags[1] = false;
                }
                else
                    flags[1] = false;
                if (i - k >= 0 && j + k < 8 && flags[2])
                {
                    if (!patrat[i - k, j + k].ocupat)
                        patrat[i - k, j + k].getPanel().BackColor = Color.Blue;
                    else if (currentTurn == 0 && !patrat[i - k, j + k].piesa.piesaAlba)
                    {
                        patrat[i - k, j + k].getPanel().BackColor = Color.Blue;
                        flags[2] = false;
                    }
                    else if (currentTurn == 1 && patrat[i - k, j + k].piesa.piesaAlba)
                    {
                        patrat[i - k, j + k].getPanel().BackColor = Color.Blue;
                        flags[2] = false;
                    }
                    else
                        flags[2] = false;
                }
                else
                    flags[2] = false;
                if (i - k >= 0 && j - k >= 0 && flags[3])
                {
                    if (!patrat[i - k, j - k].ocupat)
                        patrat[i - k, j - k].getPanel().BackColor = Color.Blue;
                    else if (currentTurn == 0 && !patrat[i - k, j - k].piesa.piesaAlba)
                    {
                        patrat[i - k, j - k].getPanel().BackColor = Color.Blue;
                        flags[3] = false;
                    }
                    else if (currentTurn == 1 && patrat[i - k, j - k].piesa.piesaAlba)
                    {
                        patrat[i - k, j - k].getPanel().BackColor = Color.Blue;
                        flags[3] = false;
                    }
                    else
                        flags[3] = false;
                }
                else
                    flags[3] = false;
            }
        }

        /*override public bool testareSah(Patrat[,] patrat, Piesa rege)
        {
            int i = rege.GetI();
            int j = rege.GetJ();
            bool[] flags = { true, true, true, true };
            for (int k = 1; k < 8; k++)
            {
                if (i + k < 8 && j + k < 8 && flags[0])
                {
                    if (patrat[i + k, j + k].ocupat)
                    {
                        if (patrat[i + k, j + k].piesa.numePiesa == "nebun" && patrat[i + k, j + k].piesaAlba != patrat[i, j].piesaAlba)
                        {
                            patrat[i, j].getPanel().BackColor = Color.Red;
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
                        if (patrat[i + k, j - k].piesa.numePiesa == "nebun" && patrat[i + k, j - k].piesaAlba != patrat[i, j].piesaAlba)
                        {
                            patrat[i, j].getPanel().BackColor = Color.Red;
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
                        if (patrat[i - k, j + k].piesa.numePiesa == "nebun" && patrat[i - k, j + k].piesaAlba != patrat[i, j].piesaAlba)
                        {
                            patrat[i, j].getPanel().BackColor = Color.Red;
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
                        if (patrat[i - k, j - k].piesa.numePiesa == "nebun" && patrat[i - k, j - k].piesaAlba != patrat[i, j].piesaAlba)
                        {
                            patrat[i, j].getPanel().BackColor = Color.Red;
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
