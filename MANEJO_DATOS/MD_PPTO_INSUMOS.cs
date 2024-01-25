using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CONEXION;

namespace MANEJO_DATOS
{
    public class MD_PPTO_INSUMOS
    {
        Conexion oConn = new Conexion();
        public string insertTempInsumo(int anio, int periodo, string cod_ceco, int cod_area, int cod_insumo, string desc_insumo, decimal cantidad)
        {
            try
            {
                /*using (var someResource = new SomeResource())
                {*/
                    using (SqlConnection oconexion = oConn.obtenerConexion())
                    {
                        using (SqlCommand ocmd = new SqlCommand())
                        {
                            ocmd.Connection = oconexion;
                            ocmd.CommandType = CommandType.StoredProcedure;
                            ocmd.CommandText = "SP_INS_TEMP_INSERT";
                            ocmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                            ocmd.Parameters.Add("@periodo", SqlDbType.Int).Value = periodo;
                            ocmd.Parameters.Add("@cod_ceco", SqlDbType.VarChar, 12).Value = cod_ceco;
                            ocmd.Parameters.Add("@cod_area", SqlDbType.Int).Value = cod_area;
                            ocmd.Parameters.Add("@cod_insumo", SqlDbType.Int).Value = cod_insumo;
                            ocmd.Parameters.Add("@desc_insumo", SqlDbType.VarChar, 120).Value = desc_insumo;
                            ocmd.Parameters.Add("@cantidad", SqlDbType.Float).Value = cantidad;
                            ocmd.ExecuteNonQuery();
                            oconexion.Close();
                        }
                    }
                   // someResource.Dispose();
               //*/ }*
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string deleteTempInsumo(int codigo)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_INS_TEMPORAL_PPTO_DELETE";
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
        public DataTable lstTemporalPPTO()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_INS_TEMP_LST", listP);
        }
        public string insertInsumoPPTO(int tusuario)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "[SP_INS_PPTO_READ_INSERT]";
                        ocmd.Parameters.Add("@tusuario", SqlDbType.Int).Value = tusuario;
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
        public DataTable lstPPTO(int sede, int fundo, int cultivo, int version)
        {
            List<SqlParameter> listP = new List<SqlParameter>();

            SqlParameter psede = new SqlParameter("@sede", sede);
            SqlParameter pfundo = new SqlParameter("@fundo", fundo);
            SqlParameter pcultivo = new SqlParameter("@cultivo", cultivo);
            SqlParameter pversion = new SqlParameter("@version", version);
            listP.Add(psede);
            listP.Add(pfundo);
            listP.Add(pcultivo);
            listP.Add(pversion);
            return oConn.filtrarRegistros("SP_INS_PPT_LST", listP);
        }
        public DataTable lstVersion(int indicador)
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            SqlParameter pindicador = new SqlParameter("@ind", indicador);
            listP.Add(pindicador);
            return oConn.filtrarRegistros("SP_GE_VER_PPTO_LST", listP);
        }
        public string opeReemplazo_DATA_PPTO()
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_INS_TEMP_PPTO_DELETE_EXISTENTES";
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
