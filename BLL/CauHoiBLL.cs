using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace BLL
{
    public class CauHoiBLL
    {
        CauHoiDAL cauHoiDAL= new CauHoiDAL();

        public DataTable LoadCauHoi()
        {
            return cauHoiDAL.LoadCauHoi();
        }

        public void ThemCauHoi(string NhomCauHoi, int IDMonHoc, string FilePath)
        {
            cauHoiDAL.ThemCauHoi(new CauHoi(NhomCauHoi, IDMonHoc, FilePath));
        }

        public DataTable LoadCauHoiStore()
        {
            return cauHoiDAL.LoadCauHoiStore();
        }
        public DataTable LoadCauHoiTaoDeThi(int _idKhoa, int _idMonHoc, string _nhomCau, int _soLuongCau, int _kieuLoad=0, string _maKhoa = "", string _maMon = "", string _listIDCau = "")
        {
            return cauHoiDAL.LoadCauHoiTaoDeThi(_idKhoa,  _idMonHoc,  _nhomCau,  _soLuongCau, _kieuLoad, _maKhoa, _maMon,  _listIDCau);
        }

        // NEW
        public DataTable LoadCauHoiTheoNhomCauHoi(int idMon, string nhomCauHoi)
        {
            return cauHoiDAL.LoadCauHoiTheoNhomCauHoi(idMon, nhomCauHoi);
        }

        public DataTable LoadCauHoiTheoMonHoc(int idMonHoc)
        {
            return cauHoiDAL.LoadCauHoiTheoMonHoc(idMonHoc);
        }

        public DataTable LoadCauHoiTheoKhoa(int idKhoa)
        {
            return cauHoiDAL.LoadCauHoiTheoKhoa(idKhoa);
        }

        public DataTable GetCauHoiById(long idCauhoi)
        {
            return cauHoiDAL.GetCauHoiById(idCauhoi);
        }

        public DataTable GetMonHocById(int idMonHoc)
        {
            return cauHoiDAL.GetMonHocById(idMonHoc);
        }

        public DataTable GetKhoaByIdMon(int idMonHoc)
        {
            return cauHoiDAL.GetKhoaByIdMon(idMonHoc);
        }

        public DataTable LoadCauHoiTheoDieuKien(int idKhoa, int idMonHoc, string nhomCauHoi, string maCauHoi)
        {
            return cauHoiDAL.LoadCauHoiTheoDieuKien(idKhoa, idMonHoc, nhomCauHoi, maCauHoi);
        }

        public byte[] GetNoiDungCauHoi(long idCauHoi)
        {
            return cauHoiDAL.GetNoiDungCauHoi(idCauHoi);
        }
        public DataTable LoadCauHoiTheoDieuKien(int idKhoa, int idMonHoc, string nhomCauHoi, string maCauHoi, DateTime tungay, DateTime denngay)
        {
            return cauHoiDAL.LoadCauHoiTheoDieuKien(idKhoa, idMonHoc, nhomCauHoi, maCauHoi, tungay, denngay);
        }

        public DataTable LoadMonHocTheoDieuKien(int idKhoa, string maMon, string tenMon, string maHocPhan, int soTinChi, DateTime tungay, DateTime denngay)
        {
            return cauHoiDAL.LoadMonHocTheoDieuKien(idKhoa, maMon, tenMon, maHocPhan, soTinChi, tungay, denngay);
        }

        public long ThaoTacCauHoi_Store(long _idCauHoi, string _maCau, string _nhomCau, int _idMon, string _fitlePath, string nguoiTao, EnumDto.eThaoTac eAction)
        {
            return cauHoiDAL.ThaoTacCauHoi_Store(_idCauHoi, _maCau, _nhomCau, _idMon, _fitlePath, nguoiTao, eAction);
        }

    }
}
