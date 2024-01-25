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
    public class MD_RECETA
    {
        Conexion oConn = new Conexion();
        public string insertReceta(int cod_ver_rec, int cod_sku,string sku_descripcion, int alternativa, 
                                    int cod_material, string material,decimal cantidad,string unidad,decimal precio_USD)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_ME_RECETA_INSERT";
                        ocmd.Parameters.Add("@cod_ver_rec", SqlDbType.Int).Value = cod_ver_rec;
                        ocmd.Parameters.Add("@cod_sku", SqlDbType.Int).Value = cod_sku;
                        ocmd.Parameters.Add("@sku_descripcion", SqlDbType.VarChar, 100).Value = sku_descripcion;
                        ocmd.Parameters.Add("@alternativa", SqlDbType.Int).Value = alternativa;
                        ocmd.Parameters.Add("@cod_material", SqlDbType.Int).Value = cod_material;
                        ocmd.Parameters.Add("@material", SqlDbType.VarChar, 100).Value = material;
                        ocmd.Parameters.Add("@cantidad", SqlDbType.Float).Value = cantidad;
                        ocmd.Parameters.Add("@unidad", SqlDbType.VarChar, 10).Value = unidad;
                        ocmd.Parameters.Add("@precio_USD", SqlDbType.Float).Value = precio_USD;
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
