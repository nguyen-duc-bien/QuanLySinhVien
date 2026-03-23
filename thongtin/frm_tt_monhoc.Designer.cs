namespace BTL1.thongtin
{
    partial class frm_tt_monhoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_tt_monhoc));
            this.label5 = new System.Windows.Forms.Label();
            this.txtMagv = new System.Windows.Forms.TextBox();
            this.txtTenmh = new System.Windows.Forms.TextBox();
            this.txtMamh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btIn = new System.Windows.Forms.Button();
            this.btĐóng = new System.Windows.Forms.Button();
            this.txtSotiet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvmh = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmh)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(4, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Mã giáo viên:";
            // 
            // txtMagv
            // 
            this.txtMagv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMagv.Location = new System.Drawing.Point(140, 149);
            this.txtMagv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMagv.Name = "txtMagv";
            this.txtMagv.ReadOnly = true;
            this.txtMagv.Size = new System.Drawing.Size(191, 26);
            this.txtMagv.TabIndex = 11;
            // 
            // txtTenmh
            // 
            this.txtTenmh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenmh.Location = new System.Drawing.Point(140, 82);
            this.txtTenmh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTenmh.Name = "txtTenmh";
            this.txtTenmh.ReadOnly = true;
            this.txtTenmh.Size = new System.Drawing.Size(191, 26);
            this.txtTenmh.TabIndex = 3;
            // 
            // txtMamh
            // 
            this.txtMamh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMamh.Location = new System.Drawing.Point(140, 44);
            this.txtMamh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMamh.Name = "txtMamh";
            this.txtMamh.ReadOnly = true;
            this.txtMamh.Size = new System.Drawing.Size(191, 26);
            this.txtMamh.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(4, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên môn học:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBox1.Location = new System.Drawing.Point(-5, 53);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(837, 12);
            this.richTextBox1.TabIndex = 23;
            this.richTextBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã môn học:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btIn);
            this.groupBox1.Controls.Add(this.btĐóng);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMagv);
            this.groupBox1.Controls.Add(this.txtSotiet);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTenmh);
            this.groupBox1.Controls.Add(this.txtMamh);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(454, 85);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(336, 248);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin môn học";
            // 
            // btIn
            // 
            this.btIn.AutoSize = true;
            this.btIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIn.ForeColor = System.Drawing.Color.Black;
            this.btIn.Image = global::BTL_.NET.Properties.Resources.Print;
            this.btIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btIn.Location = new System.Drawing.Point(84, 194);
            this.btIn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btIn.Name = "btIn";
            this.btIn.Size = new System.Drawing.Size(92, 48);
            this.btIn.TabIndex = 24;
            this.btIn.Text = "     In";
            this.btIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btIn.UseVisualStyleBackColor = true;
            // 
            // btĐóng
            // 
            this.btĐóng.AutoSize = true;
            this.btĐóng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btĐóng.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btĐóng.ForeColor = System.Drawing.Color.Black;
            this.btĐóng.Image = global::BTL_.NET.Properties.Resources.close;
            this.btĐóng.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btĐóng.Location = new System.Drawing.Point(175, 194);
            this.btĐóng.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btĐóng.Name = "btĐóng";
            this.btĐóng.Size = new System.Drawing.Size(140, 48);
            this.btĐóng.TabIndex = 23;
            this.btĐóng.Text = "     Đóng";
            this.btĐóng.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btĐóng.UseVisualStyleBackColor = true;
            this.btĐóng.Click += new System.EventHandler(this.btĐóng_Click);
            // 
            // txtSotiet
            // 
            this.txtSotiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSotiet.Location = new System.Drawing.Point(140, 116);
            this.txtSotiet.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSotiet.Name = "txtSotiet";
            this.txtSotiet.ReadOnly = true;
            this.txtSotiet.Size = new System.Drawing.Size(191, 26);
            this.txtSotiet.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(4, 155);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Số tín chỉ:";
            // 
            // dgvmh
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvmh.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvmh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmh.Location = new System.Drawing.Point(28, 94);
            this.dgvmh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgvmh.Name = "dgvmh";
            this.dgvmh.RowHeadersWidth = 51;
            this.dgvmh.RowTemplate.Height = 24;
            this.dgvmh.Size = new System.Drawing.Size(403, 238);
            this.dgvmh.TabIndex = 26;
            this.dgvmh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvmh_CellContentClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(-2, -2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(814, 66);
            this.label1.TabIndex = 25;
            this.label1.Text = "MÔN HỌC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frm_tt_monhoc
            // 
            this.Appearance.BackColor = System.Drawing.Color.LightBlue;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 354);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvmh);
            this.Controls.Add(this.label1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frm_tt_monhoc.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frm_tt_monhoc";
            this.Text = "THÔNG TIN MÔN HỌC";
            this.Load += new System.EventHandler(this.frm_tt_monhoc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMagv;
        private System.Windows.Forms.TextBox txtTenmh;
        private System.Windows.Forms.TextBox txtMamh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvmh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btIn;
        private System.Windows.Forms.Button btĐóng;
        private System.Windows.Forms.TextBox txtSotiet;
        private System.Windows.Forms.Label label4;
    }
}