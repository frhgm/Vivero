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
            Response.AppendHeader("Refresh", "3");
            Run();
        }

        internal void Run()
        {
            int seconds = 5000;
            var timer = new System.Threading.Timer(TimerMethod,
                                  null,
                                  0,
                                  seconds);
        }

        private void TimerMethod(object o)
        {
            Sector();
            MostrarDatos();
        }

        

        public int temperaturaAleatoria;
        public double humedadAleatoria;
        List<double> registroHumedad = new List<double>();



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
                sector.Humedad_Inicial = randomHumedad(minimo, maximo);
                txtHumedad_Inicial.Text = sector.Humedad_Inicial.ToString();
                registroHumedad.Add(sector.Humedad_Inicial);
            }
            else if (Estacion().Temporada.Estacion.Equals("Otono"))
            {
                minimo = 40;
                maximo = 70;
                sector.Humedad_Inicial = randomHumedad(minimo, maximo);
                txtHumedad_Inicial.Text = sector.Humedad_Inicial.ToString();
                registroHumedad.Add(sector.Humedad_Inicial);
            }
            else if (Estacion().Temporada.Estacion.Equals("Invierno"))
            {
                minimo = 70;
                maximo = 100;
                sector.Humedad_Inicial = randomHumedad(minimo, maximo);
                txtHumedad_Inicial.Text = sector.Humedad_Inicial.ToString();
                registroHumedad.Add(sector.Humedad_Inicial);
            }
            else if (Estacion().Temporada.Estacion.Equals("Primavera"))
            {
                minimo = 20;
                maximo = 50;
                sector.Humedad_Inicial = randomHumedad(minimo, maximo);
                txtHumedad_Inicial.Text = sector.Humedad_Inicial.ToString();
                registroHumedad.Add(sector.Humedad_Inicial);
            }
            
            return sector;
        }
//

        public Sector RecuperarDatos()
        {
            Sector sector = new Sector();

            sector.Temporada.Estacion = Estacion().Temporada.Estacion;
            sector.Horario = Hora().Horario;
            sector.Temperatura.Actual = TemperaturaActual().Actual;
            sector.Humedad_Inicial = RevisionHumedad().Humedad_Inicial;
            sector.Humedad_Final = RevisionHumedad().Humedad_Final;
            sector.Pronostico = GenerarPronostico();
            sector.Regado = RevisionHumedad().Regado;
            return sector;
        }
       
        public void MostrarDatos()
        {
            txtTemporada.Text = RecuperarDatos().Temporada.Estacion;
            txtHorario.Text = RecuperarDatos().Horario.ToString();
            txtTemperatura.Text = RecuperarDatos().Temperatura.Actual.ToString();
            txtHumedad_Inicial.Text = RecuperarDatos().Humedad_Inicial.ToString();
            txtHumedad_Final.Text = RecuperarDatos().Humedad_Final.ToString();
            txtPronostico.Text = RecuperarDatos().Pronostico;
            txtRegado.Text = RecuperarDatos().Regado.ToString();

        }

        public Sector RevisionHumedad()
        {
            Sector sector = new Sector();
            bool estado = false;
            double humedad_inicial = HumedadActual().Humedad_Inicial;
            double humedad_final = sector.Humedad_Final;
            //VERANO
            if (Estacion().Temporada.Estacion.Equals("Verano"))
            {
                if (humedad_inicial < 20)
                {
                    humedad_final = humedad_inicial * 1.25;
                    estado = true;
                    sector.Humedad_Inicial = humedad_inicial;
                    sector.Humedad_Final = humedad_final;
                    txtHumedad_Inicial.Text = humedad_inicial.ToString();
                    txtHumedad_Final.Text = humedad_final.ToString();

                    txtRegado.Text = estado.ToString();
                    sector.Regado = estado;
                }
                else
                {
                    humedad_inicial = HumedadActual().Humedad_Inicial;
                    humedad_final = humedad_inicial;
                    sector.Humedad_Inicial = humedad_inicial;
                    sector.Humedad_Final = humedad_final;
                    txtHumedad_Inicial.Text = humedad_inicial.ToString();
                    txtHumedad_Final.Text = humedad_final.ToString();

                    txtRegado.Text = estado.ToString();
                    sector.Regado = estado;
                }
            }
            //OTOÑO
            if (Estacion().Temporada.Estacion.Equals("Otono"))
            {
                humedad_inicial = HumedadActual().Humedad_Inicial;
                sector.Humedad_Inicial = humedad_inicial;
                sector.Humedad_Final = humedad_inicial;
                txtHumedad_Inicial.Text = sector.Humedad_Inicial.ToString();
                txtHumedad_Final.Text = sector.Humedad_Final.ToString();

                txtRegado.Text = estado.ToString();
                sector.Regado = estado;
            }

            //INVIERNO
            if (Estacion().Temporada.Estacion.Equals("Invierno"))
            {

                humedad_inicial = HumedadActual().Humedad_Inicial;
                sector.Humedad_Inicial = humedad_inicial;
                sector.Humedad_Final = humedad_inicial;
                txtHumedad_Inicial.Text = sector.Humedad_Inicial.ToString();
                txtHumedad_Final.Text = sector.Humedad_Final.ToString();

                txtRegado.Text = estado.ToString();
                sector.Regado = estado;
                
            }
            
            //PRIMAVERA
            if (Estacion().Temporada.Estacion.Equals("Primavera"))
            {
                if (humedad_inicial < 30)
                {
                    humedad_final = humedad_inicial * 1.25;
                    estado = true;
                    sector.Humedad_Inicial = humedad_inicial;
                    sector.Humedad_Final = humedad_final;
                    txtHumedad_Inicial.Text = humedad_inicial.ToString();
                    txtHumedad_Final.Text = humedad_final.ToString();

                    txtRegado.Text = estado.ToString();
                    sector.Regado = estado;
                }
                else
                {
                    humedad_inicial = HumedadActual().Humedad_Inicial;
                    humedad_final = humedad_inicial;
                    sector.Humedad_Inicial = humedad_inicial;
                    sector.Humedad_Final = humedad_final;
                    txtHumedad_Inicial.Text = humedad_inicial.ToString();
                    txtHumedad_Final.Text = humedad_final.ToString();

                    txtRegado.Text = estado.ToString();
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
                lblMensaje.Text = "Datos registrados con una temperatura de: C°" + objSector.Temperatura;
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