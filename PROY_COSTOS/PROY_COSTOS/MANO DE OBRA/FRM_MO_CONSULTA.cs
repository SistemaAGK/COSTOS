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
    public partial class FRM_MO_CONSULTA : Form
    {
        //      Un DataSet es un objeto que almacena n número de DataTables, estas tablas puedes estar conectadas dentro del dataset.
        private DataSet dtsTablas = new DataSet();
        private DataTable dtbrief;
        private static FRM_MO_REAL _Instancia;

        N_CONSULTA_MO oN = new N_CONSULTA_MO();
        public FRM_MO_CONSULTA()
        {
            InitializeComponent();

            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;

            this.cargar_temporada();
            this.cargar_versiones();
            this.cargar_periodos();
            this.cargar_sedes();
            this.cargar_cultivos();
        }
        private void cargar_temporada()
        {
            cboCampaña.DataSource = oN.lst_Temporada();
            cboCampaña.DisplayMember = "campania";
            cboCampaña.ValueMember = "cod_camp";
        }
        private void cargar_versiones()
        {
            cboVersiones.DataSource = oN.lst_VersionesPptoMO(Convert.ToInt32(this.cboCampaña.SelectedValue));
            cboVersiones.DisplayMember = "nom_version";
            cboVersiones.ValueMember = "cod_ver";
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
            cboSedes.DataSource = oN.lst_Sedes();
            cboSedes.DisplayMember = "sede";
            cboSedes.ValueMember = "cod_sede";
        }
        private void cargar_cultivos()
        {
            cboCultivo.DataSource = oN.lst_Cultivos();
            cboCultivo.DisplayMember = "cultivo_nombre";
            cboCultivo.ValueMember = "cod_cultivo";
        }
        private void btnSeleccionFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtRutaExcel.Text = fbd.SelectedPath;
            }
        }
        private void resize()
        {
            this.dgvDatos.Width = this.Width - 40;
            this.dgvDatos.Height = this.Height - 182;
            this.lblMensajesExportacion.Location = new Point(28, this.Height - 65);
        }

        private void FRM_MO_CONSULTA_Load(object sender, EventArgs e)
        {
            resize();
        }
        private void FRM_MO_CONSULTA_Resize(object sender, EventArgs e)
        {
            resize();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarRealMO_Click(object sender, EventArgs e)
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

            if (this.chkInsertar.Checked == true)
            {
                if (MessageBox.Show("Como marco el check de Insertar en la Base de Datos se\r\n" +
                                 "debe tener en cuenta que se actualizarán lo siguiente:\r\n\r\n" +
                                 "Campaña: 2023\r\n" +
                                 "Periodo Inicial: " + this.cboPeriodo1.Text + "\r\n" +
                                 "Periodo Final: " + this.cboPeriodo2.Text + "\r\n" +
                                 "Sedes: " + this.cboSedes.Text + "\r\n" +
                                 "Cultivo: " + this.cboCultivo.Text + "\r\n" +
                                 "Version Ppto.: " + this.cboVersiones.Text + "\r\n\r\n" +
                                 "Si tuviese información previamente cargada para dichos datos\r\n" +
                                 "SE PERDERAN al finalizar el proceso.\r\n\r\n" +
                                 "¿Esta seguro de continuar con la actualización ?", "Indicadores Costos", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                { 
                    return;
                }

            }

            this.lblMensajesExportacion.Text = "Cargando Información...";
            this.Refresh();

            dgvDatos.Refresh();
            dgvDatos.DataSource = oN.lst_PptoRealMO(Convert.ToInt32(this.cboCampaña.SelectedValue),
                                                    Convert.ToInt32(this.cboPeriodo1.SelectedValue),
                                                    Convert.ToInt32(this.cboPeriodo2.SelectedValue),
                                                    Convert.ToInt32(this.cboVersiones.SelectedValue),
                                                    Convert.ToInt32(this.cboSedes.SelectedValue),
                                                    Convert.ToInt32(this.cboCultivo.SelectedValue),
                                                    this.chkInsertar.Checked );

            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.lblMensajesExportacion.Text = "";
            this.Refresh();
        }

        private void cboVersiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgvDatos.DataSource = null;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (this.txtRutaExcel.Text == "")
            {
                MessageBox.Show("Debe Seleccionar una Carpeta donde se almacenara el Archivo Excel", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.lblMensajesExportacion.Text = "Generando Información...";
            this.Refresh();

            if (dgvDatos.DataSource == null)
            {
                dgvDatos.Refresh();
                dgvDatos.DataSource = oN.lst_PptoRealMO(Convert.ToInt32(this.cboCampaña.SelectedValue),
                                                       Convert.ToInt32(this.cboPeriodo1.SelectedValue),
                                                       Convert.ToInt32(this.cboPeriodo2.SelectedValue),
                                                       Convert.ToInt32(this.cboVersiones.SelectedValue),
                                                       Convert.ToInt32(this.cboSedes.SelectedValue),
                                                       Convert.ToInt32(this.cboCultivo.SelectedValue),
                                                       this.chkInsertar.Checked );

            }

            DataTable dt = new DataTable();

            foreach (DataGridViewColumn column in dgvDatos.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            foreach (DataGridViewRow row in dgvDatos.Rows)
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

                wb.SaveAs(this.txtRutaExcel.Text + "\\PPTOREAL_MO" + fecha + hora + ".xlsx");
            }

            this.lblMensajesExportacion.Text = "";
            this.Refresh();

            MessageBox.Show("Proceso de grabación del Excel concluído", "Indicadores Costos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chkCompleta_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkCompleta.Checked == true)
            {
                this.cboPeriodo1.SelectedIndex = 0;
                this.cboPeriodo2.SelectedIndex = 11; 
                this.grpPeriodos.Enabled = false; 
            }
                
            else
                this.grpPeriodos.Enabled = true;
        }
    }
}
