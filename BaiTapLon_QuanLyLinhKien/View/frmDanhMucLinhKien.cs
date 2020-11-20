using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using BaiTapLon_QuanLyLinhKien.ConnectDatabase;

namespace BaiTapLon_QuanLyLinhKien.View
{
    public partial class frmDanhMucLinhKien : Form
    {
        public frmDanhMucLinhKien()
        {
            InitializeComponent();
        }
        DataTable tblH;
        private void frmDanhMucLinhKien_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from tblLoaiLinhKien";
            txtMaLinhKien.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
            clsConnectDB.FillCombo(sql, cboLoaiLinhKien, "maLoaiLinhKien", "tenLoaiLinhKien");
            cboLoaiLinhKien.SelectedIndex = -1;
            ResetValues();
        }
        private void ResetValues()
        {
            txtMaLinhKien.Text = "";
            txtTenLinhKien.Text = "";
            cboLoaiLinhKien.Text = "";
            txtSoLuong.Text = "0";
            txtDonGiaNhap.Text = "0";
            txtDonGiaBan.Text = "0";
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtAnh.Text = "";
            picAnh.Image = null;
            txtGhiChu.Text = "";
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblLinhKien";
            tblH = clsConnectDB.GetDataToTable(sql);
            dgvHang.DataSource = tblH;
            dgvHang.Columns[0].HeaderText = "Mã Linh Kiện";
            dgvHang.Columns[1].HeaderText = "Tên Linh Kiện";
            dgvHang.Columns[2].HeaderText = "Loại Linh Kiện";
            dgvHang.Columns[3].HeaderText = "Số lượng";
            dgvHang.Columns[4].HeaderText = "Đơn giá nhập";
            dgvHang.Columns[5].HeaderText = "Đơn giá bán";
            dgvHang.Columns[6].HeaderText = "Ảnh";
            dgvHang.Columns[7].HeaderText = "Ghi chú";
            dgvHang.Columns[0].Width = 80;
            dgvHang.Columns[1].Width = 140;
            dgvHang.Columns[2].Width = 80;
            dgvHang.Columns[3].Width = 80;
            dgvHang.Columns[4].Width = 100;
            dgvHang.Columns[5].Width = 100;
            dgvHang.Columns[6].Width = 200;
            dgvHang.Columns[7].Width = 300;
            dgvHang.AllowUserToAddRows = false;
            dgvHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaLoaiLinhKien;
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLinhKien.Focus();
                return;
            }
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaLinhKien.Text = dgvHang.CurrentRow.Cells["MaLinhKien"].Value.ToString();
            txtTenLinhKien.Text = dgvHang.CurrentRow.Cells["TenLinhKien"].Value.ToString();
            MaLoaiLinhKien = dgvHang.CurrentRow.Cells["maLoaiLinhKien"].Value.ToString();
            sql = "SELECT tenLoaiLinhKien FROM tblLoaiLinhKien WHERE maLoaiLinhKien=N'" + MaLoaiLinhKien + "'";
            cboLoaiLinhKien.Text = clsConnectDB.GetFieldValues(sql);
            txtSoLuong.Text = dgvHang.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDonGiaNhap.Text = dgvHang.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txtDonGiaBan.Text = dgvHang.CurrentRow.Cells["DonGiaBan"].Value.ToString();
            sql = "SELECT Anh FROM tblLinhKien WHERE maLinhKien=N'" + txtMaLinhKien.Text + "'";
            txtAnh.Text = clsConnectDB.GetFieldValues(sql);
            picAnh.Image = Image.FromFile(txtAnh.Text);
            sql = "SELECT ghiChu FROM tblLinhKien WHERE maLinhKien = N'" + txtMaLinhKien.Text + "'";
            txtGhiChu.Text = clsConnectDB.GetFieldValues(sql);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaLinhKien.Enabled = true;
            txtMaLinhKien.Focus();
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtDonGiaBan.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLinhKien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblHang WHERE MaHang=N'" + txtMaLinhKien.Text + "'";
                clsConnectDB.RunSqlDel(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLinhKien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLinhKien.Focus();
                return;
            }
            if (txtTenLinhKien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenLinhKien.Focus();
                return;
            }
            if (cboLoaiLinhKien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboLoaiLinhKien.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAnh.Focus();
                return;
            }
            sql = "UPDATE tblHang SET TenHang=N'" + txtTenLinhKien.Text.Trim().ToString() +
                 "',MaChatLieu=N'" + cboLoaiLinhKien.SelectedValue.ToString() +
                "',SoLuong=" + txtSoLuong.Text +
                ",Anh='" + txtAnh.Text + "',Ghichu=N'" + txtGhiChu.Text + "' WHERE MaHang=N'" + txtMaLinhKien.Text + "'";
            clsConnectDB.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaLinhKien.Enabled = false;
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaHang,TenHang,MaChatLieu,SoLuong,DonGiaNhap,DonGiaBan,Anh,Ghichu FROM tblHang";
            tblH = clsConnectDB.GetDataToTable(sql);
            dgvHang.DataSource = tblH;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaLinhKien.Text == "") && (txtTenLinhKien.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from tblLinhKien WHERE 1=1";
            if (txtMaLinhKien.Text != "")
                sql += " AND maLinhKien LIKE N'%" + txtMaLinhKien.Text + "%'";
            if (txtTenLinhKien.Text != "")
                sql += " AND tenLinhKien LIKE N'%" + txtTenLinhKien.Text + "%'";
            tblH = clsConnectDB.GetDataToTable(sql);
            if (tblH.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblH.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvHang.DataSource = tblH;
            ResetValues();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaLinhKien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLinhKien.Focus();
                return;
            }
            if (txtTenLinhKien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenLinhKien.Focus();
                return;
            }
            if (cboLoaiLinhKien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboLoaiLinhKien.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnHienThi.Focus();
                return;
            }
            sql = "SELECT MaHang FROM tblHang WHERE MaHang=N'" + txtMaLinhKien.Text.Trim() + "'";
            if (clsConnectDB.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLinhKien.Focus();
                return;
            }
            sql = "INSERT INTO tblHang(MaHang,TenHang,SoLuong,DonGiaNhap, DonGiaBan,Anh,Ghichu) VALUES(N'"
                + txtMaLinhKien.Text.Trim() + "',N'" + txtTenLinhKien.Text.Trim() +
                "',N'" + cboLoaiLinhKien.SelectedValue.ToString() +
                "'," + txtSoLuong.Text.Trim() + "," + txtDonGiaNhap.Text +
                "," + txtDonGiaBan.Text + ",'" + txtAnh.Text + "',N'" + txtGhiChu.Text.Trim() + "')";

            clsConnectDB.RunSQL(sql);
            LoadDataGridView();
            //ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaLinhKien.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }
    }
}
