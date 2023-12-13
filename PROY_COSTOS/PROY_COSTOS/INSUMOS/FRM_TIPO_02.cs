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
    public partial class FRM_TIPO_02 : Form
    {
        DataView oDv = new DataView();
        Metodos met = new Metodos();
        N_MATERIAL oN = new N_MATERIAL();
        private static FRM_TIPO_02 _Instancia;
        public static FRM_TIPO_02 GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_TIPO_02();
            }
            return _Instancia;
        }
        public FRM_TIPO_02()
        {
            InitializeComponent();
            this.ver_TipoMaterial();
            this.txtDescripcion.Text = string.Empty;
            ListarDatos();
            this.dgbDatos.Columns[0].Visible = false;
            this.dgbDatos.Columns[1].Visible = false;
            //this.dgbDatos.Columns[2].Visible = false;

        }
        private void ver_TipoMaterial()
        {
            cboTipo01.DataSource = oN.lst_TipoMaterial("");
            cboTipo01.DisplayMember = "tmaterial_nombre";
            cboTipo01.ValueMember = "cod_tmaterial";
        }
        private void ListarDatos()
        {
            oDv = new DataView(oN.lst_MaterialTipo2());
            dgbDatos.DataSource = oDv;
        }
        private void FRM_TIPO_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void txtTipo_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtDescripcion.Text == string.Empty)
                {
                    txtDescripcion.Focus();
                }
                else
                {
                    rpta = oN.ope_MaterialTipo2(Convert.ToInt32(this.cboTipo01.SelectedValue.ToString()), txtDescripcion.Text.Trim());
                    if (rpta == "OK")
                    {
                        ListarDatos();
                        this.txtDescripcion.Text = string.Empty;
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
