using BTL.Log_Sig;

using BTL_.NET.Log_Sig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_.NET
{
    public partial class Trangchu :Form
    {
        public Trangchu()
        {
            InitializeComponent();
        }

        private void Trangchu_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label2.Left <= this.Width)
            {
                label2.Left += 10;
            }
            else
            {
                label2.Left = -label2.Width;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            FrmDangNhap frmDangNhap = new FrmDangNhap();
            frmDangNhap.Show();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            FrmDangKy frmDangKy = new FrmDangKy();
            frmDangKy.Show();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FrmDangKy frmDangKy = new FrmDangKy();
            frmDangKy.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormGiaoVien f1   = new FormGiaoVien();
            f1.Show();
        }
    }
}
