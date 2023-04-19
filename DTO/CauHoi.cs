using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CauHoi
    {
        private string NhomCauHoi;
        private int IDMonHoc;
        private string FilePath;
        private byte NoiDung;

        public CauHoi(string nhomCauHoi, int iDMonHoc, string filePath)
        {
            NhomCauHoi = nhomCauHoi;
            IDMonHoc = iDMonHoc;
            FilePath = filePath;
        }

        public CauHoi(string nhomCauHoi, byte noiDung, int iDMonHoc, string filePath)
        {
            NhomCauHoi = nhomCauHoi;
            NoiDung = noiDung;
            IDMonHoc = iDMonHoc;
            FilePath = filePath;
        }

        public string NhomCauHoi1 { get => NhomCauHoi; set => NhomCauHoi = value; }
        public int IDMonHoc1 { get => IDMonHoc; set => IDMonHoc = value; }
        public string FilePath1 { get => FilePath; set => FilePath = value; }
        public byte NoiDung1 { get => NoiDung; set => NoiDung = value; }
    }
}
