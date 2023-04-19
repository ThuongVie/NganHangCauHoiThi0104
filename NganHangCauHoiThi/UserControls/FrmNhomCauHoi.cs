using BLL;
using DTO;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DTO.EnumDto;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NganHangCauHoiThi.UserControls
{
    public partial class FrmNhomCauHoi : Form
    {
        MonHocBLL monHocBLL = new MonHocBLL();
        KhoaBLL khoaBLL = new KhoaBLL();
        CauHoiBLL cauHoiBLL = new CauHoiBLL();
        NhomCauHoiBLL nhomCauHoiBLL = new NhomCauHoiBLL();
        NhomQuyenBLL nhomQuyenBLL = new NhomQuyenBLL();
        private bool isBtnThemVisible = true, isBtnSuaVisible = true, isBtnXoaVisible = true;
        DateTime tungay, denngay;
        private int idMon = 0, idKhoa = 0, diem =0, thoigiandukien =0;
        string maNhom = "", chuThich ="";
        private long idNhomCau = 0;
        private bool isInAddMode = false;
        EnumDto.eThaoTac eThaoTac;
        private bool isLabelMode;
        public FrmNhomCauHoi()
        {
            InitializeComponent();
        }

        private void FrmNhomCauHoi_Load(object sender, EventArgs e)
        {
            cbbKhoa.DisplayMember = "TenKhoa";
            cbbKhoa.ValueMember = "ID";
            cbbKhoa.DataSource = khoaBLL.LoadKhoa();

            LoadDataGridViewNhomCauHoi();

            //Reset lua chon combobox
            ResetComboboxSelected();

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

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
            txtDiem.Text = string.Empty;
            txtMaNhom.Text = string.Empty;
            txtTimeDuKien.Text = string.Empty;
            rtbChuThich.Clear();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetComboboxSelected();
            ResetComboboxSelected();
        }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbbTenMon.DisplayMember = "TenMon";
                cbbTenMon.ValueMember = "ID";
                // Lấy IDKhoa từ combobox 
                int IDKhoa = 0;
                object value = cbbKhoa.SelectedValue;
                IDKhoa = Convert.ToInt32(value);

                DateTime tungay = new DateTime(2000, 1, 1);
                DateTime denngay = DateTime.Now;

                if (IDKhoa != 0)
                {
                    // Load list môn học theo ID Khoa
                    cbbTenMon.DataSource = cauHoiBLL.LoadMonHocTheoDieuKien(IDKhoa, null, null, null, 0, tungay, denngay);

                    //Load dgv theo khoa
                    //LoadcauHoiTheoKhoa(IDKhoa);
                    cbbTenMon.SelectedIndex = -1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetButtonStatus("Add");
            isLabelMode = true;
            LoadLabelWarning();
            txtMaNhom.Visible = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetButtonStatus("Edit");
            isLabelMode = true;
            LoadLabelWarning();
        }

        private void LoadLabelWarning()
        {           
            label91.Visible= isLabelMode;
            label90.Visible = isLabelMode;
            label93.Visible = isLabelMode;
            label92.Visible = isLabelMode;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThongKeNhomCau.SelectedRows.Count > 0)
            {
                // Lấy MaMonHoc của hàng được chọn

                idNhomCau = Convert.ToInt32(dgvThongKeNhomCau.SelectedRows[0].Cells["ID"].Value);   
                idMon = Convert.ToInt32(dgvThongKeNhomCau.SelectedRows[0].Cells["IDMonHoc1"].Value);
                maNhom = dgvThongKeNhomCau.SelectedRows[0].Cells["MaNhom1"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhóm câu " + maNhom + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    EnumDto.eThaoTac eThaoTac = EnumDto.eThaoTac.xoa;
                    idNhomCau = nhomCauHoiBLL.ThaoTacNhomCau_Store(idNhomCau, idMon, maNhom, diem, thoigiandukien, chuThich, eThaoTac);
                    MessageBox.Show("Xóa thành công");
                    LoadDataGridViewNhomCauHoi();
                    ResetComboboxSelected();
                    ResetComboboxSelected();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một môn học để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {                                           
                if (string.IsNullOrWhiteSpace(txtDiem.Text) || string.IsNullOrWhiteSpace(txtTimeDuKien.Text) || cbbKhoa.SelectedIndex == -1 || cbbTenMon.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                else if (!Validator.IsNumber(txtDiem.Text))
                {
                    MessageBox.Show("Vui lòng nhập đúng số điểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (!Validator.IsNumber(txtTimeDuKien.Text))
                {
                    MessageBox.Show("Vui lòng nhập đúng thời gian dự kiến.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    idKhoa = Convert.ToInt32(cbbKhoa.SelectedValue);
                    idMon = Convert.ToInt32(cbbTenMon.SelectedValue);
                    maNhom = txtMaNhom.Text;
                    chuThich = rtbChuThich.Text;
                    diem = Convert.ToInt32(txtDiem.Text);
                    thoigiandukien = Convert.ToInt32(txtTimeDuKien.Text);
                    eThaoTac = EnumDto.eThaoTac.them;
                    if (idNhomCau > 0)
                    {
                        eThaoTac = EnumDto.eThaoTac.sua;
                    }
                    idNhomCau = nhomCauHoiBLL.ThaoTacNhomCau_Store(idNhomCau, idMon, maNhom, diem, thoigiandukien, chuThich, eThaoTac);

                    LoadDataGridViewNhomCauHoi();
                    SetButtonStatus("Save");
                    MessageBox.Show("Lưu thành công");
                    txtMaNhom.Visible = true;
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
            txtMaNhom.Visible = true;
            isInAddMode = false;
        }

        private void btnXuatDS_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportDataGridViewToExcel(dgvThongKeNhomCau);
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            ResetComboboxSelected();
            ResetComboboxSelected();
        }

        private void dgvThongKeNhomCau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isInAddMode && e.RowIndex >= 0) // kiểm tra xem người dùng đã chọn hàng (row) chưa
            {
                DataGridViewRow row = dgvThongKeNhomCau.Rows[e.RowIndex];

                idNhomCau = Convert.ToInt32(dgvThongKeNhomCau.CurrentRow.Cells["ID"].Value);

                // Hiển thị thông tin của hàng được chọn ra các control
                cbbKhoa.Text = row.Cells["TenKhoa1"].Value.ToString();
                cbbTenMon.Text = row.Cells["TenMon1"].Value.ToString();
                txtMaNhom.Text = row.Cells["MaNhom1"].Value.ToString();
                txtDiem.Text = row.Cells["Diem1"].Value.ToString();
                txtTimeDuKien.Text = row.Cells["ThoiGianDuKien1"].Value.ToString();
                rtbChuThich.Text = row.Cells["ChuThich1"].Value.ToString();
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {

        }

        private void LoadDataGridViewNhomCauHoi()
        {
            try
            {
                tungay = new DateTime(2000, 1, 1);
                denngay = DateTime.Now;
                dgvThongKeNhomCau.DataSource = nhomCauHoiBLL.LoadNhomCauHoiTheoDieuKien(0, 0, null, 0, 0, tungay, denngay);
                EdittingColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                idKhoa = Convert.ToInt32(cbbKhoa.SelectedValue);
                idMon = Convert.ToInt32(cbbTenMon.SelectedValue);
                maNhom = txtMaNhom.Text.ToString();
                if (!int.TryParse(txtDiem.Text, out diem))
                {
                    diem = 0;
                }
                if (!int.TryParse(txtTimeDuKien.Text, out thoigiandukien))
                {
                    thoigiandukien = 0;
                }
                DateTime tungay = new DateTime(2000, 1, 1);
                DateTime denngay = DateTime.Now;
                dgvThongKeNhomCau.DataSource = nhomCauHoiBLL.LoadNhomCauHoiTheoDieuKien(idKhoa, idMon, maNhom, diem, thoigiandukien, tungay, denngay);
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
                dgvThongKeNhomCau.Columns["ID"].Visible = false;
                dgvThongKeNhomCau.Columns["IDMonHoc1"].Visible = false;
                dgvThongKeNhomCau.Columns["MaMon1"].Visible = false;
                int dem = 0;
                for (int i = 0; i < dgvThongKeNhomCau.Rows.Count; i++)
                {
                    dgvThongKeNhomCau.Rows[i].Cells["STT"].Value = (i + 1).ToString();
                    dem++;
                }
                //labelTongCauHoi.Text = "Tổng: " + dem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SetButtonStatus(string action)
        {
            switch (action)
            {
                case "Add":
                    idNhomCau = 0;
                    isInAddMode = true;
                    txtMaNhom.Text = string.Empty;
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
    }
}
