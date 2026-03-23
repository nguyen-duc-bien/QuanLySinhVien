
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL1.thongtin
{
    public partial class frm_tt_gv : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sqlcon;
        public frm_tt_gv()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frm_tt_gv_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection();
            sqlcon.ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";
            sqlcon.Open();
            string sql = "Select * from giangvien";
            SqlDataAdapter sqldt = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            sqldt.Fill(dt);
            sqldt.Fill(ds);
            dgvgv.DataSource = dt;
            dgvgv.Columns[0].HeaderText = "Tài Khoản";
            dgvgv.Columns[1].HeaderText = "Mật Khẩu";
            dgvgv.Columns[2].HeaderText = "Tên GV";
            dgvgv.Columns[3].HeaderText = "Giới Tính";
            dgvgv.Columns[4].HeaderText = "Ngày Sinh";
            dgvgv.Columns[5].HeaderText = "SĐT";
            dgvgv.Columns[6].HeaderText = "Email";
            dgvgv.Columns[7].HeaderText = "Địa Chỉ";

            foreach (DataGridViewColumn col in dgvgv.Columns)
                col.Width = 150;
            dgvgv.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvgv.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMagv.Text = dgvgv.CurrentRow.Cells[0].Value.ToString();
            txtTengv.Text = dgvgv.CurrentRow.Cells[2].Value.ToString();
            cbGt.Text = dgvgv.CurrentRow.Cells[4].Value.ToString();
            txtns.Text = dgvgv.CurrentRow.Cells[3].Value.ToString();
            txtSdt.Text = dgvgv.CurrentRow.Cells[6].Value.ToString();
           txtDc.Text = dgvgv.CurrentRow.Cells[5].Value.ToString();
            txtmm.Text = dgvgv.CurrentRow.Cells[1].Value.ToString();
            txtemail.Text = dgvgv.CurrentRow.Cells[7].Value.ToString();
        }

        private void btĐóng_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbGt_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtMagv_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtns_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtTengv_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
