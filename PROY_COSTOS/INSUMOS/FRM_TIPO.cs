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
    public partial class FRM_TIPO : Form
    {
        DataView oDv = new DataView();
        Metodos met = new Metodos();
        N_MATERIAL oN = new N_MATERIAL();
        private static FRM_TIPO _Instancia;
        public static FRM_TIPO GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_TIPO();
            }
            return _Instancia;
        }
        public FRM_TIPO()
        {
            InitializeComponent();
            this.txtTipo.Text = string.Empty;
            ListarDatos("");
          //  this.dgbDatos.Columns[0].Visible = false;
        }
        private void ListarDatos(string tipo)
        {
            oDv = new DataView(oN.lst_TipoMaterial(tipo));
            dgbDatos.DataSource = oDv;
        }
        private void FRM_TIPO_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void txtTipo_TextChanged(object sender, EventArgs e)
        {
            ListarDatos(txtTipo.Text.Trim());
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtTipo.Text == string.Empty)
                {
                    txtTipo.Focus();
                }
                else
                {
                    rpta = oN.ope_MaterialTipo(txtTipo.Text.Trim());
                    if (rpta == "OK")
                    {
                        ListarDatos("");
                        this.txtTipo.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                met.MensajeError (ex.ToString());
            }
        }
    }
}
