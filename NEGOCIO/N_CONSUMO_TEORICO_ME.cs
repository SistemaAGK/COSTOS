using MANEJO_DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class N_CONSUMO_TEORICO_ME
    {
        MD_CONSUMO_TEORICO_ME oMD = new MD_CONSUMO_TEORICO_ME();

        public DataTable lst_VersionesPptoME(int campania)
        {
            return oMD.lstVersionesPptoME(campania);
        }
        public DataTable lst_Sede()
        {
            return oMD.lstSede();
        }
        public DataTable lst_Sedes()
        {
            return oMD.lstSedes();
        }
        public DataTable lst_Cultivo()
        {
            return oMD.lstCultivo();
        }
        public DataTable lst_Cultivos()
        {
            return oMD.lstCultivos();
        }

        public DataTable lst_año()
        {
            return oMD.lstAño();
        }

        public DataTable lst_mes()
        {
            return oMD.lstMes();
        }

        public string opeTmpDeleteTeoricoME()
        {
            return oMD.opeTmpDeleteTeoricoME();
        }



         public string opeTmpTeoricoME(int lin,  int cod_campania,      int cod_sede, int cod_cultivo, int nume_ano, int nume_mes ,int codi_insumo, decimal cant_requerida, String nomb_insumo)
        {
            return oMD.opeTmpTeoricoME(lin, cod_campania, cod_sede, cod_cultivo, nume_ano, nume_mes, codi_insumo, cant_requerida, nomb_insumo);
        }

        ////public string opeTmpUpdaTeoricoME(int cod_sede, int cod_cultivo, int nume_ano, int nume_mes)
        ////{
        ////    return oMD.opeTmpUpdateTeoricoME(cod_sede,cod_cultivo, nume_ano, nume_mes);
        ////}


        public string opeTmpUpdaTeoricoME(int cod_campania)
        {
            return oMD.opeTmpUpdateTeoricoME(cod_campania);
        }


        public DataTable lst_Log()
        {
            return oMD.lst_Log();
        }
        public DataTable lst_Brief()
        {
            return oMD.lstBrief();
        }
        public string opeUpdateTeoricoMe(int campania)
        {
            return oMD.opeUpdateTeoricoMe(campania);
        }
        public DataTable lst_TeoricoME(int cod_sede, int cod_cultivo, int nume_ano, int nume_mes)
        {
            return oMD.lstTeoricoMEP(cod_sede, cod_cultivo, nume_ano, nume_mes);
        }

        public DataTable lst_ComparativoME(int campania, int mesi, int mesf, int cod_sede, int cod_cultivo, int version, int actualiza)
        {
            return oMD.lstComparativoME(campania, mesi, mesf, cod_sede, cod_cultivo, version, actualiza);
        }

        public DataTable lst_Temporada()
        {
            return oMD.lstTemporada();
        }
        public DataTable lst_Periodos(int tipo_lista)
        {
            return oMD.lstPeriodos(tipo_lista);
        }
    }
}
