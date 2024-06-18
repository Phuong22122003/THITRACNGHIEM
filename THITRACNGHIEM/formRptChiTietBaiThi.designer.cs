namespace THITRACNGHIEM
{
    partial class formRptChiTietBaiThi
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
            System.Windows.Forms.Label hotenLabel1;
            System.Windows.Forms.Label malopLabel;
            this.cmbCoSo = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dSChiTietBaiThi = new THITRACNGHIEM.DSChiTietBaiThi();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cmbLanThi = new System.Windows.Forms.ComboBox();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.bdsLop = new System.Windows.Forms.BindingSource(this.components);
            this.LOPTableAdapter = new THITRACNGHIEM.DSChiTietBaiThiTableAdapters.LOPTableAdapter();
            this.tableAdapterManager = new THITRACNGHIEM.DSChiTietBaiThiTableAdapters.TableAdapterManager();
            this.SINHVIENTableAdapter = new THITRACNGHIEM.DSChiTietBaiThiTableAdapters.SINHVIENTableAdapter();
            this.cmbLop = new System.Windows.Forms.ComboBox();
            this.bdsSV = new System.Windows.Forms.BindingSource(this.components);
            this.cmbMaSV = new System.Windows.Forms.ComboBox();
            this.dSMonHoc = new THITRACNGHIEM.DSMonHoc();
            this.bdsMH = new System.Windows.Forms.BindingSource(this.components);
            this.MONHOCTableAdapter = new THITRACNGHIEM.DSChiTietBaiThiTableAdapters.MONHOCTableAdapter();
            this.cmbMaMH = new System.Windows.Forms.ComboBox();
            hotenLabel1 = new System.Windows.Forms.Label();
            malopLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSChiTietBaiThi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSMonHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMH)).BeginInit();
            this.SuspendLayout();
            // 
            // hotenLabel1
            // 
            hotenLabel1.AutoSize = true;
            hotenLabel1.Location = new System.Drawing.Point(503, 153);
            hotenLabel1.Name = "hotenLabel1";
            hotenLabel1.Size = new System.Drawing.Size(61, 20);
            hotenLabel1.TabIndex = 16;
            hotenLabel1.Text = "Họ tên:";
            // 
            // malopLabel
            // 
            malopLabel.AutoSize = true;
            malopLabel.Location = new System.Drawing.Point(97, 153);
            malopLabel.Name = "malopLabel";
            malopLabel.Size = new System.Drawing.Size(69, 20);
            malopLabel.TabIndex = 19;
            malopLabel.Text = "Tên lớp: ";
            malopLabel.Click += new System.EventHandler(this.malopLabel_Click);
            // 
            // cmbCoSo
            // 
            this.cmbCoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoSo.FormattingEnabled = true;
            this.cmbCoSo.Location = new System.Drawing.Point(162, 55);
            this.cmbCoSo.Name = "cmbCoSo";
            this.cmbCoSo.Size = new System.Drawing.Size(563, 28);
            this.cmbCoSo.TabIndex = 3;
            this.cmbCoSo.SelectedIndexChanged += new System.EventHandler(this.cmbCoSo_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(101, 58);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 19);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Cơ Sở";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(89, 280);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(66, 19);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Môn học:";
            // 
            // dSChiTietBaiThi
            // 
            this.dSChiTietBaiThi.DataSetName = "DSChiTietBaiThi";
            this.dSChiTietBaiThi.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(510, 283);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(54, 19);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Lần thi:";
            // 
            // cmbLanThi
            // 
            this.cmbLanThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanThi.FormattingEnabled = true;
            this.cmbLanThi.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbLanThi.Location = new System.Drawing.Point(601, 274);
            this.cmbLanThi.Name = "cmbLanThi";
            this.cmbLanThi.Size = new System.Drawing.Size(282, 28);
            this.cmbLanThi.TabIndex = 11;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(961, 275);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(112, 28);
            this.btnPreview.TabIndex = 14;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // bdsLop
            // 
            this.bdsLop.DataMember = "LOP";
            this.bdsLop.DataSource = this.dSChiTietBaiThi;
            // 
            // LOPTableAdapter
            // 
            this.LOPTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = THITRACNGHIEM.DSChiTietBaiThiTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // SINHVIENTableAdapter
            // 
            this.SINHVIENTableAdapter.ClearBeforeFill = true;
            // 
            // cmbLop
            // 
            this.cmbLop.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLop.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLop.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsLop, "malop", true));
            this.cmbLop.DataSource = this.bdsLop;
            this.cmbLop.DisplayMember = "tenlop";
            this.cmbLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLop.Location = new System.Drawing.Point(172, 150);
            this.cmbLop.Name = "cmbLop";
            this.cmbLop.Size = new System.Drawing.Size(282, 28);
            this.cmbLop.TabIndex = 21;
            this.cmbLop.ValueMember = "MALOP";
            this.cmbLop.SelectedIndexChanged += new System.EventHandler(this.malopComboBox_SelectedIndexChanged);
            // 
            // bdsSV
            // 
            this.bdsSV.DataMember = "FK_SINHVIEN_LOP";
            this.bdsSV.DataSource = this.bdsLop;
            // 
            // cmbMaSV
            // 
            this.cmbMaSV.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsSV, "masv", true));
            this.cmbMaSV.DataSource = this.bdsSV;
            this.cmbMaSV.DisplayMember = "hoten";
            this.cmbMaSV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaSV.Location = new System.Drawing.Point(601, 150);
            this.cmbMaSV.Name = "cmbMaSV";
            this.cmbMaSV.Size = new System.Drawing.Size(282, 28);
            this.cmbMaSV.TabIndex = 22;
            this.cmbMaSV.ValueMember = "masv";
            // 
            // dSMonHoc
            // 
            this.dSMonHoc.DataSetName = "DSMonHoc";
            this.dSMonHoc.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsMH
            // 
            this.bdsMH.DataMember = "MONHOC";
            this.bdsMH.DataSource = this.dSChiTietBaiThi;
            // 
            // MONHOCTableAdapter
            // 
            this.MONHOCTableAdapter.ClearBeforeFill = true;
            // 
            // cmbMaMH
            // 
            this.cmbMaMH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaMH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaMH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsMH, "mamh", true));
            this.cmbMaMH.DataSource = this.bdsMH;
            this.cmbMaMH.DisplayMember = "tenmh";
            this.cmbMaMH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaMH.Location = new System.Drawing.Point(173, 277);
            this.cmbMaMH.Name = "cmbMaMH";
            this.cmbMaMH.Size = new System.Drawing.Size(281, 28);
            this.cmbMaMH.TabIndex = 23;
            this.cmbMaMH.ValueMember = "mamh";
            // 
            // formRptChiTietBaiThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1588, 452);
            this.Controls.Add(this.cmbMaMH);
            this.Controls.Add(this.cmbMaSV);
            this.Controls.Add(this.cmbLop);
            this.Controls.Add(malopLabel);
            this.Controls.Add(hotenLabel1);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.cmbLanThi);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cmbCoSo);
            this.Controls.Add(this.labelControl1);
            this.Name = "formRptChiTietBaiThi";
            this.Text = "formRptChiTietBaiThi";
            this.Load += new System.EventHandler(this.formRptChiTietBaiThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSChiTietBaiThi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsSV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSMonHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCoSo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DSChiTietBaiThi dSChiTietBaiThi;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ComboBox cmbLanThi;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private System.Windows.Forms.BindingSource bdsLop;
        private DSChiTietBaiThiTableAdapters.LOPTableAdapter LOPTableAdapter;
        private DSChiTietBaiThiTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ComboBox cmbLop;
        private DSChiTietBaiThiTableAdapters.SINHVIENTableAdapter SINHVIENTableAdapter;
        private System.Windows.Forms.BindingSource bdsSV;
        private System.Windows.Forms.ComboBox cmbMaSV;
        private DSMonHoc dSMonHoc;
        private System.Windows.Forms.BindingSource bdsMH;
        private DSChiTietBaiThiTableAdapters.MONHOCTableAdapter MONHOCTableAdapter;
        private System.Windows.Forms.ComboBox cmbMaMH;
    }
}