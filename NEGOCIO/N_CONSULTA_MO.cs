using MANEJO_DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class N_CONSULTA_MO
    {
        MD_CONSULTA_MO oMD = new MD_CONSULTA_MO();
        public DataTable lst_VersionesPptoMO(int campania)
        {
            return oMD.lstVersionesPptoMO(campania);
        }
        public DataTable lst_Temporada()
        {
            return oMD.lstTemporada();
        }
        public DataTable lst_Periodos(int tipo_lista)
        {
            return oMD.lstPeriodos(tipo_lista);
        }
        public DataTable lst_PptoRealMO(int campania, int mesi, int mesf, int version, int sede, int cultivo, bool insertar)
        {
            return oMD.lstPptoRealMO(campania,mesi, mesf, version, sede, cultivo, insertar);
        }
        public DataTable lst_Sedes()
        {
            return oMD.lstSedes();
        }
        public DataTable lst_Cultivos()
        {
            return oMD.lstCultivos();
        }
    }
}
