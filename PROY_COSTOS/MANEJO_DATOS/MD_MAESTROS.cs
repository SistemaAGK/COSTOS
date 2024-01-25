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
    public class MD_MAESTROS
    {
        Conexion oConn = new Conexion();
        public DataTable lstSede()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_SEDE_LST", listP);
        }
        public DataTable lstFundo(int cod_sede)
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            SqlParameter pCod_sede = new SqlParameter("@cod_sede", cod_sede);
            listP.Add(pCod_sede);
            return oConn.filtrarRegistros("SP_GE_FUNDO_LST", listP);
        }
        public DataTable lstGerencia(int cod_sede)
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            SqlParameter pCod_sede = new SqlParameter("@cod_sede", cod_sede);
            listP.Add(pCod_sede);
            return oConn.filtrarRegistros("SP_GE_GERENCIA_LST", listP);
        }
        public DataTable lstDepartamento(int cod_geren)
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            SqlParameter pCod_sede = new SqlParameter("@cod_geren", cod_geren);
            listP.Add(pCod_sede);
            return oConn.filtrarRegistros("SP_GE_DEPARTAMENTO_LST", listP);
        }
        public DataTable lstGupo()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_GRUPO_LST", listP);
        }
        public DataTable lstTipo()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_TIPO_LST", listP);
        }
        public DataTable lstCultivo()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_CULTIVO_LST", listP);
        }
        public DataTable lstIndicador()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_INDICADOR_LST", listP);
        }
        public DataTable lstCampania(int opc)
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            SqlParameter pOPC = new SqlParameter("@opc", opc);
            listP.Add(pOPC);
            return oConn.filtrarRegistros("SP_GE_CAMPANIA_LST", listP);
        }
        public DataTable lstMedida()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            return oConn.filtrarRegistros("SP_GE_MEDIDA_LST", listP);
        }
        public string insertCampania(string campania, string fec_inicio,string fec_fin, int usuario)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_GE_CAMPANIA_INS";
                        ocmd.Parameters.Add("@campania", SqlDbType.VarChar).Value = campania;
                        ocmd.Parameters.Add("@fec_inicio", SqlDbType.VarChar, 10).Value = fec_inicio;
                        ocmd.Parameters.Add("@fec_fin", SqlDbType.VarChar, 10).Value = fec_fin;
                        ocmd.Parameters.Add("@usuario", SqlDbType.Int).Value = usuario;
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
        public DataTable lstVersionesG(int opc)
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            SqlParameter pOPC = new SqlParameter("@opc", opc);
            listP.Add(pOPC);
            return oConn.filtrarRegistros("SP_VERSIONES_LST", listP);
        }
    }
}
