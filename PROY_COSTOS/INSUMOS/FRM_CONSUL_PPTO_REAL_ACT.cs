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
    public partial class FRM_CONSUL_PPTO_REAL_ACT : Form
    {
        DataView oDv = new DataView();
        Metodos met = new Metodos();
        N_MAESTROS oSedN = new N_MAESTROS();
        N_PPTO_REAL oN = new N_PPTO_REAL(); 
        private static FRM_CONSUL_PPTO_REAL_ACT _Instancia;
        public static FRM_CONSUL_PPTO_REAL_ACT GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_CONSUL_PPTO_REAL_ACT();
            }
            return _Instancia;
        }
        public FRM_CONSUL_PPTO_REAL_ACT()
        {
            InitializeComponent();
            cbo_Sede();
            cbo_Cultivo();
            cbo_Version();
            lblverPPTO01.Text = Metodos.variablesGlobales.ver_ppto.ToString();
            lblVerPLAN02.Text = Metodos.variablesGlobales.ver_plan.ToString();
            //lst_lPPTO();
        }
        private void lst_lPPTO(int sede, int fundo, int cultivo)
        {
            oDv = new DataView(oN.lstConsultaGeneral_PPTOActivo(sede, cultivo, fundo));
            dgvDatos.DataSource = oDv;
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
        private void cbo_Version()
        {
          /*  cboVersion.DataSource = oN.lst_Version(1);
            cboVersion.DisplayMember = "vers_des";
            cboVersion.ValueMember = "cod_vers";*/
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lst_lPPTO(Convert.ToInt32(this.cboSede.SelectedValue.ToString()), Convert.ToInt32(this.cboFundo.SelectedValue.ToString()), Convert.ToInt32(this.cboCultivo.SelectedValue.ToString()));
            this.lblCnt.Text = Convert.ToString(dgvDatos.RowCount);
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

        private void FRM_CONSUL_PPTO_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
