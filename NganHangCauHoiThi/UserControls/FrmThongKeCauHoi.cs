using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DevComponents.DotNetBar.Controls;
using DTO;
using Guna.UI2.Designer;
using Guna.UI2.WinForms;

namespace NganHangCauHoiThi.UserControls
{
    public partial class FrmThongKeCauHoi : Form
    {
        CauHoiBLL cHoiBll = new CauHoiBLL();
        MonHocBLL monHocBLL = new MonHocBLL();
        KhoaBLL khoaBLL = new KhoaBLL();
        NhomCauHoiBLL nhomCauHoiBLL = new NhomCauHoiBLL();
        System.Data.DataTable dtListCauHoi = new System.Data.DataTable();
        private int IDCauHoiCellClick = 0;
        public int idKhoa = 0, soTinChi = 0;
        public string maMon = "", tenMon = "", maHocPhan = "";
        public long idMonHoc = 0;

        private frm_TrangChu frmTrangChu;
        public FrmThongKeCauHoi()
        {
            InitializeComponent();
        }

        private void FrmThongKeCauHoi_Load(object sender, EventArgs e)
        {
            cbbKhoa.DisplayMember = "TenKhoa";
            cbbKhoa.ValueMember = "ID";
            cbbKhoa.DataSource = khoaBLL.LoadKhoa();

            //Reset lua chon combobox
            ResetComboboxSelected();

            //Load all cau hoi ra datagridview
            LoadDataGridViewCauHoi();
            
            // Thiết lập định dạng ngày tháng cho DateTimePicker thành "dd/MM/yy"
            /*ChangeDateTimePickerFormat(guna2DateTimePicker1);
            ChangeDateTimePickerFormat(guna2DateTimePicker2);*/

        }

        private void ChangeDateTimePickerFormat(Guna2DateTimePicker dateTimePicker)
        {
            // Thiết lập định dạng ngày tháng cho DateTimePicker thành "dd/MM/yy"
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dd/MM/yyyy";
        }


        private void ResetComboboxSelected()
        {
            cbbKhoa.SelectedIndex = -1;
            cbbNhomCauHoi.SelectedIndex = -1;
            cbbTenMon.SelectedIndex = -1;
            txtMaCauHoi.Clear();
        }
        private void LoadDataGridViewCauHoi()
        {
            try
            {
                DateTime tungay = new DateTime(2000, 1, 1);
                DateTime denngay = DateTime.Now;
                dgvThongKeCauHoi.DataSource = cHoiBll.LoadCauHoiTheoDieuKien(0, 0, null, null, tungay, denngay);
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
                dgvThongKeCauHoi.Columns["IDMonHoc"].Visible = false; // ẩn cột IDMonHoc
                dgvThongKeCauHoi.Columns["ID"].Visible = false; // ẩn cột ID
                dgvThongKeCauHoi.Columns["FilePath"].Visible = false; // ẩn cột FilePath
                int dem = 0;
                for (int i = 0; i < dgvThongKeCauHoi.Rows.Count; i++)
                {
                    dgvThongKeCauHoi.Rows[i].Cells["STT"].Value = (i + 1).ToString();
                    dem++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbbTenMon.DisplayMember = "TenMon";
                cbbTenMon.ValueMember = "ID";
                // Lấy IDKhoa từ combobox 
                object value = cbbKhoa.SelectedValue;
                int IDKhoa = Convert.ToInt32(value);
                DateTime tungay = new DateTime(2000, 1, 1);
                DateTime denngay = DateTime.Now;

                cbbTenMon.DataSource = cHoiBll.LoadMonHocTheoDieuKien(IDKhoa, maMon, tenMon, maHocPhan, soTinChi, tungay, denngay);

                cbbTenMon.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    cbbNhomCauHoi.SelectedIndex = -1;
                    //Load Cau Hoi Theo Mon Hoc

                    //LoadCauHoiTheoMonHoc(IDMon);
                }
                else
                {
                    cbbNhomCauHoi.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cbbNhomCauHoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idMon = Convert.ToInt32(cbbTenMon.SelectedValue);
                if (idMon != 0)
                {
                    string nhomCauHoi = cbbNhomCauHoi.Text.ToString();
                    //LoadCauHoiTheoNhomCauHoi(idMon, nhomCauHoi);
                }
                else
                {
                    cbbNhomCauHoi.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadcauHoiTheoKhoa(int idKhoa)
        {
            try
            {
                dgvThongKeCauHoi.DataSource = cHoiBll.LoadCauHoiTheoKhoa(idKhoa);
                EdittingColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadCauHoiTheoMonHoc(int idMonHoc)
        {
            try
            {
                dgvThongKeCauHoi.DataSource = cHoiBll.LoadCauHoiTheoMonHoc(idMonHoc);
                EdittingColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void LoadCauHoiTheoNhomCauHoi(int idMon, string nhomCauHoi)
        {
            try
            {
                dgvThongKeCauHoi.DataSource = cHoiBll.LoadCauHoiTheoNhomCauHoi(idMon, nhomCauHoi);
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
                // Lấy giá trị các combobox và textbox
                int idKhoa = Convert.ToInt32(cbbKhoa.SelectedValue);
                int idMon = Convert.ToInt32(cbbTenMon.SelectedValue);
                string nhomCauHoi = cbbNhomCauHoi.Text.Trim();
                string maCauHoi = txtMaCauHoi.Text.Trim();

                DateTime tungay = new DateTime(2000, 1, 1);
                DateTime denngay = DateTime.Now;

                if (nhomCauHoi == "")
                {
                    nhomCauHoi = null;
                }

                if (maCauHoi == "")
                {
                    maCauHoi = null;
                }

                dgvThongKeCauHoi.DataSource = cHoiBll.LoadCauHoiTheoDieuKien(idKhoa, idMon, nhomCauHoi, maCauHoi, tungay, denngay);
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

        private void btnXuatDS_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportDataGridViewToExcel(dgvThongKeCauHoi);
        }

        private void dgvThongKeCauHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvThongKeCauHoi.Columns["colBtnXem"].Index && e.RowIndex >= 0)
                {
                    IDCauHoiCellClick = Convert.ToInt32(dgvThongKeCauHoi.CurrentRow.Cells["ID"].Value);

                    UC_ThemCauHoi ucThemCauHoi = new UC_ThemCauHoi();
                    ucThemCauHoi.idCauHoi = IDCauHoiCellClick;

                    frm_TrangChu frmTrangChu = (frm_TrangChu)Application.OpenForms["FrmTrangChu"];

                    //Thêm UC_ThemCauHoi vào panelDesktop của FrmTrangChu
                    //frmTrangChu.AddUsercontrol(ucThemCauHoi);
                    AddUsercontrol(ucThemCauHoi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemCauHoi_Click(object sender, EventArgs e)
        {
            frm_TrangChu frmTrangChu = (frm_TrangChu)System.Windows.Forms.Application.OpenForms["FrmTrangChu"];

            UC_ThemCauHoi ucThemCauHoi = new UC_ThemCauHoi();
            AddUsercontrol(ucThemCauHoi);
        }


        /*private void AddUsercontrol(UserControl userControl)
        {
            frm_TrangChu frm_TrangChu = new frm_TrangChu();
            userControl.Dock = DockStyle.Fill;
            frm_TrangChu.panelDesktop.Controls.Clear();
            frm_TrangChu.panelDesktop.Controls.Add(userControl);
            userControl.BringToFront();
        }*/

        private void dgvThongKeCauHoi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void AddUsercontrol(UserControl userControl)
        {
            if (Application.OpenForms.OfType<frm_TrangChu>().FirstOrDefault() is frm_TrangChu frm)
            {
                userControl.Dock = DockStyle.Fill;
                frm.panelDesktop.Controls.Clear();
                frm.panelDesktop.Controls.Add(userControl);
                userControl.BringToFront();
            }
        }


    }
}
