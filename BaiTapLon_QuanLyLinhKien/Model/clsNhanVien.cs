using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_QuanLyLinhKien.Model
{
    class clsNhanVien
    {
        private string maNhanVien;
        private string tenNhanVien;
        private string diaChi;
        private string soDienThoai;

        public string MaNhanVien { get => maNhanVien;
            set
            {
                if(value == "")
                {
                    throw new Exception("Phải nhập mã");
                }
                else
                {
                    maNhanVien = value;
                }
            }
        }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }

        public override bool Equals(object obj)
        {
            clsNhanVien objNhanVien = (clsNhanVien)obj;
            return this.MaNhanVien.Equals(objNhanVien.maNhanVien);
        }

        public clsNhanVien(string maNhanVien, string tenNhanVien, string diaChi, string soDienThoai)
        {
            this.MaNhanVien = maNhanVien;
            this.TenNhanVien = tenNhanVien;
            this.DiaChi = diaChi;
            this.SoDienThoai = soDienThoai;
        }

        public clsNhanVien()
        {

        }

    }
}
