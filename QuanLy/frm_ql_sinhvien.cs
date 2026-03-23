using DevExpress.XtraPrinting.BarCode;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Presentation;
using ZXing.QrCode.Internal;
using ZXing.Rendering;
using BarcodeWriter = ZXing.BarcodeWriter;
using ErrorCorrectionLevel = ZXing.QrCode.Internal.ErrorCorrectionLevel;

namespace BTL1.thongtin
{
    public partial class frm_ql_sinhvien : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sqlcon;

        public frm_ql_sinhvien()
        {
            InitializeComponent();
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
            for (int i = 0; i <= 7; i++)
                dgsv.Columns[i].Width = 200;

            dgsv.AllowUserToAddRows = false;
            dgsv.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        public void reset()
        {
            txtMasv.ReadOnly = false;
            txtMasv.Clear();
            txtTensv.Clear();
            rdonam.Checked = true;
            ns.Text = DateTime.Now.ToString();
            txtSdt.Clear();
            txtDc.Clear();
            txtMasv.Focus();
        }

        public void ketnoi()
        {
            sqlcon = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30");
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
        }

        private void frm_ql_sinhvien_Load(object sender, EventArgs e)
        {
            txtMasv.Select();
            this.ActiveControl = txtMasv;
            txtMasv.Focus();
            ketnoi();

            string sql = "SELECT * FROM sinhvien";
            load_DL(sql);

            SqlDataAdapter da1 = new SqlDataAdapter(sql, sqlcon);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            DataTable dt1 = ds1.Tables[0];
            cboml.DataSource = dt1;
            cboml.DisplayMember = "Lop";
            cboml.ValueMember = "Lop";
        }

        private void dgsv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMasv.ReadOnly = true;
            txtMasv.Text = dgsv.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTensv.Text = dgsv.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (dgsv.Rows[e.RowIndex].Cells[2].Value.ToString() == "Nam")
                rdonam.Checked = true;
            else
                rdonu.Checked = true;

            ns.Text = dgsv.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSdt.Text = dgsv.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDc.Text = dgsv.Rows[e.RowIndex].Cells[5].Value.ToString();
            cboml.Text = dgsv.Rows[e.RowIndex].Cells[6].Value.ToString();
            MaPH.Text = dgsv.Rows[e.RowIndex].Cells[7].Value.ToString();
            var qrcode_text = $"{txtMasv.Text.Trim()}|{txtTensv.Text.Trim()}|{txtSdt.Text.Trim()}|";
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions() { Width = 100, Height = 100, Margin = 0, PureBarcode = false };
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            barcodeWriter.Renderer = new BitmapRenderer();
            barcodeWriter.Options = encodingOptions;
            barcodeWriter.Options.Hints.Add(EncodeHintType.DISABLE_ECI, true);
            barcodeWriter.Options.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            Bitmap bitmap = barcodeWriter.Write(qrcode_text);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtMasv.Text == "" || txtTensv.Text == "" || txtSdt.Text == "" || txtDc.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                ketnoi();
                string str = "SELECT COUNT(*) FROM sinhvien WHERE masv = @masv";
                SqlCommand sqlcom = new SqlCommand(str, sqlcon);
                sqlcom.Parameters.AddWithValue("@masv", txtMasv.Text);
                int i = (int)sqlcom.ExecuteScalar();
                sqlcom.Dispose();

                if (i != 0)
                {
                    MessageBox.Show("Trùng mã! Mời nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMasv.Focus();
                }
                else
                {
                    string gt = rdonam.Checked ? "Nam" : "Nữ";
                    string sql = "INSERT INTO sinhvien (MaSV, HoTen, NgaySinh,GioiTinh, SDT, QueQuan, Lop,MaPH) VALUES (@masv, @tensv,@ngaysinh,@gioitinh, @sdt, @diachi, @malop,@maph)";
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    cmd.Parameters.AddWithValue("@masv", txtMasv.Text);
                    cmd.Parameters.AddWithValue("@tensv", txtTensv.Text);
                    cmd.Parameters.AddWithValue("@gioitinh", gt);
                    cmd.Parameters.AddWithValue("@ngaysinh", ns.Value);
                    cmd.Parameters.AddWithValue("@sdt", txtSdt.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtDc.Text);
                    cmd.Parameters.AddWithValue("@malop", cboml.SelectedValue);
                    cmd.Parameters.AddWithValue("@maph", MaPH.Text);

                    cmd.ExecuteNonQuery();

                    frm_ql_sinhvien_Load(sender, e);
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    string sql1 = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, VaiTro) VALUES (@user, @pass, @quyen)";
                    SqlCommand cmd1 = new SqlCommand(sql1, sqlcon);
                    cmd.Parameters.AddWithValue("@user", txtMasv.Text);
                    cmd.Parameters.AddWithValue("@pass", 1);
                    cmd.Parameters.AddWithValue("@quyen", "sinhvien");
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm tài khoản thành công");
                    sqlcon.Close();
                }
            }
            catch
            {
                MessageBox.Show("Thêm không thành công! Mời thực hiện lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    string gt = rdonam.Checked ? "Nam" : "Nữ";
                    string sql = "UPDATE sinhvien SET hoten = @HoTen, gioitinh = @gioitinh, ngaysinh = @ngaysinh, sdt = @sdt, quequan = @quequan, lop = @lop WHERE masv = @masv";
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    cmd.Parameters.AddWithValue("@tensv", txtTensv.Text);
                    cmd.Parameters.AddWithValue("@gioitinh", gt);
                    cmd.Parameters.AddWithValue("@ngaysinh", ns.Value);
                    cmd.Parameters.AddWithValue("@sdt", txtSdt.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtDc.Text);
                    cmd.Parameters.AddWithValue("@malop", cboml.SelectedValue);
                    cmd.Parameters.AddWithValue("@masv", txtMasv.Text);
                    cmd.Parameters.AddWithValue("@maph", MaPH.Text);

                    cmd.ExecuteNonQuery();

                    frm_ql_sinhvien_Load(sender, e);
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
                    string sql = "DELETE FROM sinhvien WHERE masv = @masv";
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    cmd.Parameters.AddWithValue("@masv", txtMasv.Text);
                    cmd.ExecuteNonQuery();

                    frm_ql_sinhvien_Load(sender, e);
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

        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
