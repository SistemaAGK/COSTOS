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
    public  class MD_VERSION
    {
        Conexion oConn = new Conexion();

        public string crearVersion(int opc, int indicador,string descripcion, string usuario, int estado, string accion, int codigo)
        {

            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_GE_VERSION_PPTO_OPE";
                        ocmd.Parameters.Add("@opc", SqlDbType.Int).Value = opc;
                        ocmd.Parameters.Add("@indicador", SqlDbType.Int).Value = indicador;
                        ocmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 100).Value = descripcion;
                        ocmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                        ocmd.Parameters.Add("@estado", SqlDbType.Int).Value = estado;
                        ocmd.Parameters.Add("@accion", SqlDbType.VarChar).Value = accion;
                        ocmd.Parameters.Add("@cod_version", SqlDbType.Int).Value = codigo;
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
        public DataTable lstVersionPPTO()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_VERSION_PPTO_LST", listP);
        }
        /***************************************************************************/
        public string crearVersionPLAN(int opc, string descripcion)
        {

            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_GE_PLAN_VER_OPE";
                        ocmd.Parameters.Add("@opc", SqlDbType.Int).Value = opc;
                        ocmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 100).Value = descripcion;
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
        public DataTable lstVersionPLAN()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_PLAN_VER_LST", listP);
        }
    }
}
