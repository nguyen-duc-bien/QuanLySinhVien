using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL1.thongtin
{
    public partial class frm_ql_monhoc : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sqlcon;
        public frm_ql_monhoc()
        {
            InitializeComponent();
        }

        public void load_DL(string sql)
        {
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            dgmh.DataSource = ds.Tables[0];
            dgmh.Columns[0].HeaderText = "Mã Môn Học";
            dgmh.Columns[1].HeaderText = "Tên Môn Học";
            dgmh.Columns[2].HeaderText = "Số Tín Chỉ";
            dgmh.Columns[3].HeaderText = "Mã Giảng Viên";

            dgmh.Columns[0].Width = 200;
            dgmh.Columns[1].Width = 200;
            dgmh.Columns[2].Width = 200;
            dgmh.Columns[3].Width = 200;

            dgmh.AllowUserToAddRows = false;
            dgmh.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void reset()
        {
            txtMamh.ReadOnly = false;
            txtMamh.Clear();
            txtTenmh.Clear();
            txtSotiet.Clear();
            txtMamh.Focus();
        }

        public void ketnoi()
        {
            sqlcon = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30");
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
        }

        private void frm_ql_monhoc_Load(object sender, EventArgs e)
        {
            txtMamh.Select();
            this.ActiveControl = txtMamh;
            txtMamh.Focus();
            ketnoi();

            string sql = "SELECT * FROM monhoc";
            load_DL(sql);

            string sql1 = "SELECT * FROM giangvien";
            SqlDataAdapter da = new SqlDataAdapter(sql1, sqlcon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
        }

        private void dgmh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
            txtMamh.Text = dgmh.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenmh.Text = dgmh.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSotiet.Text = dgmh.Rows[e.RowIndex].Cells[3].Value.ToString(); // vẫn dùng biến txtSotiet
            txtmagv.Text = dgmh.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtMamh.Text == "" || txtTenmh.Text == "" || txtSotiet.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu! Hãy nhập đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                ketnoi();
                string str = "SELECT COUNT(*) FROM monhoc WHERE MaMon = @MaMH";
                SqlCommand sqlcom = new SqlCommand(str, sqlcon);
                sqlcom.Parameters.AddWithValue("@MaMH", txtMamh.Text);
                int i = (int)sqlcom.ExecuteScalar();
                sqlcom.Dispose();

                if (i != 0)
                {
                    MessageBox.Show("Trùng mã! Mời nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMamh.Focus();
                }
                else
                {
                    // Thêm môn học mới
                    string sql = "INSERT INTO monhoc VALUES (@MaMH,@magv, @tenmh, @SoTinChi )";
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    cmd.Parameters.AddWithValue("@MaMH", txtMamh.Text);
                    cmd.Parameters.AddWithValue("@tenmh", txtTenmh.Text);
                    cmd.Parameters.AddWithValue("@SoTinChi", txtSotiet.Text);
                    cmd.Parameters.AddWithValue("@magv", txtmagv.Text);
                    cmd.ExecuteNonQuery();

                    // Cập nhật MaMon trong bảng giangvien
                    string updateGV = @"
                UPDATE giangvien
                SET MaMon = 
                    CASE 
                        WHEN MaMon IS NULL OR MaMon = '' THEN @MaMH
                        ELSE MaMon + ',' + @MaMH 
                    END
                WHERE MaGV = @magv";

                    SqlCommand cmdUpdateGV = new SqlCommand(updateGV, sqlcon);
                    cmdUpdateGV.Parameters.AddWithValue("@MaMH", txtMamh.Text);
                    cmdUpdateGV.Parameters.AddWithValue("@magv", txtmagv.Text);
                    cmdUpdateGV.ExecuteNonQuery();

                    frm_ql_monhoc_Load(sender, e);
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    sqlcon.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm không thành công! Mời thực hiện lại!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ketnoi();
                    string sql = "UPDATE monhoc SET TenMonHoc = @tenmh, SoTinChi = @SoTinChi, MaGV = @magv WHERE MaMon = @MaMH";
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    cmd.Parameters.AddWithValue("@tenmh", txtTenmh.Text);
                    cmd.Parameters.AddWithValue("@SoTinChi", txtSotiet.Text);
                    cmd.Parameters.AddWithValue("@magv", txtmagv.Text);
                    cmd.Parameters.AddWithValue("@MaMH", txtMamh.Text);
                    cmd.ExecuteNonQuery();

                    frm_ql_monhoc_Load(sender, e);
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    sqlcon.Close();
                }
                catch
                {
                    MessageBox.Show("Sửa không thành công! Mời thực hiện lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ketnoi();
                    string sql = "DELETE FROM monhoc WHERE MaMon = @MaMH";
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    cmd.Parameters.AddWithValue("@MaMH", txtMamh.Text);
                    cmd.ExecuteNonQuery();

                    frm_ql_monhoc_Load(sender, e);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    sqlcon.Close();
                }
                catch
                {
                    MessageBox.Show("Xóa không thành công! Mời thực hiện lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
            }
        }

        private void btnnhaplai_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
    }
}
