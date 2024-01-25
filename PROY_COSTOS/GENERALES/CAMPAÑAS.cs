using NEGOCIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROY_COSTOS.GENERALES
{
    public partial class CAMPAÑAS : Form
    {
        DataView oDv = new DataView();
        N_MAESTROS oN = new N_MAESTROS();
        public CAMPAÑAS()
        {
            InitializeComponent();
        }

        private void CAMPAÑAS_Load(object sender, EventArgs e)
        {

            //// this.dgCampaña_Maestro.Rows.Add(2011,txt)
            //oDv = new DataView(oN.lstCampania(2));
            //dgCam.DataSource = oDv;

            //foreach (DataGridViewRow rows in dgCam.Rows)
            //{

            //    string campaña = rows.Cells["CAMPAÑA"].Value.ToString();
            //    string fechaI = rows.Cells["FECHA_INI"].Value.ToString();
            //    string fechaF = rows.Cells["FECHA_FIN"].Value.ToString("dd/MM/yyyy");

            //    var fechhaa = Convert.ToDateTime(rows.Cells["FECHA_FIN"].Value.ToString("dd/MM/yyyy");

            //    this.dgCampaña_Maestro.Rows.Add(campaña,fechaI, fechaF);
            //}
        }
    }
}
