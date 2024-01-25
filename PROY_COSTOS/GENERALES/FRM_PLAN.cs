using NEGOCIO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROY_COSTOS
{
    public partial class FRM_PLAN : Form
    {
        DataView oDv = new DataView();
        Metodos met = new Metodos();
        N_PLAN oN = new N_PLAN();
        private static FRM_PLAN _Instancia;
        public static FRM_PLAN GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_PLAN();
            }
            return _Instancia;
        }
        public FRM_PLAN()
        {
            InitializeComponent();
            ListarDatos("");
            txtBusqueda.Text = string.Empty;
            met.ver_VersionesPLAN();
            lblVerPLAN01.Text = Metodos.variablesGlobales.ver_plan.ToString();
            lblVerPlan02.Text = Metodos.variablesGlobales.ver_plan.ToString();
            /*this.dgbLista.Columns[0].Visible = false;
            this.dgbLista.Columns[1].Visible = false;
            this.dgbLista.Columns[2].Visible = false;*/
        }
        private void ListarDatos(string dato)
        {
            oDv = new DataView(oN.bsc_Plan(dato));
            dgbLista.DataSource = oDv;
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {

            // Abre un cuadro de diálogo para seleccionar un archivo Excel.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de Excel|*.xlsx";
            openFileDialog.Title = "Selecciona un archivo de Excel";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Crea un DataTable para almacenar los datos de Excel.
                DataTable dataTable = new DataTable();
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0]; // Suponiendo que estás trabajando con la primera hoja.

                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    dataTable.Columns.Add("VERSION");
                    dataTable.Columns.Add("MATERIAL");
                    dataTable.Columns.Add("ANIO-PERIODO");
                    dataTable.Columns.Add("PRECIO");
                    
                    for (int row = 2; row <= rowCount; row++)
                    {int inicio = 4;int cnt =0;
                        for (int colum = 2; colum <= colCount - 2; colum++)
                        {
                            DataRow dataRow = dataTable.NewRow();

                            dataRow[0] = worksheet.Cells[2, 1].Value;
                            dataRow[2] = worksheet.Cells[1, inicio + cnt].Value;
                            dataRow[1] = worksheet.Cells[row, 2].Value;
                            dataRow[3] = worksheet.Cells[row, inicio + cnt].Value;
                            cnt += 1;
                            dataTable.Rows.Add(dataRow);
                        }
                    }
                }
                dgbDatos.DataSource = dataTable;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgbDatos.RowCount < 1)
                {
                    met.MensajeError("NO EXISTEN DATOS PARA REALIZAR LA CARGA");
                }
                else
                {
                    progressBar.Maximum = Convert.ToInt32(dgbDatos.RowCount);
                    foreach (DataGridViewRow row in dgbDatos.Rows)
                    {
                        oN.insert_Plan(
                                    Convert.ToString(row.Cells["ANIO-PERIODO"].Value),
                                    1,
                                    Convert.ToInt32(row.Cells["VERSION"].Value),/*****************************/
                                    Convert.ToInt32(row.Cells["MATERIAL"].Value),
                                    Convert.ToDecimal(row.Cells["PRECIO"].Value.ToString())
                                    );
                        progressBar.Value = progressBar.Value + 1;
                    }
                    ListarDatos("");
                    dgbDatos.DataSource = null;
                    dgbDatos.Rows.Clear();
                    dgbDatos.Columns.Clear();
                    progressBar.Value = 0;

                }
               
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void FRM_PLAN_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            ListarDatos(this.txtBusqueda.Text.Trim());
        }
    }
}
