using MANEJO_DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class N_PPTO_REAL
    {
        MD_PPTO_REAL oMD = new MD_PPTO_REAL();
        public DataTable lstConsultaGeneral_PPTOActivo(int cod_sede, int cod_cultivo, int cod_fundo)
        {
            return oMD.lstConsultaGeneral_PPTOActivo( cod_sede,  cod_cultivo,  cod_fundo);
        }
        public DataTable lstConsultaGeneral_PPTOGeneral(int cod_sede, int cod_cultivo, int cod_fundo)
        {
            return oMD.lstConsultaGeneral_PPTOGeneral(cod_sede, cod_cultivo, cod_fundo);
        }
    }
}
