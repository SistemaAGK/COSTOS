using MANEJO_DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class N_REAL_MO
    {
        MD_REAL_MO oMD = new MD_REAL_MO();

        public DataTable lst_Temporada()
        {
            return oMD.lstTemporada();
        }
        public DataTable lst_Periodos(int tipo_lista)
        {
            return oMD.lstPeriodos(tipo_lista);
        }
        public string opeTmpDeleteRealMO()
        {
            return oMD.opeTmpDeleteRealMO();
        }
        public string opeTmpRealMO(int lin, int año, int mes,  string tipo_ecosto, string codi_ecosto, string desc_ecosto, string desc_lotubi, string cod_labor, 
                                   string desc_labor, decimal cant_horas, decimal cant_jornal, decimal cost_jornal, decimal cost_bfijo, 
                                   decimal cost_hext, decimal cost_bvar, decimal cost_destajo, decimal cost_otros, decimal cost_total)
        {
            return oMD.opeTmpRealMO(lin, año, mes, tipo_ecosto, codi_ecosto, desc_ecosto, desc_lotubi, cod_labor, desc_labor, cant_horas, cant_jornal, cost_jornal, cost_bfijo, cost_hext, cost_bvar, cost_destajo, cost_otros, cost_total);
        }
        public DataTable lst_Brief()
        {
            return oMD.lstBrief();
        }
        public string opeTmpUpdateRealMO(int tarifa)
        {
            return oMD.opeTmpUpdateRealMO(tarifa);
        }
        public DataTable busEjercicio(int cod_cam, int nume_mes)
        {
            return oMD.busEjercicio(cod_cam, nume_mes);
        }
        public DataTable lst_Log()
        {
            return oMD.lstLog();
        }
        public string opeUpdateRealMO(int campaña, int mes, int sede)
        {
            return oMD.opeUpdateRealMO(campaña, mes, sede);
        }
        public DataTable lst_Sedes()
        {
            return oMD.lstSedes();
        }
        public DataTable lst_RealMO(int campania, int sede, int mes)
        {
            return oMD.lstRealMO(campania, sede, mes);
        }
        public DataTable lst_SedesImportar()
        {
            return oMD.lstSedesImportar();
        }
    }
}
