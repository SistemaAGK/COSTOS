using MANEJO_DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class N_PPTO_MO
    {
        MD_PPTO_MO oMD = new MD_PPTO_MO();

        public DataTable lst_Sedes()
        {
            return oMD.lstSedes();
        }
        public DataTable lst_Año()
        {
            return oMD.lstAño();
        }
        public DataTable lst_VersionesPptoMO(int campania)
        {
            return oMD.lstVersionesPptoMO(campania);
        }
        public string opeTmpPptoMO(int lin, string ceco, int labor, int ano, int mes, decimal jornal)
        {
            return oMD.opeTmpPptoMO(lin, ceco, labor, ano, mes, jornal);
        }
        public string opeTmpDeletePptoMO()
        {
            return oMD.opeTmpDeletePptoMO();
        }
        public string opeTmpUpdatePptoMO()
        {
            return oMD.opeTmpUpdatePptoMO();
        }
        public string opeTmpViewPptoMO()
        {
            return oMD.opeTmpViewPptoMO();
        }
        public string opeUpdatePptoMO( int campaña, int version, int nva_version)
        {
            return oMD.opeUpdatePptoMO( campaña, version, nva_version);
        }
        public DataTable lst_Log()
        {
            return oMD.lstLog();
        }
        public DataTable lst_Brief()
        {
            return oMD.lstBrief();
        }
        public DataTable lst_PptoMO(int campania, int sede, int version)
        {
            return oMD.lstPptoMO(campania, sede, version);
        }
    }

}
