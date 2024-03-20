using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THITRACNGHIEM
{
    public partial class frmMonHoc : Form
    {
        public frmMonHoc()
        {
            InitializeComponent();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dSMonHoc.MONHOC' table. You can move, or remove it, as needed.
            this.MonHocTableAdapter.Fill(this.DSMonHoc.MONHOC);
            // TODO: This line of code loads data into the 'dSMonHoc.MONHOC' table. You can move, or remove it, as needed.
            this.MonHocTableAdapter.Fill(this.DSMonHoc.MONHOC);
            // TODO: This line of code loads data into the 'dSMonHoc.MONHOC' table. You can move, or remove it, as needed.
            this.MonHocTableAdapter.Fill(this.DSMonHoc.MONHOC);
            // TODO: This line of code loads data into the 'dSMonHoc.MONHOC' table. You can move, or remove it, as needed.
            this.MonHocTableAdapter.Fill(this.DSMonHoc.MONHOC);
            // TODO: This line of code loads data into the 'dSMonHoc.MONHOC' table. You can move, or remove it, as needed.
            this.MonHocTableAdapter.Fill(this.DSMonHoc.MONHOC);

        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMonHoc.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DSMonHoc);

        }

        private void mONHOCBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMonHoc.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DSMonHoc);

        }

        private void mONHOCBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMonHoc.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DSMonHoc);

        }

        private void mONHOCBindingNavigatorSaveItem_Click_3(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMonHoc.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DSMonHoc);

        }

        private void mONHOCBindingNavigatorSaveItem_Click_4(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMonHoc.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DSMonHoc);

        }

        private void mAMHTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void mAMHLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
