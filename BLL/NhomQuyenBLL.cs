using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class NhomQuyenBLL
    {
        NhomQuyenDAL nhomQuyenDAL = new NhomQuyenDAL();
        public DataTable LoadPhanQuyenForm()
        {
            return nhomQuyenDAL.LoadPhanQuyenForm();
        }

        public long ThaoTacNhomQuyen_Store(long idNhomQuyen, string maNhomNguoiSuDung, string maForm, string quyen, string chuThich, EnumDto.eThaoTac eAction)
        {
            return nhomQuyenDAL.ThaoTacNhomQuyen_Store(idNhomQuyen, maNhomNguoiSuDung, maForm, quyen, chuThich, eAction);
        }

        public DataTable LoadNhomQuyenTheoDieuKien(string maNhomNguoiSuDung, string maForm)
        {
            return nhomQuyenDAL.LoadNhomQuyenTheoDieuKien(maNhomNguoiSuDung, maForm);
        }
         
    }
}
