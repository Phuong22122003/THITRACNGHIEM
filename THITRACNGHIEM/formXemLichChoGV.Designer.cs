namespace THITRACNGHIEM
{
    partial class formXemLichChoGV
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
            System.Windows.Forms.Label tENLOPLabel;
            System.Windows.Forms.Label mAMHLabel;
            System.Windows.Forms.Label lANLabel;
            System.Windows.Forms.Label nGAYTHILabel;
            System.Windows.Forms.Label tHOIGIANLabel;
            System.Windows.Forms.Label sOCAUTHILabel;
            System.Windows.Forms.Label tRINHDOLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formXemLichChoGV));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnXemChiTiet = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoatForm = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dS_THI = new THITRACNGHIEM.DS_THI();
            this.bdsLichThi = new System.Windows.Forms.BindingSource(this.components);
            this.sP_LAYLICHTHI_GVTableAdapter = new THITRACNGHIEM.DS_THITableAdapters.SP_LAYLICHTHI_GVTableAdapter();
            this.tableAdapterManager = new THITRACNGHIEM.DS_THITableAdapters.TableAdapterManager();
            this.sP_LAYLICHTHI_GVGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID_CTDK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENLOP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMAMH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNGAYTHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTHOIGIAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOCAUTHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTRINHDO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelThongTinThi = new DevExpress.XtraEditors.PanelControl();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThi = new System.Windows.Forms.Button();
            this.tRINHDOTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.sOCAUTHISpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.speThoiLuong = new DevExpress.XtraEditors.SpinEdit();
            this.nGAYTHIDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.speLanThi = new DevExpress.XtraEditors.SpinEdit();
            this.mAMHTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.tENLOPTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.txtTenMh = new DevExpress.XtraEditors.TextEdit();
            tENMHLabel = new System.Windows.Forms.Label();
            tENLOPLabel = new System.Windows.Forms.Label();
            mAMHLabel = new System.Windows.Forms.Label();
            lANLabel = new System.Windows.Forms.Label();
            nGAYTHILabel = new System.Windows.Forms.Label();
            tHOIGIANLabel = new System.Windows.Forms.Label();
            sOCAUTHILabel = new System.Windows.Forms.Label();
            tRINHDOLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_THI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLichThi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sP_LAYLICHTHI_GVGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelThongTinThi)).BeginInit();
            this.panelThongTinThi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tRINHDOTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sOCAUTHISpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speThoiLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYTHIDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYTHIDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speLanThi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mAMHTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tENLOPTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenMh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tENMHLabel
            // 
            tENMHLabel.AutoSize = true;
            tENMHLabel.Location = new System.Drawing.Point(54, 221);
            tENMHLabel.Name = "tENMHLabel";
            tENMHLabel.Size = new System.Drawing.Size(87, 16);
            tENMHLabel.TabIndex = 0;
            tENMHLabel.Text = "Tên môn học:";
            // 
            // tENLOPLabel
            // 
            tENLOPLabel.AutoSize = true;
            tENLOPLabel.Location = new System.Drawing.Point(582, 121);
            tENLOPLabel.Name = "tENLOPLabel";
            tENLOPLabel.Size = new System.Drawing.Size(53, 16);
            tENLOPLabel.TabIndex = 2;
            tENLOPLabel.Text = "Tên Lớp";
            // 
            // mAMHLabel
            // 
            mAMHLabel.AutoSize = true;
            mAMHLabel.Location = new System.Drawing.Point(59, 124);
            mAMHLabel.Name = "mAMHLabel";
            mAMHLabel.Size = new System.Drawing.Size(82, 16);
            mAMHLabel.TabIndex = 4;
            mAMHLabel.Text = "Mã môn học:";
            // 
            // lANLabel
            // 
            lANLabel.AutoSize = true;
            lANLabel.Location = new System.Drawing.Point(59, 457);
            lANLabel.Name = "lANLabel";
            lANLabel.Size = new System.Drawing.Size(45, 16);
            lANLabel.TabIndex = 6;
            lANLabel.Text = "Lần thi";
            // 
            // nGAYTHILabel
            // 
            nGAYTHILabel.AutoSize = true;
            nGAYTHILabel.Location = new System.Drawing.Point(586, 224);
            nGAYTHILabel.Name = "nGAYTHILabel";
            nGAYTHILabel.Size = new System.Drawing.Size(53, 16);
            nGAYTHILabel.TabIndex = 8;
            nGAYTHILabel.Text = "Ngày thi";
            // 
            // tHOIGIANLabel
            // 
            tHOIGIANLabel.AutoSize = true;
            tHOIGIANLabel.Location = new System.Drawing.Point(582, 453);
            tHOIGIANLabel.Name = "tHOIGIANLabel";
            tHOIGIANLabel.Size = new System.Drawing.Size(60, 16);
            tHOIGIANLabel.TabIndex = 10;
            tHOIGIANLabel.Text = "Thời gian";
            // 
            // sOCAUTHILabel
            // 
            sOCAUTHILabel.AutoSize = true;
            sOCAUTHILabel.Location = new System.Drawing.Point(59, 327);
            sOCAUTHILabel.Name = "sOCAUTHILabel";
            sOCAUTHILabel.Size = new System.Drawing.Size(46, 16);
            sOCAUTHILabel.TabIndex = 12;
            sOCAUTHILabel.Text = "Số câu";
            // 
            // tRINHDOLabel
            // 
            tRINHDOLabel.AutoSize = true;
            tRINHDOLabel.Location = new System.Drawing.Point(586, 327);
            tRINHDOLabel.Name = "tRINHDOLabel";
            tRINHDOLabel.Size = new System.Drawing.Size(55, 16);
            tRINHDOLabel.TabIndex = 14;
            tRINHDOLabel.Text = "Trình độ";
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
            this.btnXemChiTiet,
            this.barButtonItem2,
            this.btnThoatForm});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnThoatForm)});
            this.bar1.Text = "Tools";
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.Caption = "Xem chi tiết";
            this.btnXemChiTiet.Id = 0;
            this.btnXemChiTiet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXemChiTiet.ImageOptions.Image")));
            this.btnXemChiTiet.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXemChiTiet.ImageOptions.LargeImage")));
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXemChiTiet_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Reload";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // btnThoatForm
            // 
            this.btnThoatForm.Caption = "Thoát";
            this.btnThoatForm.Id = 2;
            this.btnThoatForm.Name = "btnThoatForm";
            this.btnThoatForm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoatForm_ItemClick);
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 815);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1924, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 764);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1924, 51);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 764);
            // 
            // dS_THI
            // 
            this.dS_THI.DataSetName = "DS_THI";
            this.dS_THI.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsLichThi
            // 
            this.bdsLichThi.DataMember = "SP_LAYLICHTHI_GV";
            this.bdsLichThi.DataSource = this.dS_THI;
            // 
            // sP_LAYLICHTHI_GVTableAdapter
            // 
            this.sP_LAYLICHTHI_GVTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = THITRACNGHIEM.DS_THITableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // sP_LAYLICHTHI_GVGridControl
            // 
            this.sP_LAYLICHTHI_GVGridControl.DataSource = this.bdsLichThi;
            this.sP_LAYLICHTHI_GVGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sP_LAYLICHTHI_GVGridControl.Location = new System.Drawing.Point(0, 51);
            this.sP_LAYLICHTHI_GVGridControl.MainView = this.gridView1;
            this.sP_LAYLICHTHI_GVGridControl.MenuManager = this.barManager1;
            this.sP_LAYLICHTHI_GVGridControl.Name = "sP_LAYLICHTHI_GVGridControl";
            this.sP_LAYLICHTHI_GVGridControl.Size = new System.Drawing.Size(1924, 764);
            this.sP_LAYLICHTHI_GVGridControl.TabIndex = 6;
            this.sP_LAYLICHTHI_GVGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID_CTDK,
            this.colTENMH,
            this.colTENLOP,
            this.colMAMH,
            this.colLAN,
            this.colNGAYTHI,
            this.colTHOIGIAN,
            this.colSOCAUTHI,
            this.colTRINHDO});
            this.gridView1.GridControl = this.sP_LAYLICHTHI_GVGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colID_CTDK
            // 
            this.colID_CTDK.FieldName = "ID_CTDK";
            this.colID_CTDK.MinWidth = 25;
            this.colID_CTDK.Name = "colID_CTDK";
            this.colID_CTDK.Visible = true;
            this.colID_CTDK.VisibleIndex = 0;
            this.colID_CTDK.Width = 94;
            // 
            // colTENMH
            // 
            this.colTENMH.FieldName = "TENMH";
            this.colTENMH.MinWidth = 25;
            this.colTENMH.Name = "colTENMH";
            this.colTENMH.Visible = true;
            this.colTENMH.VisibleIndex = 1;
            this.colTENMH.Width = 94;
            // 
            // colTENLOP
            // 
            this.colTENLOP.FieldName = "TENLOP";
            this.colTENLOP.MinWidth = 25;
            this.colTENLOP.Name = "colTENLOP";
            this.colTENLOP.Visible = true;
            this.colTENLOP.VisibleIndex = 2;
            this.colTENLOP.Width = 94;
            // 
            // colMAMH
            // 
            this.colMAMH.FieldName = "MAMH";
            this.colMAMH.MinWidth = 25;
            this.colMAMH.Name = "colMAMH";
            this.colMAMH.Visible = true;
            this.colMAMH.VisibleIndex = 3;
            this.colMAMH.Width = 94;
            // 
            // colLAN
            // 
            this.colLAN.FieldName = "LAN";
            this.colLAN.MinWidth = 25;
            this.colLAN.Name = "colLAN";
            this.colLAN.Visible = true;
            this.colLAN.VisibleIndex = 4;
            this.colLAN.Width = 94;
            // 
            // colNGAYTHI
            // 
            this.colNGAYTHI.FieldName = "NGAYTHI";
            this.colNGAYTHI.MinWidth = 25;
            this.colNGAYTHI.Name = "colNGAYTHI";
            this.colNGAYTHI.Visible = true;
            this.colNGAYTHI.VisibleIndex = 5;
            this.colNGAYTHI.Width = 94;
            // 
            // colTHOIGIAN
            // 
            this.colTHOIGIAN.FieldName = "THOIGIAN";
            this.colTHOIGIAN.MinWidth = 25;
            this.colTHOIGIAN.Name = "colTHOIGIAN";
            this.colTHOIGIAN.Visible = true;
            this.colTHOIGIAN.VisibleIndex = 6;
            this.colTHOIGIAN.Width = 94;
            // 
            // colSOCAUTHI
            // 
            this.colSOCAUTHI.FieldName = "SOCAUTHI";
            this.colSOCAUTHI.MinWidth = 25;
            this.colSOCAUTHI.Name = "colSOCAUTHI";
            this.colSOCAUTHI.Visible = true;
            this.colSOCAUTHI.VisibleIndex = 7;
            this.colSOCAUTHI.Width = 94;
            // 
            // colTRINHDO
            // 
            this.colTRINHDO.FieldName = "TRINHDO";
            this.colTRINHDO.MinWidth = 25;
            this.colTRINHDO.Name = "colTRINHDO";
            this.colTRINHDO.Visible = true;
            this.colTRINHDO.VisibleIndex = 8;
            this.colTRINHDO.Width = 94;
            // 
            // panelThongTinThi
            // 
            this.panelThongTinThi.Controls.Add(this.btnThoat);
            this.panelThongTinThi.Controls.Add(this.btnThi);
            this.panelThongTinThi.Controls.Add(tRINHDOLabel);
            this.panelThongTinThi.Controls.Add(this.tRINHDOTextEdit);
            this.panelThongTinThi.Controls.Add(sOCAUTHILabel);
            this.panelThongTinThi.Controls.Add(this.sOCAUTHISpinEdit);
            this.panelThongTinThi.Controls.Add(tHOIGIANLabel);
            this.panelThongTinThi.Controls.Add(this.speThoiLuong);
            this.panelThongTinThi.Controls.Add(nGAYTHILabel);
            this.panelThongTinThi.Controls.Add(this.nGAYTHIDateEdit);
            this.panelThongTinThi.Controls.Add(lANLabel);
            this.panelThongTinThi.Controls.Add(this.speLanThi);
            this.panelThongTinThi.Controls.Add(mAMHLabel);
            this.panelThongTinThi.Controls.Add(this.mAMHTextEdit);
            this.panelThongTinThi.Controls.Add(tENLOPLabel);
            this.panelThongTinThi.Controls.Add(this.tENLOPTextEdit);
            this.panelThongTinThi.Controls.Add(tENMHLabel);
            this.panelThongTinThi.Controls.Add(this.txtTenMh);
            this.panelThongTinThi.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelThongTinThi.Location = new System.Drawing.Point(887, 51);
            this.panelThongTinThi.Name = "panelThongTinThi";
            this.panelThongTinThi.Size = new System.Drawing.Size(1037, 764);
            this.panelThongTinThi.TabIndex = 7;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(898, 23);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 17;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThi
            // 
            this.btnThi.Location = new System.Drawing.Point(449, 589);
            this.btnThi.Name = "btnThi";
            this.btnThi.Size = new System.Drawing.Size(101, 36);
            this.btnThi.TabIndex = 16;
            this.btnThi.Text = "Thi";
            this.btnThi.UseVisualStyleBackColor = true;
            this.btnThi.Click += new System.EventHandler(this.btnThi_Click);
            // 
            // tRINHDOTextEdit
            // 
            this.tRINHDOTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsLichThi, "TRINHDO", true));
            this.tRINHDOTextEdit.Location = new System.Drawing.Point(708, 316);
            this.tRINHDOTextEdit.MenuManager = this.barManager1;
            this.tRINHDOTextEdit.Name = "tRINHDOTextEdit";
            this.tRINHDOTextEdit.Properties.ReadOnly = true;
            this.tRINHDOTextEdit.Size = new System.Drawing.Size(200, 22);
            this.tRINHDOTextEdit.TabIndex = 15;
            // 
            // sOCAUTHISpinEdit
            // 
            this.sOCAUTHISpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsLichThi, "SOCAUTHI", true));
            this.sOCAUTHISpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.sOCAUTHISpinEdit.Location = new System.Drawing.Point(216, 314);
            this.sOCAUTHISpinEdit.MenuManager = this.barManager1;
            this.sOCAUTHISpinEdit.Name = "sOCAUTHISpinEdit";
            this.sOCAUTHISpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sOCAUTHISpinEdit.Properties.ReadOnly = true;
            this.sOCAUTHISpinEdit.Size = new System.Drawing.Size(178, 24);
            this.sOCAUTHISpinEdit.TabIndex = 13;
            // 
            // speThoiLuong
            // 
            this.speThoiLuong.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsLichThi, "THOIGIAN", true));
            this.speThoiLuong.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.speThoiLuong.Location = new System.Drawing.Point(708, 449);
            this.speThoiLuong.MenuManager = this.barManager1;
            this.speThoiLuong.Name = "speThoiLuong";
            this.speThoiLuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.speThoiLuong.Properties.ReadOnly = true;
            this.speThoiLuong.Size = new System.Drawing.Size(125, 24);
            this.speThoiLuong.TabIndex = 11;
            // 
            // nGAYTHIDateEdit
            // 
            this.nGAYTHIDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsLichThi, "NGAYTHI", true));
            this.nGAYTHIDateEdit.EditValue = null;
            this.nGAYTHIDateEdit.Location = new System.Drawing.Point(708, 218);
            this.nGAYTHIDateEdit.MenuManager = this.barManager1;
            this.nGAYTHIDateEdit.Name = "nGAYTHIDateEdit";
            this.nGAYTHIDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nGAYTHIDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nGAYTHIDateEdit.Properties.ReadOnly = true;
            this.nGAYTHIDateEdit.Size = new System.Drawing.Size(200, 22);
            this.nGAYTHIDateEdit.TabIndex = 9;
            // 
            // speLanThi
            // 
            this.speLanThi.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsLichThi, "LAN", true));
            this.speLanThi.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.speLanThi.Location = new System.Drawing.Point(216, 453);
            this.speLanThi.MenuManager = this.barManager1;
            this.speLanThi.Name = "speLanThi";
            this.speLanThi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.speLanThi.Properties.ReadOnly = true;
            this.speLanThi.Size = new System.Drawing.Size(178, 24);
            this.speLanThi.TabIndex = 7;
            // 
            // mAMHTextEdit
            // 
            this.mAMHTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsLichThi, "MAMH", true));
            this.mAMHTextEdit.Location = new System.Drawing.Point(216, 118);
            this.mAMHTextEdit.MenuManager = this.barManager1;
            this.mAMHTextEdit.Name = "mAMHTextEdit";
            this.mAMHTextEdit.Properties.ReadOnly = true;
            this.mAMHTextEdit.Size = new System.Drawing.Size(178, 22);
            this.mAMHTextEdit.TabIndex = 5;
            // 
            // tENLOPTextEdit
            // 
            this.tENLOPTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsLichThi, "TENLOP", true));
            this.tENLOPTextEdit.Location = new System.Drawing.Point(708, 118);
            this.tENLOPTextEdit.MenuManager = this.barManager1;
            this.tENLOPTextEdit.Name = "tENLOPTextEdit";
            this.tENLOPTextEdit.Properties.ReadOnly = true;
            this.tENLOPTextEdit.Size = new System.Drawing.Size(200, 22);
            this.tENLOPTextEdit.TabIndex = 3;
            // 
            // txtTenMh
            // 
            this.txtTenMh.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bdsLichThi, "TENMH", true));
            this.txtTenMh.Location = new System.Drawing.Point(216, 221);
            this.txtTenMh.MenuManager = this.barManager1;
            this.txtTenMh.Name = "txtTenMh";
            this.txtTenMh.Properties.ReadOnly = true;
            this.txtTenMh.Size = new System.Drawing.Size(178, 22);
            this.txtTenMh.TabIndex = 1;
            // 
            // formXemLichChoGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 835);
            this.Controls.Add(this.panelThongTinThi);
            this.Controls.Add(this.sP_LAYLICHTHI_GVGridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "formXemLichChoGV";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_THI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsLichThi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sP_LAYLICHTHI_GVGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelThongTinThi)).EndInit();
            this.panelThongTinThi.ResumeLayout(false);
            this.panelThongTinThi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tRINHDOTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sOCAUTHISpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speThoiLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYTHIDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGAYTHIDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speLanThi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mAMHTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tENLOPTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenMh.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnXemChiTiet;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btnThoatForm;
        private System.Windows.Forms.BindingSource bdsLichThi;
        private DS_THI dS_THI;
        private DS_THITableAdapters.SP_LAYLICHTHI_GVTableAdapter sP_LAYLICHTHI_GVTableAdapter;
        private DS_THITableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl sP_LAYLICHTHI_GVGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID_CTDK;
        private DevExpress.XtraGrid.Columns.GridColumn colTENMH;
        private DevExpress.XtraGrid.Columns.GridColumn colTENLOP;
        private DevExpress.XtraGrid.Columns.GridColumn colMAMH;
        private DevExpress.XtraGrid.Columns.GridColumn colLAN;
        private DevExpress.XtraGrid.Columns.GridColumn colNGAYTHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTHOIGIAN;
        private DevExpress.XtraGrid.Columns.GridColumn colSOCAUTHI;
        private DevExpress.XtraGrid.Columns.GridColumn colTRINHDO;
        private DevExpress.XtraEditors.PanelControl panelThongTinThi;
        private System.Windows.Forms.Button btnThi;
        private DevExpress.XtraEditors.TextEdit tRINHDOTextEdit;
        private DevExpress.XtraEditors.SpinEdit sOCAUTHISpinEdit;
        private DevExpress.XtraEditors.SpinEdit speThoiLuong;
        private DevExpress.XtraEditors.DateEdit nGAYTHIDateEdit;
        private DevExpress.XtraEditors.SpinEdit speLanThi;
        private DevExpress.XtraEditors.TextEdit mAMHTextEdit;
        private DevExpress.XtraEditors.TextEdit tENLOPTextEdit;
        private DevExpress.XtraEditors.TextEdit txtTenMh;
        private System.Windows.Forms.Button btnThoat;
    }
}