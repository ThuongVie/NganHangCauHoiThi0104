using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhomCauHoiBLL
    {
        NhomCauHoiDAL nhomCauHoiDAL = new NhomCauHoiDAL();

        public DataTable LoadNhomCauHoi()
        {
            return nhomCauHoiDAL.LoadNhomCauHoi();
        }
        public DataTable LoadNhomCauHoiTheoMon(int IDMon)
        {
            return nhomCauHoiDAL.LoadNhomCauHoiTheoMon(IDMon);
        }
        public DataTable LoadNhomCauTheoMon(string _maMon)
        {
            return nhomCauHoiDAL.LoadNhomCauTheoMon(_maMon: _maMon);
        }

        public DataTable LoadNhomCauHoiTheoID(int id)
        {
            return nhomCauHoiDAL.LoadNhomCauHoiTheoID(id);
        }
        public DataTable LoadNhomCauHoiTheoDieuKien(int idKhoa, int idMon, string maNhom, int diem, int thoigiandukien, DateTime tungay, DateTime denngay)
        {
            return nhomCauHoiDAL.LoadNhomCauHoiTheoDieuKien(idKhoa, idMon, maNhom, diem, thoigiandukien, tungay, denngay);
        }
        public long ThaoTacNhomCau_Store(long idNhomCau, int idMonHoc, string maNhom, float diem, int thoiGianDuKien, string chuThich, EnumDto.eThaoTac eAction)
        {
            return nhomCauHoiDAL.ThaoTacNhomCau_Store(idNhomCau, idMonHoc,maNhom, diem, thoiGianDuKien, chuThich, eAction);
        }
    }
}
