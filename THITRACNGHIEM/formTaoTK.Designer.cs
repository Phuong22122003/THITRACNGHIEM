namespace THITRACNGHIEM
{
    partial class formTaoTK
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.cmbNhom = new System.Windows.Forms.ComboBox();
            this.cmbHoVaTen = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaGV = new System.Windows.Forms.TextBox();
            this.btnTaoTK = new System.Windows.Forms.Button();
            this.btnXoaTK = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDoiMK = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblLoiMK = new System.Windows.Forms.Label();
            this.lblLoiTK = new System.Windows.Forms.Label();
            this.lblLoiNhom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(704, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "TẠO TÀI KHOẢNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(536, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ và tên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(536, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tài khoản:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(539, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mật khẩu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(541, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nhóm:";
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(665, 252);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(302, 22);
            this.txtTK.TabIndex = 6;
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(665, 314);
            this.txtMK.Name = "txtMK";
            this.txtMK.PasswordChar = '*';
            this.txtMK.Size = new System.Drawing.Size(302, 22);
            this.txtMK.TabIndex = 7;
            // 
            // cmbNhom
            // 
            this.cmbNhom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhom.FormattingEnabled = true;
            this.cmbNhom.Location = new System.Drawing.Point(665, 380);
            this.cmbNhom.Name = "cmbNhom";
            this.cmbNhom.Size = new System.Drawing.Size(302, 24);
            this.cmbNhom.TabIndex = 8;
            // 
            // cmbHoVaTen
            // 
            this.cmbHoVaTen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHoVaTen.FormattingEnabled = true;
            this.cmbHoVaTen.Location = new System.Drawing.Point(665, 187);
            this.cmbHoVaTen.Name = "cmbHoVaTen";
            this.cmbHoVaTen.Size = new System.Drawing.Size(302, 24);
            this.cmbHoVaTen.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1024, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mã giảng viên:";
            // 
            // txtMaGV
            // 
            this.txtMaGV.Enabled = false;
            this.txtMaGV.Location = new System.Drawing.Point(1135, 186);
            this.txtMaGV.Name = "txtMaGV";
            this.txtMaGV.Size = new System.Drawing.Size(173, 22);
            this.txtMaGV.TabIndex = 12;
            // 
            // btnTaoTK
            // 
            this.btnTaoTK.Location = new System.Drawing.Point(581, 554);
            this.btnTaoTK.Name = "btnTaoTK";
            this.btnTaoTK.Size = new System.Drawing.Size(97, 39);
            this.btnTaoTK.TabIndex = 13;
            this.btnTaoTK.Text = "Tạo tài khoản";
            this.btnTaoTK.UseVisualStyleBackColor = true;
            this.btnTaoTK.Click += new System.EventHandler(this.btnTaoTK_Click);
            // 
            // btnXoaTK
            // 
            this.btnXoaTK.Location = new System.Drawing.Point(751, 554);
            this.btnXoaTK.Name = "btnXoaTK";
            this.btnXoaTK.Size = new System.Drawing.Size(99, 39);
            this.btnXoaTK.TabIndex = 14;
            this.btnXoaTK.Text = "Xóa tài khoản";
            this.btnXoaTK.UseVisualStyleBackColor = true;
            this.btnXoaTK.Click += new System.EventHandler(this.btnXoaTK_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(1291, 12);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 15;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnDoiMK
            // 
            this.btnDoiMK.Location = new System.Drawing.Point(927, 554);
            this.btnDoiMK.Name = "btnDoiMK";
            this.btnDoiMK.Size = new System.Drawing.Size(102, 39);
            this.btnDoiMK.TabIndex = 16;
            this.btnDoiMK.Text = "Đổi mật khẩu";
            this.btnDoiMK.UseVisualStyleBackColor = true;
            this.btnDoiMK.Click += new System.EventHandler(this.btnDoiMK_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(731, 143);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 16);
            this.lblMessage.TabIndex = 17;
            // 
            // lblLoiMK
            // 
            this.lblLoiMK.AutoSize = true;
            this.lblLoiMK.Location = new System.Drawing.Point(672, 345);
            this.lblLoiMK.Name = "lblLoiMK";
            this.lblLoiMK.Size = new System.Drawing.Size(35, 16);
            this.lblLoiMK.TabIndex = 19;
            this.lblLoiMK.Text = "error";
            // 
            // lblLoiTK
            // 
            this.lblLoiTK.AutoSize = true;
            this.lblLoiTK.Location = new System.Drawing.Point(665, 277);
            this.lblLoiTK.Name = "lblLoiTK";
            this.lblLoiTK.Size = new System.Drawing.Size(35, 16);
            this.lblLoiTK.TabIndex = 20;
            this.lblLoiTK.Text = "error";
            // 
            // lblLoiNhom
            // 
            this.lblLoiNhom.AutoSize = true;
            this.lblLoiNhom.Location = new System.Drawing.Point(672, 416);
            this.lblLoiNhom.Name = "lblLoiNhom";
            this.lblLoiNhom.Size = new System.Drawing.Size(35, 16);
            this.lblLoiNhom.TabIndex = 21;
            this.lblLoiNhom.Text = "error";
            // 
            // formTaoTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 699);
            this.Controls.Add(this.lblLoiNhom);
            this.Controls.Add(this.lblLoiTK);
            this.Controls.Add(this.lblLoiMK);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnDoiMK);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoaTK);
            this.Controls.Add(this.btnTaoTK);
            this.Controls.Add(this.txtMaGV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbHoVaTen);
            this.Controls.Add(this.cmbNhom);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.txtTK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "formTaoTK";
            this.Text = "formTaoTK";
            this.Load += new System.EventHandler(this.formTaoTK_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.ComboBox cmbNhom;
        private System.Windows.Forms.ComboBox cmbHoVaTen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaGV;
        private System.Windows.Forms.Button btnTaoTK;
        private System.Windows.Forms.Button btnXoaTK;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnDoiMK;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblLoiMK;
        private System.Windows.Forms.Label lblLoiTK;
        private System.Windows.Forms.Label lblLoiNhom;
    }
}