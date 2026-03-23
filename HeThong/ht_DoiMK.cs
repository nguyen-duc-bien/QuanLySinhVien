using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_.NET.HeThong
{
    public partial class ht_DoiMK : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection con;

        public string VaiTro = "";
        public string tentaikhoan = "";
        public string HoTen = "";

        // Biến lưu quyền, tên tài khoản, tên người dùng
        public string Quyen { get; private set; }
        public string tenDangNhap { get; private set; }
        public string HoTenNguoiDung { get; private set; }

        public ht_DoiMK(string VaiTro)
        {
            InitializeComponent();
            this.VaiTro = VaiTro;
        }

        private void ht_DoiMK_Load(object sender, EventArgs e)
        {
            txttk.Select();
            this.ActiveControl = txttk;
            txttk.Focus();

            string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";
            con = new SqlConnection(connectionString);
            con.Open();

            // Gán tên đăng nhập từ UserSession (giả định bạn đã có class UserSession)
            txttk.Text = UserSession.TenDangNhap;
            txttk.Enabled = false;

            // Lấy VaiTro và HoTen người dùng
            string tenDN = UserSession.TenDangNhap;
            string vaiTro = "";
            string hoTen = "";

            // Lấy vai trò từ bảng taikhoan
            string sqlTK = "SELECT VaiTro FROM taikhoan WHERE TenDangNhap = @tdn";
            using (SqlCommand cmd = new SqlCommand(sqlTK, con))
            {
                cmd.Parameters.AddWithValue("@tdn", tenDN);
                object result = cmd.ExecuteScalar();
                if (result != null)
                    vaiTro = result.ToString();
            }

            // Lấy Họ tên từ 3 bảng
            string sqlHoTen = @"
                SELECT HoTen FROM SinhVien WHERE MaSV = @tdn
                UNION
                SELECT HoTen FROM GiangVien WHERE MaGV = @tdn
                UNION
                SELECT HoTen FROM PhuHuynh WHERE MaPH = @tdn";
            using (SqlCommand cmdHoTen = new SqlCommand(sqlHoTen, con))
            {
                cmdHoTen.Parameters.AddWithValue("@tdn", tenDN);
                object hoTenObj = cmdHoTen.ExecuteScalar();
                if (hoTenObj != null)
                    hoTen = hoTenObj.ToString();
            }

            Quyen = vaiTro;
            tenDangNhap = tenDN;
            HoTenNguoiDung = hoTen;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (con == null)
            {
                string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";
                con = new SqlConnection(connectionString);
            }
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            if (string.IsNullOrWhiteSpace(txtmk.Text) || string.IsNullOrWhiteSpace(txtmkmoi.Text) || string.IsNullOrWhiteSpace(txtmknl.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các trường mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtmkmoi.Text != txtmknl.Text)
            {
                MessageBox.Show("Mật khẩu mới và mật khẩu xác nhận không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Kiểm tra mật khẩu cũ
            string sqlCheck = @"
    SELECT COUNT(*) 
    FROM taikhoan 
    WHERE LTRIM(RTRIM(TenDangNhap)) = @tdn AND LTRIM(RTRIM(MatKhau)) = @mkcu";
            using (SqlCommand cmdCheck = new SqlCommand(sqlCheck, con))
            {
                cmdCheck.Parameters.AddWithValue("@tdn", txttk.Text.Trim());
                cmdCheck.Parameters.AddWithValue("@mkcu", txtmk.Text.Trim());

                int count = Convert.ToInt32(cmdCheck.ExecuteScalar());

                if (count == 1)
                {
                    // Thực hiện đổi mật khẩu
                    string sqlUpdate = "UPDATE taikhoan SET MatKhau = @mkmoi WHERE TenDangNhap = @tdn";
                    using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, con))
                    {
                        cmdUpdate.Parameters.AddWithValue("@mkmoi", txtmkmoi.Text.Trim());
                        cmdUpdate.Parameters.AddWithValue("@tdn", txttk.Text.Trim());

                        try
                        {
                            cmdUpdate.ExecuteNonQuery();
                            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi đổi mật khẩu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng hoặc tài khoản không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            // Xoá nội dung các ô nhập
            txtmk.Clear();
            txtmkmoi.Clear();
            txtmknl.Clear();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            if (con != null && con.State == ConnectionState.Open)
                con.Close();
            this.Close();
        }

        private void txttk_TextChanged(object sender, EventArgs e)
        {
            // Có thể xử lý sau nếu cần
        }
    }
}
