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
    public class MD_PLAN
    {
        Conexion oConn = new Conexion();
        public string insertPlan(string anio, int periodo, int cod_ver, int cod_material, decimal material_USD)
        {

            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_GE_PLAN_INSERT";
                        ocmd.Parameters.Add("@anio", SqlDbType.VarChar, 7).Value = anio;
                        ocmd.Parameters.Add("@periodo", SqlDbType.Int).Value = periodo;
                        /*ocmd.Parameters.Add("@cod_ver", SqlDbType.Int).Value = cod_ver;*/
                        ocmd.Parameters.Add("@cod_material", SqlDbType.Int).Value = cod_material;
                        ocmd.Parameters.Add("@material_USD", SqlDbType.Float).Value = material_USD;
                        ocmd.CommandTimeout = 9000000;
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
        public DataTable bscPlan(string dato)
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            SqlParameter pInsumo = new SqlParameter("@dato", dato);
            listP.Add(pInsumo);
            return oConn.filtrarRegistros("[SP_GE_PLAN_LST]", listP);
        }
    }
}
