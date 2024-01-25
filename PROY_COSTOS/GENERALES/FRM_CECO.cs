using NEGOCIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROY_COSTOS
{
    public partial class FRM_CECO : Form
    {
        DataView oDv = new DataView();
        Metodos met = new Metodos();
        N_CECO oN = new N_CECO();
        N_MAESTROS oSedN = new N_MAESTROS();
        private bool isNuevo = false;
        private bool isEditar = false;
        
        private static FRM_CECO _Instancia;
        public static FRM_CECO GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_CECO();
            }
            return _Instancia;
        }
        public FRM_CECO()
        {
            InitializeComponent();
            cbo_Sede();
            cbo_Cultivo();
            cbo_indicador();
            cbo_Grupo();
            cbo_Tipo();
            ListarDatos(1);
            Limpiar();
            Botones(2);
            this.dgbDatos.Columns[1].Visible = false;
            this.dgbDatos.Columns[3].Visible = false;
            this.dgbDatos.Columns[5].Visible = false;
            this.dgbDatos.Columns[7].Visible = false;
            this.dgbDatos.Columns[9].Visible = false;
            this.dgbDatos.Columns[11].Visible = false;
            this.dgbDatos.Columns[14].Visible = false;
            this.dgbDatos.Columns[17].Visible = false;
            this.dgbDatos.Columns[18].Visible = false;
            
        }
        private void Limpiar()
        {
            this.txtCECO.Text = string.Empty;
            this.txtSuperficie.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
        }
        private void colorNormal()
        {
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtCECO.BackColor = System.Drawing.Color.White;
            this.txtSuperficie.BackColor = System.Drawing.Color.White;
        }
        public bool validarDatos()
        {
            DateTime fecha;
            bool validar = false;
            if (txtCECO.Text == string.Empty)
            {
                colorNormal();
                txtCECO.BackColor = System.Drawing.Color.LightPink;
                txtCECO.Focus();
                return validar = false;
            }
            else if (txtSuperficie.Text == string.Empty)
            {
                colorNormal();
                txtSuperficie.BackColor = System.Drawing.Color.LightPink;
                txtSuperficie.Focus();
                return validar = false;
            }
            else if (txtDescripcion.Text == string.Empty)
            {
                colorNormal();
                txtDescripcion.BackColor = System.Drawing.Color.LightPink;
                txtDescripcion.Focus();
                return validar = false;
            }
            else
            {
                colorNormal();
                return validar = true;
            }
        }
        private void Botones(int ope)
        {
            if (ope == 1) /*PRESIONO NUEVO O CANCELAR*/
            {
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
                pnlControles.Enabled = true;
            }
            else if (ope == 2)/*PRESIONO GUARDAR O ELIMINAR*/
            {
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
                pnlControles.Enabled = false;
            }
        }
        private void ListarDatos(int opc)
        {
            oDv = new DataView(oN.lst_CECO(opc));
            dgbDatos.DataSource = oDv;
        }
        /*INICIO_COMBOS_MANTTO*/
        private void cbo_indicador()
        {
            cboDepartamento.DataSource = oSedN.lst_Indicador();
            cboDepartamento.DisplayMember = "abrev";
            cboDepartamento.ValueMember = "cod_indicador";
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
        private void cbo_Gerencia(int cod_sede)
        {
            cboGerencia.DataSource = oSedN.lst_Gerencia(cod_sede);
            cboGerencia.DisplayMember = "genrencia";
            cboGerencia.ValueMember = "cod_gerencia";
        }
        private void cbo_Departamento(int cod_gerencia)
        {
            cboDepartamento.DataSource = oSedN.lst_Departamento(cod_gerencia);
            cboDepartamento.DisplayMember = "departamento";
            cboDepartamento.ValueMember = "cod_dpto";
        }
        private void cbo_Grupo()
        {
            cboGrupo.DataSource = oSedN.lst_Gupo();
            cboGrupo.DisplayMember = "grupo_ceco";
            cboGrupo.ValueMember = "cod_grp_ceco";
        }
        private void cbo_Tipo()
        {
            cboTipo.DataSource = oSedN.lst_Tipo();
            cboTipo.DisplayMember = "tipo_ceco";
            cboTipo.ValueMember = "cod_tip_ceco";
        }
        private void cbo_Cultivo()
        {
            cboCultivo.DataSource = oSedN.lst_Cultivo();
            cboCultivo.DisplayMember = "cultivo_nombre";
            cboCultivo.ValueMember = "cod_cultivo";
        }
        /*FIN_COMBOS_MANTTO*/
        /*INICIO_COMBOS_MASIVO*/
        /*FIN_COMBOS_MASIVO*/
        private void dgbDatos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgbDatos.CurrentRow != null)
                {
                    this.isNuevo = false;
                    this.isEditar = true;
                    this.cboSede.SelectedValue = Convert.ToInt32(this.dgbDatos.CurrentRow.Cells["cod_sede"].Value);
                    this.cboFundo.SelectedValue = Convert.ToInt32(this.dgbDatos.CurrentRow.Cells["cod_fundo"].Value);
                    this.cboGerencia.SelectedValue = Convert.ToInt32(this.dgbDatos.CurrentRow.Cells["cod_gerencia"].Value);
                    this.cboDepartamento.SelectedValue = Convert.ToInt32(this.dgbDatos.CurrentRow.Cells["cod_dpto"].Value);
                    this.cboGrupo.SelectedValue = Convert.ToInt32(this.dgbDatos.CurrentRow.Cells["cod_grp_ceco"].Value);
                    this.cboTipo.SelectedValue = Convert.ToInt32(this.dgbDatos.CurrentRow.Cells["cod_tip_ceco"].Value);
                    this.cboCultivo.SelectedValue = Convert.ToInt32(this.dgbDatos.CurrentRow.Cells["cod_cultivo"].Value);
                    this.txtCECO.Text = Convert.ToString(this.dgbDatos.CurrentRow.Cells["cod_ceco"].Value);
                    this.txtDescripcion.Text = Convert.ToString(this.dgbDatos.CurrentRow.Cells["ceco_nombre"].Value);
                    this.txtSuperficie.Text = Convert.ToString(this.dgbDatos.CurrentRow.Cells["superficie"].Value);
                    this.lblFlag.Text = Convert.ToString(this.dgbDatos.CurrentRow.Cells["flag_pep"].Value);
                    Botones(1);
                    txtSuperficie.Focus();
                }
            }
            catch (Exception)
            {
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Botones(1);
            ListarDatos(11);
            this.isNuevo = true;
            this.isEditar = false;
            this.txtCECO.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Botones(2);
            ListarDatos(1);
            this.isNuevo = false;
            this.isEditar = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.validarDatos())
                {
                    if (this.isNuevo)
                    {
                        rpta = oN.ope_CECO(1,
                                            this.txtCECO.Text.Trim(),
                                            Convert.ToInt32(this.cboSede.SelectedValue.ToString()),
                                            Convert.ToInt32(this.cboFundo.SelectedValue.ToString()),
                                            Convert.ToInt32(this.cboDepartamento.SelectedValue.ToString()),
                                            Convert.ToInt32(this.cboGrupo.SelectedValue.ToString()),
                                            Convert.ToInt32(this.cboTipo.SelectedValue.ToString()),
                                            this.txtDescripcion.Text.Trim(),
                                            Convert.ToInt32(this.cboCultivo.SelectedValue.ToString()),
                                            Convert.ToDecimal(this.txtSuperficie.Text),
                                            1 /*ENVIADO DE VARIABLE GLOBAL*/,
                                            0
                                            ) ;
                    }
                    else
                    {
                        rpta = oN.ope_CECO(2,
                                            this.txtCECO.Text.Trim(),
                                            Convert.ToInt32(this.cboSede.SelectedValue.ToString()),
                                            Convert.ToInt32(this.cboFundo.SelectedValue.ToString()),
                                            Convert.ToInt32(this.cboDepartamento.SelectedValue.ToString()),
                                            Convert.ToInt32(this.cboGrupo.SelectedValue.ToString()),
                                            Convert.ToInt32(this.cboTipo.SelectedValue.ToString()),
                                            this.txtDescripcion.Text.Trim(),
                                            Convert.ToInt32(this.cboCultivo.SelectedValue.ToString()),
                                            Convert.ToDecimal(this.txtSuperficie.Text),
                                            1 /*ENVIADO DE VARIABLE GLOBAL*/,
                                            Convert.ToInt32(this.lblFlag.Text.ToString())
                                            );
                    }
                }
                if (rpta.Equals("OK"))
                {
                    ListarDatos(1);
                    Botones(2);
                    Limpiar();
                    colorNormal();
                    this.isNuevo = false;
                    this.isEditar = false;
                    btnNuevo.Focus();
                }
                else
                {
                    met.MensajeError(rpta);
                }
            }
            catch (Exception ex)
            {
                met.MensajeError(ex.Message + ex.StackTrace);
            }
        }

        private void cboSede_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                cbo_Fundo(Convert.ToInt32(this.cboSede.SelectedValue.ToString()));
                cbo_Gerencia(Convert.ToInt32(this.cboSede.SelectedValue.ToString()));
                //this.cboFundo.Focus();
            }
            catch (Exception)
            {
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            // met.importarExcel(dgvMasivo, "INS-01");
            met.importarExcel(dgvMasivo, "CECO");
            this.lblCantidad.Text = Convert.ToString(dgvMasivo.RowCount);
        }
        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMasivo.RowCount < 1)
                {
                    met.MensajeError("NO EXISTEN DATOS PARA REALIZAR LA CARGA");
                }
                else
                {
                    progressBar.Maximum = Convert.ToInt32(dgvMasivo.RowCount);
                    foreach (DataGridViewRow row in dgvMasivo.Rows)
                    {
                        oN.ope_CECO(
                            1,
                            row.Cells["cod_ceco"].Value.ToString().Trim(),
                            Convert.ToInt32(row.Cells["cod_sede"].Value.ToString()),
                            Convert.ToInt32(row.Cells["cod_fundo"].Value.ToString()),
                            Convert.ToInt32(row.Cells["cod_dpto"].Value.ToString()),
                            Convert.ToInt32(row.Cells["cod_grp_ceco"].Value.ToString()),
                            Convert.ToInt32(row.Cells["cod_tip_ceco"].Value.ToString()),
                            row.Cells["ceco_nombre"].Value.ToString().Trim().ToUpper(),
                            Convert.ToInt32(row.Cells["cod_cultivo"].Value.ToString()),
                            Convert.ToDecimal(row.Cells["superficie"].Value.ToString()),
                            1,
                            0 //Convert.ToInt32(row.Cells["flag_pep"].Value.ToString())
                                    );
                        progressBar.Value = progressBar.Value + 1; 
                    }ListarDatos(1);
                    dgvMasivo.DataSource = null;
                    dgvMasivo.Rows.Clear();
                    dgvMasivo.Columns.Clear();
                    progressBar.Value = 0;
                }


                
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void FRM_CECO_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void cboGerencia_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                cbo_Departamento(Convert.ToInt32(this.cboGerencia.SelectedValue.ToString()));
                //this.cboDepartamento.Focus();
            }
            catch (Exception)
            {
            }
        }

        private void cboSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    cbo_Fundo(Convert.ToInt32(this.cboSede.SelectedValue.ToString()));
            //    cbo_Gerencia(Convert.ToInt32(this.cboSede.SelectedValue.ToString()));
            //    this.cboFundo.Focus();
            //}
            //catch (Exception)
            //{
            //}
        }
    }
}
