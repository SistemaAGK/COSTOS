using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CONEXION;
using System;

namespace MANEJO_DATOS
{
    public class MD_MATERIAL
    {
        Conexion oConn = new Conexion();
        public DataTable lstTipoMaterial(string tipo)
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            SqlParameter ptmaterial_nombre = new SqlParameter("@tmaterial_nombre", tipo);
            listP.Add(ptmaterial_nombre);
            return oConn.filtrarRegistros("SP_GE_MATERIAL_TIPO_LST", listP);
        }
        public DataTable lstMotivo(string motivo)
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            SqlParameter pmotivo = new SqlParameter("@motivo", motivo);
            listP.Add(pmotivo);
            return oConn.filtrarRegistros("[SP_GE_MATERIAL_MOTV_LST]", listP);
        }
        public DataTable lstMaterial(int opc,string insumo)
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            SqlParameter pOpc = new SqlParameter("@opc", opc);
            SqlParameter pInsumo = new SqlParameter("@insumo", insumo);
            listP.Add(pOpc);
            listP.Add(pInsumo);
            return oConn.filtrarRegistros("[SP_GE_MATERIAL_LST]", listP);
        }
        public string opeMaterial(int opc, int cod_material,int cod_indicador,  int cod_tmaterial, string material_nombre,string medida, int usuario)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_GE_MATERIAL_OPE";
                        ocmd.Parameters.Add("@opc", SqlDbType.Int).Value = opc;
                        ocmd.Parameters.Add("@cod_material", SqlDbType.VarChar, 7).Value = cod_material;
                        ocmd.Parameters.Add("@cod_indicador", SqlDbType.Int).Value = cod_indicador;
                        ocmd.Parameters.Add("@cod_tmaterial", SqlDbType.Int).Value = cod_tmaterial;
                        ocmd.Parameters.Add("@material_nombre", SqlDbType.VarChar, 120).Value = material_nombre;
                        ocmd.Parameters.Add("@medida", SqlDbType.VarChar, 5).Value = medida;
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
        public string opeMaterialTipo(string tipo)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_GE_MATERIAL_TIPO_INSERT";
                        ocmd.Parameters.Add("@tmaterial_nombre", SqlDbType.VarChar,30).Value = tipo;
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

        public DataTable lstMaterialTipo2()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            //SqlParameter ptip01 = new SqlParameter("@tip01", tipo1);
            //listP.Add(ptip01);
            return oConn.filtrarRegistros("SP_GE_MATERIAL_TIPO2_LST", listP);
        }
        public string opeMaterialTipo2(int cod_tipo1,  string tipo2)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_GE_MATERIAL_TIPO2_INSERT";
                        ocmd.Parameters.Add("@cod_tmaterial", SqlDbType.Int).Value = cod_tipo1;
                        ocmd.Parameters.Add("@tmaterial_nombre2", SqlDbType.VarChar, 30).Value = tipo2;
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

        public string opeMaterialMotivo(string motivo)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_GE_MATERIAL_MOTIV_INSERT";
                        ocmd.Parameters.Add("@motivo", SqlDbType.VarChar, 30).Value = motivo;
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
        public DataTable lstMaterialFamilia()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            //SqlParameter ptip01 = new SqlParameter("@tip01", tipo1);
            //listP.Add(ptip01);
            return oConn.filtrarRegistros("SP_GE_MATERIAL_TIPO_FAM_LST", listP);
        }
        public DataTable lstMaterialAtributos()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            //SqlParameter ptip01 = new SqlParameter("@tip01", tipo1);
            //listP.Add(ptip01);
            return oConn.filtrarRegistros("SP_GE_MATERIAL_ATRIB_LST", listP);
        }

        public DataTable lstMaterialTipo01()
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            //SqlParameter ptip01 = new SqlParameter("@tip01", tipo1);
            //listP.Add(ptip01);
            return oConn.filtrarRegistros("SP_GE_MATERIAL_TIPO01_LST", listP);
        }

        public DataTable lstMaterialTipo02(int t01)
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            SqlParameter pt01 = new SqlParameter("@cod_tipo1", t01);
            listP.Add(pt01);
            return oConn.filtrarRegistros("SP_GE_MATERIAL_TIPO02_LST", listP);
        }

        public string opeMaterialAtributos(int opc, int cod_atrib, int cod_sede, int cod_cultivo, int cod_material, int cod_area, int cod_tmaterial, int cod_tmaterial2, int cod_motivo,string llave)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_GE_MATERIAL_ATRIB_OPE";
                        ocmd.Parameters.Add("@opc", SqlDbType.Int).Value = opc;
                        ocmd.Parameters.Add("@cod_atrib", SqlDbType.Int).Value = cod_atrib;
                        ocmd.Parameters.Add("@cod_sede", SqlDbType.Int).Value = cod_sede;
                        ocmd.Parameters.Add("@cod_cultivo", SqlDbType.Int).Value = cod_cultivo;
                        ocmd.Parameters.Add("@cod_material", SqlDbType.Int).Value = cod_material;
                        ocmd.Parameters.Add("@cod_area", SqlDbType.Int).Value = cod_area;
                        ocmd.Parameters.Add("@cod_tmaterial", SqlDbType.Int).Value = cod_tmaterial;
                        ocmd.Parameters.Add("@cod_tmaterial2", SqlDbType.Int).Value = cod_tmaterial2;
                        ocmd.Parameters.Add("@cod_motivo", SqlDbType.Int).Value = cod_motivo;
                        ocmd.Parameters.Add("@llave_atrib", SqlDbType.VarChar).Value = llave;
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
        public string ope_Labores(int opc, int cod_labor, int cod_grupo, int cod_gruporat, int cod_efectivo, string descripcion_labor)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_GE_LABORES_INSERT";
                        ocmd.Parameters.Add("@opc", SqlDbType.Int).Value = opc;
                        ocmd.Parameters.Add("@cod_labor", SqlDbType.Int).Value = cod_labor;
                        ocmd.Parameters.Add("@cod_grupo", SqlDbType.Int).Value = cod_grupo;
                        ocmd.Parameters.Add("@cod_gruporat", SqlDbType.Int).Value = cod_gruporat;
                        ocmd.Parameters.Add("@cod_efectivo", SqlDbType.Int).Value = cod_efectivo;
                        ocmd.Parameters.Add("@labor", SqlDbType.VarChar).Value = descripcion_labor;
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
        public string ope_Tarifas(int opc, int cod_ver, int cod_sede, int cod_cultivo, int cod_destino, int cod_labor, int cod_anio, int periodo, decimal tarifa)
        {
            try
            {
                using (SqlConnection oconexion = oConn.obtenerConexion())
                {
                    using (SqlCommand ocmd = new SqlCommand())
                    {
                        ocmd.Connection = oconexion;
                        ocmd.CommandType = CommandType.StoredProcedure;
                        ocmd.CommandText = "SP_GE_TARIFAS_INSERT";
                        ocmd.Parameters.Add("@opc", SqlDbType.Int).Value = opc;
                        ocmd.Parameters.Add("@cod_ver", SqlDbType.Int).Value = cod_ver;
                        ocmd.Parameters.Add("@cod_sede", SqlDbType.Int).Value = cod_sede;
                        ocmd.Parameters.Add("@cod_cultivo", SqlDbType.Int).Value = cod_cultivo;
                        ocmd.Parameters.Add("@cod_destino", SqlDbType.Int).Value = cod_destino;
                        ocmd.Parameters.Add("@cod_labor", SqlDbType.Int).Value = cod_labor;
                        ocmd.Parameters.Add("@anio", SqlDbType.Int).Value = cod_anio;
                        ocmd.Parameters.Add("@periodo", SqlDbType.Int).Value = periodo;
                        ocmd.Parameters.Add("@tarifa", SqlDbType.Decimal).Value = tarifa;
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
