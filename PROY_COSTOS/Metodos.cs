using System;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using NEGOCIO;
using System.Security.Cryptography;
using System.Runtime.InteropServices.WindowsRuntime;

namespace PROY_COSTOS
{
    public class Metodos
    {
        string nombre;
        string VersionS;
        OleDbConnection conn;
        OleDbDataAdapter MyDataAdapter;
        DataTable dt;
        N_TCAMBIO oN = new N_TCAMBIO();
        N_MAESTROS oMa = new N_MAESTROS();
        string tipCambioAct;
        string campActual;
        string rang_fecha;

        public static class variablesGlobales
        {
            public static int cod_campania;
            public static int ver_ppto;
            public static int ver_plan;
            public static decimal tcambio_diario;
            public static decimal tcambio_mensual;
        }

        public void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, NombreSistema(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, NombreSistema(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void SoloLetras(KeyPressEventArgs v)
        {
            if (Char.IsLetter(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsSeparator(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsControl(v.KeyChar))
            {
                v.Handled = false;
            }
            else
            {
                v.Handled = true;
                MessageBox.Show("Solo Letras", NombreSistema());
            }
        }
        public void SoloNumeros(KeyPressEventArgs v)
        {
            if (Char.IsDigit(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsSeparator(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsControl(v.KeyChar))
            {
                v.Handled = false;
            }
            else
            {
                v.Handled = true;
                MessageBox.Show("Solo Numeros", NombreSistema());
            }
        }
        public string NombreSistema()
        {
            nombre = "AGROKASA S.A.";
            return nombre;
        }
        public string VersionSistema()
        {
            VersionS = "V 1.10";
            return VersionS;
        }
        public string camp_Actual()
        {
            DataTable dt = oMa.lstCampania(1);
            if (dt.Rows.Count != 0)
            {
                variablesGlobales.cod_campania = Convert.ToInt32(dt.Rows[0][0]);
                campActual = Convert.ToString(dt.Rows[0][1]);
                //rang_fecha = Convert.ToString(dt.Rows[0][2], "MM yyyy");
                //f_fin = dt.Rows[0][3]);
            }
            else
            {
                campActual = "NO EXISTE CAMPANIA ACTUAL";
            }
            return campActual;
        }
        public void ver_VersionesPPTO()
        {
            DataTable dt = oMa.lst_VersionesG(1);
            if (dt.Rows.Count != 0)
            {
                variablesGlobales.ver_ppto = Convert.ToInt32(dt.Rows[0][0]);
            }
        }
        public void ver_VersionesPLAN()
        {
            DataTable dt = oMa.lst_VersionesG(2);
            if (dt.Rows.Count != 0)
            {
                variablesGlobales.ver_plan = Convert.ToInt32(dt.Rows[0][0]);
            }
        }
        /************************/
        public void ver_tcambioMensual()
        {
            DataTable dt = oMa.lst_VersionesG(4);
            if (dt.Rows.Count != 0)
            {
                variablesGlobales.tcambio_mensual = Convert.ToDecimal(dt.Rows[0][0]);
            }
        }
        public void ver_tcambioDiario()
        {
            DataTable dt = oMa.lst_VersionesG(3);
            if (dt.Rows.Count != 0)
            {
                variablesGlobales.tcambio_diario = Convert.ToDecimal(dt.Rows[0][0]);
            }
        }
        /*************************/
        public void importarExcel(DataGridView dgv, String nombreHoja)
        {
            String ruta = "";
            try
            {
                OpenFileDialog openfile1 = new OpenFileDialog();
                openfile1.Filter = "Excel Files |*.xlsx";
                openfile1.Title = "Seleccione el archivo de Excel";
                if (openfile1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openfile1.FileName.Equals("") == false)
                    {
                        ruta = openfile1.FileName;
                    }

                    conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; data source=" + ruta + ";Extended Properties='Excel 12.0;HDR=Yes'");
                    MyDataAdapter = new OleDbDataAdapter("Select * from [" + nombreHoja + "$]", conn);
                    dt = new DataTable();
                    MyDataAdapter.Fill(dt);
                    dgv.DataSource = dt;



                }
                else
                {
                    MensajeError("No selecciono ningun archivo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
