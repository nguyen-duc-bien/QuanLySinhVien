namespace BTL_.NET
{
    partial class Trangchu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Trangchu));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExitBtn = new DevComponents.DotNetBar.ButtonX();
            this.infoBtn = new DevComponents.DotNetBar.ButtonX();
            this.SignUpBtn = new DevComponents.DotNetBar.ButtonX();
            this.SignInBtn = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(816, 96);
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ SINH VIÊN KHOA CNTT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ExitBtn);
            this.panel1.Controls.Add(this.infoBtn);
            this.panel1.Controls.Add(this.SignUpBtn);
            this.panel1.Controls.Add(this.SignInBtn);
            this.panel1.Location = new System.Drawing.Point(11, 110);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(106, 495);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ExitBtn
            // 
            this.ExitBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ExitBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.Image = ((System.Drawing.Image)(resources.GetObject("ExitBtn.Image")));
            this.ExitBtn.ImageAlt = ((System.Drawing.Image)(resources.GetObject("ExitBtn.ImageAlt")));
            this.ExitBtn.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.ExitBtn.Location = new System.Drawing.Point(5, 346);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExitBtn.Name = "buttonX4";
            this.ExitBtn.Size = new System.Drawing.Size(92, 69);
            this.ExitBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ExitBtn.TabIndex = 3;
            this.ExitBtn.Text = "Thoát";
            this.ExitBtn.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // infoBtn
            // 
            this.infoBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.infoBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.infoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBtn.Image = ((System.Drawing.Image)(resources.GetObject("infoBtn.Image")));
            this.infoBtn.ImageAlt = ((System.Drawing.Image)(resources.GetObject("infoBtn.ImageAlt")));
            this.infoBtn.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.infoBtn.Location = new System.Drawing.Point(5, 242);
            this.infoBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.infoBtn.Name = "buttonX3";
            this.infoBtn.Size = new System.Drawing.Size(92, 69);
            this.infoBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.infoBtn.TabIndex = 2;
            this.infoBtn.Text = "Thông tin";
            // 
            // SignUpBtn
            // 
            this.SignUpBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.SignUpBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.SignUpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUpBtn.Image = ((System.Drawing.Image)(resources.GetObject("SignUpBtn.Image")));
            this.SignUpBtn.ImageAlt = ((System.Drawing.Image)(resources.GetObject("SignUpBtn.ImageAlt")));
            this.SignUpBtn.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.SignUpBtn.Location = new System.Drawing.Point(5, 142);
            this.SignUpBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SignUpBtn.Name = "buttonX2";
            this.SignUpBtn.Size = new System.Drawing.Size(92, 69);
            this.SignUpBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SignUpBtn.TabIndex = 1;
            this.SignUpBtn.Text = "Đăng ký";
            this.SignUpBtn.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // SignInBtn
            // 
            this.SignInBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.SignInBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.SignInBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignInBtn.Image = ((System.Drawing.Image)(resources.GetObject("SignInBtn.Image")));
            this.SignInBtn.ImageAlt = ((System.Drawing.Image)(resources.GetObject("SignInBtn.ImageAlt")));
            this.SignInBtn.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.SignInBtn.Location = new System.Drawing.Point(5, 38);
            this.SignInBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SignInBtn.Name = "buttonX1";
            this.SignInBtn.Size = new System.Drawing.Size(92, 69);
            this.SignInBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SignInBtn.TabIndex = 0;
            this.SignInBtn.Text = "Đăng nhập";
            this.SignInBtn.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(123, 110);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(816, 41);
            this.panel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(553, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "KHOA CÔNG NGHỆ THÔNG TIN - KIẾN TẠO TƯƠNG LAI";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(11, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Trangchu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = global::BTL_.NET.Properties.Resources.Tim_hieu_ve_truong_Dai_hoc_UNETI;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(948, 599);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Trangchu";
            this.Text = "Trang chủ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Trangchu_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.ButtonX ExitBtn;
        private DevComponents.DotNetBar.ButtonX infoBtn;
        private DevComponents.DotNetBar.ButtonX SignUpBtn;
        private DevComponents.DotNetBar.ButtonX SignInBtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
    }
}