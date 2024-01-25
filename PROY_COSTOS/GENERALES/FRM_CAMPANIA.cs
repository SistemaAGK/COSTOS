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
    public partial class FRM_CAMPANIA : Form
    {
        DataView oDv = new DataView();
        Metodos met = new Metodos();
        N_MAESTROS oN = new N_MAESTROS();
        private static FRM_CAMPANIA _Instancia;
        public static FRM_CAMPANIA GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_CAMPANIA();
            }
            return _Instancia;
        }
        public FRM_CAMPANIA()
        {
            InitializeComponent();
            ListarDatos();
            pnlControles.Enabled = false;
            btnGuardar.Enabled = false;
        }
        private void ListarDatos()
        {
            oDv = new DataView(oN.lstCampania(2,""));
            dgbDatos.DataSource = oDv;
        }
        private void FRM_CAMPANIA_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void txtFechaInicio_TextChanged(object sender, EventArgs e)
        {
            int longFecha;
            longFecha = this.txtFechaInicio.TextLength;
            switch (longFecha)
            {
                case 2:
                    this.txtFechaInicio.Text = this.txtFechaInicio.Text + "/";
                    txtFechaInicio.Select(txtFechaInicio.Text.Length, 0);
                    break;
                case 5:
                    this.txtFechaInicio.Text = this.txtFechaInicio.Text + "/";
                    txtFechaInicio.Select(txtFechaInicio.Text.Length, 0);
                    break;
                default:
                    break;
            }
        }

        private void txtFechaFin_TextChanged(object sender, EventArgs e)
        {
            int longFecha;
            longFecha = this.txtFechaFin.TextLength;
            switch (longFecha)
            {
                case 2:
                    this.txtFechaFin.Text = this.txtFechaFin.Text + "/";
                    txtFechaFin.Select(txtFechaFin.Text.Length, 0);
                    break;
                case 5:
                    this.txtFechaFin.Text = this.txtFechaFin.Text + "/";
                    txtFechaFin.Select(txtFechaFin.Text.Length, 0);
                    break;
                default:
                    break;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
            pnlControles.Enabled = true;
            btnGuardar.Enabled = true;
        }
        private void limpiar()
        {
            txtCampania.Text = string.Empty;
            txtFechaFin.Text = string.Empty;
            txtFechaInicio.Text = string.Empty;
        }
        private void colorNormal()
        {
            this.txtCampania.BackColor = System.Drawing.Color.White;
            this.txtFechaInicio.BackColor = System.Drawing.Color.White;
            this.txtFechaFin.BackColor = System.Drawing.Color.White;
        }
        public bool validarDatos()
        {
            DateTime fecha;
            bool validar = false;
            if (txtCampania.Text == string.Empty)
            {
                colorNormal();
                txtCampania.BackColor = System.Drawing.Color.LightPink;
                txtCampania.Focus();
                return validar = false;
            }
            else if (!(DateTime.TryParse(txtFechaInicio.Text, out fecha)))
            {
                colorNormal();
                txtFechaInicio.BackColor = System.Drawing.Color.LightPink;
                txtFechaInicio.Focus();
                return validar = false;
            }
            else if (!(DateTime.TryParse(txtFechaFin.Text, out fecha)))
            {
                colorNormal();
                txtFechaFin.BackColor = System.Drawing.Color.LightPink;
                txtFechaFin.Focus();
                return validar = false;
            }
            else
            {
                colorNormal();
                return validar = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fecha;
            try
            {
                string rpta = "";
                if (validarDatos())
                {
                    rpta = oN.mtto_campania
                                (
                                    this.txtCampania.Text.Trim().ToUpper(),
                                    this.txtFechaInicio.Text.Trim(),
                                    this.txtFechaFin.Text.Trim(),
                                    "osanchez",0,"N"

                                ); ;
                }
                limpiar();
                ListarDatos();
                pnlControles.Enabled = false;
                btnGuardar.Enabled = false;
                pnlControles.Enabled = false;
                btnNuevo.Enabled = true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
