namespace NganHangCauHoiThi.UserControls
{
    partial class UcChonKieuTaoDe
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new Guna.UI2.WinForms.Guna2Button();
            this.btnRandom = new Guna.UI2.WinForms.Guna2Button();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(52, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "LỰA CHỌN KIỂU TẠO ĐỀ THI";
            // 
            // btnSelect
            // 
            this.btnSelect.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSelect.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSelect.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSelect.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSelect.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSelect.ForeColor = System.Drawing.Color.White;
            this.btnSelect.Location = new System.Drawing.Point(139, 72);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(113, 45);
            this.btnSelect.TabIndex = 47;
            this.btnSelect.Text = "Lựa chọn";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnRandom
            // 
            this.btnRandom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRandom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRandom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRandom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRandom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRandom.ForeColor = System.Drawing.Color.White;
            this.btnRandom.Location = new System.Drawing.Point(20, 72);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(113, 45);
            this.btnRandom.TabIndex = 48;
            this.btnRandom.Text = "Ngẫu nhiên";
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnBack
            // 
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(258, 72);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 45);
            this.btnBack.TabIndex = 49;
            this.btnBack.Text = "Trở về";
            // 
            // UcChonKieuTaoDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label1);
            this.Name = "UcChonKieuTaoDe";
            this.Size = new System.Drawing.Size(384, 142);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnSelect;
        private Guna.UI2.WinForms.Guna2Button btnRandom;
        private Guna.UI2.WinForms.Guna2Button btnBack;
    }
}
