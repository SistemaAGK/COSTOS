using MANEJO_DATOS;
using System;
using System.Data;

namespace NEGOCIO
{
    public class N_TCAMBIO
    {
        MD_TCAMBIO oMD = new MD_TCAMBIO();
        public string insert_TipoCambio(int anio, int periodo, decimal cambio, int usuario)
        {
            return oMD.insertTipoCambio(anio, periodo, cambio, usuario);
        }
        public DataTable lst_TipoCambio(int opc)
        {
            return oMD.lstTipoCambio(opc);
        }
        public string insertTipoCambioDiario(DateTime fecha, decimal tcambio)
        {
            return oMD.insertTipoCambioDiario(fecha, tcambio);
        }
        public DataTable lstTipoCambioDiario()
        {
            return oMD.lstTipoCambioDiario();
        }
        /*TIPO DE CAMBIO MENSUAL - PROMEDIANDO TC DIARIO :: INICIO */
        public string insertTipoCambio_Mensual(int anio, int periodo, decimal cambio, string usuario)
        {
            return oMD.insertTipoCambio_Mensual(anio, periodo, cambio, usuario);
        }
        /*TIPO DE CAMBIO MENSUAL - PROMEDIANDO TC DIARIO :: FIN */
    }
}
