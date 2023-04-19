using BLL;
using DTO;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DTO.EnumDto;
using static DTO.NguoiDung;

namespace NganHangCauHoiThi.UserControls
{
    public partial class FrmThongKeMonHoc : Form
    {
        CauHoiBLL cHoiBll = new CauHoiBLL();
        MonHocBLL monHocBLL = new MonHocBLL();
        KhoaBLL khoaBLL = new KhoaBLL();
        NhomCauHoiBLL nhomCauHoiBLL = new NhomCauHoiBLL();
        NhomQuyenBLL nhomQuyenBLL = new NhomQuyenBLL();
        private bool isBtnThemVisible = true, isBtnSuaVisible = true, isBtnXoaVisible = true;
        EnumDto.eThaoTac eThaoTac;
        public DateTime tungay, denngay;
        public int idKhoa = 0, soTinChi = 0;
        public string maMon = "", tenMon = "", maHocPhan = "";
        public long idMonHoc = 0;
        private bool isInAddMode = false;
        

        private DataTable dtListMonHoc;
        private bool isLabelMode;

        public FrmThongKeMonHoc()
        {
            InitializeComponent();
        }

        private void FrmThongKeMonHoc_Load(object sender, EventArgs e)
        {
            cbbKhoa.DisplayMember = "TenKhoa";
            cbbKhoa.ValueMember = "ID";
            cbbKhoa.DataSource = khoaBLL.LoadKhoa();

            //Reset lua chon combobox
            ResetComboboxSelected();

            //Load all cau hoi ra datagridview
            LoadDataGridViewMonHoc();

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            //Phan quyen nguoi dung 
            LoadQuyen(NguoiDung.MaNhomNguoiSuDung, this.Name);
        }

        private void LoadQuyen(string maNhomNguoiSuDung,string maForm)
        {
            // Lấy thông tin về quyền của người dùng
            DataTable dtQuyen = nhomQuyenBLL.LoadNhomQuyenTheoDieuKien(maNhomNguoiSuDung, maForm);

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

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị các combobox và textbox
                idKhoa = Convert.ToInt32(cbbKhoa.SelectedValue);
                maMon = txtMaMon.Text.Trim();
                tenMon = txtTenMon.Text.Trim();
                maHocPhan = txtMaHocPhan.Text.Trim();

                if (!int.TryParse(txtSoTinChi.Text, out soTinChi))
                {
                    soTinChi = 0;
                }
                DateTime tungay = new DateTime(2000, 1, 1);
                DateTime denngay = DateTime.Now;

                dgvThongKeMonHoc.DataSource = cHoiBll.LoadMonHocTheoDieuKien(idKhoa, maMon, tenMon, maHocPhan, soTinChi, tungay, denngay);
                EdittingColumn();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvThongKeMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isInAddMode && e.RowIndex >= 0) // kiểm tra xem người dùng đã chọn hàng (row) chưa
            {
                DataGridViewRow row = dgvThongKeMonHoc.Rows[e.RowIndex];

                idMonHoc = Convert.ToInt32(dgvThongKeMonHoc.CurrentRow.Cells["ID"].Value);

                // Hiển thị thông tin của hàng được chọn ra các control
                cbbKhoa.Text = row.Cells["TenKhoa1"].Value.ToString();
                txtMaMon.Text = row.Cells["MaMon1"].Value.ToString();
                txtTenMon.Text = row.Cells["TenMon1"].Value.ToString();
                txtMaHocPhan.Text = row.Cells["MaHocPhan1"].Value.ToString();
                txtSoTinChi.Text = row.Cells["SoTinChi1"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetButtonStatus("Add");
            isLabelMode = true;
            LoadLabelWarning();
            txtMaMon.Visible = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetButtonStatus("Edit");
            isLabelMode = true;
            LoadLabelWarning();
        }

        private void LoadLabelWarning()
        {
            label90.Visible = isLabelMode;
            label93.Visible = isLabelMode;
            label92.Visible = isLabelMode;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvThongKeMonHoc.SelectedRows.Count > 0)
                {
                    // Lấy MaMonHoc của hàng được chọn

                    idMonHoc = Convert.ToInt32(dgvThongKeMonHoc.SelectedRows[0].Cells["ID"].Value);
                    tenMon = dgvThongKeMonHoc.SelectedRows[0].Cells["TenMon1"].Value.ToString();
                    maMon = dgvThongKeMonHoc.SelectedRows[0].Cells["MaMon1"].Value.ToString();

                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa môn " + tenMon + "(" + maMon + ")" + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        EnumDto.eThaoTac eThaoTac = EnumDto.eThaoTac.xoa;
                        idMonHoc = monHocBLL.ThaoTacMonHoc_Store(idMonHoc, idKhoa, maMon, tenMon, maHocPhan, soTinChi, NguoiDung.UserName, eThaoTac);
                        MessageBox.Show("Xóa thành công");
                        LoadDataGridViewMonHoc();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một môn học để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                if (string.IsNullOrWhiteSpace(txtMaHocPhan.Text) || string.IsNullOrWhiteSpace(txtTenMon.Text) || string.IsNullOrWhiteSpace(txtSoTinChi.Text) || cbbKhoa.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (!Validator.IsNumber(txtSoTinChi.Text))
                {
                    MessageBox.Show("Vui lòng nhập đúng số tín chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (!Validator.IsMaHocPhan(txtMaHocPhan.Text))
                {
                    MessageBox.Show("Vui lòng nhập đúng Mã học phần gồm 12 số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                // Kiểm tra mã học phần đã tồn tại trong CSDL hay chưa
                else if (!string.IsNullOrEmpty(txtMaHocPhan.Text) && idMonHoc == 0)
                {
                    string maHocPhanExists = monHocBLL.CheckMaHocPhan(txtMaHocPhan.Text);
                    if (maHocPhanExists != "0")
                    {
                        MessageBox.Show("Mã học phần đã tồn tại trong CSDL!");
                    }
                    else
                    {
                        object value = cbbKhoa.SelectedValue;
                        idKhoa = Convert.ToInt32(value);
                        maMon = txtMaMon.Text;
                        tenMon = txtTenMon.Text;
                        maHocPhan = txtMaHocPhan.Text;
                        soTinChi = Convert.ToInt32(txtSoTinChi.Text);

                        eThaoTac = EnumDto.eThaoTac.them;
                        if (idMonHoc > 0)
                        {
                            eThaoTac = EnumDto.eThaoTac.sua;
                        }
                        idMonHoc = monHocBLL.ThaoTacMonHoc_Store(idMonHoc, idKhoa, maMon, tenMon, maHocPhan, soTinChi, NguoiDung.UserName, eThaoTac);

                        LoadDataGridViewMonHoc();
                        SetButtonStatus("Save");
                        MessageBox.Show("Lưu thành công");
                        txtMaMon.Visible = true;
                        isInAddMode = false;
                    }
                }

                else
                {
                    object value = cbbKhoa.SelectedValue;
                    idKhoa = Convert.ToInt32(value);
                    maMon = txtMaMon.Text;
                    tenMon = txtTenMon.Text;
                    maHocPhan = txtMaHocPhan.Text;
                    soTinChi = Convert.ToInt32(txtSoTinChi.Text);

                    eThaoTac = EnumDto.eThaoTac.them;
                    if (idMonHoc > 0)
                    {
                        eThaoTac = EnumDto.eThaoTac.sua;
                    }
                    idMonHoc = monHocBLL.ThaoTacMonHoc_Store(idMonHoc, idKhoa, maMon, tenMon, maHocPhan, soTinChi, NguoiDung.UserName, eThaoTac);

                    LoadDataGridViewMonHoc();
                    SetButtonStatus("Save");
                    MessageBox.Show("Lưu thành công");
                    txtMaMon.Visible = true;
                    isInAddMode = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetButtonStatus("Cancel");
            isLabelMode = false;
            LoadLabelWarning();
            txtMaMon.Visible = true;
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            ResetComboboxSelected();
            ResetComboboxSelected();
        }

        private void SetButtonStatus(string action)
        {
            switch (action)
            {
                case "Add":
                    idMonHoc = 0;
                    isInAddMode = true;
                    /*ResetComboboxSelected();
                    ResetComboboxSelected();*/
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnTroVe.Enabled = false;
                    btnNhapMoi.Enabled = true;
                    btnLuu.Enabled = true;
                    btnHuy.Enabled = true;
                    break;
                case "Edit":
                    txtMaMon.ReadOnly = true;
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnTroVe.Enabled = false;
                    btnNhapMoi.Enabled = true;
                    btnLuu.Enabled = true;
                    btnHuy.Enabled = true;
                    break;
                case "Cancel":
                    txtMaMon.ReadOnly = false;
                    isInAddMode = false;
                    btnThem.Enabled = isBtnThemVisible;
                    btnSua.Enabled = isBtnSuaVisible;
                    btnXoa.Enabled = isBtnXoaVisible;
                    btnTroVe.Enabled = true;
                    btnNhapMoi.Enabled = true;
                    btnLuu.Enabled = false;
                    btnHuy.Enabled = false;
                    break;
                case "Save":
                    isInAddMode = false;
                    isLabelMode = false;
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

        private void btnXuatDS_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportDataGridViewToExcel(dgvThongKeMonHoc);
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetComboboxSelected();
            ResetComboboxSelected();
            
        }

        private void LoadDataGridViewMonHoc()
        {
            try
            {
                tungay = new DateTime(2000, 1, 1);
                denngay = DateTime.Now;
                dtListMonHoc = cHoiBll.LoadMonHocTheoDieuKien(0, null, null, null, 0, tungay, denngay);
                dgvThongKeMonHoc.DataSource = dtListMonHoc;
                EdittingColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void EdittingColumn()
        {
            try
            {
                //dgvThongKeMonHoc.Columns["IDKhoa"].Visible = false; // ẩn cột IDMonHoc
                dgvThongKeMonHoc.Columns["ID"].Visible = false; // ẩn cột ID               
                int dem = 0;
                for (int i = 0; i < dgvThongKeMonHoc.Rows.Count; i++)
                {
                    dgvThongKeMonHoc.Rows[i].Cells["STT"].Value = (i + 1).ToString();
                    dem++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ResetComboboxSelected()
        {
            cbbKhoa.SelectedIndex = -1;
            txtMaHocPhan.Text = string.Empty;
            txtSoTinChi.Text = string.Empty;
            txtMaMon.Text = string.Empty;
            txtTenMon.Text = string.Empty;
        }
    }
}
