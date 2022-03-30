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
    public partial class FormHOCVAN : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        string str = "Data Source=IRIS;Initial Catalog=QLNS_1;Integrated Security=True";
        SqlDataAdapter adap = new SqlDataAdapter();
        DataTable table = new DataTable();
        void LoadData()
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from HOCVAN";
            cmd.ExecuteNonQuery();
            adap.SelectCommand = cmd;
            table.Clear();
            adap.Fill(table);
            dgvHOCVAN.DataSource = table;
        }
        public FormHOCVAN()
        {
            InitializeComponent();
        }

        private void FormHOCVAN_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "insert into HOCVAN values('"+txtMaHV.Text+ "',N'"+txtTenHV.Text+"')";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void dgvHOCVAN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvHOCVAN.CurrentRow.Index;
            txtMaHV.Text = dgvHOCVAN.Rows[i].Cells[0].Value.ToString();
            txtTenHV.Text = dgvHOCVAN.Rows[i].Cells[1].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "delete from HOCVAN where MAHV='"+txtMaHV.Text+"'";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "update HOCVAN set TENHV=N'"+txtTenHV.Text+ "'where MAHV='"+txtMaHV.Text+"'";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtMaHV.Text = "";
            txtTenHV.Text = "";
            txtMaHV.Focus();
            LoadData();
        }
    }
}
