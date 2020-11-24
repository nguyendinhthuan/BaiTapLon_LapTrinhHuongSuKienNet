using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_QuanLyLinhKien.Model
{
    class clsLoaiLinhKien : ConnectDatabase.clsConnectDB
    {
        qlLinhKienDataContext dt;

        public clsLoaiLinhKien()
        {
            dt = GetDataContext();
        }

        public IEnumerable<tblLoaiLinhKien> getAllLoaiLinhKien()
        {
            IEnumerable<tblLoaiLinhKien> llk = from n in dt.tblLoaiLinhKiens
                                               select n;
            return llk;
        }
    }
}
