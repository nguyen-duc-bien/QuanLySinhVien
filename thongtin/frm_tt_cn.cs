using BTL_.NET;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL1.thongtin
{
    public partial class frm_tt_cn : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sqlcon;
        public string masv = "", hoten = "", stpd = "", stdd = "", tt = "", cn = "";

        public frm_tt_cn()
        {
            InitializeComponent();
            button1.Visible = false; // Ẩn nút mặc định
        }

        private void frm_tt_cn_Load(object sender, EventArgs e)
        {
            string tenDangNhap = UserSession.TenDangNhap;
            string connStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";

            try
            {
                using (sqlcon = new SqlConnection(connStr))
                {
                    sqlcon.Open();

                    // 1. Lấy vai trò
                    string vaiTro = "";
                    using (SqlCommand cmd = new SqlCommand("SELECT VaiTro FROM taikhoan WHERE TenDangNhap = @tk", sqlcon))
                    {
                        cmd.Parameters.AddWithValue("@tk", tenDangNhap);
                        object result = cmd.ExecuteScalar();
                        vaiTro = result?.ToString();
                    }

                    // 2. Lấy mã sinh viên
                    if (vaiTro == "SinhVien")
                    {
                        masv = tenDangNhap;
                    }
                    else if (vaiTro == "PhuHuynh")
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT MaSV FROM sinhvien WHERE MaPH = @MaPH", sqlcon))
                        {
                            cmd.Parameters.AddWithValue("@MaPH", tenDangNhap);
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                                masv = result.ToString();
                            else
                            {
                                MessageBox.Show("Không tìm thấy sinh viên cho phụ huynh này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chức năng này chỉ dành cho Sinh viên hoặc Phụ huynh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 3. Truy vấn học phí
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM hocphi WHERE MaSV = @MaSV", sqlcon))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", masv);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cn = reader["CongNo"].ToString();
                                stpd = reader["SoTienPhaiDong"].ToString();
                                stdd = reader["SoTienDaDong"].ToString();
                                tt = reader["TrangThai"].ToString();

                                decimal soTienPhaiDong = 0;
                                decimal.TryParse(stpd, out soTienPhaiDong);

                                textBox1.Text = cn;
                                textBox2.Text = stdd;
                                textBox3.Text = stpd;
                                textBox4.Text = masv;

                                if (soTienPhaiDong == 0)
                                {
                                    textBox1.Text = "0"; // Công nợ
                                    textBox5.Text = "Không có công nợ";
                                    button1.Visible = false;
                                }
                                else
                                {
                                    textBox5.Text = tt;
                                    if (tt.Trim().Equals("Đã đóng", StringComparison.OrdinalIgnoreCase))
                                        button1.Visible = false;
                                    else
                                        button1.Visible = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy học phí của sinh viên này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu học phí: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn nộp học phí?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                string connStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";

                try
                {
                    using (sqlcon = new SqlConnection(connStr))
                    {
                        sqlcon.Open();

                        decimal soTienPhaiDong = 0;
                        if (!decimal.TryParse(textBox3.Text, out soTienPhaiDong))
                        {
                            MessageBox.Show("Số tiền phải đóng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string updateQuery = @"
                        UPDATE hocphi 
                        SET SoTienDaDong = @SoTienPhaiDong, 
                            CongNo = 0, 
                            TrangThai = N'Đã đóng' 
                        WHERE MaSV = @MaSV";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, sqlcon))
                        {
                            cmd.Parameters.AddWithValue("@MaSV", masv);
                            cmd.Parameters.AddWithValue("@SoTienPhaiDong", soTienPhaiDong);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Nộp học phí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                textBox2.Text = textBox3.Text; // SoTienDaDong = SoTienPhaiDong
                                textBox1.Text = "0";           // CongNo = 0
                                textBox5.Text = "Đã đóng";     // TrangThai
                                button1.Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("Không thể cập nhật học phí!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật học phí: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // Không cần xử lý
        }
    }
}
