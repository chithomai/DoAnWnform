using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLNS_1
{
    public partial class FormCHUCVU : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        string str = "Data Source=IRIS;Initial Catalog=QLNS;Integrated Security=True";
        SqlDataAdapter adap = new SqlDataAdapter();
        DataTable table = new DataTable();
        void LoadData()
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from CHUCVU";
            cmd.ExecuteNonQuery();
            adap.SelectCommand = cmd;
            table.Clear();
            adap.Fill(table);
            dgvCHUCVU.DataSource = table;
        }
        public FormCHUCVU()
        {
            InitializeComponent();
        }

        private void FormCHUCVU_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            LoadData();
        }
  
        private void dgvCHUCVU_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCV.ReadOnly = true;
            int i;
            i = dgvCHUCVU.CurrentRow.Index;
            txtMaCV.Text = dgvCHUCVU.Rows[i].Cells[0].Value.ToString();
            txtTenCV.Text= dgvCHUCVU.Rows[i].Cells[1].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "insert into CHUCVU values('"+txtMaCV.Text+ "',N'"+txtTenCV.Text+"')";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "delete from CHUCVU where MACV='"+txtMaCV.Text+"'";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "update CHUCVU set TENCV=N'"+txtTenCV.Text+ "'where MACV='"+txtMaCV.Text+"'";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtMaCV.Text = "";
            txtTenCV.Text = "";
            LoadData();
        }
    }
}
