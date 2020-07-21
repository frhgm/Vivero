using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Temperatura
    {
        public int Minimo { get; set; }
        public int Maximo { get; set; }
        public int Actual { get; set; }


        public Temperatura() : this(0,100,50) { }

        public Temperatura(int _minimo, int _maximo, int _actual)
        {
            this.Minimo = _minimo;
            this.Maximo = _maximo;
            this.Actual = _actual;
        }
    }

}
