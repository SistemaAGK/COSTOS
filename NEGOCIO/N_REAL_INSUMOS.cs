using MANEJO_DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public  class N_REAL_INSUMOS
    {
        MD_REAL_INSUMOS oMD = new MD_REAL_INSUMOS();
        public string insert_TempREAL(string cod_ceco, int cod_area, int cod_insumo, string desc_insumo, DateTime fecha,
                                        int anio, int periodo, decimal cantidad_cons, decimal cst_cons_PES,
                                        string usuario_alm, string num_doc_ref, string usuario_solic, string num_documen, string clase, int indicativo)
        {
            return oMD.insertTempREAL(cod_ceco,  cod_area,  cod_insumo,  desc_insumo,  fecha,  anio,  periodo,  cantidad_cons,  cst_cons_PES,
                 usuario_alm,  num_doc_ref,  usuario_solic,  num_documen,  clase, indicativo);
        }
        public string delete_TempREAL(int codigo)
        {
            return oMD.deleteTempREAL(codigo);
        }
        public DataTable lst_TemporalREAL()
        {
            return oMD.lstTemporalREAL();
        }
        public string insert_REAL(int log)
        {
            return oMD.insertREAL(log);
        }
        public DataTable lst_REAL(int opc, int sede, int fundo, int cultivo)
        {
            return oMD.lstREAL(opc, sede, fundo, cultivo);
        }
        public string opeReemplazo_DATA_REAL()
        {
            return oMD.opeReemplazo_DATA_REAL();
        }
    }
}
