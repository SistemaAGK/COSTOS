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

namespace PROY_COSTOS.EMPAQUE
{
    public partial class FRM_ME_CONSUMO_TEORICO : Form
    {
        //Un DataSet es un objeto que almacena n número de DataTables, estas tablas puedes estar conectadas dentro del dataset.
        private DataSet dtsTablas = new DataSet();
        private DataTable dtbrief;
        private static FRM_ME_CONSUMO_TEORICO _Instancia;
        N_CONSUMO_TEORICO_ME oN = new N_CONSUMO_TEORICO_ME();

        public static FRM_ME_CONSUMO_TEORICO GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_ME_CONSUMO_TEORICO();
            }
            return _Instancia;
        }


        public FRM_ME_CONSUMO_TEORICO()
        {
            InitializeComponent();

            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;
            this.cargar_temporada();
            this.cargar_sede();
            this.cargar_cultivo();
            this.cargar_años();
            this.cargar_meses();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //configuracion de ventana para seleccionar un archivo
            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.Filter = "Excel Worbook|*.xlsx";

            if (oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                cboHojas.Items.Clear();
                dgvDatos.DataSource = null;

                txtRuta.Text = oOpenFileDialog.FileName;    

//FileStream nos permite leer, escribir, abrir y cerrar archivos en un sistema de archivos, como matrices de bytes
                FileStream fsSource = new FileStream(oOpenFileDialog.FileName, FileMode.Open, FileAccess.Read);


                //ExcelReaderFactory.CreateBinaryReader = formato XLS
                //ExcelReaderFactory.CreateOpenXmlReader = formato XLSX
                //ExcelReaderFactory.CreateReader = XLS o XLSX
                IExcelDataReader reader = ExcelReaderFactory.CreateReader(fsSource);

                //convierte todas las hojas a un DataSet
                dtsTablas = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                //obtenemos las tablas y añadimos sus nombres en el desplegable de hojas
                foreach (DataTable tabla in dtsTablas.Tables)
                {
                    cboHojas.Items.Add(tabla.TableName);
                }
                cboHojas.SelectedIndex = 0;

                reader.Close();

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarPptoMO_Click(object sender, EventArgs e)
        {


            if (this.txtRuta.Text == "")
            {
                MessageBox.Show("Debe Seleccionar una Hoja Excel de Entrada", "Material Empaque", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.lblMensajesImportacion.Text = "Procesando Información...";
            this.Refresh();

            inicializaLabelsProceso();
           dgvDatos.DataSource = null;
           dgvDatos.DataSource = dtsTablas.Tables[cboHojas.SelectedIndex];

            int nume_linea = 2;
            string rpta = "";

            rpta = oN.opeTmpDeleteTeoricoME();

            foreach (DataGridViewRow r in dgvDatos.Rows)
            {
                if ((Convert.ToString(r.Cells["CODIGO"].Value) != ""))     
                 {
                    this.lblFE.Text = (nume_linea - 1).ToString();
                    this.lblFE.Refresh();

                rpta = oN.opeTmpTeoricoME(nume_linea,
                                        Convert.ToInt32(this.cboCampaña.SelectedValue),
                                       Convert.ToInt32(r.Cells["SEDE"].Value),
                                       Convert.ToInt32(r.Cells["CULTIVO"].Value),
                                          Convert.ToInt32(r.Cells["AÑO"].Value),
                                          Convert.ToInt32(r.Cells["MES"].Value),
                                          Convert.ToInt32(r.Cells["CODIGO"].Value),
                                          Convert.ToDecimal(r.Cells["CANTIDAD"].Value),
                                       Convert.ToString(r.Cells["DESCRIPCION"].Value)
                                       
                                            );
                nume_linea = nume_linea + 1;
            }
            }
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.lblPE.Text = "100.00";
            this.lblPE.Refresh();
            //Ubicamos los errores y lo cargamos en el campo de observaciones
            rpta = oN.opeTmpUpdaTeoricoME(Convert.ToInt32(this.cboCampaña.SelectedValue));
                                    

            //Obtenemos el Resumen de la carga (Cantidad de Errores, Cantidad de Ok)
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
                    if (MessageBox.Show("Se han validado correctamente " + this.lblFV.Text.Trim() + " Filas.\r\n" + "¿Esta seguro de proceder a la Actualización?", "Teórico de Empaque", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //Calculamos y grabamos en la tabla definitiva de Teorico de Empaque
                        rpta = oN.opeUpdateTeoricoMe(Convert.ToInt32(this.cboCampaña.SelectedValue));


                        ////////rpta = oN.opeUpdateTeoricoMe(Convert.ToInt32(this.cboSedes.SelectedValue),
                        ////////               Convert.ToInt32(this.cboCultivo.SelectedValue),
                        ////////                Convert.ToInt32(this.cboAño.SelectedValue),
                        ////////               Convert.ToInt32(this.cboMes.SelectedIndex) + 1);
                        this.lblPC.Text = "100.00";
                        this.lblFC.Text = dtbrief.Rows[0]["ok"].ToString();

                        MessageBox.Show("Actualización Concluída", "Teórico de Empaque", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        ////this.cargar_versiones();
                    }
                    else
                        //Cargamos la tabla de log de errores para ser revisada y descargada 
                        dgvLogMETeorico.DataSource = oN.lst_Log();
                }
                else
                {
                    //Cargamos la tabla de log de errores para ser revisada y descargada 
                    dgvLogMETeorico.DataSource = oN.lst_Log();
                dgvLogMETeorico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                MessageBox.Show("Se presentarón Errores en el proceso de validación.\r\n" + " Revise el LOG de Carga y Reprocese", "Teórico Empaque", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                //             Cargamos la tabla de log de errores para ser revisada y descargada 
                dgvLogMETeorico.DataSource = oN.lst_Log();

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

        private void cargar_temporada()
        {
            cboCampaña.DataSource = oN.lst_Temporada();
            cboCampaña.DisplayMember = "campania";
            cboCampaña.ValueMember = "cod_camp";
        }

        private void cargar_sede()
        {
            //cboSedes.DataSource = oN.lst_Sede();
            //cboSedes.DisplayMember = "sede";
            //cboSedes.ValueMember = "cod_sede";

            cboSedesExp1.DataSource = oN.lst_Sedes();
            cboSedesExp1.DisplayMember = "sede";
            cboSedesExp1.ValueMember = "cod_sede";

        }
        private void cargar_cultivo()
        {
            //cboCultivo.DataSource = oN.lst_Cultivo();
            //cboCultivo.DisplayMember = "cultivo_nombre";
            //cboCultivo.ValueMember = "cod_cultivo";

            cboCultivoExp1.DataSource = oN.lst_Cultivos();
            cboCultivoExp1.DisplayMember = "cultivo_nombre";
            cboCultivoExp1.ValueMember = "cod_cultivo";
        }

        private void cargar_años()
        {
            //cboAño.DataSource = oN.lst_año();
            //cboAño.DisplayMember = "año";
            //cboAño.ValueMember = "cod_año";

            cboAñoExp.DataSource = oN.lst_año();
            cboAñoExp.DisplayMember = "año";
            cboAñoExp.ValueMember = "cod_año";

        }

        private void cargar_meses()
        {

            ////cboMes.Items.Add("Enero");
            ////cboMes.Items.Add("Febrero");
            ////cboMes.Items.Add("Marzo");
            ////cboMes.Items.Add("Abril");
            ////cboMes.Items.Add("Mayo");
            ////cboMes.Items.Add("Junio");
            ////cboMes.Items.Add("Julio");
            ////cboMes.Items.Add("Agosto");
            ////cboMes.Items.Add("Setiembre");
            ////cboMes.Items.Add("Octubre");
            ////cboMes.Items.Add("Noviembre");
            ////cboMes.Items.Add("Diciembre");
            ////cboMes.SelectedIndex = 0;

            cboMesExp.Items.Add("Enero");
            cboMesExp.Items.Add("Febrero");
            cboMesExp.Items.Add("Marzo");
            cboMesExp.Items.Add("Abril");
            cboMesExp.Items.Add("Mayo");
            cboMesExp.Items.Add("Junio");
            cboMesExp.Items.Add("Julio");
            cboMesExp.Items.Add("Agosto");
            cboMesExp.Items.Add("Setiembre");
            cboMesExp.Items.Add("Octubre");
            cboMesExp.Items.Add("Noviembre");
            cboMesExp.Items.Add("Diciembre");
            cboMesExp.SelectedIndex = 0;



        }

        private void FRM_ME_CONSUMO_TEORICO_Load(object sender, EventArgs e)
        {
            ControlExtension.Draggable(this.grpPasos, true);

            resize();
        }

        private void resize()
        {

            ////this.grpPasos.Location = new Point(tabControlME.Width +128, tabControlME.Height - 580);
            this.grpPasos.Location = new Point(tabControlME.Width + 80, tabControlME.Height - 575);





            this.tabControlME.Width = this.Width - 50;
            this.tabControlME.Height = this.Height - 60;

            this.dgvDatos.Width = this.tabControlME.Width - 50;
            this.dgvDatos.Height = this.tabControlME.Height - 190;

            this.dgvLogMETeorico.Width = this.tabControlME.Width - 50;
            this.dgvLogMETeorico.Height = this.tabControlME.Height - 190;

            this.dgvDataExportar.Width = this.tabControlME.Width - 50;
            this.dgvDataExportar.Height = this.tabControlME.Height - 190;

            this.lblMensajesImportacion.Location = new Point(28, this.tabControlME.Height - 55);
            this.lblMensajesLog.Location = new Point(28, this.tabControlME.Height - 55);
            this.lblMensajesExportacion.Location = new Point(28, this.tabControlME.Height - 55);
        }


        private void btnSeleccionFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtRutaLog.Text = fbd.SelectedPath;

            }
        }

        //private void btnExportar_Click(object sender, EventArgs e)
        //{
        //        if (this.txtRutaExcel.Text == "")
        //        {
        //        MessageBox.Show("Debe Seleccionar una Carpeta donde se almacenara el Archivo Excel", "Teótico de Empaque", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //       return;
        //        }

        //        this.lblMensajesExportacion.Text = "Generando Información...";
        //        this.Refresh();

        //    dgvDataExportar.DataSource = null;

        //    if (dgvDataExportar.DataSource == null)
        //    {
        //        dgvDataExportar.Refresh();
        //        dgvDataExportar.DataSource = oN.lst_TeoricoME(Convert.ToInt32(this.cboSedes.SelectedValue),
        //                               Convert.ToInt32(this.cboCultivo.SelectedValue),
        //                                Convert.ToInt32(this.cboAño.SelectedValue),
        //                               Convert.ToInt32(this.cboMes.SelectedIndex) + 1);
        //        dgvDataExportar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        //    }



        //    DataTable dt = new DataTable();

        //        foreach (DataGridViewColumn column in dgvDataExportar.Columns)
        //        {
        //            dt.Columns.Add(column.HeaderText, column.ValueType);
        //        }

        //        foreach (DataGridViewRow row in dgvDataExportar.Rows)
        //        {
        //            dt.Rows.Add();
        //            foreach (DataGridViewCell cell in row.Cells)
        //            {
        //                if (cell.Value != null)
        //                {
        //                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value; //.ToString();
        //                }
        //            }
        //        }

        //        string hora = DateTime.Now.ToString("hhmmss");
        //        string fecha = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();

        //        using (XLWorkbook wb = new XLWorkbook())
        //        {
        //            wb.Worksheets.Add(dt, "LogErrores");

        //            wb.Worksheet(1).Columns().AdjustToContents();

        //            wb.SaveAs(this.txtRutaExcel.Text + "\\TEORICO_ME" + fecha + hora + ".xlsx");
        //        }

        //        this.lblMensajesExportacion.Text = "";
        //        this.Refresh();

        //         MessageBox.Show("Proceso de grabación del Excel concluído", "Teórico de Empaque", MessageBoxButtons.OK, MessageBoxIcon.Information);


        //}

  

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
            dgvDataExportar.DataSource = oN.lst_TeoricoME(Convert.ToInt32(this.cboSedesExp1.SelectedValue),
                                                       Convert.ToInt32(this.cboCultivoExp1.SelectedValue),
                                                       Convert.ToInt32(this.cboAñoExp.SelectedValue),
                                                        Convert.ToInt32(this.cboMesExp.SelectedIndex) + 1
                                                        );
            dgvDataExportar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.lblMensajesExportacion.Text = "";
            this.Refresh();
        }
        
        private void tabControlME_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControlME.SelectedTab == tabImportar)
            {
                this.grpPasos.Visible = true;
            }
            if (this.tabControlME.SelectedTab == tabLog)
            {
                this.grpPasos.Visible = true;
            }
            if (this.tabControlME.SelectedTab == tabExportar)
            {
                this.grpPasos.Visible = false;
            }
        }

        private void btnReprocesar_Click(object sender, EventArgs e)
        {
            string rpta = "";

            this.lblPV.Text = "";
            this.lblFV.Text = "";
            this.lblPC.Text = "";
            this.lblFC.Text = "";

            this.lblMensajesImportacion.Text = "Procesando Información...";
            this.Refresh();


            //          Ubicamos los errores y lo cargamos en el campo de observaciones
            //////rpta = oN.opeTmpUpdaTeoricoME(Convert.ToInt32(this.cboAño.SelectedValue),
            //////                           Convert.ToInt32(this.cboMes.SelectedIndex) + 1);

            rpta = oN.opeTmpUpdaTeoricoME(Convert.ToInt32(this.cboCampaña.SelectedValue));


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
                    if (MessageBox.Show("Se han validado correctamente " + this.lblFV.Text.Trim() + " Filas.\r\n" + "¿Esta seguro de proceder a la Actualización?", "Teórico de Empaque", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //Calculamos y grabamos en la tabla definitiva de Teorico de Empaque
                        //////////rpta = oN.opeUpdateTeoricoMe(Convert.ToInt32(this.cboSedes.SelectedValue),
                        //////////               Convert.ToInt32(this.cboCultivo.SelectedValue),
                        //////////                Convert.ToInt32(this.cboAño.SelectedValue),
                        //////////               Convert.ToInt32(this.cboMes.SelectedIndex) + 1);
                        this.lblPC.Text = "100.00";
                        this.lblFC.Text = dtbrief.Rows[0]["ok"].ToString();

                        MessageBox.Show("Actualización Concluída", "Teórico de Empaque", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        dgvLogMETeorico.DataSource = null;
                       

                    }
                    else
//Cargamos la tabla de log de errores para ser revisada y descargada 
                        dgvLogMETeorico.DataSource = oN.lst_Log();
                }
                else
//Cargamos la tabla de log de errores para ser revisada y descargada 
                    dgvLogMETeorico.DataSource = oN.lst_Log();
                dgvLogMETeorico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            else
                //             Cargamos la tabla de log de errores para ser revisada y descargada 
                dgvLogMETeorico.DataSource = oN.lst_Log();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {

            if (this.txtRutaExcel.Text == "")
            {
                MessageBox.Show("Debe Seleccionar una Carpeta donde se almacenara el Archivo Excel", "Teótico de Empaque", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.lblMensajesExportacion.Text = "Generando Información...";
            this.Refresh();

            dgvDataExportar.DataSource = null;

            if (dgvDataExportar.DataSource == null)
            {
                dgvDataExportar.Refresh();
                dgvDataExportar.DataSource = oN.lst_TeoricoME(Convert.ToInt32(this.cboSedesExp1.SelectedValue),
                                       Convert.ToInt32(this.cboCultivoExp1.SelectedValue),
                                        Convert.ToInt32(this.cboAñoExp.SelectedValue),
                                       Convert.ToInt32(this.cboMesExp.SelectedIndex) + 1);
                dgvDataExportar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
                wb.Worksheets.Add(dt, "LogErrores");

                wb.Worksheet(1).Columns().AdjustToContents();

                wb.SaveAs(this.txtRutaExcel.Text + "\\TEORICO_ME_" + fecha + hora + ".xlsx");
            }

            this.lblMensajesExportacion.Text = "";
            this.Refresh();

            MessageBox.Show("Proceso de grabación del Excel concluído", "Teórico de Empaque", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (this.txtRutaLog.Text == "")
            {
                MessageBox.Show("Debe Seleccionar una Carpeta donde se almacenara el Archivo Excel", "Teótico de Empaque", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.lblMensajesExportacion.Text = "Generando Información...";
            this.Refresh();

            //////dgvLogMETeorico.DataSource = null;

            //////if (dgvLogMETeorico.DataSource == null)
            //////{
            //////    dgvLogMETeorico.Refresh();
            //////    dgvLogMETeorico.DataSource = oN.lst_TeoricoME(Convert.ToInt32(this.cboSedes.SelectedValue),
            //////                           Convert.ToInt32(this.cboCultivo.SelectedValue),
            //////                            Convert.ToInt32(this.cboAño.SelectedValue),
            //////                           Convert.ToInt32(this.cboMes.SelectedIndex) + 1);
            //////    dgvLogMETeorico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //////}

            DataTable dt = new DataTable();

            foreach (DataGridViewColumn column in dgvLogMETeorico.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            foreach (DataGridViewRow row in dgvLogMETeorico.Rows)
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

                wb.SaveAs(this.txtRutaLog.Text + "\\LOG_" + fecha + hora + ".xlsx");
            }

            this.lblMensajesExportacion.Text = "";
            this.Refresh();

            MessageBox.Show("Proceso de grabación del Excel concluído", "Teórico de Empaque", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabImportar_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
 }

