using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BTL_.NET.HeThong
{
    public partial class frm_qltk_ph : Form
    {
        private SqlConnection con = new SqlConnection();

        public frm_qltk_ph()
        {
            InitializeComponent();
            con.ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";
        
        }

        private void frm_qltk_ph_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
           
            con = new SqlConnection();
            con.ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();
            string sql = "Select * from taikhoan where VaiTro='PhuHuynh' ";
            SqlDataAdapter sqldt = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            sqldt.Fill(dt);
            sqldt.Fill(ds);
            dgvph.DataSource = dt;
            dgvph.Columns[0].HeaderText = "Tài Khoản";
            dgvph.Columns[1].HeaderText = "Mật Khẩu"; 
            dgvph.Columns[2].HeaderText = "Vai Trò";
            dgvph.Columns[0].Width = 200;
            dgvph.Columns[1].Width = 200;
            dgvph.Columns[2].Width = 200;


            dgvph.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvph.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnnhaplai_Click(object sender, EventArgs e)
        {
         
            txttdn.Text = "";
            txtmk.Text = "";
            txttdn.Focus();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txttdn.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập!!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                if (txtmk.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string sql = "Select count(*) from taikhoan where TenDangNhap='" + txttdn.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                int i = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                if (i != 0)
                {
                    MessageBox.Show("Tài khoản đã được đăng ký!!!Vui lòng chọn tên tài khoản khác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    txttdn.Text = "";
                    txtmk.Text = "";
                    txttdn.Focus();
                }
                else
                {
                    string sql2 = "INSERT INTO taikhoan (TenDangNhap, MatKhau, VaiTro) VALUES ('" + txttdn.Text + "', '" + txtmk.Text + "', N'PhuHuynh')";
                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Bạn đã đăng ký thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                    txttdn.Text = "";
                    txtmk.Text = "";
                    txttdn.Focus();
                    frm_qltk_ph_Load(sender, e);
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txttdn.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập!!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
              if (txtmk.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string sql;
                sql = "UPDATE taikhoan SET MatKhau=N'" + txtmk.Text + "' where  TenDangNhap=N'" + txttdn.Text + "'";
                SqlCommand cmd;
                cmd = new SqlCommand(sql, con);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ohh!Có vẻ hệ thống lỗi!Thử lại sau.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                txttdn.Text = "";
                txtmk.Text = "";
                txttdn.Focus();
                cmd.Dispose();
                cmd = null;
                frm_qltk_ph_Load(sender, e);
            }
        }

        private void dgvph_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txttdn.Text = dgvph.CurrentRow.Cells[0].Value.ToString();
            txtmk.Text = dgvph.CurrentRow.Cells[1].FormattedValue.ToString();
          
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txttdn.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đăng nhập!!!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
           if (txtmk.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string sql;
                sql = "DELETE taikhoan WHERE TenDangNhap=N'" + txttdn.Text + "'";
                SqlCommand cmd;
                cmd = new SqlCommand(sql, con);

                try
                {
                    DialogResult dg = MessageBox.Show("Bạn xóa không?", "Thông báo",
  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg == DialogResult.Yes)
                    {
                        MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch
                {
                    MessageBox.Show("Mã không tồn tại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
                txttdn.Text = "";
                txtmk.Text = "";
              
                cmd.Dispose();
                cmd = null;
                frm_qltk_ph_Load(sender, e);
            }
        }
    }
    }

