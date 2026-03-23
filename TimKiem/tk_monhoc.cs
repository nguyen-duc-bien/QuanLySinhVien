using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_.NET.TimKiem
{
    public partial class tk_monhoc : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sqlcon;
        public tk_monhoc()
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
            dgmh.DataSource = ds.Tables[0];
            dgmh.Columns[0].HeaderText = "Mã Môn Học";
            dgmh.Columns[1].HeaderText = "Mã Giảng Viên";
            dgmh.Columns[2].HeaderText = "Tên Môn Học";
            dgmh.Columns[3].HeaderText = "Số Tín Chỉ";


            for (int i = 0; i < 4; i++)
                dgmh.Columns[i].Width = 200;

            dgmh.AllowUserToAddRows = false;
            dgmh.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void tk_monhoc_Load(object sender, EventArgs e)
        {
            cbtim.Focus();
            ketnoi();
            string sql = "SELECT * FROM monhoc";
            load_DL(sql);
        }

        private void btnloadlai_Click(object sender, EventArgs e)
        {
            txttukhoa.Clear();
            cbtim.Text = "";
            tk_monhoc_Load(sender, e);
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
                    string sql = "";
                    if (cbtim.Text == cbtim.Items[0].ToString())
                    {
                        sql = "SELECT * FROM monhoc WHERE MaMon LIKE '%" + txttukhoa.Text + "%'";
                    }
                    else if (cbtim.Text == cbtim.Items[1].ToString())
                    {
                        sql = "SELECT * FROM monhoc WHERE MaGV LIKE '%" + txttukhoa.Text + "%'";
                    }
                    else if (cbtim.Text == cbtim.Items[2].ToString())
                    {
                        sql = "SELECT * FROM monhoc WHERE TenMonHoc LIKE '%" + txttukhoa.Text + "%'";
                    }
                    else if (cbtim.Text == cbtim.Items[3].ToString())
                    {
                        sql = "SELECT * FROM monhoc WHERE SoTinChi LIKE '%" + txttukhoa.Text + "%'";
                    }

                    load_DL(sql);
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

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Các sự kiện không sử dụng có thể xóa bớt cho gọn
        private void label3_Click(object sender, EventArgs e) { }
        private void cbtim_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void txttukhoa_TextChanged(object sender, EventArgs e) { }

        private void dgmh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
