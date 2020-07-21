using System;
using System.Collections.Generic;
using CapaAccesoDatos;
using CapaEntidades;

namespace CapaLogicaNegocio
{
    public class SectorLN
    {
        #region "PATRON SINGLETON"

        private static SectorLN sector = null;

        private SectorLN()
        {
        }

        public static SectorLN getInstance()
        {
            if (sector == null) sector = new SectorLN();
            return sector;
        }

        #endregion

        public bool RegistrarMediciones(Sector objSector)
        {
            try
            {
                return SectorDAO.getInstance().RegistrarMediciones(objSector);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*
        public List<Reserva> Listar(int rut)
        {
            try
            {
                return ReservaDAO.getInstance().Listar(rut);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public bool Eliminar(int rut)
        {
            try
            {
                return ReservaDAO.getInstance().Eliminar(rut);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
*/
        /*
        
       

        */
    }
}