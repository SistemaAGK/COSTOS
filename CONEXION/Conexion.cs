using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CONEXION
{
    public class Conexion
    {
        public SqlConnection obtenerConexion()
        {
            string cadConn = ConfigurationManager.ConnectionStrings["_Conexion"].ConnectionString;
            SqlConnection oconn = new SqlConnection(cadConn);
            oconn.Open();
            return oconn;
        }
        public DataTable listaRegistros(string name_sp)
        {
            using (SqlConnection oconn = obtenerConexion())
            {
                using (SqlCommand ocmd = new SqlCommand(name_sp, oconn))
                {
                    ocmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(ocmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    oconn.Close();
                    return dt;
                    //PRUEBA GITHUB
                }
            }
        }
        public DataTable filtrarRegistros(string name_sp, List<SqlParameter> parametros)
        {
            using (SqlConnection oconn = obtenerConexion())
            {
                using (SqlCommand ocmd = new SqlCommand(name_sp, oconn))
                {
                    ocmd.CommandType = CommandType.StoredProcedure;
                    foreach (SqlParameter param in parametros)
                    {
                        ocmd.Parameters.Add(param);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(ocmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    oconn.Close();
                    return dt;
                }
            }
        }
    }
}
