using Microsoft.Data.SqlTypes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_.NET
{
    public partial class Form2 : Form
    {
        SqlConnection con;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();

            con.ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";

            LoadMonHocChuaDangKy();
        }

        private void LoadMonHocChuaDangKy()
        {
            try
            {
                con.Open();
                string masv = UserSession.TenDangNhap;

                string sql = @"
                    SELECT mh.MaMon,mh.MaGV, mh.TenMonHoc, mh.SoTinChi
                    FROM monhoc mh
                    WHERE mh.MaMon NOT IN (
                        SELECT MaMon FROM diem WHERE MaSV = @MaSV
                    )";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaSV", masv);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvMonChuaDK.DataSource = dt;
                dgvMonChuaDK.Columns[0].HeaderText = "Mã môn";
                dgvMonChuaDK.Columns[1].Name = "Mã GV";
                dgvMonChuaDK.Columns[2].HeaderText = "Tên môn";
                dgvMonChuaDK.Columns[3].HeaderText = "Số tín chỉ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách môn học: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            
        }

        private void HienThiSoSinhVienDK(string maMon)
        {
            con.Open();
            string sql = "SELECT COUNT(*) FROM diem WHERE MaMon = @MaMon";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MaMon", maMon);
            int count = (int)cmd.ExecuteScalar();
            con.Close();

            MessageBox.Show($"Hiện có {count} sinh viên đã đăng ký môn {maMon}");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            con = new SqlConnection();

            con.ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";

            LoadMonHocChuaDangKy();
        }

        private void dgvMonChuaDK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMonChuaDK.Rows[e.RowIndex];

                string maMon = row.Cells[0].Value.ToString();
                string maGV = row.Cells[1].Value.ToString();
                string tenMon = row.Cells[2].Value.ToString();
                string soTinChi = row.Cells[3].Value.ToString();

                // Gán vào TextBox nếu có
                txtMamh.Text = maMon;
                txtmagv.Text = maGV;
                txtTenmh.Text = tenMon;
                txtSotiet.Text = soTinChi;

                // Hoặc hiển thị thông báo:
                // MessageBox.Show($"Bạn vừa chọn môn: {tenMon} (Mã: {maMon})");
            }
        }

        private void btnnhaplai_Click(object sender, EventArgs e)
        {
           

            string maSV = UserSession.TenDangNhap;
            string maMon = dgvMonChuaDK.CurrentRow.Cells[0].Value.ToString();
            var soTinChi = Convert.ToInt32(dgvMonChuaDK.CurrentRow.Cells[3].Value);

            try
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();

                // 1. Thêm vào bảng điểm
                string insertDiem = "INSERT INTO diem (MaSV, MaMon, Diem) VALUES (@MaSV, @MaMon, 0)";
                SqlCommand cmdInsert = new SqlCommand(insertDiem, con, tran);
                cmdInsert.Parameters.AddWithValue("@MaSV", maSV);
                cmdInsert.Parameters.AddWithValue("@MaMon", maMon);
                cmdInsert.ExecuteNonQuery();

                // 2. Cập nhật học phí
                int soTien = soTinChi * 500000;
                string sql = @"
    DECLARE @OldTienPhaiDong INT;

    SELECT @OldTienPhaiDong = SoTienPhaiDong 
    FROM hocphi 
    WHERE MaSV = @MaSV;

    UPDATE hocphi
    SET 
        SoTienPhaiDong = @OldTienPhaiDong + @Tien,
        CongNo = (@OldTienPhaiDong + @Tien) - SoTienDaDong,
        TrangThai = 'Chưa đóng'         
    WHERE MaSV = @MaSV;
";

                SqlCommand cmd = new SqlCommand(sql, con, tran);
                cmd.Parameters.AddWithValue("@MaSV", maSV);
                cmd.Parameters.AddWithValue("@Tien", soTien);
                cmd.ExecuteNonQuery();

                tran.Commit();
                MessageBox.Show("Đăng ký môn học thành công!");

                LoadMonHocChuaDangKy(); // Load lại danh sách còn lại
                HienThiSoSinhVienDK(maMon); // (Tuỳ chọn)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng ký: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
