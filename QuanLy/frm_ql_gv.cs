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

namespace BTL1.thongtin
{
    public partial class frm_ql_gv : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sqlcon;
        public frm_ql_gv()
        {
            InitializeComponent();
        }
        public void load_DL(string sql)
        {
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlcon);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            dggv.DataSource = ds.Tables[0];
            dggv.Columns[0].HeaderText = "Mã Giảng viên";
            dggv.Columns[1].HeaderText = "Mã Môn Học";  
            dggv.Columns[2].HeaderText = "Tên Giảng Viên";
            dggv.Columns[3].HeaderText = "Ngày Sinh";
            dggv.Columns[4].HeaderText = "Giới Tính";
            dggv.Columns[5].HeaderText = "Quê Quán";
            dggv.Columns[6].HeaderText = "SDT";
            dggv.Columns[7].HeaderText = "Email";
            dggv.Columns[8].HeaderText = "Chức Vụ";

            foreach (DataGridViewColumn col in dggv.Columns)
                col.Width = 150;


            dggv.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dggv.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void reset()
        {
            txtMagv.ReadOnly = false;
            txtMagv.Clear();
            txtTengv.Clear();
            dtpns.Text = DateTime.Now.ToString();
            txtSdt.Clear();
            txtDc.Clear();
            rdonam.Checked = true;
            txtMagv.Focus();
        }
        public void ketnoi()
        {
            sqlcon = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30");
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
        }



        private void frm_ql_gv_Load(object sender, EventArgs e)
        {
            
            

            txtMagv.Focus();
            ketnoi();
            string sql = "select * from giangvien";
            load_DL(sql);
        }

        private void dggv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dggv.Rows.Count)
            {
                return; // Ignore invalid clicks
            }
            txtMagv.ReadOnly = true;
            txtmamon.Text = dggv.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMagv.Text = dggv.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTengv.Text = dggv.Rows[e.RowIndex].Cells[2].Value.ToString();
            if (dggv.Rows[e.RowIndex].Cells[4].Value.ToString() == "Nam")
            {
                rdonam.Checked = true;
            }
            else
            {
                rdonu.Checked = true;
            }
            if (DateTime.TryParse(dggv.Rows[e.RowIndex].Cells[3].Value.ToString(), out DateTime parsedDate))
            {
                dtpns.Value = parsedDate;
            }
            else
            {
                MessageBox.Show("Invalid date format in the selected row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtSdt.Text = dggv.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtDc.Text = dggv.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtemail.Text = dggv.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtchucvu.Text = dggv.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
      
        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtMagv.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu! Hãy nhập đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMagv.Focus();
            }
            else if (txtTengv.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu! Hãy nhập đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTengv.Focus();
            }

            else if (txtSdt.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu! Hãy nhập đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSdt.Focus();
            }
            else if (txtDc.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu! Hãy nhập đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDc.Focus();
            }
            else
            {
                try
                {
                    ketnoi();
                    string str = "select count(*) from giangvien where MaGV='" + txtMagv.Text + "'";
                    SqlCommand sqlcom = new SqlCommand(str, sqlcon);
                    int i = (int)sqlcom.ExecuteScalar();
                    sqlcom.Dispose();
                    if (i != 0)
                    {
                        MessageBox.Show("Trùng mã! Mời nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMagv.Focus();
                    }
                    else
                    {
                        string gt = "";
                        if (rdonam.Checked)
                        {
                            gt = "Nam";
                        }
                        else
                        {
                            gt = "Nữ";
                        }
                        // Thêm giảng viên
                        string sqlGV = "insert into giangvien values('" + txtMagv.Text + "',N'" + txtmamon.Text + "',N'" + txtTengv.Text + "', N'" + gt + "', '" + dtpns.Value + "', '" + txtSdt.Text + "', N'" + txtDc.Text + "', N'" + txtemail.Text + "', N'" + txtchucvu.Text + "')";
                        SqlCommand cmdGV = new SqlCommand(sqlGV, sqlcon);
                        cmdGV.ExecuteNonQuery();

                        // Thêm tài khoản đăng nhập cho giảng viên
                        string sqlTK = "insert into taikhoan(TenDangNhap, MatKhau, VaiTro) values(@tendn, @matkhau, @vaitro)";
                        SqlCommand cmdTK = new SqlCommand(sqlTK, sqlcon);
                        cmdTK.Parameters.AddWithValue("@tendn", txtMagv.Text);
                        cmdTK.Parameters.AddWithValue("@matkhau", "1");
                        cmdTK.Parameters.AddWithValue("@vaitro", "GiangVien");
                        cmdTK.ExecuteNonQuery();

                        frm_ql_gv_Load(sender, e);
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                        sqlcon.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Thêm không thành công! Mời thực hiện lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ketnoi();
                    string gt = rdonam.Checked ? "Nam" : "Nữ";
                    txtchucvu.Enabled = false;
                    txtmamon.Enabled = false;
                    txtMagv.Enabled = false;

                    string sql = @"UPDATE giangvien SET hoten=@hoten, gioitinh=@gioitinh, ngaysinh=@ngaysinh, sdt=@sdt, quequan=@quequan, email=@email, chucvu=@chucvu WHERE magv=@magv";
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    cmd.Parameters.AddWithValue("@hoten", txtTengv.Text);
                    cmd.Parameters.AddWithValue("@gioitinh", gt);
                    cmd.Parameters.AddWithValue("@ngaysinh", dtpns.Value);
                    cmd.Parameters.AddWithValue("@sdt", txtSdt.Text);
                    cmd.Parameters.AddWithValue("@quequan", txtDc.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.Parameters.AddWithValue("@chucvu", txtchucvu.Text);
                    cmd.Parameters.AddWithValue("@magv", txtMagv.Text);

                    cmd.ExecuteNonQuery();
                    frm_ql_gv_Load(sender, e);
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

                    string sql = "delete from giangvien where magv='" + txtMagv.Text + "'";
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    cmd.ExecuteNonQuery();
                    frm_ql_gv_Load(sender, e);
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
            this.reset();
            txtmamon.Text="";
            txtemail.Text = "";
            txtchucvu.Text = "";
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
