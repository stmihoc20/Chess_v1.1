using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_v1._0
{
    public class Pozitie
    {
        protected int i;
        protected int j;

        public Pozitie(int i ,int j)
        {
            this.i = i;
            this.j = j;
        }

        public int GetI()
        {
            return i;
        }
        public int GetJ()
        {
            return j;
        }
    }
}
