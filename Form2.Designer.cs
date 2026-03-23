namespace BTL_.NET
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMonChuaDK = new System.Windows.Forms.DataGridView();
            this.txtmagv = new System.Windows.Forms.TextBox();
            this.btndong = new System.Windows.Forms.Button();
            this.btnnhaplai = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSotiet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenmh = new System.Windows.Forms.TextBox();
            this.txtMamh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonChuaDK)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(372, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 25);
            this.label1.TabIndex = 71;
            this.label1.Text = "Danh sách học phần chưa đăng kí";
            // 
            // dgvMonChuaDK
            // 
            this.dgvMonChuaDK.AllowUserToAddRows = false;
            this.dgvMonChuaDK.AllowUserToDeleteRows = false;
            this.dgvMonChuaDK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonChuaDK.Location = new System.Drawing.Point(342, 36);
            this.dgvMonChuaDK.Name = "dgvMonChuaDK";
            this.dgvMonChuaDK.ReadOnly = true;
            this.dgvMonChuaDK.RowHeadersWidth = 51;
            this.dgvMonChuaDK.RowTemplate.Height = 24;
            this.dgvMonChuaDK.Size = new System.Drawing.Size(446, 148);
            this.dgvMonChuaDK.TabIndex = 70;
            this.dgvMonChuaDK.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMonChuaDK_CellContentClick);
            // 
            // txtmagv
            // 
            this.txtmagv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmagv.Location = new System.Drawing.Point(146, 78);
            this.txtmagv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtmagv.Name = "txtmagv";
            this.txtmagv.Size = new System.Drawing.Size(191, 26);
            this.txtmagv.TabIndex = 69;
            // 
            // btndong
            // 
            this.btndong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndong.Image = global::BTL_.NET.Properties.Resources.close;
            this.btndong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndong.Location = new System.Drawing.Point(181, 237);
            this.btndong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btndong.Name = "btndong";
            this.btndong.Size = new System.Drawing.Size(87, 39);
            this.btndong.TabIndex = 68;
            this.btndong.Text = "Đóng";
            this.btndong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndong.UseVisualStyleBackColor = true;
            this.btndong.Click += new System.EventHandler(this.btndong_Click);
            // 
            // btnnhaplai
            // 
            this.btnnhaplai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnhaplai.Image = global::BTL_.NET.Properties.Resources.refresh;
            this.btnnhaplai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnhaplai.Location = new System.Drawing.Point(60, 237);
            this.btnnhaplai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnnhaplai.Name = "btnnhaplai";
            this.btnnhaplai.Size = new System.Drawing.Size(114, 39);
            this.btnnhaplai.TabIndex = 67;
            this.btnnhaplai.Text = "Đăng Kí";
            this.btnnhaplai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnnhaplai.UseVisualStyleBackColor = true;
            this.btnnhaplai.Click += new System.EventHandler(this.btnnhaplai_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(25, 78);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 66;
            this.label5.Text = "Mã giáo viên:";
            // 
            // txtSotiet
            // 
            this.txtSotiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSotiet.Location = new System.Drawing.Point(146, 158);
            this.txtSotiet.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSotiet.Name = "txtSotiet";
            this.txtSotiet.Size = new System.Drawing.Size(191, 26);
            this.txtSotiet.TabIndex = 65;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(25, 162);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 64;
            this.label4.Text = "Số tín chỉ: ";
            // 
            // txtTenmh
            // 
            this.txtTenmh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenmh.Location = new System.Drawing.Point(146, 126);
            this.txtTenmh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTenmh.Name = "txtTenmh";
            this.txtTenmh.Size = new System.Drawing.Size(191, 26);
            this.txtTenmh.TabIndex = 63;
            // 
            // txtMamh
            // 
            this.txtMamh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMamh.Location = new System.Drawing.Point(146, 37);
            this.txtMamh.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMamh.Name = "txtMamh";
            this.txtMamh.Size = new System.Drawing.Size(191, 26);
            this.txtMamh.TabIndex = 62;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 61;
            this.label3.Text = "Tên môn học:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(25, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 60;
            this.label2.Text = "Mã môn học:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 285);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvMonChuaDK);
            this.Controls.Add(this.txtmagv);
            this.Controls.Add(this.btndong);
            this.Controls.Add(this.btnnhaplai);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSotiet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTenmh);
            this.Controls.Add(this.txtMamh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonChuaDK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMonChuaDK;
        private System.Windows.Forms.TextBox txtmagv;
        private System.Windows.Forms.Button btndong;
        private System.Windows.Forms.Button btnnhaplai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSotiet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenmh;
        private System.Windows.Forms.TextBox txtMamh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}