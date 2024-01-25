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

namespace PROY_COSTOS.MANO_DE_OBRA.Maestros
{
    public partial class FRM_MO_TARIFAS : Form
    {
        Metodos met = new Metodos();
        DataView oDv = new DataView();
        N_MATERIAL oN = new N_MATERIAL();
        public FRM_MO_TARIFAS()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //met.importarExcel(dgvDatos, "MATE-TIPO-INSUMO");
            met.importarExcel(dgvDatos, "TARIFAS");
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
                        oN.ope_Tarifas(1,
                        Convert.ToInt32(row.Cells["COD_VER"].Value.ToString()),
                        Convert.ToInt32(row.Cells["COD_SEDE"].Value.ToString()),
                        Convert.ToInt32(row.Cells["COD_CULTIVO"].Value.ToString()),
                        Convert.ToInt32(row.Cells["COD_DESTINO"].Value.ToString()),
                        Convert.ToInt32(row.Cells["COD_LABOR"].Value.ToString()),
                        Convert.ToInt32(row.Cells["COD_ANIO"].Value.ToString()),
                        Convert.ToInt32(row.Cells["PERIODO"].Value.ToString()),
                        Convert.ToDecimal(row.Cells["TARIFA"].Value.ToString())
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
    }
}
