using NEGOCIO;
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
using System.Configuration;
using Microsoft.Office.Interop.Excel;

namespace PROY_COSTOS.GENERALES
{
    public partial class MTTO_CAMPAÑA : Form
    {
        DataView oDv = new DataView();
        Metodos met = new Metodos();
        N_MAESTROS oN = new N_MAESTROS();
        private static MTTO_CAMPAÑA _Instancia;
        string camp_activa;
        public static MTTO_CAMPAÑA GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new MTTO_CAMPAÑA();
            }
            return _Instancia;
        }
        public MTTO_CAMPAÑA()
        {
            InitializeComponent();
            ListarDatos();
            LlenarCajas();
            pnlControles.Enabled = false;

            //this.dgCampaña.Columns["COD_CAMP"].Visible = false;
            //   btnGuardar.Enabled = false;
        }
        private void ListarDatos()
        {
            oDv = new DataView(oN.lstCampania(2,""));
            dgCampaña.DataSource = oDv;

        }

        private void MTTO_CAMPAÑA_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigurationManager.AppSettings["_Action_Camp"] = "N";
                limpiar();
                pnlGridCamp.Enabled = false;
                pnlControles.Enabled = true;

                tsbSalir.Visible = true;
                tsbNuevo.Visible = false;
                tsbGrabar.Enabled = true;
                //      tsbEliminar.Enabled = false;
                tsbModificar.Enabled = false;
                txtCampania.Enabled = true;

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
                txtCampania.Text = string.Empty;
                txtFechaFin.Text = string.Empty;
                txtFechaInicio.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MTTO_CAMPAÑA_Load(object sender, EventArgs e)
        {
            //pnlGridCamp.Location = new Point(13, 35);


            //pnlGridCamp.Width = 774;
            //pnlGridCamp.Height = 402;
        }

        private void txtCampania_TextChanged(object sender, EventArgs e)
        {
            try
            {
                colorNormal();
                if (txtCampania.Text.Length > 0)
                {
                    txtFechaInicio.Text = "01" + "/" + "03" + "/" + txtCampania.Text;
                    int anio_prox = Convert.ToInt32(txtCampania.Text) + 1;
                    DateTime date = Convert.ToDateTime("01" + "/" + "03" + "/" + anio_prox);
                    DateTime oPrimerDiaDelMes = new DateTime(date.Year, date.Month, 1);
                    DateTime oUltimoDiaDelMes = oPrimerDiaDelMes.AddDays(-1);
                    var fecha_fin = oUltimoDiaDelMes.ToString("dd/MM/yyyy");
                    txtFechaFin.Text = fecha_fin;
                }
                else
                {
                    txtFechaInicio.Text = string.Empty;
                    txtFechaFin.Text = string.Empty;
                }


            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void salir() {
            try
            {
                ConfigurationManager.AppSettings["_Action_Camp"] = "";
                limpiar();

                pnlGridCamp.Enabled = true;
                pnlControles.Enabled = false;

                tsbSalir.Visible = false;
                tsbNuevo.Visible = true;
                tsbGrabar.Enabled = false;
                tsbModificar.Enabled = true;
                //      tsbEliminar.Enabled = true;

                LlenarCajas();
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
        private void LlenarCajas()
        {
            try
            {
                txtCampania.Text = dgCampaña.CurrentRow.Cells["CAMPAÑA"].Value.ToString();
                var estado_camp = dgCampaña.CurrentRow.Cells["ESTADO"].Value.ToString();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgCampaña_SelectionChanged(object sender, EventArgs e)
        {
            LlenarCajas();
        }

        private void tsbGrabar_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (ConfigurationManager.AppSettings["_Action_Camp"] == "N")
                {
                    string rpta = "";
                    if (validarDatos())
                    {
                        DialogResult dialogResult = MessageBox.Show("Registrar campaña " + txtCampania.Text + " como activa?", ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            rpta = oN.mtto_campania
                                    (
                                        this.txtCampania.Text.Trim().ToUpper(),
                                        this.txtFechaInicio.Text.Trim(),
                                        this.txtFechaFin.Text.Trim(),
                                        ConfigurationManager.AppSettings["_Usuario"].ToString(),
                                        1,
                                        ConfigurationManager.AppSettings["_Action_Camp"]
                                    );

                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            rpta = oN.mtto_campania
                                    (
                                        this.txtCampania.Text.Trim().ToUpper(),
                                        this.txtFechaInicio.Text.Trim(),
                                        this.txtFechaFin.Text.Trim(),
                                        ConfigurationManager.AppSettings["_Usuario"].ToString(),
                                        0,
                                        ConfigurationManager.AppSettings["_Action_Camp"]
                                    );
                        }
                        // limpiar();
                        ListarDatos();
                        pnlControles.Enabled = false;
                        tsbGrabar.Enabled = false;
                        pnlControles.Enabled = false;
                        tsbNuevo.Enabled = true;
                        salir();
                    }
                }
                else if (ConfigurationManager.AppSettings["_Action_Camp"] == "U")
                {
                    
                    foreach (DataGridViewRow rows in dgCampaña.Rows)
                    {
                        if (rows.Cells["ESTADO"].Value.ToString() == "1")
                            camp_activa = rows.Cells["CAMPAÑA"].Value.ToString();
                    }
                    if (camp_activa == txtCampania.Text & chkEstado.Checked == false)
                    {
                        MessageBox.Show("Debe haber al menos 1 campaña activa, active otra campaña para desactivar la campaña "+ txtCampania.Text, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        string rpta = "";
                        DialogResult dialogResult = MessageBox.Show("Actualizar campaña " + txtCampania.Text + " como activa?", ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            rpta = oN.mtto_campania
                                    (
                                        this.txtCampania.Text.Trim().ToUpper(),
                                        this.txtFechaInicio.Text.Trim(),
                                        this.txtFechaFin.Text.Trim(),
                                        ConfigurationManager.AppSettings["_Usuario"].ToString(),
                                        1, ConfigurationManager.AppSettings["_Action_Camp"]
                                    );
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
        private void colorNormal()
        {
            this.txtCampania.BackColor = System.Drawing.Color.White;
            //this.txtFechaInicio.BackColor = System.Drawing.Color.White;
            //this.txtFechaFin.BackColor = System.Drawing.Color.White;
        }
        public bool validarDatos()
        {
        
            bool validar = false;
            oDv = new DataView(oN.lstCampania(3,txtCampania.Text));

            if (oDv.Table.Rows.Count > 0)
            {
                MessageBox.Show("Ya existe la campaña " + txtCampania.Text, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCampania.Clear();
                txtCampania.Focus();
                return validar = false;
            }
            //dgCampaña.DataSource = oDv;
            if (txtCampania.Text == string.Empty)
            {
                colorNormal();
                MessageBox.Show("Ingresar Campaña", ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCampania.BackColor = System.Drawing.Color.LightPink;
                txtCampania.Focus();
                return validar = false;
            }
            else
            {
                colorNormal();
                return validar = true;
            }
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigurationManager.AppSettings["_Action_Camp"] = "U";
                tsbGrabar.Enabled = true;
                chkEstado.Enabled = true;
                pnlControles.Enabled = true;
                txtCampania.Enabled = false;
                txtFechaInicio.Enabled = false;
                tsbNuevo.Visible = false;
                tsbSalir.Visible = true;
         //       tsbEliminar.Enabled = false;


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

        private void dgCampaña_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private void tsbExportar_Click(object sender, EventArgs e)
        {
            try
            {
                var timer = System.Diagnostics.Stopwatch.StartNew();

                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);

                object[,] datos = new object[dgCampaña.Rows.Count + 1, dgCampaña.Columns.Count]; // +1 por la cabecera
                for (int j = 0; j < dgCampaña.Columns.Count; j++) //cabeceras
                {
                    datos[0, j] = dgCampaña.Columns[j].Name;
                }


                for (int i = 0; i < dgCampaña.Rows.Count; i++)
                {
                    for (int j = 0; j < dgCampaña.Columns.Count; j++)
                    {
                        datos[i + 1, j] = dgCampaña.Rows[i].Cells[j].Value;
                    }
                    progressBar1.Value++;
                }

                excel.Range[excel.Cells[1, 1], excel.Cells[datos.GetLength(0), datos.GetLength(1)]].Value = datos;
                excel.Visible = true;
                Worksheet worksheet = (Worksheet)excel.ActiveSheet;
                worksheet.Activate();
                progressBar1.Value = 0;
                timer.Stop();
                var elapsed = timer.Elapsed;
                MessageBox.Show(elapsed.ToString("mm':'ss':'fff"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
