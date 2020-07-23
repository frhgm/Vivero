using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.Script.Serialization;
using Microsoft.Ajax.Utilities;
using CapaLogicaNegocio;
using System.Data;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;
namespace Vivero
{
    public partial class Medicion : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Run();
        }

        internal void Run()
        {
            int seconds = 10000;
            var timer = new System.Threading.Timer(TimerMethod,
                                  null,
                                  0,
                                  seconds);
        }

        private void TimerMethod(object o)
        {
            
            //System.Diagnostics.Debug.WriteLine(DateTime.Now);
            Sector();
            //Page.Response.Write("<script>console.log(' msg ');</script>");
        }

        public int temperaturaAleatoria;
        public double humedadAleatoria;



        public string GenerarPronostico()
        {
            string[] pronostico = new string[5];
            int indice;
            Random random = new Random();

            pronostico[0] = "Soleado";
            pronostico[1] = "Nublado";
            pronostico[2] = "Lloviendo";
            pronostico[3] = "Parcial";
            pronostico[4] = "Tormenta";

            indice = random.Next(0, 4);
            txtPronostico.Text = pronostico[indice];
            return pronostico[indice];
        }
        public Sector Estacion()
        {

            DateTime inicioVerano = new DateTime(2020, 01, 01);
            DateTime terminoVerano = new DateTime(2020, 03, 31);

            DateTime inicioOtono = new DateTime(2020, 04, 01);
            DateTime terminoOtono = new DateTime(2020, 06, 30);

            DateTime inicioInvierno = new DateTime(2020, 07, 01);
            DateTime terminoInvierno = new DateTime(2020, 09, 30);

            DateTime inicioPrimavera = new DateTime(2020, 10, 01);
            DateTime terminoPrimavera = new DateTime(2020, 12, 31);

            Sector sector = new Sector();

            if (sector.Temporada.Fecha > inicioVerano && sector.Temporada.Fecha < terminoVerano)
            {
                sector.Temporada.Estacion = "Verano";

                txtTemporada.Text = sector.Temporada.Estacion;
            }
            else if (sector.Temporada.Fecha > inicioOtono && sector.Temporada.Fecha < terminoOtono)
            {
                sector.Temporada.Estacion = "Otono";

                txtTemporada.Text = sector.Temporada.Estacion;
            }
            else if (sector.Temporada.Fecha > inicioInvierno && sector.Temporada.Fecha < terminoInvierno)
            {
                sector.Temporada.Estacion = "Invierno";

                txtTemporada.Text = sector.Temporada.Estacion;
            }
            else if (sector.Temporada.Fecha > inicioPrimavera && sector.Temporada.Fecha < terminoPrimavera)
            {
                sector.Temporada.Estacion = "Primavera";

                txtTemporada.Text = sector.Temporada.Estacion;
            }

            return sector;
        }
        public int randomTemperatura(int minimo, int maximo)
        {
            Random _random = new Random();
            temperaturaAleatoria = _random.Next(minimo, maximo);

            return temperaturaAleatoria;
        }

        public double randomHumedad(int minimo, int maximo)
        {
            Random _random = new Random();
            humedadAleatoria = _random.Next(minimo, maximo);

            return humedadAleatoria;
        }

        public Sector Hora()
        {
            Sector sector = new Sector();

            txtHorario.Text = sector.Horario.ToString("t");

            return sector;
        }

        public Temperatura TemperaturaActual()
        {
            int minimo;
            int maximo;
            Random _random = new Random();
            Temperatura temperatura = new Temperatura();


            if (Estacion().Temporada.Estacion.Equals("Verano"))
            {
                minimo = 17;
                maximo = 32;
                temperatura.Actual = randomTemperatura(minimo,maximo);
                txtTemperatura.Text = temperaturaAleatoria.ToString();
            }
            else if (Estacion().Temporada.Estacion.Equals("Otono"))
            {
                minimo = 13;
                maximo = 20;
                temperatura.Actual = randomTemperatura(minimo, maximo);
                txtTemperatura.Text = temperaturaAleatoria.ToString();
            }
            else if (Estacion().Temporada.Estacion.Equals("Invierno"))
            {
                minimo = 5;
                maximo = 17;
                temperatura.Actual = randomTemperatura(minimo, maximo);
                txtTemperatura.Text = temperaturaAleatoria.ToString();
            }
            else if (Estacion().Temporada.Estacion.Equals("Primavera"))
            {
                minimo = 16;
                maximo = 26;
                temperatura.Actual = randomTemperatura(minimo, maximo);
                txtTemperatura.Text = temperaturaAleatoria.ToString();
            }

            return temperatura;
        }

        public Sector HumedadActual()
        {
            int minimo;
            int maximo;
            Sector sector = new Sector();


            if (Estacion().Temporada.Estacion.Equals("Verano"))
            {
                minimo = 10;
                maximo = 40;
                sector.Humedad = randomHumedad(minimo, maximo);
                txtHumedad.Text = humedadAleatoria.ToString();
            }
            else if (Estacion().Temporada.Estacion.Equals("Otono"))
            {
                minimo = 40;
                maximo = 50;
                sector.Humedad = randomHumedad(minimo, maximo);
                txtHumedad.Text = humedadAleatoria.ToString();
            }
            else if (Estacion().Temporada.Estacion.Equals("Invierno"))
            {
                minimo = 50;
                maximo = 60;
                sector.Humedad = randomHumedad(minimo, maximo);
                txtHumedad.Text = humedadAleatoria.ToString();
            }
            else if (Estacion().Temporada.Estacion.Equals("Primavera"))
            {
                minimo = 30;
                maximo = 40;
                sector.Humedad = randomHumedad(minimo, maximo);
                txtHumedad.Text = humedadAleatoria.ToString();
            }
            
            return sector;
        }

        public void btnMedir_Click(object sender, EventArgs e)
        {
            Sector();
        }

        public Sector RecuperarDatos()
        {
            Sector sector = new Sector();

            sector.Temporada.Estacion = Estacion().Temporada.Estacion;
            sector.Horario = Hora().Horario;
            sector.Temperatura.Actual = TemperaturaActual().Actual;
            sector.Humedad -= 5;
            sector.Humedad = HumedadActual().Humedad;//RevisionHumedad().Humedad;
            sector.Pronostico = GenerarPronostico();
            sector.Regado = RevisionHumedad().Regado;//FueRegado()
            return sector;
        }
        /*
        protected bool FueRegado()
        {
            bool estado;
            if (RevisionHumedad().Humedad > 50)
            {
                estado = true;
            }
            else
            {
                estado = false;
            }

            return estado;
        }
        */
        public Sector RevisionHumedad()
        {
            Sector sector = new Sector();
            bool estado = false;
            double humedad = sector.Humedad;
            //VERANO
            if (Estacion().Temporada.Estacion.Equals("Verano"))
            {
                if (humedad > 20)
                {
                    humedad *= 1.25;
                    estado = true;
                    sector.Humedad = humedad;
                    sector.Regado = estado;
                    txtHumedad.Text = humedad.ToString();
                }
                else
                {
                    humedad = HumedadActual().Humedad;
                    sector.Humedad = humedad;
                    sector.Regado = estado;
                }
            }

            //OTOÑO
            if (Estacion().Temporada.Estacion.Equals("Otono"))
            {
                if (humedad > 30)
                {
                    humedad *= 1.25;
                    estado = true;
                    sector.Humedad = humedad;
                    sector.Regado = estado;
                    txtHumedad.Text = humedad.ToString();
                }
                else
                {
                    humedad = HumedadActual().Humedad;
                    sector.Humedad = humedad;
                    sector.Regado = estado;
                }
            }

            //INVIERNO
            if (Estacion().Temporada.Estacion.Equals("Invierno"))
            {
                if (humedad > 50)
                {
                    humedad *= 1.25;
                    estado = true;
                    sector.Humedad = humedad;
                    sector.Regado = estado;
                    txtHumedad.Text = humedad.ToString();
                }
                else
                {
                    humedad = HumedadActual().Humedad;
                    sector.Humedad = humedad;
                    sector.Regado = estado;
                }
            }

            //PRIMAVERA
            if (Estacion().Temporada.Estacion.Equals("Primavera"))
            {
                if (humedad > 30)
                {
                    humedad *= 1.25;
                    estado = true;
                    sector.Humedad = humedad;
                    sector.Regado = estado;
                    txtHumedad.Text = humedad.ToString();
                }
                else
                {
                    humedad = HumedadActual().Humedad;
                    sector.Humedad = humedad;
                    sector.Regado = estado;
                }
            }

            return sector;
        }

        public void Sector()
        {
            var objSector = RecuperarDatos();


            var response = SectorDAO.getInstance().RegistrarMediciones(objSector);

            if (response)
            {
                lblMensaje.Text = "Datos registrados";
                panelMensajes.CssClass = "alert-success text-center";
            }
            else
            {
                lblMensaje.Text =
                    "Revise los datos ingresados por favor, es posible que haya ingresado algo incorrectamente";
                panelMensajes.CssClass = "alert-warning text-center";
            }
        }

    }
}