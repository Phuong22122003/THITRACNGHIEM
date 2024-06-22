namespace THITRACNGHIEM
{
    partial class formXemDanhSachDangKy
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
            this.dateEditTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.dateEditDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblXemDanhSachDK = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.lblErrorTuNgay = new System.Windows.Forms.Label();
            this.lblErrorDenNgay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // dateEditTuNgay
            // 
            this.dateEditTuNgay.EditValue = null;
            this.dateEditTuNgay.Location = new System.Drawing.Point(790, 283);
            this.dateEditTuNgay.Name = "dateEditTuNgay";
            this.dateEditTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTuNgay.Size = new System.Drawing.Size(125, 22);
            this.dateEditTuNgay.TabIndex = 0;
            // 
            // dateEditDenNgay
            // 
            this.dateEditDenNgay.EditValue = null;
            this.dateEditDenNgay.Location = new System.Drawing.Point(790, 364);
            this.dateEditDenNgay.Name = "dateEditDenNgay";
            this.dateEditDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDenNgay.Size = new System.Drawing.Size(125, 22);
            this.dateEditDenNgay.TabIndex = 1;
            // 
            // lblXemDanhSachDK
            // 
            this.lblXemDanhSachDK.AutoSize = true;
            this.lblXemDanhSachDK.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXemDanhSachDK.Location = new System.Drawing.Point(689, 136);
            this.lblXemDanhSachDK.Name = "lblXemDanhSachDK";
            this.lblXemDanhSachDK.Size = new System.Drawing.Size(305, 26);
            this.lblXemDanhSachDK.TabIndex = 2;
            this.lblXemDanhSachDK.Text = "XEM DANH SÁCH ĐĂNG KÝ";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(670, 286);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(59, 16);
            this.lblTuNgay.TabIndex = 3;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(665, 370);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(64, 16);
            this.lblDenNgay.TabIndex = 4;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(790, 435);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(125, 23);
            this.btnXem.TabIndex = 5;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // lblErrorTuNgay
            // 
            this.lblErrorTuNgay.AutoSize = true;
            this.lblErrorTuNgay.ForeColor = System.Drawing.Color.Red;
            this.lblErrorTuNgay.Location = new System.Drawing.Point(790, 238);
            this.lblErrorTuNgay.Name = "lblErrorTuNgay";
            this.lblErrorTuNgay.Size = new System.Drawing.Size(85, 16);
            this.lblErrorTuNgay.TabIndex = 6;
            this.lblErrorTuNgay.Text = "ErrorTuNgay";
            this.lblErrorTuNgay.Visible = false;
            // 
            // lblErrorDenNgay
            // 
            this.lblErrorDenNgay.AutoSize = true;
            this.lblErrorDenNgay.ForeColor = System.Drawing.Color.Red;
            this.lblErrorDenNgay.Location = new System.Drawing.Point(790, 332);
            this.lblErrorDenNgay.Name = "lblErrorDenNgay";
            this.lblErrorDenNgay.Size = new System.Drawing.Size(94, 16);
            this.lblErrorDenNgay.TabIndex = 7;
            this.lblErrorDenNgay.Text = "ErrorDenNgay";
            this.lblErrorDenNgay.Visible = false;
            // 
            // formXemDanhSachDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 572);
            this.Controls.Add(this.lblErrorDenNgay);
            this.Controls.Add(this.lblErrorTuNgay);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.lblXemDanhSachDK);
            this.Controls.Add(this.dateEditDenNgay);
            this.Controls.Add(this.dateEditTuNgay);
            this.Name = "formXemDanhSachDangKy";
            this.Text = "formXemDanhSachDangKy";
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDenNgay.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dateEditTuNgay;
        private DevExpress.XtraEditors.DateEdit dateEditDenNgay;
        private System.Windows.Forms.Label lblXemDanhSachDK;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Label lblErrorTuNgay;
        private System.Windows.Forms.Label lblErrorDenNgay;
    }
}