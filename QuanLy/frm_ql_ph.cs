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

namespace BTL_.NET.QuanLy
{
    public partial class frm_ql_ph : Form
    {
        SqlConnection sqlcon;

        public void ketnoi()
        {
            if (sqlcon == null)
            {
                string connStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";
                sqlcon = new SqlConnection(connStr);
            }
            if (sqlcon.State != ConnectionState.Open)
            {
                sqlcon.Open();
            }
        }

        public frm_ql_ph()
        {
            InitializeComponent();
        }

        public void load_DL(string sql)
        {
            try
            {
                ketnoi();
                SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    dgmh.DataSource = ds.Tables[0];
                    dgmh.Columns[0].HeaderText = "Mã Phụ Huynh";
                    dgmh.Columns[1].HeaderText = "Mã Sinh Viên";
                    dgmh.Columns[2].HeaderText = "Họ Tên";
                    dgmh.Columns[3].HeaderText = "SDT";

                    dgmh.Columns[0].Width = 200;
                    dgmh.Columns[1].Width = 200;
                    dgmh.Columns[2].Width = 200;
                    dgmh.Columns[3].Width = 200;

                    dgmh.AllowUserToAddRows = false;
                    dgmh.EditMode = DataGridViewEditMode.EditProgrammatically;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                if (sqlcon != null && sqlcon.State == ConnectionState.Open)
                    sqlcon.Close();
            }
        }

        public void reset()
        {
            txtMamh.ReadOnly = false;
            txtMamh.Clear();
            txtTenmh.Clear();
            txtSotiet.Clear();
            txtmagv.Clear();
            txtMamh.Focus();
        }

        private void btnnhaplai_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtMamh.Text == "" || txtTenmh.Text == "" || txtSotiet.Text == "" || txtmagv.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu! Hãy nhập đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                ketnoi();
                string str = "SELECT COUNT(*) FROM PhuHuynh WHERE MaPH = @MaMH";
                SqlCommand sqlcom = new SqlCommand(str, sqlcon);
                sqlcom.Parameters.AddWithValue("@MaMH", txtMamh.Text);
                int i = (int)sqlcom.ExecuteScalar();
                sqlcom.Dispose();

                if (i != 0)
                {
                    MessageBox.Show("Trùng mã! Mời nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMamh.Focus();
                }
                else
                {
                    string sql = "INSERT INTO phuhuynh VALUES (@MaMH, @MaSV, @tenPH, @sdt)";
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    cmd.Parameters.AddWithValue("@MaMH", txtMamh.Text);
                    cmd.Parameters.AddWithValue("@MaSV", txtmagv.Text);
                    cmd.Parameters.AddWithValue("@tenPH", txtTenmh.Text);
                    cmd.Parameters.AddWithValue("@sdt", txtSotiet.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_ql_ph_Load(sender, e);
                    reset();
                }// Thêm tài khoản cho phụ huynh
                try
                {
                    string sqlTaiKhoan = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, VaiTro) VALUES (@tendn, @matkhau, @vaitro)";
                    SqlCommand cmdTaiKhoan = new SqlCommand(sqlTaiKhoan, sqlcon);
                    cmdTaiKhoan.Parameters.AddWithValue("@tendn", txtMamh.Text); // MaPH làm TenDangNhap
                    cmdTaiKhoan.Parameters.AddWithValue("@matkhau", "1");        // Mật khẩu mặc định
                    cmdTaiKhoan.Parameters.AddWithValue("@vaitro", "PhuHuynh");  // Vai trò
                    cmdTaiKhoan.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tạo tài khoản thất bại! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm không thành công! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlcon != null && sqlcon.State == ConnectionState.Open)
                    sqlcon.Close();
            }
        }

        private void frm_ql_ph_Load(object sender, EventArgs e)
        {
            txtMamh.Select();
            this.ActiveControl = txtMamh;
            txtMamh.Focus();

            string sql = "SELECT * FROM phuhuynh";
            load_DL(sql);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ketnoi();
                    string sql = "DELETE FROM phuhuynh WHERE MaPH = @MaMH";
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    cmd.Parameters.AddWithValue("@MaMH", txtMamh.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_ql_ph_Load(sender, e);
                    reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa không thành công! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reset();
                }
                finally
                {
                    if (sqlcon != null && sqlcon.State == ConnectionState.Open)
                        sqlcon.Close();
                }
            }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgmh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không click tiêu đề cột
            {
                DataGridViewRow row = dgmh.Rows[e.RowIndex];

                txtMamh.Text = row.Cells[0].Value?.ToString();
                txtTenmh.Text = row.Cells[2].Value?.ToString();
                txtSotiet.Text = row.Cells[3].Value?.ToString();
                txtmagv.Text = row.Cells[1].Value?.ToString();

            }
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtMamh.Text == "" || txtTenmh.Text == "" || txtSotiet.Text == "" || txtmagv.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu! Hãy nhập đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                ketnoi();
                string sql = "UPDATE phuhuynh SET MaSV = @MaSV, HoTen = @HoTen, SDT = @SDT WHERE MaPH = @MaPH";
                SqlCommand cmd = new SqlCommand(sql, sqlcon);
                cmd.Parameters.AddWithValue("@MaPH", txtMamh.Text);
                cmd.Parameters.AddWithValue("@MaSV", txtmagv.Text);
                cmd.Parameters.AddWithValue("@HoTen", txtTenmh.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSotiet.Text);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_ql_ph_Load(sender, e);
                    reset();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bản ghi để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa không thành công! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlcon != null && sqlcon.State == ConnectionState.Open)
                    sqlcon.Close();
            }
        }

    }
}
