namespace THITRACNGHIEM
{
    partial class Thi
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
            this.components = new System.ComponentModel.Container();
            this.panelThongtin = new DevExpress.XtraEditors.PanelControl();
            this.button1 = new System.Windows.Forms.Button();
            this.lblConLai = new System.Windows.Forms.Label();
            this.txtConLai = new System.Windows.Forms.TextBox();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.txtThoiGian = new System.Windows.Forms.TextBox();
            this.txtLop = new System.Windows.Forms.TextBox();
            this.lblMaLop = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.ngaySinh = new DevExpress.XtraEditors.DateEdit();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.panelDieuHuong = new DevExpress.XtraEditors.PanelControl();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.panelCauHoi = new DevExpress.XtraEditors.PanelControl();
            this.radioD = new System.Windows.Forms.RadioButton();
            this.radioC = new System.Windows.Forms.RadioButton();
            this.radioB = new System.Windows.Forms.RadioButton();
            this.radioA = new System.Windows.Forms.RadioButton();
            this.labelSoCau = new System.Windows.Forms.Label();
            this.labelCau = new System.Windows.Forms.Label();
            this.txtD = new DevExpress.XtraEditors.TextEdit();
            this.txtC = new DevExpress.XtraEditors.TextEdit();
            this.txtB = new DevExpress.XtraEditors.TextEdit();
            this.txtA = new DevExpress.XtraEditors.TextEdit();
            this.txtNoiDung = new DevExpress.XtraEditors.TextEdit();
            this.lvLuaChon = new System.Windows.Forms.ListView();
            this.colCau = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bdsCauHoi = new System.Windows.Forms.BindingSource(this.components);
            this.DS_THI = new THITRACNGHIEM.DS_THI();
            this.SP_LAYCAUHOITHITableAdapter = new THITRACNGHIEM.DS_THITableAdapters.SP_LAYCAUHOITHITableAdapter();
            this.tableAdapterManager = new THITRACNGHIEM.DS_THITableAdapters.TableAdapterManager();
            this.bdsPhucHoiCauHoi = new System.Windows.Forms.BindingSource(this.components);
            this.SP_PHUCHOICAUHOITHITableAdapter = new THITRACNGHIEM.DS_THITableAdapters.SP_PHUCHOICAUHOITHITableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.panelThongtin)).BeginInit();
            this.panelThongtin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ngaySinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngaySinh.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDieuHuong)).BeginInit();
            this.panelDieuHuong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelCauHoi)).BeginInit();
            this.panelCauHoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCauHoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_THI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPhucHoiCauHoi)).BeginInit();
            this.SuspendLayout();
            // 
            // panelThongtin
            // 
            this.panelThongtin.Controls.Add(this.button1);
            this.panelThongtin.Controls.Add(this.lblConLai);
            this.panelThongtin.Controls.Add(this.txtConLai);
            this.panelThongtin.Controls.Add(this.lblThoiGian);
            this.panelThongtin.Controls.Add(this.txtThoiGian);
            this.panelThongtin.Controls.Add(this.txtLop);
            this.panelThongtin.Controls.Add(this.lblMaLop);
            this.panelThongtin.Controls.Add(this.txtHoTen);
            this.panelThongtin.Controls.Add(this.lblHoTen);
            this.panelThongtin.Controls.Add(this.ngaySinh);
            this.panelThongtin.Controls.Add(this.lblNgaySinh);
            this.panelThongtin.Controls.Add(this.txtMaSV);
            this.panelThongtin.Controls.Add(this.lblMaSV);
            this.panelThongtin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelThongtin.Location = new System.Drawing.Point(0, 0);
            this.panelThongtin.Name = "panelThongtin";
            this.panelThongtin.Size = new System.Drawing.Size(1924, 124);
            this.panelThongtin.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1586, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Nộp bài";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnNopBai_Click);
            // 
            // lblConLai
            // 
            this.lblConLai.AutoSize = true;
            this.lblConLai.Location = new System.Drawing.Point(1082, 83);
            this.lblConLai.Name = "lblConLai";
            this.lblConLai.Size = new System.Drawing.Size(51, 16);
            this.lblConLai.TabIndex = 12;
            this.lblConLai.Text = "Còn lại:";
            // 
            // txtConLai
            // 
            this.txtConLai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConLai.Enabled = false;
            this.txtConLai.Location = new System.Drawing.Point(1193, 76);
            this.txtConLai.Name = "txtConLai";
            this.txtConLai.Size = new System.Drawing.Size(100, 23);
            this.txtConLai.TabIndex = 11;
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Location = new System.Drawing.Point(1068, 44);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(65, 16);
            this.lblThoiGian.TabIndex = 10;
            this.lblThoiGian.Text = "Thời gian:";
            // 
            // txtThoiGian
            // 
            this.txtThoiGian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThoiGian.Enabled = false;
            this.txtThoiGian.Location = new System.Drawing.Point(1191, 41);
            this.txtThoiGian.Name = "txtThoiGian";
            this.txtThoiGian.Size = new System.Drawing.Size(100, 23);
            this.txtThoiGian.TabIndex = 9;
            // 
            // txtLop
            // 
            this.txtLop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLop.Enabled = false;
            this.txtLop.Location = new System.Drawing.Point(676, 73);
            this.txtLop.Name = "txtLop";
            this.txtLop.Size = new System.Drawing.Size(178, 23);
            this.txtLop.TabIndex = 8;
            // 
            // lblMaLop
            // 
            this.lblMaLop.AutoSize = true;
            this.lblMaLop.Location = new System.Drawing.Point(535, 76);
            this.lblMaLop.Name = "lblMaLop";
            this.lblMaLop.Size = new System.Drawing.Size(27, 16);
            this.lblMaLop.TabIndex = 7;
            this.lblMaLop.Text = "Lớp";
            // 
            // txtHoTen
            // 
            this.txtHoTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoTen.Enabled = false;
            this.txtHoTen.Location = new System.Drawing.Point(677, 37);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(178, 23);
            this.txtHoTen.TabIndex = 6;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(535, 40);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(66, 16);
            this.lblHoTen.TabIndex = 5;
            this.lblHoTen.Text = "Họ và tên:";
            // 
            // ngaySinh
            // 
            this.ngaySinh.EditValue = null;
            this.ngaySinh.Enabled = false;
            this.ngaySinh.Location = new System.Drawing.Point(238, 70);
            this.ngaySinh.Name = "ngaySinh";
            this.ngaySinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngaySinh.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ngaySinh.Size = new System.Drawing.Size(178, 22);
            this.ngaySinh.TabIndex = 4;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(93, 70);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(69, 16);
            this.lblNgaySinh.TabIndex = 3;
            this.lblNgaySinh.Text = "Ngày Sinh:";
            // 
            // txtMaSV
            // 
            this.txtMaSV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaSV.Enabled = false;
            this.txtMaSV.Location = new System.Drawing.Point(239, 33);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(178, 23);
            this.txtMaSV.TabIndex = 1;
            // 
            // lblMaSV
            // 
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Location = new System.Drawing.Point(93, 36);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Size = new System.Drawing.Size(83, 16);
            this.lblMaSV.TabIndex = 0;
            this.lblMaSV.Text = "Mã sinh viên:";
            // 
            // panelDieuHuong
            // 
            this.panelDieuHuong.Controls.Add(this.btnNext);
            this.panelDieuHuong.Controls.Add(this.btnPrevious);
            this.panelDieuHuong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDieuHuong.Location = new System.Drawing.Point(0, 763);
            this.panelDieuHuong.Name = "panelDieuHuong";
            this.panelDieuHuong.Size = new System.Drawing.Size(1924, 100);
            this.panelDieuHuong.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(970, 44);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(127, 44);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "Tiếp";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(539, 44);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(128, 43);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "Trước";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // panelCauHoi
            // 
            this.panelCauHoi.Controls.Add(this.radioD);
            this.panelCauHoi.Controls.Add(this.radioC);
            this.panelCauHoi.Controls.Add(this.radioB);
            this.panelCauHoi.Controls.Add(this.radioA);
            this.panelCauHoi.Controls.Add(this.labelSoCau);
            this.panelCauHoi.Controls.Add(this.labelCau);
            this.panelCauHoi.Controls.Add(this.txtD);
            this.panelCauHoi.Controls.Add(this.txtC);
            this.panelCauHoi.Controls.Add(this.txtB);
            this.panelCauHoi.Controls.Add(this.txtA);
            this.panelCauHoi.Controls.Add(this.txtNoiDung);
            this.panelCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCauHoi.Location = new System.Drawing.Point(0, 124);
            this.panelCauHoi.Name = "panelCauHoi";
            this.panelCauHoi.Size = new System.Drawing.Size(1924, 639);
            this.panelCauHoi.TabIndex = 3;
            // 
            // radioD
            // 
            this.radioD.AutoSize = true;
            this.radioD.Location = new System.Drawing.Point(208, 557);
            this.radioD.Name = "radioD";
            this.radioD.Size = new System.Drawing.Size(36, 20);
            this.radioD.TabIndex = 15;
            this.radioD.TabStop = true;
            this.radioD.Text = "D";
            this.radioD.UseVisualStyleBackColor = true;
            this.radioD.Click += new System.EventHandler(this.RadioButtonClick);
            // 
            // radioC
            // 
            this.radioC.AutoSize = true;
            this.radioC.Location = new System.Drawing.Point(208, 473);
            this.radioC.Name = "radioC";
            this.radioC.Size = new System.Drawing.Size(36, 20);
            this.radioC.TabIndex = 14;
            this.radioC.TabStop = true;
            this.radioC.Text = "C";
            this.radioC.UseVisualStyleBackColor = true;
            this.radioC.Click += new System.EventHandler(this.RadioButtonClick);
            // 
            // radioB
            // 
            this.radioB.AutoSize = true;
            this.radioB.Location = new System.Drawing.Point(210, 385);
            this.radioB.Name = "radioB";
            this.radioB.Size = new System.Drawing.Size(35, 20);
            this.radioB.TabIndex = 13;
            this.radioB.TabStop = true;
            this.radioB.Text = "B";
            this.radioB.UseVisualStyleBackColor = true;
            this.radioB.Click += new System.EventHandler(this.RadioButtonClick);
            // 
            // radioA
            // 
            this.radioA.AutoSize = true;
            this.radioA.Location = new System.Drawing.Point(211, 299);
            this.radioA.Name = "radioA";
            this.radioA.Size = new System.Drawing.Size(36, 20);
            this.radioA.TabIndex = 12;
            this.radioA.TabStop = true;
            this.radioA.Text = "A";
            this.radioA.UseVisualStyleBackColor = true;
            this.radioA.Click += new System.EventHandler(this.RadioButtonClick);
            // 
            // labelSoCau
            // 
            this.labelSoCau.AutoSize = true;
            this.labelSoCau.Location = new System.Drawing.Point(209, 181);
            this.labelSoCau.Name = "labelSoCau";
            this.labelSoCau.Size = new System.Drawing.Size(33, 16);
            this.labelSoCau.TabIndex = 11;
            this.labelSoCau.Text = "100:";
            // 
            // labelCau
            // 
            this.labelCau.AutoSize = true;
            this.labelCau.Location = new System.Drawing.Point(165, 181);
            this.labelCau.Name = "labelCau";
            this.labelCau.Size = new System.Drawing.Size(29, 16);
            this.labelCau.TabIndex = 10;
            this.labelCau.Text = "Câu";
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(304, 558);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(1288, 22);
            this.txtD.TabIndex = 9;
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(304, 467);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(1288, 22);
            this.txtC.TabIndex = 7;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(304, 379);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(1306, 22);
            this.txtB.TabIndex = 5;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(304, 298);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(1306, 22);
            this.txtA.TabIndex = 3;
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsCauHoi, "NOIDUNG", true));
            this.txtNoiDung.Location = new System.Drawing.Point(304, 176);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(1306, 22);
            this.txtNoiDung.TabIndex = 1;
            // 
            // lvLuaChon
            // 
            this.lvLuaChon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCau,
            this.colA,
            this.colB,
            this.colC,
            this.colD});
            this.lvLuaChon.Dock = System.Windows.Forms.DockStyle.Right;
            this.lvLuaChon.GridLines = true;
            this.lvLuaChon.HideSelection = false;
            this.lvLuaChon.Location = new System.Drawing.Point(1616, 124);
            this.lvLuaChon.Name = "lvLuaChon";
            this.lvLuaChon.Size = new System.Drawing.Size(308, 639);
            this.lvLuaChon.TabIndex = 4;
            this.lvLuaChon.UseCompatibleStateImageBehavior = false;
            this.lvLuaChon.View = System.Windows.Forms.View.Details;
            // 
            // colCau
            // 
            this.colCau.Text = "Câu";
            // 
            // colA
            // 
            this.colA.Text = "A";
            // 
            // colB
            // 
            this.colB.Text = "B";
            // 
            // colC
            // 
            this.colC.Text = "C";
            // 
            // colD
            // 
            this.colD.Text = "D";
            // 
            // bdsCauHoi
            // 
            this.bdsCauHoi.DataMember = "SP_LAYCAUHOITHI";
            this.bdsCauHoi.DataSource = this.DS_THI;
            // 
            // DS_THI
            // 
            this.DS_THI.DataSetName = "DS_THI";
            this.DS_THI.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_LAYCAUHOITHITableAdapter
            // 
            this.SP_LAYCAUHOITHITableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = THITRACNGHIEM.DS_THITableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // bdsPhucHoiCauHoi
            // 
            this.bdsPhucHoiCauHoi.DataMember = "SP_PHUCHOICAUHOITHI";
            this.bdsPhucHoiCauHoi.DataSource = this.DS_THI;
            // 
            // SP_PHUCHOICAUHOITHITableAdapter
            // 
            this.SP_PHUCHOICAUHOITHITableAdapter.ClearBeforeFill = true;
            // 
            // Thi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 863);
            this.Controls.Add(this.lvLuaChon);
            this.Controls.Add(this.panelCauHoi);
            this.Controls.Add(this.panelDieuHuong);
            this.Controls.Add(this.panelThongtin);
            this.Name = "Thi";
            this.Text = "Thi";
            ((System.ComponentModel.ISupportInitialize)(this.panelThongtin)).EndInit();
            this.panelThongtin.ResumeLayout(false);
            this.panelThongtin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ngaySinh.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ngaySinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelDieuHuong)).EndInit();
            this.panelDieuHuong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelCauHoi)).EndInit();
            this.panelCauHoi.ResumeLayout(false);
            this.panelCauHoi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCauHoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS_THI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsPhucHoiCauHoi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelThongtin;
        private DevExpress.XtraEditors.PanelControl panelDieuHuong;
        private DevExpress.XtraEditors.PanelControl panelCauHoi;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.TextBox txtMaSV;
        private DevExpress.XtraEditors.DateEdit ngaySinh;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtLop;
        private System.Windows.Forms.Label lblMaLop;
        private System.Windows.Forms.ListView lvLuaChon;
        private System.Windows.Forms.ColumnHeader colCau;
        private System.Windows.Forms.ColumnHeader colA;
        private System.Windows.Forms.ColumnHeader colB;
        private System.Windows.Forms.ColumnHeader colC;
        private System.Windows.Forms.ColumnHeader colD;
        private System.Windows.Forms.TextBox txtThoiGian;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Label lblConLai;
        private System.Windows.Forms.TextBox txtConLai;
        private DS_THI DS_THI;
        private System.Windows.Forms.BindingSource bdsCauHoi;
        private DS_THITableAdapters.SP_LAYCAUHOITHITableAdapter SP_LAYCAUHOITHITableAdapter;
        private DS_THITableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraEditors.TextEdit txtD;
        private DevExpress.XtraEditors.TextEdit txtC;
        private DevExpress.XtraEditors.TextEdit txtB;
        private DevExpress.XtraEditors.TextEdit txtA;
        private DevExpress.XtraEditors.TextEdit txtNoiDung;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label labelSoCau;
        private System.Windows.Forms.Label labelCau;
        private System.Windows.Forms.RadioButton radioD;
        private System.Windows.Forms.RadioButton radioC;
        private System.Windows.Forms.RadioButton radioB;
        private System.Windows.Forms.RadioButton radioA;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bdsPhucHoiCauHoi;
        private DS_THITableAdapters.SP_PHUCHOICAUHOITHITableAdapter SP_PHUCHOICAUHOITHITableAdapter;
    }
}