namespace NganHangCauHoiThi.UserControls
{
    partial class UcLoadTaoDeThi
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
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.lblNhomDaChon = new System.Windows.Forms.Label();
            this.lblTongDiemChon = new System.Windows.Forms.Label();
            this.lblDS = new System.Windows.Forms.Label();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.btnTaoDe = new Guna.UI2.WinForms.Guna2Button();
            this.dgvCauHoi = new System.Windows.Forms.DataGridView();
            this.Chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCauHoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhomCauHoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewImageColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXuatWord = new Guna.UI2.WinForms.Guna2Button();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(793, 6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(89, 45);
            this.btnBack.TabIndex = 58;
            this.btnBack.Text = "Trở về";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(589, 6);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(89, 45);
            this.btnLuu.TabIndex = 57;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // lblNhomDaChon
            // 
            this.lblNhomDaChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNhomDaChon.AutoSize = true;
            this.lblNhomDaChon.BackColor = System.Drawing.Color.Transparent;
            this.lblNhomDaChon.ForeColor = System.Drawing.Color.Red;
            this.lblNhomDaChon.Location = new System.Drawing.Point(30, 498);
            this.lblNhomDaChon.Name = "lblNhomDaChon";
            this.lblNhomDaChon.Size = new System.Drawing.Size(107, 16);
            this.lblNhomDaChon.TabIndex = 56;
            this.lblNhomDaChon.Text = "- Nhóm đã chọn: ";
            // 
            // lblTongDiemChon
            // 
            this.lblTongDiemChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongDiemChon.AutoSize = true;
            this.lblTongDiemChon.BackColor = System.Drawing.Color.Transparent;
            this.lblTongDiemChon.ForeColor = System.Drawing.Color.Red;
            this.lblTongDiemChon.Location = new System.Drawing.Point(30, 471);
            this.lblTongDiemChon.Name = "lblTongDiemChon";
            this.lblTongDiemChon.Size = new System.Drawing.Size(85, 16);
            this.lblTongDiemChon.TabIndex = 55;
            this.lblTongDiemChon.Text = "- Tổng điểm: ";
            this.lblTongDiemChon.Click += new System.EventHandler(this.lblTongDiemChon_Click);
            // 
            // lblDS
            // 
            this.lblDS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDS.AutoSize = true;
            this.lblDS.BackColor = System.Drawing.Color.Transparent;
            this.lblDS.ForeColor = System.Drawing.Color.Red;
            this.lblDS.Location = new System.Drawing.Point(30, 444);
            this.lblDS.Name = "lblDS";
            this.lblDS.Size = new System.Drawing.Size(63, 16);
            this.lblDS.TabIndex = 54;
            this.lblDS.Text = "- Từ ngày";
            // 
            // btnReset
            // 
            this.btnReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(494, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(89, 45);
            this.btnReset.TabIndex = 53;
            this.btnReset.Text = "Nhập lại";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExport
            // 
            this.btnExport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(965, 6);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(89, 45);
            this.btnExport.TabIndex = 52;
            this.btnExport.Text = "Lưu Word";
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnTaoDe
            // 
            this.btnTaoDe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoDe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoDe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaoDe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaoDe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTaoDe.ForeColor = System.Drawing.Color.White;
            this.btnTaoDe.Location = new System.Drawing.Point(399, 6);
            this.btnTaoDe.Name = "btnTaoDe";
            this.btnTaoDe.Size = new System.Drawing.Size(89, 45);
            this.btnTaoDe.TabIndex = 51;
            this.btnTaoDe.Text = "Tạo đề";
            this.btnTaoDe.Click += new System.EventHandler(this.btnTaoDe_Click);
            // 
            // dgvCauHoi
            // 
            this.dgvCauHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCauHoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chon,
            this.ID,
            this.MaCauHoi,
            this.NhomCauHoi,
            this.Diem,
            this.IDMon,
            this.NoiDung,
            this.FilePath,
            this.TenMon,
            this.TenKhoa,
            this.MaxSTT});
            this.dgvCauHoi.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCauHoi.Location = new System.Drawing.Point(0, 0);
            this.dgvCauHoi.Name = "dgvCauHoi";
            this.dgvCauHoi.RowHeadersWidth = 51;
            this.dgvCauHoi.RowTemplate.Height = 24;
            this.dgvCauHoi.Size = new System.Drawing.Size(569, 436);
            this.dgvCauHoi.TabIndex = 48;
            this.dgvCauHoi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCauHoi_CellClick_2);
            this.dgvCauHoi.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCauHoi_CellValueChanged_2);
            // 
            // Chon
            // 
            this.Chon.FillWeight = 30F;
            this.Chon.HeaderText = "Chọn";
            this.Chon.MinimumWidth = 6;
            this.Chon.Name = "Chon";
            this.Chon.Width = 70;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 70F;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // MaCauHoi
            // 
            this.MaCauHoi.DataPropertyName = "MaCauHoi";
            this.MaCauHoi.HeaderText = "Mã câu";
            this.MaCauHoi.MinimumWidth = 6;
            this.MaCauHoi.Name = "MaCauHoi";
            this.MaCauHoi.Width = 110;
            // 
            // NhomCauHoi
            // 
            this.NhomCauHoi.DataPropertyName = "NhomCauHoi";
            this.NhomCauHoi.HeaderText = "Nhóm câu";
            this.NhomCauHoi.MinimumWidth = 6;
            this.NhomCauHoi.Name = "NhomCauHoi";
            this.NhomCauHoi.Width = 125;
            // 
            // Diem
            // 
            this.Diem.DataPropertyName = "Diem";
            this.Diem.HeaderText = "Điểm";
            this.Diem.MinimumWidth = 6;
            this.Diem.Name = "Diem";
            this.Diem.Width = 70;
            // 
            // IDMon
            // 
            this.IDMon.DataPropertyName = "IDMonHoc";
            this.IDMon.HeaderText = "ID Môn";
            this.IDMon.MinimumWidth = 6;
            this.IDMon.Name = "IDMon";
            this.IDMon.Visible = false;
            this.IDMon.Width = 125;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Ndung";
            this.NoiDung.MinimumWidth = 6;
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Visible = false;
            this.NoiDung.Width = 125;
            // 
            // FilePath
            // 
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "Url";
            this.FilePath.MinimumWidth = 6;
            this.FilePath.Name = "FilePath";
            this.FilePath.Width = 125;
            // 
            // TenMon
            // 
            this.TenMon.DataPropertyName = "TenMon";
            this.TenMon.HeaderText = "Môn";
            this.TenMon.MinimumWidth = 6;
            this.TenMon.Name = "TenMon";
            this.TenMon.Width = 125;
            // 
            // TenKhoa
            // 
            this.TenKhoa.DataPropertyName = "TenKhoa";
            this.TenKhoa.HeaderText = "Khoa";
            this.TenKhoa.MinimumWidth = 6;
            this.TenKhoa.Name = "TenKhoa";
            this.TenKhoa.Width = 125;
            // 
            // MaxSTT
            // 
            this.MaxSTT.DataPropertyName = "MaxSTT";
            this.MaxSTT.HeaderText = "MaxSTT";
            this.MaxSTT.MinimumWidth = 6;
            this.MaxSTT.Name = "MaxSTT";
            this.MaxSTT.Visible = false;
            this.MaxSTT.Width = 125;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(578, 42);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(725, 526);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1306, 37);
            this.panel1.TabIndex = 54;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label5.Location = new System.Drawing.Point(6, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "LOAD ĐỀ THI";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXuatWord);
            this.panel2.Controls.Add(this.btnBack);
            this.panel2.Controls.Add(this.btnLuu);
            this.panel2.Controls.Add(this.btnTaoDe);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnReset);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 570);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1306, 66);
            this.panel2.TabIndex = 55;
            // 
            // btnXuatWord
            // 
            this.btnXuatWord.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnXuatWord.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnXuatWord.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnXuatWord.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnXuatWord.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXuatWord.ForeColor = System.Drawing.Color.White;
            this.btnXuatWord.Location = new System.Drawing.Point(684, 6);
            this.btnXuatWord.Name = "btnXuatWord";
            this.btnXuatWord.Size = new System.Drawing.Size(103, 45);
            this.btnXuatWord.TabIndex = 59;
            this.btnXuatWord.Text = "Xuất Word";
            this.btnXuatWord.Click += new System.EventHandler(this.btnXuatWord_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.Controls.Add(this.dgvCauHoi);
            this.panel3.Controls.Add(this.lblDS);
            this.panel3.Controls.Add(this.lblTongDiemChon);
            this.panel3.Controls.Add(this.lblNhomDaChon);
            this.panel3.Location = new System.Drawing.Point(3, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(569, 525);
            this.panel3.TabIndex = 57;
            // 
            // UcLoadTaoDeThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel1);
            this.Name = "UcLoadTaoDeThi";
            this.Size = new System.Drawing.Size(1306, 636);
            this.Load += new System.EventHandler(this.UcLoadTaoDeThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView dgvCauHoi;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private System.Windows.Forms.Label lblNhomDaChon;
        private System.Windows.Forms.Label lblTongDiemChon;
        private System.Windows.Forms.Label lblDS;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private Guna.UI2.WinForms.Guna2Button btnExport;
        private Guna.UI2.WinForms.Guna2Button btnTaoDe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCauHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhomCauHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diem;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMon;
        private System.Windows.Forms.DataGridViewImageColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxSTT;
        private Guna.UI2.WinForms.Guna2Button btnXuatWord;
    }
}
