
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
    public partial class frm_tt_monhoc : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sqlcon;
        public frm_tt_monhoc()
        {
            InitializeComponent();
        }

        private void frm_tt_monhoc_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection();
            sqlcon.ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";
            sqlcon.Open();
            string sql = "Select * from monhoc";
            SqlDataAdapter sqldt = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            sqldt.Fill(dt);
            sqldt.Fill(ds);
            dgvmh.DataSource = dt;
            dgvmh.Columns[0].HeaderText = "Mã Môn Học";
            dgvmh.Columns[1].HeaderText = "Mã Giáo Viên";
            dgvmh.Columns[2].HeaderText = "Tên Môn Học";
            dgvmh.Columns[3].HeaderText = "Số Tín Chỉ";
            
           

            dgvmh.Columns[0].Width = 200;
            dgvmh.Columns[1].Width = 200;
            dgvmh.Columns[2].Width = 200;
            dgvmh.Columns[3].Width = 200;
           

            dgvmh.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvmh.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvmh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMamh.Text = dgvmh.CurrentRow.Cells[0].Value.ToString();
            txtTenmh.Text = dgvmh.CurrentRow.Cells[1].Value.ToString();
            txtSotiet.Text = dgvmh.CurrentRow.Cells[2].Value.ToString();
            txtMagv.Text = dgvmh.CurrentRow.Cells[3].Value.ToString();
        }

        private void btĐóng_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
