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
namespace BTL_.NET.HoSo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = null;
        public string VaiTro = "";
        public string tentaikhoan = "";
        public string HoTen = ""; private void Form1_Load(object sender, EventArgs e)
        {
            if (con == null)
            {
                con = new SqlConnection();
            }
            con.ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();

            string tenDangNhap = UserSession.TenDangNhap;
            string vaiTro = "";

            // 1. Lấy vai trò
            using (SqlCommand cmdVaiTro = new SqlCommand("SELECT VaiTro FROM taikhoan WHERE TenDangNhap = @tk", con))
            {
                cmdVaiTro.Parameters.AddWithValue("@tk", tenDangNhap);
                using (SqlDataReader reader = cmdVaiTro.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        vaiTro = reader["VaiTro"].ToString();
                    }
                }
            }

            // 2. Lấy thông tin người dùng từ UNION query
            string sql = @"
    SELECT MaGV, MaMon, HoTen, NgaySinh, GioiTinh, QueQuan, SDT, Email, ChucVu
    FROM giangvien WHERE MaGV = @tk
    UNION
    SELECT MaSV AS MaGV, NULL AS MaMon, HoTen, NgaySinh, GioiTinh, QueQuan, SDT, Lop, MaPH
    FROM sinhvien WHERE MaSV = @tk
    UNION
    SELECT MaPH AS MaGV, MaSV AS MaMon, HoTen, NULL AS NgaySinh, NULL AS GioiTinh, NULL AS QueQuan, SDT, NULL AS Email, NULL AS ChucVu
    FROM phuhuynh WHERE MAPH = @tk";

            string ma = "", hoTen = "", sdt = "", ngaySinh = "", gioiTinh = "", queQuan = "", email = "", chucVu = "";
            string mamon = ""; // Biến này để lưu MaMon nếu cần thiết
            string maph = ""; // Biến này để lưu MaPH nếu cần thiết
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@tk", tenDangNhap);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ma = reader["MaGV"]?.ToString();
                        hoTen = reader["HoTen"]?.ToString();
                        sdt = reader["SDT"]?.ToString();
                        ngaySinh = reader["NgaySinh"]?.ToString();
                        gioiTinh = reader["GioiTinh"]?.ToString();
                        queQuan = reader["QueQuan"]?.ToString();
                        email = reader[7]?.ToString();
                        chucVu = reader["ChucVu"]?.ToString();
                        mamon = reader["MaMon"]?.ToString(); // Lấy MaMon nếu có

                    }
                }
            }

            // 3. Gán thông tin lên Form
            txtTensv.Text = hoTen;
            textNs.Text = gioiTinh;
            txtSdt.Text = sdt;

            if (vaiTro == "CNK" || vaiTro == "GiangVien")
            {
                label2.Text = "Mã Giảng Viên:";
                txtMasv.Text = ma;
                txtDc.Text = queQuan;
                cbGt.Text = ngaySinh;
                txtLop.Text = chucVu;
                label9.Visible = true;
                textBox1.Visible = true;
                label8.Text = "Chức Vụ";
                textBox2.Text = mamon ; // Email field đang lưu ChucVu
            }
            else if (vaiTro == "SinhVien")
            {
                label2.Text = "Mã Sinh Viên:";
                txtMasv.Text = ma;
                txtDc.Text = queQuan;
                cbGt.Text = ngaySinh;
                textNs.Text = gioiTinh;
                txtLop.Text = email; // Email field đang lưu Lop
                label10.Text = "Mã Phụ Huynh:";
                textBox2.Text = chucVu; // ChucVu field đang lưu MaPH
                label9.Visible = textBox1.Visible = false;
            }
            else if (vaiTro == "PhuHuynh")
            {
                
                txtMasv.Text = mamon;
                label5.Text = "Số điện thoại:";
                cbGt.Text = sdt;
                textBox2.Text = ma;
                label10.Text = "Mã Phụ Huynh:";
                
                // Ẩn các thông tin không có
                txtSdt.Visible= textBox1.Visible=textNs.Visible = label4.Visible = txtDc.Visible  = false;
               label6.Visible= label7.Visible = label8.Visible = txtLop.Visible = label9.Visible = false;
                textBox2.Visible = true;
            }

            con.Close();
        }


        private void txtMasv_TextChanged(object sender, EventArgs e)
        {

        }

        private void btĐóng_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

