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
using System.Data.SqlClient;
using System.Configuration;

namespace Vivero
{
    public partial class Medicion : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected Sector Estacion()
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

        protected Sector Hora()
        {
            Sector sector = new Sector();

            txtHorario.Text = sector.Horario.ToString("t");

            return sector;
        }

        protected Temperatura TemperaturaActual()
        {
            int minimo;
            int maximo;
            Random _random = new Random();
            Temperatura temperatura = new Temperatura();
            

            if (Estacion().Temporada.Estacion.Equals("Verano")){
                minimo = 17;
                maximo = 32;
                temperatura.Actual = _random.Next(minimo, maximo);
                txtTemperatura.Text = _random.Next(minimo, maximo).ToString();
            }
            else if (Estacion().Temporada.Estacion.Equals("Otono"))
            {
                minimo = 13;
                maximo = 20;
                temperatura.Actual = _random.Next(minimo, maximo);
                txtTemperatura.Text = _random.Next(minimo, maximo).ToString();
            }
            else if (Estacion().Temporada.Estacion.Equals("Invierno"))
            {
                minimo = 5;
                maximo = 17;
                temperatura.Actual = _random.Next(minimo, maximo);
                txtTemperatura.Text = _random.Next(minimo, maximo).ToString();
            }
            else if (Estacion().Temporada.Estacion.Equals("Primavera"))
            {
                minimo = 16;
                maximo = 26;
                temperatura.Actual = _random.Next(minimo, maximo);
                txtTemperatura.Text = _random.Next(minimo, maximo).ToString();
            }

            return temperatura;
        }

        protected Sector HumedadActual()
        {
            int minimo;
            int maximo;
            Random _random = new Random();
            Sector sector = new Sector();


            if (Estacion().Temporada.Estacion.Equals("Verano"))
            {
                minimo = 10;
                maximo = 40;
                sector.Humedad = _random.Next(minimo, maximo);
                txtHumedad.Text = _random.Next(minimo, maximo).ToString();
            }
            else if (Estacion().Temporada.Estacion.Equals("Otono"))
            {
                minimo = 40;
                maximo = 50;
                sector.Humedad = _random.Next(minimo, maximo);
                txtHumedad.Text = _random.Next(minimo, maximo).ToString();
            }
            else if (Estacion().Temporada.Estacion.Equals("Invierno"))
            {
                minimo = 50;
                maximo = 60;
                sector.Humedad = _random.Next(minimo, maximo);
                txtHumedad.Text = _random.Next(minimo, maximo).ToString();
            }
            else if (Estacion().Temporada.Estacion.Equals("Primavera"))
            {
                minimo = 30;
                maximo = 40;
                sector.Humedad = _random.Next(minimo, maximo);
                txtHumedad.Text = _random.Next(minimo, maximo).ToString();
            }
            return sector;
        }
        protected void btnMedir_Click(object sender, EventArgs e)
        {
            Sector();
        }

        protected Sector RecuperarDatos()
        {
            Sector sector = new Sector();

            sector.Temporada.Estacion = Estacion().Temporada.Estacion;
            sector.Horario = Hora().Horario;
            sector.Temperatura.Actual = TemperaturaActual().Actual;
            sector.Humedad = CalorExtremo();
            sector.Pronostico = "Soleado";
            return sector;
        }

        protected double CalorExtremo()
        {
            double humedad = RecuperarDatos().Humedad;
            //VERANO
            if (RecuperarDatos().Temporada.Estacion.Equals("Verano"))
            {
                if(RecuperarDatos().Humedad < 30)
                {
                    humedad = humedad * 1.25;
                }
                else
                {
                    humedad = RecuperarDatos().Humedad;
                }
            }
            //OTOÑO
            if (RecuperarDatos().Temporada.Estacion.Equals("Otono"))
            {
                if (RecuperarDatos().Humedad < 40)
                {
                    humedad = humedad * 1.25;
                }
                else
                {
                    humedad = RecuperarDatos().Humedad;
                }
            }
            //INVIERNO
            if (RecuperarDatos().Temporada.Estacion.Equals("Invierno"))
            {
                if (RecuperarDatos().Humedad < 60)
                {
                    humedad = humedad * 1.25;
                }
                else
                {
                    humedad = RecuperarDatos().Humedad;
                }
            }
            //PRIMAVERA
            if (RecuperarDatos().Temporada.Estacion.Equals("Primavera"))
            {
                if (RecuperarDatos().Humedad < 40)
                {
                    humedad = humedad * 1.25;
                }
                else
                {
                    humedad = RecuperarDatos().Humedad;
                }
            }
            return humedad;
        }

        protected void Sector()
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
                lblMensaje.Text = "Revise los datos ingresados por favor, es posible que haya ingresado algo incorrectamente";
                panelMensajes.CssClass = "alert-warning text-center";
            }
        }



        

    }
}