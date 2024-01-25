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
    public class MD_INICIO
    {
        Conexion oConn = new Conexion();
        public DataTable buscausuario(string usuario,string clave)
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
                        ocmd.CommandText = "SP_GE_USUARIO_BUSCA";
                        ocmd.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                        ocmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = clave;

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
