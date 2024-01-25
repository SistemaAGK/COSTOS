
namespace PROY_COSTOS.MANO_DE_OBRA
{
    partial class FRM_MO_CONSULTA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.cboCampaña = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkCompleta = new System.Windows.Forms.CheckBox();
            this.btnGuardarRealMO = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnSeleccionFolder = new System.Windows.Forms.Button();
            this.txtRutaExcel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboVersiones = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPeriodos = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPeriodo2 = new System.Windows.Forms.ComboBox();
            this.cboPeriodo1 = new System.Windows.Forms.ComboBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblMensajesExportacion = new System.Windows.Forms.Label();
            this.cboSedes = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboCultivo = new System.Windows.Forms.ComboBox();
            this.chkInsertar = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.grpPeriodos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatos.Location = new System.Drawing.Point(12, 116);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.Size = new System.Drawing.Size(1135, 419);
            this.dgvDatos.TabIndex = 12;
            // 
            // cboCampaña
            // 
            this.cboCampaña.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCampaña.FormattingEnabled = true;
            this.cboCampaña.Location = new System.Drawing.Point(96, 8);
            this.cboCampaña.Name = "cboCampaña";
            this.cboCampaña.Size = new System.Drawing.Size(104, 27);
            this.cboCampaña.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 19);
            this.label4.TabIndex = 13;
            this.label4.Text = "Campaña:";
            // 
            // chkCompleta
            // 
            this.chkCompleta.AutoSize = true;
            this.chkCompleta.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCompleta.Location = new System.Drawing.Point(208, 11);
            this.chkCompleta.Name = "chkCompleta";
            this.chkCompleta.Size = new System.Drawing.Size(163, 23);
            this.chkCompleta.TabIndex = 15;
            this.chkCompleta.Text = "Toda la Campaña";
            this.chkCompleta.UseVisualStyleBackColor = true;
            this.chkCompleta.CheckedChanged += new System.EventHandler(this.chkCompleta_CheckedChanged);
            // 
            // btnGuardarRealMO
            // 
            this.btnGuardarRealMO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardarRealMO.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarRealMO.Location = new System.Drawing.Point(1095, 5);
            this.btnGuardarRealMO.Name = "btnGuardarRealMO";
            this.btnGuardarRealMO.Size = new System.Drawing.Size(102, 29);
            this.btnGuardarRealMO.TabIndex = 16;
            this.btnGuardarRealMO.Text = "EJECUTAR";
            this.btnGuardarRealMO.UseVisualStyleBackColor = false;
            this.btnGuardarRealMO.Click += new System.EventHandler(this.btnGuardarRealMO_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnExportar.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Location = new System.Drawing.Point(1095, 37);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(102, 29);
            this.btnExportar.TabIndex = 17;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnSeleccionFolder
            // 
            this.btnSeleccionFolder.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionFolder.Location = new System.Drawing.Point(1051, 42);
            this.btnSeleccionFolder.Name = "btnSeleccionFolder";
            this.btnSeleccionFolder.Size = new System.Drawing.Size(37, 28);
            this.btnSeleccionFolder.TabIndex = 21;
            this.btnSeleccionFolder.Text = "...";
            this.btnSeleccionFolder.UseVisualStyleBackColor = true;
            this.btnSeleccionFolder.Click += new System.EventHandler(this.btnSeleccionFolder_Click);
            // 
            // txtRutaExcel
            // 
            this.txtRutaExcel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRutaExcel.Location = new System.Drawing.Point(542, 44);
            this.txtRutaExcel.Name = "txtRutaExcel";
            this.txtRutaExcel.Size = new System.Drawing.Size(503, 26);
            this.txtRutaExcel.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(392, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 19);
            this.label3.TabIndex = 19;
            this.label3.Text = "Carpeta Salida:";
            // 
            // cboVersiones
            // 
            this.cboVersiones.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboVersiones.FormattingEnabled = true;
            this.cboVersiones.Location = new System.Drawing.Point(948, 8);
            this.cboVersiones.Name = "cboVersiones";
            this.cboVersiones.Size = new System.Drawing.Size(138, 27);
            this.cboVersiones.TabIndex = 23;
            this.cboVersiones.SelectedIndexChanged += new System.EventHandler(this.cboVersiones_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(852, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "Ver.Ppto.:";
            // 
            // grpPeriodos
            // 
            this.grpPeriodos.Controls.Add(this.label5);
            this.grpPeriodos.Controls.Add(this.label2);
            this.grpPeriodos.Controls.Add(this.cboPeriodo2);
            this.grpPeriodos.Controls.Add(this.cboPeriodo1);
            this.grpPeriodos.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPeriodos.Location = new System.Drawing.Point(12, 35);
            this.grpPeriodos.Name = "grpPeriodos";
            this.grpPeriodos.Size = new System.Drawing.Size(363, 49);
            this.grpPeriodos.TabIndex = 27;
            this.grpPeriodos.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 19);
            this.label5.TabIndex = 29;
            this.label5.Text = "Desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(181, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 19);
            this.label2.TabIndex = 28;
            this.label2.Text = "Hasta:";
            // 
            // cboPeriodo2
            // 
            this.cboPeriodo2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodo2.FormattingEnabled = true;
            this.cboPeriodo2.Location = new System.Drawing.Point(248, 15);
            this.cboPeriodo2.Name = "cboPeriodo2";
            this.cboPeriodo2.Size = new System.Drawing.Size(107, 27);
            this.cboPeriodo2.TabIndex = 27;
            // 
            // cboPeriodo1
            // 
            this.cboPeriodo1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodo1.FormattingEnabled = true;
            this.cboPeriodo1.Location = new System.Drawing.Point(72, 15);
            this.cboPeriodo1.Name = "cboPeriodo1";
            this.cboPeriodo1.Size = new System.Drawing.Size(103, 27);
            this.cboPeriodo1.TabIndex = 26;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSalir.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(1095, 70);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(102, 29);
            this.btnSalir.TabIndex = 28;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblMensajesExportacion
            // 
            this.lblMensajesExportacion.BackColor = System.Drawing.Color.White;
            this.lblMensajesExportacion.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajesExportacion.ForeColor = System.Drawing.Color.Red;
            this.lblMensajesExportacion.Location = new System.Drawing.Point(12, 538);
            this.lblMensajesExportacion.Name = "lblMensajesExportacion";
            this.lblMensajesExportacion.Size = new System.Drawing.Size(557, 20);
            this.lblMensajesExportacion.TabIndex = 36;
            // 
            // cboSedes
            // 
            this.cboSedes.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSedes.FormattingEnabled = true;
            this.cboSedes.Location = new System.Drawing.Point(447, 8);
            this.cboSedes.Name = "cboSedes";
            this.cboSedes.Size = new System.Drawing.Size(141, 27);
            this.cboSedes.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(392, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 19);
            this.label6.TabIndex = 37;
            this.label6.Text = "Sede:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(610, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 19);
            this.label7.TabIndex = 39;
            this.label7.Text = "Cultivo:";
            // 
            // cboCultivo
            // 
            this.cboCultivo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCultivo.FormattingEnabled = true;
            this.cboCultivo.Location = new System.Drawing.Point(697, 9);
            this.cboCultivo.Name = "cboCultivo";
            this.cboCultivo.Size = new System.Drawing.Size(138, 27);
            this.cboCultivo.TabIndex = 40;
            // 
            // chkInsertar
            // 
            this.chkInsertar.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInsertar.Location = new System.Drawing.Point(1203, 1);
            this.chkInsertar.Name = "chkInsertar";
            this.chkInsertar.Size = new System.Drawing.Size(107, 42);
            this.chkInsertar.TabIndex = 41;
            this.chkInsertar.Text = "Insertar EN B.D.";
            this.chkInsertar.UseVisualStyleBackColor = true;
            // 
            // FRM_MO_CONSULTA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 614);
            this.Controls.Add(this.chkInsertar);
            this.Controls.Add(this.cboCultivo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboSedes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblMensajesExportacion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.grpPeriodos);
            this.Controls.Add(this.cboVersiones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSeleccionFolder);
            this.Controls.Add(this.txtRutaExcel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnGuardarRealMO);
            this.Controls.Add(this.chkCompleta);
            this.Controls.Add(this.cboCampaña);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvDatos);
            this.Name = "FRM_MO_CONSULTA";
            this.Text = "Consultas Real vs. Presupuesto";
            this.Load += new System.EventHandler(this.FRM_MO_CONSULTA_Load);
            this.Resize += new System.EventHandler(this.FRM_MO_CONSULTA_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.grpPeriodos.ResumeLayout(false);
            this.grpPeriodos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.ComboBox cboCampaña;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkCompleta;
        private System.Windows.Forms.Button btnGuardarRealMO;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnSeleccionFolder;
        private System.Windows.Forms.TextBox txtRutaExcel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboVersiones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpPeriodos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPeriodo2;
        private System.Windows.Forms.ComboBox cboPeriodo1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblMensajesExportacion;
        private System.Windows.Forms.ComboBox cboSedes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboCultivo;
        private System.Windows.Forms.CheckBox chkInsertar;
    }
}