namespace BTL_.NET.TimKiem
{
    partial class tk_giaovien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tk_giaovien));
            this.dggv = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbtim = new System.Windows.Forms.ComboBox();
            this.btndong = new System.Windows.Forms.Button();
            this.btnloadlai = new System.Windows.Forms.Button();
            this.btntim = new System.Windows.Forms.Button();
            this.txttukhoa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dggv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dggv
            // 
            this.dggv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dggv.Location = new System.Drawing.Point(408, 104);
            this.dggv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dggv.Name = "dggv";
            this.dggv.RowHeadersWidth = 62;
            this.dggv.Size = new System.Drawing.Size(506, 231);
            this.dggv.TabIndex = 14;
            this.dggv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dggv_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbtim);
            this.groupBox1.Controls.Add(this.btndong);
            this.groupBox1.Controls.Add(this.btnloadlai);
            this.groupBox1.Controls.Add(this.btntim);
            this.groupBox1.Controls.Add(this.txttukhoa);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 104);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(380, 231);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Tìm Kiếm";
            // 
            // cbtim
            // 
            this.cbtim.FormattingEnabled = true;
            this.cbtim.Items.AddRange(new object[] {
            "Mã Giảng Viên",
            "Tên Giảng Viên",
            "Mã Môn Học",
            "Số Điện Thoại",
            "Quê Quán"});
            this.cbtim.Location = new System.Drawing.Point(144, 46);
            this.cbtim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbtim.Name = "cbtim";
            this.cbtim.Size = new System.Drawing.Size(217, 28);
            this.cbtim.TabIndex = 9;
            this.cbtim.SelectedIndexChanged += new System.EventHandler(this.cbtim_SelectedIndexChanged);
            // 
            // btndong
            // 
            this.btndong.Image = global::BTL_.NET.Properties.Resources.close;
            this.btndong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndong.Location = new System.Drawing.Point(278, 152);
            this.btndong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(82, 39);
            this.btndong.TabIndex = 8;
            this.btndong.Text = "Đóng";
            this.btndong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btnloadlai
            // 
            this.btnloadlai.Image = global::BTL_.NET.Properties.Resources.refresh;
            this.btnloadlai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnloadlai.Location = new System.Drawing.Point(154, 152);
            this.btnloadlai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnloadlai.Name = "btnloadlai";
            this.btnloadlai.Size = new System.Drawing.Size(106, 39);
            this.btnloadlai.TabIndex = 7;
            this.btnloadlai.Text = "Load lại";
            this.btnloadlai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnloadlai.UseVisualStyleBackColor = true;
            this.btnloadlai.Click += new System.EventHandler(this.btnloadlai_Click);
            // 
            // btntim
            // 
            this.btntim.Image = global::BTL_.NET.Properties.Resources.Find;
            this.btntim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btntim.Location = new System.Drawing.Point(26, 152);
            this.btntim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btntim.Name = "btntim";
            this.btntim.Size = new System.Drawing.Size(110, 39);
            this.btntim.TabIndex = 4;
            this.btntim.Text = "Tìm kiếm";
            this.btntim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btntim.UseVisualStyleBackColor = true;
            this.btntim.Click += new System.EventHandler(this.btntim_Click_1);
            // 
            // txttukhoa
            // 
            this.txttukhoa.Location = new System.Drawing.Point(144, 97);
            this.txttukhoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txttukhoa.Name = "txttukhoa";
            this.txttukhoa.Size = new System.Drawing.Size(217, 26);
            this.txttukhoa.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tìm Theo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Từ Khoá";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(-7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(945, 64);
            this.label1.TabIndex = 12;
            this.label1.Text = "GIÁO VIÊN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tk_giaovien
            // 
            this.Appearance.BackColor = System.Drawing.Color.LightBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 363);
            this.Controls.Add(this.dggv);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("tk_giaovien.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "tk_giaovien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TÌM KIẾM GIÁO VIÊN";
            this.Load += new System.EventHandler(this.tk_giaovien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dggv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dggv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbtim;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnloadlai;
        private System.Windows.Forms.Button btntim;
        private System.Windows.Forms.TextBox txttukhoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}