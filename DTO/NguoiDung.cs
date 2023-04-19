using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguoiDung
    {
        public DataTable userInfor { get; set; }
        public static int ID { get; set; }
        public static int IDKhoa { get; set; }
        public static string UserName { get; set; }
        public static string HoTen { get; set; }
        public static string ChucVu { get; set; }
        public static string Email { get; set; }
        public static string SoDienThoai { get; set; }
        public static string DiaChi { get; set; }
        public static string MaNhomNguoiSuDung { get; set; }

    }
}
