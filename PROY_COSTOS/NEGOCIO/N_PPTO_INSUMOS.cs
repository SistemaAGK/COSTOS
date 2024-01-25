using MANEJO_DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class N_PPTO_INSUMOS
    {
        MD_PPTO_INSUMOS oMD = new MD_PPTO_INSUMOS();
        public string insert_TempInsumo(int anio, int periodo, string cod_ceco, int cod_area, int cod_insumo, string desc_insumo, decimal cantidad)
        {
            return oMD.insertTempInsumo(anio, periodo, cod_ceco, cod_area, cod_insumo, desc_insumo, cantidad);
        }
        public string delete_TempInsumo(int codigo)
        {
            return oMD.deleteTempInsumo(codigo);
        }
        public DataTable lstTemporalPPTO()
        {
            return oMD.lstTemporalPPTO();
        }
        public string insert_InsumoPPTO(int tusuario)
        {
            return oMD.insertInsumoPPTO(tusuario);
        }
        public DataTable lst_PPTO(int sede, int fundo, int cultivo, int version)
        {
            return oMD.lstPPTO(sede, fundo, cultivo,  version);
        }
        public DataTable lst_Version(int indc)
        {
            return oMD.lstVersion(indc);
        }
        public string ope_Reemplazo_DATA_PPTO()
        {
            return oMD.opeReemplazo_DATA_PPTO();
        }
    }
}
