using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Temporada
    {
        public string Estacion { get; set; }
        public DateTime Fecha { get; set; }
        public Temperatura Minimo { get; set; }
        public Temperatura Maximo { get; set; }

        public Temporada() : this("", DateTime.Today, new Temperatura(), new Temperatura()) { }

        public Temporada(string _estacion, DateTime _fecha, Temperatura _minimo,Temperatura _maximo)
        {
            this.Estacion = _estacion;
            this.Fecha = _fecha;
            this.Minimo = _minimo;
            this.Maximo = _maximo;
        }
    }
}
