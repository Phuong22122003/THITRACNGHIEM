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
            this.radioGiaoVien = new System.Windows.Forms.RadioButton();
            this.radioSinhVien = new System.Windows.Forms.RadioButton();
            this.lblErrorLoginName = new System.Windows.Forms.Label();
            this.lblErrorPassword = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inputTK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputMK.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // inputTK
            // 
            this.inputTK.Location = new System.Drawing.Point(958, 334);
            this.inputTK.Margin = new System.Windows.Forms.Padding(9, 6, 9, 6);
            this.inputTK.Name = "inputTK";
            this.inputTK.Size = new System.Drawing.Size(356, 26);
            this.inputTK.TabIndex = 1;
            // 
            // inputMK
            // 
            this.inputMK.Location = new System.Drawing.Point(958, 476);
            this.inputMK.Margin = new System.Windows.Forms.Padding(9, 6, 9, 6);
            this.inputMK.Name = "inputMK";
            this.inputMK.Properties.PasswordChar = '*';
            this.inputMK.Size = new System.Drawing.Size(356, 26);
            this.inputMK.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(821, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cơ sở";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(821, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tài Khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(821, 484);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mật khẩu";
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(899, 679);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(9, 6, 9, 6);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(170, 52);
            this.btnDangNhap.TabIndex = 6;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(1216, 679);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(9, 6, 9, 6);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(177, 52);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // cmbCoSo
            // 
            this.cmbCoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoSo.FormattingEnabled = true;
            this.cmbCoSo.Location = new System.Drawing.Point(958, 185);
            this.cmbCoSo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbCoSo.Name = "cmbCoSo";
            this.cmbCoSo.Size = new System.Drawing.Size(355, 28);
            this.cmbCoSo.TabIndex = 8;
            // 
            // radioGiaoVien
            // 
            this.radioGiaoVien.AutoSize = true;
            this.radioGiaoVien.Checked = true;
            this.radioGiaoVien.Location = new System.Drawing.Point(972, 579);
            this.radioGiaoVien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioGiaoVien.Name = "radioGiaoVien";
            this.radioGiaoVien.Size = new System.Drawing.Size(100, 24);
            this.radioGiaoVien.TabIndex = 9;
            this.radioGiaoVien.TabStop = true;
            this.radioGiaoVien.Text = "Giáo viên";
            this.radioGiaoVien.UseVisualStyleBackColor = true;
            // 
            // radioSinhVien
            // 
            this.radioSinhVien.AutoSize = true;
            this.radioSinhVien.Location = new System.Drawing.Point(1216, 579);
            this.radioSinhVien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioSinhVien.Name = "radioSinhVien";
            this.radioSinhVien.Size = new System.Drawing.Size(102, 24);
            this.radioSinhVien.TabIndex = 10;
            this.radioSinhVien.Text = "Sinh Viên";
            this.radioSinhVien.UseVisualStyleBackColor = true;
            // 
            // lblErrorLoginName
            // 
            this.lblErrorLoginName.AutoSize = true;
            this.lblErrorLoginName.ForeColor = System.Drawing.Color.Red;
            this.lblErrorLoginName.Location = new System.Drawing.Point(1047, 281);
            this.lblErrorLoginName.Name = "lblErrorLoginName";
            this.lblErrorLoginName.Size = new System.Drawing.Size(202, 20);
            this.lblErrorLoginName.TabIndex = 11;
            this.lblErrorLoginName.Text = "Vui lòng nhập tên tài khoản";
            this.lblErrorLoginName.Visible = false;
            // 
            // lblErrorPassword
            // 
            this.lblErrorPassword.AutoSize = true;
            this.lblErrorPassword.ForeColor = System.Drawing.Color.Red;
            this.lblErrorPassword.Location = new System.Drawing.Point(1047, 425);
            this.lblErrorPassword.Name = "lblErrorPassword";
            this.lblErrorPassword.Size = new System.Drawing.Size(176, 20);
            this.lblErrorPassword.TabIndex = 12;
            this.lblErrorPassword.Text = "Vui lòng nhập mật khẩu";
            this.lblErrorPassword.Visible = false;
            // 
            // formDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1565, 1018);
            this.Controls.Add(this.lblErrorPassword);
            this.Controls.Add(this.lblErrorLoginName);
            this.Controls.Add(this.radioSinhVien);
            this.Controls.Add(this.radioGiaoVien);
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
        private System.Windows.Forms.RadioButton radioGiaoVien;
        private System.Windows.Forms.RadioButton radioSinhVien;
        private System.Windows.Forms.Label lblErrorLoginName;
        private System.Windows.Forms.Label lblErrorPassword;
    }
}