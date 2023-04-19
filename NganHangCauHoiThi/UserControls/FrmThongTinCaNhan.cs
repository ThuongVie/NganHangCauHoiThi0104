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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NganHangCauHoiThi.UserControls
{
    public partial class FrmThongTinCaNhan : Form
    {
        NguoiDungBLL nguoiDungBLL = new NguoiDungBLL();
        KhoaBLL khoaBll = new KhoaBLL();
        private int idKhoa = 0;
        EnumDto.eThaoTac eThaoTac;
        string hoTen = "", userName = "", email = "", diachi = "", sdt = "";
        public long idNguoiDung = 0;
        private bool isLabelMode, isReadOnlyMode;
       

        public FrmThongTinCaNhan()
        {
            InitializeComponent();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            panelDoiMK.Visible = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            panelDoiMK.Visible = false;
        }

        private void btnLuuMK_Click(object sender, EventArgs e)
        {
            try
            {
                ChangePassword();
                idNguoiDung = nguoiDungBLL.DoiMatKhau_Store(NguoiDung.ID, NguoiDung.UserName, txtConfirmPass.Text);
                MessageBox.Show("Lưu thành công");
                txtOldPass.Text = string.Empty;
                txtNewPass.Text = string.Empty;
                txtConfirmPass.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangePassword()
        {
            if (string.IsNullOrWhiteSpace(txtOldPass.Text) || string.IsNullOrWhiteSpace(txtNewPass.Text) || string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtOldPass.Text == txtNewPass.Text)
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu cũ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp với mật khẩu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void FrmThongTinCaNhan_Load(object sender, EventArgs e)
        {            
            LoadThongTinCaNhan();
        }
        private void LoadThongTinCaNhan()
        {
            try
            {
                DataTable dtNguoiDung = nguoiDungBLL.LoadNguoiDungTheoDieuKien_Store(0, null, NguoiDung.UserName, null, null, null, null);

                txtHoTen.Text = dtNguoiDung.Rows[0]["HoTen"].ToString();
                txtDiaChi.Text = dtNguoiDung.Rows[0]["DiaChi"].ToString();
                txtSdt.Text = dtNguoiDung.Rows[0]["SoDienThoai"].ToString();
                txtEmail.Text = dtNguoiDung.Rows[0]["Email"].ToString();

                labelUserName.Text = "UserName : " + NguoiDung.UserName;
                labelChucVu.Text = "Chức vụ : " + NguoiDung.ChucVu;

                idKhoa = NguoiDung.IDKhoa;
                DataTable dtKhoa = khoaBll.LoadKhoaTheo(null, idKhoa);
                labelKhoa.Text = "Khoa : " + dtKhoa.Rows[0]["TenKhoa"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            isLabelMode = true;
            isReadOnlyMode = false;
            btnSua.Visible = false;
            btnLuu.Visible = true;
            LoadBtnSuaClick();              
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                hoTen = txtHoTen.Text;
                email = txtEmail.Text;
                sdt = txtSdt.Text;
                diachi = txtDiaChi.Text;
                if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(sdt) || string.IsNullOrWhiteSpace(diachi))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                else if (!Validator.IsValidPhoneNumber(sdt))
                {
                    MessageBox.Show("Vui lòng nhập đúng số điện thoại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!Validator.IsValidEmail(email))
                {
                    MessageBox.Show("Vui lòng nhập đúng email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    eThaoTac = EnumDto.eThaoTac.sua;
                    idNguoiDung = nguoiDungBLL.ThaoTacNguoiDung_Store(NguoiDung.ID, idKhoa, NguoiDung.UserName, hoTen, email, sdt, diachi, NguoiDung.MaNhomNguoiSuDung, " ", " ", eThaoTac);
                    MessageBox.Show("Lưu thành công");
                    btnSua.Visible = true;
                    btnLuu.Visible = false;
                    isLabelMode = false;
                    isReadOnlyMode = true;
                    LoadBtnSuaClick();
                    LoadThongTinCaNhan();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadBtnSuaClick()
        {
            label14.Visible = isLabelMode;
            label7.Visible = isLabelMode;
            label8.Visible = isLabelMode;
            label9.Visible = isLabelMode;

            txtHoTen.ReadOnly = isReadOnlyMode;
            txtSdt.ReadOnly = isReadOnlyMode;
            txtDiaChi.ReadOnly = isReadOnlyMode;
            txtEmail.ReadOnly = isReadOnlyMode;          
        }
    }
}
