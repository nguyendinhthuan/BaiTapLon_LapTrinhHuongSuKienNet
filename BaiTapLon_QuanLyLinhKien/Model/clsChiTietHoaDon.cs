using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_QuanLyLinhKien.Model
{
    public class clsChiTietHoaDon
    {
        private int maHoaDon;
        private string maLinhKien;
        private int soLuong;
        private double donGia;
        private string giamGia;

        public clsChiTietHoaDon()
        {
        }

        public clsChiTietHoaDon(int maHoaDon, string maLinhKien, int soLuong, double donGia, string giamGia)
        {
            this.MaHoaDon = maHoaDon;
            this.MaLinhKien = maLinhKien;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
            this.GiamGia = giamGia;
        }

        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string MaLinhKien { get => maLinhKien; set => maLinhKien = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double DonGia { get => donGia; set => donGia = value; }
        public string GiamGia { get => giamGia; set => giamGia = value; }
    }
}
