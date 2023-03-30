using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_v1._0
{
    class Regina: Piesa
    {
        public Regina(int i, int j, PictureBox regina0, bool piesaAlba) : base(i, j, piesaAlba)
        {
            numePiesa = "regina";
            imagine = regina0;
            imagine.Location = new Point(calculLocatie(i), calculLocatie(j));
        }

        override public void desenareAlbastru(Patrat[,] patrat, int currentTurn)
        {
            if (currentTurn == 0 && imagine.Tag.ToString() == "alb")
            {
                desenareRegina(patrat, currentTurn);
            }
            else if (currentTurn == 1 && imagine.Tag.ToString() == "negru")
            {
                desenareRegina(patrat, currentTurn);
            }
        }
        public void desenareRegina(Patrat [,] patrat, int currentTurn)
        {
            bool[] flags = { true, true, true, true };
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

            for (int k = 1; k < 8; k++)
            {
                if (i + k < 8)
                {
                    if (!patrat[i + k, j].ocupat)
                        patrat[i + k, j].getPanel().BackColor = Color.Blue;
                    else if (currentTurn == 0 && !patrat[i + k, j].piesa.piesaAlba)
                    {
                        patrat[i + k, j].getPanel().BackColor = Color.Blue;
                        break;
                    }
                    else if (currentTurn == 1 && patrat[i + k, j].piesa.piesaAlba)
                    {
                        patrat[i + k, j].getPanel().BackColor = Color.Blue;
                        break;
                    }
                    else
                        break;
                }
                else
                    break;
            }
            for (int k = 1; k < 8; k++)
            {
                if (i - k >= 0)
                {
                    if (!patrat[i - k, j].ocupat)
                        patrat[i - k, j].getPanel().BackColor = Color.Blue;
                    else if (currentTurn == 0 && !patrat[i - k, j].piesa.piesaAlba)
                    {
                        patrat[i - k, j].getPanel().BackColor = Color.Blue;
                        break;
                    }
                    else if (currentTurn == 1 && patrat[i - k, j].piesa.piesaAlba)
                    {
                        patrat[i - k, j].getPanel().BackColor = Color.Blue;
                        break;
                    }
                    else
                        break;
                }
                else
                    break;
            }
            for (int k  = 1; k < 8; k++)
            {
                if (j + k < 8)
                {
                    if (!patrat[i, j + k].ocupat)
                        patrat[i, j + k].getPanel().BackColor = Color.Blue;
                    else if (currentTurn == 0 && !patrat[i, j + k].piesa.piesaAlba)
                    {
                        patrat[i, j + k].getPanel().BackColor = Color.Blue;
                        break;
                    }
                    else if (currentTurn == 1 && patrat[i, j + k].piesa.piesaAlba)
                    {
                        patrat[i, j + k].getPanel().BackColor = Color.Blue;
                        break;
                    }
                    else
                        break;
                }
                else
                    break;
            }
            for (int k = 1; k < 8; k++)
            {
                if (j - k >= 0)
                {
                    if (!patrat[i, j - k].ocupat)
                        patrat[i, j - k].getPanel().BackColor = Color.Blue;
                    else if (currentTurn == 0 && !patrat[i, j - k].piesa.piesaAlba)
                    {
                        patrat[i, j - k].getPanel().BackColor = Color.Blue;
                        break;
                    }
                    else if (currentTurn == 1 && patrat[i, j - k].piesa.piesaAlba)
                    {
                        patrat[i, j - k].getPanel().BackColor = Color.Blue;
                        break;
                    }
                    else
                        break;
                }
                else
                    break;
            }
        }

        /*override public bool testareSah(Patrat[,] patrat, Piesa rege)
        {
            int i = rege.GetI();
            int j = rege.GetJ();
            for (int k = 1; k < 8; k++)
            {
                if (i + k < 8)
                {
                    if (patrat[i + k, j].ocupat)
                    {
                        if (patrat[i + k, j].piesa.numePiesa == "regina" && patrat[i + k, j].piesaAlba != patrat[i, j].piesaAlba)
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
            for (int k = 1; k < 8; k++)
            {
                if (i - k >= 0)
                {
                    if (patrat[i - k, j].ocupat)
                    {
                        if (patrat[i - k, j].piesa.numePiesa == "regina" && patrat[i - k, j].piesaAlba != patrat[i, j].piesaAlba)
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
            for (int k = 1; k < 8; k++)
            {
                if (j + k < 8)
                {
                    if (patrat[i, j + k].ocupat)
                    {
                        if (patrat[i, j + k].piesa.numePiesa == "regina" && patrat[i, j + k].piesaAlba != patrat[i, j].piesaAlba)
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
            for (int k = 1; k < 8; k++)
            {
                if (j - k >= 0)
                {
                    if (patrat[i, j - k].ocupat)
                    {
                        if (patrat[i, j - k].piesa.numePiesa == "regina" && patrat[i, j - k].piesaAlba != patrat[i, j].piesaAlba)
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

            bool[] flags = { true, true, true, true };
            for (int k = 1; k < 8; k++)
            {
                if (i + k < 8 && j + k < 8 && flags[0])
                {
                    if (patrat[i + k, j + k].ocupat)
                    {
                        if (patrat[i + k, j + k].piesa.numePiesa == "regina" && patrat[i + k, j + k].piesaAlba != patrat[i, j].piesaAlba)
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
                        if (patrat[i + k, j - k].piesa.numePiesa == "regina" && patrat[i + k, j - k].piesaAlba != patrat[i, j].piesaAlba)
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
                        if (patrat[i - k, j + k].piesa.numePiesa == "regina" && patrat[i - k, j + k].piesaAlba != patrat[i, j].piesaAlba)
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
                        if (patrat[i - k, j - k].piesa.numePiesa == "regina" && patrat[i - k, j - k].piesaAlba != patrat[i, j].piesaAlba)
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
