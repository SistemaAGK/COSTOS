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
    public class MD_REAL_MO
    {
        Conexion oConn = new Conexion();
        public DataTable lstTemporada()
        {
            List<SqlParameter> listP = new List<SqlParameter>();

            return oConn.filtrarRegistros("SP_GE_CAMPANIA_LST", listP);
        }
        public DataTable lstSedes()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_SEDE_LST_ALL", listP);
        }
        public DataTable lstPeriodos(int tipo_lista)
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
                        ocmd.CommandText = "SP_GE_MES_LST";
                        ocmd.Parameters.Add("@tipo_lista", SqlDbType.Int).Value = tipo_lista;

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
        public string opeTmpDeleteRealMO()
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_MO_TMP_REAL_DELETE";

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
        public string opeTmpRealMO(int nume_lin, int nume_ano, int nume_mes, string tipo_ecosto, string codi_ecosto, string desc_ecosto, string desc_lotubi, string cod_labor, string desc_labor, decimal cant_horas, decimal cant_jornal, decimal cost_jornal, decimal cost_bfijo, decimal cost_hext, decimal cost_bvar, decimal cost_destajo, decimal cost_otros, decimal cost_total)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_MO_TMP_REAL_INSERT";

                        ocmd.Parameters.Add("@nume_lin", SqlDbType.Int).Value = nume_lin;
                        ocmd.Parameters.Add("@nume_ano", SqlDbType.Int).Value = nume_ano;
                        ocmd.Parameters.Add("@nume_mes", SqlDbType.Int).Value = nume_mes;
                        ocmd.Parameters.Add("@tipo_ecosto", SqlDbType.VarChar, 1).Value = tipo_ecosto;
                        ocmd.Parameters.Add("@codi_ecosto", SqlDbType.VarChar, 20).Value = codi_ecosto;
                        ocmd.Parameters.Add("@desc_ecosto", SqlDbType.VarChar, 50).Value = desc_ecosto;
                        ocmd.Parameters.Add("@desc_lotubi", SqlDbType.VarChar, 50).Value = desc_lotubi;
                        ocmd.Parameters.Add("@cod_labor", SqlDbType.Int).Value = cod_labor;
                        ocmd.Parameters.Add("@desc_labor", SqlDbType.VarChar, 50).Value = desc_labor;
                        ocmd.Parameters.Add("@cant_horas", SqlDbType.Decimal, 18).Value = cant_horas;
                        ocmd.Parameters.Add("@cant_jornal", SqlDbType.Decimal, 18).Value = cant_jornal;
                        ocmd.Parameters.Add("@cost_jornal", SqlDbType.Decimal, 18).Value = cost_jornal;
                        ocmd.Parameters.Add("@cost_bfijo", SqlDbType.Decimal, 18).Value = cost_bfijo;
                        ocmd.Parameters.Add("@cost_hext", SqlDbType.Decimal, 18).Value = cost_hext;
                        ocmd.Parameters.Add("@cost_bvar", SqlDbType.Decimal, 18).Value = cost_bvar;
                        ocmd.Parameters.Add("@cost_destajo", SqlDbType.Decimal, 18).Value = cost_destajo;
                        ocmd.Parameters.Add("@cost_otros", SqlDbType.Decimal, 18).Value = cost_otros;
                        ocmd.Parameters.Add("@cost_total", SqlDbType.Decimal, 18).Value = cost_total;

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
        public DataTable lstBrief()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.listaRegistros("SP_MO_TMP_REAL_SHOW_BRIEF");
        }
        public string opeTmpUpdateRealMO(int incluyetarifa)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_MO_TMP_REAL_UPDATE";
                        ocmd.Parameters.Add("@flag_tarifa", SqlDbType.Int).Value = incluyetarifa;

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
            return oConn.listaRegistros("SP_MO_TMP_REAL_SHOW");
        }
        public DataTable busEjercicio(int cod_cam, int nume_mes)
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
                        ocmd.CommandText = "SP_MO_OBTENER_EJERCICIO";
                        ocmd.Parameters.Add("@cod_cam", SqlDbType.Int).Value = cod_cam;
                        ocmd.Parameters.Add("@nume_mes", SqlDbType.Int).Value = nume_mes;

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
        public string opeUpdateRealMO(int campaña, int mes, int sede)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_MO_REAL_UPDATE";

                        ocmd.Parameters.Add("@cod_campania", SqlDbType.Int).Value = campaña;
                        ocmd.Parameters.Add("@nume_mes", SqlDbType.Int).Value = mes;
                        ocmd.Parameters.Add("@cod_sede", SqlDbType.Int).Value = sede;
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
        public DataTable lstRealMO(int campania, int sede, int mes)
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
                        ocmd.CommandText = "SP_MO_REAL_LST";
                        ocmd.Parameters.Add("@cod_campania", SqlDbType.Int).Value = campania;
                        ocmd.Parameters.Add("@cod_sede", SqlDbType.Int).Value = sede;
                        ocmd.Parameters.Add("@nume_mes", SqlDbType.Int).Value = mes;

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
        public DataTable lstSedesImportar()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_SEDE_LST", listP);
        }
    }
}
