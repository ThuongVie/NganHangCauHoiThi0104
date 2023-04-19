namespace NganHangCauHoiThi.UserControls
{
    partial class FrmLoadTaoDeThi
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
            this.grpCauHoi = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblNhomDaChon = new System.Windows.Forms.Label();
            this.lblTongDiemChon = new System.Windows.Forms.Label();
            this.dgvCauHoi = new System.Windows.Forms.DataGridView();
            this.Chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhomCauHoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewImageColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExportWord = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.lblDS = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.grpCauHoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCauHoi
            // 
            this.grpCauHoi.Controls.Add(this.btnReset);
            this.grpCauHoi.Controls.Add(this.lblNhomDaChon);
            this.grpCauHoi.Controls.Add(this.lblTongDiemChon);
            this.grpCauHoi.Controls.Add(this.dgvCauHoi);
            this.grpCauHoi.Controls.Add(this.btnExportWord);
            this.grpCauHoi.Controls.Add(this.btnThoat);
            this.grpCauHoi.Controls.Add(this.btnIn);
            this.grpCauHoi.Controls.Add(this.lblDS);
            this.grpCauHoi.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCauHoi.Location = new System.Drawing.Point(0, 0);
            this.grpCauHoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpCauHoi.Name = "grpCauHoi";
            this.grpCauHoi.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpCauHoi.Size = new System.Drawing.Size(1158, 285);
            this.grpCauHoi.TabIndex = 0;
            this.grpCauHoi.TabStop = false;
            this.grpCauHoi.Text = "List câu hỏi";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(891, 82);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(255, 39);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Nhập lại";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblNhomDaChon
            // 
            this.lblNhomDaChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNhomDaChon.AutoSize = true;
            this.lblNhomDaChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNhomDaChon.Location = new System.Drawing.Point(911, 215);
            this.lblNhomDaChon.Name = "lblNhomDaChon";
            this.lblNhomDaChon.Size = new System.Drawing.Size(107, 16);
            this.lblNhomDaChon.TabIndex = 6;
            this.lblNhomDaChon.Text = "- Nhóm đã chọn: ";
            // 
            // lblTongDiemChon
            // 
            this.lblTongDiemChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongDiemChon.AutoSize = true;
            this.lblTongDiemChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTongDiemChon.Location = new System.Drawing.Point(911, 186);
            this.lblTongDiemChon.Name = "lblTongDiemChon";
            this.lblTongDiemChon.Size = new System.Drawing.Size(85, 16);
            this.lblTongDiemChon.TabIndex = 5;
            this.lblTongDiemChon.Text = "- Tổng điểm: ";
            // 
            // dgvCauHoi
            // 
            this.dgvCauHoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCauHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCauHoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chon,
            this.ID,
            this.NhomCauHoi,
            this.Diem,
            this.IDMon,
            this.NoiDung,
            this.FilePath,
            this.TenMon,
            this.TenKhoa});
            this.dgvCauHoi.Location = new System.Drawing.Point(6, 20);
            this.dgvCauHoi.Name = "dgvCauHoi";
            this.dgvCauHoi.RowHeadersWidth = 51;
            this.dgvCauHoi.RowTemplate.Height = 24;
            this.dgvCauHoi.Size = new System.Drawing.Size(879, 260);
            this.dgvCauHoi.TabIndex = 4;
            this.dgvCauHoi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCauHoi_CellClick);
            this.dgvCauHoi.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCauHoi_CellValueChanged);
            this.dgvCauHoi.Click += new System.EventHandler(this.dgvCauHoi_Click);
            // 
            // Chon
            // 
            this.Chon.FillWeight = 30F;
            this.Chon.HeaderText = "Chọn";
            this.Chon.MinimumWidth = 6;
            this.Chon.Name = "Chon";
            this.Chon.Width = 125;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.FillWeight = 70F;
            this.ID.HeaderText = "Mã";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 125;
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
            this.Diem.Width = 125;
            // 
            // IDMon
            // 
            this.IDMon.DataPropertyName = "IDMonHoc";
            this.IDMon.HeaderText = "ID Môn";
            this.IDMon.MinimumWidth = 6;
            this.IDMon.Name = "IDMon";
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
            // btnExportWord
            // 
            this.btnExportWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportWord.Location = new System.Drawing.Point(891, 39);
            this.btnExportWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportWord.Name = "btnExportWord";
            this.btnExportWord.Size = new System.Drawing.Size(95, 39);
            this.btnExportWord.TabIndex = 3;
            this.btnExportWord.Text = "Xuất Word";
            this.btnExportWord.UseVisualStyleBackColor = true;
            this.btnExportWord.Click += new System.EventHandler(this.btnExportWord_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(1071, 39);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 39);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnIn
            // 
            this.btnIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIn.Location = new System.Drawing.Point(991, 39);
            this.btnIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 39);
            this.btnIn.TabIndex = 1;
            this.btnIn.Text = "Tạo đề";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // lblDS
            // 
            this.lblDS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDS.AutoSize = true;
            this.lblDS.Location = new System.Drawing.Point(911, 157);
            this.lblDS.Name = "lblDS";
            this.lblDS.Size = new System.Drawing.Size(44, 16);
            this.lblDS.TabIndex = 0;
            this.lblDS.Text = "label1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 285);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1158, 486);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // FrmLoadTaoDeThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1158, 771);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.grpCauHoi);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmLoadTaoDeThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "`";
            this.Load += new System.EventHandler(this.FrmLoadTaoDeThi_Load);
            this.grpCauHoi.ResumeLayout(false);
            this.grpCauHoi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHoi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCauHoi;
        private System.Windows.Forms.Label lblDS;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnExportWord;
        private System.Windows.Forms.DataGridView dgvCauHoi;
        private System.Windows.Forms.Label lblNhomDaChon;
        private System.Windows.Forms.Label lblTongDiemChon;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhomCauHoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diem;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDMon;
        private System.Windows.Forms.DataGridViewImageColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhoa;
    }
}