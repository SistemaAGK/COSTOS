using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CONEXION;

namespace MANEJO_DATOS
{
    public class MD_PPTO_REAL
    {
        Conexion oConn = new Conexion();
        public DataTable lstConsultaGeneral_PPTOActivo(int cod_sede, int cod_cultivo, int cod_fundo)
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            SqlParameter psede = new SqlParameter("@cod_sede", cod_sede);
            SqlParameter pcultivo = new SqlParameter("@cod_cultivo", cod_cultivo);
            SqlParameter pfundo = new SqlParameter("@cod_fundo", cod_fundo);
            listP.Add(psede);
            listP.Add(pcultivo);
            listP.Add(pfundo);
            return oConn.filtrarRegistros("SP_INS_REAL_CONSULTA_ACTIVA", listP);
        }
        public DataTable lstConsultaGeneral_PPTOGeneral(int cod_sede, int cod_cultivo, int cod_fundo)
        {
            List<SqlParameter> listP = new List<SqlParameter>();
            SqlParameter psede = new SqlParameter("@cod_sede", cod_sede);
            SqlParameter pcultivo = new SqlParameter("@cod_cultivo", cod_cultivo);
            SqlParameter pfundo = new SqlParameter("@cod_fundo", cod_fundo);
            listP.Add(psede);
            listP.Add(pcultivo);
            listP.Add(pfundo);
            return oConn.filtrarRegistros("SP_INS_REAL_CONSULTA_GENERAL", listP);
        }
    }
}
