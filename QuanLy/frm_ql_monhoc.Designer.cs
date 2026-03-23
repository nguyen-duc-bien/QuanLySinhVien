namespace BTL1.thongtin
{
    partial class frm_ql_monhoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ql_monhoc));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btndong = new System.Windows.Forms.Button();
            this.btnnhaplai = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSotiet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenmh = new System.Windows.Forms.TextBox();
            this.txtMamh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgmh = new System.Windows.Forms.DataGridView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmagv = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgmh)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtmagv);
            this.groupBox1.Controls.Add(this.btndong);
            this.groupBox1.Controls.Add(this.btnnhaplai);
            this.groupBox1.Controls.Add(this.btnxoa);
            this.groupBox1.Controls.Add(this.btnsua);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnthem);
            this.groupBox1.Controls.Add(this.txtSotiet);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTenmh);
            this.groupBox1.Controls.Add(this.txtMamh);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 83);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(344, 288);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin môn học";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btndong
            // 
            this.btndong.Image = global::BTL_.NET.Properties.Resources.close;
            this.btndong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndong.Location = new System.Drawing.Point(175, 244);
            this.btndong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(87, 39);
            this.btndong.TabIndex = 43;
            this.btndong.Text = "Đóng";
            this.btndong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btnnhaplai
            // 
            this.btnnhaplai.Image = global::BTL_.NET.Properties.Resources.refresh;
            this.btnnhaplai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnhaplai.Location = new System.Drawing.Point(54, 244);
            this.btnnhaplai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnnhaplai.Name = "btnnhaplai";
            this.btnnhaplai.Size = new System.Drawing.Size(114, 39);
            this.btnnhaplai.TabIndex = 42;
            this.btnnhaplai.Text = "Nhập lại";
            this.btnnhaplai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnnhaplai.UseVisualStyleBackColor = true;
            this.btnnhaplai.Click += new System.EventHandler(this.btnnhaplai_Click);
            // 
            // btnxoa
            // 
            this.btnxoa.Image = global::BTL_.NET.Properties.Resources.del;
            this.btnxoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnxoa.Location = new System.Drawing.Point(212, 198);
            this.btnxoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(72, 39);
            this.btnxoa.TabIndex = 41;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Image = global::BTL_.NET.Properties.Resources.tool;
            this.btnsua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsua.Location = new System.Drawing.Point(132, 198);
            this.btnsua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(73, 39);
            this.btnsua.TabIndex = 40;
            this.btnsua.Text = "Sửa";
            this.btnsua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.Image = global::BTL_.NET.Properties.Resources.add;
            this.btnthem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnthem.Location = new System.Drawing.Point(38, 198);
            this.btnthem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(87, 39);
            this.btnthem.TabIndex = 39;
            this.btnthem.Text = "Thêm";
            this.btnthem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(19, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Mã giáo viên:";
            // 
            // txtSotiet
            // 
            this.txtSotiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSotiet.Location = new System.Drawing.Point(140, 165);
            this.txtSotiet.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSotiet.Name = "txtSotiet";
            this.txtSotiet.Size = new System.Drawing.Size(191, 26);
            this.txtSotiet.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Số tín chỉ: ";
            // 
            // txtTenmh
            // 
            this.txtTenmh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenmh.Location = new System.Drawing.Point(140, 133);
            this.txtTenmh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTenmh.Name = "txtTenmh";
            this.txtTenmh.Size = new System.Drawing.Size(191, 26);
            this.txtTenmh.TabIndex = 3;
            // 
            // txtMamh
            // 
            this.txtMamh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMamh.Location = new System.Drawing.Point(140, 44);
            this.txtMamh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMamh.Name = "txtMamh";
            this.txtMamh.Size = new System.Drawing.Size(191, 26);
            this.txtMamh.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(13, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên môn học:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã môn học:";
            // 
            // dgmh
            // 
            this.dgmh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgmh.Location = new System.Drawing.Point(381, 83);
            this.dgmh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgmh.Name = "dgmh";
            this.dgmh.RowHeadersWidth = 51;
            this.dgmh.RowTemplate.Height = 24;
            this.dgmh.Size = new System.Drawing.Size(432, 288);
            this.dgmh.TabIndex = 22;
            this.dgmh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgmh_CellContentClick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBox1.Location = new System.Drawing.Point(-12, 51);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(867, 12);
            this.richTextBox1.TabIndex = 19;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(-8, -3);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(845, 66);
            this.label1.TabIndex = 21;
            this.label1.Text = "MÔN HỌC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtmagv
            // 
            this.txtmagv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmagv.Location = new System.Drawing.Point(140, 85);
            this.txtmagv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtmagv.Name = "txtmagv";
            this.txtmagv.Size = new System.Drawing.Size(191, 26);
            this.txtmagv.TabIndex = 44;
            // 
            // frm_ql_monhoc
            // 
            this.Appearance.BackColor = System.Drawing.Color.LightBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 386);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgmh);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_ql_monhoc.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frm_ql_monhoc";
            this.Text = "CẬP NHẬT MÔN HỌC";
            this.Load += new System.EventHandler(this.frm_ql_monhoc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgmh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSotiet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenmh;
        private System.Windows.Forms.TextBox txtMamh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgmh;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnnhaplai;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.TextBox txtmagv;
    }
}