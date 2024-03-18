namespace WindowsFormsApp1
{
    partial class formDangNhap
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
            this.inputTK = new DevExpress.XtraEditors.TextEdit();
            this.inputMK = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDangNhap = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.cmbCoSo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.inputTK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputMK.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // inputTK
            // 
            this.inputTK.Location = new System.Drawing.Point(301, 202);
            this.inputTK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputTK.Name = "inputTK";
            this.inputTK.Size = new System.Drawing.Size(271, 22);
            this.inputTK.TabIndex = 1;
         
            // 
            // inputMK
            // 
            this.inputMK.Location = new System.Drawing.Point(301, 260);
            this.inputMK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputMK.Name = "inputMK";
            this.inputMK.Properties.PasswordChar = '*';
            this.inputMK.Size = new System.Drawing.Size(271, 22);
            this.inputMK.TabIndex = 2;
          
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cơ sở";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tài Khoảng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mật khẩu";
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(275, 369);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(107, 30);
            this.btnDangNhap.TabIndex = 6;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(451, 369);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(107, 30);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // cmbCoSo
            // 
            this.cmbCoSo.FormattingEnabled = true;
            this.cmbCoSo.Location = new System.Drawing.Point(301, 129);
            this.cmbCoSo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCoSo.Name = "cmbCoSo";
            this.cmbCoSo.Size = new System.Drawing.Size(269, 24);
            this.cmbCoSo.TabIndex = 8;
         
            // 
            // formDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 718);
            this.Controls.Add(this.cmbCoSo);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputMK);
            this.Controls.Add(this.inputTK);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "formDangNhap";
            this.Text = "formDangNhap";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.formDangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputTK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputMK.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit inputTK;
        private DevExpress.XtraEditors.TextEdit inputMK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnDangNhap;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private System.Windows.Forms.ComboBox cmbCoSo;
        private formMain parentForm;
    }
}