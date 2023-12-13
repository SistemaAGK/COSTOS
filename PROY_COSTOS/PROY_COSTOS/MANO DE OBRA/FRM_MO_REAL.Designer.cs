﻿
namespace PROY_COSTOS.MANO_DE_OBRA
{
    partial class FRM_MO_REAL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtRutaLog = new System.Windows.Forms.TextBox();
            this.btnExportar = new System.Windows.Forms.Button();
            this.tabExportar = new System.Windows.Forms.TabPage();
            this.lblMensajesExportacion = new System.Windows.Forms.Label();
            this.dgvDataExportar = new System.Windows.Forms.DataGridView();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnSeleccionarFolderExp = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.txtRutaExcel = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboCampañaExp = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboSedesExp = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboPeriodoExp = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.grpPasos = new System.Windows.Forms.GroupBox();
            this.lblFC = new System.Windows.Forms.Label();
            this.lblPC = new System.Windows.Forms.Label();
            this.lblFV = new System.Windows.Forms.Label();
            this.lblPV = new System.Windows.Forms.Label();
            this.lblFE = new System.Windows.Forms.Label();
            this.lblPE = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReprocesar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnGuardarRealMO = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.cboHojas = new System.Windows.Forms.ComboBox();
            this.lblMensajesImportacion = new System.Windows.Forms.Label();
            this.tabImportar = new System.Windows.Forms.TabPage();
            this.chkTarifa = new System.Windows.Forms.CheckBox();
            this.cboSedesImp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.cboCampaña = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboPeriodo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControlMO = new System.Windows.Forms.TabControl();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.lblMensajesLog = new System.Windows.Forms.Label();
            this.btnSeleccionFolder = new System.Windows.Forms.Button();
            this.tabExportar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataExportar)).BeginInit();
            this.grpPasos.SuspendLayout();
            this.tabImportar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.tabControlMO.SuspendLayout();
            this.tabLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRutaLog
            // 
            this.txtRutaLog.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRutaLog.Location = new System.Drawing.Point(184, 22);
            this.txtRutaLog.Name = "txtRutaLog";
            this.txtRutaLog.Size = new System.Drawing.Size(509, 26);
            this.txtRutaLog.TabIndex = 17;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnExportar.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Location = new System.Drawing.Point(744, 21);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(102, 29);
            this.btnExportar.TabIndex = 15;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // tabExportar
            // 
            this.tabExportar.Controls.Add(this.lblMensajesExportacion);
            this.tabExportar.Controls.Add(this.dgvDataExportar);
            this.tabExportar.Controls.Add(this.btnMostrar);
            this.tabExportar.Controls.Add(this.btnSeleccionarFolderExp);
            this.tabExportar.Controls.Add(this.btnExportarExcel);
            this.tabExportar.Controls.Add(this.txtRutaExcel);
            this.tabExportar.Controls.Add(this.label13);
            this.tabExportar.Controls.Add(this.cboCampañaExp);
            this.tabExportar.Controls.Add(this.label14);
            this.tabExportar.Controls.Add(this.cboSedesExp);
            this.tabExportar.Controls.Add(this.label15);
            this.tabExportar.Controls.Add(this.cboPeriodoExp);
            this.tabExportar.Controls.Add(this.label16);
            this.tabExportar.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabExportar.Location = new System.Drawing.Point(4, 28);
            this.tabExportar.Name = "tabExportar";
            this.tabExportar.Size = new System.Drawing.Size(863, 591);
            this.tabExportar.TabIndex = 2;
            this.tabExportar.Text = "EXPORTAR";
            this.tabExportar.UseVisualStyleBackColor = true;
            // 
            // lblMensajesExportacion
            // 
            this.lblMensajesExportacion.BackColor = System.Drawing.Color.White;
            this.lblMensajesExportacion.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajesExportacion.ForeColor = System.Drawing.Color.Red;
            this.lblMensajesExportacion.Location = new System.Drawing.Point(28, 567);
            this.lblMensajesExportacion.Name = "lblMensajesExportacion";
            this.lblMensajesExportacion.Size = new System.Drawing.Size(557, 20);
            this.lblMensajesExportacion.TabIndex = 34;
            // 
            // dgvDataExportar
            // 
            this.dgvDataExportar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDataExportar.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvDataExportar.Location = new System.Drawing.Point(22, 132);
            this.dgvDataExportar.Name = "dgvDataExportar";
            this.dgvDataExportar.ReadOnly = true;
            this.dgvDataExportar.Size = new System.Drawing.Size(819, 432);
            this.dgvDataExportar.TabIndex = 33;
            // 
            // btnMostrar
            // 
            this.btnMostrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMostrar.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrar.Location = new System.Drawing.Point(637, 52);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(102, 29);
            this.btnMostrar.TabIndex = 32;
            this.btnMostrar.Text = "MOSTRAR";
            this.btnMostrar.UseVisualStyleBackColor = false;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // btnSeleccionarFolderExp
            // 
            this.btnSeleccionarFolderExp.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarFolderExp.Location = new System.Drawing.Point(511, 50);
            this.btnSeleccionarFolderExp.Name = "btnSeleccionarFolderExp";
            this.btnSeleccionarFolderExp.Size = new System.Drawing.Size(37, 29);
            this.btnSeleccionarFolderExp.TabIndex = 29;
            this.btnSeleccionarFolderExp.Text = "...";
            this.btnSeleccionarFolderExp.UseVisualStyleBackColor = false;
            this.btnSeleccionarFolderExp.Click += new System.EventHandler(this.btnSeleccionarFolderExp_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnExportarExcel.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcel.Location = new System.Drawing.Point(745, 51);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(102, 29);
            this.btnExportarExcel.TabIndex = 28;
            this.btnExportarExcel.Text = "EXPORTAR";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // txtRutaExcel
            // 
            this.txtRutaExcel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRutaExcel.Location = new System.Drawing.Point(109, 52);
            this.txtRutaExcel.Name = "txtRutaExcel";
            this.txtRutaExcel.Size = new System.Drawing.Size(396, 26);
            this.txtRutaExcel.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(24, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 19);
            this.label13.TabIndex = 26;
            this.label13.Text = "Carpeta:";
            // 
            // cboCampañaExp
            // 
            this.cboCampañaExp.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCampañaExp.FormattingEnabled = true;
            this.cboCampañaExp.Location = new System.Drawing.Point(379, 18);
            this.cboCampañaExp.Name = "cboCampañaExp";
            this.cboCampañaExp.Size = new System.Drawing.Size(157, 27);
            this.cboCampañaExp.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(300, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 19);
            this.label14.TabIndex = 24;
            this.label14.Text = "Campaña:";
            // 
            // cboSedesExp
            // 
            this.cboSedesExp.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSedesExp.FormattingEnabled = true;
            this.cboSedesExp.Location = new System.Drawing.Point(109, 16);
            this.cboSedesExp.Name = "cboSedesExp";
            this.cboSedesExp.Size = new System.Drawing.Size(157, 27);
            this.cboSedesExp.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(24, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 19);
            this.label15.TabIndex = 22;
            this.label15.Text = "Sede:";
            // 
            // cboPeriodoExp
            // 
            this.cboPeriodoExp.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodoExp.FormattingEnabled = true;
            this.cboPeriodoExp.Location = new System.Drawing.Point(649, 16);
            this.cboPeriodoExp.Name = "cboPeriodoExp";
            this.cboPeriodoExp.Size = new System.Drawing.Size(122, 27);
            this.cboPeriodoExp.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(562, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 19);
            this.label16.TabIndex = 19;
            this.label16.Text = "Periodo:";
            // 
            // grpPasos
            // 
            this.grpPasos.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grpPasos.Controls.Add(this.lblFC);
            this.grpPasos.Controls.Add(this.lblPC);
            this.grpPasos.Controls.Add(this.lblFV);
            this.grpPasos.Controls.Add(this.lblPV);
            this.grpPasos.Controls.Add(this.lblFE);
            this.grpPasos.Controls.Add(this.lblPE);
            this.grpPasos.Controls.Add(this.label12);
            this.grpPasos.Controls.Add(this.label11);
            this.grpPasos.Controls.Add(this.label10);
            this.grpPasos.Controls.Add(this.label9);
            this.grpPasos.Controls.Add(this.label8);
            this.grpPasos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpPasos.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.grpPasos.Location = new System.Drawing.Point(903, 42);
            this.grpPasos.Name = "grpPasos";
            this.grpPasos.Size = new System.Drawing.Size(305, 123);
            this.grpPasos.TabIndex = 4;
            this.grpPasos.TabStop = false;
            this.grpPasos.Text = "Pasos (Última Ejecución)";
            this.grpPasos.Enter += new System.EventHandler(this.grpPasos_Enter);
            // 
            // lblFC
            // 
            this.lblFC.BackColor = System.Drawing.Color.Blue;
            this.lblFC.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFC.ForeColor = System.Drawing.Color.Yellow;
            this.lblFC.Location = new System.Drawing.Point(208, 93);
            this.lblFC.Name = "lblFC";
            this.lblFC.Size = new System.Drawing.Size(73, 19);
            this.lblFC.TabIndex = 10;
            // 
            // lblPC
            // 
            this.lblPC.BackColor = System.Drawing.Color.Blue;
            this.lblPC.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPC.ForeColor = System.Drawing.Color.Yellow;
            this.lblPC.Location = new System.Drawing.Point(136, 93);
            this.lblPC.Name = "lblPC";
            this.lblPC.Size = new System.Drawing.Size(68, 19);
            this.lblPC.TabIndex = 9;
            // 
            // lblFV
            // 
            this.lblFV.BackColor = System.Drawing.Color.Blue;
            this.lblFV.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFV.ForeColor = System.Drawing.Color.Yellow;
            this.lblFV.Location = new System.Drawing.Point(208, 70);
            this.lblFV.Name = "lblFV";
            this.lblFV.Size = new System.Drawing.Size(73, 19);
            this.lblFV.TabIndex = 8;
            // 
            // lblPV
            // 
            this.lblPV.BackColor = System.Drawing.Color.Blue;
            this.lblPV.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPV.ForeColor = System.Drawing.Color.Yellow;
            this.lblPV.Location = new System.Drawing.Point(136, 70);
            this.lblPV.Name = "lblPV";
            this.lblPV.Size = new System.Drawing.Size(68, 19);
            this.lblPV.TabIndex = 7;
            // 
            // lblFE
            // 
            this.lblFE.BackColor = System.Drawing.Color.Blue;
            this.lblFE.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFE.ForeColor = System.Drawing.Color.Yellow;
            this.lblFE.Location = new System.Drawing.Point(208, 47);
            this.lblFE.Name = "lblFE";
            this.lblFE.Size = new System.Drawing.Size(73, 19);
            this.lblFE.TabIndex = 6;
            // 
            // lblPE
            // 
            this.lblPE.BackColor = System.Drawing.Color.Blue;
            this.lblPE.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPE.ForeColor = System.Drawing.Color.Yellow;
            this.lblPE.Location = new System.Drawing.Point(136, 47);
            this.lblPE.Name = "lblPE";
            this.lblPE.Size = new System.Drawing.Size(68, 19);
            this.lblPE.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(208, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 19);
            this.label12.TabIndex = 4;
            this.label12.Text = "# Filas ";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(137, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 19);
            this.label11.TabIndex = 3;
            this.label11.Text = "  %  ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 19);
            this.label10.TabIndex = 2;
            this.label10.Text = "CÁLCULO:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 19);
            this.label9.TabIndex = 1;
            this.label9.Text = "VALIDACIÓN:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "EXTRACCIÓN:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Carpeta Salida:";
            // 
            // btnReprocesar
            // 
            this.btnReprocesar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnReprocesar.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReprocesar.Location = new System.Drawing.Point(744, 56);
            this.btnReprocesar.Name = "btnReprocesar";
            this.btnReprocesar.Size = new System.Drawing.Size(102, 29);
            this.btnReprocesar.TabIndex = 37;
            this.btnReprocesar.Text = "REPROCESAR";
            this.btnReprocesar.UseVisualStyleBackColor = false;
            this.btnReprocesar.Click += new System.EventHandler(this.btnReprocesar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(594, 45);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(37, 29);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Text = "...";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnGuardarRealMO
            // 
            this.btnGuardarRealMO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardarRealMO.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarRealMO.Location = new System.Drawing.Point(631, 82);
            this.btnGuardarRealMO.Name = "btnGuardarRealMO";
            this.btnGuardarRealMO.Size = new System.Drawing.Size(102, 29);
            this.btnGuardarRealMO.TabIndex = 14;
            this.btnGuardarRealMO.Text = "EJECUTAR";
            this.btnGuardarRealMO.UseVisualStyleBackColor = false;
            this.btnGuardarRealMO.Click += new System.EventHandler(this.btnGuardarRealMO_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuta.Location = new System.Drawing.Point(136, 47);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(452, 26);
            this.txtRuta.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Libro Excel:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSalir.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(739, 82);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(102, 29);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cboHojas
            // 
            this.cboHojas.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHojas.FormattingEnabled = true;
            this.cboHojas.Location = new System.Drawing.Point(169, 79);
            this.cboHojas.Name = "cboHojas";
            this.cboHojas.Size = new System.Drawing.Size(349, 27);
            this.cboHojas.TabIndex = 17;
            // 
            // lblMensajesImportacion
            // 
            this.lblMensajesImportacion.BackColor = System.Drawing.Color.White;
            this.lblMensajesImportacion.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajesImportacion.ForeColor = System.Drawing.Color.Red;
            this.lblMensajesImportacion.Location = new System.Drawing.Point(24, 564);
            this.lblMensajesImportacion.Name = "lblMensajesImportacion";
            this.lblMensajesImportacion.Size = new System.Drawing.Size(557, 20);
            this.lblMensajesImportacion.TabIndex = 35;
            // 
            // tabImportar
            // 
            this.tabImportar.Controls.Add(this.chkTarifa);
            this.tabImportar.Controls.Add(this.cboSedesImp);
            this.tabImportar.Controls.Add(this.label2);
            this.tabImportar.Controls.Add(this.lblMensajesImportacion);
            this.tabImportar.Controls.Add(this.btnSalir);
            this.tabImportar.Controls.Add(this.cboHojas);
            this.tabImportar.Controls.Add(this.label7);
            this.tabImportar.Controls.Add(this.btnBuscar);
            this.tabImportar.Controls.Add(this.btnGuardarRealMO);
            this.tabImportar.Controls.Add(this.txtRuta);
            this.tabImportar.Controls.Add(this.label6);
            this.tabImportar.Controls.Add(this.dgvDatos);
            this.tabImportar.Controls.Add(this.cboCampaña);
            this.tabImportar.Controls.Add(this.label4);
            this.tabImportar.Controls.Add(this.cboPeriodo);
            this.tabImportar.Controls.Add(this.label1);
            this.tabImportar.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabImportar.Location = new System.Drawing.Point(4, 28);
            this.tabImportar.Name = "tabImportar";
            this.tabImportar.Padding = new System.Windows.Forms.Padding(3);
            this.tabImportar.Size = new System.Drawing.Size(863, 591);
            this.tabImportar.TabIndex = 0;
            this.tabImportar.Text = "IMPORTAR";
            this.tabImportar.UseVisualStyleBackColor = true;
            // 
            // chkTarifa
            // 
            this.chkTarifa.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTarifa.Location = new System.Drawing.Point(649, 13);
            this.chkTarifa.Name = "chkTarifa";
            this.chkTarifa.Size = new System.Drawing.Size(271, 31);
            this.chkTarifa.TabIndex = 38;
            this.chkTarifa.Text = "Cargar aun sin Tarifa Plan";
            this.chkTarifa.UseVisualStyleBackColor = true;
            // 
            // cboSedesImp
            // 
            this.cboSedesImp.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSedesImp.FormattingEnabled = true;
            this.cboSedesImp.Location = new System.Drawing.Point(517, 13);
            this.cboSedesImp.Name = "cboSedesImp";
            this.cboSedesImp.Size = new System.Drawing.Size(114, 27);
            this.cboSedesImp.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(454, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 36;
            this.label2.Text = "Sede:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "Seleccione Hoja:";
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvDatos.Location = new System.Drawing.Point(22, 132);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.Size = new System.Drawing.Size(819, 424);
            this.dgvDatos.TabIndex = 11;
            // 
            // cboCampaña
            // 
            this.cboCampaña.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCampaña.FormattingEnabled = true;
            this.cboCampaña.Location = new System.Drawing.Point(100, 13);
            this.cboCampaña.Name = "cboCampaña";
            this.cboCampaña.Size = new System.Drawing.Size(110, 27);
            this.cboCampaña.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Campaña:";
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPeriodo.FormattingEnabled = true;
            this.cboPeriodo.Location = new System.Drawing.Point(316, 13);
            this.cboPeriodo.Name = "cboPeriodo";
            this.cboPeriodo.Size = new System.Drawing.Size(121, 27);
            this.cboPeriodo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Periodo:";
            // 
            // tabControlMO
            // 
            this.tabControlMO.Controls.Add(this.tabImportar);
            this.tabControlMO.Controls.Add(this.tabLog);
            this.tabControlMO.Controls.Add(this.tabExportar);
            this.tabControlMO.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMO.Location = new System.Drawing.Point(12, 12);
            this.tabControlMO.Name = "tabControlMO";
            this.tabControlMO.SelectedIndex = 0;
            this.tabControlMO.Size = new System.Drawing.Size(871, 623);
            this.tabControlMO.TabIndex = 3;
            this.tabControlMO.SelectedIndexChanged += new System.EventHandler(this.tabControlMO_SelectedIndexChanged);
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.dgvLogs);
            this.tabLog.Controls.Add(this.btnReprocesar);
            this.tabLog.Controls.Add(this.lblMensajesLog);
            this.tabLog.Controls.Add(this.btnSeleccionFolder);
            this.tabLog.Controls.Add(this.txtRutaLog);
            this.tabLog.Controls.Add(this.label3);
            this.tabLog.Controls.Add(this.btnExportar);
            this.tabLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabLog.Location = new System.Drawing.Point(4, 28);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(863, 591);
            this.tabLog.TabIndex = 1;
            this.tabLog.Text = "LOG CARGA";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // dgvLogs
            // 
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLogs.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvLogs.Location = new System.Drawing.Point(22, 132);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.Size = new System.Drawing.Size(819, 433);
            this.dgvLogs.TabIndex = 38;
            // 
            // lblMensajesLog
            // 
            this.lblMensajesLog.BackColor = System.Drawing.Color.White;
            this.lblMensajesLog.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajesLog.ForeColor = System.Drawing.Color.Red;
            this.lblMensajesLog.Location = new System.Drawing.Point(23, 568);
            this.lblMensajesLog.Name = "lblMensajesLog";
            this.lblMensajesLog.Size = new System.Drawing.Size(557, 20);
            this.lblMensajesLog.TabIndex = 36;
            // 
            // btnSeleccionFolder
            // 
            this.btnSeleccionFolder.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionFolder.Location = new System.Drawing.Point(697, 21);
            this.btnSeleccionFolder.Name = "btnSeleccionFolder";
            this.btnSeleccionFolder.Size = new System.Drawing.Size(37, 28);
            this.btnSeleccionFolder.TabIndex = 18;
            this.btnSeleccionFolder.Text = "...";
            this.btnSeleccionFolder.UseVisualStyleBackColor = true;
            this.btnSeleccionFolder.Click += new System.EventHandler(this.btnSeleccionFolder_Click);
            // 
            // FRM_MO_REAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 689);
            this.Controls.Add(this.grpPasos);
            this.Controls.Add(this.tabControlMO);
            this.Name = "FRM_MO_REAL";
            this.Text = "Gestión de Gastos Reales de Mano de Obra";
            this.Load += new System.EventHandler(this.FRM_MO_REAL_Load);
            this.Resize += new System.EventHandler(this.FRM_MO_REAL_Resize);
            this.tabExportar.ResumeLayout(false);
            this.tabExportar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataExportar)).EndInit();
            this.grpPasos.ResumeLayout(false);
            this.grpPasos.PerformLayout();
            this.tabImportar.ResumeLayout(false);
            this.tabImportar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.tabControlMO.ResumeLayout(false);
            this.tabLog.ResumeLayout(false);
            this.tabLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRutaLog;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.TabPage tabExportar;
        private System.Windows.Forms.Label lblMensajesExportacion;
        private System.Windows.Forms.DataGridView dgvDataExportar;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Button btnSeleccionarFolderExp;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.TextBox txtRutaExcel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboCampañaExp;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboSedesExp;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboPeriodoExp;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox grpPasos;
        private System.Windows.Forms.Label lblFC;
        private System.Windows.Forms.Label lblPC;
        private System.Windows.Forms.Label lblFV;
        private System.Windows.Forms.Label lblPV;
        private System.Windows.Forms.Label lblFE;
        private System.Windows.Forms.Label lblPE;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReprocesar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnGuardarRealMO;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox cboHojas;
        private System.Windows.Forms.Label lblMensajesImportacion;
        private System.Windows.Forms.TabPage tabImportar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.ComboBox cboCampaña;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboPeriodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControlMO;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.Label lblMensajesLog;
        private System.Windows.Forms.Button btnSeleccionFolder;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.ComboBox cboSedesImp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkTarifa;
    }
}