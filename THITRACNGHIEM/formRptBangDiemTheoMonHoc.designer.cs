namespace THITRACNGHIEM
{
    partial class formRptBangDiemTheoMonHoc
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
            System.Windows.Forms.Label tENMHLabel;
            System.Windows.Forms.Label tenlopLabel;
            this.cmbLanThi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.dSBangDiemTheoMon = new THITRACNGHIEM.DSBangDiemTheoMon();
            this.bdsLop = new System.Windows.Forms.BindingSource(this.components);
            this.LOPTableAdapter = new THITRACNGHIEM.DSBangDiemTheoMonTableAdapters.LOPTableAdapter();
            this.tableAdapterManager = new THITRACNGHIEM.DSBangDiemTheoMonTableAdapters.TableAdapterManager();
            this.bdsMH = new System.Windows.Forms.BindingSource(this.components);
            this.MONHOCTableAdapter = new THITRACNGHIEM.DSBangDiemTheoMonTableAdapters.MONHOCTableAdapter();
            this.cmbLop = new System.Windows.Forms.ComboBox();
            this.cmbMH = new System.Windows.Forms.ComboBox();
            tENMHLabel = new System.Windows.Forms.Label();
            tenlopLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dSBangDiemTheoMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMH)).BeginInit();
            this.SuspendLayout();
            // 
            // tENMHLabel
            // 
            tENMHLabel.AutoSize = true;
            tENMHLabel.Location = new System.Drawing.Point(109, 185);
            tENMHLabel.Name = "tENMHLabel";
            tENMHLabel.Size = new System.Drawing.Size(105, 20);
            tENMHLabel.TabIndex = 1;
            tENMHLabel.Text = "Tên môn học:";
            // 
            // tenlopLabel
            // 
            tenlopLabel.AutoSize = true;
            tenlopLabel.Location = new System.Drawing.Point(536, 185);
            tenlopLabel.Name = "tenlopLabel";
            tenlopLabel.Size = new System.Drawing.Size(65, 20);
            tenlopLabel.TabIndex = 2;
            tenlopLabel.Text = "Tên lớp:";
            // 
            // cmbLanThi
            // 
            this.cmbLanThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanThi.FormattingEnabled = true;
            this.cmbLanThi.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbLanThi.Location = new System.Drawing.Point(996, 182);
            this.cmbLanThi.Name = "cmbLanThi";
            this.cmbLanThi.Size = new System.Drawing.Size(121, 28);
            this.cmbLanThi.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(933, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Lần thi";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(1198, 182);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(112, 28);
            this.btnPreview.TabIndex = 6;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // dSBangDiemTheoMon
            // 
            this.dSBangDiemTheoMon.DataSetName = "DSBangDiemTheoMon";
            this.dSBangDiemTheoMon.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsLop
            // 
            this.bdsLop.DataMember = "LOP";
            this.bdsLop.DataSource = this.dSBangDiemTheoMon;
            // 
            // LOPTableAdapter
            // 
            this.LOPTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = THITRACNGHIEM.DSBangDiemTheoMonTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // bdsMH
            // 
            this.bdsMH.DataMember = "MONHOC";
            this.bdsMH.DataSource = this.dSBangDiemTheoMon;
            // 
            // MONHOCTableAdapter
            // 
            this.MONHOCTableAdapter.ClearBeforeFill = true;
            // 
            // cmbLop
            // 
            this.cmbLop.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsLop, "MAKH", true));
            this.cmbLop.DataSource = this.bdsLop;
            this.cmbLop.DisplayMember = "TENLOP";
            this.cmbLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLop.Location = new System.Drawing.Point(607, 182);
            this.cmbLop.Name = "cmbLop";
            this.cmbLop.Size = new System.Drawing.Size(220, 28);
            this.cmbLop.TabIndex = 7;
            this.cmbLop.ValueMember = "MALOP";
            // 
            // cmbMH
            // 
            this.cmbMH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bdsMH, "MAMH", true));
            this.cmbMH.DataSource = this.bdsMH;
            this.cmbMH.DisplayMember = "TENMH";
            this.cmbMH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMH.Location = new System.Drawing.Point(220, 182);
            this.cmbMH.Name = "cmbMH";
            this.cmbMH.Size = new System.Drawing.Size(219, 28);
            this.cmbMH.TabIndex = 8;
            this.cmbMH.ValueMember = "MAMH";
            // 
            // formRptBangDiemTheoMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 365);
            this.Controls.Add(this.cmbMH);
            this.Controls.Add(this.cmbLop);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbLanThi);
            this.Controls.Add(tenlopLabel);
            this.Controls.Add(tENMHLabel);
            this.Name = "formRptBangDiemTheoMonHoc";
            this.Text = "formRptBangDiemTheoMonHoc";
            this.Load += new System.EventHandler(this.formRptBangDiemTheoMonHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSBangDiemTheoMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsMH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbLanThi;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DSBangDiemTheoMon dSBangDiemTheoMon;
        private System.Windows.Forms.BindingSource bdsLop;
        private DSBangDiemTheoMonTableAdapters.LOPTableAdapter LOPTableAdapter;
        private DSBangDiemTheoMonTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource bdsMH;
        private DSBangDiemTheoMonTableAdapters.MONHOCTableAdapter MONHOCTableAdapter;
        private System.Windows.Forms.ComboBox cmbLop;
        private System.Windows.Forms.ComboBox cmbMH;
    }
}