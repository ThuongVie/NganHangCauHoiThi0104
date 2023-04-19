using BLL;
using DevComponents.DotNetBar.Controls;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NganHangCauHoiThi.UserControls
{
    public partial class UCNganHangDeThi : UserControl
    {
        MonHocBLL monHocBLL = new MonHocBLL();
        KhoaBLL khoaBLL = new KhoaBLL();
        NhomCauHoiBLL nhomCauHoiBLL = new NhomCauHoiBLL();
        CauTrucDeThiBus cauTrucDeBus = new CauTrucDeThiBus();

        DataTable dtNhomCau;
        DataTable dtDS;

        public string maKhoa = "", maMon = "", nhomCau = "";
        public DateTime tuNgay, denNgay;

        public UCNganHangDeThi()
        {
            InitializeComponent();
        }

        private void grpTimKiem_Click(object sender, EventArgs e)
        {

        }
        private void LoadCmb()
        {
            // Hiện thị List tên Khoa 
            cbbKhoa.DisplayMember = "TenKhoa";
            cbbKhoa.ValueMember = "MaKhoa";
            cbbKhoa.DataSource = khoaBLL.LoadKhoa();
        }

        private void UCNganHangDeThi_Load(object sender, EventArgs e)
        {
            LoadCmb();
            //dtTuNgay.Value = (tuNgay!=default(DateTime)?tuNgay: DateTime.Now);
            dtTuNgay.Value = new DateTime(2000, 1, 1);
            dtDenNgay.Value = (denNgay != default(DateTime) ? denNgay : DateTime.Now);
            cbbKhoa.SelectedValue = (maKhoa!=""?maKhoa:"");
            cbbTenMon.SelectedValue = (maMon != "" ? maMon : "");
            rtbNhomCauHoi.Text = (nhomCau != "" ? nhomCau : "");
            LoadDSDe();
        }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbTenMon.DisplayMember = "TenMon";
            cbbTenMon.ValueMember = "MaMon";

            // Lấy IDKhoa từ combobox 
            object value = cbbKhoa.SelectedValue;
            string maKhoa = Convert.ToString(value);
            // Load list môn học theo ID Khoa
            cbbTenMon.DataSource = monHocBLL.LoadMonTheoKhoa(_maKhoa: maKhoa);
        }

        private void cbbTenMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCbbNhomCauHoiTheoMon();
            cbbNhomCauHoi.SelectedValue = -1;
            cbbNhomCauHoi.SelectedIndex = -1;
        }
        private void LoadCbbNhomCauHoiTheoMon()
        {
            //cbbNhomCauHoi.Items.Clear();
            rtbNhomCauHoi.Text = string.Empty;

            // Lấy ID Mon hoc từ combobox Ten mon
            object value = cbbTenMon.SelectedValue;
            string maMon = Convert.ToString(value);
            if (maMon != null && maMon != "")
            {
                System.Data.DataTable dt = nhomCauHoiBLL.LoadNhomCauTheoMon(maMon);
                dtNhomCau = dt;

                dt.Columns.Add("Xem", typeof(string), "MaNhom + ' - ' + Diem + ' điểm - ' + ThoiGianDuKien + 'p'");

                cbbNhomCauHoi.DisplayMember = "Xem";
                cbbNhomCauHoi.ValueMember = "MaNhom";
                cbbNhomCauHoi.DataSource = dt;
            }
            else
            {
                cbbNhomCauHoi.Text = "";
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadDSDe();
        }
        private void LoadDSDe()
        {
            try
            {
                KhoiTaoGiaTri();
                dtDS = cauTrucDeBus.LoadDSDeThi(_tuNgay: dtTuNgay.Value, _denNgay: dtDenNgay.Value, _maKhoa: maKhoa, _maMon: maMon, _nhomCau: nhomCau, _id: 0,_made: "");
                grdData.DataSource = dtDS;
            }
            catch(Exception ex)
            {

            }
        }

        private void grdData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grdData.Columns["colBtnXem"].Index && e.RowIndex >= 0)
            {
                //MoDeThi();
            }
        }

        private void grdData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                MoDeThi(_stt: e.RowIndex);
            }
        }

        private void cbbNhomCauHoi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtTuNgay.Value = new DateTime(2000, 1, 1);
            dtDenNgay.Value = (denNgay != default(DateTime) ? denNgay : DateTime.Now);
            cbbKhoa.SelectedIndex = -1;
            cbbTenMon.SelectedIndex = -1;
            LoadDSDe();
        }

        private void KhoiTaoGiaTri()
        {
            try
            {
                maKhoa = (cbbKhoa.SelectedValue != null && cbbKhoa.SelectedValue != "") ? cbbKhoa.SelectedValue.ToString() : "";
                maMon = (cbbTenMon.SelectedValue != null && cbbTenMon.SelectedValue != "") ? cbbTenMon.SelectedValue.ToString() : "";
                nhomCau = (rtbNhomCauHoi.Text != null && rtbNhomCauHoi.Text != "") ? rtbNhomCauHoi.Text.ToString() : "";
            }
            catch(Exception ex)
            {

            }
        }

        private frm_TrangChu frmHome = new frm_TrangChu();
        private void MoDeThi(int _stt=0)
        {
            try
            {
                KhoiTaoGiaTri();
                UC_TaoDeThi s = new UC_TaoDeThi();
                s.maDe = dtDS.Rows[_stt][0].ToString();
                s.idDe = 0;
                s.tuNgayFind = dtTuNgay.Value;
                s.denNgayFind = dtDenNgay.Value;
                s.maKhoaFind = maKhoa;
                s.maMonFind = maMon;
                s.nhomCauFind = nhomCau;
                s.kieuLoad = 0;
                s.isXemThongKe = true;
                PluginBus.OpenForm(s);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
