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

namespace PROY_COSTOS.MANO_DE_OBRA
{
    public partial class FRM_MO_LABORES : Form
    {
        Metodos met = new Metodos();
        DataView oDv = new DataView();
        N_MATERIAL oN = new N_MATERIAL();
        public FRM_MO_LABORES()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //met.importarExcel(dgvDatos, "MATE-TIPO-INSUMO");
            met.importarExcel(dgvDatos, "LABORES");
            this.lblTotal.Text = Convert.ToString(dgvDatos.RowCount);
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            int success_registros = 0;
            try
            {
                if (dgvDatos.RowCount < 1)
                {
                    met.MensajeError("NO EXISTEN DATOS PARA REALIZAR LA CARGA");
                }
                else
                {
                    progressBar.Maximum = Convert.ToInt32(dgvDatos.RowCount);
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        oN.ope_Labores(1, 
                        Convert.ToInt32(row.Cells["COD_LABOR"].Value.ToString()),
                        Convert.ToInt32(row.Cells["COD_GRUPO"].Value.ToString()),
                        Convert.ToInt32(row.Cells["COD_GRUPORAT"].Value.ToString()),
                        Convert.ToInt32(row.Cells["COD_EFECTIVO"].Value.ToString()),
                        row.Cells["LABOR"].Value.ToString()
                        );
                        progressBar.Value = progressBar.Value + 1;
                    }
                  //  lst_Labores();
                    dgvDatos.DataSource = null;
                    dgvDatos.Rows.Clear();
                    dgvDatos.Columns.Clear();
                    progressBar.Value = 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void lst_Labores()
        {
            //oDv = new DataView(oN.lst_MaterialAtributos());
            //dgvTemporal.DataSource = oDv;
        }
    }
}
