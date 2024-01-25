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
    public partial class FRM_ME_COMPARATIVO : Form
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


        public FRM_ME_COMPARATIVO()
        {
            InitializeComponent();

            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;
            this.chkActualiza.Checked = false;
            this.cargar_temporada();
            this.cargar_versiones();
            this.cargar_periodos();
            ////this.cargar_sede();
            ////this.cargar_cultivo();
            this.cargar_sedes();
            this.cargar_cultivos();
            //this.cargar_años();
            //this.cargar_meses();
        }

        private void cargar_versiones()
        {
            cboVersiones.DataSource = oN.lst_VersionesPptoME(Convert.ToInt32(this.cboCampaña.SelectedValue));
            cboVersiones.DisplayMember = "descripcion";
            cboVersiones.ValueMember = "nom_version";
        }

        private void cargar_temporada()
        {
            cboCampaña.DataSource = oN.lst_Temporada();
            cboCampaña.DisplayMember = "campania";
            cboCampaña.ValueMember = "cod_camp";
        }

        private void cargar_periodos()
        {
            cboPeriodo1.DataSource = oN.lst_Periodos(1);
            cboPeriodo1.DisplayMember = "nom_mes";
            cboPeriodo1.ValueMember = "cod_mes";

            cboPeriodo2.DataSource = oN.lst_Periodos(1);
            cboPeriodo2.DisplayMember = "nom_mes";
            cboPeriodo2.ValueMember = "cod_mes";
        }

        private void cargar_sedes()
        {
            cboSedesExp.DataSource = oN.lst_Sedes();
            cboSedesExp.DisplayMember = "sede";
            cboSedesExp.ValueMember = "cod_sede";
        }
        private void cargar_cultivos()
        {
            cboCultivoExp.DataSource = oN.lst_Cultivos();
            cboCultivoExp.DisplayMember = "cultivo_nombre";
            cboCultivoExp.ValueMember = "cod_cultivo";
        }

        ////private void cargar_sede()
        ////{
        ////    cboSedesExp.DataSource = oN.lst_Sedes();
        ////    cboSedesExp.DisplayMember = "sede";
        ////    cboSedesExp.ValueMember = "cod_sede";
        ////}
        ////private void cargar_cultivo()
        ////{
        ////    cboCultivoExp.DataSource = oN.lst_Cultivo();
        ////    cboCultivoExp.DisplayMember = "cultivo_nombre";
        ////    cboCultivoExp.ValueMember = "cod_cultivo";
        ////}

        //private void cargar_años()
        //{
            //cboAñoExp.DataSource = oN.lst_año();
            //cboAñoExp.DisplayMember = "año";
            //cboAñoExp.ValueMember = "cod_año";
        //}

        //private void cargar_meses()
        //{
            //cboMesExp.Items.Add("Enero");
            //cboMesExp.Items.Add("Febrero");
            //cboMesExp.Items.Add("Marzo");
            //cboMesExp.Items.Add("Abril");
            //cboMesExp.Items.Add("Mayo");
            //cboMesExp.Items.Add("Junio");
            //cboMesExp.Items.Add("Julio");
            //cboMesExp.Items.Add("Agosto");
            //cboMesExp.Items.Add("Setiembre");
            //cboMesExp.Items.Add("Octubre");
            //cboMesExp.Items.Add("Noviembre");
            //cboMesExp.Items.Add("Diciembre");
            //cboMesExp.SelectedIndex = 0;
        //}
        private void FRM_ME_CONSUMO_TEORICO_Load(object sender, EventArgs e)
        {
            resize();
        }
        private void resize()
        {
           this.tabControlME.Width = this.Width - 50;
            this.tabControlME.Height = this.Height - 60;
            this.dgvDataExportarC.Width = this.tabControlME.Width - 50;
            this.dgvDataExportarC.Height = this.tabControlME.Height - 190;
           this.lblMensajesExportacion.Location = new Point(28, this.tabControlME.Height - 55);
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
            int p1, p2;

            p1 = Convert.ToInt32(this.cboPeriodo1.SelectedValue);
            p2 = Convert.ToInt32(this.cboPeriodo2.SelectedValue);

            if (p1 >= 3)
            {
                if (p2 >= 3 && p2 <= 12)
                {
                    if (p2 < p1)
                    {
                        MessageBox.Show("El PERIODO FINAL no puede ser menor que el PERIODO INICIAL", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {

                }
            }
            else
            {
                if (p1 >= 1 && p1 <= 2)
                {
                    if (p2 < p1)
                    {
                        MessageBox.Show("El PERIODO FINAL no puede ser menor que el PERIODO INICIAL", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            int actualiza;
            if (this.chkActualiza.Checked == true)
            {
                actualiza = 1;
            }
            else
            {
                actualiza = 0;
            }

            this.lblMensajesExportacion.Text = "Cargando Información...";
            this.Refresh();
            dgvDataExportarC.DataSource = null;
            dgvDataExportarC.Refresh();
            dgvDataExportarC.DataSource = oN.lst_ComparativoME(Convert.ToInt32(this.cboCampaña.SelectedValue),
                                                                 Convert.ToInt32(this.cboPeriodo1.SelectedValue),
                                                                 Convert.ToInt32(this.cboPeriodo2.SelectedValue),
                                                                 Convert.ToInt32(this.cboSedesExp.SelectedValue),
                                                                 Convert.ToInt32(this.cboCultivoExp.SelectedValue),
                                                                 Convert.ToInt32(this.cboVersiones.SelectedValue),
                                                                 Convert.ToInt32(actualiza)
                                                        //Convert.ToInt32(this.cboAñoExp.SelectedValue),
                                                        //Convert.ToInt32(this.cboMesExp.SelectedIndex) + 1
                                                        );
            dgvDataExportarC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.lblMensajesExportacion.Text = "Proceso Finalizado";
            this.Refresh();

        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {

            int actualiza;
            if (this.chkActualiza.Checked == true)
            {
                actualiza = 1;
            }
            else
            {
                actualiza = 0;
            }

            if (this.txtRutaExcel.Text == "")
            {
                MessageBox.Show("Debe Seleccionar una Carpeta donde se almacenara el Archivo Excel", "Teótico de Empaque", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvDataExportarC.DataSource = null;
            this.lblMensajesExportacion.Text = "Generando Información...";
            this.Refresh();
            if (dgvDataExportarC.DataSource == null)
            {
                dgvDataExportarC.Refresh();
                dgvDataExportarC.DataSource = oN.lst_ComparativoME(Convert.ToInt32(this.cboCampaña.SelectedValue),
                                                                 Convert.ToInt32(this.cboPeriodo1.SelectedValue),
                                                                 Convert.ToInt32(this.cboPeriodo2.SelectedValue),
                                                                 Convert.ToInt32(this.cboSedesExp.SelectedValue),
                                                                 Convert.ToInt32(this.cboCultivoExp.SelectedValue),
                                                                 Convert.ToInt32(this.cboVersiones.SelectedValue),
                                                                 Convert.ToInt32(actualiza)
                                                                 );
                                                                 ////Convert.ToInt32(this.cboAñoExp.SelectedValue),
                                                                 ////Convert.ToInt32(this.cboMesExp.SelectedIndex) + 1);
            }

            DataTable dt = new DataTable();

            foreach (DataGridViewColumn column in dgvDataExportarC.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            foreach (DataGridViewRow row in dgvDataExportarC.Rows)
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
                wb.Worksheets.Add(dt, "Comparativo Empaque");

                wb.Worksheet(1).Columns().AdjustToContents();

                wb.SaveAs(this.txtRutaExcel.Text + "\\COMPARATIVO_ME" + fecha + hora + ".xlsx");
            }

            this.lblMensajesExportacion.Text = "";
            this.Refresh();

            MessageBox.Show("Proceso de grabación del Excel concluído", "Comparativo de Empaque", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

   

        //////    if (dtbrief.Rows.Count > 0)
        //////    {
        //////        this.lblFV.Text = dtbrief.Rows[0]["ok"].ToString();
        //////        this.lblFV.Refresh();

        //////        this.lblPV.Text = dtbrief.Rows[0]["por_ok"].ToString();
        //////        this.lblPV.Refresh();

        //////        if (this.lblPV.Text == "100.00")
        //////        {
        //////            if (MessageBox.Show("Se han validado correctamente " + this.lblFV.Text.Trim() + " Filas.\r\n" + "¿Esta seguro de proceder a la Actualización?", "Teórico de Empaque", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
        //////            {
        //////                //Calculamos y grabamos en la tabla definitiva de Teorico de Empaque
        //////                rpta = oN.opeUpdateTeoricoMe(Convert.ToInt32(this.cboSedes.SelectedValue),
        //////                               Convert.ToInt32(this.cboCultivo.SelectedValue),
        //////                                Convert.ToInt32(this.cboAño.SelectedValue),
        //////                               Convert.ToInt32(this.cboMes.SelectedIndex) + 1);
        //////                this.lblPC.Text = "100.00";
        //////                this.lblFC.Text = dtbrief.Rows[0]["ok"].ToString();

        //////                MessageBox.Show("Actualización Concluída", "Teórico de Empaque", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        //////            }
        //////            else
        //////                //Cargamos la tabla de log de errores para ser revisada y descargada 
        //////                dgvLogMETeorico.DataSource = oN.lst_Log();
        //////        }
        //////        else
        //////            //Cargamos la tabla de log de errores para ser revisada y descargada 
        //////            dgvLogMETeorico.DataSource = oN.lst_Log();
        //////        dgvLogMETeorico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        //////    }
        //////    else
        //////        //             Cargamos la tabla de log de errores para ser revisada y descargada 
        //////        dgvLogMETeorico.DataSource = oN.lst_Log();
        //////}

    }
}


