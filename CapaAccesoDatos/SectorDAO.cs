using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidades;

namespace CapaLogicaNegocio
{
    public class SectorDAO
    {
        #region "PATRON SINGLETON"

        private static SectorDAO daoSector = null;

        private SectorDAO()
        {
        }

        public static SectorDAO getInstance()
        {
            if (daoSector == null) daoSector = new SectorDAO();
            return daoSector;
        }

        #endregion


        public bool RegistrarMediciones(Sector objSector)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            var response = false;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistrarMedicion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmHorario", objSector.Horario.ToString("t"));
                cmd.Parameters.AddWithValue("@prmTemporada", objSector.Temporada.Estacion);
                cmd.Parameters.AddWithValue("@prmTemperatura", objSector.Temperatura.Actual);
                cmd.Parameters.AddWithValue("@prmHumedad", objSector.Humedad);
                cmd.Parameters.AddWithValue("@prmPronostico", objSector.Pronostico);

                con.Open();
                var filas = cmd.ExecuteNonQuery();
                if (filas > 0) response = true;
            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }

            return response;
        }


        /*

        public List<Reserva> Listar(int rut)
        {
            SqlConnection conexion = Conexion.getInstance().ConexionBD();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Reserva> Lista = null;


            try
            {
                cmd = new SqlCommand("[spListaHorariosReserva]", conexion);
                cmd.Parameters.AddWithValue("@prmRut", rut);
                cmd.CommandType = CommandType.StoredProcedure;

                conexion.Open();

                dr = cmd.ExecuteReader();

                Lista = new List<Reserva>();

                while (dr.Read())
                {
                    // llenamos los objetos
                    Reserva reserva = new Reserva();
                    //DATOS RESERVA
                    reserva.Numero_Reserva = Convert.ToInt32(dr["n_reserva"].ToString());
                    reserva.Fecha = Convert.ToDateTime(dr["fecha"].ToString());
                    //DATOS BLOQUE
                    reserva.BloqueHora.Hora_Inicio = TimeSpan.Parse(dr["hora_inicio"].ToString());
                    reserva.BloqueHora.Hora_Final = TimeSpan.Parse(dr["hora_final"].ToString());

                    Lista.Add(reserva);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return Lista;
        }
        */
    }
}
