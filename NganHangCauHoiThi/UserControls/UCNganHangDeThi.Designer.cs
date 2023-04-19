namespace NganHangCauHoiThi.UserControls
{
    partial class UCNganHangDeThi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpTimKiem = new Guna.UI2.WinForms.Guna2GroupBox();
            this.rtbNhomCauHoi = new System.Windows.Forms.RichTextBox();
            this.btnTim = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtDenNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtTuNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cbbNhomCauHoi = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbTenMon = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbbKhoa = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grdData = new Guna.UI2.WinForms.Guna2DataGridView();
            this.MaDe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.DSCau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBtnXem = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.grpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // grpTimKiem
            // 
            this.grpTimKiem.Controls.Add(this.btnReset);
            this.grpTimKiem.Controls.Add(this.rtbNhomCauHoi);
            this.grpTimKiem.Controls.Add(this.btnTim);
            this.grpTimKiem.Controls.Add(this.label2);
            this.grpTimKiem.Controls.Add(this.dtDenNgay);
            this.grpTimKiem.Controls.Add(this.label1);
            this.grpTimKiem.Controls.Add(this.dtTuNgay);
            this.grpTimKiem.Controls.Add(this.cbbNhomCauHoi);
            this.grpTimKiem.Controls.Add(this.label5);
            this.grpTimKiem.Controls.Add(this.cbbTenMon);
            this.grpTimKiem.Controls.Add(this.label10);
            this.grpTimKiem.Controls.Add(this.cbbKhoa);
            this.grpTimKiem.Controls.Add(this.label3);
            this.grpTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.grpTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.grpTimKiem.Location = new System.Drawing.Point(0, 0);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(1306, 135);
            this.grpTimKiem.TabIndex = 0;
            this.grpTimKiem.Text = "Tìm kiếm";
            this.grpTimKiem.Click += new System.EventHandler(this.grpTimKiem_Click);
            // 
            // rtbNhomCauHoi
            // 
            this.rtbNhomCauHoi.Location = new System.Drawing.Point(1194, 43);
            this.rtbNhomCauHoi.Name = "rtbNhomCauHoi";
            this.rtbNhomCauHoi.ReadOnly = true;
            this.rtbNhomCauHoi.Size = new System.Drawing.Size(99, 36);
            this.rtbNhomCauHoi.TabIndex = 43;
            this.rtbNhomCauHoi.Text = "";
            this.rtbNhomCauHoi.Visible = false;
            // 
            // btnTim
            // 
            this.btnTim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTim.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTim.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTim.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTim.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Location = new System.Drawing.Point(988, 93);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(89, 36);
            this.btnTim.TabIndex = 41;
            this.btnTim.Text = "Tìm";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(235, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "Đến ngày";
            // 
            // dtDenNgay
            // 
            this.dtDenNgay.AccessibleDescription = "dtDenNgay";
            this.dtDenNgay.BackColor = System.Drawing.Color.Transparent;
            this.dtDenNgay.Checked = true;
            this.dtDenNgay.FillColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtDenNgay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDenNgay.Location = new System.Drawing.Point(309, 48);
            this.dtDenNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtDenNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDenNgay.Name = "dtDenNgay";
            this.dtDenNgay.Size = new System.Drawing.Size(117, 36);
            this.dtDenNgay.TabIndex = 39;
            this.dtDenNgay.Value = new System.DateTime(2023, 3, 1, 19, 42, 19, 821);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(20, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "Từ ngày";
            // 
            // dtTuNgay
            // 
            this.dtTuNgay.BackColor = System.Drawing.Color.Transparent;
            this.dtTuNgay.Checked = true;
            this.dtTuNgay.FillColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtTuNgay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTuNgay.Location = new System.Drawing.Point(103, 48);
            this.dtTuNgay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtTuNgay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtTuNgay.Name = "dtTuNgay";
            this.dtTuNgay.Size = new System.Drawing.Size(117, 36);
            this.dtTuNgay.TabIndex = 37;
            this.dtTuNgay.Value = new System.DateTime(2023, 3, 1, 19, 42, 19, 821);
            // 
            // cbbNhomCauHoi
            // 
            this.cbbNhomCauHoi.BackColor = System.Drawing.Color.Transparent;
            this.cbbNhomCauHoi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbNhomCauHoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNhomCauHoi.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbNhomCauHoi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbNhomCauHoi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbNhomCauHoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbNhomCauHoi.ItemHeight = 30;
            this.cbbNhomCauHoi.Location = new System.Drawing.Point(971, 43);
            this.cbbNhomCauHoi.Name = "cbbNhomCauHoi";
            this.cbbNhomCauHoi.Size = new System.Drawing.Size(217, 36);
            this.cbbNhomCauHoi.TabIndex = 36;
            this.cbbNhomCauHoi.Visible = false;
            this.cbbNhomCauHoi.SelectedIndexChanged += new System.EventHandler(this.cbbNhomCauHoi_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(888, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 35;
            this.label5.Text = "Nhóm câu";
            this.label5.Visible = false;
            // 
            // cbbTenMon
            // 
            this.cbbTenMon.BackColor = System.Drawing.Color.Transparent;
            this.cbbTenMon.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbTenMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTenMon.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbTenMon.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbTenMon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbTenMon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbTenMon.ItemHeight = 30;
            this.cbbTenMon.Location = new System.Drawing.Point(530, 93);
            this.cbbTenMon.Name = "cbbTenMon";
            this.cbbTenMon.Size = new System.Drawing.Size(323, 36);
            this.cbbTenMon.TabIndex = 22;
            this.cbbTenMon.SelectedIndexChanged += new System.EventHandler(this.cbbTenMon_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(447, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Môn học";
            // 
            // cbbKhoa
            // 
            this.cbbKhoa.BackColor = System.Drawing.Color.Transparent;
            this.cbbKhoa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbKhoa.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbKhoa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbKhoa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbKhoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbKhoa.ItemHeight = 30;
            this.cbbKhoa.Location = new System.Drawing.Point(530, 48);
            this.cbbKhoa.Name = "cbbKhoa";
            this.cbbKhoa.Size = new System.Drawing.Size(322, 36);
            this.cbbKhoa.TabIndex = 20;
            this.cbbKhoa.SelectedIndexChanged += new System.EventHandler(this.cbbKhoa_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(447, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Khoa";
            // 
            // grdData
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.grdData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdData.ColumnHeadersHeight = 35;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDe,
            this.TenDe,
            this.TenKhoa,
            this.TenMon,
            this.Ngay,
            this.DSCau,
            this.User,
            this.colBtnXem});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdData.DefaultCellStyle = dataGridViewCellStyle9;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdData.Location = new System.Drawing.Point(0, 135);
            this.grdData.Name = "grdData";
            this.grdData.RowHeadersVisible = false;
            this.grdData.RowHeadersWidth = 51;
            this.grdData.RowTemplate.Height = 24;
            this.grdData.Size = new System.Drawing.Size(1306, 606);
            this.grdData.TabIndex = 1;
            this.grdData.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.grdData.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.grdData.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdData.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.grdData.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.grdData.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.grdData.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdData.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.grdData.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdData.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.grdData.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdData.ThemeStyle.HeaderStyle.Height = 35;
            this.grdData.ThemeStyle.ReadOnly = false;
            this.grdData.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.grdData.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdData.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdData.ThemeStyle.RowsStyle.Height = 24;
            this.grdData.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdData.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData_CellClick);
            this.grdData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData_CellContentClick);
            // 
            // MaDe
            // 
            this.MaDe.DataPropertyName = "MaDe";
            this.MaDe.FillWeight = 118.8442F;
            this.MaDe.HeaderText = "Mã đề";
            this.MaDe.MinimumWidth = 6;
            this.MaDe.Name = "MaDe";
            this.MaDe.ReadOnly = true;
            // 
            // TenDe
            // 
            this.TenDe.DataPropertyName = "TenDe";
            this.TenDe.FillWeight = 171.1231F;
            this.TenDe.HeaderText = "Tên đề";
            this.TenDe.MinimumWidth = 6;
            this.TenDe.Name = "TenDe";
            this.TenDe.ReadOnly = true;
            // 
            // TenKhoa
            // 
            this.TenKhoa.DataPropertyName = "MaKhoa";
            this.TenKhoa.FillWeight = 110.5981F;
            this.TenKhoa.HeaderText = "Mã khoa";
            this.TenKhoa.MinimumWidth = 6;
            this.TenKhoa.Name = "TenKhoa";
            this.TenKhoa.ReadOnly = true;
            this.TenKhoa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TenMon
            // 
            this.TenMon.DataPropertyName = "MaMon";
            this.TenMon.FillWeight = 105.9631F;
            this.TenMon.HeaderText = "Tên môn";
            this.TenMon.MinimumWidth = 6;
            this.TenMon.Name = "TenMon";
            this.TenMon.ReadOnly = true;
            this.TenMon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Ngay
            // 
            // 
            // 
            // 
            this.Ngay.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.Ngay.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.Ngay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Ngay.BackgroundStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.Ngay.CustomFormat = "dd/MM/yyyy";
            this.Ngay.DataPropertyName = "Ngay";
            this.Ngay.FillWeight = 106.0632F;
            this.Ngay.HeaderText = "Ngày";
            this.Ngay.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.Ngay.MinimumWidth = 6;
            // 
            // 
            // 
            // 
            // 
            // 
            this.Ngay.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Ngay.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.Ngay.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Ngay.MonthCalendar.DisplayMonth = new System.DateTime(2023, 3, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.Ngay.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Ngay.Name = "Ngay";
            this.Ngay.ReadOnly = true;
            this.Ngay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DSCau
            // 
            this.DSCau.DataPropertyName = "IDCauChons";
            this.DSCau.FillWeight = 90.82236F;
            this.DSCau.HeaderText = "DS câu";
            this.DSCau.MinimumWidth = 6;
            this.DSCau.Name = "DSCau";
            this.DSCau.ReadOnly = true;
            this.DSCau.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // User
            // 
            this.User.DataPropertyName = "CreateBy";
            this.User.FillWeight = 56.62952F;
            this.User.HeaderText = "Người tạo";
            this.User.MinimumWidth = 6;
            this.User.Name = "User";
            this.User.ReadOnly = true;
            this.User.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colBtnXem
            // 
            this.colBtnXem.DataPropertyName = "Xem";
            this.colBtnXem.FillWeight = 39.95678F;
            this.colBtnXem.HeaderText = "Xem";
            this.colBtnXem.MinimumWidth = 6;
            this.colBtnXem.Name = "colBtnXem";
            this.colBtnXem.Text = "...";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(1099, 93);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(89, 36);
            this.btnReset.TabIndex = 44;
            this.btnReset.Text = "Làm mới";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // UCNganHangDeThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.grpTimKiem);
            this.Name = "UCNganHangDeThi";
            this.Size = new System.Drawing.Size(1306, 741);
            this.Load += new System.EventHandler(this.UCNganHangDeThi_Load);
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox grpTimKiem;
        private Guna.UI2.WinForms.Guna2DataGridView grdData;
        private Guna.UI2.WinForms.Guna2ComboBox cbbKhoa;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cbbTenMon;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2ComboBox cbbNhomCauHoi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtDenNgay;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtTuNgay;
        private Guna.UI2.WinForms.Guna2Button btnTim;
        private System.Windows.Forms.RichTextBox rtbNhomCauHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDe;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDe;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMon;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn Ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn DSCau;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewButtonColumn colBtnXem;
        private Guna.UI2.WinForms.Guna2Button btnReset;
    }
}
