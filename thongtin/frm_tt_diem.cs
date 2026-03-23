
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
using BTL.FormChinh;
namespace BTL1.thongtin
{
    public partial class frm_tt_diem : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sqlcon;
        public frm_tt_diem()
        {
            InitializeComponent();
        }

        public string masv,hoten;

        public frm_tt_diem(string masv,string hoten)
        {
            InitializeComponent();
            this.masv = masv;
            this.hoten = hoten;
        }

        private void frm_tt_diem_Load(object sender, EventArgs e)
        {
            // Fix for CS0120: Create an instance of frmformchinh to access the non-static method getTenDN()
            frmformchinh formChinhInstance = new frmformchinh("SinhVien", masv, hoten);
            masv = formChinhInstance.getTenDN();
            sqlcon = new SqlConnection();
            sqlcon.ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";
            sqlcon.Open();
            // Sử dụng parameter để tránh lỗi và bảo mật hơn
            string sql = "SELECT * FROM diem WHERE MaSV = @MaSV OR MaSV IN (SELECT MaSV FROM sinhvien WHERE MaPH = @MaPH )";
            SqlDataAdapter sqldt = new SqlDataAdapter(sql, sqlcon);
            sqldt.SelectCommand.Parameters.AddWithValue("@MaSV", masv);
            sqldt.SelectCommand.Parameters.AddWithValue("@MaPH", masv);
            DataTable dt = new DataTable();
            sqldt.Fill(dt);
            DataSet ds = new DataSet();
            sqldt.Fill(ds);
            dgvdiem.DataSource = dt;

            dgvdiem.Columns[0].HeaderText = "Mã Sinh Viên";
            dgvdiem.Columns[1].HeaderText = "Mã Môn Học";
            dgvdiem.Columns[2].HeaderText = "Điểm";

            dgvdiem.Columns[0].Width = 200;
            dgvdiem.Columns[1].Width = 200;
            dgvdiem.Columns[2].Width = 200;

            dgvdiem.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvdiem.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

  

        private void dgvdiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMasv.Text = dgvdiem.CurrentRow.Cells[0].Value.ToString();
            txtMamh.Text = dgvdiem.CurrentRow.Cells[1].Value.ToString();
            txtDiem.Text = dgvdiem.CurrentRow.Cells[2].Value.ToString();
        }

        private void btĐóng_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

