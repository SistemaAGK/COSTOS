using NEGOCIO;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Windows.Forms;
using System.Configuration;

namespace PROY_COSTOS.MANO_DE_OBRA
{
    public partial class FRM_MO_PPTO : Form
    {
        //      Un DataSet es un objeto que almacena n número de DataTables, estas tablas puedes estar conectadas dentro del dataset.
        private DataSet dtsTablas = new DataSet();
        private DataTable dtbrief;
        private static FRM_MO_PPTO _Instancia;

        N_PPTO_MO oN = new N_PPTO_MO();

        public static FRM_MO_PPTO GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_MO_PPTO();
            }
            return _Instancia;
        }

        public FRM_MO_PPTO()
        {
            InitializeComponent();

            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;

            this.cargar_sede();
            this.cargar_temporada();
            this.cargar_versiones();

            lblMensajesExportacion.Text = "";
            lblMensajesLog.Text = "";
            lblMensajesImportacion.Text = "";

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //          Configuracion de ventana para seleccionar un archivo
                OpenFileDialog oOpenFileDialog = new OpenFileDialog();
                oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

                if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    cboHojas.Items.Clear();
                    dgvDatos.DataSource = null;

                    txtRuta.Text = oOpenFileDialog.FileName;

                    //              FileStream nos permite leer, escribir, abrir y cerrar archivos en un sistema de archivos, como matrices de bytes
                    FileStream fsSource = new FileStream(oOpenFileDialog.FileName, FileMode.Open, FileAccess.Read);


                    //ExcelReaderFactory.CreateBinaryReader = formato XLS
                    //ExcelReaderFactory.CreateOpenXmlReader = formato XLSX
                    //ExcelReaderFactory.CreateReader = XLS o XLSX
                    IExcelDataReader reader = ExcelReaderFactory.CreateReader(fsSource);

                    //              Convierte todas las hojas a un DataSet
                    dtsTablas = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    //              Obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                    foreach (DataTable tabla in dtsTablas.Tables)
                    {
                        cboHojas.Items.Add(tabla.TableName);
                    }
                    cboHojas.SelectedIndex = 0;

                    reader.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarPptoMO_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtRuta.Text == "")
                {
                    MessageBox.Show("Debe Seleccionar una Hoja Excel de Entrada", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.lblMensajesImportacion.Text = "Procesando Información...";
                this.Refresh();

                inicializaLabelsProceso();

                dgvDatos.DataSource = dtsTablas.Tables[cboHojas.SelectedIndex];

                int nume_linea = 2;
                string rpta = "";

                //          Borramos el contenido de la tabla temporal SQL
                rpta = oN.opeTmpDeletePptoMO();

                //          Cargamos en excel en una tabla temporal SQL
                foreach (DataGridViewRow r in dgvDatos.Rows)
                {
                    if ((Convert.ToString(r.Cells["ceco"].Value) != "") && (Convert.ToInt32(r.Cells["cod_labor"].Value) != 0) && (Convert.ToInt32(r.Cells["año"].Value) != 0) && (Convert.ToInt32(r.Cells["periodo"].Value) != 0))
                    {
                        this.lblFE.Text = (nume_linea - 1).ToString();
                        this.lblFE.Refresh();

                        rpta = oN.opeTmpPptoMO(nume_linea,
                                               Convert.ToString(r.Cells["ceco"].Value),
                                               Convert.ToInt32(r.Cells["cod_labor"].Value),
                                               Convert.ToInt32(r.Cells["año"].Value),
                                               Convert.ToInt32(r.Cells["periodo"].Value),
                                               Convert.ToDecimal(r.Cells["jornales"].Value)
                                               );
                        nume_linea = nume_linea + 1;
                    }

                }

                this.lblPE.Text = "100.00";
                this.lblPE.Refresh();

                //          Ubicamos los errores y lo cargamos en el campo de observaciones
                rpta = oN.opeTmpUpdatePptoMO();

                //          Obtenemos el Resumen de la carga (Cantidad de Errores, Cantidad de Ok)
                dtbrief = oN.lst_Brief();

                this.lblMensajesImportacion.Text = "";
                this.Refresh();

                if (dtbrief.Rows.Count > 0)
                {
                    this.lblFV.Text = dtbrief.Rows[0]["ok"].ToString();
                    this.lblFV.Refresh();

                    this.lblPV.Text = dtbrief.Rows[0]["por_ok"].ToString();
                    this.lblPV.Refresh();

                    if (this.lblPV.Text == "100.00")
                    {
                        if (MessageBox.Show("Se han validado correctamente " + this.lblFV.Text.Trim() + " Filas.\r\n" + "¿Esta seguro de proceder a la Actualización?", "Indicadores de Costos", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            //                      Calculamos y grabamos en la tabla definitiva de Presupuestos de Mano de Obra
                            rpta = oN.opeUpdatePptoMO(Convert.ToInt32(this.cboCampaña.SelectedValue), Convert.ToInt32(this.cboVersiones.SelectedValue), Convert.ToInt32(this.chkNuevaVersion.Checked));
                            this.lblPC.Text = "100.00";
                            this.lblFC.Text = dtbrief.Rows[0]["ok"].ToString();

                            MessageBox.Show("Actualización Concluída", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            this.cargar_versiones();
                        }
                        else
                            //                      Cargamos la tabla de log de errores para ser revisada y descargada 
                            dgvLog.DataSource = oN.lst_Log();
                    }
                    else
                    {
                        //                  Cargamos la tabla de log de errores para ser revisada y descargada 
                        dgvLog.DataSource = oN.lst_Log();
                        dgvLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                        MessageBox.Show("Se presentaron Errores en el proceso de validación.\r\n" + " Revise el LOG de Carga y Reprocese", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    //             Cargamos la tabla de log de errores para ser revisada y descargada 
                    dgvLog.DataSource = oN.lst_Log();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ConfigurationManager.AppSettings["_Titulo_Popups"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void inicializaLabelsProceso()
        {
            this.lblPE.Text = "";
            this.lblFE.Text = "";
            this.lblPV.Text = "";
            this.lblFV.Text = "";
            this.lblPC.Text = "";
            this.lblFC.Text = "";
            this.lblPE.Refresh();
            this.lblFE.Refresh();
            this.lblPV.Refresh();
            this.lblFV.Refresh();
            this.lblPC.Refresh();
            this.lblFC.Refresh();
        }
        private void cargar_sede()
        {
            cboSedesExp.DataSource = oN.lst_Sedes();
            cboSedesExp.DisplayMember = "sede";
            cboSedesExp.ValueMember = "cod_sede";
        }
        private void cargar_temporada()
        {
            cboCampaña.DataSource = oN.lst_Año();
            cboCampaña.DisplayMember = "campania";
            cboCampaña.ValueMember = "cod_camp";

            cboCampañaExp.DataSource = oN.lst_Año();
            cboCampañaExp.DisplayMember = "campania";
            cboCampañaExp.ValueMember = "cod_camp";
        }
        private void cargar_versiones()
        {
            cboVersiones.DataSource = oN.lst_VersionesPptoMO(Convert.ToInt32(this.cboCampaña.SelectedValue));
            cboVersiones.DisplayMember = "nom_version";
            cboVersiones.ValueMember = "cod_ver";

            cboVersionesExp.DataSource = oN.lst_VersionesPptoMO(Convert.ToInt32(this.cboCampañaExp.SelectedValue));
            cboVersionesExp.DisplayMember = "nom_version";
            cboVersionesExp.ValueMember = "cod_ver";
        }
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (this.txtRutaLog.Text == "")
            {
                MessageBox.Show("Debe Seleccionar una Carpeta donde se almacenara el Archivo Log", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.lblMensajesLog.Text = "Generando Información...";
            this.Refresh();

            DataTable dt = new DataTable();

            foreach (DataGridViewColumn column in dgvLog.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            foreach (DataGridViewRow row in dgvLog.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value; //.ToString();
                    }
                }
            }

            string hora = DateTime.Now.ToString("hhmmss");
            string fecha = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "LogErrores");

                wb.Worksheet(1).Columns().AdjustToContents();

                wb.SaveAs(this.txtRutaLog.Text + "\\LOG" + fecha + hora + ".xlsx");
            }

            this.lblMensajesLog.Text = "";
            this.Refresh();

            MessageBox.Show("Proceso de grabación del Log concluído", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnSeleccionFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtRutaLog.Text = fbd.SelectedPath;
            }
        }

        private void btnSeleccionarFolderExp_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtRutaExcel.Text = fbd.SelectedPath;
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (this.txtRutaExcel.Text == "")
            {
                MessageBox.Show("Debe Seleccionar una Carpeta donde se almacenara el Archivo Excel", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.lblMensajesExportacion.Text = "Generando Información...";
            this.Refresh();

            if (dgvDataExportar.DataSource == null)
            {
                dgvDataExportar.Refresh();
                dgvDataExportar.DataSource = oN.lst_PptoMO(Convert.ToInt32(this.cboCampañaExp.SelectedValue),
                                                           Convert.ToInt32(this.cboSedesExp.SelectedValue),
                                                           Convert.ToInt32(this.cboVersionesExp.SelectedValue));
            }

            DataTable dt = new DataTable();

            foreach (DataGridViewColumn column in dgvDataExportar.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            foreach (DataGridViewRow row in dgvDataExportar.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value; //.ToString();
                    }
                }
            }

            string hora = DateTime.Now.ToString("hhmmss");
            string fecha = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "DATA");

                wb.Worksheet(1).Columns().AdjustToContents();

                wb.SaveAs(this.txtRutaExcel.Text + "\\PPTO_MO" + fecha + hora + ".xlsx");
            }

            this.lblMensajesExportacion.Text = "";
            this.Refresh();

            MessageBox.Show("Proceso de grabación del Excel concluído", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            this.lblMensajesExportacion.Text = "Cargando Información...";
            this.Refresh();

            dgvDataExportar.Refresh();
            dgvDataExportar.DataSource = oN.lst_PptoMO(Convert.ToInt32(this.cboCampañaExp.SelectedValue),
                                                       Convert.ToInt32(this.cboSedesExp.SelectedValue),
                                                       Convert.ToInt32(this.cboVersionesExp.SelectedValue));
      
            dgvDataExportar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.lblMensajesExportacion.Text = "";
            this.Refresh();
        }

        private void cboVersionesExp_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDataExportar.DataSource = null;
            dgvDataExportar.Refresh();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void chkNuevaVersion_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkNuevaVersion.Checked == true)
                this.cboVersiones.Enabled = false;
            else
                this.cboVersiones.Enabled = true;
        }

        private void tabControlMO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControlMO.SelectedTab == tabImportar)
            {
                this.grpPasos.Visible = true;
            }
            if (this.tabControlMO.SelectedTab == tabLog)
            {
                this.grpPasos.Visible = true;
            }
            if (this.tabControlMO.SelectedTab == tabExportar)
            {
                this.grpPasos.Visible = false;
            }
        }

        private void cboSedesExp_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgvDataExportar.DataSource = null;
        }

        private void btnReprocesar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            
            dgvLog.DataSource = null;

            this.lblPV.Text = "";
            this.lblFV.Text = "";
            this.lblPC.Text = "";
            this.lblFC.Text = "";
            this.lblMensajesLog.Text = "Procesando Información...";

            //          Ubicamos los errores y lo cargamos en el campo de observaciones
            rpta = oN.opeTmpUpdatePptoMO();

//          Obtenemos el Resumen de la carga (Cantidad de Errores, Cantidad de Ok)
            dtbrief = oN.lst_Brief();

            this.Refresh();

            if (dtbrief.Rows.Count > 0)
            {
                this.lblFV.Text = dtbrief.Rows[0]["ok"].ToString();
                this.lblFV.Refresh();

                this.lblPV.Text = dtbrief.Rows[0]["por_ok"].ToString();
                this.lblPV.Refresh();

                if (this.lblPV.Text == "100.00")
                {
                    if (MessageBox.Show("Se han validado correctamente " + this.lblFV.Text.Trim() + " Filas.\r\n" + "¿Esta seguro de proceder a la Actualización?", "Indicadores de Costos", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //                      Calculamos y grabamos en la tabla definitiva de Presupuestos de Mano de Obra
                        rpta = oN.opeUpdatePptoMO(Convert.ToInt32(this.cboCampaña.SelectedValue), Convert.ToInt32(this.cboVersiones.SelectedValue), Convert.ToInt32(this.chkNuevaVersion.Checked));
                        this.lblPC.Text = "100.00";
                        this.lblFC.Text = dtbrief.Rows[0]["ok"].ToString();
                        this.lblMensajesLog.Text = "";
                        MessageBox.Show("Actualización Concluída", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        this.cargar_versiones();
                    }
                    else
                        //                      Cargamos la tabla de log de errores para ser revisada y descargada 
                        dgvLog.DataSource = oN.lst_Log();
                }
                else
                {
//                  Cargamos la tabla de log de errores para ser revisada y descargada 
                    dgvLog.DataSource = oN.lst_Log();
                    dgvLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    this.lblMensajesLog.Text = "";
                    MessageBox.Show("Se presentaron Errores en el proceso de validación.\r\n" + " Revise el LOG de Carga y Reprocese", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
//              Cargamos la tabla de log de errores para ser revisada y descargada 
                dgvLog.DataSource = oN.lst_Log();
        }

        private void FRM_MO_PPTO_Load(object sender, EventArgs e)
        {
            ControlExtension.Draggable(this.grpPasos, true);
            
            resize();
        }
        private void FRM_MO_PPTO_Resize(object sender, EventArgs e)
        {
            resize();
        }
        private void resize()
        {

            ////this.grpPasos.Location = new Point(tabControlMO.Width - 318, tabControlMO.Height - 603);
            this.grpPasos.Location = new Point(tabControlMO.Width - 380, tabControlMO.Height - 580);

            this.tabControlMO.Width = this.Width - 50;
            this.tabControlMO.Height = this.Height - 60;

            this.dgvDatos.Width = this.tabControlMO.Width - 50;
            this.dgvDatos.Height = this.tabControlMO.Height - 190;

            this.dgvLog.Width = this.tabControlMO.Width - 50;
            this.dgvLog.Height = this.tabControlMO.Height - 190;

            this.dgvDataExportar.Width = this.tabControlMO.Width - 50;
            this.dgvDataExportar.Height = this.tabControlMO.Height - 190;

            this.lblMensajesImportacion.Location = new Point(28, this.tabControlMO.Height - 55);
            this.lblMensajesLog.Location = new Point(28, this.tabControlMO.Height - 55);
            this.lblMensajesExportacion.Location = new Point(28, this.tabControlMO.Height - 55);
        }

    }
}
