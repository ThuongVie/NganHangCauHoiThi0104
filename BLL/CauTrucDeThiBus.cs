using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using DAL;

namespace BLL
{
    public class CauTrucDeThiBus
    {
        CauTrucDeThiDAL cauTrucDeDal = new CauTrucDeThiDAL();
        public DataTable LoadCauTrucDeThi(long _id = 0, string _maDe="")
        {
            return cauTrucDeDal.LoadCauTrucDeThi(_id, _maDe: _maDe);
        }
        public DataTable LoadDSDeThi(DateTime _tuNgay, DateTime _denNgay, string _maKhoa, string _maMon, string _nhomCau, long _id,string _made)
        {
            return cauTrucDeDal.LoadDSDeThi( _tuNgay,  _denNgay,  _maKhoa,  _maMon,  _nhomCau,  _id, _made);
        }

        public void ThemCauTrucDe(CauTrucDeThiDTO cauTrucDeDto)
        {
            cauTrucDeDal.ThemCauTrucDeThi(cauTrucDeDto);
        }

        public long ThaoTacCauTrucDeThi_Store(CauTrucDeThiDTO cauTrucDeDto, Boolean _isSua = false)
        {
            return cauTrucDeDal.ThaoTacCauTrucDeThi_Store(cauTrucDeDto,  _isSua );
        }
        public void SuaCauTrucDe(CauTrucDeThiDTO cauTrucDeDto)
        {
            cauTrucDeDal.SuaCauTrucDeThi(cauTrucDeDto);
        }

    }
}
