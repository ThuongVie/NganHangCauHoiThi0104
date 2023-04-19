using BLL;
using DTO;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace NganHangCauHoiThi.UserControls
{
    public partial class FrmThongKeNguoiDung : Form
    {
        KhoaBLL khoaBLL = new KhoaBLL();
        NguoiDungBLL nguoiDungBLL = new NguoiDungBLL();
        NhomQuyenBLL nhomQuyenBLL = new NhomQuyenBLL();
        private bool isBtnThemVisible = true, isBtnSuaVisible = true, isBtnXoaVisible = true;
        EnumDto.eThaoTac eThaoTac;
        public int idKhoa = 0;
        string hoTen = "", userName = "", email ="", diachi="", sdt ="", maNhomNguoiSuDung ="";
        private int IDCauHoiCellClick =0;
        private bool isInAddMode = false;
        public long idNguoiDung = 0;
        private bool isLabelMode;

        public FrmThongKeNguoiDung()
        {
            InitializeComponent();
        }

        private void FrmThongKeNguoiDung_Load(object sender, EventArgs e)
        {
            cbbNhomNguoiSD.DisplayMember = "TenNhom";
            cbbNhomNguoiSD.ValueMember = "MaNhom";
            cbbNhomNguoiSD.DataSource = nguoiDungBLL.LoadNhomNguoiSuDung();

            cbbKhoa.DisplayMember = "TenKhoa";
            cbbKhoa.ValueMember = "ID";
            cbbKhoa.DataSource = khoaBLL.LoadKhoa();

            //Reset lua chon combobox
            ResetComboboxSelected();

            //Load all cau hoi ra datagridview
            LoadDataGridViewMonHoc();

            //Phan quyen nguoi dung 
            LoadQuyen(NguoiDung.MaNhomNguoiSuDung, this.Name);

        }

        private void LoadDataGridViewMonHoc()
        {
            try
            {   
                dgvThongKeNguoiDung.DataSource = nguoiDungBLL.LoadNguoiDungTheoDieuKien_Store(0,null, null, null, null, null, null);
                EdittingColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetButtonStatus("Add");
            isLabelMode = true;
            LoadLabelWarning();
            txtUserName.Visible = false;
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
            label93.Visible = isLabelMode;
            label92.Visible = isLabelMode;
            label94.Visible = isLabelMode;
            label95.Visible = isLabelMode;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThongKeNguoiDung.SelectedRows.Count > 0)
            {
                // Lấy MaMonHoc của hàng được chọn

                idNguoiDung = Convert.ToInt32(dgvThongKeNguoiDung.SelectedRows[0].Cells["ID"].Value);
                hoTen = dgvThongKeNguoiDung.SelectedRows[0].Cells["HoTen1"].Value.ToString();
                userName = dgvThongKeNguoiDung.SelectedRows[0].Cells["UserName1"].Value.ToString();

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa môn " + hoTen + "(" + userName + ")" + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    EnumDto.eThaoTac eThaoTac = EnumDto.eThaoTac.xoa;
                    idNguoiDung = nguoiDungBLL.ThaoTacNguoiDung_Store(idNguoiDung, idKhoa, userName, hoTen, email, sdt, diachi, maNhomNguoiSuDung, " ", " ", eThaoTac);
                    MessageBox.Show("Xóa thành công");
                    LoadDataGridViewMonHoc();
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
                if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtSdt.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text) || cbbKhoa.SelectedIndex == -1 || cbbNhomNguoiSD.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                else if (!Validator.IsValidPhoneNumber(txtSdt.Text))
                {
                    MessageBox.Show("Vui lòng nhập đúng số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!Validator.IsValidEmail(txtEmail.Text))
                {
                    MessageBox.Show("Vui lòng nhập đúng email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    idKhoa = Convert.ToInt32(cbbKhoa.SelectedValue);
                    if (cbbNhomNguoiSD.SelectedIndex != -1)
                    {
                        maNhomNguoiSuDung = cbbNhomNguoiSD.SelectedValue.ToString();
                    }
                    else
                    {
                        maNhomNguoiSuDung = "";
                    }

                    userName = txtUserName.Text;
                    hoTen = txtHoTen.Text;
                    email = txtEmail.Text;
                    sdt = txtSdt.Text;
                    diachi = txtDiaChi.Text;

                    eThaoTac = EnumDto.eThaoTac.them;
                    if (idNguoiDung > 0)
                    {
                        eThaoTac = EnumDto.eThaoTac.sua;
                    }
                    idNguoiDung = nguoiDungBLL.ThaoTacNguoiDung_Store(idNguoiDung, idKhoa, userName, hoTen, email, sdt, diachi, maNhomNguoiSuDung, " ", " ", eThaoTac);
                    LoadDataGridViewMonHoc();
                    SetButtonStatus("Save");
                    MessageBox.Show("Lưu thành công");
                    txtUserName.Visible = true;
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
            txtUserName.Visible = true;
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            ResetComboboxSelected();
            ResetComboboxSelected();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {

        }

        private void SetButtonStatus(string action)
        {
            switch (action)
            {
                case "Add":
                    txtUserName.Text = string.Empty;
                    txtUserName.ReadOnly= true;
                    idNguoiDung = 0;
                    isInAddMode = true;
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
                    txtUserName.ReadOnly = false;
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
                    isLabelMode = false;
                    isInAddMode = false;
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
            ExcelHelper.ExportDataGridViewToExcel(dgvThongKeNguoiDung);
        }

        private void dgvThongKeNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isInAddMode && e.RowIndex >= 0) // kiểm tra xem người dùng đã chọn hàng (row) chưa
            {
                DataGridViewRow row = dgvThongKeNguoiDung.Rows[e.RowIndex];

                idNguoiDung = Convert.ToInt32(dgvThongKeNguoiDung.CurrentRow.Cells["ID"].Value);

                // Hiển thị thông tin của hàng được chọn ra các control
                cbbKhoa.Text = row.Cells["TenKhoa1"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen1"].Value.ToString();
                cbbNhomNguoiSD.Text = row.Cells["TenNhom1"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi1"].Value.ToString();
                txtSdt.Text = row.Cells["SoDienThoai1"].Value.ToString();
                txtEmail.Text = row.Cells["Email1"].Value.ToString();
                txtUserName.Text = row.Cells["UserName1"].Value.ToString();
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                idKhoa = Convert.ToInt32(cbbKhoa.SelectedValue);
                if (cbbNhomNguoiSD.SelectedIndex != -1)
                {
                    maNhomNguoiSuDung = cbbNhomNguoiSD.SelectedValue.ToString();
                }
                else
                {
                    maNhomNguoiSuDung = "";
                }
                
                hoTen = txtHoTen.Text;
                email= txtEmail.Text;
                sdt = txtSdt.Text;
                diachi = txtDiaChi.Text;

                dgvThongKeNguoiDung.DataSource = nguoiDungBLL.LoadNguoiDungTheoDieuKien_Store(idKhoa,maNhomNguoiSuDung, null, hoTen, email, sdt, diachi);
                EdittingColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetComboboxSelected();
            ResetComboboxSelected();
        }

        private void dgvThongKeNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvThongKeNguoiDung.Columns["colBtnXem"].Index && e.RowIndex >= 0)
                {
                    userName = dgvThongKeNguoiDung.CurrentRow.Cells["UserName1"].Value.ToString();

                    FrmPhanQuyenNguoiDung frm = new FrmPhanQuyenNguoiDung();
                    frm.userName = userName;

                    AddFormcontrol(frm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddFormcontrol(Form form)
        {
            if (System.Windows.Forms.Application.OpenForms.OfType<frm_TrangChu>().FirstOrDefault() is frm_TrangChu frm)
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                frm.panelDesktop.Controls.Clear();
                frm.panelDesktop.Controls.Add(form);
                frm.panelDesktop.Tag = form;
                form.BringToFront();
                form.Show();
            }
        }

        private void EdittingColumn()
        {
            try
            {
                dgvThongKeNguoiDung.Columns["IDKhoa"].Visible = false; // ẩn cột IDMonHoc
                dgvThongKeNguoiDung.Columns["ID"].Visible = false; // ẩn cột ID               
                int dem = 0;
                for (int i = 0; i < dgvThongKeNguoiDung.Rows.Count; i++)
                {
                    dgvThongKeNguoiDung.Rows[i].Cells["STT"].Value = (i + 1).ToString();
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
            cbbNhomNguoiSD.SelectedIndex = -1;
            txtHoTen.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSdt.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtUserName.Text = string.Empty;
        }
    }
}
