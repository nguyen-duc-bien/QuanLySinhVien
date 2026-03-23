using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_.NET.TimKiem
{
    public partial class tk_lop : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sqlcon;

        public tk_lop()
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
            dglop.DataSource = ds.Tables[0];

            dglop.Columns[0].HeaderText = "Mã SV";
            dglop.Columns[1].HeaderText = "Họ Tên";
            dglop.Columns[2].HeaderText = "Ngày Sinh";
            dglop.Columns[3].HeaderText = "Giới Tính";
            dglop.Columns[4].HeaderText = "SĐT";
            dglop.Columns[6].HeaderText = "Quê Quán";
            dglop.Columns[7].HeaderText = "Lớp";
            dglop.Columns[8].HeaderText = "Mã Phụ Huynh";

            foreach (DataGridViewColumn col in dglop.Columns)
                col.Width = 150;
            dglop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dglop.AllowUserToAddRows = false;
            dglop.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void tk_lop_Load(object sender, EventArgs e)
        {
            cbtim.Items.Clear();
            cbtim.Items.Add("Mã lớp");
            cbtim.SelectedIndex = 0;

            txttukhoa.Clear();
            txttukhoa.Focus();

            ketnoi();
            string sql = "SELECT MaSV, HoTen, NgaySinh, GioiTinh, SDT, Email, QueQuan, Lop,MaPH FROM sinhvien";
            load_DL(sql);
        }

        private void btnloadlai_Click(object sender, EventArgs e)
        {
            tk_lop_Load(sender, e);
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            if (cbtim.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu tìm kiếm! Hãy chọn dữ liệu tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbtim.Focus();
            }
            else if (txttukhoa.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu tìm kiếm! Hãy nhập dữ liệu tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttukhoa.Focus();
            }
            else
            {
                try
                {
                    ketnoi();
                    string sql = "SELECT MaSV, HoTen, NgaySinh, GioiTinh, SDT, Email, QueQuan, Lop,MaPH FROM sinhvien WHERE Lop LIKE @malop";
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    cmd.Parameters.AddWithValue("@malop", "%" + txttukhoa.Text + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dglop.DataSource = dt;

                    sqlcon.Close();
                }
                catch
                {
                    MessageBox.Show("Không có dữ liệu cần tìm! Hãy thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txttukhoa.Clear();
                    cbtim.Text = "";
                }
            }
        }

        // Các hàm không sử dụng có thể bỏ hoặc để trống
        private void label3_Click(object sender, EventArgs e) { }
        private void cbtim_SelectedIndexChanged(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
