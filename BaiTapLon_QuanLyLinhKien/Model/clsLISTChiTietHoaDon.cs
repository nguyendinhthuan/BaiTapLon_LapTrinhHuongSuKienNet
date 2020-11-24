using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLon_QuanLyLinhKien.Model
{
    public class clsLISTChiTietHoaDon
    {
        ArrayList ds;

        public clsLISTChiTietHoaDon()
        {
            ds = new ArrayList();
        }

        public bool Them(clsChiTietHoaDon cthd)
        {
            if (ds.Contains(cthd))
            {
                return false;
            }
            else
            {
                ds.Add(cthd);
                return true;
            }
        }

        public ArrayList getALL()
        {
            return ds;
        }
    }
}
