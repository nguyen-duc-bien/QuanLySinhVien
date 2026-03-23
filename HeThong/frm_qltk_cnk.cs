using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL1.quanlytaikhoan
{
    public partial class frm_qltk_cnk : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection con;

        public frm_qltk_cnk()
        {
            InitializeComponent();
        }

        private void frm_qltk_cnk_Load(object sender, EventArgs e)
        {
           
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txttdn.Text == "" || txtmk.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sqlCheck = "SELECT COUNT(*) FROM taikhoan WHERE TenDangNhap = @tk";
            SqlCommand cmdCheck = new SqlCommand(sqlCheck, con);
            cmdCheck.Parameters.AddWithValue("@tk", txttdn.Text);
            int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show("Tài khoản đã tồn tại. Vui lòng chọn tên khác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttdn.Text = "";
                txtmk.Text = "";
                txttdn.Focus();
            }
            else
            {
                string sqlInsert = "INSERT INTO taikhoan (TenDangNhap, MatKhau) VALUES (@tk, @mk)";
                SqlCommand cmdInsert = new SqlCommand(sqlInsert, con);
                cmdInsert.Parameters.AddWithValue("@tk", txttdn.Text);
                cmdInsert.Parameters.AddWithValue("@mk", txtmk.Text);
                cmdInsert.ExecuteNonQuery();

                MessageBox.Show("Đăng ký thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttdn.Text = "";
                txtmk.Text = "";
                txttdn.Focus();
                frm_qltk_cnk_Load(sender, e);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txttdn.Text == "" || txtmk.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập và Mật khẩu cần sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sqlUpdate = "UPDATE taikhoan SET MatKhau = @mk WHERE TenDangNhap = @tk";
            SqlCommand cmd = new SqlCommand(sqlUpdate, con);
            cmd.Parameters.AddWithValue("@mk", txtmk.Text);
            cmd.Parameters.AddWithValue("@tk", txttdn.Text);

            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                MessageBox.Show("Sửa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Không tìm thấy tài khoản để sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            txttdn.Text = "";
            txtmk.Text = "";
            txttdn.Focus();
            frm_qltk_cnk_Load(sender, e);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txttdn.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sqlDelete = "DELETE FROM taikhoan WHERE TenDangNhap = @tk";
                SqlCommand cmd = new SqlCommand(sqlDelete, con);
                cmd.Parameters.AddWithValue("@tk", txttdn.Text);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Không tìm thấy tài khoản để xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txttdn.Text = "";
                txtmk.Text = "";
                txttdn.Focus();
                frm_qltk_cnk_Load(sender, e);
            }
        }

        private void btnnhaplai_Click(object sender, EventArgs e)
        {
            txttdn.Text = "";
            txtmk.Text = "";
            txttdn.Focus();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvtruongkhoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txttdn.Text = dgvtruongkhoa.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtmk.Text = dgvtruongkhoa.Rows[e.RowIndex].Cells[1].Value.ToString();

               
               
            }
        }

        private void dgvtruongkhoa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvtruongkhoa.Columns[e.ColumnIndex].HeaderText == "Mật Khẩu" && e.RowIndex >= 0)
            {
                string pass = dgvtruongkhoa.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                e.Value = new string('*', pass.Length);
            }
        }

        private void btndong_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_qltk_cnk_Load_1(object sender, EventArgs e)
        {
            try
            {
                txttdn.Select();
                this.ActiveControl = txttdn;
                txttdn.Focus();

                con = new SqlConnection();
                con.ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";
                con.Open();

                string sqlGV = "SELECT * FROM giangvien WHERE ChucVu = 'Chủ nhiệm khoa'";
                SqlDataAdapter daGV = new SqlDataAdapter(sqlGV, con);
                DataTable dtGV = new DataTable();
                daGV.Fill(dtGV);

                string sql = @"
            SELECT tk.TenDangNhap, tk.MatKhau,
                   gv.HoTen, gv.GioiTinh, gv.NgaySinh, gv.SDT, gv.Email, gv.QueQuan
            FROM taikhoan tk
            JOIN giangvien gv ON tk.TenDangNhap = gv.MaGV
            WHERE gv.ChucVu = 'Chủ nhiệm khoa'";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvtruongkhoa.CellFormatting -= dgvtruongkhoa_CellFormatting;
                dgvtruongkhoa.DataSource = dt;
                dgvtruongkhoa.CellFormatting += dgvtruongkhoa_CellFormatting;

                // Gán tên cột
                if (dgvtruongkhoa.Columns.Count >= 8)
                {
                    dgvtruongkhoa.Columns[0].HeaderText = "Tài Khoản/Mã GV";
                    dgvtruongkhoa.Columns[1].HeaderText = "Mật Khẩu";
                    dgvtruongkhoa.Columns[2].HeaderText = "Tên CNK";
                    dgvtruongkhoa.Columns[3].HeaderText = "Giới Tính";
                    dgvtruongkhoa.Columns[4].HeaderText = "Ngày Sinh";
                    dgvtruongkhoa.Columns[5].HeaderText = "SĐT";
                    dgvtruongkhoa.Columns[6].HeaderText = "Email";
                    dgvtruongkhoa.Columns[7].HeaderText = "Quê Quán";
                }

                foreach (DataGridViewColumn col in dgvtruongkhoa.Columns)
                    col.Width = 150;

                dgvtruongkhoa.AllowUserToAddRows = false;
                dgvtruongkhoa.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }
    }
}
