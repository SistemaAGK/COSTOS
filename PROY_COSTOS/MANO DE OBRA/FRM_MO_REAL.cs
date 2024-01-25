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

namespace PROY_COSTOS.MANO_DE_OBRA
{
    public partial class FRM_MO_REAL : Form
    {
        //      Un DataSet es un objeto que almacena n número de DataTables, estas tablas puedes estar conectadas dentro del dataset.
        private DataSet dtsTablas = new DataSet();
        private DataTable dtbrief;
        private static FRM_MO_REAL _Instancia;

        N_REAL_MO oN = new N_REAL_MO();

        public FRM_MO_REAL()
        {
            InitializeComponent();
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;

            this.cargar_temporada();
            this.cargar_periodos();
            this.cargar_sede();

            lblMensajesExportacion.Text = "";
            lblMensajesLog.Text = "";
            lblMensajesImportacion.Text = "";
        }
        private void cargar_temporada()
        {
            cboCampaña.DataSource = oN.lst_Temporada();
            cboCampaña.DisplayMember = "campania";
            cboCampaña.ValueMember = "cod_camp";

            cboCampañaExp.DataSource = oN.lst_Temporada();
            cboCampañaExp.DisplayMember = "campania";
            cboCampañaExp.ValueMember = "cod_camp";
        }
        private void cargar_periodos()
        {
            cboPeriodo.DataSource = oN.lst_Periodos(1);
            cboPeriodo.DisplayMember = "nom_mes";
            cboPeriodo.ValueMember = "cod_mes";

            cboPeriodoExp.DataSource = oN.lst_Periodos(1);
            cboPeriodoExp.DisplayMember = "nom_mes";
            cboPeriodoExp.ValueMember = "cod_mes";
        }
        private void cargar_sede()
        {
            cboSedesExp.DataSource = oN.lst_Sedes();
            cboSedesExp.DisplayMember = "sede";
            cboSedesExp.ValueMember = "cod_sede";

            cboSedesImp.DataSource = oN.lst_SedesImportar();
            cboSedesImp.DisplayMember = "sede";
            cboSedesImp.ValueMember = "cod_sede";
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
        private void resize()
        {

            ////this.grpPasos.Location = new Point(tabControlMO.Width - 318, tabControlMO.Height - 603);
            this.grpPasos.Location = new Point(tabControlMO.Width - 320, tabControlMO.Height - 625);


            this.tabControlMO.Width = this.Width - 50;
            this.tabControlMO.Height = this.Height - 60;

            this.dgvDatos.Width = this.tabControlMO.Width - 50;
            this.dgvDatos.Height = this.tabControlMO.Height - 190;

            this.dgvLogs.Width = this.tabControlMO.Width - 50;
            this.dgvLogs.Height = this.tabControlMO.Height - 190;

            this.dgvDataExportar.Width = this.tabControlMO.Width - 50;
            this.dgvDataExportar.Height = this.tabControlMO.Height - 190;

            this.lblMensajesImportacion.Location = new Point(28, this.tabControlMO.Height - 55);
            this.lblMensajesLog.Location = new Point(28, this.tabControlMO.Height - 55);
            this.lblMensajesExportacion.Location = new Point(28, this.tabControlMO.Height - 55);
        }

        private void FRM_MO_REAL_Load(object sender, EventArgs e)
        {
            ControlExtension.Draggable(this.grpPasos, true);

            resize();
        }

        private void FRM_MO_REAL_Resize(object sender, EventArgs e)
        {
            resize();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //          Configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.csv";

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
                //    IExcelDataReader reader = ExcelReaderFactory.CreateReader(fsSource);
                //IExcelDataReader reader;
                IExcelDataReader reader = ExcelReaderFactory.CreateCsvReader(fsSource, new ExcelReaderConfiguration()
                {

                    // Gets or sets the encoding to use when the input XLS lacks a CodePage
                    // record, or when the input CSV lacks a BOM and does not parse as UTF8. 
                    // Default: cp1252. (XLS BIFF2-5 and CSV only)
                    FallbackEncoding = Encoding.GetEncoding(1252),

                    // Gets or sets the password used to open password protected workbooks.
                    Password = "password",

                    // Gets or sets an array of CSV separator candidates. The reader 
                    // autodetects which best fits the input data. Default: , ; TAB | # 
                    // (CSV only)
                    AutodetectSeparators = new char[] { ',', ';', '\t', '|', '#' }
                });

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

        private void btnGuardarRealMO_Click(object sender, EventArgs e)
        {
            if (this.txtRuta.Text == "")
            {
                MessageBox.Show("Debe Seleccionar una Hoja CSV de Entrada", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.dgvDatos.DataSource = null;

            this.lblMensajesImportacion.Text = "Procesando Información...";
            this.Refresh();

            inicializaLabelsProceso();

            dgvDatos.DataSource = dtsTablas.Tables[cboHojas.SelectedIndex];
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            int nume_linea = 1;
            int nume_mes;
                       
            string rpta = "";
            
            nume_mes = ObtenerEjercicio(Convert.ToInt32(this.cboCampaña.SelectedValue), Convert.ToInt32(this.cboPeriodo.SelectedValue));

            //          Borramos el contenido de la tabla temporal SQL
            rpta = oN.opeTmpDeleteRealMO();

            //          Cargamos en excel en una tabla temporal SQL
            foreach (DataGridViewRow r in dgvDatos.Rows)
            {
                //    if ((Convert.ToString(r.Cells["tipo ecosto"].Value) != "") && (Convert.ToInt32(r.Cells["codi ecosto"].Value) != 0) && (Convert.ToInt32(r.Cells["labor"].Value) != 0) && (Convert.ToInt32(r.Cells["cantidad horas"].Value) != 0))
                //  {
                this.lblFE.Text = (nume_linea - 1).ToString();
                this.lblFE.Refresh();

                rpta = oN.opeTmpRealMO(nume_linea,
                                       nume_mes,
                                       Convert.ToInt32(this.cboPeriodo.SelectedValue),
                                       Convert.ToString(r.Cells["tipo ecosto"].Value),
                                       Convert.ToString(r.Cells["codi ecosto"].Value),
                                       Convert.ToString(r.Cells["descripcion ccosto"].Value),
                                       Convert.ToString(r.Cells["lote/ubicacion"].Value),
                                       Convert.ToString(r.Cells["labor"].Value),
                                       Convert.ToString(r.Cells["descripcion labor"].Value),
                                       Convert.ToDecimal(r.Cells["cantidad horas"].Value),
                                       Convert.ToDecimal(r.Cells["cantidad jornal"].Value),
                                       Convert.ToDecimal(r.Cells["costo jornal"].Value),
                                       Convert.ToDecimal(r.Cells["costo bono fijo"].Value),
                                       Convert.ToDecimal(r.Cells["costo horas extras"].Value),
                                       Convert.ToDecimal(r.Cells["costo bono variable"].Value),
                                       Convert.ToDecimal(r.Cells["costo destajo"].Value),
                                       Convert.ToDecimal(r.Cells["costo otros"].Value),
                                       Convert.ToDecimal(r.Cells["costo total"].Value)
                                       );
                nume_linea = nume_linea + 1;
                // }

            }

            this.lblPE.Text = "100.00";
            this.lblPE.Refresh();

            //          Ubicamos los errores y lo cargamos en el campo de observaciones
            rpta = oN.opeTmpUpdateRealMO(Convert.ToInt32(this.chkTarifa.Checked));

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
                        rpta = oN.opeUpdateRealMO(Convert.ToInt32(this.cboCampaña.SelectedValue), Convert.ToInt32(this.cboPeriodo.SelectedValue), Convert.ToInt32(this.cboSedesImp.SelectedValue));
                        this.lblPC.Text = "100.00";
                        this.lblFC.Text = dtbrief.Rows[0]["ok"].ToString();

                        MessageBox.Show("Actualización Concluída", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                        //                      Cargamos la tabla de log de errores para ser revisada y descargada 
                        dgvLogs.DataSource = oN.lst_Log();
                }
                else
                {
                    //                  Cargamos la tabla de log de errores para ser revisada y descargada 
                    dgvLogs.DataSource = oN.lst_Log();
                    dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    MessageBox.Show("Se presentaron Errores en el proceso de validación.\r\n" + " Revise el LOG de Carga y Reprocese", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                //             Cargamos la tabla de log de errores para ser revisada y descargada 
                dgvLogs.DataSource = oN.lst_Log();

        }

        private int ObtenerEjercicio(int campaña, int mes)
        {
            DataTable dtEjercicio;

            dtEjercicio = oN.busEjercicio(campaña, mes);

            if (dtEjercicio.Rows.Count > 0)
                return int.Parse(dtEjercicio.Rows[0]["ejercicio"].ToString());
            else
                return 1;
        }

        private void btnReprocesar_Click(object sender, EventArgs e)
        {
            string rpta = "";

            this.lblPV.Text = "";
            this.lblFV.Text = "";
            this.lblPC.Text = "";
            this.lblFC.Text = "";
            
            this.lblMensajesLog.Text = "Procesando Información...";

            dgvLogs.DataSource = null;

            //          Ubicamos los errores y lo cargamos en el campo de observaciones
            rpta = oN.opeTmpUpdateRealMO(Convert.ToInt32(this.chkTarifa.Checked));

            //          Obtenemos el Resumen de la carga (Cantidad de Errores, Cantidad de Ok)
            dtbrief = oN.lst_Brief();

           // this.lblMensajesImportacion.Text = "";
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
                        rpta = oN.opeUpdateRealMO(Convert.ToInt32(this.cboCampaña.SelectedValue), Convert.ToInt32(this.cboPeriodo.SelectedValue), Convert.ToInt32(this.cboSedesImp.SelectedValue));
                        this.lblPC.Text = "100.00";
                        this.lblFC.Text = dtbrief.Rows[0]["ok"].ToString();

                        MessageBox.Show("Actualización Concluída", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                        //                      Cargamos la tabla de log de errores para ser revisada y descargada 
                        dgvLogs.DataSource = oN.lst_Log();
                }
                else
                {
                    //                  Cargamos la tabla de log de errores para ser revisada y descargada 
                    dgvLogs.DataSource = oN.lst_Log();
                    dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    this.lblMensajesLog.Text = "";

                    MessageBox.Show("Se presentaron Errores en el proceso de validación.\r\n" + " Revise el LOG de Carga y Reprocese", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                //              Cargamos la tabla de log de errores para ser revisada y descargada 
                dgvLogs.DataSource = oN.lst_Log();
            this.lblMensajesLog.Text = "";
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

            foreach (DataGridViewColumn column in dgvLogs.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            foreach (DataGridViewRow row in dgvLogs.Rows)
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
                wb.Worksheets.Add(dt, "LogErroresReal");

                wb.Worksheet(1).Columns().AdjustToContents();

                wb.SaveAs(this.txtRutaLog.Text + "\\LOGREAL" + fecha + hora + ".xlsx");
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

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            this.lblMensajesExportacion.Text = "Cargando Información...";
            this.Refresh();

            dgvDataExportar.Refresh();
            dgvDataExportar.DataSource = oN.lst_RealMO(Convert.ToInt32(this.cboCampañaExp.SelectedValue),
                                                       Convert.ToInt32(this.cboSedesExp.SelectedValue),
                                                       Convert.ToInt32(this.cboPeriodoExp.SelectedValue));

            dgvDataExportar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.lblMensajesExportacion.Text = "";
            this.Refresh();
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
                dgvDataExportar.DataSource = oN.lst_RealMO(Convert.ToInt32(this.cboCampañaExp.SelectedValue),
                                                           Convert.ToInt32(this.cboSedesExp.SelectedValue),
                                                           Convert.ToInt32(this.cboPeriodoExp.SelectedValue));
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

                wb.SaveAs(this.txtRutaExcel.Text + "\\REAL_MO" + fecha + hora + ".xlsx");
            }

            this.lblMensajesExportacion.Text = "";
            this.Refresh();

            MessageBox.Show("Proceso de grabación del Excel concluído", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grpPasos_Enter(object sender, EventArgs e)
        {

        }
    }
}
