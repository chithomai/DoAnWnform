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
    public partial class FormHOPDONG : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        string str = "Data Source=IRIS;Initial Catalog=QLNS_1;Integrated Security=True";
        SqlDataAdapter adap = new SqlDataAdapter();
        DataTable table = new DataTable();
        void LoadData()
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from HOPDONG";
            cmd.ExecuteNonQuery();
            adap.SelectCommand = cmd;
            table.Clear();
            adap.Fill(table);
            dgvHOPDONG.DataSource = table;
        }
        public FormHOPDONG()
        {
            InitializeComponent();
        }

        private void FormHOPDONG_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "insert into HOPDONG values('"+txtMaHD.Text+ "',N'"+txtLoaiHD.Text+ "',N'"+txtGhiChu.Text+"')";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void dgvHOPDONG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvHOPDONG.CurrentRow.Index;
            txtMaHD.Text = dgvHOPDONG.Rows[i].Cells[0].Value.ToString();
            txtLoaiHD.Text = dgvHOPDONG.Rows[i].Cells[1].Value.ToString();
            txtGhiChu.Text = dgvHOPDONG.Rows[i].Cells[2].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "delete from HOPDONG where MAHD='"+txtMaHD.Text+"'";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "update HOPDONG set LOAIHD=N'"+txtLoaiHD.Text+ "',GHICHU=N'"+txtGhiChu.Text+ "'where MAHD='"+txtMaHD.Text+"'";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = "";
            txtLoaiHD.Text = "";
            txtGhiChu.Text = "";
            LoadData();
            txtMaHD.Focus();
        }
    }
}
