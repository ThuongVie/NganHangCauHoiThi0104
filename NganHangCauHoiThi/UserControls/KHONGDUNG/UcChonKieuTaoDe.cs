using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace NganHangCauHoiThi.UserControls
{
    public partial class UcChonKieuTaoDe : UserControl
    {
        public int idKhoa = 0, idMonHoc = 0, soLuongCau = 0;
        public string nhomCau = "";
        public CauTrucDeThiDTO cauTrucDeDto = new CauTrucDeThiDTO();
        public UcChonKieuTaoDe()
        {
            InitializeComponent();
        }
        private void AddUsercontrol(UserControl userControl)
        {
            //userControl.Dock = DockStyle.Fill;
            //frm_TrangChu.panelDesktop.Controls.Clear();
            //frm_TrangChu.panelDesktop.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (soLuongCau == 0)
            {
                MessageBox.Show("Chưa chọn số lượng câu.!!!");
                return;
            }
            UcLoadTaoDeThi s = new UcLoadTaoDeThi();
            s.idKhoa = idKhoa;
            s.idMonHoc = idMonHoc;
            s.nhomCau = nhomCau;
            s.soLuongCau = soLuongCau;
            s.kieuLoad = 0;
            s.cauTrucDeDto = cauTrucDeDto;
            s.Dock = DockStyle.Fill;
            //frm_TrangChu.panelDesktop.Controls.Clear();
            //frm_TrangChu.panelDesktop.Controls.Add(s);
            s.BringToFront();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            UcLoadTaoDeThi s = new UcLoadTaoDeThi();
            s.idKhoa = idKhoa;
            s.idMonHoc = idMonHoc;
            s.nhomCau = nhomCau;
            s.soLuongCau = soLuongCau;
            s.kieuLoad = 1;
            s.cauTrucDeDto = cauTrucDeDto;
            s.Dock = DockStyle.Fill;
            //frm_TrangChu.panelDesktop.Controls.Clear();
            //frm_TrangChu.panelDesktop.Controls.Add(s);
            s.BringToFront();
        }
    }
}
