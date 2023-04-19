using BLL;
using DTO;
using Guna.UI.WinForms;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.ApplicationServices;
using NganHangCauHoiThi.UserControls;
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

namespace NganHangCauHoiThi
{
    public partial class frm_TrangChu : Form
    {
        NhomQuyenBLL nhomQuyenBLL = new NhomQuyenBLL();
        public frm_TrangChu()
        {
            InitializeComponent();
            customizeDesing();
        }

        private void customizeDesing()
        {
            panelKhoaSubMenu.Visible= false;
            panelMonHocSubMenu.Visible= false;
            panelDeThiSubMenu.Visible= false;
            panelCauHoiSubMenu.Visible= false;
            panelNguoiDungSubMenu.Visible= false;
        }
        private void hideSubMenu()
        {
            if (panelKhoaSubMenu.Visible == true)
            {
                panelKhoaSubMenu.Visible = false;
            }
            if (panelMonHocSubMenu.Visible == true)
            {
                panelMonHocSubMenu.Visible = false;
            }
            if (panelDeThiSubMenu.Visible == true)
            {
                panelDeThiSubMenu.Visible = false;
            }
            if (panelCauHoiSubMenu.Visible == true)
            {
                panelCauHoiSubMenu.Visible = false;
            }
            if (panelNguoiDungSubMenu.Visible == true)
            {
                panelNguoiDungSubMenu.Visible = false;
            }
        }
        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void AddUsercontrol(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(userControl);
            userControl.BringToFront();
        }

        public void OpenForm(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void frm_TrangChu_Load(object sender, EventArgs e)
        {           
            try
            {
                UC_Home s = new UC_Home();
                AddUsercontrol(s);
                //Label
                label1.Text = "Examination \r\nQuestion Bank";
                //DateTime
                timer1.Start();
                labelTime.Text = DateTime.Now.ToLongTimeString();
                labelDate.Text = DateTime.Now.ToShortDateString();
                labelForm.Visible = false;
                //Phan quyen nguoi dung                 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private bool CheckQuyen(string maNhomNguoiSuDung, string maForm)
        {
            int quyen = 5;
            DataTable dtQuyen = nhomQuyenBLL.LoadNhomQuyenTheoDieuKien(maNhomNguoiSuDung, maForm);

            if (dtQuyen != null && dtQuyen.Rows.Count > 0)
            {
                string quyenString = dtQuyen.Rows[0]["Quyen"].ToString();
                if (quyenString.Contains(quyen.ToString()))
                {
                    return true;
                }
            }
            return false;
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ptbLogoUneti.Visible = true;
            labelTenTruong.Visible = true;
            UC_Home s = new UC_Home();
            AddUsercontrol(s);
            labelForm.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            labelTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMonHocSubMenu);
        }
    
        private void btnCauHoi_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCauHoiSubMenu);
        }

        private void btnDeThi_Click(object sender, EventArgs e)
        {
            showSubMenu(panelDeThiSubMenu);
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            showSubMenu(panelKhoaSubMenu);
        }

        private void btnNguoiDung_Click(object sender, EventArgs e)
        {           
            showSubMenu(panelNguoiDungSubMenu);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            const string message = "Bạn có muốn thoát không?";
            const string caption = "Thoát";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnQLMonHoc_Click(object sender, EventArgs e)
        {
            if (!CheckQuyen(NguoiDung.MaNhomNguoiSuDung, "FrmThongKeMonHoc"))
            {
                XuLyLabelForm(btnQLMonHoc.Text);

                FrmThongKeMonHoc frm = new FrmThongKeMonHoc();
                AddFormcontrol(frm);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào trang này.");
            }

        }

        private void btnThemCauHoi_Click(object sender, EventArgs e)
        {
            if (!CheckQuyen(NguoiDung.MaNhomNguoiSuDung, "UC_ThemCauHoi"))
            {
                XuLyLabelForm(btnThemCauHoi.Text);

                UC_ThemCauHoi s = new UC_ThemCauHoi();
                AddUsercontrol(s);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào trang này.");
            }
        }

        private void btnTaoDeThi_Click(object sender, EventArgs e)
        {
            if (!CheckQuyen(NguoiDung.MaNhomNguoiSuDung, "UC_TaoDeThi"))
            {
                XuLyLabelForm(btnTaoDeThi.Text);

                UC_TaoDeThi s = new UC_TaoDeThi();
                AddUsercontrol(s);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào trang này.");
            }           
        }

        private void btnChiaNhomCau_Click(object sender, EventArgs e)
        {
            if (!CheckQuyen(NguoiDung.MaNhomNguoiSuDung, "FrmNhomCauHoi"))
            {
                XuLyLabelForm(btnChiaNhomCau.Text);
                FrmNhomCauHoi s = new FrmNhomCauHoi();
                AddFormcontrol(s);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào trang này.");
            }
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            if (!CheckQuyen(NguoiDung.MaNhomNguoiSuDung, "UCNganHangDeThi"))
            {
                XuLyLabelForm(guna2Button18.Text);
                UCNganHangDeThi s = new UCNganHangDeThi();
                AddUsercontrol(s);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào trang này.");
            }
           
        }

        private void btnThongKeCauHoi_Click(object sender, EventArgs e)
        {
            if (!CheckQuyen(NguoiDung.MaNhomNguoiSuDung, "FrmThongKeCauHoi"))
            {
                XuLyLabelForm(btnThongKeCauHoi.Text);
                FrmThongKeCauHoi frm = new FrmThongKeCauHoi();
                AddFormcontrol(frm);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào trang này.");
            }
            
        }

        #region NEW
        public void AddFormcontrol(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(form);
            panelDesktop.Tag = form;
            form.BringToFront();
            
            form.Show();
        }


        #endregion

        private void btnDSNguoiDung_Click(object sender, EventArgs e)
        {
            if (!CheckQuyen(NguoiDung.MaNhomNguoiSuDung, "FrmThongKeNguoiDung"))
            {
                XuLyLabelForm(btnDSNguoiDung.Text);
                FrmThongKeNguoiDung frm = new FrmThongKeNguoiDung();
                AddFormcontrol(frm);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào trang này.");
            }

        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            if (!CheckQuyen(NguoiDung.MaNhomNguoiSuDung, "FrmPhanQuyenNguoiDung"))
            {
                XuLyLabelForm(guna2Button16.Text);
                FrmPhanQuyenNguoiDung frm = new FrmPhanQuyenNguoiDung();
                AddFormcontrol(frm);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào trang này.");
            }
        }

        private void btnQLyKhoa_Click(object sender, EventArgs e)
        {
            if (!CheckQuyen(NguoiDung.MaNhomNguoiSuDung, "FrmQuanLyKhoa"))
            {
                XuLyLabelForm(btnQLyKhoa.Text);
                FrmQuanLyKhoa frm = new FrmQuanLyKhoa();
                AddFormcontrol(frm);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào trang này.");
            }

        }

        private void XuLyLabelForm(string tenForm)
        {
            ptbLogoUneti.Visible= false;
            labelTenTruong.Visible= false;
            labelForm.Visible= true;
            labelForm.Text= tenForm;
        }

        private void btnPaDeThi_Click(object sender, EventArgs e)
        {
            if (!CheckQuyen(NguoiDung.MaNhomNguoiSuDung, "UcPhuongAnDeThi"))
            {
                XuLyLabelForm(btnPaDeThi.Text);
                UcPhuongAnDeThi s = new UcPhuongAnDeThi();
                AddUsercontrol(s);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào trang này.");
            }
        }

        private void btnUserInfor_Click(object sender, EventArgs e)
        {
            if (!CheckQuyen(NguoiDung.MaNhomNguoiSuDung, "FrmThongTinCaNhan"))
            {
                XuLyLabelForm(btnUserInfor.Text);
                FrmThongTinCaNhan frm = new FrmThongTinCaNhan();
                AddFormcontrol(frm);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào trang này.");
            }
        }

        private void btnPaDeThi_Click_1(object sender, EventArgs e)
        {
            UcPhuongAnDeThi s = new UcPhuongAnDeThi();
            //PluginBus.OpenForm(s);
            AddUsercontrol(s);
        }
    }
}
