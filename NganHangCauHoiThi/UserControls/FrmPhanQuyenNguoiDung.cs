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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NganHangCauHoiThi.UserControls
{
    public partial class FrmPhanQuyenNguoiDung : Form
    {
        public long idNhomQuyen = 0 ;
        public string userName = "", hoTen ="", maNhomNguoiSuDung ="", maForm ="", quyen = "", chuthich ="";
        public int idKhoa = 0;
        NguoiDungBLL nguoiDungBLL = new NguoiDungBLL();
        DateTime tungay, denngay;
        private bool isInAddMode = false;
        EnumDto.eThaoTac eThaoTac;
        NhomQuyenBLL nhomQuyenBLL = new NhomQuyenBLL();
        private bool isBtnThemVisible = true, isBtnSuaVisible = true, isBtnXoaVisible = true;
        private bool isLabelMode;

        public FrmPhanQuyenNguoiDung()
        {
            InitializeComponent();
        }

        private void FrmLoadTaoNguoiDung_Load(object sender, EventArgs e)
        {
            cbbNhomNguoiSD.DisplayMember = "TenNhom";
            cbbNhomNguoiSD.ValueMember = "MaNhom";
            cbbNhomNguoiSD.DataSource = nguoiDungBLL.LoadNhomNguoiSuDung();

            cbbForm.DisplayMember = "TenForm";
            cbbForm.ValueMember = "MaForm";
            cbbForm.DataSource = nhomQuyenBLL.LoadPhanQuyenForm();

            //Load nhom người dùng cbbQuyen

            if (userName != null && userName !="")
            {
                LoadThongTinNguoiDung(userName);               
            }
            else
            {
                cbbNhomNguoiSD.SelectedIndex = -1;
                cbbQuyen.SelectedIndex = -1;
                dockUserInfor.Visible = false;
            }

            //Reset lua chon combobox
            //ResetComboboxSelected();
            cbbForm.SelectedIndex = -1;

            //Load all cau hoi ra datagridview
            LoadDataGridViewNhomQuyen();

            //Load cac quyen 
            LoadCbbQuyen();

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
        

        private void LoadCbbQuyen()
        {
            cbbQuyen.Items.Add("0 - Chỉ xem");
            cbbQuyen.Items.Add("1 - Thêm");
            cbbQuyen.Items.Add("2 - Sửa");
            cbbQuyen.Items.Add("3 - Xóa");
            cbbQuyen.Items.Add("4 - Tất cả quyền");
            cbbQuyen.Items.Add("5 - Không được truy cập");
        }

        private void LoadDataGridViewNhomQuyen()
        {
            try
            {
                dgvNhomQuyen.DataSource = nhomQuyenBLL.LoadNhomQuyenTheoDieuKien(null, null);
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
                //dgvThongKeNguoiDung.Columns["IDKhoa"].Visible = false; // ẩn cột IDMonHoc
                dgvNhomQuyen.Columns["ID"].Visible = false; // ẩn cột ID               
                int dem = 0;
                for (int i = 0; i < dgvNhomQuyen.Rows.Count; i++)
                {
                    dgvNhomQuyen.Rows[i].Cells["STT"].Value = (i + 1).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetComboboxSelected()
        {
            cbbNhomNguoiSD.SelectedIndex = -1;
            cbbForm.SelectedIndex = -1;
            rtbChuThich.Text = string.Empty;
            rtbQuyenDaThem.Text = string.Empty;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetComboboxSelected();
            ResetComboboxSelected();
        }

        private void cbbQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbbQuyen.SelectedItem.ToString().Substring(0, 1);
            if (!rtbQuyenDaThem.Text.Contains(selectedValue))
            {
                if (selectedValue == "0" || selectedValue == "4")
                {
                    rtbQuyenDaThem.Text = selectedValue;
                }
                else
                {
                    // Nếu chọn các quyền khác, xóa đi 0 và 4 nếu có
                    rtbQuyenDaThem.Text = rtbQuyenDaThem.Text.Replace("0", "").Replace("4", "");

                    // Thêm giá trị mới vào rtbQuyenDaThem
                    if (rtbQuyenDaThem.Text.Length > 0)
                    {
                        rtbQuyenDaThem.AppendText(";");
                    }
                    rtbQuyenDaThem.AppendText(selectedValue);
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            rtbQuyenDaThem.Text = string.Empty;
        }

        private void cbbNhomNguoiSD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbNhomNguoiSD.SelectedIndex != -1)
                {
                    maNhomNguoiSuDung = cbbNhomNguoiSD.SelectedValue.ToString();
                }
                else
                {
                    maNhomNguoiSuDung = "";
                }

                if (cbbForm.SelectedIndex != -1)
                {
                    maForm = cbbForm.SelectedValue.ToString();
                }
                else
                {
                    maForm = "";
                }


                dgvNhomQuyen.DataSource = nhomQuyenBLL.LoadNhomQuyenTheoDieuKien(maNhomNguoiSuDung, maForm);
                EdittingColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbbForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbNhomNguoiSD.SelectedIndex != -1)
                {
                    maNhomNguoiSuDung = cbbNhomNguoiSD.SelectedValue.ToString();
                }
                else
                {
                    maNhomNguoiSuDung = "";
                }

                if (cbbForm.SelectedIndex != -1)
                {
                    maForm = cbbForm.SelectedValue.ToString();
                }
                else
                {
                    maForm = "";
                }


                dgvNhomQuyen.DataSource = nhomQuyenBLL.LoadNhomQuyenTheoDieuKien(maNhomNguoiSuDung, maForm);
                EdittingColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetButtonStatus("Add");
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
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbNhomNguoiSD.SelectedIndex == -1 || cbbForm.SelectedIndex == -1 || string.IsNullOrWhiteSpace(rtbQuyenDaThem.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (cbbNhomNguoiSD.SelectedIndex != -1)
                    {
                        maNhomNguoiSuDung = cbbNhomNguoiSD.SelectedValue.ToString();
                    }
                    else
                    {
                        maNhomNguoiSuDung = "";
                    }

                    if (cbbForm.SelectedIndex != -1)
                    {
                        maForm = cbbForm.SelectedValue.ToString();
                    }
                    else
                    {
                        maForm = "";
                    }
                    quyen = rtbQuyenDaThem.Text;
                    chuthich = rtbChuThich.Text;


                    eThaoTac = EnumDto.eThaoTac.them;
                    if (idNhomQuyen > 0)
                    {
                        eThaoTac = EnumDto.eThaoTac.sua;
                    }
                    idNhomQuyen = nhomQuyenBLL.ThaoTacNhomQuyen_Store(idNhomQuyen, maNhomNguoiSuDung, maForm, quyen, chuthich, eThaoTac);
                    LoadDataGridViewNhomQuyen();
                    SetButtonStatus("Save");
                    MessageBox.Show("Lưu thành công");
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
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            ResetComboboxSelected();
            ResetComboboxSelected();
        }

        private void btnXuatDS_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportDataGridViewToExcel(dgvNhomQuyen);
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            frm_TrangChu frmTrangChu = (frm_TrangChu)System.Windows.Forms.Application.OpenForms["FrmTrangChu"];

            FrmThongKeNguoiDung frmThongKeNguoiDung = new FrmThongKeNguoiDung();
            AddFormcontrol(frmThongKeNguoiDung);
        }

        private void dgvNhomQuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isInAddMode && e.RowIndex >= 0) // kiểm tra xem người dùng đã chọn hàng (row) chưa
            {
                DataGridViewRow row = dgvNhomQuyen.Rows[e.RowIndex];

                idNhomQuyen = Convert.ToInt32(dgvNhomQuyen.CurrentRow.Cells["ID"].Value);
                // Hiển thị thông tin của hàng được chọn ra các control
                cbbNhomNguoiSD.Text = row.Cells["TenNhom1"].Value.ToString();
                cbbForm.Text = dgvNhomQuyen.CurrentRow.Cells["TenForm1"].Value.ToString();
                rtbQuyenDaThem.Text = dgvNhomQuyen.CurrentRow.Cells["Quyen1"].Value.ToString();
                rtbChuThich.Text = dgvNhomQuyen.CurrentRow.Cells["ChuThich1"].Value.ToString();
            }
        }

        private void SetButtonStatus(string action)
        {
            switch (action)
            {
                case "Add":
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

        private void btnXemDS_Click(object sender, EventArgs e)
        {
            frm_TrangChu frmTrangChu = (frm_TrangChu)System.Windows.Forms.Application.OpenForms["FrmTrangChu"];

            FrmThongKeNguoiDung frmThongKeNguoiDung = new FrmThongKeNguoiDung();
            AddFormcontrol(frmThongKeNguoiDung);
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

        private void LoadThongTinNguoiDung(string userName)
        {
            System.Data.DataTable dtNguoiDung = nguoiDungBLL.LoadNguoiDungTheoDieuKien_Store(0,null,userName,null,null,null,null);
            labelKhoa.Text = dtNguoiDung.Rows[0]["TenKhoa"].ToString();
            labelHoten.Text = dtNguoiDung.Rows[0]["HoTen"].ToString();
            labelUserName.Text = dtNguoiDung.Rows[0]["UserName"].ToString();
            cbbNhomNguoiSD.Text = dtNguoiDung.Rows[0]["TenNhom"].ToString();

        }
    }
}
