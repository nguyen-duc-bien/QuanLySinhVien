using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BTL_.NET.chart
{
    public partial class ChartDiem : Form
    {
        SqlConnection sqlcon;

        public ChartDiem()
        {
            InitializeComponent();
        }
        private void ChartDiem_Load(object sender, EventArgs e)
        {
            string maDangNhap = UserSession.TenDangNhap;
            sqlcon = new SqlConnection();
            sqlcon.ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";
            sqlcon.Open();

            string maSV = null;

            // --- Xác định MaSV theo loại tài khoản
            if (maDangNhap.StartsWith("SV"))
            {
                // Người dùng là sinh viên → dùng trực tiếp mã đăng nhập
                maSV = maDangNhap;
            }
            else if (maDangNhap.StartsWith("PH"))
            {
                // Người dùng là phụ huynh → truy bảng sinhvien để lấy MaSV
                string sqlGetMaSV = "SELECT MaSV FROM SinhVien WHERE MaPH = @MaPH";
                using (SqlCommand cmdGetMaSV = new SqlCommand(sqlGetMaSV, sqlcon))
                {
                    cmdGetMaSV.Parameters.AddWithValue("@MaPH", maDangNhap);
                    SqlDataReader reader = cmdGetMaSV.ExecuteReader();
                    if (reader.Read())
                    {
                        maSV = reader["MaSV"].ToString();
                    }
                    reader.Close();
                }

                if (maSV == null)
                {
                    MessageBox.Show("Không tìm thấy sinh viên tương ứng với phụ huynh này.");
                    sqlcon.Close();
                    return;
                }
            }

            else
            {
                MessageBox.Show("Tài khoản không hợp lệ.");
                sqlcon.Close();
                return;
            }
            chart1.Series.Clear();

            // --- Series 1: Điểm sinh viên
            Series svSeries = new Series("Điểm Sinh Viên");
            svSeries.ChartType = SeriesChartType.Column;
            svSeries.Color = Color.Orange;
            chart1.Series.Add(svSeries);

            string sqlSV = @"
SELECT mh.TenMonHoc, d.Diem
FROM Diem d
JOIN MonHoc mh ON d.MaMon = mh.MaMon
WHERE d.MaSV = @MaSV";
            SqlCommand cmdSV = new SqlCommand(sqlSV, sqlcon);
            cmdSV.Parameters.AddWithValue("@MaSV", maSV);
            SqlDataReader readerSV = cmdSV.ExecuteReader();

            while (readerSV.Read())
            {
                string mon = readerSV["TenMonHoc"].ToString();
                double diem = Convert.ToDouble(readerSV["Diem"]);
                svSeries.Points.AddXY(mon, diem);
            }
            readerSV.Close();

            // --- Series 2: Điểm trung bình
            Series avgSeries = new Series("Điểm Trung Bình lớp học phần");
            avgSeries.ChartType = SeriesChartType.Line;
            avgSeries.BorderWidth = 3;
            avgSeries.Color = Color.Red;
            avgSeries.MarkerStyle = MarkerStyle.Circle;
            avgSeries.MarkerSize = 8;
            avgSeries.MarkerColor = Color.Red;
            chart1.Series.Add(avgSeries);

            string sqlAVG = @"
SELECT mh.TenMonHoc, AVG(d.Diem) AS DiemTrungBinh
FROM Diem d
JOIN MonHoc mh ON d.MaMon = mh.MaMon
GROUP BY mh.TenMonHoc";
            SqlCommand cmdAVG = new SqlCommand(sqlAVG, sqlcon);
            SqlDataReader readerAVG = cmdAVG.ExecuteReader();

            while (readerAVG.Read())
            {
                string mon = readerAVG["TenMonHoc"].ToString();
                double diemTB = Convert.ToDouble(readerAVG["DiemTrungBinh"]);
                avgSeries.Points.AddXY(mon, diemTB);
            }
            readerAVG.Close();

            // --- Cấu hình trục
            chart1.ChartAreas[0].AxisX.Title = "Môn học";
            chart1.ChartAreas[0].AxisY.Title = "Điểm";
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 10;


        }

        // --- Đoạn code xử lý chart phía sau không thay đổi ---


        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
