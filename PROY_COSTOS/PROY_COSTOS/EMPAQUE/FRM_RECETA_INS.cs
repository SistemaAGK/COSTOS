using NEGOCIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROY_COSTOS.EMPAQUE
{
    public partial class FRM_RECETA_INS : Form
    {
        DataView oDv = new DataView();
        Metodos met = new Metodos();
        N_RECETA oN = new N_RECETA();

       // N_MAESTROS oMaN = new N_MAESTROS();
        private static FRM_RECETA_INS _Instancia;
        public static FRM_RECETA_INS GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_RECETA_INS();
            }
            return _Instancia;
        }
        public FRM_RECETA_INS()
        {
            InitializeComponent();
            lst_TemporalREAL();
            //this.dgvTemporal.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //lblverPPTO01.Text = Metodos.variablesGlobales.ver_ppto.ToString();
            //lblverPPTO02.Text = Metodos.variablesGlobales.ver_ppto.ToString();
            //lblVerPLAN01.Text = Metodos.variablesGlobales.ver_plan.ToString();
            //lblVerPLAN02.Text = Metodos.variablesGlobales.ver_plan.ToString();
            //cboIndicativo.SelectedIndex = -1;
        }
        private void lst_TemporalREAL()
        {
            //oDv = new DataView(oN.lst_TemporalREAL());
            //dgvTemporal.DataSource = oDv;
            //this.lbltemporal.Text = dgvTemporal.RowCount.ToString();
            //if (Convert.ToInt32(lbltemporal.Text) > 0)
            //{
            //    btnExcel.Enabled = false;
            //}
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            this.lblEstado.Text = "Procesando Datos";
            met.importarExcel(dgvDatos, "RECETA");
            this.lblTotal.Text = Convert.ToString(dgvDatos.RowCount);
            this.lblEstado.Text = "Procesando Datos";
        }

        private void FRM_REAL_INS_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //this.lblEstado.Text = "Procesando Datos";
            //try
            //{
            //    if (dgvDatos.RowCount < 1)
            //    {
            //        met.MensajeError("NO EXISTEN DATOS PARA REALIZAR LA CARGA");
            //    }
            //    else
            //    {
            //        this.lblEstado.Text = "Procesando Datos";
            //        string rpta = "";
            //        foreach (DataGridViewRow row in dgvDatos.Rows)
            //        {
            //            oN.insert_Receta(
            //                        row.Cells["CECO"].Value.ToString(),
            //                        Convert.ToInt32(row.Cells["CUENTA"].Value.ToString()),
            //                        Convert.ToInt32(row.Cells["COD_MATERIAL"].Value.ToString()),
            //                        row.Cells["MATERIAL"].Value.ToString(),
            //                        Convert.ToDateTime(row.Cells["FECHA"].Value.ToString()),
            //                        Convert.ToInt32(row.Cells["ANIO"].Value.ToString()),
            //                        Convert.ToInt32(row.Cells["PERIODO"].Value.ToString()),
            //                        Convert.ToDecimal(row.Cells["CANTIDAD"].Value.ToString()),
            //                        Convert.ToDecimal(row.Cells["COSTO_SOLES"].Value.ToString()),
            //                        row.Cells["USUARIO_ALM"].Value.ToString(),
            //                        row.Cells["NUM_DOC_REF"].Value.ToString(),
            //                        row.Cells["USU_SOLIC"].Value.ToString(),
            //                        row.Cells["NUM_DOCUMENTO"].Value.ToString(),
            //                        row.Cells["CLASE"].Value.ToString(),
            //                        Convert.ToInt32(cboIndicativo.SelectedValue.ToString())
            //                        );
            //        }
            //        dgvDatos.DataSource = null;
            //        dgvDatos.Rows.Clear();
            //        dgvDatos.Columns.Clear();
            //        rpta = oN.opeReemplazo_DATA_REAL();

            //        if (rpta.Equals("OK"))
            //        {
            //            rpta = oN.insert_REAL();
            //        }
                   
            //        if (rpta.Equals("OK"))
            //        {
                        
            //            lst_TemporalREAL();
            //            met.MensajeOK("DATOS REGISTRADOS");
            //            this.lblEstado.Text = "";
            //            cboIndicativo.SelectedIndex = -1;
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dgvTemporal.RowCount < 1)
            //    {
            //        met.MensajeError("NO EXISTEN DATOS PARA REALIZAR LA CARGA");
            //    }
            //    else
            //    {
            //        string rpta = "";
            //        rpta = oN.insert_REAL();
            //        if (rpta.Equals("OK"))
            //        {
            //            met.MensajeOK("DATOS REGISTRADOS");
            //            lst_TemporalREAL();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    met.MensajeError(ex.ToString());
            //}
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in dgvTemporal.Rows)
            //{
            //    if (Convert.ToBoolean(row.Cells["SELEC"].Value))
            //    {
            //        oN.delete_TempREAL(Convert.ToInt32(row.Cells["cod_temp"].Value));
            //    }
            //}
            //lst_TemporalREAL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //oN.insert_REAL();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
