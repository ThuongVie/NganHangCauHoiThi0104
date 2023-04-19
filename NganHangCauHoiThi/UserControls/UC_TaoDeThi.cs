using BLL;
using DevComponents.DotNetBar.Controls;
using DTO;
using Microsoft.Office.Interop.Word;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;
using DTO;
using System.IO;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Cryptography;

namespace NganHangCauHoiThi.UserControls
{
    public partial class UC_TaoDeThi : UserControl
    {
        CauHoiBLL cHoiBll = new CauHoiBLL();
        CauTrucDeThiBus cauTrucDeBus = new CauTrucDeThiBus();
        PhuongAnRaDeBus paBus = new PhuongAnRaDeBus();

        CauTrucDeThiDTO cauTrucDeDto = new CauTrucDeThiDTO();
        public int idKhoa = 0, idMonHoc = 0, soLuongCau = 0;
        public string nhomCau = "";
        private string local = "";
        System.Data.DataTable dtListCauHoi = new System.Data.DataTable();

        string urlRtf = "";
        List<string> lstUrlRtf = new List<string>();
        List<string> lstNhomCau = new List<string>();
        List<string> lstNhomCauDaChon = new List<string>();
        List<string> lstNhomCauSelect = new List<string>();
        List<int> lstIDCauHoi = new List<int>();
        List<int> lstIDCauHoiUsed = new List<int>();
        List<int> lstDiemDaChon = new List<int>();

        public int  kieuLoad = 0, tongDiemChon = 0;
        public string  arrIDCauHoi = "";

        private DataTable dtCauTrucDe;
        private Boolean isTaoDe = false;
        private long idCauTrucDeThi = 0;

        MonHocBLL monHocBLL = new MonHocBLL();
        KhoaBLL khoaBLL = new KhoaBLL();
        NhomCauHoiBLL nhomCauHoiBLL = new NhomCauHoiBLL();

        public int totalDiem = 0;
        DataTable dtNhomCau;

        public string maKhoaFind = "", maMonFind = "", nhomCauFind="", maDe="";
        public DateTime tuNgayFind, denNgayFind;
        public Boolean isXemThongKe = false;
        public long idDe = 0;
        private string maMon = "",maKhoa="";
        private Boolean isSua = false;

        public UC_TaoDeThi()
        {
            InitializeComponent();
        }

        // Load
        private void UC_CauTrucDeThi_Load(object sender, EventArgs e)
        {
            // Hiện thị List tên Khoa 
            cbbKhoa.DisplayMember = "TenKhoa";
            cbbKhoa.ValueMember = "MaKhoa";
            cbbKhoa.DataSource = khoaBLL.LoadKhoa();
            rtbNhomCauHoi.BackColor = Color.White;
            rtbNhomCauHoi.Text = string.Empty;

            cmbPhuongAn.DisplayMember = "TenPA";
            cmbPhuongAn.ValueMember = "MaPA";
            cmbPhuongAn.DataSource = paBus.LoadPhuongAnRaDe();
            
            if (maDe !=null && maDe!="")
            {
                LoadDeThi();
            }   
            else
            {
                clearFolder(local + @"\Trash\");
                ResetComboboxSelected();
                txtMaDe.Text = TaoMaDeThiTuDong();

            }
            PluginBus.PhanQuyenButtonForm(_root: grpButton, _ePhanQuyen: PluginBus.ePhanQuyenForm.them);

        }

        private void ResetComboboxSelected()
        {
            /*cbbKhoa.SelectedIndex = -1;
            cbbTenMon.SelectedIndex = -1;*/
            cmbPhuongAn.SelectedIndex = -1;
            txtChuThich.Text = string.Empty;
            richTextBox2.Text = string.Empty;
            rtbNhomCauHoi.Clear();
        }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbTenMon.DisplayMember = "TenMon";
            cbbTenMon.ValueMember = "MaMon";

            // Lấy IDKhoa từ combobox 
            object value = cbbKhoa.SelectedValue;
            //int IDKhoa = Convert.ToInt32(value);
            // Load list môn học theo ID Khoa
            if (value != null && value != "")
            {
                maKhoa = value.ToString();
                DataTable dtKhoa = khoaBLL.LoadKhoaTheo(_maKhoa: maKhoa);
                idKhoa = Convert.ToInt32( dtKhoa.Rows[0]["ID"]);
            }    
            cbbTenMon.DataSource = monHocBLL.LoadMonTheoKhoa(_maKhoa: maKhoa);
            //txtMaDe.Text = TaoMaDeThiTuDong();
        }

        private void cbbTenMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mon = cbbTenMon.SelectedValue;
            if (mon != null && mon != "")
            {
                maMon = mon.ToString();
                DataTable dtMon = monHocBLL.LoadMonTheoKhoa(_maKhoa: maKhoa, _maMon: maMon);
                idMonHoc = Convert.ToInt32(dtMon.Rows[0]["ID"]);
            }
            LoadCbbNhomCauHoiTheoMon();

            try
            {
                cmbPhuongAn.DisplayMember = "TenPA";
                cmbPhuongAn.ValueMember = "MaPA";
                // Lấy IDKhoa từ combobox 
                object value = cbbTenMon.SelectedValue;
                maMon = value.ToString();

                cmbPhuongAn.DataSource = paBus.LoadPhuongAnRaDeTheo( maKhoa, maMon, null, null);
                if (maDe != null && maDe != "")
                {
                    return;
                }
                else
                {
                    txtMaDe.Text = TaoMaDeThiTuDong();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void LoadCbbNhomCauHoiTheoMon()
        {
            //cbbNhomCauHoi.Items.Clear();
            rtbNhomCauHoi.Text = string.Empty;

            // Lấy ID Mon hoc từ combobox Ten mon
            object value = cbbTenMon.SelectedValue;
            //int IDMon = Convert.ToInt32(value);
            maMon = value.ToString();
            if (maMon != "")
            {
                System.Data.DataTable dt = nhomCauHoiBLL.LoadNhomCauTheoMon(maMon);
                dtNhomCau = dt;


                dt.Columns.Add("DisplayText", typeof(string), "MaNhom + ' - ' + Diem + ' điểm - ' + ThoiGianDuKien + 'p'");

                cbbNhomCauHoi.DisplayMember = "DisplayText";
                cbbNhomCauHoi.ValueMember = "MaNhom";
                cbbNhomCauHoi.DataSource = dt;
            }
            else
            {
                cbbNhomCauHoi.Text = "";
            }
        }

        private void btnXoaNhomCauVuaChon_Click(object sender, EventArgs e)
        {
            totalDiem = 0;
            LoadCbbNhomCauHoiTheoMon();
            rtbNhomCauHoi.Clear();
            txtTongDiem.Text= string.Empty;
            
        }

        private void cbbNhomCauHoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbNhomCauHoi.SelectedItem != null)
            {
                DataRowView selectedItem = cbbNhomCauHoi.SelectedItem as DataRowView;
                rtbNhomCauHoi.AppendText(selectedItem["MaNhom"].ToString() + " ");
            }

            //Dem so luong nhom cau hoi cua mon hoc  
            string nhomCauHoi = rtbNhomCauHoi.Text;
            string[] words = nhomCauHoi.Split(new char[] { ',', ';', ' ', '-', '_', '.', '*' }, StringSplitOptions.RemoveEmptyEntries);

            int soLuongNhomCauHoiDuocChon = words.Length;

            // Load số lượng So diem moi cau

            ChuyenDoiMaskTextBox(mtbSoDiemMoiNhomCau, words.Length);
            ChuyenDoiMaskTextBox(mtbSoLuongCauMoiNhom, words.Length);
            ChuyenDoiMaskTextBox2(mtbThoiGianMoiNhomCau, words.Length);

            totalDiem += TinhTongDiemBaiThi(); 
            txtTongDiem.Text = totalDiem.ToString(); // đang tinh sai

            txtTongDiem.Text = TinhTongDiem().ToString(); //Viết lại tính tổng điểm

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

        private void ChuyenDoiMaskTextBox2(MaskedTextBox mtb, int length)
        {
            if (length > 0)
            {
                string result = "";

                for (int i = 0; i < length; i++)
                {
                    result += "00" + " - ";
                }
                mtb.Mask = result.TrimEnd('-', ' ');
            }
            else
            {
                mtb.Mask = " ";
            }
        }

        private void mtbSoDiemMoiNhomCau_Click(object sender, EventArgs e)
        {
            try
            {
                mtbSoDiemMoiNhomCau.SelectionStart = mtbSoDiemMoiNhomCau.MaskedTextProvider.LastAssignedPosition + 1;
                mtbSoDiemMoiNhomCau.SelectionLength = 0;
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn Font chữ ENG");
            }

        }

        private void mtbSoLuongCauMoiNhom_Click(object sender, EventArgs e)
        {
            try
            {
                mtbSoLuongCauMoiNhom.SelectionStart = mtbSoLuongCauMoiNhom.MaskedTextProvider.LastAssignedPosition + 1;
                mtbSoLuongCauMoiNhom.SelectionLength = 0;
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn Font chữ ENG");
            }
        }

        private void mtbThoiGianMoiNhomCau_Click(object sender, EventArgs e)
        {
            try
            {
                mtbThoiGianMoiNhomCau.SelectionStart = mtbThoiGianMoiNhomCau.MaskedTextProvider.LastAssignedPosition + 1;
                mtbThoiGianMoiNhomCau.SelectionLength = 0;
            }
            catch
            {
                MessageBox.Show("Vui lòng chọn Font chữ ENG");
            }
        }
        

        private void TinhTongThoiGianBaiThi()
        {
            try
            {
                string stringSoLuongCauMoiNhom = mtbSoLuongCauMoiNhom.Text;
                string stringSoDiemMoiNhomCau = mtbSoDiemMoiNhomCau.Text;
                string stringThoiGianMoiNhomCau = mtbThoiGianMoiNhomCau.Text;

                string[] arrSoLuongCauMoiNhom = stringSoLuongCauMoiNhom.Split(new char[] { ',', ';', ' ', '-', '_', '.', '*' }, StringSplitOptions.RemoveEmptyEntries);
                string[] arrSoDiemMoiNhomCau = stringSoDiemMoiNhomCau.Split(new char[] { ',', ';', ' ', '-', '_', '.', '*' }, StringSplitOptions.RemoveEmptyEntries);
                string[] arrThoiGianMoiNhomCau = stringThoiGianMoiNhomCau.Split(new char[] { ',', ';', ' ', '-', '_', '.', '*' }, StringSplitOptions.RemoveEmptyEntries);

                //Tinh tong thoi gian lam du kien
                int tongThoiGian = 0;

                for (int i = 0; i < arrSoLuongCauMoiNhom.Length; i++)
                {
                    tongThoiGian += Int32.Parse(arrSoLuongCauMoiNhom[i]) * Int32.Parse(arrThoiGianMoiNhomCau[i]);
                }
                txtThoiGianLam.Text = tongThoiGian.ToString();

            }
            catch
            {
                txtThoiGianLam.Text = string.Empty;
                txtThoiGianLam.Text = string.Empty;
            }
        }

        //Thuong sua
        private void btnXuatWord_Click(object sender, EventArgs e)
        {
            ExportToWord(richTextBox1);
        }

        private void ExportToWord(RichTextBox richTextBox)
        {
            // Khởi tạo đối tượng Word
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();

            // Tạo một tài liệu mới trong Word
            Document document = word.Documents.Add();

            // Chuyển dữ liệu từ RichTextBox sang Clipboard
            Clipboard.SetText(richTextBox.Rtf, TextDataFormat.Rtf);

            // Chèn nội dung từ Clipboard vào file Word
            document.Range().Paste();

            // Hiển thị tài liệu Word
            word.Visible = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraTaoDeThi())
                {
                    return;
                }
                KhoiTaoGiaTri();
                UcLoadTaoDeThi s = new UcLoadTaoDeThi();
                s.idKhoa = idKhoa;
                s.idMonHoc = idMonHoc;
                s.maKhoa = maKhoa;
                s.maMon = maMon;
                s.nhomCau = nhomCau;
                s.soLuongCau = soLuongCau;
                s.maPA = cmbPhuongAn.SelectedValue.ToString();
                cauTrucDeDto = new CauTrucDeThiDTO();
                cauTrucDeDto.MaDe = txtMaDe.Text;
                cauTrucDeDto.TenDe = txtTenDe.Text;
                cauTrucDeDto.IDMonHoc = idMonHoc;
                cauTrucDeDto.SLCauCuaNhom = soLuongCau;
                cauTrucDeDto.SoLuongNhomCau = 3;
                cauTrucDeDto.SoDiemMoiNhomCau = "";
                cauTrucDeDto.SLCauMoiNhom = "1;1;1;";
                cauTrucDeDto.TongThoiGianLam = 0;
                cauTrucDeDto.ThoiGianDuKienMoiNhom = 0;
                cauTrucDeDto.IDKhoa = idKhoa;
                cauTrucDeDto.NhomCauChons = nhomCau;
                cauTrucDeDto.IDCauChons = "";
                cauTrucDeDto.Huy = false;
                cauTrucDeDto.MaKhoa = cbbKhoa.SelectedValue.ToString();
                cauTrucDeDto.MaMon = cbbTenMon.SelectedValue.ToString();
                cauTrucDeDto.Ngay = DateTime.Now;

                s.cauTrucDeDto = cauTrucDeDto;
                s.kieuLoad = 1;
                PluginBus.OpenForm(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.ToString());
            }
            
        }
        private Boolean KiemTraTaoDeThi()
        {
            try
            {
                Boolean result = true;
                string msg = "";
                if (rtbNhomCauHoi.Text == null || rtbNhomCauHoi.Text == "")
                {
                    msg = "Chọn nhóm câu hỏi.!!!";
                    result= false;
                }
                if (TinhTongDiem() != 10)
                {
                    msg = "Tổng điểm các nhóm câu hỏi phải bằng 10đ.!!!";
                    result = false;
                }    
                if (msg != "")
                {
                    MessageBox.Show(msg);
                    result = false;
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private int TinhTongDiem()
        {
            try
            {
                soLuongCau = 0;
                if (rtbNhomCauHoi.Text=="")
                {
                    return 0;
                }    
                int result = 0;
                string[] caus = rtbNhomCauHoi.Text.Split(' ');
                if (dtNhomCau != null & dtNhomCau.Rows.Count > 0 && caus != null && caus.Length  > 1)
                {
                    foreach(DataRow dr in dtNhomCau.Rows)
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
                if (result==10)
                {
                    soLuongCau = caus.Length-1;
                }    
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        private Boolean CheckValidate()
        {
            try
            {
                if (!isSua)
                {
                    DataTable dtCheck = cauTrucDeBus.LoadCauTrucDeThi(_id: idCauTrucDeThi, _maDe: txtMaDe.Text);
                    if (dtCheck != null && dtCheck.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã đề thi đã được sử dụng.!!!");
                        return false;
                    }    
                    
                } 
                if (arrIDCauHoi==null || arrIDCauHoi =="")
                {
                    MessageBox.Show("Chưa chọn câu hỏi cho đề thi.!!!");
                    return false;
                }   
                if (cbbKhoa.Text=="" || cbbTenMon.Text=="" || txtMaDe.Text=="")
                {
                    MessageBox.Show("Chọn đầy đủ thông tin.!!!");
                    return false;
                }    
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!CheckValidate())
            {
                return;
            }
            if (cauTrucDeDto == null || cauTrucDeDto.MaDe=="")
                return;
            dtCauTrucDe = cauTrucDeBus.LoadCauTrucDeThi(_id: idCauTrucDeThi, _maDe: txtMaDe.Text);
            if (dtCauTrucDe != null && dtCauTrucDe.Rows.Count > 0)
            {
                isSua = true;
                cauTrucDeDto.ID = idCauTrucDeThi;
            }
            idCauTrucDeThi = cauTrucDeBus.ThaoTacCauTrucDeThi_Store(cauTrucDeDto, _isSua: isSua);
            PluginBus.PhanQuyenButtonForm(_root: grpButton, _ePhanQuyen: PluginBus.ePhanQuyenForm.capNhat);
            MessageBox.Show("Đã lưu");
            txtMaDe.Text = TaoMaDeThiTuDong();
            ResetData();
        }

        private void btnNgauNhien_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtbNhomCauHoi.Text == null || rtbNhomCauHoi.Text == "")
                {
                    MessageBox.Show("Chưa chọn phương án ra đề thi.!!!");
                }
                else if (cbbKhoa.Text == "" || cbbTenMon.Text == "" || txtMaDe.Text == "" || txtTenDe.Text =="")
                {
                    MessageBox.Show("Điền đầy đủ thông tin đề thi.!!!");
                }
                else
                {

                    KhoiTaoGiaTri();

                    local = System.Windows.Forms.Application.StartupPath;
                    dtListCauHoi = cHoiBll.LoadCauHoiTaoDeThi(idKhoa, idMonHoc, nhomCau, soLuongCau, _kieuLoad: kieuLoad, _maKhoa: maKhoa, _maMon: maMon);
                    lstIDCauHoi.Clear();
                    foreach (DataRow dr in dtListCauHoi.Rows)
                    {
                        int idThem = 0;
                        idThem = Convert.ToInt16(dr["ID"]);
                        lstIDCauHoi.Add(idThem);
                    }
                    //lblDS.Text = "SỐ LƯỢNG CÂU " + lstIDCauHoi.Count().ToString();
                    switch (kieuLoad)
                    {
                        case 0:
                            this.Text = "LOAD CÂU HỎI RANDOM";
                            TaoDe();
                            break;
                        case 1:
                            this.Text = "LOAD CÂU HỎI LỰA CHỌN";
                            soLuongCau = 0;
                            lstIDCauHoi.Clear();
                            lstIDCauHoiUsed.Clear();
                            lstDiemDaChon.Clear();
                            lstNhomCau.Clear();
                            if (nhomCau != null && nhomCau != "")
                            {
                                string[] nhoms = nhomCau.Split(' ');
                                foreach (string s in nhoms)
                                {
                                    if (s != null && s != "")
                                        lstNhomCau.Add(s);

                                }
                            }
                            break;
                    }
                    if (kieuLoad == 1)
                    {
                        dtListCauHoi = cHoiBll.LoadCauHoiTaoDeThi(idKhoa, idMonHoc, nhomCau, soLuongCau, _kieuLoad: kieuLoad, _maKhoa: maKhoa, _maMon: maMon);
                    }
                    //dgvCauHoi.DataSource = dtListCauHoi;
                    dtCauTrucDe = cauTrucDeBus.LoadCauTrucDeThi(_id: 0, _maDe: cauTrucDeDto.MaDe);

                    arrIDCauHoi = GetArrayIDCauHoi();

                    //XEM LẠI
                    cauTrucDeDto = new CauTrucDeThiDTO();
                    cauTrucDeDto.MaDe = txtMaDe.Text;
                    cauTrucDeDto.TenDe = txtTenDe.Text;
                    cauTrucDeDto.IDMonHoc = idMonHoc;
                    cauTrucDeDto.SLCauCuaNhom = soLuongCau;
                    cauTrucDeDto.SoLuongNhomCau = 3;
                    cauTrucDeDto.SoDiemMoiNhomCau = "";
                    cauTrucDeDto.SLCauMoiNhom = "1;1;1;";
                    cauTrucDeDto.TongThoiGianLam = 0;
                    cauTrucDeDto.ThoiGianDuKienMoiNhom = 0;
                    cauTrucDeDto.IDKhoa = idKhoa;
                    cauTrucDeDto.NhomCauChons = nhomCau;
                    cauTrucDeDto.IDCauChons = arrIDCauHoi;
                    cauTrucDeDto.MaKhoa = cbbKhoa.SelectedValue.ToString();
                    cauTrucDeDto.MaMon = cbbTenMon.SelectedValue.ToString();
                    cauTrucDeDto.Huy = false;
                    cauTrucDeDto.Ngay = DateTime.Now;

                    LoadDSCau();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void KhoiTaoGiaTri()
        {
            try
            {
                maKhoa = cbbKhoa.SelectedValue.ToString();
                maMon = cbbTenMon.SelectedValue.ToString();
                nhomCau = rtbNhomCauHoi.Text;
                soLuongCau = soLuongCau;
            }
            catch(Exception ex)
            {

            }
        }
        #region tạo đề
        private void clearFolder(string FolderName)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(FolderName);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                foreach (DirectoryInfo di in dir.GetDirectories())
                {
                    clearFolder(di.FullName);
                    di.Delete();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        private void ResetData()
        {
            cmbPhuongAn.SelectedIndex = -1;
            richTextBox1.Clear();
            btnXoaNhomCauVuaChon_Click(null, null);
            idCauTrucDeThi = 0;
            dtCauTrucDe = null;
            cauTrucDeDto = new CauTrucDeThiDTO();
            arrIDCauHoi = "";
            lstIDCauHoi.Clear();
            txtTenDe.Text = string.Empty;
            txtChuThich.Text = "";
            richTextBox2.Text = "";
            PluginBus.PhanQuyenButtonForm(_root: grpButton, _ePhanQuyen: PluginBus.ePhanQuyenForm.huy);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnReset_Click(null,null);
            txtMaDe.Text= TaoMaDeThiTuDong();
            PluginBus.PhanQuyenButtonForm(_root: grpButton, _ePhanQuyen: PluginBus.ePhanQuyenForm.them);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
            if (isXemThongKe)
            {
                UCNganHangDeThi s = new UCNganHangDeThi();
                s.tuNgay = tuNgayFind;
                s.denNgay = denNgayFind;
                s.maKhoa = maKhoaFind;
                s.maMon = maMonFind;
                s.nhomCau = nhomCauFind;
                PluginBus.OpenForm(s);
            }
            else
            {
                frm_TrangChu frmTrangChu = (frm_TrangChu)System.Windows.Forms.Application.OpenForms["FrmTrangChu"];

                UCNganHangDeThi s = new UCNganHangDeThi();
                AddUsercontrol(s);
            }

        }
        private void AddUsercontrol(UserControl userControl)
        {
            if (System.Windows.Forms.Application.OpenForms.OfType<frm_TrangChu>().FirstOrDefault() is frm_TrangChu frm)
            {
                userControl.Dock = DockStyle.Fill;
                frm.panelDesktop.Controls.Clear();
                frm.panelDesktop.Controls.Add(userControl);
                userControl.BringToFront();
            }
        }

        private void cmbPhuongAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPhuongAn.SelectedValue == null)
            {
                return;
            }    
            PhuongAnRaDeDto paDto = new PhuongAnRaDeDto();
            paDto = (PhuongAnRaDeDto)paBus.LoadPhuongAnRaDe(_maPA: cmbPhuongAn.SelectedValue.ToString(), _isDTO: true);
            if (paDto != null && paDto.ID > 0)
            {
                rtbNhomCauHoi.Text = paDto.NhomCaus.Replace(";"," ");
                txtChuThich.Text = paDto.GhiChu;
            }    
        }

        private void txtMaDe_TextChanged(object sender, EventArgs e)
        {

        }

        public static void MergeRTF(string[] filesToMerge, string outputFilename, bool insertPageBreaks)
        {
            object missing = System.Type.Missing;
            object pageBreak = Microsoft.Office.Interop.Word.WdBreakType.wdSectionBreakNextPage;
            object outputFile = outputFilename;
            Microsoft.Office.Interop.Word._Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            try
            {
                Microsoft.Office.Interop.Word.Document wordDocument = wordApplication.Documents.Add(
                                                ref missing
                                            , ref missing
                                            , ref missing
                                            , ref missing);
                Microsoft.Office.Interop.Word.Selection selection = wordApplication.Selection;
                int documentCount = filesToMerge.Length;
                int breakStop = 0;
                foreach (string file in filesToMerge)
                {
                    breakStop++;
                    selection.InsertFile(file, ref missing, ref missing, ref missing, ref missing);
                    if (insertPageBreaks && breakStop != documentCount)
                    {
                        selection.InsertBreak(ref pageBreak);
                    }
                }
                wordDocument.SaveAs(
                            ref outputFile
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing);
                wordDocument = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                wordApplication.Quit(ref missing, ref missing, ref missing);
            }
        }

        // Ban goc 
        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportFile();
        }

        private void btnThemPA_Click(object sender, EventArgs e)
        {
            UcPhuongAnDeThi s = new UcPhuongAnDeThi();
            s.isOpenFast = true;
            PluginBus.OpenForm(s);
        }

        private void btnRandomNhomCau_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtNhomCau == null || dtNhomCau.Rows.Count == 0)
                    return;
                foreach(DataRow dr in dtNhomCau.Rows)
                {
                    var diemCau = dr[0];
                }    
            }
            catch(Exception ex)
            {

            }
        }
        private void KhoiTaoUrlHeader()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ServerShareDto.connect))
                {
                    conn.Open();

                    string selQuery = $" select NoiDungHeader from TblPhuongAnRaDe where ISNULL(Huy,0)=0 and MaPA='{cmbPhuongAn.SelectedValue}' ";
                    using (SqlCommand cmd = new SqlCommand(selQuery, conn))
                    {
                        string nameRtf = "";
                        object oBuffer = cmd.ExecuteScalar();
                        if (oBuffer != DBNull.Value)
                        {
                            byte[] buffer = (byte[])oBuffer;
                            string fName = local + @"\Trash\001rtf_header.rtf";
                            System.IO.File.WriteAllBytes(fName, buffer);
                        }
                    }
                    urlRtf = local + @"\Trash\001rtf_header.rtf";
                    urlRtf = AppendFormattedText(_pathFile: urlRtf, text: txtMaDe.Text, _stt: 0, _diem: 0, Color.Black, isBold: true, alignment: HorizontalAlignment.Center, _tenMaDe: txtMaDe.Text, _tenDeThi: txtTenDe.Text);
                    lstUrlRtf.Add(urlRtf);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void KhoiTaoUrlFooter()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ServerShareDto.connect))
                {
                    conn.Open();

                    string selQuery = $" select NoiDungFooter from TblPhuongAnRaDe where ISNULL(Huy,0)=0 and MaPA='{cmbPhuongAn.SelectedValue}' ";
                    using (SqlCommand cmd = new SqlCommand(selQuery, conn))
                    {
                        string nameRtf = "";
                        object oBuffer = cmd.ExecuteScalar();
                        if (oBuffer != DBNull.Value)
                        {
                            byte[] buffer = (byte[])oBuffer;
                            string fName = local + @"\Trash\zzzrtf_NoiDungFooter.rtf";
                            System.IO.File.WriteAllBytes(fName, buffer);
                        }
                    }
                    urlRtf = local + @"\Trash\zzzrtf_NoiDungFooter.rtf";
                    lstUrlRtf.Add(urlRtf);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        private void KhoiTaoUrlRtf()
        {
            try
            {
                KhoiTaoUrlHeader();
                using (SqlConnection conn = new SqlConnection(ServerShareDto.connect))
                {
                    conn.Open();

                    for (int i = 0; i < lstIDCauHoi.Count; i++)
                    {
                        string selQuery = $" select NoiDung from TblCauHoi where ID={lstIDCauHoi[i]} ";
                        using (SqlCommand cmd = new SqlCommand(selQuery, conn))
                        {
                            string nameRtf = "";
                            object oBuffer = cmd.ExecuteScalar();
                            if (oBuffer != DBNull.Value)
                            {
                                byte[] buffer = (byte[])oBuffer;
                                string fName = local + @"\Trash\rtf" + lstIDCauHoi[i].ToString() + ".rtf";
                                System.IO.File.WriteAllBytes(fName, buffer);
                            }
                        }

                        urlRtf = local + @"\Trash\rtf" + lstIDCauHoi[i].ToString() + ".rtf";

                        int _diem = 0;
                        _diem = 0;
                        DataTable dtCauHoi= (DataTable)cHoiBll.GetCauHoiById(idCauhoi: Convert.ToInt64(lstIDCauHoi[i]));
                        if (dtCauHoi != null && dtCauHoi.Rows.Count == 1)
                            _diem = Convert.ToInt32(dtCauHoi.Rows[0]["Diem"]);
                        urlRtf = AppendFormattedText(_pathFile: urlRtf, text: "Câu", _stt: i, _diem: _diem, Color.Red, isBold: true, alignment: HorizontalAlignment.Left);

                        //File.Delete(local + @"\Trash\rtf" + lstIDCauHoi[i].ToString() + ".rtf");

                        if (urlRtf != "")
                            lstUrlRtf.Add(urlRtf);
                        else
                            MessageBox.Show("Chưa lưu được file.!!!");

                    }
                }
                KhoiTaoUrlFooter();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void TaoDe(List<int> _lstIDCau=null)
        {
            try
            {
                switch (kieuLoad)
                {
                    case 0:
                        break;
                    case 1:
                        if (tongDiemChon != 10)
                        {
                            MessageBox.Show("Tổng điểm = 10 .!!!");
                            return;
                        }
                        if (lstNhomCauSelect.Count != lstNhomCau.Count)
                        {
                            MessageBox.Show($"Chọn câu hỏi đảm bảo mỗi nhóm 1 câu. Nhóm câu hỏi: {nhomCau} ");
                            return;
                        }
                        break;
                }
                if(_lstIDCau!=null && _lstIDCau.Count> 0)
                {
                    lstIDCauHoi = _lstIDCau;
                }
                local = System.Windows.Forms.Application.StartupPath;
                clearFolder(local + @"\Trash\");
                KhoiTaoUrlRtf();
                string[] allRTFDocument = Directory.GetFiles(local + (@"\Trash"), "*.rtf");

                List<string> lstNEW = new List<string>();
                foreach (string s in allRTFDocument)
                {
                    int index = lstUrlRtf.IndexOf(s);
                    if (index >=0)
                    {
                        lstNEW.Add(s);
                    }
                }
                allRTFDocument = lstNEW.ToArray();

                MergeRTF(allRTFDocument, local + @"\Trash\Final.rtf", true);
                object readOnly = false;
                object visiable = true;
                object save = false;
                object fileName = local + @"\Trash\Final.rtf";
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
                richTextBox1.Rtf = dataObject.GetData(DataFormats.Rtf).ToString();
                application.Quit(ref missing, ref missing, ref missing);
                isTaoDe = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("TaoDe() " + ex.ToString());
            }
        }
        private void ExportFile()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "LƯU ĐỀ THI";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                string pathFile = local + @"\Trash\Final.rtf";
                var wordApp = new Microsoft.Office.Interop.Word.Application();
                var currentDoc = wordApp.Documents.Open(pathFile);
                string pathSave = saveFileDialog1.FileName + @".doc";
                currentDoc.SaveAs(pathSave, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument97);
                MessageBox.Show("Đã lưu");
            }
        }
        private void LoadDeThi()
        {
            try
            {
                dtCauTrucDe = cauTrucDeBus.LoadCauTrucDeThi(_id: idCauTrucDeThi, _maDe: maDe);
                if ( dtCauTrucDe!=null && dtCauTrucDe.Rows.Count > 0)
                {
                    txtMaDe.Text = maDe; 
                    txtTenDe.Text = dtCauTrucDe.Rows[0]["TenDe"].ToString();
                    rtbNhomCauHoi.Text = dtCauTrucDe.Rows[0]["NhomCauChons"].ToString();
                    cbbKhoa.SelectedValue = dtCauTrucDe.Rows[0]["MaKhoa"].ToString();
                    cbbTenMon.SelectedValue = dtCauTrucDe.Rows[0]["MaMon"].ToString();
                    local = System.Windows.Forms.Application.StartupPath;

                    List<int> lstCau = new List<int>();
                    string[] arr = dtCauTrucDe.Rows[0]["IDCauChons"].ToString().Split(';');
                    foreach(string s in arr)
                    {
                        if (s!= null && s!= "")
                        {
                            lstCau.Add(Convert.ToInt32(s));
                        }
                    }
                    arrIDCauHoi= dtCauTrucDe.Rows[0]["IDCauChons"].ToString();
                    LoadDSCau();
                    TaoDe(_lstIDCau: lstCau);
                }    
            }
            catch(Exception ex)
            {

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            PluginBus.PhanQuyenButtonForm(_root: grpButton, _ePhanQuyen: PluginBus.ePhanQuyenForm.sua);
        }

        private void btnXuatDS_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportDataGridViewToExcel(grdData);
        }

        /*private string TaoMaDeThiTuDong()
        {
            try
            {
                if (cbbKhoa.Text=="" || cbbTenMon.Text=="")
                {
                    return "";
                }
                string maMoi = "", maxMa="s";
                DataTable dtCheck = cauTrucDeBus.LoadDSDeThi(_tuNgay: DateTime.Now.AddYears(-5), _denNgay: DateTime.Now, _maKhoa: cbbKhoa.SelectedValue.ToString(), _maMon: cbbTenMon.SelectedValue.ToString(), _nhomCau: "", _id: 0, _made: "");
                if (dtCheck!=null && dtCheck.Rows.Count > 0)
                {
                    maxMa = dtCheck.Rows[0]["MaDe"].ToString();
                    long sttMax = Convert.ToInt64(maxMa.Replace($"{cbbKhoa.SelectedValue.ToString()}_{cbbTenMon.SelectedValue.ToString()}_", "")) + 1;
                    maMoi = $"{cbbKhoa.SelectedValue.ToString()}_{cbbTenMon.SelectedValue.ToString()}_{sttMax}";
                }    
                return maMoi;
            }   
            catch(Exception ex)
            {
                return "";
            }
        }*/
        private string TaoMaDeThiTuDong()
        {
            try
            {
                if (cbbKhoa.Text == "" || cbbTenMon.Text == "")
                {
                    return "";
                }

                string maMoi = "";
                string maMon = cbbTenMon.SelectedValue.ToString();

                // Kiểm tra xem môn học đã có đề thi hay chưa
                DataTable dtCheck = cauTrucDeBus.LoadDSDeThi(_tuNgay: DateTime.Now.AddYears(-5), _denNgay: DateTime.Now, _maKhoa: cbbKhoa.SelectedValue.ToString(), _maMon: maMon, _nhomCau: "", _id: 0, _made: "");

                if (dtCheck != null && dtCheck.Rows.Count > 0)
                {
                    // Nếu đã có đề thi, tìm mã đề thi cuối cùng và tạo mã mới dựa trên số thứ tự
                    string maxMa = dtCheck.Rows[0]["MaDe"].ToString();
                    long sttMax = Convert.ToInt64(maxMa.Replace($"{maMon}_", "")) + 1;
                    maMoi = $"{maMon}_{sttMax.ToString("D3")}";
                }
                else
                {
                    // Nếu chưa có đề thi, tạo mã mới với số thứ tự là 1
                    maMoi = $"{maMon}_001";
                }

                return maMoi;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private string GetArrayIDCauHoi()
        {
            try
            {
                if (lstIDCauHoi == null || lstIDCauHoi.Count == 0)
                    return "";
                if (lstIDCauHoi.Count > 0)
                {
                    foreach (int idCau in lstIDCauHoi)
                    {
                        if (idCau != null && idCau > 0)
                            arrIDCauHoi = $"{arrIDCauHoi};{idCau.ToString()}";
                    }
                }
                return arrIDCauHoi;
            }
            catch(Exception ex)
            {
                return "";
            }
        }
        private void LoadDSCau()
        {
            try
            {
                DataTable dtDSCau = cHoiBll.LoadCauHoiTaoDeThi(idKhoa, idMonHoc, nhomCau, soLuongCau, _kieuLoad: kieuLoad, _maKhoa: maKhoa, _maMon: maMon, _listIDCau: arrIDCauHoi);
                grdData.DataSource = dtDSCau;
            }
            catch(Exception ex)
            {

            }
        }
        private string AppendFormattedText(string _pathFile="", string text="", int _stt = 1, int _diem = 0, Color textColour= default(Color), Boolean isBold=false, HorizontalAlignment alignment= HorizontalAlignment.Left, string _tenMaDe="", string _tenDeThi = "")
        {
            try
            {
                RichTextBox rtb = new RichTextBox();

                object readOnly = false;
                object visiable = true;
                object save = false;
                object fileName = _pathFile;
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
                rtb.Rtf = dataObject.GetData(DataFormats.Rtf).ToString();
                application.Quit(ref missing, ref missing, ref missing);

                //rtb.LoadFile(_pathFile);
                if(_tenMaDe != "")
                {
                    int start = rtb.TextLength;
                    rtb.AppendText($"\n{_tenDeThi} - Mã đề {_tenMaDe}\r");
                    int end = rtb.TextLength; // now longer by length of appended text

                    // Select text that was appended
                    rtb.Select(start, end - start);

                    #region Apply Formatting
                    rtb.SelectionColor = textColour;
                    rtb.SelectionAlignment = alignment;
                    rtb.SelectionFont = new System.Drawing.Font(
                         rtb.SelectionFont.FontFamily,
                         rtb.SelectionFont.Size,
                         (isBold ? FontStyle.Bold : FontStyle.Regular));
                    #endregion
                }

                // Unselect text

                if (_tenMaDe=="")
                {
                    rtb.SelectionLength = 0;

                    rtb.SelectionStart = 0;
                    rtb.SelectionLength = 0;
                    rtb.SelectedText = $"{text} {_stt + 1} ({_diem} điểm) \r\n ";
                }    
                    

                string result = "";
                string newPath = _pathFile.Replace(".rtf", "") + "_2.rtf";
                rtb.SaveFile(newPath, RichTextBoxStreamType.RichText);
                if (File.Exists(newPath))
                    result = newPath;
                else
                    result= _pathFile;

                return result;
            }
            catch(Exception ex)
            {
                MessageBox.Show("AppendFormattedText() " + ex.ToString());
                return "";
            }
        }
        public void DoWriteToLog(string strLogMessage, bool blnHighlighted = false, Color myFontColor = default(Color), bool blnNewLine = true)
        {
            RichTextBox rtbLog = new RichTextBox();
            string dtStamp = "[" + DateTime.Now.ToString("HH:mm:ss") + "] ";
            if (blnNewLine)
                strLogMessage = dtStamp + strLogMessage + Environment.NewLine;
            if (blnHighlighted)
            {
                rtbLog.SelectionColor = myFontColor;             // Optional font color passed to method
                if (strLogMessage.ToLower().Contains("help"))       // IF there is 'help' in the message, highlight it blue
                    rtbLog.SelectionBackColor = Color.LightBlue;
                rtbLog.SelectionFont = new System.Drawing.Font("Cambria", 10F, FontStyle.Bold, GraphicsUnit.Point);
                rtbLog.AppendText(strLogMessage);
            }
            else
                rtbLog.AppendText(strLogMessage);
            rtbLog.ScrollToCaret();
        }
        public byte[] addByteToArray(byte[] _input_bArray, byte _newByte, Boolean _add_to_start_of_array)
        {
            byte[] newArray;
            if (_add_to_start_of_array)
            {
                newArray = new byte[_input_bArray.Length + 1];
                _input_bArray.CopyTo(newArray, 1);
                //newArray[0] = _newByte;
            }
            else
            {
                newArray = new byte[_input_bArray.Length + 1];
                _input_bArray.CopyTo(newArray, 0);
                newArray[_input_bArray.Length] = _newByte;
            }
            return newArray;
        }
        private byte[] String_To_Bytes2(string strInput)
        {
            int numBytes = (strInput.Length) / 2;
            byte[] bytes = new byte[numBytes];

            for (int x = 0; x < numBytes; ++x)
            {
                bytes[x] = Convert.ToByte(strInput.Substring(x * 2, 2), 16);
            }
            return bytes;
        }
        private void RTBoxSetLines(RichTextBox rtbox, int lines)
        {
            while (lines > 0)    // here you may use type you like
            {
                rtbox.AppendText(System.Environment.NewLine + " AAAAAAAAAA ");
                lines--;
            }
        }



        #endregion
    }
}
