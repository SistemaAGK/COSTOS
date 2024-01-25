using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CONEXION;

namespace MANEJO_DATOS
{
    public class MD_TCAMBIO
    {
        Conexion oConn = new Conexion();
        public string insertTipoCambio(int anio, int periodo,  decimal cambio, int usuario)
        {

            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "[SP_GE_CAMBIO_INS]";
                        ocmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                        ocmd.Parameters.Add("@periodo", SqlDbType.Int).Value = periodo;
                        ocmd.Parameters.Add("@cambio", SqlDbType.Float).Value = cambio;
                        ocmd.Parameters.Add("@usuario", SqlDbType.Int).Value = usuario;
                        ocmd.ExecuteNonQuery();
                        oconexion.Close();
                    }
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public DataTable lstTipoCambio(int opc)
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            SqlParameter pOpc = new SqlParameter("@opc", opc);
            listP.Add(pOpc);
            return oConn.filtrarRegistros("SP_GE_CAMBIO_PPTO_LST", listP);
        }
        public string insertTipoCambioDiario(DateTime fecha, decimal tcambio)
        {

            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "[SP_GE_CAMBIO_DIARIO_INSERT]";
                        ocmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
                        ocmd.Parameters.Add("@tcambio", SqlDbType.Decimal).Value = tcambio;
                        ocmd.ExecuteNonQuery();
                        oconexion.Close();
                    }
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public DataTable lstTipoCambioDiario()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_CAMBIO_DIARIO_LST", listP);
        }
        /*TIPO DE CAMBIO MENSUAL - PROMEDIANDO TC DIARIO :: INICIO */
        public string insertTipoCambio_Mensual(int anio, int periodo, decimal cambio, string usuario)
        {

            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "[SP_GE_CAMBIO_MENSUAL_INSERT]";
                        ocmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                        ocmd.Parameters.Add("@periodo", SqlDbType.Int).Value = periodo;
                        ocmd.Parameters.Add("@cambio", SqlDbType.Float).Value = cambio;
                        ocmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                        ocmd.ExecuteNonQuery();
                        oconexion.Close();
                    }
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /*TIPO DE CAMBIO MENSUAL - PROMEDIANDO TC DIARIO :: FIN */
    }
}
