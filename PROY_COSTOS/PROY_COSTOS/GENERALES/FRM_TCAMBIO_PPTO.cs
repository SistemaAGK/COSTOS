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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROY_COSTOS
{
    public partial class FRM_TCAMBIO_PPTO : Form
    {
        Metodos met = new Metodos();
        DataView oDv = new DataView();
        //Metodos met = new Metodos();
        N_TCAMBIO oN = new N_TCAMBIO();

        private static FRM_TCAMBIO_PPTO _Instancia;
        public static FRM_TCAMBIO_PPTO GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_TCAMBIO_PPTO();
            }
            return _Instancia;
        }
        public FRM_TCAMBIO_PPTO()
        {
            InitializeComponent();
            ListarDatos();
            //this.txtTipoCambio.Text = string.Empty;
        }
        private void ListarDatos()
        {
            pnlDatos.Visible = true;
            pnlExcel.Visible = false;
            oDv = new DataView(oN.lst_TipoCambio(1));
            dgbDatos.DataSource = oDv;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatosExcel.RowCount < 1)
                {
                    met.MensajeError("NO EXISTEN DATOS PARA REALIZAR LA CARGA");
                }
                else
                {
                    string rpta = "";
                    if (dgvDatosExcel.RowCount>0)
                    {
                        foreach (DataGridViewRow row in dgvDatosExcel.Rows)
                        {
                            rpta = oN.insert_TipoCambio(
                                        Convert.ToInt32(row.Cells["ANIO"].Value.ToString()),
                                        Convert.ToInt32(row.Cells["PERIODO"].Value.ToString()),
                                        Convert.ToDecimal(row.Cells["TIPO_CAMBIO"].Value.ToString()),
                                        1
                            );
                        }
                    }
                    else
                    {
                        met.MensajeError("No existen datos de carga");
                    }
                    if (rpta.Equals("OK"))
                    {
                        ListarDatos();
                        dgvDatosExcel.DataSource = null;
                        dgvDatosExcel.Rows.Clear();
                        dgvDatosExcel.Columns.Clear();
                  
                    }
                }
            }
            catch (Exception ex)
            {
                met.MensajeError(ex.Message + ex.StackTrace);
            }
        }
        private void FRM_TCAMBIO_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            //pnlControles.Visible = false;
            pnlDatos.Visible = false;
            pnlExcel.Visible = true;
            met.importarExcel(dgvDatosExcel, "TCAMBIO_MES");
            this.lblTotal.Text = Convert.ToString(dgvDatosExcel.RowCount);
        }
    }
}
