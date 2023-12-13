using PROY_COSTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROY_COSTOS
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FRM_INSUMOS());
            Application.Run(new Frm_Inicio());
            //Application.Run(FRM_PRINCIPAL.GetInstancia());
        }
    }
}
