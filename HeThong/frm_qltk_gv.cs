using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL1.quanlytaikhoan
{
    public partial class frm_qltk_gv : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection con;

        public frm_qltk_gv()
        {
            InitializeComponent();
        }

        private void frm_qltk_gv_Load(object sender, EventArgs e)
        {
            txttk.Select();
            this.ActiveControl = txttk;
            txttk.Focus();

            con = new SqlConnection();
            con.ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();

            // Load giảng viên vào ComboBox
            string sqlGV = "SELECT * FROM giangvien";
            SqlDataAdapter daGV = new SqlDataAdapter(sqlGV, con);
            DataTable dtGV = new DataTable();
            daGV.Fill(dtGV);


           
            // JOIN taikhoan với giangvien
            string sql = @"
                SELECT tk.TenDangNhap, tk.MatKhau,
                       gv.HoTen, gv.GioiTinh, gv.NgaySinh, gv.SDT, gv.Email, gv.QueQuan
                FROM taikhoan tk
                JOIN giangvien gv ON tk.TenDangNhap = gv.MaGV";

            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvgv.CellFormatting -= dgvgv_CellFormatting;
            dgvgv.DataSource = dt;
            dgvgv.CellFormatting += dgvgv_CellFormatting;

            dgvgv.Columns[0].HeaderText = "Tài Khoản/Mã Giảng viên";
            dgvgv.Columns[1].HeaderText = "Mật Khẩu";
            dgvgv.Columns[2].HeaderText = "Tên Giảng Viên";
            dgvgv.Columns[3].HeaderText = "Giới Tính";
            dgvgv.Columns[4].HeaderText = "Ngày Sinh";
            dgvgv.Columns[5].HeaderText = "SĐT";
            dgvgv.Columns[6].HeaderText = "Email";
            dgvgv.Columns[7].HeaderText = "Quê Quán";

            foreach (DataGridViewColumn col in dgvgv.Columns)
                col.Width = 150;

            dgvgv.AllowUserToAddRows = false;
            dgvgv.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txttk.Text == "" || txtmk.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sqlCheck = "SELECT COUNT(*) FROM taikhoan WHERE TenDangNhap = @tk";
            SqlCommand cmdCheck = new SqlCommand(sqlCheck, con);
            cmdCheck.Parameters.AddWithValue("@tk", txttk.Text);
            int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show("Tài khoản đã tồn tại. Vui lòng chọn tên khác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttk.Text = "";
                txtmk.Text = "";
                txttk.Focus();
            }
            else
            {
                string sqlInsert = "INSERT INTO taikhoan (TenDangNhap, MatKhau) VALUES (@tk, @mk)";
                SqlCommand cmdInsert = new SqlCommand(sqlInsert, con);
                cmdInsert.Parameters.AddWithValue("@tk", txttk.Text);
                cmdInsert.Parameters.AddWithValue("@mk", txtmk.Text);
                cmdInsert.ExecuteNonQuery();

                MessageBox.Show("Đăng ký thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttk.Text = "";
                txtmk.Text = "";
                txttk.Focus();
                frm_qltk_gv_Load(sender, e);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txttk.Text == "" || txtmk.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập và Mật khẩu cần sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sqlUpdate = "UPDATE taikhoan SET MatKhau = @mk WHERE TenDangNhap = @tk";
            SqlCommand cmd = new SqlCommand(sqlUpdate, con);
            cmd.Parameters.AddWithValue("@mk", txtmk.Text);
            cmd.Parameters.AddWithValue("@tk", txttk.Text);

            int rows = cmd.ExecuteNonQuery();
            if (rows > 0)
                MessageBox.Show("Sửa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Không tìm thấy tài khoản để sửa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            txttk.Text = "";
            txtmk.Text = "";
            txttk.Focus();
            frm_qltk_gv_Load(sender, e);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txttk.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập cần xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sqlDelete = "DELETE FROM taikhoan WHERE TenDangNhap = @tk";
                SqlCommand cmd = new SqlCommand(sqlDelete, con);
                cmd.Parameters.AddWithValue("@tk", txttk.Text);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Không tìm thấy tài khoản để xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txttk.Text = "";
                txtmk.Text = "";
                txttk.Focus();
                frm_qltk_gv_Load(sender, e);
            }
        }

        private void btnnhaplai_Click(object sender, EventArgs e)
        {
            txttk.Text = "";
            txtmk.Text = "";
            txttk.Focus();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvgv.Columns[e.ColumnIndex].HeaderText == "Mật Khẩu" && e.RowIndex >= 0)
            {
                string pass = dgvgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                e.Value = new string('*', pass.Length);
            }
        }

        private void dgvgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txttk.Text = dgvgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtmk.Text = dgvgv.Rows[e.RowIndex].Cells[1].Value.ToString();

                if (dgvgv.SelectedRows.Count > 0)
                {
               
                }
            }
        }
    }
}
