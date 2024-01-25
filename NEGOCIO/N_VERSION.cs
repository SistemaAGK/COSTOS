using MANEJO_DATOS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class N_VERSION
    {
        MD_VERSION oMD = new MD_VERSION();
        public string crear_Version(int opc, int indicador,string descripcion,  string usuario, int estado, string accion, int codigo)
        {
            return oMD.crearVersion(opc, indicador, descripcion, usuario,estado,accion,codigo);
        }
        public DataTable lst_VersionPPTO()
        {
            return oMD.lstVersionPPTO();
        }
        public string crear_VersionPLAN(int opc, string descripcion)
        {
            return oMD.crearVersionPLAN(opc, descripcion);
        }
        public DataTable lst_VersionPLAN()
        {
            return oMD.lstVersionPLAN();
        }
    }
}
