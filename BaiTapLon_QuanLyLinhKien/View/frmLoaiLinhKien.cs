﻿using System;
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
    public partial class frmLoaiLinhKien : Form
    {
        public frmLoaiLinhKien()
        {
            InitializeComponent();
        }
        DataTable tblLLK;
        private void frmLoaiLinhKien_Load(object sender, EventArgs e)
        {
            txtMaLinhKien.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT maLoaiLinhKien, tenLoaiLinhKien FROM tblLoaiLinhKien";
            tblLLK = clsConnectDB.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvLoaiLinhKien.DataSource = tblLLK; //Nguồn dữ liệu            
            dgvLoaiLinhKien.Columns[0].HeaderText = "Mã";
            dgvLoaiLinhKien.Columns[1].HeaderText = "Tên";
            dgvLoaiLinhKien.Columns[0].Width = 100;
            dgvLoaiLinhKien.Columns[1].Width = 340;
            dgvLoaiLinhKien.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvLoaiLinhKien.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaLinhKien.Enabled = true;
            ResetValue(); //Xoá trắng các textbox
        }
        private void ResetValue()
        {
            txtMaLinhKien.Text = "";
            txtTenLinhKien.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtMaLinhKien.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã loại linh kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLinhKien.Focus();
                return;
            }
            if (txtTenLinhKien.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên loại linh kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenLinhKien.Focus();
                return;
            }
            sql = "Select maLoaiLinhKien From tblLoaiLinhKien where maLoaiLinhKien = N'" + txtMaLinhKien.Text.Trim() + "'";
            if (clsConnectDB.CheckKey(sql))
            {
                MessageBox.Show("Mã loại linh kiện này đã tồn tại, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLinhKien.Focus();
                return;
            }

            sql = "INSERT INTO tblLoaiLinhKien VALUES(N'" + txtMaLinhKien.Text + "',N'" + txtTenLinhKien.Text + "')";
            clsConnectDB.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaLinhKien.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (tblLLK.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLinhKien.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenLinhKien.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên loại linh kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE tblLoaiLinhKien SET tenLoaiLinhKien=N'" +
                txtTenLinhKien.Text.ToString() +
                "' WHERE maLoaiLinhKien=N'" + txtMaLinhKien.Text + "'";
            clsConnectDB.RunSQL(sql);
            LoadDataGridView();
            ResetValue();

            btnBoQua.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblLLK.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLinhKien.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblLoaiLinhKien WHERE maLoaiLinhKien=N'" + txtMaLinhKien.Text + "'";
                clsConnectDB.RunSqlDel(sql);
                LoadDataGridView();
                ResetValue();
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaLinhKien.Enabled = false;
        }
        private void txtMaLinhKien_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLoaiLinhKien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLinhKien.Focus();
                return;
            }
            if (tblLLK.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaLinhKien.Text = dgvLoaiLinhKien.CurrentRow.Cells["maLoaiLinhKien"].Value.ToString();
            txtTenLinhKien.Text = dgvLoaiLinhKien.CurrentRow.Cells["tenLoaiLinhKien"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }
    }
}
