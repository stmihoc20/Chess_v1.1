using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Chess_v1._0
{
    public class Tabla
    {
        protected Patrat[,] patrat = new Patrat[8, 8];
        protected Dictionary<PictureBox, Piesa> p = new Dictionary<PictureBox, Piesa>();

        public Tabla(fGame f2)
        {
            //Initializare tabla
            for (int i=0; i<8; i++)
            {
                for(int j=0; j<8; j++)
                {
                    patrat[i, j] = new Patrat(i, j, f2);
                }
            }
            initializarePioni(f2);
            initializareTurnuri(f2);
            initializareCai(f2);
            initializareNebuni(f2);
            initializareRege(f2);
            initializareRegina(f2);
        }

        public void initializarePioni(fGame f2)
        {
            Pion[] pion = new Pion[16];
            PictureBox[] pionA = { f2.pionA0, f2.pionA1, f2.pionA2, f2.pionA3, f2.pionA4, f2.pionA5, f2.pionA6, f2.pionA7 };
            PictureBox[] pionB = { f2.pionN0, f2.pionN1, f2.pionN2, f2.pionN3, f2.pionN4, f2.pionN5, f2.pionN6, f2.pionN7 };
            int t;
            for (int i = 0; i < 8; i++)
            {
                t = 6;
                pionA[i].Tag = "alb";
                f2.Controls.SetChildIndex(pionA[i], 2);
                pion[i] = new Pion(i, t, pionA[i], true);
                patrat[i, t].piesa = pion[i];
                p.Add(pionA[i], pion[i]);
            }
            for (int i = 0; i < 8; i++)
            {
                t = 1;
                pionB[i].Tag = "negru";
                f2.Controls.SetChildIndex(pionA[i], 2);
                pion[i+8] = new Pion(i, t, pionB[i], false);
                patrat[i, t].piesa = pion[i+8];
                p.Add(pionB[i], pion[i + 8]);
            }
        }
        public void initializareTurnuri(fGame f2)
        {
            Turn[] turn = new Turn[4];
            PictureBox[] Turn = { f2.turnA0, f2.turnA1, f2.turnN0, f2.turnN1 };
            turn[0] = new Turn(0, 7, Turn[0], true);
            patrat[0, 7].piesa = turn[0];
            turn[1] = new Turn(7, 7, Turn[1], true);
            patrat[7, 7].piesa = turn[1];
            turn[2] = new Turn(0, 0, Turn[2], false);
            patrat[0, 0].piesa = turn[2];
            turn[3] = new Turn(7, 0, Turn[3], false);
            patrat[7, 0].piesa = turn[3];
            for (int i=0; i<4; i++)
            {
                p.Add(Turn[i], turn[i]);
                f2.Controls.SetChildIndex(Turn[i], 2);
                if (i < 2)
                {
                    Turn[i].Tag = "alb";
                }
                else
                {
                    Turn[i].Tag = "negru";
                }
            }
        }
        public void initializareCai(fGame f2)
        {
            Cal[] cal = new Cal[4];
            PictureBox[] Cal = { f2.calA0, f2.calA1, f2.calN0, f2.calN1 };
            cal[0] = new Cal(1, 7, Cal[0], true);
            patrat[1, 7].piesa = cal[0];
            cal[1] = new Cal(6, 7, Cal[1], true);
            patrat[6, 7].piesa = cal[1];
            cal[2] = new Cal(1, 0, Cal[2], false);
            patrat[1, 0].piesa = cal[2];
            cal[3] = new Cal(6, 0, Cal[3], false);
            patrat[6, 0].piesa = cal[3];

            for (int i = 0; i < 4; i++)
            {
                p.Add(Cal[i], cal[i]);
                f2.Controls.SetChildIndex(Cal[i], 2);
                if (i < 2)
                {
                    Cal[i].Tag = "alb";
                }
                else
                {
                    Cal[i].Tag = "negru";
                }
            }
        }
        public void initializareNebuni(fGame f2)
        {
            Nebun[] nebun = new Nebun[4];
            PictureBox[] Nebun = { f2.nebunA0, f2.nebunA1, f2.nebunN0, f2.NebunN1 };
            nebun[0] = new Nebun(2, 7, Nebun[0], true);
            patrat[2, 7].piesa = nebun[0];
            nebun[1] = new Nebun(5, 7, Nebun[1], true);
            patrat[5, 7].piesa = nebun[1];
            nebun[2] = new Nebun(2, 0, Nebun[2], false);
            patrat[2, 0].piesa = nebun[2];
            nebun[3] = new Nebun(5, 0, Nebun[3], false);
            patrat[5, 0].piesa = nebun[3];

            for (int i = 0; i < 4; i++)
            {
                p.Add(Nebun[i], nebun[i]);
                f2.Controls.SetChildIndex(Nebun[i], 2);
                if (i < 2)
                {
                    Nebun[i].Tag = "alb";
                }
                else
                {
                    Nebun[i].Tag = "negru";
                }
            }
        }
        public void initializareRege(fGame f2)
        {
            f2.regeA.Tag = "alb";
            patrat[4, 7].piesa = new Rege(4, 7, f2.regeA, true);
            p.Add(f2.regeA, patrat[4, 7].piesa);
            f2.Controls.SetChildIndex(f2.regeA, 2);

            f2.regeN.Tag = "negru";
            patrat[4, 0].piesa = new Rege(4, 0, f2.regeN, false);
            p.Add(f2.regeN, patrat[4, 0].piesa);
            f2.Controls.SetChildIndex(f2.regeN, 2);

        }
        public void initializareRegina(fGame f2)
        {
            f2.reginaA.Tag = "alb";
            patrat[3, 7].piesa = new Regina(3, 7, f2.reginaA, true);
            p.Add(f2.reginaA, patrat[3, 7].piesa);
            f2.Controls.SetChildIndex(f2.reginaA, 2);

            f2.reginaN.Tag = "negru";
            patrat[3, 0].piesa = new Regina(3, 0, f2.reginaN, false);
            p.Add(f2.reginaN, patrat[3, 0].piesa);
            f2.Controls.SetChildIndex(f2.reginaN, 2);
        }

        public void resetareCuloarePanouri()
        {
            for(int i=0; i<8; i++)
            {
                for(int j=0; j<8; j++)
                {
                    patrat[i, j].setCuloare();
                }
            }
        }
    }
}
