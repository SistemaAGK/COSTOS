using MANEJO_DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class N_MAESTROS
    {
        MD_MAESTROS oMD = new MD_MAESTROS();

        public DataTable lst_Sede()
        {
            return oMD.lstSede();
        }
        public DataTable lst_Fundo(int cod_sede)
        {
            return oMD.lstFundo(cod_sede);
        }
        public DataTable lst_Gerencia(int cod_sede)
        {
            return oMD.lstGerencia(cod_sede);
        }
        public DataTable lst_Departamento(int cod_geren)
        {
            return oMD.lstDepartamento(cod_geren);
        }
        public DataTable lst_Cultivo()
        {
            return oMD.lstCultivo();
        }
        public DataTable lst_Gupo()
        {
            return oMD.lstGupo();
        }
        public DataTable lst_Tipo()
        {
            return oMD.lstTipo();
        }
        public DataTable lst_Indicador()
        {
            return oMD.lstIndicador();
        }
        public DataTable lstCampania(int opc, string campania)
        {
            return oMD.lstCampania(opc, campania);
        }
        public DataTable lst_Medida()
        {
            return oMD.lstMedida();
        }
        public string mtto_campania(string campania, string fec_inicio, string fec_fin, string usuario, int estado, string accion)
        {
            return oMD.mtto_campania(campania, fec_inicio, fec_fin, usuario, estado, accion);
        }
        public DataTable lst_VersionesG(int opc)
        {
            return oMD.lstVersionesG(opc);
        }
        /* 2410 - OS */
        public DataTable lstManTipFam(int opc)
        {
            return oMD.lstMantTipoFam(opc);
        }
    }
}
