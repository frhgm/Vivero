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
        public double Humedad_Inicial { get; set; }
        public double Humedad_Final { get; set; }
        public string Pronostico { get; set; }
        public bool Regado { get; set; }


        public Sector() : this(DateTime.Now, new Temporada(), new Temperatura(), 5.3,8.0, "", false) { }

        public Sector(DateTime _horario, Temporada _temporada, Temperatura _temperatura, double _humedad_inicial,double _humedad_final, string _pronostico, bool _regado)
        {
            this.Horario = _horario;
            this.Temporada = _temporada;
            this.Temperatura = _temperatura;
            this.Humedad_Inicial = _humedad_inicial;
            this.Humedad_Final = _humedad_final;
            this.Pronostico = _pronostico;
            this.Regado = _regado;
        }
    }
}
