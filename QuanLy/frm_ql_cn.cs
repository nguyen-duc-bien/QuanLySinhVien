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

namespace BTL_.NET.QuanLy
{
    public partial class frm_ql_cn : Form
    {
        SqlConnection sqlcon;
        public frm_ql_cn()
        {
            InitializeComponent();
        }
        public void ketnoi()
        {
            string connStr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";
            sqlcon = new SqlConnection(connStr);
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
        }

        private void dshp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHocPhi.Rows[e.RowIndex];
                txtMaSV.Text = row.Cells["MaSV"].Value.ToString();
                txtCongNo.Text = row.Cells["CongNo"].Value.ToString();
                txtPhaiDong.Text = row.Cells["SoTienPhaiDong"].Value.ToString();
                txtDaDong.Text = row.Cells["SoTienDaDong"].Value.ToString();
                txtTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
            }
        }

        public void load_DL()
        {
            ketnoi();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM HocPhi", sqlcon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dgvHocPhi.DataSource = ds.Tables[0];
            sqlcon.Close();
            txttukhoa.Enabled = true;
            txtTrangThai.Text="Chưa đóng";
        }
        private void frm_ql_cn_Load(object sender, EventArgs e)
        {
            load_DL();
            txttukhoa.Enabled = true;
            txttukhoa.Clear();
            txttukhoa.ReadOnly = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ketnoi();
            string sql = "UPDATE HocPhi SET CongNo=@CongNo, SoTienPhaiDong=@PhaiDong, SoTienDaDong=@DaDong, TrangThai=@TrangThai WHERE MaSV=@MaSV";
            SqlCommand cmd = new SqlCommand(sql, sqlcon);
            cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text);
            cmd.Parameters.AddWithValue("@CongNo",  CongNo(txtPhaiDong.Text,txtDaDong.Text) );
            cmd.Parameters.AddWithValue("@PhaiDong", txtPhaiDong.Text);
            cmd.Parameters.AddWithValue("@DaDong", txtDaDong.Text);
            cmd.Parameters.AddWithValue("@TrangThai", trangthai());

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Sửa thành công!");
                load_DL();
                reset();
            }
            else
                MessageBox.Show("Không tìm thấy mã SV!");

            sqlcon.Close();
        }
        public String trangthai()
        {
            return CongNo(txtPhaiDong.Text, txtDaDong.Text) > 0 ? "Đã đóng" : "Chưa đóng";
        }

        public long  CongNo(string a,string b)
        {
            int x = Int32.Parse(a);
            int y = Int32.Parse(b);
            return x - y;
        }
        public void reset()
        {
            txtMaSV.Clear();
            txtCongNo.Clear();
            txtPhaiDong.Clear();
            txtDaDong.Clear();
            txtTrangThai.ResetText();
            txtMaSV.Focus();
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbtim.Text))
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbtim.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txttukhoa.Text))
            {
                MessageBox.Show("Bạn chưa nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttukhoa.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM HocPhi WHERE ";
                    string tukhoa = txttukhoa.Text.Trim();

                    switch (cbtim.Text)
                    {
                        case "MaSV":
                            sql += "MaSV LIKE @kw";
                            break;
                        case "SoTienPhaiDong":
                            sql += "CAST(SoTienPhaiDong AS NVARCHAR) LIKE @kw";
                            break;
                        case "SoTienDaDong":
                            sql += "CAST(SoTienDaDong AS NVARCHAR) LIKE @kw";
                            break;
                        case "CongNo":
                            sql += "CAST(CongNo AS NVARCHAR) LIKE @kw";
                            break;
                        case "TrangThai":
                            sql += "TrangThai LIKE @kw";
                            break;
                        default:
                            MessageBox.Show("Lựa chọn tìm kiếm không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@kw", "%" + tukhoa + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvHocPhi.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm!\nChi tiết: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
