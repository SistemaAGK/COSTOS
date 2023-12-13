using MANEJO_DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
namespace NEGOCIO
{
    public class N_INICIO
    {
        MD_INICIO oMD = new MD_INICIO();
        public DataTable bInicio(string txtusuario, string txtclave)
        {
              return oMD.buscausuario(txtusuario, txtclave);
        }

    }
}
