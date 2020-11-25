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
    public partial class frmLinhKien : Form
    {
        public frmLinhKien()
        {
            InitializeComponent();
        }

        DataTable tblH = new DataTable();

        DataTable tblLoaiLinhKien { get; set; }

        DataTable tblLinhKien { get; set; }

        TreeNode nodeGoc;
        Model.clsLoaiLinhKien loaiLinhKien;
        Model.clsLinhKien linhKien;

        private void frmDanhMucLinhKien_Load(object sender, EventArgs e)
        {
            string sql;

            sql = "SELECT maLoaiLinhKien, tenLoaiLinhKien from tblLoaiLinhKien";
            tblLoaiLinhKien = clsConnectDB.GetDataToTable(sql);
            cboLoaiLinhKien.DataSource = tblLoaiLinhKien;
            cboLoaiLinhKien.ValueMember = "maLoaiLinhKien"; //Trường giá trị
            cboLoaiLinhKien.DisplayMember = "tenLoaiLinhKien"; //Trường hiển thị
            
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            LoadDataGridView();
            //cboLoaiLinhKien.SelectedIndex = -1;
            ResetValues();

            nodeGoc = new TreeNode("Danh sách loại linh kiện");
            loaiLinhKien = new Model.clsLoaiLinhKien();
            linhKien = new Model.clsLinhKien();
            IEnumerable<tblLoaiLinhKien> dsLLK = loaiLinhKien.getAllLoaiLinhKien();
            LoadLoaiLinhKienVaoTreeView(treeView, dsLLK);
        }

        void LoadLoaiLinhKienVaoTreeView(TreeView treeView, IEnumerable<tblLoaiLinhKien> dsLLK)
        {
            nodeGoc.Nodes.Clear();
            TreeNode nodeCon;
            foreach (tblLoaiLinhKien llk in dsLLK)
            {
                nodeCon = new TreeNode();
                nodeCon.Text = llk.tenLoaiLinhKien;
                nodeCon.Tag = llk.maLoaiLinhKien;
                nodeGoc.Nodes.Add(nodeCon);
            }
            treeView.Nodes.Add(nodeGoc);
            treeView.ExpandAll();
        }

        private void ResetValues()
        {
            txtMaLinhKien.Text = "";
            txtMaLinhKien.Focus();
            txtTenLinhKien.Text = "";
            cboLoaiLinhKien.Text = "";
            txtDonGiaNhap.Text = "";
            txtSoLuong.Text = "";
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT tblLinhKien.maLinhKien, tblLinhKien.tenLinhKien, tblLinhKien.donGia, tblLinhKien.ngayNhap, tblLinhKien.soLuong," +
                " tblNhaCungCap.tenNhaCungCap, tblLoaiLinhKien.tenLoaiLinhKien from tblLinhKien inner join tblNhaCungCap on tblLinhKien.maNhaCungCap = tblNhaCungCap.maNhaCungCap" +
                " inner join tblLoaiLinhKien on tblLinhKien.maLoaiLinhKien = tblLoaiLinhKien.maLoaiLinhKien";
            tblH = clsConnectDB.GetDataToTable(sql);
            dgvHang.DataSource = tblH;
            dgvHang.Columns[0].HeaderText = "Mã Linh Kiện";
            dgvHang.Columns[1].HeaderText = "Tên Linh Kiện";
            dgvHang.Columns[2].HeaderText = "Đơn giá";
            dgvHang.Columns[3].HeaderText = "Ngày nhập";
            dgvHang.Columns[4].HeaderText = "Số lượng";
            dgvHang.Columns[5].HeaderText = "Nhà cung cấp";
            dgvHang.Columns[6].HeaderText = "Loại linh kiện";
            dgvHang.Columns[0].Width = 100;
            dgvHang.Columns[1].Width = 160;
            dgvHang.Columns[2].Width = 90;
            dgvHang.Columns[3].Width = 110;
            dgvHang.Columns[4].Width = 90;
            dgvHang.Columns[5].Width = 145;
            dgvHang.Columns[6].Width = 120;
            dgvHang.AllowUserToAddRows = false;
            dgvHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtMaLinhKien.Enabled = false;
            txtTenLinhKien.Focus();
            ResetValues();
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
                sql = "DELETE tblLinhKien WHERE maLinhKien=N'" + txtMaLinhKien.Text + "'";
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
                MessageBox.Show("Bạn phải nhập tên linh kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenLinhKien.Focus();
                return;
            }
            if (cboLoaiLinhKien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập loại linh kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboLoaiLinhKien.Focus();
                return;
            }
            sql = "UPDATE tblLinhKien SET tenLinhKien=N'" + txtTenLinhKien.Text.Trim().ToString() + "',maLoaiLinhKien=N'" + cboLoaiLinhKien.SelectedValue.ToString() + "',soLuong=" + txtSoLuong.Text + ",donGia=" + txtDonGiaNhap.Text +",ngayNhap='" + dtpNgayNhap.Value.ToString() + "' WHERE maLinhKien=N'" + txtMaLinhKien.Text + "'";
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            /*if (txtMaLinhKien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã linh kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLinhKien.Focus();
                return;
            }*/
            if (txtTenLinhKien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên linh kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenLinhKien.Focus();
                return;
            }
            if (cboLoaiLinhKien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn loại linh kiện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboLoaiLinhKien.Focus();
                return;
            }
            sql = "SELECT maLinhKien FROM tblLinhKien WHERE maLinhKien=N'" + txtMaLinhKien.Text.Trim() + "'";
            if (clsConnectDB.CheckKey(sql))
            {
                MessageBox.Show("Mã linh kiện này đã tồn tại, bạn phải chọn mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLinhKien.Focus();
                return;
            }
            sql = "INSERT INTO tblLinhKien(tenLinhKien,maLoaiLinhKien,soLuong,donGia,ngayNhap,maNhaCungCap) VALUES(N'" + txtTenLinhKien.Text.Trim() +"',N'" + cboLoaiLinhKien.SelectedValue.ToString() +"'," + txtSoLuong.Text.Trim() + "," + txtDonGiaNhap.Text +", '" + dtpNgayNhap.Value.ToString("yyyy/MM/dd") + "', " + 1 +")";

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

        private void dgvHang_CellClick(object sender, DataGridViewCellEventArgs e)
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
            cboLoaiLinhKien.Text = dgvHang.CurrentRow.Cells["TenLoaiLinhKien"].Value.ToString();
            txtDonGiaNhap.Text = dgvHang.CurrentRow.Cells["DonGia"].Value.ToString();
            txtSoLuong.Text = dgvHang.CurrentRow.Cells["SoLuong"].Value.ToString();
            dtpNgayNhap.Value = Convert.ToDateTime(dgvHang.CurrentRow.Cells["NgayNhap"].Value.ToString());
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMaLinhKien.Enabled = false;
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            IEnumerable<tblLinhKien> dsLK;
            string maLoaiLinhKien = "";
            if (treeView.SelectedNode != null)
            {
                if (treeView.SelectedNode.Level == 0)
                {
                    maLoaiLinhKien = "";
                }
                else
                {
                    maLoaiLinhKien = treeView.SelectedNode.Tag.ToString();
                }

                string sql;
                sql = "SELECT tblLinhKien.maLinhKien, tblLinhKien.tenLinhKien, tblLinhKien.donGia, tblLinhKien.ngayNhap, tblLinhKien.soLuong," +
                    " tblNhaCungCap.tenNhaCungCap, tblLoaiLinhKien.tenLoaiLinhKien from tblLinhKien inner join tblNhaCungCap on tblLinhKien.maNhaCungCap = tblNhaCungCap.maNhaCungCap" +
                    " inner join tblLoaiLinhKien on tblLinhKien.maLoaiLinhKien = tblLoaiLinhKien.maLoaiLinhKien where tblLoaiLinhKien.maLoaiLinhKien='" + maLoaiLinhKien + "'";
                tblH = clsConnectDB.GetDataToTable(sql);
                dgvHang.DataSource = tblH;
                dgvHang.Columns[0].HeaderText = "Mã Linh Kiện";
                dgvHang.Columns[1].HeaderText = "Tên Linh Kiện";
                dgvHang.Columns[2].HeaderText = "Đơn giá";
                dgvHang.Columns[3].HeaderText = "Ngày nhập";
                dgvHang.Columns[4].HeaderText = "Số lượng";
                dgvHang.Columns[5].HeaderText = "Nhà cung cấp";
                dgvHang.Columns[6].HeaderText = "Loại linh kiện";
                dgvHang.Columns[0].Width = 100;
                dgvHang.Columns[1].Width = 160;
                dgvHang.Columns[2].Width = 90;
                dgvHang.Columns[3].Width = 110;
                dgvHang.Columns[4].Width = 90;
                dgvHang.Columns[5].Width = 145;
                dgvHang.Columns[6].Width = 120;
                dgvHang.AllowUserToAddRows = false;
                dgvHang.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }
    }
}
