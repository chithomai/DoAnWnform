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
    public partial class FormTIMKIEM : Form
    {
        public FormTIMKIEM()
        {
            InitializeComponent();
        }

        public void LoadGrid()
        {
            dgvTimKiem.DataSource = Conect.GetData("select * from NHANVIEN");
        }

        public void LoadGridKeyword()
        {
            dgvTimKiem.DataSource = Conect.GetData("select * from NHANVIEN where TENNV like '%" + txtTim.Text + "%'");
        }
        public void LoadGridKeywordCode()
        {
           dgvTimKiem.DataSource = Conect.GetData("select * from NHANVIEN where MANV like '%" + txtMa.Text + "%'");
        }
        private void FormTIMKIEM_Load(object sender, EventArgs e)
        {

        }

   
        private void button1_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void btnTim_Click_1(object sender, EventArgs e)
        {
            LoadGridKeyword();
        }

        private void btnTimMa_Click(object sender, EventArgs e)
        {
            LoadGridKeywordCode();
        }
    }
}
