namespace NganHangCauHoiThi.UserControls
{
    partial class FrmQuanLyKhoa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnHuy = new Guna.UI2.WinForms.Guna2Button();
            this.btnSua = new Guna.UI2.WinForms.Guna2Button();
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.btnNhapMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoa = new Guna.UI2.WinForms.Guna2Button();
            this.btnTroVe = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label91 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.rtbChuThich = new System.Windows.Forms.RichTextBox();
            this.txtTenKhoa = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaKhoa = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelTenMon = new System.Windows.Forms.Label();
            this.btnXuatDS = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnXem = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvThongKeKhoa = new Guna.UI2.WinForms.Guna2DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhoa1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKhoa1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChuThich1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel2.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeKhoa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên khoa";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.Controls.Add(this.btnHuy);
            this.guna2Panel2.Controls.Add(this.btnSua);
            this.guna2Panel2.Controls.Add(this.btnThem);
            this.guna2Panel2.Controls.Add(this.btnNhapMoi);
            this.guna2Panel2.Controls.Add(this.btnXoa);
            this.guna2Panel2.Controls.Add(this.btnTroVe);
            this.guna2Panel2.Controls.Add(this.btnLuu);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 651);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1288, 43);
            this.guna2Panel2.TabIndex = 9;
            // 
            // btnHuy
            // 
            this.btnHuy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHuy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHuy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(458, 6);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(96, 31);
            this.btnHuy.TabIndex = 33;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnSua
            // 
            this.btnSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(124, 6);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(96, 31);
            this.btnSua.TabIndex = 32;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(12, 6);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(96, 31);
            this.btnThem.TabIndex = 31;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnNhapMoi
            // 
            this.btnNhapMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNhapMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNhapMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNhapMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNhapMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNhapMoi.ForeColor = System.Drawing.Color.White;
            this.btnNhapMoi.Location = new System.Drawing.Point(573, 6);
            this.btnNhapMoi.Name = "btnNhapMoi";
            this.btnNhapMoi.Size = new System.Drawing.Size(96, 31);
            this.btnNhapMoi.TabIndex = 30;
            this.btnNhapMoi.Text = "Nhập mới";
            this.btnNhapMoi.Click += new System.EventHandler(this.btnNhapMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(236, 6);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(96, 31);
            this.btnXoa.TabIndex = 29;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnTroVe
            // 
            this.btnTroVe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTroVe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTroVe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTroVe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTroVe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTroVe.ForeColor = System.Drawing.Color.White;
            this.btnTroVe.Location = new System.Drawing.Point(684, 6);
            this.btnTroVe.Name = "btnTroVe";
            this.btnTroVe.Size = new System.Drawing.Size(96, 31);
            this.btnTroVe.TabIndex = 28;
            this.btnTroVe.Text = "Trở về";
            // 
            // btnLuu
            // 
            this.btnLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(347, 6);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(96, 31);
            this.btnLuu.TabIndex = 27;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.label91);
            this.guna2GroupBox1.Controls.Add(this.label90);
            this.guna2GroupBox1.Controls.Add(this.rtbChuThich);
            this.guna2GroupBox1.Controls.Add(this.txtTenKhoa);
            this.guna2GroupBox1.Controls.Add(this.txtMaKhoa);
            this.guna2GroupBox1.Controls.Add(this.labelTenMon);
            this.guna2GroupBox1.Controls.Add(this.btnXuatDS);
            this.guna2GroupBox1.Controls.Add(this.btnLamMoi);
            this.guna2GroupBox1.Controls.Add(this.btnXem);
            this.guna2GroupBox1.Controls.Add(this.label4);
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1288, 164);
            this.guna2GroupBox1.TabIndex = 0;
            this.guna2GroupBox1.Text = "Nhập điều kiện tìm kiếm";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.BackColor = System.Drawing.Color.White;
            this.label91.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label91.ForeColor = System.Drawing.Color.Red;
            this.label91.Location = new System.Drawing.Point(82, 96);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(27, 20);
            this.label91.TabIndex = 63;
            this.label91.Text = "(*)";
            this.label91.Visible = false;
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.BackColor = System.Drawing.Color.White;
            this.label90.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.ForeColor = System.Drawing.Color.Red;
            this.label90.Location = new System.Drawing.Point(81, 53);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(27, 20);
            this.label90.TabIndex = 62;
            this.label90.Text = "(*)";
            this.label90.Visible = false;
            // 
            // rtbChuThich
            // 
            this.rtbChuThich.Location = new System.Drawing.Point(536, 43);
            this.rtbChuThich.Name = "rtbChuThich";
            this.rtbChuThich.Size = new System.Drawing.Size(268, 81);
            this.rtbChuThich.TabIndex = 19;
            this.rtbChuThich.Text = "";
            // 
            // txtTenKhoa
            // 
            this.txtTenKhoa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenKhoa.DefaultText = "";
            this.txtTenKhoa.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTenKhoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTenKhoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenKhoa.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTenKhoa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKhoa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTenKhoa.Location = new System.Drawing.Point(114, 44);
            this.txtTenKhoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenKhoa.Name = "txtTenKhoa";
            this.txtTenKhoa.PasswordChar = '\0';
            this.txtTenKhoa.PlaceholderText = "";
            this.txtTenKhoa.SelectedText = "";
            this.txtTenKhoa.Size = new System.Drawing.Size(227, 36);
            this.txtTenKhoa.TabIndex = 18;
            // 
            // txtMaKhoa
            // 
            this.txtMaKhoa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaKhoa.DefaultText = "";
            this.txtMaKhoa.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaKhoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaKhoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaKhoa.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaKhoa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKhoa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaKhoa.Location = new System.Drawing.Point(114, 88);
            this.txtMaKhoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaKhoa.Name = "txtMaKhoa";
            this.txtMaKhoa.PasswordChar = '\0';
            this.txtMaKhoa.PlaceholderText = "";
            this.txtMaKhoa.SelectedText = "";
            this.txtMaKhoa.Size = new System.Drawing.Size(227, 36);
            this.txtMaKhoa.TabIndex = 17;
            // 
            // labelTenMon
            // 
            this.labelTenMon.AutoSize = true;
            this.labelTenMon.BackColor = System.Drawing.Color.White;
            this.labelTenMon.Location = new System.Drawing.Point(18, 96);
            this.labelTenMon.Name = "labelTenMon";
            this.labelTenMon.Size = new System.Drawing.Size(66, 20);
            this.labelTenMon.TabIndex = 16;
            this.labelTenMon.Text = "Mã khoa";
            // 
            // btnXuatDS
            // 
            this.btnXuatDS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatDS.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXuatDS.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXuatDS.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXuatDS.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXuatDS.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXuatDS.ForeColor = System.Drawing.Color.White;
            this.btnXuatDS.Location = new System.Drawing.Point(1184, 125);
            this.btnXuatDS.Name = "btnXuatDS";
            this.btnXuatDS.Size = new System.Drawing.Size(92, 33);
            this.btnXuatDS.TabIndex = 13;
            this.btnXuatDS.Text = "Xuất DS";
            this.btnXuatDS.Click += new System.EventHandler(this.btnXuatDS_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLamMoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLamMoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(1074, 125);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(92, 33);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Visible = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXem
            // 
            this.btnXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(979, 125);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(77, 33);
            this.btnXem.TabIndex = 1;
            this.btnXem.Text = "Tìm";
            this.btnXem.Visible = false;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(436, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Chú thích";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2GroupBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1288, 164);
            this.guna2Panel1.TabIndex = 8;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.dgvThongKeKhoa);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 164);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(1288, 487);
            this.guna2Panel3.TabIndex = 10;
            // 
            // dgvThongKeKhoa
            // 
            this.dgvThongKeKhoa.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvThongKeKhoa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThongKeKhoa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThongKeKhoa.ColumnHeadersHeight = 33;
            this.dgvThongKeKhoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThongKeKhoa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.ID,
            this.TenKhoa1,
            this.MaKhoa1,
            this.ChuThich1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThongKeKhoa.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvThongKeKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongKeKhoa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThongKeKhoa.Location = new System.Drawing.Point(0, 0);
            this.dgvThongKeKhoa.Name = "dgvThongKeKhoa";
            this.dgvThongKeKhoa.ReadOnly = true;
            this.dgvThongKeKhoa.RowHeadersVisible = false;
            this.dgvThongKeKhoa.RowHeadersWidth = 51;
            this.dgvThongKeKhoa.RowTemplate.Height = 24;
            this.dgvThongKeKhoa.Size = new System.Drawing.Size(1288, 487);
            this.dgvThongKeKhoa.TabIndex = 2;
            this.dgvThongKeKhoa.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongKeKhoa.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvThongKeKhoa.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvThongKeKhoa.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvThongKeKhoa.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvThongKeKhoa.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongKeKhoa.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThongKeKhoa.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvThongKeKhoa.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvThongKeKhoa.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dgvThongKeKhoa.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvThongKeKhoa.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThongKeKhoa.ThemeStyle.HeaderStyle.Height = 33;
            this.dgvThongKeKhoa.ThemeStyle.ReadOnly = true;
            this.dgvThongKeKhoa.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongKeKhoa.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThongKeKhoa.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dgvThongKeKhoa.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvThongKeKhoa.ThemeStyle.RowsStyle.Height = 24;
            this.dgvThongKeKhoa.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThongKeKhoa.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvThongKeKhoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThongKeKhoa_CellClick);
            // 
            // STT
            // 
            this.STT.FillWeight = 15.398F;
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Visible = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 53.47593F;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // TenKhoa1
            // 
            this.TenKhoa1.DataPropertyName = "TenKhoa";
            this.TenKhoa1.FillWeight = 80.72702F;
            this.TenKhoa1.HeaderText = "Khoa";
            this.TenKhoa1.MinimumWidth = 6;
            this.TenKhoa1.Name = "TenKhoa1";
            this.TenKhoa1.ReadOnly = true;
            // 
            // MaKhoa1
            // 
            this.MaKhoa1.DataPropertyName = "MaKhoa";
            this.MaKhoa1.FillWeight = 62.444F;
            this.MaKhoa1.HeaderText = "Mã môn";
            this.MaKhoa1.MinimumWidth = 6;
            this.MaKhoa1.Name = "MaKhoa1";
            this.MaKhoa1.ReadOnly = true;
            // 
            // ChuThich1
            // 
            this.ChuThich1.DataPropertyName = "ChuThich";
            this.ChuThich1.FillWeight = 233.3902F;
            this.ChuThich1.HeaderText = "Chú thích";
            this.ChuThich1.MinimumWidth = 6;
            this.ChuThich1.Name = "ChuThich1";
            this.ChuThich1.ReadOnly = true;
            // 
            // FrmQuanLyKhoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 694);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "FrmQuanLyKhoa";
            this.Text = "FrmQuanLyKhoa";
            this.Load += new System.EventHandler(this.FrmQuanLyKhoa_Load);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeKhoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Guna.UI2.WinForms.Guna2Button btnSua;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna.UI2.WinForms.Guna2Button btnNhapMoi;
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnTroVe;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtMaKhoa;
        private System.Windows.Forms.Label labelTenMon;
        private Guna.UI2.WinForms.Guna2Button btnXuatDS;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2Button btnXem;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox txtTenKhoa;
        private System.Windows.Forms.RichTextBox rtbChuThich;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2DataGridView dgvThongKeKhoa;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhoa1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhoa1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChuThich1;
    }
}