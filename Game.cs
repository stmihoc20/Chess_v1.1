using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Chess_v1._0
{
    public class Game : Tabla
    {
        private Point MouseDownLocation;
        private int currentTurn = 0;
        private int zIndex;
        private bool esteSah = false;
        private fGame f2;
        private Piesa piesaMutata;

        public Game(fGame f2) : base(f2)
        {
            this.f2 = f2;
            ArrayList vectorPiese = new ArrayList(p.Values);

            //Legarea evenimentelor de fiecare piesa
            foreach (Piesa ctrl in vectorPiese)
            {
                ctrl.imagine.MouseDown += Piesa_MouseDown;
                ctrl.imagine.MouseMove += Piesa_MouseMove;
                ctrl.imagine.MouseUp += Piesa_MouseUp;
            }
        }

        private void Piesa_MouseDown(object sender, MouseEventArgs e)
        {
            //Salvam pozitia mouse-ului intr-o variabila
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
            //Imaginea este luata din sender si apoi este gasita piesa corespondenta in dictionar
            PictureBox piesa = sender as PictureBox;

            //Se deseneaza mutarile posibile pentru piesa
            if(currentTurn == 0)
                p[piesa].desenareAlbastru(patrat, currentTurn);
            else
                p[piesa].desenareAlbastru(patrat, currentTurn);

            //Se salveaza adancimea imaginii si apoi se aduce in prim plan
            zIndex = f2.Controls.GetChildIndex(piesa);
            piesa.BringToFront();
        }
        private void Piesa_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox piesa = sender as PictureBox;

            //Se calculeaza noua locatie a piesei in functie de MouseDownLocation
            if (e.Button == MouseButtons.Left && piesa.Left > 75 && piesa.Left < 555 && piesa.Top > 75 && piesa.Top < 555)
            {
                piesa.Left = e.X + piesa.Left - MouseDownLocation.X;
                piesa.Top = e.Y + piesa.Top - MouseDownLocation.Y;
            }
        }
        private void Piesa_MouseUp(object sender, MouseEventArgs e)
        {
            PictureBox piesa = sender as PictureBox;
            piesaMutata = p[piesa];
            Piesa rege1, rege2;

            //Salvam ultima pozitie a piesei
            int lastI = piesaMutata.GetI();
            int lastJ = piesaMutata.GetJ();

            //Mutam in prima faza piesa
            bool ok = piesaMutata.Muta(piesaMutata.calculIndice(piesa.Left + 25), piesaMutata.calculIndice(piesa.Top + 25), patrat);

            //Salvam noua pozitie a piesei
            int i = piesaMutata.GetI();
            int j = piesaMutata.GetJ();

            //Daca este ok putem testa daca este sah
            //Daca nu, mutam piesa inapoi
            if (ok)
            {
                Piesa copie;

                if (patrat[i, j].piesa != null)
                {
                    copie = patrat[i, j].piesa;
                    patrat[i, j].piesa.imagine.Visible = false;
                }
                else
                {
                    copie = null;
                    patrat[i, j].ocupat = true;
                }
                patrat[i, j].piesa = piesaMutata;
                patrat[lastI, lastJ].ocupat = false;

                if (currentTurn == 0)
                {
                    rege1 = p[f2.regeA];
                    rege2 = p[f2.regeN];
                }
                else
                {
                    rege1 = p[f2.regeN];
                    rege2 = p[f2.regeA];
                }

                if (esteSah)
                {
                    esteSah = piesaMutata.testareSah(patrat, rege1);

                    if (esteSah)
                    {
                        piesaMutata.Muta(lastI, lastJ, patrat, true);

                        patrat[lastI, lastJ].piesa = piesaMutata;
                        patrat[lastI, lastJ].ocupat = true;

                        if (copie != null)
                        {
                            patrat[i, j].piesa = copie;
                            patrat[i, j].piesa.imagine.Visible = true;
                        }
                        else
                        {
                            patrat[i, j].ocupat = false;
                        }
                    }
                    else
                    {
                        patrat[i, j].ocupat = true;
                        currentTurn = (currentTurn + 1) % 2;
                    }
                }
                else
                {


                    if (piesaMutata.testareSah(patrat, rege1))
                    {
                        piesaMutata.Muta(lastI, lastJ, patrat, true);

                        patrat[lastI, lastJ].piesa = piesaMutata;
                        patrat[lastI, lastJ].ocupat = true;

                        if (copie != null)
                        {
                            patrat[i, j].piesa = copie;
                            patrat[i, j].piesa.imagine.Visible = true;
                        }
                        else
                        {
                            patrat[i, j].ocupat = false;
                        }
                    }
                    else
                    {
                        patrat[i, j].ocupat = true;

                        esteSah = piesaMutata.testareSah(patrat, rege2);
                        currentTurn = (currentTurn + 1) % 2;
                    }
                }
            }

            resetareCuloarePanouri();

            if (piesaMutata.numePiesa == "pion" && (j == 0 || j == 7 ) && ok)
            {
                fDialog f3 = new fDialog(f2, piesaMutata);
                piesaMutata.imagine.Visible = false;
                piesaMutata = f3.transformare();

                patrat[i, j].piesa = piesaMutata;
                p.Add(piesaMutata.imagine, piesaMutata);

                piesaMutata.imagine.MouseDown += Piesa_MouseDown;
                piesaMutata.imagine.MouseMove += Piesa_MouseMove;
                piesaMutata.imagine.MouseUp += Piesa_MouseUp;
            }

            //Resetarea adancimii imaginii
            f2.Controls.SetChildIndex(piesa, zIndex);
        }

    }
}
