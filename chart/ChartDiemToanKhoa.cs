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
using System.Windows.Forms.DataVisualization.Charting;

namespace BTL_.NET.chart
{
    public partial class ChartDiemToanKhoa : Form
    {
        SqlConnection sqlcon;
        public ChartDiemToanKhoa()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void ChartDiemToanKhoa_Load(object sender, EventArgs e)
        {
            sqlcon = new SqlConnection();
            sqlcon.ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";
            sqlcon.Open();

            string sql = @"
        SELECT 
            mh.TenMonHoc,
            AVG(d.Diem) AS DiemTrungBinh
        FROM 
            Diem d
        JOIN 
            MonHoc mh ON d.MaMon = mh.MaMon
        GROUP BY 
            mh.TenMonHoc
    ";

            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            SqlDataReader reader = cmd.ExecuteReader();

            chart1.Series.Clear();
            chart1.Series.Add("Điểm Trung Bình");
            chart1.Series["Điểm Trung Bình"].ChartType = SeriesChartType.Column;

            while (reader.Read())
            {
                string mon = reader["TenMonHoc"].ToString();
                double diemTB = Convert.ToDouble(reader["DiemTrungBinh"]);
                chart1.Series["Điểm Trung Bình"].Points.AddXY(mon, diemTB);
            }

            chart1.ChartAreas[0].AxisX.Title = "Môn học";
            chart1.ChartAreas[0].AxisY.Title = "Điểm trung bình";
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 10;

            reader.Close();
            sqlcon.Close();
        }

    }
}
