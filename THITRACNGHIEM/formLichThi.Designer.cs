namespace THITRACNGHIEM
{
    partial class formLichThi
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
            System.Windows.Forms.Label mAMHLabel;
            System.Windows.Forms.Label tENMHLabel;
            System.Windows.Forms.Label lANLabel;
            System.Windows.Forms.Label nGAYTHILabel;
            System.Windows.Forms.Label tHOIGIANLabel;
            System.Windows.Forms.Label sOCAUTHILabel;
            System.Windows.Forms.Label tRINHDOLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLichThi));
            this.dS_THI = new THITRACNGHIEM.DS_THI();
            this.bdsLichThi = new System.Windows.Forms.BindingSource(this.components);
            this.SP_LAYLICHTHITableAdapter = new THITRACNGHIEM.DS_THITableAdapters.SP_LAYLICHTHITableAdapter();
            this.tableAdapterManager = new THITRACNGHIEM.DS_THITableAdapters.TableAdapterManager();
            this.gcLichThi = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTENMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYTHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTHOIGIAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOCAUTHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTRINHDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelThongTinThi = new DevExpress.XtraEditors.PanelControl();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThi = new System.Windows.Forms.Button();
            this.txtTrinhDo = new DevExpress.XtraEditors.TextEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnXemChiTiet = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.speSoCau = new DevExpress.XtraEditors.SpinEdit();
            this.speThoiLuong = new DevExpress.XtraEditors.SpinEdit();
            this.deNgayThi = new DevExpress.XtraEditors.DateEdit();
            this.speLanThi = new DevExpress.XtraEditors.SpinEdit();
            this.txtTenMH = new DevExpress.XtraEditors.TextEdit();
            this.txtMaMH = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.tspThoiGianConLai = new DevExpress.XtraEditors.TimeSpanEdit();
            this.timer = new System.Windows.Forms.Timer(this.components);
            mAMHLabel = new System.Windows.Forms.Label();
            tENMHLabel = new System.Windows.Forms.Label();
            lANLabel = new System.Windows.Forms.Label();
            nGAYTHILabel = new System.Windows.Forms.Label();
            tHOIGIANLabel = new System.Windows.Forms.Label();
            sOCAUTHILabel = new System.Windows.Forms.Label();
            tRINHDOLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dS_THI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLichThi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLichThi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelThongTinThi)).BeginInit();
            this.panelThongTinThi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrinhDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speSoCau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speThoiLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNgayThi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNgayThi.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speLanThi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenMH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaMH.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tspThoiGianConLai.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mAMHLabel
            // 
            mAMHLabel.AutoSize = true;
            mAMHLabel.Location = new System.Drawing.Point(47, 145);
            mAMHLabel.Name = "mAMHLabel";
            mAMHLabel.Size = new System.Drawing.Size(90, 16);
            mAMHLabel.TabIndex = 1;
            mAMHLabel.Text = "MÃ MÔN HỌC:";
            // 
            // tENMHLabel
            // 
            tENMHLabel.AutoSize = true;
            tENMHLabel.Location = new System.Drawing.Point(42, 240);
            tENMHLabel.Name = "tENMHLabel";
            tENMHLabel.Size = new System.Drawing.Size(95, 16);
            tENMHLabel.TabIndex = 3;
            tENMHLabel.Text = "TÊN MÔN HỌC:";
            // 
            // lANLabel
            // 
            lANLabel.AutoSize = true;
            lANLabel.Location = new System.Drawing.Point(701, 354);
            lANLabel.Name = "lANLabel";
            lANLabel.Size = new System.Drawing.Size(58, 16);
            lANLabel.TabIndex = 5;
            lANLabel.Text = "LẦN THI:";
            // 
            // nGAYTHILabel
            // 
            nGAYTHILabel.AutoSize = true;
            nGAYTHILabel.Location = new System.Drawing.Point(692, 148);
            nGAYTHILabel.Name = "nGAYTHILabel";
            nGAYTHILabel.Size = new System.Drawing.Size(67, 16);
            nGAYTHILabel.TabIndex = 7;
            nGAYTHILabel.Text = "NGÀY THI:";
            // 
            // tHOIGIANLabel
            // 
            tHOIGIANLabel.AutoSize = true;
            tHOIGIANLabel.Location = new System.Drawing.Point(675, 243);
            tHOIGIANLabel.Name = "tHOIGIANLabel";
            tHOIGIANLabel.Size = new System.Drawing.Size(85, 16);
            tHOIGIANLabel.TabIndex = 9;
            tHOIGIANLabel.Text = "THỜI LƯỢNG:";
            // 
            // sOCAUTHILabel
            // 
            sOCAUTHILabel.AutoSize = true;
            sOCAUTHILabel.Location = new System.Drawing.Point(702, 461);
            sOCAUTHILabel.Name = "sOCAUTHILabel";
            sOCAUTHILabel.Size = new System.Drawing.Size(57, 16);
            sOCAUTHILabel.TabIndex = 11;
            sOCAUTHILabel.Text = "SỐ CÂU:";
            // 
            // tRINHDOLabel
            // 
            tRINHDOLabel.AutoSize = true;
            tRINHDOLabel.Location = new System.Drawing.Point(63, 354);
            tRINHDOLabel.Name = "tRINHDOLabel";
            tRINHDOLabel.Size = new System.Drawing.Size(70, 16);
            tRINHDOLabel.TabIndex = 13;
            tRINHDOLabel.Text = "TRÌNH ĐỘ:";
            // 
            // dS_THI
            // 
            this.dS_THI.DataSetName = "DS_THI";
            this.dS_THI.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsLichThi
            // 
            this.bdsLichThi.DataMember = "SP_LAYLICHTHI";
            this.bdsLichThi.DataSource = this.dS_THI;
            // 
            // SP_LAYLICHTHITableAdapter
            // 
            this.SP_LAYLICHTHITableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = THITRACNGHIEM.DS_THITableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gcLichThi
            // 
            this.gcLichThi.DataSource = this.bdsLichThi;
            this.gcLichThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcLichThi.Location = new System.Drawing.Point(0, 51);
            this.gcLichThi.MainView = this.gridView1;
            this.gcLichThi.Name = "gcLichThi";
            this.gcLichThi.Size = new System.Drawing.Size(813, 770);
            this.gcLichThi.TabIndex = 2;
            this.gcLichThi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTENMH,
            this.colMAMH,
            this.colLAN,
            this.colNGAYTHI,
            this.colTHOIGIAN,
            this.colSOCAUTHI,
            this.colTRINHDO});
            this.gridView1.GridControl = this.gcLichThi;
            this.gridView1.Name = "gridView1";
            // 
            // colTENMH
            // 
            this.colTENMH.FieldName = "TENMH";
            this.colTENMH.MinWidth = 25;
            this.colTENMH.Name = "colTENMH";
            this.colTENMH.OptionsColumn.AllowEdit = false;
            this.colTENMH.Visible = true;
            this.colTENMH.VisibleIndex = 0;
            this.colTENMH.Width = 221;
            // 
            // colMAMH
            // 
            this.colMAMH.FieldName = "MAMH";
            this.colMAMH.MinWidth = 25;
            this.colMAMH.Name = "colMAMH";
            this.colMAMH.OptionsColumn.AllowEdit = false;
            this.colMAMH.Visible = true;
            this.colMAMH.VisibleIndex = 1;
            this.colMAMH.Width = 103;
            // 
            // colLAN
            // 
            this.colLAN.FieldName = "LAN";
            this.colLAN.MinWidth = 25;
            this.colLAN.Name = "colLAN";
            this.colLAN.OptionsColumn.AllowEdit = false;
            this.colLAN.Visible = true;
            this.colLAN.VisibleIndex = 2;
            this.colLAN.Width = 69;
            // 
            // colNGAYTHI
            // 
            this.colNGAYTHI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNGAYTHI.FieldName = "NGAYTHI";
            this.colNGAYTHI.MinWidth = 25;
            this.colNGAYTHI.Name = "colNGAYTHI";
            this.colNGAYTHI.OptionsColumn.AllowEdit = false;
            this.colNGAYTHI.Visible = true;
            this.colNGAYTHI.VisibleIndex = 3;
            this.colNGAYTHI.Width = 100;
            // 
            // colTHOIGIAN
            // 
            this.colTHOIGIAN.FieldName = "THOIGIAN";
            this.colTHOIGIAN.MinWidth = 25;
            this.colTHOIGIAN.Name = "colTHOIGIAN";
            this.colTHOIGIAN.OptionsColumn.AllowEdit = false;
            this.colTHOIGIAN.Visible = true;
            this.colTHOIGIAN.VisibleIndex = 4;
            this.colTHOIGIAN.Width = 66;
            // 
            // colSOCAUTHI
            // 
            this.colSOCAUTHI.FieldName = "SOCAUTHI";
            this.colSOCAUTHI.MinWidth = 25;
            this.colSOCAUTHI.Name = "colSOCAUTHI";
            this.colSOCAUTHI.OptionsColumn.AllowEdit = false;
            this.colSOCAUTHI.Visible = true;
            this.colSOCAUTHI.VisibleIndex = 5;
            this.colSOCAUTHI.Width = 52;
            // 
            // colTRINHDO
            // 
            this.colTRINHDO.FieldName = "TRINHDO";
            this.colTRINHDO.MinWidth = 25;
            this.colTRINHDO.Name = "colTRINHDO";
            this.colTRINHDO.OptionsColumn.AllowEdit = false;
            this.colTRINHDO.Visible = true;
            this.colTRINHDO.VisibleIndex = 6;
            this.colTRINHDO.Width = 172;
            // 
            // panelThongTinThi
            // 
            this.panelThongTinThi.Controls.Add(this.btnThoat);
            this.panelThongTinThi.Controls.Add(this.label2);
            this.panelThongTinThi.Controls.Add(this.btnThi);
            this.panelThongTinThi.Controls.Add(tRINHDOLabel);
            this.panelThongTinThi.Controls.Add(this.txtTrinhDo);
            this.panelThongTinThi.Controls.Add(sOCAUTHILabel);
            this.panelThongTinThi.Controls.Add(this.speSoCau);
            this.panelThongTinThi.Controls.Add(tHOIGIANLabel);
            this.panelThongTinThi.Controls.Add(this.speThoiLuong);
            this.panelThongTinThi.Controls.Add(nGAYTHILabel);
            this.panelThongTinThi.Controls.Add(this.deNgayThi);
            this.panelThongTinThi.Controls.Add(lANLabel);
            this.panelThongTinThi.Controls.Add(this.speLanThi);
            this.panelThongTinThi.Controls.Add(tENMHLabel);
            this.panelThongTinThi.Controls.Add(this.txtTenMH);
            this.panelThongTinThi.Controls.Add(mAMHLabel);
            this.panelThongTinThi.Controls.Add(this.txtMaMH);
            this.panelThongTinThi.Controls.Add(this.label1);
            this.panelThongTinThi.Controls.Add(this.tspThoiGianConLai);
            this.panelThongTinThi.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelThongTinThi.Location = new System.Drawing.Point(813, 51);
            this.panelThongTinThi.Name = "panelThongTinThi";
            this.panelThongTinThi.Size = new System.Drawing.Size(1111, 770);
            this.panelThongTinThi.TabIndex = 3;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(947, 21);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 47);
            this.btnThoat.TabIndex = 18;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 454);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "THỜI GIAN CÒN LẠI:";
            // 
            // btnThi
            // 
            this.btnThi.Location = new System.Drawing.Point(498, 597);
            this.btnThi.Name = "btnThi";
            this.btnThi.Size = new System.Drawing.Size(104, 41);
            this.btnThi.TabIndex = 15;
            this.btnThi.Text = "Thi";
            this.btnThi.UseVisualStyleBackColor = true;
            this.btnThi.Click += new System.EventHandler(this.btnThi_Click);
            // 
            // txtTrinhDo
            // 
            this.txtTrinhDo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsLichThi, "TRINHDO", true));
            this.txtTrinhDo.Enabled = false;
            this.txtTrinhDo.Location = new System.Drawing.Point(261, 348);
            this.txtTrinhDo.MenuManager = this.barManager1;
            this.txtTrinhDo.Name = "txtTrinhDo";
            this.txtTrinhDo.Size = new System.Drawing.Size(287, 22);
            this.txtTrinhDo.TabIndex = 14;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.btnXemChiTiet});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXemChiTiet, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem1, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.Caption = "Xem chi tiết";
            this.btnXemChiTiet.Id = 2;
            this.btnXemChiTiet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXemChiTiet.ImageOptions.Image")));
            this.btnXemChiTiet.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXemChiTiet.ImageOptions.LargeImage")));
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXemChiTiet_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Reload";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Thoát";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1924, 51);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 821);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1924, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 770);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1924, 51);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 770);
            // 
            // speSoCau
            // 
            this.speSoCau.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsLichThi, "SOCAUTHI", true));
            this.speSoCau.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.speSoCau.Enabled = false;
            this.speSoCau.Location = new System.Drawing.Point(846, 456);
            this.speSoCau.MenuManager = this.barManager1;
            this.speSoCau.Name = "speSoCau";
            this.speSoCau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.speSoCau.Size = new System.Drawing.Size(125, 24);
            this.speSoCau.TabIndex = 12;
            // 
            // speThoiLuong
            // 
            this.speThoiLuong.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsLichThi, "THOIGIAN", true));
            this.speThoiLuong.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.speThoiLuong.Enabled = false;
            this.speThoiLuong.Location = new System.Drawing.Point(846, 238);
            this.speThoiLuong.MenuManager = this.barManager1;
            this.speThoiLuong.Name = "speThoiLuong";
            this.speThoiLuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.speThoiLuong.Size = new System.Drawing.Size(125, 24);
            this.speThoiLuong.TabIndex = 10;
            // 
            // deNgayThi
            // 
            this.deNgayThi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsLichThi, "NGAYTHI", true));
            this.deNgayThi.EditValue = null;
            this.deNgayThi.Enabled = false;
            this.deNgayThi.Location = new System.Drawing.Point(846, 145);
            this.deNgayThi.MenuManager = this.barManager1;
            this.deNgayThi.Name = "deNgayThi";
            this.deNgayThi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deNgayThi.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deNgayThi.Size = new System.Drawing.Size(125, 22);
            this.deNgayThi.TabIndex = 8;
            // 
            // speLanThi
            // 
            this.speLanThi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsLichThi, "LAN", true));
            this.speLanThi.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.speLanThi.Enabled = false;
            this.speLanThi.Location = new System.Drawing.Point(846, 346);
            this.speLanThi.MenuManager = this.barManager1;
            this.speLanThi.Name = "speLanThi";
            this.speLanThi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.speLanThi.Size = new System.Drawing.Size(125, 24);
            this.speLanThi.TabIndex = 6;
            // 
            // txtTenMH
            // 
            this.txtTenMH.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsLichThi, "TENMH", true));
            this.txtTenMH.Enabled = false;
            this.txtTenMH.Location = new System.Drawing.Point(261, 237);
            this.txtTenMH.MenuManager = this.barManager1;
            this.txtTenMH.Name = "txtTenMH";
            this.txtTenMH.Size = new System.Drawing.Size(287, 22);
            this.txtTenMH.TabIndex = 4;
            // 
            // txtMaMH
            // 
            this.txtMaMH.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsLichThi, "MAMH", true));
            this.txtMaMH.Enabled = false;
            this.txtMaMH.Location = new System.Drawing.Point(261, 142);
            this.txtMaMH.MenuManager = this.barManager1;
            this.txtMaMH.Name = "txtMaMH";
            this.txtMaMH.Size = new System.Drawing.Size(287, 22);
            this.txtMaMH.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÔNG TIN THI";
            // 
            // tspThoiGianConLai
            // 
            this.tspThoiGianConLai.EditValue = null;
            this.tspThoiGianConLai.Enabled = false;
            this.tspThoiGianConLai.Location = new System.Drawing.Point(261, 451);
            this.tspThoiGianConLai.MenuManager = this.barManager1;
            this.tspThoiGianConLai.Name = "tspThoiGianConLai";
            this.tspThoiGianConLai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tspThoiGianConLai.Properties.DisplayFormat.FormatString = "d";
            this.tspThoiGianConLai.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tspThoiGianConLai.Properties.EditFormat.FormatString = "d";
            this.tspThoiGianConLai.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tspThoiGianConLai.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.DateTimeMaskManager));
            this.tspThoiGianConLai.Properties.MaskSettings.Set("mask", "d");
            this.tspThoiGianConLai.Size = new System.Drawing.Size(287, 22);
            this.tspThoiGianConLai.TabIndex = 17;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.allowBtnThi);
            // 
            // formLichThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 841);
            this.Controls.Add(this.gcLichThi);
            this.Controls.Add(this.panelThongTinThi);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "formLichThi";
            this.Text = "formLichThi";
            this.Load += new System.EventHandler(this.formLichThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS_THI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLichThi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLichThi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelThongTinThi)).EndInit();
            this.panelThongTinThi.ResumeLayout(false);
            this.panelThongTinThi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrinhDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speSoCau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speThoiLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNgayThi.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deNgayThi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speLanThi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenMH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaMH.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tspThoiGianConLai.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DS_THI dS_THI;
        private System.Windows.Forms.BindingSource bdsLichThi;
        private DS_THITableAdapters.SP_LAYLICHTHITableAdapter SP_LAYLICHTHITableAdapter;
        private DS_THITableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl gcLichThi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colTENMH;
        private DevExpress.XtraGrid.Columns.GridColumn colMAMH;
        private DevExpress.XtraGrid.Columns.GridColumn colLAN;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYTHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTHOIGIAN;
        private DevExpress.XtraGrid.Columns.GridColumn colSOCAUTHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTRINHDO;
        private DevExpress.XtraEditors.PanelControl panelThongTinThi;
        private DevExpress.XtraEditors.TextEdit txtTrinhDo;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SpinEdit speSoCau;
        private DevExpress.XtraEditors.SpinEdit speThoiLuong;
        private DevExpress.XtraEditors.DateEdit deNgayThi;
        private DevExpress.XtraEditors.SpinEdit speLanThi;
        private DevExpress.XtraEditors.TextEdit txtTenMH;
        private DevExpress.XtraEditors.TextEdit txtMaMH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThi;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraEditors.TimeSpanEdit tspThoiGianConLai;
        private DevExpress.XtraBars.BarButtonItem btnXemChiTiet;
        private System.Windows.Forms.Button btnThoat;
    }
}