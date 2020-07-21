using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Sector
    {

        public DateTime Horario { get; set; }
        public Temporada Temporada { get; set; }
        public Temperatura Temperatura { get; set; }
        public double Humedad { get; set; }
        public string Pronostico { get; set; }


        public Sector() : this(DateTime.Now, new Temporada(), new Temperatura(), 5.3, "") { }

        public Sector(DateTime _horario, Temporada _temporada, Temperatura _temperatura, double _humedad, string _pronostico)
        {
            this.Horario = _horario;
            this.Temporada = _temporada;
            this.Temperatura = _temperatura;
            this.Humedad = _humedad;
            this.Pronostico = _pronostico;
        }
    }
}
