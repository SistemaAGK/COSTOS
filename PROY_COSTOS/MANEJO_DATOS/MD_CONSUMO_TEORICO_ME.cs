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
    public class MD_CONSUMO_TEORICO_ME
    {

        Conexion oConn = new Conexion();

        public DataTable lstTemporada()
        {
            List<SqlParameter> listP = new List<SqlParameter>();

            return oConn.filtrarRegistros("SP_GE_CAMPANIA_LST", listP);
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

        public DataTable lstSedes()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_SEDE_LST_ALL", listP);
        }
        public DataTable lstSede()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_SEDE_LST", listP);
        }
        public DataTable lstCultivo()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_CULTIVO_LST", listP);
        }

        public DataTable lstCultivos()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_CULTIVO_LST_ALL", listP);
        }

        public DataTable lstAño()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_AÑO_LST", listP);
        }

        public DataTable lstMes()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_MES_LST", listP);
        }

        public string opeTmpDeleteTeoricoME()
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_ME_TMP_TEORICO_DELETE";

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

        ////public string opeTmpTeoricoME(int nume_lin, int codi_insumo, Decimal cant_requerida)

        public string opeTmpTeoricoME(int nume_lin, int cod_campania, int cod_sede, int cod_cultivo, int nume_ano, int nume_mes, int codi_insumo,  decimal cant_requerida, String nomb_insumo)

        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_ME_TMP_TEORICO_INSERT";
                        ocmd.Parameters.Add("@nume_lin", SqlDbType.Int).Value = nume_lin;
                        ocmd.Parameters.Add("@cod_campania", SqlDbType.Int).Value = cod_campania;
                        ocmd.Parameters.Add("@cod_sede", SqlDbType.Int).Value = cod_sede;
                        ocmd.Parameters.Add("@cod_cultivo", SqlDbType.Int).Value = cod_cultivo;
                        ocmd.Parameters.Add("@nume_ano", SqlDbType.Int).Value = nume_ano;
                        ocmd.Parameters.Add("@nume_mes", SqlDbType.Int).Value = nume_mes;
                        ocmd.Parameters.Add("@codi_insumo", SqlDbType.Int).Value = codi_insumo;
                        ocmd.Parameters.Add("@nomb_insumo", SqlDbType.VarChar).Value = nomb_insumo;
                        ocmd.Parameters.Add("@cant_requerida", SqlDbType.Decimal, 18).Value = cant_requerida;
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


        ////public string opeTmpUpdateTeoricoME(int cod_sede, int cod_cultivo, int nume_ano, int nume_mes)
        public string opeTmpUpdateTeoricoME(int cod_campania)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_ME_TMP_TEORICO_UPDATE";
                        ocmd.Parameters.Add("@cod_campania", SqlDbType.Int).Value = cod_campania;

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


        public DataTable lst_Log()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.listaRegistros("SP_ME_TMP_TEORICO_SHOW");
        }
        public DataTable lstBrief()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.listaRegistros("SP_ME_TMP_TEORICO_SHOW_BRIEF");
        }


        public string opeUpdateTeoricoMe(int campania)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_ME_TEORICO_UPDATE";
                        ocmd.Parameters.Add("@cod_campania", SqlDbType.Int).Value = campania;
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

        public string lstTeoricoME(int cod_sede, int cod_cultivo, int nume_ano, int nume_mes)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_ME_TMP_TEORICO_INSERT";
                        ocmd.Parameters.Add("@cod_sede", SqlDbType.Int).Value = cod_sede;
                        ocmd.Parameters.Add("@cod_cultivo", SqlDbType.Int).Value = cod_cultivo;
                        ocmd.Parameters.Add("@nume_ano", SqlDbType.Int).Value = nume_ano;
                        ocmd.Parameters.Add("@nume_mes", SqlDbType.Int).Value = nume_mes;

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

        public DataTable lstTeoricoMEP(int cod_sede, int cod_cultivo, int nume_ano, int nume_mes)
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
                        ocmd.CommandText = "SP_ME_TEORICO_LST";
                        ocmd.Parameters.Add("@cod_sede", SqlDbType.Int).Value = cod_sede;
                        ocmd.Parameters.Add("@cod_cultivo", SqlDbType.Int).Value = cod_cultivo;
                        ocmd.Parameters.Add("@nume_ano", SqlDbType.Int).Value = nume_ano;
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

        public DataTable lstComparativoME(int campania, int mesi, int mesf, int cod_sede, int cod_cultivo, int version, int actualiza)
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
                        ocmd.CommandText = "SP_ME_COMPARATIVO_LST";
                        ocmd.Parameters.Add("@cod_campania", SqlDbType.Int).Value = campania;
                        ocmd.Parameters.Add("@nume_mes1", SqlDbType.Int).Value = mesi;
                        ocmd.Parameters.Add("@nume_mes2", SqlDbType.Int).Value = mesf;
                        ocmd.Parameters.Add("@cod_sede", SqlDbType.Int).Value = cod_sede;
                        ocmd.Parameters.Add("@cod_cultivo", SqlDbType.Int).Value = cod_cultivo;
                        ocmd.Parameters.Add("@nom_version", SqlDbType.Int).Value = version;
                        ocmd.Parameters.Add("@actualiza", SqlDbType.Int).Value = actualiza;
                        ////ocmd.Parameters.Add("@nume_ano", SqlDbType.Int).Value = nume_ano;
                        ////ocmd.Parameters.Add("@nume_mes", SqlDbType.Int).Value = nume_mes;
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

        public DataTable lstVersionesPptoME(int campania)
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
                        ocmd.CommandText = "SP_ME_PLAN_VER_LST";
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

    }
}
