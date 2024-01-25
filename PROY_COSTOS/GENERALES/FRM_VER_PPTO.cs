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
using System.Configuration;

namespace PROY_COSTOS.GENERALES
{
    public partial class FRM_VER_PPTO : Form
    {
        DataView oDv = new DataView();
        Metodos met = new Metodos();
        N_VERSION oN = new N_VERSION();
        N_MAESTROS oMaN = new N_MAESTROS();
        FRM_PRINCIPAL frm = new FRM_PRINCIPAL();
        string version_activa;
        private static FRM_VER_PPTO _Instancia;
        public static FRM_VER_PPTO GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_VER_PPTO();
            }
            return _Instancia;
        }
        public FRM_VER_PPTO()
        {
            InitializeComponent();
            ver_campaña();
            ListarDatos();
            ver_indicador();
            LlenarCajas();
          //  this.txtDescripcion.Text = string.Empty;
          //  this.dgDatos.Columns["cod_vers"].Visible = false;
            this.dgDatos.Columns["cod_camp"].Visible = false;
            this.dgDatos.Columns["cod_ind"].Visible = false;
            this.dgDatos.Columns["descr"].Visible = false;
            this.dgDatos.Columns["vers_des"].Visible = false;
            this.dgDatos.Columns["ESTADO"].Visible = false;
            pnlControles.Enabled = false;

            
        }
        private void ListarDatos()
        {
            oDv = new DataView(oN.lst_VersionPPTO());
            dgDatos.DataSource = oDv;
        }
        private void ver_indicador()
        {
            cboIndicador.DataSource = oMaN.lst_Indicador();
            cboIndicador.DisplayMember = "indicador";
            cboIndicador.ValueMember = "cod_indicador";
        }
        private void ver_campaña()
        {
            cboCampaña.DataSource = oMaN.lstCampania(2,"");
            cboCampaña.DisplayMember = "CAMPAÑA";
            cboCampaña.ValueMember = "COD_CAMP";
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string rpta = "";
            //    rpta = oN.crear_Version(1, Convert.ToInt32(this.cboIndicador.SelectedValue.ToString()),this.txtDescripcion.Text.Trim().ToUpper(), 1); 
            //    ListarDatos();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        private void FRM_VER_PPTO_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void tsbGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (ConfigurationManager.AppSettings["_Action_Ver"] == "N")
                {
                    DialogResult dialogResult = MessageBox.Show("Registrar versión a la campaña " + lblCampañaPPTO.Text + "?", ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string rpta = "";
                        rpta = oN.crear_Version(1,
                                                Convert.ToInt32(this.cboIndicador.SelectedValue.ToString()),
                                                this.txtDescripcion.Text.Trim().ToUpper(),
                                                ConfigurationManager.AppSettings["_Usuario"].ToString(),0,
                                                ConfigurationManager.AppSettings["_Action_Ver"].ToString(),0);
                    }
                    ListarDatos();
                    pnlControles.Enabled = false;
                    tsbGrabar.Enabled = false;
                    pnlControles.Enabled = false;
                    tsbNuevo.Enabled = true;
                    salir();
                }
                else if (ConfigurationManager.AppSettings["_Action_Ver"] == "U")
                {
                    var modulo = cboIndicador.SelectedValue.ToString();
                    foreach (DataGridViewRow rows in dgDatos.Rows)
                    {
                        if (rows.Cells["ESTADO"].Value.ToString() == "1" & rows.Cells["cod_ind"].Value.ToString() == modulo )
                            version_activa = rows.Cells["cod_vers"].Value.ToString();
                    }
                    if (version_activa == lblcodigo.Text & chkEstado.Checked == false)
                    {
                        MessageBox.Show("Debe haber al menos 1 versión activa en la campaña " + lblCampañaPPTO.Text, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                       // var codigo = dgbDatos.CurrentRow.Cells["cod_vers"].Value.ToString();
                        int check = chkEstado.Checked ? 1 : 0;
                        DialogResult dialogResult = MessageBox.Show("Actualizar versión "+ lblCampañaPPTO.Text + " - " + txtVersion.Text + "?", ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string rpta = "";
                            rpta = oN.crear_Version(1,
                                                    Convert.ToInt32(this.cboIndicador.SelectedValue.ToString()),
                                                    this.txtDescripcion.Text.Trim().ToUpper(),
                                                    ConfigurationManager.AppSettings["_Usuario"].ToString(),
                                                    check,
                                                    ConfigurationManager.AppSettings["_Action_Ver"].ToString(),
                                                    Convert.ToInt32(this.lblcodigo.Text));
                        }
                        ListarDatos();
                        pnlControles.Enabled = false;
                        tsbGrabar.Enabled = false;
                        pnlControles.Enabled = false;
                        tsbNuevo.Enabled = true;
                        salir();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigurationManager.AppSettings["_Action_Ver"] = "N";
                limpiar();
                panel3.Enabled = false;
                pnlControles.Enabled = true;
                cboIndicador.Enabled = true;

                tsbSalir.Visible = true;
                tsbNuevo.Visible = false;
                tsbGrabar.Enabled = true;
                tsbModificar.Enabled = false;
                if (dgDatos.Rows.Count == 0)
                {

                    lblCampañaPPTO.Text = frm.lblCampania.Text;
                    chkEstado.Checked = false;
                    lblEstado.Text = "INACTIVO";
                    txtVersion.Text = "1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            salir();
        }
        private void salir()
        {
            try
            {
                ConfigurationManager.AppSettings["_Action_Ver"] = "";
                limpiar();

                panel3.Enabled = true;
                pnlControles.Enabled = false;

                tsbSalir.Visible = false;
                tsbNuevo.Visible = true;
                tsbGrabar.Enabled = false;
                tsbModificar.Enabled = true;
                LlenarCajas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void limpiar()
        {
            try
            {
                txtDescripcion.Text = string.Empty;
                //txtFechaFin.Text = string.Empty;
                //txtFechaInicio.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkEstado.Checked == true)
                {
                    lblEstado.Text = "ACTIVO";
                    lblEstado.BackColor = Color.GreenYellow;
                }
                else
                {
                    lblEstado.Text = "INACTIVO";
                    lblEstado.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LlenarCajas()
        {
            try
            {
                if (dgDatos.Rows.Count > 0)
                {
                    txtDescripcion.Text = dgDatos.CurrentRow.Cells["descr"].Value.ToString();
                    cboIndicador.Text = dgDatos.CurrentRow.Cells["indicador"].Value.ToString();
                    var estado_camp = dgDatos.CurrentRow.Cells["ESTADO"].Value.ToString();
                    lblcodigo.Text = dgDatos.CurrentRow.Cells["cod_vers"].Value.ToString();
                    if (estado_camp == "1")
                    {
                        chkEstado.Checked = true;
                        lblEstado.Text = "ACTIVO";
                        lblEstado.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        chkEstado.Checked = false;
                        lblEstado.Text = "INACTIVO";
                        lblEstado.BackColor = Color.Red;
                    }
                    lblCampañaPPTO.Text = dgDatos.CurrentRow.Cells["campania"].Value.ToString();
                    txtVersion.Text = dgDatos.CurrentRow.Cells["vers_des"].Value.ToString();
                }
                else
                {
                    
                    MessageBox.Show("No existen versiones en la campaña " + frm.lblCampania.Text, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblCampañaPPTO.Text = "-";
                    lblEstado.Text = "-";
                    txtDescripcion.Text = " - ";
                    txtVersion.Text = " - "; 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tsbModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigurationManager.AppSettings["_Action_Ver"] = "U";
                tsbGrabar.Enabled = true;
                chkEstado.Enabled = true;
                pnlControles.Enabled = true;
                cboIndicador.Enabled = true;
                txtDescripcion.Enabled = true;
                chkEstado.Enabled = true;
                cboIndicador.Enabled = false;
                txtVersion.Enabled = false;

                tsbNuevo.Visible = false;
                tsbSalir.Visible = true;
                //       tsbEliminar.Enabled = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                var gridView = (DataGridView)sender;
                foreach (DataGridViewRow row in gridView.Rows)
                {
                    if (row.Cells["ESTADO"].Value.ToString() == "1")
                    {
                        row.DefaultCellStyle.BackColor = Color.GreenYellow;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LlenarCajas();
        }
    }
}
