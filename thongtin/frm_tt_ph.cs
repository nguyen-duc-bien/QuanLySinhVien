using Microsoft.Data.SqlTypes;
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

namespace BTL_.NET.thongtin
{
    public partial class frm_tt_ph : Form
    {
        SqlConnection sqlcon;
        public frm_tt_ph()
        {
            InitializeComponent();
        }
        private void frm_tt_ph_Load(object sender, EventArgs e)
        {

            sqlcon = new SqlConnection();
            sqlcon.ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";
            sqlcon.Open();
            string sql = "SELECT * FROM phuhuynh WHERE MaPH = @TenDangNhap or MaSV = @TenDangNhap" ;
            SqlDataAdapter sqldt = new SqlDataAdapter(sql, sqlcon);
            sqldt.SelectCommand.Parameters.AddWithValue("@TenDangNhap", UserSession.TenDangNhap);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            sqldt.Fill(dt);
            sqldt.Fill(ds);
            dgvsv.DataSource = dt;
            dgvsv.Columns[7].HeaderText = "Mã Phụ Huynh";
            dgvsv.Columns[0].HeaderText = "Mã Sinh Viên";
            dgvsv.Columns[1].HeaderText = "Họ Tên";
            dgvsv.Columns[4].HeaderText = "Số Điện Thoại";

            dgvsv.Columns[0].Width = 200;
            dgvsv.Columns[1].Width = 200;
            dgvsv.Columns[2].Width = 200;
            dgvsv.Columns[3].Width = 200;

            dgvsv.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvsv.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void btĐóng_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_tt_ph_Load_1(object sender, EventArgs e)
        {

        }
    }
}
