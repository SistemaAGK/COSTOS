using MANEJO_DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NEGOCIO
{
    public class N_MATERIAL
    {
        MD_MATERIAL oMD = new MD_MATERIAL();

        public DataTable lst_Motivo(string motivo)
        {
            return oMD.lstMotivo(motivo);
        }
        public DataTable lst_TipoMaterial(string tipo)
        {
            return oMD.lstTipoMaterial( tipo);
        }
        public DataTable lst_Material(int opc, string insumo)
        {
            return oMD.lstMaterial(opc, insumo);
        }
        public string ope_Material(int opc, int cod_material, int cod_indicador, int cod_tmaterial, string material_nombre, string medida, int usuario)
        {
            return oMD.opeMaterial(opc, cod_material, cod_indicador, cod_tmaterial, material_nombre, medida, usuario);
        }
        public string ope_MaterialMotivo(string motivo)
        {
            return oMD.opeMaterialMotivo(motivo);
        }
        public string ope_MaterialTipo(string tipo)
        {
            return oMD.opeMaterialTipo(tipo);
        }
        public DataTable lst_MaterialTipo2()
        {
            return oMD.lstMaterialTipo2();
        }
        public string ope_MaterialTipo2(int cod_tip1, string tipo2)
        {
            return oMD.opeMaterialTipo2(cod_tip1, tipo2);
        }
        public DataTable lst_MaterialFamilia()
        {
            return oMD.lstMaterialFamilia();
        }
        public DataTable lst_MaterialAtributos()
        {
            return oMD.lstMaterialAtributos();
        }
        public DataTable lst_MaterialTipo01()
        {
            return oMD.lstMaterialTipo01();
        }
        public DataTable lst_MaterialTipo02(int t01)
        {
            return oMD.lstMaterialTipo02( t01);
        }
        public string ope_MaterialAtributos(int opc, int cod_atrib, int cod_sede, int cod_cultivo, int cod_material, int cod_area, int cod_tmaterial, int cod_tmaterial2, int cod_motivo)
        {
            return oMD.opeMaterialAtributos(opc, cod_atrib, cod_sede, cod_cultivo, cod_material, cod_area, cod_tmaterial, cod_tmaterial2, cod_motivo);
        }
    }
}
