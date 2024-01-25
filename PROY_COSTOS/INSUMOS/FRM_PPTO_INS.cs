using NEGOCIO;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace PROY_COSTOS
{
    public partial class FRM_PPTO_INS : Form
    {
        DataView oDv = new DataView();
        Metodos met = new Metodos();
        N_PPTO_INSUMOS oN = new N_PPTO_INSUMOS();
        private static FRM_PPTO_INS _Instancia;
        public static FRM_PPTO_INS GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_PPTO_INS();
            }
            return _Instancia;
        }
        public FRM_PPTO_INS()
        {
            InitializeComponent();
            lst_TemporalPPTO();
            this.dgvTemporal.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            lblverPPTO01.Text = Metodos.variablesGlobales.ver_ppto.ToString();
            lblverPPTO02.Text = Metodos.variablesGlobales.ver_ppto.ToString();
            lblVerPLAN01.Text = Metodos.variablesGlobales.ver_plan.ToString();
            lblVerPLAN02.Text = Metodos.variablesGlobales.ver_plan.ToString();
            //this.dgvTemporal.Columns[0].Visible = false;
            //this.dgvTemporal.Columns[9].Visible = false;
        }
        private void lst_TemporalPPTO()
        {
            //this.lblEstado.Text = "Procesando Datos ...";
            oDv = new DataView(oN.lstTemporalPPTO());
            dgvTemporal.DataSource = oDv;
            this.lbltemporal.Text = dgvTemporal.RowCount.ToString();
            if (Convert.ToInt32(lbltemporal.Text) > 0)
            {
                btnExcel.Enabled = false;
            }
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            this.lblEstado.Text = "Procesando Datos";
            met.importarExcel(dgvDatos, "PPTO");
            this.lblTotal.Text = Convert.ToString(dgvDatos.RowCount);
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatos.RowCount < 1)
                {
                    met.MensajeError("NO EXISTEN DATOS PARA REALIZAR LA CARGA");
                }
                else
                {
                    this.lblEstado.Text = "Procesando Datos ...";
                    string rpta = "";
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        oN.insert_TempInsumo(
                                    Convert.ToInt32(row.Cells["ANIO"].Value.ToString()),
                                    Convert.ToInt32(row.Cells["PER"].Value.ToString()),
                                    row.Cells["COD_CECO"].Value.ToString(),
                                    Convert.ToInt32(row.Cells["COD_CUENTA"].Value.ToString()),
                                    Convert.ToInt32(row.Cells["COD_MATERIAL"].Value.ToString()),
                                    row.Cells["DESC_MATERIAL"].Value.ToString(),
                                    Convert.ToDecimal(row.Cells["CANT"].Value.ToString())
                                    );
                       // progressBar.Value = progressBar.Value + 1;
                    }
                    dgvDatos.DataSource = null; 
                    dgvDatos.Rows.Clear();    
                    dgvDatos.Columns.Clear();
                    //progressBar.Value = 0;

                    //rpta = oN.ope_Reemplazo_DATA_PPTO();
                    //if (rpta.Equals("OK"))
                    //{
                    rpta = oN.insert_InsumoPPTO(1);
                    //}
                    if (rpta.Equals("OK"))
                    {
                        lst_TemporalPPTO();
                        met.MensajeOK("DATOS REGISTRADOS");
                        this.lblEstado.Text = "";
                    }
                } 
            }
            catch (Exception ex)
            {
                met.MensajeError(ex.ToString());
            }
        }

        private void FRM_PPTO_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTemporal.RowCount < 1)
                {
                    met.MensajeError("NO EXISTEN DATOS PARA REALIZAR LA CARGA");
                }
                else
                {
                    string rpta = "";
                    rpta = oN.insert_InsumoPPTO(1);
                    if (rpta.Equals("OK"))
                    {
                        lst_TemporalPPTO();
                        met.MensajeOK("DATOS REGISTRADOS");
                        
                    }
                }
            }
            catch (Exception ex)
            {
                met.MensajeError(ex.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTemporal.Rows)
            {
                if (Convert.ToBoolean(row.Cells["SELEC"].Value))
                {
                    oN.delete_TempInsumo(Convert.ToInt32(row.Cells["cod_temp"].Value));
                }
            }
            lst_TemporalPPTO();
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void chkEliminar_CheckedChanged_1(object sender, EventArgs e)
        {
            bool isChecked = chkEliminar.Checked;

            // Recorre todas las filas del DataGridView
            foreach (DataGridViewRow row in dgvTemporal.Rows)
            {
                // Verifica si la celda en la columna de CheckBox no está nula
                if (row.Cells["SELEC"] != null)
                {
                    // Accede a la celda del CheckBox y establece su valor según el estado del CheckBox maestro
                    DataGridViewCheckBoxCell checkBoxCell = row.Cells["SELEC"] as DataGridViewCheckBoxCell;
                    checkBoxCell.Value = isChecked;
                }
            }
        }
    }
}
