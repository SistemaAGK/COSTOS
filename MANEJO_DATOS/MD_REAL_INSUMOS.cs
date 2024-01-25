using CONEXION;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MANEJO_DATOS
{
    public  class MD_REAL_INSUMOS
    {
        Conexion oConn = new Conexion();

        public string insertTempREAL(string cod_ceco, int cod_area, int cod_insumo, string desc_insumo, DateTime fecha, 
                                        int anio, int periodo, decimal cantidad_cons, decimal cst_cons_PES,
                                        string usuario_alm, string num_doc_ref, string usuario_solic, string num_documen, string clase, int indicativo)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "[SP_INS_TEMP_REAL_INSERT]";
                        ocmd.Parameters.Add("@cod_ceco", SqlDbType.VarChar, 20).Value = cod_ceco;
                        ocmd.Parameters.Add("@cod_area", SqlDbType.Int).Value = cod_area;
                        ocmd.Parameters.Add("@cod_insumo", SqlDbType.Int).Value = cod_insumo;
                        ocmd.Parameters.Add("@desc_insumo", SqlDbType.VarChar, 120).Value = desc_insumo;
                        ocmd.Parameters.Add("@fecha", SqlDbType.DateTime).Value = fecha;
                        ocmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                        ocmd.Parameters.Add("@periodo", SqlDbType.Int).Value = periodo;
                        ocmd.Parameters.Add("@cantidad_cons", SqlDbType.Float).Value = cantidad_cons;
                        ocmd.Parameters.Add("@cst_cons_PES", SqlDbType.Float).Value = cst_cons_PES;
                        ocmd.Parameters.Add("@usuario_alm", SqlDbType.VarChar, 40).Value = usuario_alm;
                        ocmd.Parameters.Add("@num_doc_ref", SqlDbType.VarChar, 50).Value = num_doc_ref;
                        ocmd.Parameters.Add("@usuario_solic", SqlDbType.VarChar, 80).Value = usuario_solic;
                        ocmd.Parameters.Add("@num_documen", SqlDbType.VarChar, 50).Value = num_documen;
                        ocmd.Parameters.Add("@clase", SqlDbType.VarChar, 10).Value = clase;
                        ocmd.Parameters.Add("@indicativo", SqlDbType.Int).Value = indicativo;
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
        public string deleteTempREAL( int codigo)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "[SP_INS_TEMPORAL_REAL_DELETE]";
                        ocmd.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo;
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
        public DataTable lstTemporalREAL()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("[SP_INS_TEMP_REAL_LST]", listP);
        }
        public string insertREAL(int log)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "[SP_INS_REAL_READ_INSERT]";
                        ocmd.Parameters.Add("@log", SqlDbType.Int).Value = log;
                        ocmd.CommandTimeout = 900000;
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

        public DataTable lstREAL(int opc, int sede, int fundo, int cultivo)
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            SqlParameter popc = new SqlParameter("@opc", opc);
            SqlParameter psede = new SqlParameter("@sede", sede);
            SqlParameter pfundo = new SqlParameter("@fundo", fundo);
            SqlParameter pcultivo = new SqlParameter("@cultivo", cultivo);
            listP.Add(popc);
            listP.Add(psede);
            listP.Add(pfundo);
            listP.Add(pcultivo);
            return oConn.filtrarRegistros("SP_REAL_LST", listP);
        }
        public string opeReemplazo_DATA_REAL()
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_INS_TEMP_REAL_DELETE_EXISTENTES";
                        ocmd.CommandTimeout = 900000;
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
    }
}
