using BLL;
using DTO;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NganHangCauHoiThi.UserControls
{
    public partial class UC_ThemCauHoi : UserControl
    {
        public long idCauHoi = 0;
        public int IDCauHoiCellClick = 0;
        public int idKhoa = 0, soTinChi = 0;
        public string maMon = "", tenMon = "", maHocPhan = "";
        public long idMonHoc = 0;
        NhomQuyenBLL nhomQuyenBLL = new NhomQuyenBLL();
        private bool isBtnThemVisible = true, isBtnSuaVisible = true, isBtnXoaVisible = true;
        MonHocBLL monHocBLL = new MonHocBLL();
        KhoaBLL khoaBLL = new KhoaBLL();
        CauHoiBLL cauHoiBLL = new CauHoiBLL();
        NhomCauHoiBLL nhomCauHoiBLL = new NhomCauHoiBLL();
        System.Data.DataTable dtListCauHoi = new System.Data.DataTable();

        public UC_ThemCauHoi()
        {
            InitializeComponent();
        }
       
        private void UC_CauHoi_Load(object sender, EventArgs e)
        {
            cbbKhoa.DisplayMember = "TenKhoa";
            cbbKhoa.ValueMember = "ID";
            cbbKhoa.DataSource = khoaBLL.LoadKhoa();
           
            if (idCauHoi > 0)
            {
                //Load cbb Ten Mon
                cbbTenMon.DisplayMember = "TenMon";
                cbbTenMon.ValueMember = "ID";
                // Lấy IDKhoa từ combobox 
                DateTime tungay = new DateTime(2000, 1, 1);
                DateTime denngay = DateTime.Now;

                cbbTenMon.DataSource = cauHoiBLL.LoadMonHocTheoDieuKien(0, null, null, null, 0, tungay, denngay);

                LoadCauHoi(idCauHoi);
            }
            else
            {
                //Reset lua chon combobox
                ResetComboboxSelected();
            }

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            dtpTuNgay.Value = DateTime.Now;

            //Phan quyen nguoi dung 
            LoadQuyen(NguoiDung.MaNhomNguoiSuDung, this.Name);
        }

        private void LoadQuyen(string maNhomNguoiSuDung, string maForm)
        {
            // Lấy thông tin về quyền của người dùng
            System.Data.DataTable dtQuyen = nhomQuyenBLL.LoadNhomQuyenTheoDieuKien(maNhomNguoiSuDung, maForm);

            if (dtQuyen != null && dtQuyen.Rows.Count > 0)
            {
                // Lấy chuỗi quyền từ cột Quyen trong bảng TblNhomQuyen
                string quyen = dtQuyen.Rows[0]["Quyen"].ToString();

                if (quyen == "0")
                {
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;
                    isBtnThemVisible = false;
                    isBtnSuaVisible = false;
                    isBtnXoaVisible = false;
                }
                else if (quyen != "4")
                {
                    if (!quyen.Contains("1"))
                    {
                        btnThem.Enabled = false;
                        isBtnThemVisible = false;
                    }
                    if (!quyen.Contains("2"))
                    {
                        btnSua.Enabled = false;
                        isBtnSuaVisible = false;
                    }
                    if (!quyen.Contains("3"))
                    {
                        btnXoa.Enabled = false;
                        isBtnXoaVisible = false;
                    }
                }
            }
        }

        private void ResetComboboxSelected()
        {
            cbbKhoa.SelectedIndex = -1;           
            cbbTenMon.SelectedIndex = -1;
            cbbNhomCauHoi.SelectedIndex = -1;
            txtMaCauHoi.Text= string.Empty;
            txtFilePath.Text= string.Empty;
            rtbNoiDungCauHoi.Clear();
        }

        // Hiển thị List tên môn học khi chọn Khoa 
        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadComboboxTenMon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadComboboxTenMon()
        {
            cbbTenMon.DisplayMember = "TenMon";
            cbbTenMon.ValueMember = "ID";
            // Lấy IDKhoa từ combobox 
            int IDKhoa = 0;
            object value = cbbKhoa.SelectedValue;
            IDKhoa = Convert.ToInt32(value);

            DateTime tungay = new DateTime(2000, 1, 1);
            DateTime denngay = dtpTuNgay.Value;

            if (IDKhoa != 0)
            {
                // Load list môn học theo ID Khoa
                cbbTenMon.DataSource = cauHoiBLL.LoadMonHocTheoDieuKien(IDKhoa, maMon, tenMon, maHocPhan, soTinChi, tungay, denngay);

                //Load dgv theo khoa
                //LoadcauHoiTheoKhoa(IDKhoa);
                //cbbTenMon.SelectedIndex = -1;
            }
        }


        private void cbbTenMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy ID Mon hoc từ combobox Ten mon
                object value = cbbTenMon.SelectedValue;
                int IDMon = Convert.ToInt32(value);
                if (IDMon != 0)
                {
                    cbbNhomCauHoi.DisplayMember = "MaNhom";
                    cbbNhomCauHoi.ValueMember = "ID";
                    cbbNhomCauHoi.DataSource = nhomCauHoiBLL.LoadNhomCauHoiTheoMon(IDMon);
                    //cbbNhomCauHoi.SelectedIndex = -1;

                    //Load Cau Hoi Theo Mon Hoc
                    //LoadCauHoiTheoMonHoc(IDMon);
                }
                else
                {
                    cbbNhomCauHoi.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbbNhomCauHoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadCauHoiTheoNhomCauHoi();
        }

        //Nhập câu hỏi file Word từ máy tính
        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.ShowDialog();
                txtFilePath.Text = fileDialog.FileName;
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
                rtbNoiDungCauHoi.Rtf = dataObject.GetData(DataFormats.Rtf).ToString();
                application.Quit(ref missing, ref missing, ref missing);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbKhoa.SelectedIndex == -1 || cbbTenMon.SelectedIndex == -1 || cbbNhomCauHoi.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    object value = cbbTenMon.SelectedValue;
                    int IDMon = Convert.ToInt32(value);
                    string NhomCauHoi = cbbNhomCauHoi.Text;
                    string FilePath = txtFilePath.Text;
                    SaveFile(NhomCauHoi, IDMon, FilePath);
                    MessageBox.Show("Lưu thành công");
                    SetButtonStatus("Save");
                    txtMaCauHoi.Visible = true;
                }

                //LoadCauHoiTheoNhomCauHoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void SaveFile(string NhomCauHoi, int IDMonHoc, string filePath)
        {
            try
            {
                using (Stream stream = File.OpenRead(filePath))
                {
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    string FilePath = filePath.ToString();

                    EnumDto.eThaoTac eThaoTac = EnumDto.eThaoTac.them;
                    if (idCauHoi > 0)
                    {
                        eThaoTac = EnumDto.eThaoTac.sua;
                    }
                    idCauHoi = cauHoiBLL.ThaoTacCauHoi_Store(_idCauHoi: idCauHoi, _maCau: txtMaCauHoi.Text,
                        NhomCauHoi, IDMonHoc, FilePath, NguoiDung.UserName, eThaoTac);
                    if (idCauHoi > 0)
                    {
                        LoadCauHoi(idCauHoi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNhapListCauHoi_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

                // Mở file Word
                Document document = wordApp.Documents.Open(@"E:\Example.docx");

                // Tạo một danh sách chứa các đoạn văn
                List<string> paragraphsUnderHeadings = new List<string>();

                // Lấy tất cả các tiêu đề trong file Word
                foreach (Paragraph para in document.Paragraphs)
                {
                    if (para.Range.get_Style().NameLocal == "Heading 1")
                    {
                        // Lấy đoạn văn dưới tiêu đề
                        Paragraph nextPara = para.Next();

                        // Thêm đoạn văn vào danh sách
                        paragraphsUnderHeadings.Add(nextPara.Range.Text);
                    }
                }

                // In danh sách các đoạn văn
                foreach (string para in paragraphsUnderHeadings)
                {
                    rtbNoiDungCauHoi.Text =para;
                }

                // Đóng file Word và giải phóng tài nguyên
                document.Close();
                wordApp.Quit();
            }
            catch
            {
                MessageBox.Show("Không đọc được file ");
            }
        }

        private void LoadCauHoi(long idCauHoi)
        {
            try
            {
                LoadThongTinCauHoi(idCauHoi);

                // Lấy nội dung câu hỏi từ cơ sở dữ liệu
                byte[] noiDungBytes = cauHoiBLL.GetNoiDungCauHoi(idCauHoi);
                string fName = System.Windows.Forms.Application.StartupPath + @"\Trash\Cau" + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".rtf";

                File.WriteAllBytes(fName, noiDungBytes);

                string content = GetRTFContent(fName);

                // Hiển thị nội dung tài liệu RTF trên RichTextBox
                rtbNoiDungCauHoi.Rtf = content;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadThongTinCauHoi(long idCauHoi)
        {
            try
            {
                // Gọi phương thức GetCauHoiById để lấy thông tin câu hỏi
                System.Data.DataTable dtCauHoi = cauHoiBLL.GetCauHoiById(idCauHoi);

                if (dtCauHoi != null && dtCauHoi.Rows.Count > 0)
                {
                    // Lấy giá trị IDMonHoc từ câu hỏi
                    int idMonHoc = Convert.ToInt32(dtCauHoi.Rows[0]["IDMonHoc"]);

                    // Gọi phương thức GetMonHocById để lấy thông tin môn học
                    System.Data.DataTable dtMonHoc = cauHoiBLL.GetMonHocById(idMonHoc);

                    if (dtMonHoc != null && dtMonHoc.Rows.Count > 0)
                    {
                        // Gọi phương thức GetKhoaById để lấy thông tin khoa
                        System.Data.DataTable dtKhoa = cauHoiBLL.GetKhoaByIdMon(idMonHoc);

                        if (dtKhoa != null && dtKhoa.Rows.Count > 0)
                        {
                            // Điền thông tin Khoa vào combobox cbbKhoa
                            cbbKhoa.Text = dtKhoa.Rows[0]["TenKhoa"].ToString();
                        }

                        // Điền thông tin Tên Môn vào combobox cbbTenMon
                        cbbTenMon.Text = dtMonHoc.Rows[0]["TenMon"].ToString();
                    }

                    // Điền thông tin Nhóm câu hỏi vào combobox cbbNhomCauHoi
                    cbbNhomCauHoi.Text = dtCauHoi.Rows[0]["NhomCauHoi"].ToString();
                    txtFilePath.Text = dtCauHoi.Rows[0]["FilePath"].ToString();
                    txtMaCauHoi.Text = dtCauHoi.Rows[0]["MaCauHoi"].ToString();
                    txtNguoiTao.Text = dtCauHoi.Rows[0]["HoTen"].ToString();
                    dtpTuNgay.Text = dtCauHoi.Rows[0]["NgayTao"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetRTFContent(string rtfFilePath)
        {
            try
            {
                string content = "";

                if (File.Exists(rtfFilePath))
                {
                    Microsoft.Office.Interop.Word._Document doc;
                    Microsoft.Office.Interop.Word._Application app = new Microsoft.Office.Interop.Word.Application();

                    doc = app.Documents.Open(rtfFilePath, ReadOnly: true, Visible: false);

                    doc.ActiveWindow.Selection.WholeStory();
                    doc.ActiveWindow.Selection.Copy();

                    if (Clipboard.ContainsData(DataFormats.Rtf))
                    {
                        IDataObject dataObject = Clipboard.GetDataObject();
                        if (dataObject.GetDataPresent(DataFormats.Rtf))
                        {
                            content = dataObject.GetData(DataFormats.Rtf).ToString();
                        }
                    }
                    doc.Close();
                    app.Quit();
                }

                return content;
            }
            catch {
                return null;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frm_TrangChu frmTrangChu = (frm_TrangChu)System.Windows.Forms.Application.OpenForms["FrmTrangChu"];

            FrmThongKeCauHoi frmThongKeCauHoi = new FrmThongKeCauHoi();
            AddFormcontrol(frmThongKeCauHoi);
        }
        public void AddFormcontrol(Form form)
        {
            if (System.Windows.Forms.Application.OpenForms.OfType<frm_TrangChu>().FirstOrDefault() is frm_TrangChu frm)
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                //frm_TrangChu frm_TrangChu = new frm_TrangChu();
                frm.panelDesktop.Controls.Clear();
                frm.panelDesktop.Controls.Add(form);
                frm.panelDesktop.Tag = form;
                form.BringToFront();
                form.Show();
            }
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            //idCauHoi = 0;
            ResetComboboxSelected();
            ResetComboboxSelected();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetButtonStatus("Add");
            txtMaCauHoi.Visible = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetButtonStatus("Edit");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaCauHoi.Text != null && txtMaCauHoi.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa câu hỏi " + txtMaCauHoi.Text + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    EnumDto.eThaoTac eThaoTac = EnumDto.eThaoTac.xoa;
                    idMonHoc = cauHoiBLL.ThaoTacCauHoi_Store(idCauHoi, txtMaCauHoi.Text, null, 0, null, null, eThaoTac);
                    MessageBox.Show("Xóa thành công");
                }
            }
            else
            {
                MessageBox.Show("Chưa có câu hỏi được chọn");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetButtonStatus("Cancel");
            txtMaCauHoi.Visible = true;
        }
        private void SetButtonStatus(string action)
        {
            switch (action)
            {
                case "Add":
                    idCauHoi = 0;                  
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnTroVe.Enabled = false;
                    btnNhapMoi.Enabled = true;
                    btnLuu.Enabled = true;
                    btnHuy.Enabled = true;
                    break;
                case "Edit":
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnTroVe.Enabled = false;
                    btnNhapMoi.Enabled = true;
                    btnLuu.Enabled = true;
                    btnHuy.Enabled = true;
                    break;
                case "Cancel":
                    btnThem.Enabled = isBtnThemVisible;
                    btnSua.Enabled = isBtnSuaVisible;
                    btnXoa.Enabled = isBtnXoaVisible;
                    btnTroVe.Enabled = true;
                    btnNhapMoi.Enabled = true;
                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;
                    break;
                case "Save":
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnNhapMoi.Enabled = true;
                    btnTroVe.Enabled = true;
                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;
                    break;
            }
        }

    }
}
