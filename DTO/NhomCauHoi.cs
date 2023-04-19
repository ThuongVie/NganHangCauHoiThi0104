using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhomCauHoi
    {
        private int ID;
        private string MaNhom;
        private string TenNhom;
        private int Diem;
        private int ThoiGianDuKien;
        private string ChuThich;
        private int IDMon;

        public NhomCauHoi(int iD, string maNhom, string tenNhom, int diem, int thoiGianDuKien, string chuThich, int iDMon)
        {
            ID = iD;
            MaNhom = maNhom;
            TenNhom = tenNhom;
            Diem = diem;
            ThoiGianDuKien = thoiGianDuKien;
            ChuThich = chuThich;
            IDMon = iDMon;
        }

        public int ID1 { get => ID; set => ID = value; }
        public string MaNhom1 { get => MaNhom; set => MaNhom = value; }
        public string TenNhom1 { get => TenNhom; set => TenNhom = value; }
        public int Diem1 { get => Diem; set => Diem = value; }
        public int ThoiGianDuKien1 { get => ThoiGianDuKien; set => ThoiGianDuKien = value; }
        public string ChuThich1 { get => ChuThich; set => ChuThich = value; }
        public int IDMon1 { get => IDMon; set => IDMon = value; }
    }
}
