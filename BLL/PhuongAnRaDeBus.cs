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
    public class PhuongAnRaDeBus
    {
        PhuongAnRaDeDal paRaDeDal = new PhuongAnRaDeDal();

        public Object LoadPhuongAnRaDe(string _maPA = "", long _idPA = 0, Boolean _isDTO = false)
        {
            return paRaDeDal.LoadPhuongAnRaDe(_maPA, _idPA, _isDTO);
        }

        //public DataTable LoadDSPARaDe(DateTime _tuNgay, DateTime _denNgay, string _maKhoa, string _maMon, string _nhomCau, long _id, string _made)
        //{
        //    return paRaDeDal.Load(_tuNgay, _denNgay, _maKhoa, _maMon, _nhomCau, _id, _made);
        //}

        public long XuLyPhuongAnRaDe(PhuongAnRaDeDto paRaDeDto, Boolean _isSua = false, string _urlHeader = "", string _urlFooter = "")
        {
            return paRaDeDal.XuLyPARaDe(paRaDeDto, _isSua, _urlHeader, _urlFooter);
        }

        public DataTable LoadPhuongAnRaDeTheo(string maKhoa, string maMon, string maPA, string tenPA)
        {
            return paRaDeDal.LoadPhuongAnRaDeTheo(maKhoa, maMon, maPA, tenPA);
        }
    }
}
