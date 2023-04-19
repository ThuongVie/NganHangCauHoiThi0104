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
  
    public class KhoaBLL
    {
        KhoaDAL khoaDAL = new KhoaDAL();
        public DataTable LoadKhoa()
        {
            return khoaDAL.LoadKhoa();
        }
        public string CheckMaKhoa(string maKhoa)
        {
            return khoaDAL.CheckMaKhoa(maKhoa);
        }
        public DataTable LoadKhoaTheo(string _maKhoa = "", int _idKhoa = 0)
        {
            return khoaDAL.LoadKhoaTheo( _maKhoa ,  _idKhoa );
        }
        public DataTable LoadKhoaTheoDieuKien(string maKhoa, string tenKhoa)
        {
            return khoaDAL.LoadKhoaTheoDieuKien(maKhoa, tenKhoa);
        }
        public long ThaoTacKhoa_Store(long idKhoa, string maKhoa, string tenKhoa, string chuThich, string nguoiTao, string nguoiCapNhat, EnumDto.eThaoTac eAction)
        {
            return khoaDAL.ThaoTacKhoa_Store( idKhoa,  maKhoa,  tenKhoa,  chuThich,nguoiTao,nguoiCapNhat, eAction);
        }

    }
}
