using BaiTapLon_QuanLyLinhKien.ConnectDatabase;
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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }

        DataTable tblChiTietHoaDon { get; set; }
        DataTable tblNhanVien { get; set; }
        DataTable tblLinhKien { get; set; }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            string str;
            string sql;
            btnThemHoaDon.Enabled = true;
            btnLuuHoaDon.Enabled = false;
            btnHuyHoaDon.Enabled = false;
            btnInHoaDon.Enabled = false;
            //txtMaHoaDon.ReadOnly = true;
            //txtTenNhanVien.ReadOnly = true;
            //txtTenKhachHang.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtSDT.ReadOnly = true;
            //txtTenLinhKien.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            //txtTenKhachHang.ReadOnly = true;
            txtGiamGia.Text = "0";

            sql = "SELECT maKhachHang, tenKhachHang, diaChi, soDienThoai FROM tblKhachHang";
            tblChiTietHoaDon = clsConnectDB.GetDataToTable(sql);
            cboMaKhach.DataSource = tblChiTietHoaDon;
            cboMaKhach.ValueMember = "maKhachHang"; //Trường giá trị
            cboMaKhach.DisplayMember = "tenKhachHang"; //Trường hiển thị

            sql = "SELECT diaChi FROM tblKhachHang WHERE maKhachHang = " + cboMaKhach.ValueMember;
            txtDiaChi.Text = clsConnectDB.GetFieldValues(sql);

            sql = "SELECT maNhanVien, tenNhanVien FROM tblNhanVien";
            tblNhanVien = clsConnectDB.GetDataToTable(sql);
            cboMaNhanVien.DataSource = tblNhanVien;
            cboMaNhanVien.ValueMember = "maNhanVien"; //Trường giá trị
            cboMaNhanVien.DisplayMember = "tenNhanVien"; //Trường hiển thị

            sql = "SELECT maLinhKien, tenLinhKien FROM tblLinhKien";
            tblLinhKien = clsConnectDB.GetDataToTable(sql);
            cboMaHang.DataSource = tblLinhKien;
            cboMaHang.ValueMember = "maLinhKien"; //Trường giá trị
            cboMaHang.DisplayMember = "tenLinhKien"; //Trường hiển thị

            str = "SELECT donGia FROM tblLinhKien WHERE maLinhKien = " + cboMaHang.ValueMember;
            txtDonGia.Text = clsConnectDB.GetFieldValues(str);

            str = "SELECT soLuong FROM tblLinhKien WHERE maLinhKien = " + cboMaHang.ValueMember;
            txtSoLuong.Text = clsConnectDB.GetFieldValues(str);




            //clsConnectDB.FillCombo("SELECT maKhachHang, tenKhachHang FROM tblKhachHang", cboMaKhach, "maKhachHang", "maKhachHang");
            //cboMaKhach.SelectedIndex = -1;
            //clsConnectDB.FillCombo("SELECT maNhanVien, tenNhanVien FROM tblNhanVien", cboMaNhanVien, "maNhanVien", "tenNhanVien");
            //cboMaNhanVien.SelectedIndex = -1;
            //clsConnectDB.FillCombo("SELECT maLinhKien, tenLinhKien FROM tblLinhKien", cboMaHang, "maKhachHang", "maKhachHang");
            //cboMaHang.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            /*if (txtMaHoaDon.Text != "")
            {
                LoadInfoHoaDon();
                btnHuyHoaDon.Enabled = true;
                btnInHoaDon.Enabled = true;
            }*/
            LoadDataGridView();
        }
        void LoadDataGridView()
        {
            /*string sql;
            sql = "SELECT tenLinhKien FROM tblLinhKien";
            tblChiTietHoaDon = clsConnectDB.GetDataToTable(sql);
            dgvHoaDon.DataSource = tblChiTietHoaDon;
            dgvHoaDon.Columns[0].HeaderText = "Mã hàng";
            dgvHoaDon.Columns[1].HeaderText = "Tên hàng";
            dgvHoaDon.Columns[2].HeaderText = "Đơn giá";
            dgvHoaDon.Columns[3].HeaderText = "Giảm giá %";
            dgvHoaDon.Columns[4].HeaderText = "Thành tiền";
            dgvHoaDon.Columns[0].Width = 80;
            dgvHoaDon.Columns[1].Width = 130;
            dgvHoaDon.Columns[2].Width = 90;
            dgvHoaDon.Columns[3].Width = 90;
            dgvHoaDon.Columns[4].Width = 90;
            dgvHoaDon.AllowUserToAddRows = false;
            dgvHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;*/

        }
        void LoadInfoHoaDon()
        {
            //string str;
            /*str = "SELECT ngayBan FROM tblHDBan WHERE maHoaDon = N'" + txtMaHoaDon.Text + "'";
            txtNgayBan.Text = clsConnectDB.ConvertDateTime(clsConnectDB.GetFieldValues(str));
            str = "SELECT maLianVien FROM tblHoaDon WHERE maHoaDon = N'" + txtMaHoaDon.Text + "'";
            cboMaNhanVien.Text = clsConnectDB.GetFieldValues(str);
            str = "SELECT maNhachHang FROM tblHoaDon WHERE maHoaDon = N'" + txtMaHoaDon.Text + "'";
            cboMaKhach.Text = clsConnectDB.GetFieldValues(str);
            str = "SELECT tongTien FROM tblHoaDon WHERE maHoaDon = N'" + txtMaHoaDon.Text + "'";
            txtTongTienHoaDon.Text = clsConnectDB.GetFieldValues(str);
            lblBangChu.Text = "Bằng chữ: " + clsConnectDB.ChuyenSoSangChu(txtMaHoaDon.Text);*/
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            btnHuyHoaDon.Enabled = false;
            btnLuuHoaDon.Enabled = true;
            btnInHoaDon.Enabled = false;
            btnThemHoaDon.Enabled = false;
            ResetValues();
            //txtMaHoaDon.Text = clsConnectDB.CreateKey("HDB");
            LoadDataGridView();
        }
        private void ResetValues()
        {
            //txtMaHoaDon.Text = "";
            txtNgayBan.Text = "";
            txtNgayBan.Text = DateTime.Now.ToShortDateString();
            cboMaNhanVien.Text = "";
            cboMaKhach.Text = "";
            //txtTenKhachHang.Text = "0";
            lblBangChu.Text = "Bằng chữ: ";
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            //sql = "SELECT maHoaDon FROM tblHoaDon WHERE maHoaDon=N'" + txtMaHoaDon.Text + "'";
            //if (!clsConnectDB.CheckKey(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (txtNgayBan.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNgayBan.Focus();
                    return;
                }
                if (cboMaNhanVien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaNhanVien.Focus();
                    return;
                }
                if (cboMaKhach.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaKhach.Focus();
                    return;
                }
                /*sql = "INSERT INTO tblHoaDon(maHoaDon, maNhachHang, maLianVien, maKhnhKien, ngayBan, noiNhan,tongTien,ghiChu,trangThai) VALUES (N'" + txtMaHoaDon.Text.Trim() + "','" +
                        "',N'" + cboMaKhach.SelectedValue +
                        "',N'" + cboMaNhanVien.SelectedValue +
                        "',N'" + cboMaHang.SelectedValue +
                        clsConnectDB.ConvertDateTime(txtNgayBan.Text.Trim()) + "'," + txtDiaChi.Text.ToString() + "'," +
                        txtTongTienHoaDon.Text.ToString() + "'," + txtTongTienHoaDon.Text + "'," + txtGhiChu.Text + "'," + txtTrangThai.Text + ")";
                clsConnectDB.RunSQL(sql);*/
            }
            // Lưu thông tin của các mặt hàng
            if (cboMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHang.Focus();
                return;
            }
            if ((txtSoLuong.Text.Trim().Length == 0) || (txtSoLuong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            if (txtGiamGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamGia.Focus();
                return;
            }
            /*sql = "SELECT maLinhKien FROM tblChiTietHDBan WHERE maLinhKien=N'" + cboMaHang.SelectedValue + "' AND maHoaDon = N'" + txtMaHoaDon.Text.Trim() + "'";
            if (clsConnectDB.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cboMaHang.Focus();
                return;
            }*/
            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(clsConnectDB.GetFieldValues("SELECT soLuong FROM tblLinhKien WHERE maLinhKien = N'" + cboMaHang.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoLuong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            /*sql = "INSERT INTO tblChiTietHDBan(MaHDBan,MaHang,SoLuong,DonGia, GiamGia,ThanhTien) VALUES(N'" + txtMaHoaDon.Text.Trim() + "',N'" + cboMaHang.SelectedValue + "'," + txtSoLuong.Text + "," + txtDonGia.Text + "," + txtGiamGia.Text + "," + txtThanhTien.Text + ")";
            clsConnectDB.RunSQL(sql);*/
            LoadDataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txtSoLuong.Text);
            sql = "UPDATE tblHang SET SoLuong =" + SLcon + " WHERE MaHang= N'" + cboMaHang.SelectedValue + "'";
            clsConnectDB.RunSQL(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán
            /*tong = Convert.ToDouble(clsConnectDB.GetFieldValues("SELECT TongTien FROM tblHDBan WHERE MaHDBan = N'" + txtMaHoaDon.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhTien.Text);*/
            /*sql = "UPDATE tblHDBan SET TongTien =" + Tongmoi + " WHERE MaHDBan = N'" + txtMaHoaDon.Text + "'";
            clsConnectDB.RunSQL(sql);*/
            /*txtTongTienHoaDon.Text = Tongmoi.ToString();
            lblBangChu.Text = "Bằng chữ: " + clsConnectDB.ChuyenSoSangChu(Tongmoi.ToString());*/
            ResetValuesHang();
            btnHuyHoaDon.Enabled = true;
            btnThemHoaDon.Enabled = true;
            btnInHoaDon.Enabled = true;
        }
        private void ResetValuesHang()
        {
            cboMaHang.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
        }

        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            /*double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MaHang,SoLuong FROM tblChiTietHDBan WHERE MaHDBan = N'" + txtMaHoaDon.Text + "'";
                DataTable tblHang = clsConnectDB.GetDataToTable(sql);
                for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(clsConnectDB.GetFieldValues("SELECT SoLuong FROM tblHang WHERE MaHang = N'" + tblHang.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
                    slcon = sl + slxoa;
                    sql = "UPDATE tblLinhKien SET SoLuong =" + slcon + " WHERE MaHang= N'" + tblHang.Rows[hang][0].ToString() + "'";
                    clsConnectDB.RunSQL(sql);
                }

                //Xóa chi tiết hóa đơn
                sql = "DELETE tblChiTietHoaDon WHERE MaHoaDon=N'" + txtMaHoaDon.Text + "'";
                clsConnectDB.RunSqlDel(sql);

                //Xóa hóa đơn
                sql = "DELETE tblHoaDon WHERE MaHoaDon=N'" + txtMaHoaDon.Text + "'";
                clsConnectDB.RunSqlDel(sql);
                ResetValues();
                LoadDataGridView();
                btnHuyHoaDon.Enabled = false;
                btnInHoaDon.Enabled = false;
            }*/
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
        }

        private void btnTimHoaDon_Click(object sender, EventArgs e)
        {
            if (cboMaHDBan.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHDBan.Focus();
                return;
            }
            //txtMaHoaDon.Text = cboMaHDBan.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnHuyHoaDon.Enabled = true;
            btnLuuHoaDon.Enabled = true;
            btnInHoaDon.Enabled = true;
            cboMaHDBan.SelectedIndex = -1;
        }

        private void cboMaHDBan_DropDown(object sender, EventArgs e)
        {
            clsConnectDB.FillCombo("SELECT maHoaDon FROM tblHoaDon", cboMaHDBan, "maHoaDon", "maHoaDon");
            cboMaHDBan.SelectedIndex = -1;
        }

        private void frmHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetValues();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
