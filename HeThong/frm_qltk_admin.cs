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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTL1.quanlytaikhoan
{
    public partial class frm_qltk_admin : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection con;
        
        public frm_qltk_admin()
        {
            InitializeComponent();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txttdn.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập!!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtmk.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string sql = "SELECT COUNT(*) FROM taikhoan WHERE TenDangNhap = @tdn";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@tdn", txttdn.Text);
                int i = Convert.ToInt32(cmd.ExecuteScalar());

                if (i != 0)
                {
                    MessageBox.Show("Tài khoản đã tồn tại! Vui lòng chọn tên khác.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txttdn.Text = "";
                    txtmk.Text = "";
                }
                else
                {
                    string sql2 = "INSERT INTO taikhoan VALUES (@tdn, @mk, 'Admin')";
                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    cmd2.Parameters.AddWithValue("@tdn", txttdn.Text);
                    cmd2.Parameters.AddWithValue("@mk", txtmk.Text);
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Thêm tài khoản thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txttdn.Text = "";
                    txtmk.Text = "";
                    frm_qltk_admin_Load(sender, e);
                }
            }
        }
        private void frm_qltk_admin_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            this.ActiveControl = txttdn;
            txttdn.Focus();

            con = new SqlConnection();
            con.ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();

            string sql = "SELECT * FROM taikhoan WHERE VaiTro = 'Admin'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            dgvadmin.CellFormatting -= dgvadmin_CellFormatting;
            dgvadmin.DataSource = dt;
            dgvadmin.Columns[0].HeaderText = "Tài Khoản";
            dgvadmin.Columns[1].HeaderText = "Mật Khẩu";
            dgvadmin.Columns[2].HeaderText = "Vai Trò";

            dgvadmin.Columns[0].Width = 200;
            dgvadmin.Columns[1].Width = 200;
            dgvadmin.Columns[2].Width = 200;

            dgvadmin.AllowUserToAddRows = false;
            dgvadmin.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvadmin.CellFormatting += dgvadmin_CellFormatting;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txttdn.Text == "" || txtmk.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql = "UPDATE taikhoan SET MatKhau = @mk WHERE TenDangNhap = @tdn";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mk", txtmk.Text);
            cmd.Parameters.AddWithValue("@tdn", txttdn.Text);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txttdn.Text = "";
            txtmk.Text = "";
            frm_qltk_admin_Load(sender, e);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txttdn.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = "DELETE FROM taikhoan WHERE TenDangNhap = @tdn";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@tdn", txttdn.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Lỗi khi xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txttdn.Text = "";
                txtmk.Text = "";
                frm_qltk_admin_Load(sender, e);
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
        private void dgvadmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txttdn.Text = dgvadmin.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtmk.Text = dgvadmin.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }


        private void dgvadmin_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvadmin.Columns[e.ColumnIndex].HeaderText == "Mật Khẩu" && e.RowIndex >= 0)
            {
                string pass = dgvadmin.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                e.Value = new string('*', pass.Length);
            }
        }

    }
}
