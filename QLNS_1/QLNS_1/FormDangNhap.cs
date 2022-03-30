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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();

        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection("Data Source=IRIS;Initial Catalog=QLNS;Integrated Security=True");
            SqlDataAdapter adap = new SqlDataAdapter("select * from TAIKHOAN where TENDN=N'"+txtUser.Text+"'and MATKHAU=N'"+txtPass.Text+"'and QUYEN=N'"+cmbQuyen.Text+"'",cn);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide(); 
                if(cmbQuyen.Text=="User")
                {
                    FormTIMKIEM f = new FormTIMKIEM();
                    f.ShowDialog();
                }
                else
                {
                    FormMAIN f = new FormMAIN();
                    f.ShowDialog();
                }
                this.Show();
            }
            else
            {
                MessageBox.Show("Bạn nhập sai thông tin. Vui lòng kiểm tra lại!", "Thông báo!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có chắc muốn thoát!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
                Application.Exit();
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void cmbQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
