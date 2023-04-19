using BLL;
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
    public partial class UcPhuongAnDeThi : UserControl
    {
        MonHocBLL monHocBLL = new MonHocBLL();
        KhoaBLL khoaBLL = new KhoaBLL();
        NhomCauHoiBLL nhomCauHoiBLL = new NhomCauHoiBLL();
        PhuongAnRaDeBus paRaDeBus = new PhuongAnRaDeBus();
        PhuongAnRaDeDto paRaDeDto = new PhuongAnRaDeDto();

        DataTable dtNhomCau;
        DataTable dtDS;
        public int totalDiem = 0;

        List<string> lstNhomCau = new List<string>();
        List<string> lstNhomCauDaChon = new List<string>();
        List<string> lstNhomCauSelect = new List<string>();
        List<int> lstIDCauHoi = new List<int>();
        List<int> lstIDCauHoiUsed = new List<int>();
        List<int> lstDiemDaChon = new List<int>();

        public Boolean isOpenFast = false;

        public string maKhoa = "", maMon = "", nhomCau = "";
        public DateTime tuNgay, denNgay;
        private long idPhuongAnRaDe = 0;
        private int  soLuongCau = 0,tongDiemChon = 0;

        private Boolean isSua = false,isEndLoadForm=false;
        public UcPhuongAnDeThi()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbTenMon.DisplayMember = "TenMon";
            cbbTenMon.ValueMember = "MaMon";

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

        private void txtMaDe_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenDe_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXoaNhomCauVuaChon_Click(object sender, EventArgs e)
        {
            cbbNhomCauHoi.SelectedValue = "";
            totalDiem = 0;
            LoadCbbNhomCauHoiTheoMon();
            rtbNhomCauHoi.Clear();
            txtTongDiem.Text = string.Empty;
            //lblThongBao.Text = "(*) Tổng điểm phải bằng 10";
        }

        private void btnRandomNhomCau_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private Boolean CheckValidate()
        {
            tongDiemChon = Convert.ToInt32( (txtTongDiem.Text == "" ? "0" : txtTongDiem.Text));
            if (tongDiemChon != 10)
            {
                MessageBox.Show("Tổng điểm = 10 .!!!");
                return false;
            }
            if (!isSua)
            {
                PhuongAnRaDeDto paDtoCheck = (PhuongAnRaDeDto)paRaDeBus.LoadPhuongAnRaDe(_maPA: txtMaPA.Text, _isDTO: true);
                if (paDtoCheck!=null && paDtoCheck.ID > 0)
                {
                    MessageBox.Show("Mã phương án đã được sử dụng.!!!");
                    return false;
                }    
            }    
            return true;
        }
        private void SetPhuongAnDTO()
        {
            try
            {
                paRaDeDto = (PhuongAnRaDeDto)paRaDeBus.LoadPhuongAnRaDe(_maPA: txtMaPA.Text, _isDTO: true);
                if (paRaDeDto != null && paRaDeDto.ID > 0)
                {
                    isSua = true;
                    paRaDeDto.ID = idPhuongAnRaDe;
                }
                else
                {
                    paRaDeDto = new PhuongAnRaDeDto();
                }
                paRaDeDto.MaPA = txtMaPA.Text;
                paRaDeDto.TenPA = txtTenPA.Text;
                paRaDeDto.MaKhoa = cbbKhoa.SelectedValue.ToString();
                paRaDeDto.MaMon = cbbTenMon.SelectedValue.ToString();
                paRaDeDto.NhomCaus = rtbNhomCauHoi.Text.Replace(" ", ";");
                if (!isSua)
                {
                    paRaDeDto.CreatedBy = (cmbNguoiTao.SelectedValue != null ? cmbNguoiTao.SelectedValue.ToString() : "");
                    paRaDeDto.CreatedDate = dtNgay.Value;
                }
                else
                {
                    paRaDeDto.UpdatedBy = (cmbNguoiTao.SelectedValue != null ? cmbNguoiTao.SelectedValue.ToString() : "Admin");
                    paRaDeDto.UpdatedDate = DateTime.Now;
                }
                paRaDeDto.GhiChu = txtGhiChu.Text.ToString();
                paRaDeDto.UrlHeader = txtUrlHeader.Text.ToString();
                paRaDeDto.UrlFooter = txtUrlFooter.Text.ToString();
            }
            catch(Exception ex)
            {

            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!CheckValidate())
            {
                return;
            }
            SetPhuongAnDTO();
            if (paRaDeDto == null || paRaDeDto.MaPA == "")
                return;
            idPhuongAnRaDe = paRaDeBus.XuLyPhuongAnRaDe(paRaDeDto, _isSua: isSua, _urlHeader: txtUrlHeader.Text, _urlFooter: txtUrlFooter.Text);
            MessageBox.Show("Đã lưu");
            LoadData();
            PluginBus.PhanQuyenButtonForm(_root: grpButton, _ePhanQuyen: PluginBus.ePhanQuyenForm.capNhat);
        }

        private void dtDenNgay_ValueChanged(object sender, EventArgs e)
        {

        }
        private void ChuyenDoiMaskTextBox(MaskedTextBox mtb, int length)
        {
            if (length > 0)
            {
                string result = "";

                for (int i = 0; i < length; i++)
                {
                    result += "0" + " - ";
                }
                mtb.Mask = result.TrimEnd('-', ' ');
            }
            else
            {
                mtb.Mask = " ";
            }
        }
        private int TinhTongDiemBaiThi()
        {
            //int selectedNhomCauHoiID = Convert.ToInt32(cbbNhomCauHoi.SelectedValue);
            if (maMon == null || maMon == "")
                return 0;
            string maNhomchon = Convert.ToString(cbbNhomCauHoi.SelectedValue);
            // Tính tổng điểm nhóm câu hỏi
            int tongDiem = 0;
            System.Data.DataTable dt = nhomCauHoiBLL.LoadNhomCauTheoMon(_maMon: maMon);
            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToString(row["MaNhom"]) == maNhomchon)
                {
                    tongDiem += Convert.ToInt32(row["Diem"]);
                }
            }
            return tongDiem;
        }
        private int TinhTongDiem()
        {
            try
            {
                soLuongCau = 0;
                if (rtbNhomCauHoi.Text == "")
                {
                    return 0;
                }
                int result = 0;
                string[] caus = rtbNhomCauHoi.Text.Split(' ');
                if (dtNhomCau != null & dtNhomCau.Rows.Count > 0 && caus != null && caus.Length > 1)
                {
                    foreach (DataRow dr in dtNhomCau.Rows)
                    {
                        var maNhom = dr["MaNhom"].ToString();
                        if (maNhom != "")
                        {
                            var sFind = Array.Find(caus, element => element == maNhom);
                            if (sFind != null && sFind != "")
                            {
                                result = result + Convert.ToInt32(dr["Diem"]);
                            }
                        }
                    }
                }
                if (result == 10)
                {
                    soLuongCau = caus.Length - 1;
                }
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        private void cbbNhomCauHoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!isEndLoadForm)
                    cbbNhomCauHoi.SelectedValue = "";

                if (cbbNhomCauHoi.SelectedItem != null)
                {
                    DataRowView selectedItem = cbbNhomCauHoi.SelectedItem as DataRowView;
                    rtbNhomCauHoi.AppendText(selectedItem["MaNhom"].ToString() + " ");
                }
                string nhomCauHoi = rtbNhomCauHoi.Text;
                string[] words = nhomCauHoi.Split(new char[] { ',', ';', ' ', '-', '_', '.', '*' }, StringSplitOptions.RemoveEmptyEntries);

                int soLuongNhomCauHoiDuocChon = words.Length;
                totalDiem += TinhTongDiemBaiThi();

                txtTongDiem.Text = TinhTongDiem().ToString(); //Viết lại tính tổng điểm
            }
            catch(Exception ex)
            {

            }
        }

        private void grdData_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch(Exception ex)
            {

            }
        }

        private void grdData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex >= 0)
                {
                    //grdData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (grdData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null ? true : (!(bool)grdData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                    idPhuongAnRaDe = Convert.ToInt64( grdData.Rows[e.RowIndex].Cells[0].Value);
                    var maPA = grdData.Rows[e.RowIndex].Cells[1].Value;
                    paRaDeDto = (PhuongAnRaDeDto)paRaDeBus.LoadPhuongAnRaDe(_idPA: idPhuongAnRaDe, _maPA: maPA.ToString(), _isDTO: true);
                    
                    LoadPhuongAn(_paDto: paRaDeDto);
                    txtTongDiem.Text = "10";
                    isSua = true;
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void LoadCmb()
        {
            // Hiện thị List tên Khoa 
            cbbKhoa.DisplayMember = "TenKhoa";
            cbbKhoa.ValueMember = "MaKhoa";
            cbbKhoa.DataSource = khoaBLL.LoadKhoa();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            idPhuongAnRaDe = 0;
            LoadData();
            PluginBus.PhanQuyenButtonForm(_root: grpButton, _ePhanQuyen: PluginBus.ePhanQuyenForm.huy);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            idPhuongAnRaDe = 0;
            isSua = false;
            paRaDeDto = new PhuongAnRaDeDto();
            dtNgay.Value = DateTime.Now;
            cbbNhomCauHoi.SelectedValue = "";
            ResetControl();
            LoadData();
            txtMaPA.Text = TaoMaPAMoiNhat();
            PluginBus.PhanQuyenButtonForm(_root: grpButton, _ePhanQuyen: PluginBus.ePhanQuyenForm.them);
        }

        // Load
        private void UcPhuongAnDeThi_Load(object sender, EventArgs e)
        {
            LoadCmb();
            LoadData();
            btnXoaNhomCauVuaChon_Click(null,null);
            cbbNhomCauHoi.SelectedValue = "";
            dtNgay.Value = DateTime.Now;
            isEndLoadForm = true;
            txtMaPA.Text = TaoMaPAMoiNhat();
            txtUrlHeader.Text = "C:\\Users\\ADMIN\\Desktop\\File_Luan_Van\\Tieu_de\\header.docx";
            txtUrlFooter.Text = "C:\\Users\\ADMIN\\Desktop\\File_Luan_Van\\Tieu_de\\footer.docx";
            PluginBus.PhanQuyenButtonForm(_root: grpButton, _ePhanQuyen: PluginBus.ePhanQuyenForm.them);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Chắn chắn xóa phương án?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (paRaDeDto!=null && paRaDeDto.ID > 0)
                {
                    paRaDeDto.Huy = true;
                    idPhuongAnRaDe = paRaDeBus.XuLyPhuongAnRaDe(paRaDeDto, _isSua: isSua, _urlHeader: txtUrlHeader.Text, _urlFooter: txtUrlFooter.Text);
                    LoadData();
                    PluginBus.PhanQuyenButtonForm(_root: grpButton, _ePhanQuyen: PluginBus.ePhanQuyenForm.xoa);
                }
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (isOpenFast)
            {
                UC_TaoDeThi s = new UC_TaoDeThi();
                PluginBus.OpenForm(s);
            }    
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.ShowDialog();
                txtUrlHeader.Text = fileDialog.FileName;
                object readOnly = false;
                object visiable = true;
                object save = false;
                object fileName = fileDialog.FileName;
                object newTemplate = false;
                object docType = 0;
                object missing = Type.Missing;
                Microsoft.Office.Interop.Word._Document document;
                Microsoft.Office.Interop.Word._Application application = new Microsoft.Office.Interop.Word.Application() { Visible = false };
                document = application.Documents.Open(ref fileName,
                ref missing, ref readOnly, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref visiable, ref missing, ref missing, ref missing, ref missing);
                document.ActiveWindow.Selection.WholeStory();
                document.ActiveWindow.Selection.Copy();
                IDataObject dataObject = Clipboard.GetDataObject();
                //rtbNoiDungCauHoi.Rtf = dataObject.GetData(DataFormats.Rtf).ToString();
                application.Quit(ref missing, ref missing, ref missing);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            PluginBus.PhanQuyenButtonForm(_root: grpButton, _ePhanQuyen: PluginBus.ePhanQuyenForm.sua);
        }

        private void btnFooter_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.ShowDialog();
                txtUrlFooter.Text = fileDialog.FileName;
                object readOnly = false;
                object visiable = true;
                object save = false;
                object fileName = fileDialog.FileName;
                object newTemplate = false;
                object docType = 0;
                object missing = Type.Missing;
                Microsoft.Office.Interop.Word._Document document;
                Microsoft.Office.Interop.Word._Application application = new Microsoft.Office.Interop.Word.Application() { Visible = false };
                document = application.Documents.Open(ref fileName,
                ref missing, ref readOnly, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref visiable, ref missing, ref missing, ref missing, ref missing);
                document.ActiveWindow.Selection.WholeStory();
                document.ActiveWindow.Selection.Copy();
                IDataObject dataObject = Clipboard.GetDataObject();
                //rtbNoiDungCauHoi.Rtf = dataObject.GetData(DataFormats.Rtf).ToString();
                application.Quit(ref missing, ref missing, ref missing);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadData()
        {
            dtDS = (DataTable)paRaDeBus.LoadPhuongAnRaDe();
            grdData.DataSource = dtDS;
        }
        private void LoadPhuongAn(PhuongAnRaDeDto _paDto)
        {
            if (_paDto == null || _paDto.ID == 0)
                return;
            txtMaPA.Text = PluginBus.KiemTraGiaTri(_paDto.MaPA);
            txtTenPA.Text = PluginBus.KiemTraGiaTri(_paDto.TenPA);
            cbbKhoa.SelectedValue = PluginBus.KiemTraGiaTri(_paDto.MaKhoa);
            cbbTenMon.SelectedValue = PluginBus.KiemTraGiaTri(_paDto.MaMon);
            rtbNhomCauHoi.Text = PluginBus.KiemTraGiaTri(_paDto.NhomCaus);
            txtGhiChu.Text = PluginBus.KiemTraGiaTri(_paDto.GhiChu); 
            txtUrlHeader.Text = PluginBus.KiemTraGiaTri(_paDto.UrlHeader); 
            txtUrlFooter.Text = PluginBus.KiemTraGiaTri(_paDto.UrlFooter); 
        }    
        
        private void ResetControl()
        {
            txtMaPA.ResetText();
            txtTenPA.ResetText();
            cbbKhoa.SelectedValue = "";
            cbbTenMon.SelectedValue = "";
            rtbNhomCauHoi.Text = "";
            txtTongDiem.ResetText();
        }
   /*     private string TaoMaPAMoiNhat()
        {
            try
            {
                if (dtDS == null || dtDS.Rows.Count == 0)
                    return "PA1";
                string maMax = dtDS.Rows[0]["MaPA"].ToString();
                string maMoi = $"PA{Convert.ToInt64(maMax.Replace("PA","")) + 1}";
                return maMoi;
            }
            catch(Exception ex)
            {
                return "";
            }
        }*/

        private string TaoMaPAMoiNhat()
        {
            try
            {
                if (dtDS == null || dtDS.Rows.Count == 0)
                    return "PA_1";
                string maMax = dtDS.Rows[0]["MaPA"].ToString();
                int sttMax = Convert.ToInt32(maMax.Split('_')[1]);
                string maMoi = $"PA_{sttMax + 1}";
                return maMoi;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

    }
}
