using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhuongAnRaDeDto
    {
        public long? ID { set; get; }
        public string MaPA { set; get; }
        public string TenPA { set; get; }
        public string MaKhoa { set; get; }
        public string MaMon { set; get; }
        public string NhomCaus { set; get; }
        public string CreatedBy { set; get; }
        public DateTime CreatedDate { set; get; }
        public string UpdatedBy { set; get; }
        public DateTime UpdatedDate { set; get; }
        public Boolean Huy { set; get; }
        public string GhiChu { set; get; }
        public string UrlHeader { set; get; }
        public string UrlFooter { set; get; }

    }
}
