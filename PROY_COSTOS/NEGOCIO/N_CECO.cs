using MANEJO_DATOS;
using System.Data;

namespace NEGOCIO
{
    public class N_CECO
    {
        MD_CECO oMD = new MD_CECO();
        public string ope_CECO(
            int opc, 
            string cod_ceco, 
            int cod_sede, 
            int cod_fundo, 
            int cod_dpto, 
            int cod_grp_ceco,                
            int cod_tip_ceco, 
            string ceco_nombre, 
            int cod_cultivo, 
            decimal superficie, 
            int usuario, 
            int flag_pep)
        {
            return oMD.opeCECO( opc,  cod_ceco,  cod_sede,  cod_fundo,  cod_dpto,  cod_grp_ceco,
                                 cod_tip_ceco,  ceco_nombre,  cod_cultivo,  superficie,  usuario,  flag_pep);
        }
        public DataTable lst_CECO(int opc)
        {
            return oMD.lstCECO(opc);
        }
    }
}
