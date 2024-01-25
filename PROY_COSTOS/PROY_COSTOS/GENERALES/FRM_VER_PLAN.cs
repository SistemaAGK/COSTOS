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

namespace PROY_COSTOS.GENERALES
{
    public partial class FRM_VER_PLAN : Form
    {
        DataView oDv = new DataView();
        Metodos met = new Metodos();
        N_VERSION oN = new N_VERSION();
        N_MAESTROS oMaN = new N_MAESTROS();
        private static FRM_VER_PLAN _Instancia;
        public static FRM_VER_PLAN GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FRM_VER_PLAN();
            }
            return _Instancia;
        }
        public FRM_VER_PLAN()
        {
            InitializeComponent();
            ListarDatos();
            this.txtDescripcion.Text = string.Empty;
            this.dgbDatos.Columns[0].Visible = false;
            this.dgbDatos.Columns[1].Visible = false;
            this.dgbDatos.Columns[5].Visible = false;
        }
        private void ListarDatos()
        {
            oDv = new DataView(oN.lst_VersionPLAN());
            dgbDatos.DataSource = oDv;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                rpta = oN.crear_VersionPLAN(1,this.txtDescripcion.Text.Trim().ToUpper()); 
                ListarDatos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void FRM_VER_PPTO_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
