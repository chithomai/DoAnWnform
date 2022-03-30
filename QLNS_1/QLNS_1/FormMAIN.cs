using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS_1
{
    public partial class FormMAIN : Form
    {
        public FormMAIN()
        {
            InitializeComponent();
        }

        private void mnHoSoNV_Click(object sender, EventArgs e)
        {
            FormNHANVIEN fm = new FormNHANVIEN();
            fm.ShowDialog();
        }

        private void mnChucVu_Click(object sender, EventArgs e)
        {
            FormCHUCVU fm = new FormCHUCVU();
            fm.ShowDialog();
        }

        private void mnSHocVan_Click(object sender, EventArgs e)
        {
            FormHOCVAN fm = new FormHOCVAN();
            fm.ShowDialog();
        }

        private void mnSTaiKhoan_Click(object sender, EventArgs e)
        {
            FormTAIKHOAN fm = new FormTAIKHOAN();
            fm.ShowDialog();
        }

        private void mnSHOPDONG_Click(object sender, EventArgs e)
        {
            FormHOPDONG fm = new FormHOPDONG();
            fm.ShowDialog();
        }

        private void phòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPHONGBAN fm = new FormPHONGBAN();
            fm.ShowDialog();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTIMKIEM f = new FormTIMKIEM();
            f.ShowDialog();
        }

        private void tToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có chắc muốn thoát!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
                Application.Exit();
        }
    }
}
