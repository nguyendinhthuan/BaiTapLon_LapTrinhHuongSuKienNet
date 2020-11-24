using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_QuanLyLinhKien.Model
{
    class clsLinhKien : ConnectDatabase.clsConnectDB
    {
        qlLinhKienDataContext dt;

        public clsLinhKien()
        {
            dt = GetDataContext();
        }

        public IEnumerable<tblLinhKien> getLinhKienThuocLoaiLinhKien(string maLoaiLinhKien)
        {
            IEnumerable<tblLinhKien> lk;
            if (maLoaiLinhKien.Equals(""))
            {
                lk = from n in dt.tblLinhKiens
                     select n;
            }
            else
            {
                lk = from n in dt.tblLinhKiens
                     where n.maLoaiLinhKien.Equals(maLoaiLinhKien)
                     select n;
            }
            return lk;
        }
    }
}
