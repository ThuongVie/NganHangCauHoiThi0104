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
using static DTO.EnumDto;

namespace NganHangCauHoiThi.UserControls
{
    public partial class FrmQuanLyKhoa : Form
    {
        KhoaBLL khoaBLL = new KhoaBLL(); 
        NhomQuyenBLL nhomQuyenBLL = new NhomQuyenBLL();
        private bool isBtnThemVisible = true, isBtnSuaVisible = true, isBtnXoaVisible = true;
        private bool isInAddMode = false;
        public long idKhoa = 0;
        public string tenKhoa = "", maKhoa = "", chuThich ="", nguoiTao ="", nguoiCapNhat="";
        EnumDto.eThaoTac eThaoTac;
        private bool isLabelMode;

        public FrmQuanLyKhoa()
        {
            InitializeComponent();
        }

        private void FrmQuanLyKhoa_Load(object sender, EventArgs e)
        {
            //Load all cau hoi ra datagridview
            LoadDataGridViewKhoa();

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            //Phan quyen nguoi dung 
            LoadQuyen(NguoiDung.MaNhomNguoiSuDung, this.Name);
        }

        private void LoadQuyen(string maNhomNguoiSuDung, string maForm)
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

        private void LoadDataGridViewKhoa()
        {
            try
            {
                dgvThongKeKhoa.DataSource = khoaBLL.LoadKhoaTheoDieuKien(null,null);
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
                dgvThongKeKhoa.Columns["ID"].Visible = false; // ẩn cột ID               
                int dem = 0;
                for (int i = 0; i < dgvThongKeKhoa.Rows.Count; i++)
                {
                    dgvThongKeKhoa.Rows[i].Cells["STT"].Value = (i + 1).ToString();
                    dem++;
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
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetButtonStatus("Edit");
            isLabelMode = true;
            LoadLabelWarning();
        }

        private void LoadLabelWarning()
        {
            label91.Visible = isLabelMode;
            label90.Visible = isLabelMode;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThongKeKhoa.SelectedRows.Count > 0)
            {
                // Lấy MaMonHoc của hàng được chọn

                idKhoa = Convert.ToInt32(dgvThongKeKhoa.SelectedRows[0].Cells["ID"].Value);
                tenKhoa = dgvThongKeKhoa.SelectedRows[0].Cells["TenKhoa1"].Value.ToString();
                maKhoa = dgvThongKeKhoa.SelectedRows[0].Cells["MaKhoa1"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa khoa " + tenKhoa + "(" + maKhoa + ")" + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    EnumDto.eThaoTac eThaoTac = EnumDto.eThaoTac.xoa;
                    idKhoa = khoaBLL.ThaoTacKhoa_Store(idKhoa, maKhoa, tenKhoa, chuThich, nguoiTao, nguoiCapNhat, eThaoTac);
                    MessageBox.Show("Xóa thành công");
                    LoadDataGridViewKhoa();
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
                if (string.IsNullOrWhiteSpace(txtMaKhoa.Text) || string.IsNullOrWhiteSpace(txtTenKhoa.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Kiểm tra mã khoa đã tồn tại trong CSDL hay chưa
                else if (!string.IsNullOrEmpty(txtMaKhoa.Text) && idKhoa == 0)
                {
                    string maHocPhanExists = khoaBLL.CheckMaKhoa(txtMaKhoa.Text);
                    if (maHocPhanExists != "0")
                    {
                        MessageBox.Show("Mã khoa đã tồn tại trong CSDL!");
                    }
                    else
                    {
                        maKhoa = txtMaKhoa.Text;
                        tenKhoa = txtTenKhoa.Text;
                        chuThich = rtbChuThich.Text;

                        eThaoTac = EnumDto.eThaoTac.them;
                        if (idKhoa > 0)
                        {
                            eThaoTac = EnumDto.eThaoTac.sua;
                        }
                        idKhoa = khoaBLL.ThaoTacKhoa_Store(idKhoa, maKhoa, tenKhoa, chuThich, nguoiTao, nguoiCapNhat, eThaoTac);

                        LoadDataGridViewKhoa();
                        SetButtonStatus("Save");
                        MessageBox.Show("Lưu thành công");
                        isInAddMode = false;
                        ResetComboboxSelected();
                        ResetComboboxSelected();
                    }
                }
                else
                {
                    maKhoa = txtMaKhoa.Text;
                    tenKhoa = txtTenKhoa.Text;
                    chuThich = rtbChuThich.Text;

                    eThaoTac = EnumDto.eThaoTac.them;
                    if (idKhoa > 0)
                    {
                        eThaoTac = EnumDto.eThaoTac.sua;
                    }
                    idKhoa = khoaBLL.ThaoTacKhoa_Store(idKhoa, maKhoa, tenKhoa, chuThich, nguoiTao, nguoiCapNhat, eThaoTac);

                    LoadDataGridViewKhoa();
                    SetButtonStatus("Save");
                    MessageBox.Show("Lưu thành công");
                    isInAddMode = false;
                    ResetComboboxSelected();
                    ResetComboboxSelected();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatDS_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportDataGridViewToExcel(dgvThongKeKhoa);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetButtonStatus("Cancel");
            isLabelMode = false;
            LoadLabelWarning();
        }

        private void dgvThongKeKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isInAddMode && e.RowIndex >= 0) // kiểm tra xem người dùng đã chọn hàng (row) chưa
            {
                DataGridViewRow row = dgvThongKeKhoa.Rows[e.RowIndex];

                idKhoa = Convert.ToInt32(dgvThongKeKhoa.CurrentRow.Cells["ID"].Value);

                // Hiển thị thông tin của hàng được chọn ra các control
                txtTenKhoa.Text = row.Cells["TenKhoa1"].Value.ToString();
                txtMaKhoa.Text = row.Cells["MaKhoa1"].Value.ToString();
                rtbChuThich.Text = row.Cells["ChuThich1"].Value.ToString();               
            }
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            ResetComboboxSelected();
            ResetComboboxSelected();
        }
        private void ResetComboboxSelected()
        {
            txtTenKhoa.Text = string.Empty;
            txtMaKhoa.Text = string.Empty;
            rtbChuThich.Text = string.Empty;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetComboboxSelected();
            ResetComboboxSelected();
        }

        private void SetButtonStatus(string action)
        {
            switch (action)
            {
                case "Add":
                    idKhoa = 0;
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
