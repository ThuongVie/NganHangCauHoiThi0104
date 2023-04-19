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
    public class MonHocBLL
    {
        MonHocDAL monHocDAL = new MonHocDAL();
        public DataTable LoadMonHoc()
        {
            return monHocDAL.LoadMonHoc();
        }
        public string CheckMaHocPhan(string maHocPhan)
        {
            return monHocDAL.CheckMaHocPhan(maHocPhan);
        }
        public DataTable LoadMonHocTheoKhoa(int IDKhoa)
        {
            return monHocDAL.LoadMonHocTheoKhoa(IDKhoa);
        }
        public DataTable LoadMonTheoKhoa(int _idKhoa = 0, string _maKhoa = "", string _maMon = "")
        {
            return monHocDAL.LoadMonTheoKhoa( _idKhoa ,  _maKhoa ,  _maMon);
        }
        public string LoadNhomCauHoiTheoMonHoc(int IDMon)
        {
            return monHocDAL.LoadNhomCauHoiTheoMonHoc(IDMon);
        }
        public string LoadChuThichTheoMonHoc (int IDMon)
        {
            return monHocDAL.LoadChuThichTheoMonHoc(IDMon);
        }
        public long ThaoTacMonHoc_Store(long idCauHoi, int idKhoa, string maMon, string tenMon, string maHocPhan, int soTinChi, string nguoiTao, EnumDto.eThaoTac eAction)
        {
            return monHocDAL.ThaoTacMonHoc_Store(idCauHoi, idKhoa, maMon, tenMon, maHocPhan, soTinChi, nguoiTao, eAction);
        }
    }
}
