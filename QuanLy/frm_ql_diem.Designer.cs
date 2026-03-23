namespace BTL1.thongtin
{
    partial class frm_ql_diem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ql_diem));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txttmh = new System.Windows.Forms.TextBox();
            this.txtmmh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtmsv = new System.Windows.Forms.TextBox();
            this.btndong = new System.Windows.Forms.Button();
            this.btnnhaplai = new System.Windows.Forms.Button();
            this.btnxoa = new System.Windows.Forms.Button();
            this.btnsua = new System.Windows.Forms.Button();
            this.btnthem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgdiem = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdiem)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txttmh);
            this.groupBox1.Controls.Add(this.txtmmh);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtmsv);
            this.groupBox1.Controls.Add(this.btndong);
            this.groupBox1.Controls.Add(this.btnnhaplai);
            this.groupBox1.Controls.Add(this.btnxoa);
            this.groupBox1.Controls.Add(this.btnsua);
            this.groupBox1.Controls.Add(this.btnthem);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDiem);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 82);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(352, 288);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin điểm";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txttmh
            // 
            this.txttmh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttmh.Location = new System.Drawing.Point(146, 115);
            this.txttmh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txttmh.Name = "txttmh";
            this.txttmh.Size = new System.Drawing.Size(191, 26);
            this.txttmh.TabIndex = 29;
            // 
            // txtmmh
            // 
            this.txtmmh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmmh.Location = new System.Drawing.Point(145, 74);
            this.txtmmh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtmmh.Name = "txtmmh";
            this.txtmmh.Size = new System.Drawing.Size(191, 26);
            this.txtmmh.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(26, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Mã Sinh Viên";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtmsv
            // 
            this.txtmsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmsv.Location = new System.Drawing.Point(146, 37);
            this.txtmsv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtmsv.Name = "txtmsv";
            this.txtmsv.Size = new System.Drawing.Size(191, 26);
            this.txtmsv.TabIndex = 26;
            this.txtmsv.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btndong
            // 
            this.btndong.Image = global::BTL_.NET.Properties.Resources.close;
            this.btndong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndong.Location = new System.Drawing.Point(202, 232);
            this.btndong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(87, 39);
            this.btndong.TabIndex = 23;
            this.btndong.Text = "Đóng";
            this.btndong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btnnhaplai
            // 
            this.btnnhaplai.Image = global::BTL_.NET.Properties.Resources.refresh;
            this.btnnhaplai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnhaplai.Location = new System.Drawing.Point(81, 232);
            this.btnnhaplai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnnhaplai.Name = "btnnhaplai";
            this.btnnhaplai.Size = new System.Drawing.Size(114, 39);
            this.btnnhaplai.TabIndex = 22;
            this.btnnhaplai.Text = "Nhập lại";
            this.btnnhaplai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnnhaplai.UseVisualStyleBackColor = true;
            // 
            // btnxoa
            // 
            this.btnxoa.Image = global::BTL_.NET.Properties.Resources.del;
            this.btnxoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnxoa.Location = new System.Drawing.Point(240, 185);
            this.btnxoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnxoa.Name = "btnxoa";
            this.btnxoa.Size = new System.Drawing.Size(72, 39);
            this.btnxoa.TabIndex = 21;
            this.btnxoa.Text = "Xóa";
            this.btnxoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnxoa.UseVisualStyleBackColor = true;
            this.btnxoa.Click += new System.EventHandler(this.btnxoa_Click);
            // 
            // btnsua
            // 
            this.btnsua.Image = global::BTL_.NET.Properties.Resources.tool;
            this.btnsua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsua.Location = new System.Drawing.Point(159, 185);
            this.btnsua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(73, 39);
            this.btnsua.TabIndex = 20;
            this.btnsua.Text = "Sửa";
            this.btnsua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // btnthem
            // 
            this.btnthem.Image = global::BTL_.NET.Properties.Resources.add;
            this.btnthem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnthem.Location = new System.Drawing.Point(64, 185);
            this.btnthem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(87, 39);
            this.btnthem.TabIndex = 19;
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
            this.label5.Location = new System.Drawing.Point(26, 154);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Điểm:";
            // 
            // txtDiem
            // 
            this.txtDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiem.Location = new System.Drawing.Point(146, 152);
            this.txtDiem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.Size = new System.Drawing.Size(191, 26);
            this.txtDiem.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(26, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tên môn học:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(26, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mã Môn Học";
            // 
            // dgdiem
            // 
            this.dgdiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdiem.Location = new System.Drawing.Point(390, 91);
            this.dgdiem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgdiem.Name = "dgdiem";
            this.dgdiem.RowHeadersWidth = 51;
            this.dgdiem.RowTemplate.Height = 24;
            this.dgdiem.Size = new System.Drawing.Size(423, 279);
            this.dgdiem.TabIndex = 26;
            this.dgdiem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgdiem_CellContentClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(-9, -5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(835, 66);
            this.label1.TabIndex = 25;
            this.label1.Text = "ĐIỂM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBox1.Location = new System.Drawing.Point(-12, 50);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(837, 12);
            this.richTextBox1.TabIndex = 23;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBox2.Location = new System.Drawing.Point(-12, 50);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(858, 12);
            this.richTextBox2.TabIndex = 27;
            this.richTextBox2.Text = "";
            // 
            // frm_ql_diem
            // 
            this.Appearance.BackColor = System.Drawing.Color.LightBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 392);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgdiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_ql_diem.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frm_ql_diem";
            this.Text = "CẬP NHẬT ĐIỂM";
            this.Load += new System.EventHandler(this.frm_ql_diem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdiem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgdiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnnhaplai;
        private System.Windows.Forms.Button btnxoa;
        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtmsv;
        private System.Windows.Forms.TextBox txttmh;
        private System.Windows.Forms.TextBox txtmmh;
    }
}