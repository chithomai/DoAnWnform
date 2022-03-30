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
    public partial class FormNHANVIEN : Form
    {
  
        SqlConnection conn;
        SqlCommand cmd;
        string str = "Data Source=IRIS;Initial Catalog=QLNS;Integrated Security=True";
        SqlDataAdapter adap = new SqlDataAdapter();
        DataTable table = new DataTable();
        void LoadData()
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from NHANVIEN";
            cmd.ExecuteNonQuery();
            adap.SelectCommand = cmd;
            table.Clear();
            adap.Fill(table);
            dgvNHANVIEN.DataSource = table;   
        }
        void LockControl()
        {
            txtMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            cmbGioiTinh.Enabled = false;
            dtpkNgaySinh.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;
            cmbCV.Enabled = false;
            cmbHocVan.Enabled = false;
            cmbPB.Enabled = false;
            txtLuong.Enabled = false;
            cmbHD.Enabled = false;
        }
        void UnLockControl()
        {
            txtMaNV.Enabled = true;
            txtTenNV.Enabled = true;
            cmbGioiTinh.Enabled = true;
            dtpkNgaySinh.Enabled = true;
            txtSDT.Enabled = true;
            txtDiaChi.Enabled = true;
            cmbCV.Enabled = true;
            cmbHocVan.Enabled = true;
            cmbPB.Enabled = true;
            txtLuong.Enabled = true;
            cmbHD.Enabled = true;
        }

        public FormNHANVIEN()
        {
            InitializeComponent();
            getHOCVAN();
            getHOPDONG();
            getPHONGBAN();
 
        }
 
        private void getHOCVAN()
        {
            cmbHocVan.DataSource = Conect.GetData("select TENHV,MAHV  from HOCVAN");
            cmbHocVan.DisplayMember = "TENHV";
            cmbHocVan.ValueMember = "MAHV";
        }
        private void getHOPDONG()
        {
            cmbHD.DataSource = Conect.GetData("select LOAIHD, MAHD  from HOPDONG");
            cmbHD.DisplayMember = "LOAIHD";
            cmbHD.ValueMember = "MAHD";
        }
        private void getPHONGBAN()
        {
            cmbPB.DataSource = Conect.GetData("select TENPB, MAPB  from PHONGBAN");
            cmbPB.DisplayMember = "TENPB";
            cmbPB.ValueMember = "MAPB";
        }
 
        private void FormNHANVIEN_Load(object sender, EventArgs e)
        {
            //LockControl();
            conn = new SqlConnection(str);
            conn.Open();
            LoadData();
        }

        private void dgvNHANVIEN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvNHANVIEN.CurrentRow.Index;
            txtMaNV.Text = dgvNHANVIEN.Rows[i].Cells[0].Value.ToString();
            txtTenNV.Text= dgvNHANVIEN.Rows[i].Cells[1].Value.ToString();
            dtpkNgaySinh.Text= dgvNHANVIEN.Rows[i].Cells[2].Value.ToString();
            cmbGioiTinh.Text= dgvNHANVIEN.Rows[i].Cells[3].Value.ToString();
            txtDiaChi.Text= dgvNHANVIEN.Rows[i].Cells[4].Value.ToString();
            txtSDT.Text= dgvNHANVIEN.Rows[i].Cells[5].Value.ToString();
            cmbCV.Text= dgvNHANVIEN.Rows[i].Cells[6].Value.ToString();
            cmbHocVan.Text= dgvNHANVIEN.Rows[i].Cells[7].Value.ToString(); 
            cmbPB.Text= dgvNHANVIEN.Rows[i].Cells[8].Value.ToString();
            cmbHD.Text= dgvNHANVIEN.Rows[i].Cells[9].Value.ToString();
            txtLuong.Text= dgvNHANVIEN.Rows[i].Cells[10].Value.ToString();
            txtBH.Text= dgvNHANVIEN.Rows[i].Cells[11].Value.ToString();
            cmbTT.Text= dgvNHANVIEN.Rows[i].Cells[12].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMaNV.Text =="")
            {
                MessageBox.Show("Bạn chưa nhập Mã nhân viên!");
            }
            else if(txtTenNV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên!");
            }
            else if (dtpkNgaySinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày sinh nhân viên!");
            }
            else if (cmbGioiTinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giới tính nhân viên!");
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ nhân viên!");
            }
            else if (txtSDT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại nhân viên!");
            }
            else if (cmbCV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập chức vụ nhân viên!");
            }
            else if (cmbHocVan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập học vấn nhân viên!");
            }
            else if (cmbPB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên phòng ban nhân viên!");
            }
            else if (cmbHD.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập loại hợp đồng nhân viên!");
            }
            else if (txtLuong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập lương nhân viên!");
            }
            else if (txtBH.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập bảo hiểm nhân viên!");
            }
            
            else
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "insert into NHANVIEN values('" + txtMaNV.Text + "',N'" + txtTenNV.Text + "','" + dtpkNgaySinh.Text + "',N'" + cmbGioiTinh.Text + "',N'" + txtDiaChi.Text + "'," + txtSDT.Text + ",N'" + cmbCV.Text + "',N'" + cmbHocVan.Text + "',N'" + cmbPB.Text + "',N'" + cmbHD.Text + "'," + txtLuong.Text + ",N'" + txtBH.Text + "')";
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "delete from NHANVIEN where MANV='"+txtMaNV.Text+"'";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "update NHANVIEN set TENNV=N'"+txtTenNV.Text+ "',NGAYSINH=N'"+dtpkNgaySinh.Text+ "',GIOITINH=N'"+cmbGioiTinh.Text+ "',DIACHI=N'"+txtDiaChi.Text+ "',SDT='"+txtSDT.Text+ "',CHUCVU=N'"+cmbCV.Text+ "',HOCVAN=N'"+cmbHocVan.Text+ "',PHONGBAN=N'"+cmbPB.Text+ "',LOAIHD=N'"+cmbHD.Text+ "',BAOHIEM=N'" + txtBH.Text + "',LUONG=" +txtLuong.Text+  "where MANV='"+txtMaNV.Text+"'";
            cmd.ExecuteNonQuery();
            LoadData();
        }

        private void btnKhoitao_Click(object sender, EventArgs e)
        {
          
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            dtpkNgaySinh.Text = "";
            cmbGioiTinh.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";
            cmbCV.Text = "";
            cmbHocVan.Text = "";
            cmbPB.Text = "";
            cmbHD.Text = "";
            txtLuong.Text = "";
            txtBH.Text = "";
            cmbTT.Text = "";
        }
    }
}
