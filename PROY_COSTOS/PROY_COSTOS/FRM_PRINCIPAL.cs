using PROY_COSTOS.GENERALES;
using PROY_COSTOS.INSUMOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROY_COSTOS
{
    public partial class FRM_PRINCIPAL : Form
    {
        private int childFormNumber = 0;
        private static FRM_PRINCIPAL _Instancia;
        Metodos met = new Metodos();
        public static FRM_PRINCIPAL GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_PRINCIPAL();
            }
            return _Instancia;
        }
        public FRM_PRINCIPAL()
        {
            InitializeComponent();
            lblCampania.Text = met.camp_Actual();
            met.ver_tcambioDiario();
            met.ver_tcambioMensual();
            met.ver_VersionesPPTO();
            met.ver_VersionesPLAN();
            lblTipoCambio_DIARIO.Text = Metodos.variablesGlobales.tcambio_diario.ToString("N2");
            lblTipoCambio_PPTO.Text = Metodos.variablesGlobales.tcambio_mensual.ToString("N2");

        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FRM_TCAMBIO_PPTO frm = FRM_TCAMBIO_PPTO.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void iNSUMOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_MATERIAL frm = FRM_MATERIAL.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cECOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CECO frm = FRM_CECO.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pLANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_PLAN frm = FRM_PLAN.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pPTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_PPTO_INS frm = FRM_PPTO_INS.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FRM_CAMPANIA frm = FRM_CAMPANIA.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }
        private void cECOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRM_CECO frm = FRM_CECO.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tCAMBIODIARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_TCAMBIO_DIARIO frm = FRM_TCAMBIO_DIARIO.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cONSUMOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_REAL_INS frm = FRM_REAL_INS.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pLANToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRM_PLAN frm = FRM_PLAN.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mATERIALESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_MATERIAL frm = FRM_MATERIAL.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void FRM_PRINCIPAL_Load(object sender, EventArgs e)
        {

        }

        private void vERPPTOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRM_CONSUL_PPTO frm = FRM_CONSUL_PPTO.GetInstancia();
            frm.MdiParent = this;
            frm.Show();/*****************/
        }

        private void tIPOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_TIPO frm = FRM_TIPO.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mOTIVOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_MOTIVO frm = FRM_MOTIVO.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void sEMANAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CONSUL_REAL_DIARIO frm = FRM_CONSUL_REAL_DIARIO.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pORSEMANAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CONSUL_REAL_SEMANA frm = FRM_CONSUL_REAL_SEMANA.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pORMESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CONSUL_REAL_MENSUAL frm = FRM_CONSUL_REAL_MENSUAL.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void vERPPTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_VER_PPTO frm = FRM_VER_PPTO.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void vERPLANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_VER_PLAN frm = FRM_VER_PLAN.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void vERACTIVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CONSUL_PPTO_REAL_ACT frm = FRM_CONSUL_PPTO_REAL_ACT.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cOMPLETAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CONSUL_PPTO_REAL_GENE frm = FRM_CONSUL_PPTO_REAL_GENE.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tIPO02ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_TIPO_02 frm = FRM_TIPO_02.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void aTRIBUTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_INSUMOS_ATRIB frm = FRM_INSUMOS_ATRIB.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            EMPAQUE.FRM_ME_CONSUMO_TEORICO frm = new EMPAQUE.FRM_ME_CONSUMO_TEORICO();

            frm.MdiParent = this;
            frm.Show();
        }

        private void cOMPARATIVOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EMPAQUE.FRM_ME_COMPARATIVO frm = new EMPAQUE.FRM_ME_COMPARATIVO();

            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            MANO_DE_OBRA.FRM_MO_PPTO frm = new MANO_DE_OBRA.FRM_MO_PPTO();

            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            MANO_DE_OBRA.FRM_MO_REAL frm = new MANO_DE_OBRA.FRM_MO_REAL();

            frm.MdiParent = this;
            frm.Show();
        }

        private void cONSULTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MANO_DE_OBRA.FRM_MO_CONSULTA frm = new MANO_DE_OBRA.FRM_MO_CONSULTA();

            frm.MdiParent = this;
            frm.Show();
        }
    }
}
