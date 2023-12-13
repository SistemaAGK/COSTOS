using CONEXION;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


namespace MANEJO_DATOS
{
    public class MD_CECO
    {
        Conexion oConn = new Conexion();
        public string opeCECO( int opc, string cod_ceco, int cod_sede, int cod_fundo, int cod_dpto, int cod_grp_ceco, 
                                int cod_tip_ceco, string ceco_nombre,int cod_cultivo, decimal superficie, int usuario, int flag_pep)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_GE_CECO_OPE";
                        ocmd.Parameters.Add("@opc", SqlDbType.Int).Value = opc;
                        ocmd.Parameters.Add("@cod_ceco", SqlDbType.VarChar, 30).Value = cod_ceco;
                        ocmd.Parameters.Add("@cod_sede", SqlDbType.Int).Value = cod_sede;
                        ocmd.Parameters.Add("@cod_fundo", SqlDbType.Int).Value = cod_fundo/*VARIABLE GLOBAL DE CAMPANIA*/;
                        ocmd.Parameters.Add("@cod_dpto", SqlDbType.Int).Value = cod_dpto;
                        ocmd.Parameters.Add("@cod_grp_ceco", SqlDbType.Int).Value = cod_grp_ceco;
                        ocmd.Parameters.Add("@cod_tip_ceco", SqlDbType.Int).Value = cod_tip_ceco;
                        ocmd.Parameters.Add("@ceco_nombre", SqlDbType.VarChar, 100).Value = ceco_nombre;
                        ocmd.Parameters.Add("@cod_cultivo", SqlDbType.Int).Value = cod_cultivo;
                        ocmd.Parameters.Add("@superficie", SqlDbType.Float).Value = superficie;
                        ocmd.Parameters.Add("@usuario", SqlDbType.Int).Value = usuario;
                        ocmd.Parameters.Add("@flag_pep", SqlDbType.Int).Value = flag_pep;
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
        public DataTable lstCECO(int opc)
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            SqlParameter pOpc = new SqlParameter("@opc", opc);
            listP.Add(pOpc);
            return oConn.filtrarRegistros("[SP_GE_CECO_LST]", listP);
        }
    }
}
