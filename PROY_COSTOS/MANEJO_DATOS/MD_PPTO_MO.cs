using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CONEXION;
using System.Threading.Tasks;

namespace MANEJO_DATOS
{
    public class MD_PPTO_MO
    {
        Conexion oConn = new Conexion();
        public DataTable lstSedes()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_SEDE_LST", listP);
        }
        public DataTable lstAño()
        {
            List<SqlParameter> listP = new List<SqlParameter>();

            return oConn.filtrarRegistros("SP_GE_CAMPANIA_LST", listP);
        }
        public string opeTmpPptoMO(int nume_lin, string cod_ceco, int cod_labor, int nume_ano, int nume_mes, decimal jornal)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_MO_TMP_PPTO_INSERT";

                        ocmd.Parameters.Add("@nume_lin", SqlDbType.Int).Value = nume_lin;
                        ocmd.Parameters.Add("@cod_ceco", SqlDbType.VarChar, 20).Value = cod_ceco;
                        ocmd.Parameters.Add("@cod_labor", SqlDbType.Int).Value = cod_labor;
                        ocmd.Parameters.Add("@nume_ano", SqlDbType.Int).Value = nume_ano;
                        ocmd.Parameters.Add("@nume_mes", SqlDbType.Int).Value = nume_mes;
                        ocmd.Parameters.Add("@jornales", SqlDbType.Decimal, 18).Value = jornal;

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
        public string opeTmpDeletePptoMO()
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_MO_TMP_PPTO_DELETE";

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
        public string opeTmpUpdatePptoMO()
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_MO_TMP_PPTO_UPDATE";

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
        public string opeTmpViewPptoMO()
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_MO_TMP_PPTO_SHOW";

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
        public DataTable lstLog()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.listaRegistros("SP_MO_TMP_PPTO_SHOW");
        }
        public DataTable lstBrief()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.listaRegistros("SP_MO_TMP_PPTO_SHOW_BRIEF");
        }
        public DataTable lstVersionesPptoMO(int campania)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_MO_PPTO_VER_LST";
                        ocmd.Parameters.Add("@cod_campania", SqlDbType.Int).Value = campania;

                        SqlDataAdapter da = new SqlDataAdapter(ocmd);
                        da.Fill(dt);
                        da.Dispose();
                        oconexion.Close();
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
        public string opeUpdatePptoMO(int campaña, int version, int nva_version)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_MO_PPTO_UPDATE";

                        ocmd.Parameters.Add("@cod_campania", SqlDbType.Int).Value = campaña;
                        ocmd.Parameters.Add("@cod_ver", SqlDbType.Int).Value = version;
                        ocmd.Parameters.Add("@nva_version", SqlDbType.Int).Value = nva_version;

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
        public DataTable lstPptoMO(int campania, int sede, int version)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {

                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_MO_PPTO_LST";
                        ocmd.Parameters.Add("@cod_campania", SqlDbType.Int).Value = campania;
                        ocmd.Parameters.Add("@cod_sede", SqlDbType.Int).Value = sede;
                        ocmd.Parameters.Add("@cod_version", SqlDbType.Int).Value = version;

                        SqlDataAdapter da = new SqlDataAdapter(ocmd);
                        da.Fill(dt);
                        da.Dispose();
                        oconexion.Close();
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                return dt;
            }
        }
    }
}