using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CauTrucDeThiDTO
    {
        public long? ID { set; get; }
        public string MaDe { set; get; }
        public string TenDe { set; get; }

        public long? IDMonHoc { set; get; }
        public int? SLCauCuaNhom { set; get; }
        public int? SoLuongNhomCau { set; get; }

        public string SoDiemMoiNhomCau { set; get; }

        public string SLCauMoiNhom { set; get; }
        public int? TongThoiGianLam { set; get; }
        public int? ThoiGianDuKienMoiNhom { set; get; }
        public long? IDKhoa { set; get; }

        public string NhomCauChons { set; get; }
        public string IDCauChons { set; get; }
        public string MaKhoa { set; get; }
        public string MaMon { set; get; }
        public bool Huy { set; get; }
        public DateTime Ngay { set; get; }
    }
}
