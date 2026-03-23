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

namespace BTL_.NET.TimKiem
{
    public partial class tk_sinhvien : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sqlcon;
        public tk_sinhvien()
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
            dgsv.DataSource = ds.Tables[0];
            dgsv.Columns[0].HeaderText = "Mã Sinh Viên";
            dgsv.Columns[1].HeaderText = "Tên Sinh Viên";
            dgsv.Columns[2].HeaderText = "Ngày Sinh";
            dgsv.Columns[3].HeaderText = "Giới Tính";

            dgsv.Columns[4].HeaderText = "Số Điện Thoại";
            dgsv.Columns[5].HeaderText = "Quê Quán";
            dgsv.Columns[6].HeaderText = "Lớp";
            dgsv.Columns[7].HeaderText = "Mã Phụ Huynh";


            foreach (DataGridViewColumn col in dgsv.Columns)
                col.Width = 150;
            dgsv.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgsv.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void tk_sinhvien_Load(object sender, EventArgs e)
        {
            cbtim.Focus();
            ketnoi();
            string sql = "select * from sinhvien";
            load_DL(sql);
        }

        private void btnloadlai_Click(object sender, EventArgs e)
        {
            txttukhoa.Text = "";
            cbtim.Text = "";
            tk_sinhvien_Load(sender, e);
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
                        sql = "select * from sinhvien where MaSV like '%" + txttukhoa.Text + "%'";
                    }
                    else if (cbtim.Text == cbtim.Items[1].ToString())
                    {
                        sql = "select * from sinhvien where HoTen like '%" + txttukhoa.Text + "%'";
                    }
                    else if (cbtim.Text == cbtim.Items[2].ToString())
                    {
                        sql = "select * from sinhvien where NgaySinh like '%" + txttukhoa.Text + "%'";
                    }
                    else if (cbtim.Text == cbtim.Items[3].ToString())
                    {
                        sql = "select * from sinhvien where GioiTinh like '%" + txttukhoa.Text + "%'";
                    }
                    else if (cbtim.Text == cbtim.Items[4].ToString())
                    {
                        sql = "select * from sinhvien where SDT like '%" + txttukhoa.Text + "%'";
                    }
                    else if (cbtim.Text == cbtim.Items[5].ToString())
                    {
                        sql = "select * from sinhvien where QueQuan like '%" + txttukhoa.Text + "%'";
                    }else if (cbtim.Text == cbtim.Items[6].ToString())
                    {
                        sql = "select * from sinhvien where Lop like '%" + txttukhoa.Text + "%'";
                    }

                    else if (cbtim.Text == cbtim.Items[7].ToString())
                    {
                        sql = "select * from sinhvien where MaPH like '%" + txttukhoa.Text + "%'";
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
    }
}
