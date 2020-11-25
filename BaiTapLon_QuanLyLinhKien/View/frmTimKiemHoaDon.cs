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
using BaiTapLon_QuanLyLinhKien.ConnectDatabase;

namespace BaiTapLon_QuanLyLinhKien.View
{
    public partial class frmTimKiemHoaDon : Form
    {
        public frmTimKiemHoaDon()
        {
            InitializeComponent();
        }

        DataTable tblHD;

        private void frmTimKiemLinhKienBan_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgvTimKiemHoaDon.DataSource = null;
            LoadTatCaHoaDon();
        }

        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaHoaDon.Focus();
        }

        private void txtTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaHoaDon.Text == "") &&
               (txtTenKhachHang.Text == "") && (txtTenNhanVien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblHoaDon WHERE 1=1";
            if (txtMaHoaDon.Text != "")
                sql = sql + " AND maHoaDon Like N'%" + txtMaHoaDon.Text + "%'";
            /*if (txtThang.Text != "")
                sql = sql + " AND MONTH(ngayDatHang) =" + txtThang.Text;
            if (txtNam.Text != "")
                sql = sql + " AND YEAR(ngayGiaoHang) =" + txtNam.Text;*/
            if (txtTenNhanVien.Text != "")
                sql = sql + " AND maNhanVien Like N'%" + txtTenNhanVien.Text + "%'";
            if (txtTenKhachHang.Text != "")
                sql = sql + " AND maKhachHang Like N'%" + txtTenKhachHang.Text + "%'";
            /*if (txtTongTien.Text != "")
                sql = sql + " AND tongTien <=" + txtTongTien.Text;*/
            tblHD = clsConnectDB.GetDataToTable(sql);
            if (tblHD.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblHD.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTimKiemHoaDon.DataSource = tblHD;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            dgvTimKiemHoaDon.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvTimKiemHoaDon.Columns[1].HeaderText = "Mã nhân viên";
            dgvTimKiemHoaDon.Columns[2].HeaderText = "Mã khách";
            dgvTimKiemHoaDon.Columns[3].HeaderText = "Ngày bán hàng";
            dgvTimKiemHoaDon.Columns[4].HeaderText = "Tổng tiền";
            dgvTimKiemHoaDon.Columns[5].HeaderText = "Ghi chú";
            dgvTimKiemHoaDon.Columns[0].Width = 130;
            dgvTimKiemHoaDon.Columns[1].Width = 130;
            dgvTimKiemHoaDon.Columns[2].Width = 120;
            dgvTimKiemHoaDon.Columns[3].Width = 140;
            dgvTimKiemHoaDon.Columns[4].Width = 110;
            dgvTimKiemHoaDon.Columns[5].Width = 130;
            dgvTimKiemHoaDon.AllowUserToAddRows = false;
            dgvTimKiemHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTimKiemHoaDon_DoubleClick(object sender, EventArgs e)
        {
            string ghichu;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ghichu = dgvTimKiemHoaDon.CurrentRow.Cells["ghiChu"].Value.ToString();
                frmHoaDon frm = new frmHoaDon();
                frm.txtGhiChu.Text = ghichu;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                frm.LoadInfoHoaDon();
            }
        }

        private void dgvTimKiemHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHoaDon.Text = dgvTimKiemHoaDon.CurrentRow.Cells["MaHoaDon"].Value.ToString();
            txtTenNhanVien.Text = dgvTimKiemHoaDon.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            txtTenKhachHang.Text = dgvTimKiemHoaDon.CurrentRow.Cells["MaKhachHang"].Value.ToString();
            txtNgayBanHang.Text = dgvTimKiemHoaDon.CurrentRow.Cells["NgayBanHang"].Value.ToString();
        }

        private void LoadTatCaHoaDon()
        {
            string sql;
            sql = "SELECT * FROM tblHoaDon";
            tblHD = clsConnectDB.GetDataToTable(sql);
            dgvTimKiemHoaDon.DataSource = tblHD;
            dgvTimKiemHoaDon.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvTimKiemHoaDon.Columns[1].HeaderText = "Mã Nhân Viên";
            dgvTimKiemHoaDon.Columns[2].HeaderText = "Mã Khách Hàng";
            dgvTimKiemHoaDon.Columns[3].HeaderText = "Ngày Bán Hàng";
            dgvTimKiemHoaDon.Columns[4].HeaderText = "Tổng Tiền";
            dgvTimKiemHoaDon.Columns[5].HeaderText = "Ghi Chú";
            dgvTimKiemHoaDon.Columns[0].Width = 130;
            dgvTimKiemHoaDon.Columns[1].Width = 130;
            dgvTimKiemHoaDon.Columns[2].Width = 120;
            dgvTimKiemHoaDon.Columns[3].Width = 140;
            dgvTimKiemHoaDon.Columns[4].Width = 110;
            dgvTimKiemHoaDon.Columns[5].Width = 130;
            dgvTimKiemHoaDon.AllowUserToAddRows = false;
            dgvTimKiemHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            LoadTatCaHoaDon();
        }
    }
}
