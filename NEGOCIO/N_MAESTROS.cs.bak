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
        public DataTable lstCampania(int opc)
        {
            return oMD.lstCampania(opc);
        }
        public DataTable lst_Medida()
        {
            return oMD.lstMedida();
        }
        public string insert_Campania(string campania, string fec_inicio, string fec_fin, int usuario)
        {
            return oMD.insertCampania(campania, fec_inicio, fec_fin, usuario);
        }
        public DataTable lst_VersionesG(int opc)
        {
            return oMD.lstVersionesG(opc);
        }
    }
}
