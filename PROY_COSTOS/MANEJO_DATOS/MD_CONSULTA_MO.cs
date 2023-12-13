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
    public class MD_CONSULTA_MO
    {
        Conexion oConn = new Conexion();
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
        public DataTable lstPptoRealMO(int campania, int mesi, int mesf, int version, int sede, int cultivo, bool insertar)
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
                        ocmd.CommandText = "SP_MO_REAL_PPTO_CONSULTA";
                        ocmd.Parameters.Add("@cod_campania", SqlDbType.Int).Value = campania;
                        ocmd.Parameters.Add("@nume_mes1", SqlDbType.Int).Value = mesi;
                        ocmd.Parameters.Add("@nume_mes2", SqlDbType.Int).Value = mesf;
                        ocmd.Parameters.Add("@cod_vers", SqlDbType.Int).Value = version;
                        ocmd.Parameters.Add("@cod_sede", SqlDbType.Int).Value = sede;
                        ocmd.Parameters.Add("@cod_cultivo", SqlDbType.Int).Value = cultivo;
                        ocmd.Parameters.Add("@cod_update", SqlDbType.Int).Value = insertar;

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
        public DataTable lstCultivos()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_CULTIVO_LST_ALL", listP);
        }
    }
}
