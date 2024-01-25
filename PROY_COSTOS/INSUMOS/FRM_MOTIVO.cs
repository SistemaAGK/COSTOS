using NEGOCIO;
using PROY_COSTOS.GENERALES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROY_COSTOS.INSUMOS
{
    public partial class FRM_MOTIVO : Form
    {
        DataView oDv = new DataView();
        Metodos met = new Metodos();
        N_MATERIAL oN = new N_MATERIAL();
        private static FRM_MOTIVO _Instancia;
        public static FRM_MOTIVO GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_MOTIVO();
            }
            return _Instancia;
        }
        public FRM_MOTIVO()
        {
            InitializeComponent();
            this.txtMotivo.Text = string.Empty;
            ListarDatos("");
            this.dgbDatos.Columns[0].Visible = false;
        }
        private void ListarDatos(string motivo)
        {
            oDv = new DataView(oN.lst_Motivo(motivo));
            dgbDatos.DataSource = oDv;
        }
        private void FRM_MOTIVO_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void txtMotivo_TextChanged(object sender, EventArgs e)
        {
            ListarDatos(txtMotivo.Text.Trim());
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtMotivo.Text == string.Empty)
                {
                    txtMotivo.Focus();
                }
                else
                {
                    rpta = oN.ope_MaterialMotivo(txtMotivo.Text.Trim());
                    if (rpta == "OK")
                    {
                        ListarDatos("");
                        this.txtMotivo.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                met.MensajeError(ex.ToString());
            }
        }
    }
}
