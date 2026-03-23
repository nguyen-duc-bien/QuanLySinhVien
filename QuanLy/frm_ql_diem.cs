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
    public partial class frm_ql_diem : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sqlcon;

        public frm_ql_diem()
        {
            InitializeComponent();
        }

        public void ketnoi()
        {
            sqlcon = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30");
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
        }

        public void load_DL(string sql)
        {
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            dgdiem.DataSource = dt;

            dgdiem.Columns[0].HeaderText = "Mã Sinh Viên";
            dgdiem.Columns[1].HeaderText = "Mã Môn Học";
            dgdiem.Columns[2].HeaderText = "Tên Môn";

            dgdiem.Columns[3].HeaderText = "Điểm";

            dgdiem.Columns[0].Width = 200;
            dgdiem.Columns[1].Width = 200;
            dgdiem.Columns[2].Width = 200;
            dgdiem.Columns[3].Width = 200;
            dgdiem.AllowUserToAddRows = false;
            dgdiem.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void reset()
        {
            txtDiem.Clear();
            txttmh.Clear();
            txtmmh.Clear();
            txtmsv.Clear();
            txtmmh.Focus();
        }

        private void frm_ql_diem_Load(object sender, EventArgs e)
        {
            txtmmh.Focus();
            ketnoi();

            // Load bảng điểm kèm tên môn học
            string sql = @"
                SELECT d.MaSV, d.MaMon, m.TenMonHoc, d.Diem
                FROM diem d
                JOIN monhoc m ON d.MaMon = m.MaMon
            ";
            load_DL(sql);

            // Load danh sách sinh viên
            string sql1 = "SELECT MaSV, HoTen FROM sinhvien";
            SqlDataAdapter da = new SqlDataAdapter(sql1, sqlcon);
            DataTable dt = new DataTable();
            da.Fill(dt);
           

            // Load danh sách môn học
            string sql2 = "SELECT MaMon, TenMonHoc FROM monhoc";
            SqlDataAdapter da1 = new SqlDataAdapter(sql2, sqlcon);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtDiem.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiem.Focus();
                return;
            }

            try
            {
                ketnoi();

                string checkSql = "SELECT COUNT(*) FROM diem WHERE MaSV=@MaSV AND MaMon =@mamh";
                SqlCommand checkCmd = new SqlCommand(checkSql, sqlcon);
                checkCmd.Parameters.AddWithValue("@MaSV", txtmsv.Text);
                checkCmd.Parameters.AddWithValue("@mamh", txtmmh.Text);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Sinh viên đã có điểm cho môn học này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string insertSql = "INSERT INTO diem (MaSV, MaMon, Diem) VALUES (@MaSV, @mamh, @diem)";
                SqlCommand cmd = new SqlCommand(insertSql, sqlcon);
                cmd.Parameters.AddWithValue("@MaSV", txtmmh.Text);
                cmd.Parameters.AddWithValue("@mamh", txttmh.Text);
                cmd.Parameters.AddWithValue("@diem", txtDiem.Text);
                cmd.ExecuteNonQuery();

                frm_ql_diem_Load(sender, e);
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
                sqlcon.Close();
            }
            catch
            {
                MessageBox.Show("Thêm không thành công! Mời thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reset();
            }
        }

        private void dgdiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LayDuLieuHang(e.RowIndex);
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa điểm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ketnoi();
                    string updateSql = "UPDATE diem SET Diem=@diem WHERE MaSV=@MaSV AND MaMon=@mamh";
                    SqlCommand cmd = new SqlCommand(updateSql, sqlcon);
                    cmd.Parameters.AddWithValue("@MaSV", txtmsv.Text);
                    cmd.Parameters.AddWithValue("@mamh", txtmmh.Text);
                    cmd.Parameters.AddWithValue("@diem", txtDiem.Text);
                    cmd.ExecuteNonQuery();

                    frm_ql_diem_Load(sender, e);
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    sqlcon.Close();
                }
                catch
                {
                    MessageBox.Show("Sửa không thành công! Mời thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reset();
                }
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa điểm?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ketnoi();
                    string deleteSql = "DELETE FROM diem WHERE MaSV=@MaSV AND MaMon=@mamh";
                    SqlCommand cmd = new SqlCommand(deleteSql, sqlcon);
                    cmd.Parameters.AddWithValue("@MaSV", txtmmh.Text);
                    cmd.Parameters.AddWithValue("@mamh", txttmh.Text);
                    cmd.ExecuteNonQuery();

                    frm_ql_diem_Load(sender, e);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    sqlcon.Close();
                }
                catch
                {
                    MessageBox.Show("Xóa không thành công! Mời thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reset();
                }
            }
        }

        public void LayDuLieuHang(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dgdiem.Rows.Count)
            {
                var row = dgdiem.Rows[rowIndex];
                // Lấy dữ liệu từng cột của hàng
                string maSV = row.Cells[0].Value?.ToString();
                string maMon = row.Cells[1].Value?.ToString();
                string tenMon = row.Cells[2].Value?.ToString();
                string diem = row.Cells[3].Value?.ToString();
                txtmsv.Text = maSV;
                txtmmh.Text = maMon;
                txtDiem.Text = diem;
                txttmh.Text = tenMon;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbommh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
