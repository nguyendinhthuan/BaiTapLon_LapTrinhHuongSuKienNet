namespace BaiTapLon_QuanLyLinhKien.View
{
    partial class frmKhachHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhachHang));
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiaChiKhach = new System.Windows.Forms.TextBox();
            this.txtMaKhachHang = new System.Windows.Forms.TextBox();
            this.txtSDTKhachHang = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmailKhachHang = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtSoDienThoaiKhach = new System.Windows.Forms.TextBox();
            this.txtDiaChiKhachHang = new System.Windows.Forms.Label();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHang.Location = new System.Drawing.Point(33, 255);
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.RowHeadersWidth = 51;
            this.dgvKhachHang.Size = new System.Drawing.Size(875, 118);
            this.dgvKhachHang.TabIndex = 8;
            this.dgvKhachHang.Click += new System.EventHandler(this.dgvKhachHang_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDiaChiKhach);
            this.panel1.Controls.Add(this.txtMaKhachHang);
            this.panel1.Controls.Add(this.txtSDTKhachHang);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtEmailKhachHang);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtSoDienThoaiKhach);
            this.panel1.Controls.Add(this.txtDiaChiKhachHang);
            this.panel1.Controls.Add(this.txtTenKhachHang);
            this.panel1.Location = new System.Drawing.Point(26, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 213);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(205, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH MỤC KHÁCH HÀNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Khách Hàng :";
            // 
            // txtDiaChiKhach
            // 
            this.txtDiaChiKhach.Location = new System.Drawing.Point(578, 66);
            this.txtDiaChiKhach.Name = "txtDiaChiKhach";
            this.txtDiaChiKhach.Size = new System.Drawing.Size(181, 30);
            this.txtDiaChiKhach.TabIndex = 2;
            // 
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.Location = new System.Drawing.Point(191, 63);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.Size = new System.Drawing.Size(181, 30);
            this.txtMaKhachHang.TabIndex = 2;
            // 
            // txtSDTKhachHang
            // 
            this.txtSDTKhachHang.AutoSize = true;
            this.txtSDTKhachHang.Location = new System.Drawing.Point(419, 122);
            this.txtSDTKhachHang.Name = "txtSDTKhachHang";
            this.txtSDTKhachHang.Size = new System.Drawing.Size(153, 25);
            this.txtSDTKhachHang.TabIndex = 1;
            this.txtSDTKhachHang.Text = "Số Điện Thoại : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tên Khách Hàng :";
            // 
            // txtEmailKhachHang
            // 
            this.txtEmailKhachHang.AutoSize = true;
            this.txtEmailKhachHang.Location = new System.Drawing.Point(20, 172);
            this.txtEmailKhachHang.Name = "txtEmailKhachHang";
            this.txtEmailKhachHang.Size = new System.Drawing.Size(76, 25);
            this.txtEmailKhachHang.TabIndex = 1;
            this.txtEmailKhachHang.Text = "Email : ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(193, 169);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(181, 30);
            this.txtEmail.TabIndex = 2;
            // 
            // txtSoDienThoaiKhach
            // 
            this.txtSoDienThoaiKhach.Location = new System.Drawing.Point(578, 120);
            this.txtSoDienThoaiKhach.Name = "txtSoDienThoaiKhach";
            this.txtSoDienThoaiKhach.Size = new System.Drawing.Size(181, 30);
            this.txtSoDienThoaiKhach.TabIndex = 2;
            // 
            // txtDiaChiKhachHang
            // 
            this.txtDiaChiKhachHang.AutoSize = true;
            this.txtDiaChiKhachHang.Location = new System.Drawing.Point(419, 66);
            this.txtDiaChiKhachHang.Name = "txtDiaChiKhachHang";
            this.txtDiaChiKhachHang.Size = new System.Drawing.Size(92, 25);
            this.txtDiaChiKhachHang.TabIndex = 1;
            this.txtDiaChiKhachHang.Text = "Địa Chỉ : ";
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Location = new System.Drawing.Point(193, 119);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(181, 30);
            this.txtTenKhachHang.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDong);
            this.panel2.Controls.Add(this.btnBoQua);
            this.panel2.Controls.Add(this.btnLuu);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Location = new System.Drawing.Point(26, 391);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(882, 100);
            this.panel2.TabIndex = 9;
            // 
            // btnDong
            // 
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(762, 30);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(103, 40);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "&Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Image = ((System.Drawing.Image)(resources.GetObject("btnBoQua.Image")));
            this.btnBoQua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBoQua.Location = new System.Drawing.Point(611, 30);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(111, 40);
            this.btnBoQua.TabIndex = 7;
            this.btnBoQua.Text = "&Bỏ Qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(461, 30);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(111, 40);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(312, 30);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 40);
            this.btnSua.TabIndex = 9;
            this.btnSua.Text = "&Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(174, 30);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(104, 40);
            this.btnXoa.TabIndex = 10;
            this.btnXoa.Text = "&Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(25, 30);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(114, 40);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "&Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 503);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvKhachHang);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmKhachHang";
            this.Text = "KhachHang";
            this.Load += new System.EventHandler(this.frmKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaKhachHang;
        private System.Windows.Forms.Label txtSDTKhachHang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtDiaChiKhachHang;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.Label txtEmailKhachHang;
        private System.Windows.Forms.TextBox txtDiaChiKhach;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtSoDienThoaiKhach;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
    }
}