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

namespace PROY_COSTOS.INSUMOS
{
    public partial class FRM_CONSUL_REAL_DIARIO : Form
    {
        DataView oDv = new DataView();
        Metodos met = new Metodos();
        N_MAESTROS oSedN = new N_MAESTROS();
        N_REAL_INSUMOS oN = new N_REAL_INSUMOS();
        private static FRM_CONSUL_REAL_DIARIO _Instancia;
        public static FRM_CONSUL_REAL_DIARIO GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_CONSUL_REAL_DIARIO();
            }
            return _Instancia;
        }
        public FRM_CONSUL_REAL_DIARIO()
        {
            InitializeComponent();
            cbo_Sede();
            cbo_Cultivo();
            lblverPPTO01.Text = Metodos.variablesGlobales.ver_ppto.ToString();
            lblVerPLAN02.Text = Metodos.variablesGlobales.ver_plan.ToString();
        }
        private void cbo_Sede()
        {
            cboSede.DataSource = oSedN.lst_Sede();
            cboSede.DisplayMember = "sede";
            cboSede.ValueMember = "cod_sede";
        }
        private void cbo_Fundo(int cod_sede)
        {
            cboFundo.DataSource = oSedN.lst_Fundo(cod_sede);
            cboFundo.DisplayMember = "fundo_nombre";
            cboFundo.ValueMember = "cod_fundo";
        }
        private void cbo_Cultivo()
        {
            cboCultivo.DataSource = oSedN.lst_Cultivo();
            cboCultivo.DisplayMember = "cultivo_nombre";
            cboCultivo.ValueMember = "cod_cultivo";
        }
        private void lst_REAL(int sede, int fundo, int cultivo)
        {
            oDv = new DataView(oN.lst_REAL(1, sede, fundo, cultivo));
            dgvDatos.DataSource = oDv;
        }
        private void FRM_CONSUL_REAL_DIARIO_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
        private void cboSede_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                cbo_Fundo(Convert.ToInt32(this.cboSede.SelectedValue.ToString()));
                this.cboFundo.Focus();
            }
            catch (Exception)
            {
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lst_REAL(Convert.ToInt32(this.cboSede.SelectedValue.ToString()), Convert.ToInt32(this.cboFundo.SelectedValue.ToString()), Convert.ToInt32(this.cboCultivo.SelectedValue.ToString()));
            this.lblCnt.Text = Convert.ToString(dgvDatos.RowCount);
        }
    }
}
