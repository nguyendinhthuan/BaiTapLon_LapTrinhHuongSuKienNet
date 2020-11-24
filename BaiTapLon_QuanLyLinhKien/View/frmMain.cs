using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon_QuanLyLinhKien.View
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            statusStrip1.Items[2].Text = "Ngày: " + DateTime.Now.ToString("dd/MM/yyyy");
            statusStrip1.Items[3].Text = "Giờ: " + DateTime.Now.ToString("hh:mm tt");
        }

        private void mnuTimKiem_Click(object sender, EventArgs e)
        {
            frmTimKiemHoaDon frm = new frmTimKiemHoaDon();
            frm.Show();
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon();
            frm.Show();
        }

        private void mnuDanhMucLoaiLinhKien_Click(object sender, EventArgs e)
        {
            frmLoaiLinhKien frm = new frmLoaiLinhKien();
            frm.Show();
        }

        private void mnuDanhMucNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.Show();
        }

        private void mnuDanhMucHangHoa_Click(object sender, EventArgs e)
        {
            frmLinhKien frm = new frmLinhKien();
            frm.Show();
        }

        private void mnuDanhMucKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.Show();
        }

        private void mnuChucNangThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
