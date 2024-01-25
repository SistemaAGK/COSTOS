using NEGOCIO;
using OfficeOpenXml.FormulaParsing.ExpressionGraph.FunctionCompilers;
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
    public partial class FRM_INSUMOS_ATRIB : Form
    {
        DataView oDv = new DataView();
        Metodos met = new Metodos();
        N_MATERIAL oN = new N_MATERIAL();
        private static FRM_INSUMOS_ATRIB _Instancia;
        public static FRM_INSUMOS_ATRIB GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_INSUMOS_ATRIB();
            }
            return _Instancia;
        }
        public FRM_INSUMOS_ATRIB()
        {
            InitializeComponent();
            lst_Atributos();
            this.dgvTemporal.Columns[0].Visible = false;
            this.dgvTemporal.Columns[2].Visible = false;
            this.dgvTemporal.Columns[9].Visible = false;
            this.dgvTemporal.Columns[8].Visible = false;
            this.dgvTemporal.Columns[11].Visible = false; 
            this.dgvTemporal.Columns[13].Visible = false;
            this.dgvTemporal.Columns[15].Visible = false;
            dgvTemporal.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ver_Motivo(); 
            ver_Tipo01();
            this.lblCodigoAtrib.Text = string.Empty;
            this.lblCodSede.Text = string.Empty;
            this.lblCodCultivo.Text = string.Empty;
            this.lblCodMaterial.Text = string.Empty;
            this.lblCodArea.Text = string.Empty;

            //this.dgvTemporal.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
        private void ver_Motivo()
        {
            cboMotivo.DataSource = oN.lst_Motivo("");
            cboMotivo.DisplayMember = "motivo";
            cboMotivo.ValueMember = "cod_motivo";
        }
        private void ver_Tipo01()
        {
            cboTipo01.DataSource = oN.lst_MaterialTipo01();
            cboTipo01.DisplayMember = "tmaterial_nombre";
            cboTipo01.ValueMember = "cod_tmaterial";
        }
        private void ver_Tipo02(int t01)
        {
            cboTipo02.DataSource = oN.lst_MaterialTipo02(t01);
            cboTipo02.DisplayMember = "tmaterial_nombre2";
            cboTipo02.ValueMember = "cod_tmaterial2";
        }
        private void lst_Atributos()
        {
            oDv = new DataView(oN.lst_MaterialAtributos());
            dgvTemporal.DataSource = oDv;
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            //met.importarExcel(dgvDatos, "MATE-TIPO-INSUMO");
            met.importarExcel(dgvDatos, "ATRIBUTOS");
            this.lblTotal.Text = Convert.ToString(dgvDatos.RowCount);
        }

        private void FRM_REAL_INS_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void dgvTemporal_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTemporal.CurrentRow != null)
                {
                    this.lblCodigoAtrib.Text = Convert.ToString(this.dgvTemporal.CurrentRow.Cells["cod_atrib"].Value);
                    this.cboTipo01.SelectedValue = Convert.ToInt32(this.dgvTemporal.CurrentRow.Cells["cod_tmaterial"].Value);
                    this.cboTipo02.SelectedValue = Convert.ToInt32(this.dgvTemporal.CurrentRow.Cells["cod_tmaterial2"].Value);
                    this.cboMotivo.SelectedValue = Convert.ToInt32(this.dgvTemporal.CurrentRow.Cells["cod_motivo"].Value);

                    this.lblCodSede.Text = Convert.ToString(this.dgvTemporal.CurrentRow.Cells["cod_sede"].Value);
                    this.lblCodCultivo.Text = Convert.ToString(this.dgvTemporal.CurrentRow.Cells["cod_cultivo"].Value);
                    this.lblCodMaterial.Text = Convert.ToString(this.dgvTemporal.CurrentRow.Cells["cod_material"].Value);
                    this.lblCodArea.Text = Convert.ToString(this.dgvTemporal.CurrentRow.Cells["cod_area"].Value);
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                string llave = lblCodSede.Text + lblCodCultivo.Text + lblCodMaterial.Text + lblCodArea.Text;
                if (this.lblCodigoAtrib.Text == "0")
                {

                    if (this.cboTipo02.Text != "")
                    {
                        rpta = oN.ope_MaterialAtributos(1,1,
                        Convert.ToInt32(lblCodSede.Text.Trim()), 
                        Convert.ToInt32(lblCodCultivo.Text.Trim()), 
                        Convert.ToInt32(lblCodMaterial.Text.Trim()), 
                        Convert.ToInt32(lblCodArea.Text.Trim()), 
                        Convert.ToInt32(this.cboTipo01.SelectedValue.ToString()), 
                        Convert.ToInt32(this.cboTipo02.SelectedValue.ToString()), 
                        Convert.ToInt32(this.cboMotivo.SelectedValue.ToString()),
                        llave);
                        
                    }
                    else
                    {
                        met.MensajeError("Seleccion Incorrecta");
                        rpta = "";
                    }  
                }
                else
                {
                    rpta = oN.ope_MaterialAtributos(2, Convert.ToInt32(lblCodigoAtrib.Text.Trim()),
                        Convert.ToInt32(lblCodSede.Text.Trim()),
                        Convert.ToInt32(lblCodCultivo.Text.Trim()),
                        Convert.ToInt32(lblCodMaterial.Text.Trim()),
                        Convert.ToInt32(lblCodArea.Text.Trim()),
                        Convert.ToInt32(this.cboTipo01.SelectedValue.ToString()),
                        Convert.ToInt32(this.cboTipo02.SelectedValue.ToString()),
                        Convert.ToInt32(this.cboMotivo.SelectedValue.ToString()),
                        llave);
                }
                if (rpta.Equals("OK"))
                {
                    lst_Atributos();
                    this.lblCodigoAtrib.Text = string.Empty;
                    this.lblCodSede.Text = string.Empty;
                    this.lblCodCultivo.Text = string.Empty;
                    this.lblCodMaterial.Text = string.Empty;
                    this.lblCodArea.Text = string.Empty;
                }

            }
            catch (Exception)
            {
                //met.MensajeError(ex.Message + ex.StackTrace);
            }
        }

        private void cboTipo01_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ver_Tipo02(Convert.ToInt32(this.cboTipo01.SelectedValue.ToString()));
            }
            catch (Exception)
            {
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            int success_registros = 0;
            try
            {
                if (dgvDatos.RowCount < 1)
                {
                    met.MensajeError("NO EXISTEN DATOS PARA REALIZAR LA CARGA");
                }
                else
                {
                    progressBar.Maximum = Convert.ToInt32(dgvDatos.RowCount);
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                            oN.ope_MaterialAtributos(1,1,
                            Convert.ToInt32(row.Cells["COD_SEDE"].Value.ToString().Trim()),
                            Convert.ToInt32(row.Cells["COD_CULTIVO"].Value.ToString()),
                            Convert.ToInt32(row.Cells["COD_MATERIAL"].Value.ToString()),
                            Convert.ToInt32(row.Cells["COD_CUENTA"].Value.ToString()),
                            Convert.ToInt32(row.Cells["COD_TIP01"].Value.ToString()),
                            Convert.ToInt32(row.Cells["COD_TIP02"].Value.ToString()),
                            Convert.ToInt32(row.Cells["COD_MOTIVO"].Value.ToString()),
                            row.Cells["LLAVE_ATRIB"].Value.ToString()
                            );
                        progressBar.Value = progressBar.Value + 1;
                    }
                    lst_Atributos();
                    dgvDatos.DataSource = null;
                    dgvDatos.Rows.Clear();
                    dgvDatos.Columns.Clear();
                    progressBar.Value = 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
