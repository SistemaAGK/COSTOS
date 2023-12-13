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
    public partial class FRM_TCAMBIO_DIARIO : Form
    {
        Metodos met = new Metodos();
        DataView oDv = new DataView();
        //Metodos met = new Metodos();
        N_TCAMBIO oN = new N_TCAMBIO();
        private static FRM_TCAMBIO_DIARIO _Instancia;
        public static FRM_TCAMBIO_DIARIO GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_TCAMBIO_DIARIO();
            }
            return _Instancia;
        }
        public FRM_TCAMBIO_DIARIO()
        {
            InitializeComponent();
            ListarDatos();
        }
        private void ListarDatos()
        {
            pnlDatos.Visible = true;
            pnlExcel.Visible = false;
            oDv = new DataView(oN.lstTipoCambioDiario());
            dgbDatos.DataSource = oDv;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //pnlControles.Visible = false;
            pnlDatos.Visible = false;
            pnlExcel.Visible = true;
            met.importarExcel(dgvDatosExcel, "TCAMBIO_DIARIO");
            this.lblTotal.Text = Convert.ToString(dgvDatosExcel.RowCount);
        }

        private void FRM_TCAMBIO_DIARIO_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
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
                    if (dgvDatosExcel.RowCount > 0)
                    {
                        foreach (DataGridViewRow row in dgvDatosExcel.Rows)
                        {
                            rpta = oN.insertTipoCambioDiario(
                                        Convert.ToDateTime(row.Cells["FECHA"].Value.ToString()),
                                        Convert.ToDecimal(row.Cells["TCAMBIO"].Value.ToString())
                                    
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
    }
}
