using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;

namespace BTL_.NET.TimKiem
{
    public partial class tk_giaovien : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sqlcon;
        public tk_giaovien()
        {
            InitializeComponent();
        }

        public void ketnoi()
        {
            sqlcon = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30");
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
        }

        public void load_DL(string sql)
        {
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                dggv.DataSource = ds.Tables[0];

                if (dggv.Columns.Count >= 9)
                {
                    dggv.Columns[0].HeaderText = "Mã GV";
                    dggv.Columns[1].HeaderText = "Mã Môn Học";
                    dggv.Columns[2].HeaderText = "Tên GV";
                    dggv.Columns[3].HeaderText = "Ngày Sinh";
                    dggv.Columns[4].HeaderText = "Giới Tính";
                    dggv.Columns[5].HeaderText = "Quê Quán";
                    dggv.Columns[6].HeaderText = "SĐT";
                    dggv.Columns[7].HeaderText = "Email";
                    dggv.Columns[8].HeaderText = "Chức Vụ";

                    foreach (DataGridViewColumn col in dggv.Columns)
                        col.Width = 150;
                }
                else
                {
                    MessageBox.Show("Bảng dữ liệu không đủ số cột như mong đợi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                dggv.AllowUserToAddRows = false;
                dggv.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void tk_giaovien_Load(object sender, EventArgs e)
        {
            cbtim.Focus();
            ketnoi();
            string sql = "SELECT * FROM GiangVien";
            load_DL(sql);
        }
        private void btntim_Click(object sender, EventArgs e)
        {
            if (cbtim.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn trường tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbtim.Focus();
                return;
            }
            if (txttukhoa.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttukhoa.Focus();
                return;
            }

            try
            {
                ketnoi(); // thêm vào nếu chưa có
                string sql = "";

                if (cbtim.Text == "Mã GV")
                    sql = "SELECT * FROM GiangVien WHERE MaGV LIKE '%" + txttukhoa.Text + "%'";
                else if (cbtim.Text == "Họ Tên")
                    sql = "SELECT * FROM GiangVien WHERE HoTen LIKE '%" + txttukhoa.Text + "%'";
                else if (cbtim.Text == "Mã Môn")
                    sql = "SELECT * FROM GiangVien WHERE MaMon LIKE '%" + txttukhoa.Text + "%'";
                else if (cbtim.Text == "SĐT")
                    sql = "SELECT * FROM GiangVien WHERE SDT LIKE '%" + txttukhoa.Text + "%'";
                else if (cbtim.Text == "Quê Quán")
                    sql = "SELECT * FROM GiangVien WHERE QueQuan LIKE '%" + txttukhoa.Text + "%'";

                SqlDataAdapter da = new SqlDataAdapter(sql, sqlcon);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dggv.DataSource = dt; // đảm bảo dggv đã được khai báo

                if (dt.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy kết quả!");

                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
            
        }


        private void btnloadlai_Click(object sender, EventArgs e)
        {
            LoadAllData();
            txttukhoa.Clear();
            cbtim.SelectedIndex = -1;
        }

        private void LoadAllData()
        {
            string query = "SELECT * FROM giangvien";
            using (SqlConnection con = new SqlConnection(sqlcon.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dggv.DataSource = dt;
            }
        }


        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dggv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void cbtim_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btntim_Click_1(object sender, EventArgs e)
        {
         
            if (cbtim.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tiêu chí tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txttukhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tukhoa = txttukhoa.Text.Trim();
            string cot = "";

            switch (cbtim.SelectedItem.ToString())
            {
                case "Mã Giảng Viên":
                    cot = "MaGV";
                    break;
                case "Tên Giảng Viên":
                    cot = "TenGV";
                    break;
                case "Mã Môn Học":
                    cot = "MaMH";
                    break;
                case "Số Điện Thoại":
                    cot = "SDT";
                    break;
                case "Quê Quán":
                    cot = "QueQuan";
                    break;
            }

            string query = $"SELECT * FROM giangvien WHERE {cot} LIKE @tukhoa";
            using (SqlConnection con = new SqlConnection(sqlcon.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@tukhoa", "%" + tukhoa + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                dggv.DataSource = dt;
            }
        }


    }
}
