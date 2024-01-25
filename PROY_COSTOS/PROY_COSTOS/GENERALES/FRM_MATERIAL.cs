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

namespace PROY_COSTOS
{
    public partial class FRM_MATERIAL : Form
    {
        DataView oDv = new DataView();
        Metodos met = new Metodos();
        N_MATERIAL oN = new N_MATERIAL();
        N_MAESTROS oMaN = new N_MAESTROS();
        private bool isNuevo = false;
        private bool isEditar = false;
        private static FRM_MATERIAL _Instancia;
        public static FRM_MATERIAL GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_MATERIAL();
            }
            return _Instancia;
        }
        public FRM_MATERIAL()
        {
            InitializeComponent();
            Limpiar();
            ListarDatos(1,"");
            dgbDatos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgbDatos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgbDatos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgbDatos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgbDatos.Columns[4].Visible = false;
            dgbDatos.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgbDatos.Columns[6].Visible = false;
            this.dgbDatos.Columns[7].Visible = false;
            Botones(2);
        }
        private void Limpiar()
        {
            this.txtCodInsumo.Text = string.Empty;
            this.txtInsumo.Text = string.Empty;
            this.cargar_Tipo();
            //this.cargar_Motivo(); 
            cargar_Medida();
            cargar_Indicativo();
        }
        private void colorNormal()
        {
            this.txtCodInsumo.BackColor = System.Drawing.Color.White;
            this.txtInsumo.BackColor = System.Drawing.Color.White;
        }
        public bool validarDatos()
        {
            DateTime fecha;
            bool validar = false;
            if (txtCodInsumo.Text == string.Empty)
            {
                colorNormal();
                txtCodInsumo.BackColor = System.Drawing.Color.LightPink;
                txtCodInsumo.Focus();
                return validar = false;
            }
            else if (txtInsumo.Text == string.Empty)
            {
                colorNormal();
                txtInsumo.BackColor = System.Drawing.Color.LightPink;
                txtInsumo.Focus();
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
        private void ListarDatos(int opc, string insumo)
        {
            oDv = new DataView(oN.lst_Material(opc, insumo));
            dgbDatos.DataSource = oDv;
        }
        private void cargar_Tipo()
        {
            cboFamilia.DataSource = oN.lst_MaterialFamilia();
            cboFamilia.DisplayMember = "familia";
            cboFamilia.ValueMember = "cod_familia";
        }
        //private void cargar_Motivo()
        //{
        //    .DataSource = oN.lst_Motivo("");
        //    cboMotivo.DisplayMember = "motivo";
        //    cboMotivo.ValueMember = "cod_motivo";
        //}
        private void btnExcel_Click(object sender, EventArgs e)
        {
            met.importarExcel(dgvMasivo, "INSUMOS");
            this.lblCantidad.Text = Convert.ToString(dgvMasivo.RowCount);
        }
        private void cargar_Medida()
        {
            cboMedida.DataSource = oMaN.lst_Medida();
            cboMedida.DisplayMember = "medida";
        }
        private void cargar_Indicativo()
        {
            cboIndicativo.DataSource = oMaN.lst_Indicador();
            cboIndicativo.DisplayMember = "indicador";
            cboIndicativo.ValueMember = "cod_indicador";
        }
        private void dgbDatos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgbDatos.CurrentRow != null)
                {
                    this.txtCodInsumo.Text = Convert.ToString(this.dgbDatos.CurrentRow.Cells["codigo"].Value);
                    this.txtInsumo.Text = Convert.ToString(this.dgbDatos.CurrentRow.Cells["material"].Value);
                    this.cboFamilia.SelectedValue = Convert.ToString(this.dgbDatos.CurrentRow.Cells["cod_tmaterial"].Value);
                    this.cboMedida.Text = Convert.ToString(this.dgbDatos.CurrentRow.Cells["und"].Value);
                    this.cboIndicativo.SelectedValue = Convert.ToInt32(this.dgbDatos.CurrentRow.Cells["indicativo"].Value);
                    Botones(1);
                    txtCodInsumo.Focus();
                    this.isNuevo = false;
                    this.isEditar = true;
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
            ListarDatos(1, "");
            this.isNuevo = true;
            this.isEditar = false;
            this.txtCodInsumo.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Botones(2);
            ListarDatos(1, "");
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
                        rpta = oN.ope_Material(1,
                                            Convert.ToInt32(this.txtCodInsumo.Text.Trim()),
                                            Convert.ToInt32(this.cboIndicativo.SelectedValue.ToString()),
                                            Convert.ToInt32(this.cboFamilia.SelectedValue.ToString()),
                                            this.txtInsumo.Text.Trim(),
                                            this.cboMedida.Text.ToString().Trim(),
                                            1/*ENVIADO DE VARIABLE GLOBAL*/
                                            );
                    }
                    else
                    {
                        rpta = oN.ope_Material(2,
                                            Convert.ToInt32(this.txtCodInsumo.Text.Trim()),
                                            Convert.ToInt32(this.cboIndicativo.SelectedValue.ToString()),
                                            Convert.ToInt32(this.cboFamilia.SelectedValue.ToString()),
                                            this.txtInsumo.Text.Trim(),
                                            this.cboMedida.Text.ToString().Trim(),
                                            1/*ENVIADO DE VARIABLE GLOBAL*/
                                            );
                    }
                }
                if (rpta.Equals("OK"))
                {
                    ListarDatos(1, "");
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

        private void FRM_INSUMOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
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
                        oN.ope_Material(1,
                                    Convert.ToInt32(row.Cells["COD_MATERIAL"].Value.ToString()),
                                    Convert.ToInt32(row.Cells["INDICATIVO"].Value.ToString()),
                                    Convert.ToInt32(row.Cells["COD_TFAMILIA"].Value.ToString()),
                                    row.Cells["MATERIAL"].Value.ToString().ToUpper(),
                                    row.Cells["MEDIDA"].Value.ToString().ToUpper(),
                                    1/*ENVIADO DE VARIABLE GLOBAL*/
                                    );
                        progressBar.Value = progressBar.Value + 1;
                    }
                    ListarDatos(1, "");
                    cargar_Medida();
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

        private void txtCodInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void dgbDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            ListarDatos(2,this.txtBusqueda.Text.Trim());
        }
    }
}
