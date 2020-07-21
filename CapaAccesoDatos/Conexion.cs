﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class Conexion
    {
        #region "PATRON SINGLETON"

        private static Conexion conexion = null;

        private Conexion()
        {
        }

        public static Conexion getInstance()
        {
            if (conexion == null) conexion = new Conexion();
            return conexion;
        }

        #endregion

        public SqlConnection ConexionBD()
        {
            var conexion = new SqlConnection();
            conexion.ConnectionString =
                "Data Source=(local);Initial Catalog=Vivero;Integrated Security=True";

            return conexion;
        }
    }
}