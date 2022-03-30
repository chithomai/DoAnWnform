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
    public partial class FormPHONGBAN : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        string str = "Data Source=IRIS;Initial Catalog=QLNS_1;Integrated Security=True";
        SqlDataAdapter adap = new SqlDataAdapter();
        DataTable table = new DataTable();
        void LoadData()
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from PHONGBAN";
            adap.SelectCommand = cmd;
            table.Clear();
            adap.Fill(table);
            dgvPHONGBAN.DataSource = table;
        }
        public FormPHONGBAN()
        {
            InitializeComponent();
        }

        private void FormPHONGBAN_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(str);
            conn.Open();
            LoadData();
        }

        private void dgvPHONGBAN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvPHONGBAN.CurrentRow.Index;
            txtMaPB.Text = dgvPHONGBAN.Rows[i].Cells[0].Value.ToString();
            txtTenPB.Text= dgvPHONGBAN.Rows[i].Cells[1].Value.ToString();
            txtDiaChi.Text= dgvPHONGBAN.Rows[i].Cells[2].Value.ToString();
            txtSDT.Text= dgvPHONGBAN.Rows[i].Cells[3].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "insert into PHONGBAN values('"+txtMaPB.Text+ "',N'"+txtTenPB.Text+ "',N'"+txtDiaChi.Text+ "',N'"+txtSDT.Text+"')";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "delete from PHONGBAN where MAPB='"+txtMaPB.Text+"'";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "update PHONGBAN set TENPB=N'"+txtTenPB.Text+ "',DIACHI=N'"+txtDiaChi.Text+ "',SDTPB=N'"+txtSDT.Text+ "'where MAPB='"+txtMaPB.Text+"'";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            txtMaPB.Text = "";
            txtTenPB.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            LoadData();
            txtMaPB.Focus();
        }
    }
}
