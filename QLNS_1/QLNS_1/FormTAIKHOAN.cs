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
    public partial class FormTAIKHOAN : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        string str = "Data Source=IRIS;Initial Catalog=QLNS_1;Integrated Security=True";
        SqlDataAdapter adap = new SqlDataAdapter();
        DataTable table = new DataTable();
        void LoadData()
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from TAIKHOAN";
            cmd.ExecuteNonQuery();
            adap.SelectCommand = cmd;
            table.Clear();
            adap.Fill(table);
            dgvTAIKHOAN.DataSource = table;
        }
        public FormTAIKHOAN()
        {
            InitializeComponent();
        }

        private void FormTAIKHOAN_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "insert into TAIKHOAN values('"+txtTenTK.Text+ "','"+txtMatkhau.Text+"')";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void dgvTAIKHOAN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvTAIKHOAN.CurrentRow.Index;
            txtTenTK.Text = dgvTAIKHOAN.Rows[i].Cells[0].Value.ToString();
            txtMatkhau.Text = dgvTAIKHOAN.Rows[i].Cells[1].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "delete from TAIKHOAN where TAIKHOAN='"+txtTenTK.Text+"'";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "update TAIKHOAN set MATKHAU='"+txtMatkhau.Text+ "'where TAIKHOAN='"+txtTenTK.Text+"'";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtTenTK.Text = "";
            txtMatkhau.Text = "";
            LoadData();
        }
    }
}
