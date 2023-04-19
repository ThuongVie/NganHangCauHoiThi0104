using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class NguoiDungBLL
    {
        NguoiDungDAL nguoiDungDAL = new NguoiDungDAL();

        public DataTable LoadNguoiDungTheoDieuKien_Store(int idKhoa, string maNhomNguoiSuDung, string userName, string hoTen, string email, string soDienThoai, string DiaChi)
        {
            return nguoiDungDAL.LoadNguoiDungTheoDieuKien_Store(idKhoa, maNhomNguoiSuDung, userName, hoTen, email, soDienThoai, DiaChi);
        }

        public long ThaoTacNguoiDung_Store(long idNguoiDung, int idKhoa, string userName, string hoTen, string email, string soDienThoai, string diaChi, string maNhomNguoiSuDung, string nguoiTao, string nguoiCapNhat, EnumDto.eThaoTac eAction)
        {
            return nguoiDungDAL.ThaoTacNguoiDung_Store(idNguoiDung, idKhoa, userName, hoTen, email, soDienThoai, diaChi, maNhomNguoiSuDung, nguoiTao, nguoiCapNhat, eAction);
        }

        public long DoiMatKhau_Store(long idNguoiDung, string userName, string pass)
        {
            return nguoiDungDAL.DoiMatKhau_Store(idNguoiDung, userName, pass);

        }

        public DataTable LoadNhomNguoiSuDung()
        {
            return nguoiDungDAL.LoadNhomNguoiSuDung();
        }

        public DataTable LoginUser(string username, string pass)
        {
            return nguoiDungDAL.LoginUser(username, pass);
        }

    }
}
