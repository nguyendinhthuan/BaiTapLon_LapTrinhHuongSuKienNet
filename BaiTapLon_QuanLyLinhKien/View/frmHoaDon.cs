using BaiTapLon_QuanLyLinhKien.ConnectDatabase;
using System;
using System.Collections;
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
        Model.clsChiTietHoaDon CTHD = new Model.clsChiTietHoaDon();
        Model.clsLISTChiTietHoaDon dsCTHD = new Model.clsLISTChiTietHoaDon();

        DataTable tblChiTietHoaDon { get; set; }
        DataTable tblNhanVien { get; set; }
        DataTable tblLinhKien { get; set; }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            string str;
            string sql;
            btnThemHoaDon.Enabled = true;
            btnLuuHoaDon.Enabled = false;
            btnInHoaDon.Enabled = false;
            btnThem.Enabled = false;
            txtThanhTien.Text = "0";
            txtGiamGia.Text = "0";
            cboMaNhanVien.Enabled = false;
            cboMaKhach.Enabled = false;
            cboMaHang.Enabled = false;
            txtDiaChi.Enabled = false;
            txtSDT.Enabled = false;
            txtGhiChu.Enabled = false;
            txtDonGia.Enabled = false;
            txtThanhTien.Enabled = false;
            txtSoLuong.Enabled = false;
            txtGiamGia.Enabled = false;

            sql = "SELECT maKhachHang, tenKhachHang, diaChi FROM tblKhachHang";
            tblChiTietHoaDon = clsConnectDB.GetDataToTable(sql);
            cboMaKhach.DataSource = tblChiTietHoaDon;
            cboMaKhach.ValueMember = "maKhachHang"; //Trường giá trị
            cboMaKhach.DisplayMember = "tenKhachHang"; //Trường hiển thị
            cboMaKhach.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";

            sql = "SELECT maNhanVien, tenNhanVien FROM tblNhanVien";
            tblNhanVien = clsConnectDB.GetDataToTable(sql);
            cboMaNhanVien.DataSource = tblNhanVien;
            cboMaNhanVien.ValueMember = "maNhanVien"; //Trường giá trị
            cboMaNhanVien.DisplayMember = "tenNhanVien"; //Trường hiển thị
            cboMaNhanVien.Text = "";

            sql = "SELECT maLinhKien, tenLinhKien FROM tblLinhKien";
            tblLinhKien = clsConnectDB.GetDataToTable(sql);
            cboMaHang.DataSource = tblLinhKien;
            cboMaHang.ValueMember = "maLinhKien"; //Trường giá trị
            cboMaHang.DisplayMember = "tenLinhKien"; //Trường hiển thị
            cboMaHang.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            txtThanhTien.Text = "";
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuuHoaDon.Enabled = true;
            btnInHoaDon.Enabled = false;
            btnThemHoaDon.Enabled = false;
            cboMaNhanVien.Enabled = true;
            cboMaKhach.Enabled = true;
            cboMaHang.Enabled = true;
            txtGhiChu.Enabled = true;
            txtSoLuong.Enabled = true;
            txtGiamGia.Enabled = true;
            ResetValues();
        }
        private void ResetValues()
        {
            cboMaNhanVien.Text = "";
            cboMaKhach.Text = "";
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            string sql, sql1;
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
            // Lưu thông tin của các mặt hàng
            if ((txtSoLuong.Text.Trim().Length == 0) || (txtSoLuong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            sql = "INSERT INTO tblHoaDon(maKhachHang,maNhanVien,ngayBanHang,tongTien,ghiChu) VALUES (N'" + cboMaKhach.SelectedValue + "',N'" + cboMaNhanVien.SelectedValue + "','" + dtpNgayBan.Text.ToString() + "'," + txtTongTienHoaDon.Text.Replace(",", "") + ",N'" + txtGhiChu.Text + "')";
            clsConnectDB.RunSQL(sql);
            MessageBox.Show("Lưu thành công", "Thông báo");

            for (int i = 0; i < dgvHoaDon.Rows.Count - 1; i++)
            {
                sql1 = "INSERT INTO tblChiTietHoaDon(maHoaDon,maLinhKien,soLuong,donGia,giamGia) VALUES(" + clsConnectDB.GetFieldValues("SELECT maHoaDon FROM tblHoaDon WHERE ghiChu='" + txtGhiChu.Text + "'") + ",N'" + dgvHoaDon.Rows[i].Cells["Column1"].Value + "'," + txtSoLuong.Text + "," + txtDonGia.Text + "," + txtGiamGia.Text + ")";
                clsConnectDB.RunSQL(sql1);
            }
            ResetValuesHang();
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

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
        }

        private void frmHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetValues();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();      
        }

        private void cboMaKhach_TextChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT maKhachHang, tenKhachHang FROM tblKhachHang";
            tblChiTietHoaDon = clsConnectDB.GetDataToTable(sql);
            cboMaKhach.ValueMember = "maKhachHang"; //Trường giá trị
            cboMaKhach.DisplayMember = "tenKhachHang"; //Trường hiển thị

            sql = "SELECT diaChi FROM tblKhachHang WHERE maKhachHang = " + cboMaKhach.SelectedValue;
            txtDiaChi.Text = clsConnectDB.GetFieldValues(sql);

            sql = "SELECT soDienThoai FROM tblKhachHang WHERE maKhachHang = " + cboMaKhach.SelectedValue;
            txtSDT.Text = clsConnectDB.GetFieldValues(sql);
        }

        private void cboMaHang_TextChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT maLinhKien, tenLinhKien FROM tblLinhKien";
            tblLinhKien = clsConnectDB.GetDataToTable(sql);
            //cboMaHang.DataSource = tblLinhKien;
            cboMaHang.ValueMember = "maLinhKien"; //Trường giá trị
            cboMaHang.DisplayMember = "tenLinhKien"; //Trường hiển thị

            sql = "SELECT donGia FROM tblLinhKien WHERE maLinhKien = " + cboMaHang.SelectedValue;
            txtDonGia.Text = clsConnectDB.GetFieldValues(sql);
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon;
            sl = Convert.ToDouble(clsConnectDB.GetFieldValues("SELECT soLuong FROM tblLinhKien WHERE maLinhKien = N'" + cboMaHang.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoLuong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }

            SLcon = sl - Convert.ToDouble(txtSoLuong.Text);
            sql = "UPDATE tblLinhKien SET soLuong =" + SLcon + " WHERE maLinhKien= N'" + cboMaHang.SelectedValue + "'";
            clsConnectDB.RunSQL(sql);

            
            sql = "SELECT tenLinhKien from tblLinhKien where maLinhKien=" + cboMaHang.SelectedValue;
            AddItemToGridView(cboMaHang.SelectedValue.ToString(), clsConnectDB.GetFieldValues(sql), txtSoLuong.Text, txtDonGia.Text, txtGiamGia.Text, txtThanhTien.Text);

            int sc = dgvHoaDon.Rows.Count;
            float tongtienhoadon = 0;
            for (int i = 0; i < sc - 1; i++)
            {
                tongtienhoadon += float.Parse(dgvHoaDon.Rows[i].Cells["Column5"].Value.ToString());
            }
            txtTongTienHoaDon.Text = tongtienhoadon.ToString("#,###");
        }

        void AddItemToGridView(string malinhkien, string tenlinhkien, string soluong, string dongia, string giamgia, string thanhtien)
        {
            try
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgvHoaDon);
                newRow.Cells[0].Value = malinhkien;
                newRow.Cells[1].Value = tenlinhkien;
                newRow.Cells[2].Value = soluong;
                newRow.Cells[3].Value = dongia;
                newRow.Cells[4].Value = giamgia;
                newRow.Cells[5].Value = thanhtien;
                dgvHoaDon.Rows.Add(newRow);
            }
            catch { }
        }

        void LoadToGridView(ArrayList ALLDS)
        {
            DataGridView Items;
            foreach (Model.clsChiTietHoaDon item in ALLDS)
            {
            

            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.dgvHoaDon.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xóa linh kiện này","Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dgvHoaDon.Rows.RemoveAt(this.dgvHoaDon.SelectedRows[0].Index);
                }       
            }
            int sc = dgvHoaDon.Rows.Count;
            float tongtienhoadon = 0;
            for (int i = 0; i < sc - 1; i++)
            {
                tongtienhoadon += float.Parse(dgvHoaDon.Rows[i].Cells["Column5"].Value.ToString());
            }
            txtTongTienHoaDon.Text = tongtienhoadon.ToString("#,### VNĐ");
        }
    }
}
