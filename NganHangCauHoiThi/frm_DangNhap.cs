using BLL;
using DevComponents.Schedule.Model;
using DTO;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DTO.NguoiDung;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NganHangCauHoiThi
{
    public partial class frm_DangNhap : Form
    {
        NguoiDungBLL nguoiDungBLL= new NguoiDungBLL();
        NhomQuyenBLL nhomQuyenBLL = new NhomQuyenBLL();
        public int count = 0;
        List<UserPermission> permissions = new List<UserPermission>();

        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text != "" && txtPassword.Text != "")
                {
                    DataTable dt = nguoiDungBLL.LoginUser(txtUserName.Text, txtPassword.Text);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        NguoiDung.ID =  Convert.ToInt32( dt.Rows[0]["ID"]);
                        NguoiDung.IDKhoa =  Convert.ToInt32( dt.Rows[0]["IDKhoa"]);
                        NguoiDung.UserName = dt.Rows[0]["UserName"].ToString();
                        NguoiDung.HoTen = dt.Rows[0]["HoTen"].ToString();
                        NguoiDung.ChucVu = dt.Rows[0]["TenNhom"].ToString();
                        NguoiDung.Email = dt.Rows[0]["Email"].ToString();
                        NguoiDung.SoDienThoai = dt.Rows[0]["SoDienThoai"].ToString();
                        NguoiDung.DiaChi = dt.Rows[0]["DiaChi"].ToString();
                        NguoiDung.MaNhomNguoiSuDung = dt.Rows[0]["MaNhomNguoiSuDung"].ToString();

                        MessageBox.Show("Đăng nhập thành công", "Thông báo");
                        frm_TrangChu frm = new frm_TrangChu();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo");
                        txtUserName.Focus();
                        count = count + 1;
                        if (count >= 3)
                        {
                            btnDangNhap.Enabled = false;
                            MessageBox.Show("Không được nhập quá 3 lần", "Thông báo");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập đủ thông tin", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frm_DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult q = MessageBox.Show("Are you sure you want to exit?", "Exit Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (q.Equals(DialogResult.Yes))
            {
                this.Close();
            }
        }

        private void guna2PictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void guna2PictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void frm_DangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnDangNhap_Click(sender,e);
        }
    }
}
