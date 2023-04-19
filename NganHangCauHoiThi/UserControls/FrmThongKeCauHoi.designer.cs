namespace NganHangCauHoiThi.UserControls
{
    partial class FrmThongKeCauHoi
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnXuatDS = new Guna.UI2.WinForms.Guna2Button();
            this.btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            this.btnXem = new Guna.UI2.WinForms.Guna2Button();
            this.txtMaCauHoi = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbNhomCauHoi = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbTenMon = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbbKhoa = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnThemCauHoi = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvThongKeCauHoi = new Guna.UI2.WinForms.Guna2DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCauHoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMon1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhomCauHoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBtnXem = new System.Windows.Forms.DataGridViewButtonColumn();
            this.guna2Panel1.SuspendLayout();
            this.guna2GroupBox1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeCauHoi)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2GroupBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1288, 164);
            this.guna2Panel1.TabIndex = 0;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.btnXuatDS);
            this.guna2GroupBox1.Controls.Add(this.btnLamMoi);
            this.guna2GroupBox1.Controls.Add(this.btnXem);
            this.guna2GroupBox1.Controls.Add(this.txtMaCauHoi);
            this.guna2GroupBox1.Controls.Add(this.label4);
            this.guna2GroupBox1.Controls.Add(this.label3);
            this.guna2GroupBox1.Controls.Add(this.cbbNhomCauHoi);
            this.guna2GroupBox1.Controls.Add(this.label2);
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.Controls.Add(this.cbbTenMon);
            this.guna2GroupBox1.Controls.Add(this.cbbKhoa);
            this.guna2GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(1288, 164);
            this.guna2GroupBox1.TabIndex = 0;
            this.guna2GroupBox1.Text = "Nhập điều kiện tìm kiếm";
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
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // txtMaCauHoi
            // 
            this.txtMaCauHoi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaCauHoi.DefaultText = "";
            this.txtMaCauHoi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMaCauHoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMaCauHoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaCauHoi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMaCauHoi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaCauHoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaCauHoi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMaCauHoi.Location = new System.Drawing.Point(576, 86);
            this.txtMaCauHoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaCauHoi.Name = "txtMaCauHoi";
            this.txtMaCauHoi.PasswordChar = '\0';
            this.txtMaCauHoi.PlaceholderText = "";
            this.txtMaCauHoi.SelectedText = "";
            this.txtMaCauHoi.Size = new System.Drawing.Size(227, 36);
            this.txtMaCauHoi.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(433, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mã câu hỏi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(433, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nhóm câu hỏi";
            // 
            // cbbNhomCauHoi
            // 
            this.cbbNhomCauHoi.BackColor = System.Drawing.Color.Transparent;
            this.cbbNhomCauHoi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbNhomCauHoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNhomCauHoi.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbNhomCauHoi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbNhomCauHoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNhomCauHoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbNhomCauHoi.ItemHeight = 30;
            this.cbbNhomCauHoi.Location = new System.Drawing.Point(576, 46);
            this.cbbNhomCauHoi.Name = "cbbNhomCauHoi";
            this.cbbNhomCauHoi.Size = new System.Drawing.Size(227, 36);
            this.cbbNhomCauHoi.TabIndex = 5;
            this.cbbNhomCauHoi.SelectedIndexChanged += new System.EventHandler(this.cbbNhomCauHoi_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên môn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên khoa";
            // 
            // cbbTenMon
            // 
            this.cbbTenMon.BackColor = System.Drawing.Color.Transparent;
            this.cbbTenMon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbTenMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTenMon.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbTenMon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbTenMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTenMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbTenMon.ItemHeight = 30;
            this.cbbTenMon.Location = new System.Drawing.Point(114, 86);
            this.cbbTenMon.Name = "cbbTenMon";
            this.cbbTenMon.Size = new System.Drawing.Size(227, 36);
            this.cbbTenMon.TabIndex = 2;
            this.cbbTenMon.SelectedIndexChanged += new System.EventHandler(this.cbbTenMon_SelectedIndexChanged);
            // 
            // cbbKhoa
            // 
            this.cbbKhoa.BackColor = System.Drawing.Color.Transparent;
            this.cbbKhoa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbKhoa.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbKhoa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbKhoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbKhoa.ItemHeight = 30;
            this.cbbKhoa.Location = new System.Drawing.Point(114, 46);
            this.cbbKhoa.Name = "cbbKhoa";
            this.cbbKhoa.Size = new System.Drawing.Size(227, 36);
            this.cbbKhoa.TabIndex = 0;
            this.cbbKhoa.SelectedIndexChanged += new System.EventHandler(this.cbbKhoa_SelectedIndexChanged);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.Controls.Add(this.btnThemCauHoi);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 643);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1288, 51);
            this.guna2Panel2.TabIndex = 21;
            // 
            // btnThemCauHoi
            // 
            this.btnThemCauHoi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemCauHoi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemCauHoi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemCauHoi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemCauHoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThemCauHoi.ForeColor = System.Drawing.Color.White;
            this.btnThemCauHoi.Location = new System.Drawing.Point(16, 10);
            this.btnThemCauHoi.Name = "btnThemCauHoi";
            this.btnThemCauHoi.Size = new System.Drawing.Size(153, 31);
            this.btnThemCauHoi.TabIndex = 24;
            this.btnThemCauHoi.Text = "Thêm Câu Hỏi";
            this.btnThemCauHoi.Click += new System.EventHandler(this.btnThemCauHoi_Click);
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.Controls.Add(this.dgvThongKeCauHoi);
            this.guna2Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel4.Location = new System.Drawing.Point(0, 164);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.Size = new System.Drawing.Size(1288, 479);
            this.guna2Panel4.TabIndex = 22;
            // 
            // dgvThongKeCauHoi
            // 
            this.dgvThongKeCauHoi.AllowUserToAddRows = false;
            this.dgvThongKeCauHoi.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvThongKeCauHoi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThongKeCauHoi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThongKeCauHoi.ColumnHeadersHeight = 33;
            this.dgvThongKeCauHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThongKeCauHoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.ID,
            this.MaCauHoi,
            this.TenKhoa,
            this.TenMon1,
            this.NhomCauHoi,
            this.NguoiTao,
            this.NgayTao,
            this.colBtnXem});
            this.dgvThongKeCauHoi.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThongKeCauHoi.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvThongKeCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThongKeCauHoi.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvThongKeCauHoi.Location = new System.Drawing.Point(0, 0);
            this.dgvThongKeCauHoi.Name = "dgvThongKeCauHoi";
            this.dgvThongKeCauHoi.ReadOnly = true;
            this.dgvThongKeCauHoi.RowHeadersVisible = false;
            this.dgvThongKeCauHoi.RowHeadersWidth = 51;
            this.dgvThongKeCauHoi.RowTemplate.Height = 24;
            this.dgvThongKeCauHoi.Size = new System.Drawing.Size(1288, 479);
            this.dgvThongKeCauHoi.TabIndex = 2;
            this.dgvThongKeCauHoi.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongKeCauHoi.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvThongKeCauHoi.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvThongKeCauHoi.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvThongKeCauHoi.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvThongKeCauHoi.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongKeCauHoi.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvThongKeCauHoi.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dgvThongKeCauHoi.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvThongKeCauHoi.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dgvThongKeCauHoi.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvThongKeCauHoi.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvThongKeCauHoi.ThemeStyle.HeaderStyle.Height = 33;
            this.dgvThongKeCauHoi.ThemeStyle.ReadOnly = true;
            this.dgvThongKeCauHoi.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvThongKeCauHoi.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThongKeCauHoi.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dgvThongKeCauHoi.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvThongKeCauHoi.ThemeStyle.RowsStyle.Height = 24;
            this.dgvThongKeCauHoi.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvThongKeCauHoi.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvThongKeCauHoi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThongKeCauHoi_CellContentClick);
            // 
            // STT
            // 
            this.STT.FillWeight = 20.47735F;
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            this.STT.Visible = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // MaCauHoi
            // 
            this.MaCauHoi.DataPropertyName = "MaCauHoi";
            this.MaCauHoi.FillWeight = 62.62029F;
            this.MaCauHoi.HeaderText = "Mã câu hỏi";
            this.MaCauHoi.MinimumWidth = 6;
            this.MaCauHoi.Name = "MaCauHoi";
            this.MaCauHoi.ReadOnly = true;
            // 
            // TenKhoa
            // 
            this.TenKhoa.DataPropertyName = "TenKhoa";
            this.TenKhoa.FillWeight = 62.62029F;
            this.TenKhoa.HeaderText = "Khoa";
            this.TenKhoa.MinimumWidth = 6;
            this.TenKhoa.Name = "TenKhoa";
            this.TenKhoa.ReadOnly = true;
            // 
            // TenMon1
            // 
            this.TenMon1.DataPropertyName = "TenMon";
            this.TenMon1.HeaderText = "Tên Môn";
            this.TenMon1.MinimumWidth = 6;
            this.TenMon1.Name = "TenMon1";
            this.TenMon1.ReadOnly = true;
            // 
            // NhomCauHoi
            // 
            this.NhomCauHoi.DataPropertyName = "NhomCauHoi";
            this.NhomCauHoi.FillWeight = 62.62029F;
            this.NhomCauHoi.HeaderText = "Nhóm câu hỏi";
            this.NhomCauHoi.MinimumWidth = 6;
            this.NhomCauHoi.Name = "NhomCauHoi";
            this.NhomCauHoi.ReadOnly = true;
            // 
            // NguoiTao
            // 
            this.NguoiTao.DataPropertyName = "HoTen";
            this.NguoiTao.FillWeight = 62.62029F;
            this.NguoiTao.HeaderText = "Người tạo";
            this.NguoiTao.MinimumWidth = 6;
            this.NguoiTao.Name = "NguoiTao";
            this.NguoiTao.ReadOnly = true;
            // 
            // NgayTao
            // 
            this.NgayTao.DataPropertyName = "NgayTao";
            this.NgayTao.FillWeight = 39.94956F;
            this.NgayTao.HeaderText = "Ngày tạo";
            this.NgayTao.MinimumWidth = 6;
            this.NgayTao.Name = "NgayTao";
            this.NgayTao.ReadOnly = true;
            // 
            // colBtnXem
            // 
            this.colBtnXem.FillWeight = 16.694F;
            this.colBtnXem.HeaderText = "Xem";
            this.colBtnXem.MinimumWidth = 6;
            this.colBtnXem.Name = "colBtnXem";
            this.colBtnXem.ReadOnly = true;
            this.colBtnXem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBtnXem.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FrmThongKeCauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 694);
            this.Controls.Add(this.guna2Panel4);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "FrmThongKeCauHoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê câu hỏi";
            this.Load += new System.EventHandler(this.FrmThongKeCauHoi_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2GroupBox1.ResumeLayout(false);
            this.guna2GroupBox1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKeCauHoi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnXem;
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cbbTenMon;
        private Guna.UI2.WinForms.Guna2ComboBox cbbKhoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtMaCauHoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cbbNhomCauHoi;
        private Guna.UI2.WinForms.Guna2Button btnXuatDS;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button btnThemCauHoi;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private Guna.UI2.WinForms.Guna2DataGridView dgvThongKeCauHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCauHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMon1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhomCauHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTao;
        private System.Windows.Forms.DataGridViewButtonColumn colBtnXem;
    }
}