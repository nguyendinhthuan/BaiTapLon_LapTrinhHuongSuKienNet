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


namespace BaiTapLon_QuanLyLinhKien.View
{
    public partial class frmDangNhap : Form
    {
        
        public frmDangNhap()
        {
            InitializeComponent();
        }
       

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=LAPTOP-A77BJ5G6\SQLEXPRESS;Initial Catalog=QuanLyLinhKien;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("select * from [dbo].[tblTaiKhoan] where [tenTaiKhoan] =  N'" +txtTaiKhoan.Text+ "' and [matKhau] = N'" +txtMatKhau.Text+"'",cn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                frmMain fmain = new frmMain(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString());
                fmain.Show();
            }
            else
            {
                lblCorrect.Text = "Nhập sai tên tài khoản và mật khẩu";
                txtTaiKhoan.Text = "";
                txtMatKhau.Text = "";
                txtTaiKhoan.Focus();
            }

            
        }

        private void ckbShowMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowMatKhau.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;

            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }
    }
}
