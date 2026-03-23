using BTL.Diem;
using BTL_.NET.HeThong;

using BTL_.NET.Log_Sig;
using BTL_.NET.TimKiem;
using BTL1.quanlytaikhoan;
using BTL1.thongtin;
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
using System.Runtime.InteropServices;
using BTL_.NET;
using BTL_.NET.thongtin;
using BTL_.NET.HoSo;
using BTL_.NET.chart;
using BTL_.NET.QuanLy;
namespace BTL.FormChinh
{
    public partial class frmformchinh : DevExpress.XtraEditors.XtraForm
    {
        [DllImport("Powrprof.dll", SetLastError = true)]
        private static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);
        SqlConnection con = null;
        public string VaiTro = "";
        public string tentaikhoan = "";
        public string HoTen = "";

        public frmformchinh(string VT, string tk, string ten)
        {
            InitializeComponent();
            this.VaiTro = VT;
            this.tentaikhoan = tk;
            this.HoTen = ten;
        }
        private void FormChinh_Load(object sender, EventArgs e)
        {
           
            if (con == null)
            {
                con = new SqlConnection();
            }
            con.ConnectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}\\DoAn.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();
            string sqlTK = "SELECT TenDangNhap, VaiTro FROM taikhoan WHERE TenDangNhap = @tdn";
            SqlCommand cmdTK = new SqlCommand(sqlTK, con);
            cmdTK.Parameters.AddWithValue("@tdn", tentaikhoan);
            SqlDataReader readerTK = cmdTK.ExecuteReader();
            string tenDangNhap = "";
            string vaiTro = "";
            if (readerTK.Read())
            {
                tenDangNhap = readerTK["TenDangNhap"].ToString();
                vaiTro = readerTK["VaiTro"].ToString();
            }
            readerTK.Close();

            // Lấy HoTen từ SinhVien, PhuHuynh hoặc GiangVien
            string sqlHoTen = @"
SELECT HoTen FROM SinhVien WHERE MaSV = @tdn
UNION
SELECT HoTen FROM GiangVien WHERE MaGV = @tdn
UNION
SELECT HoTen FROM PhuHuynh WHERE MaPH = @tdn
";
            SqlCommand cmdHoTen = new SqlCommand(sqlHoTen, con);
            cmdHoTen.Parameters.AddWithValue("@tdn", tentaikhoan);
            object hoTenObj = cmdHoTen.ExecuteScalar();
            string hoTen = hoTenObj != null ? hoTenObj.ToString() : "";

            con.Close();

            // Gán giá trị vào thuộc tính
            
            label3.Text = "" + DateTime.Now.ToString();
            label2.Text ="" + tenDangNhap+"/"+hoTen+ "/"+vaiTro;
            label2.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            if (vaiTro == "CNK")
            {
                đăngNhậpToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnAdminToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnGiáoViênToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnTrưởngKhoaToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnUserToolStripMenuItem.Visible = false;
                điểmToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnPhụHuynhToolStripMenuItem.Visible = false; toolStripMenuItem1.Visible = false;
            }
            if (vaiTro == "Admin")
            {
                thôngTinToolStripMenuItem.Visible = false;
                hồSơBảnThânToolStripMenuItem.Visible = false;
                điểmToolStripMenuItem.Visible = false;
            }
            if (vaiTro == "SinhVien")
            {
                đăngNhậpToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnAdminToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnGiáoViênToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnTrưởngKhoaToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnUserToolStripMenuItem.Visible = false;
                quảnLýToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnPhụHuynhToolStripMenuItem.Visible = false;

            }
            if (vaiTro == "GiangVien")
            {
                đăngNhậpToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnAdminToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnGiáoViênToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnTrưởngKhoaToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnUserToolStripMenuItem.Visible = false;
                quảnLýToolStripMenuItem.Visible=false;
                quảnLýTàiKhoảnPhụHuynhToolStripMenuItem.Visible = false;
                điểmToolStripMenuItem.Visible = false; toolStripMenuItem1.Visible = false;
            }
            if (vaiTro == "PhuHuynh")
            {
                đăngNhậpToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnAdminToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnGiáoViênToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnTrưởngKhoaToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnUserToolStripMenuItem.Visible = false;
                quảnLýToolStripMenuItem.Visible = false;
                quảnLýTàiKhoảnPhụHuynhToolStripMenuItem.Visible = false;
                toolStripMenuItem1.Visible = false;
            }
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FrmDangNhap frmDangNhap = new FrmDangNhap();
            frmDangNhap.Show();
        }

        private void quảnLýTàiKhoảnAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frm_qltk_admin frm_Qltk_Admin = new frm_qltk_admin();
            frm_Qltk_Admin.Show();
        }

        private void quảnLýTàiKhoảnTrưởngKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_qltk_cnk frm_Qltk_Truongkhoa = new frm_qltk_cnk();
            frm_Qltk_Truongkhoa.Show();
        }

        private void quảnLýTàiKhoảnGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_qltk_gv frm_Qltk_Gv = new frm_qltk_gv();
            frm_Qltk_Gv.Show();
        }

        private void quảnLýTàiKhoảnUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_qltk_sinhvien frm_Qltk_User = new frm_qltk_sinhvien();
            frm_Qltk_User.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ht_DoiMK ht_DoiMK = new ht_DoiMK(VaiTro);
            ht_DoiMK.Show();
        }





        private void giáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tk_giaovien tk_Giaovien = new tk_giaovien();
            tk_Giaovien.Show();
        }

        private void lớpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tk_lop tk_Lop = new tk_lop();
            tk_Lop.Show();
        }

        private void sinhViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tk_sinhvien tk_Sinhvien = new tk_sinhvien();
            tk_Sinhvien.Show();
        }

        private void mônHọcToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tk_monhoc tk_Monhoc = new tk_monhoc();
            tk_Monhoc.Show();
        }


        private void điểmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           frm_ql_diem frm_Ql_Diem = new frm_ql_diem();
            frm_Ql_Diem.Show();
        }



        private void giáoViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_ql_gv frm_Ql_Gv = new frm_ql_gv();
            frm_Ql_Gv.Show();
        }



        private void sinhViênToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frm_ql_sinhvien frm_Ql_Sinhvien = new frm_ql_sinhvien();
            frm_Ql_Sinhvien.Show();
        }

        private void mônHọcToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frm_ql_monhoc frm_Ql_Monhoc = new frm_ql_monhoc();
            frm_Ql_Monhoc.Show();
        }

        private void điểmToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ChartDiemToanKhoa chartDiemtk = new ChartDiemToanKhoa();
            chartDiemtk.Show();// Or use the correct property for MaSV
            frm_ql_diem frm_Ql_Diem = new frm_ql_diem();
            frm_Ql_Diem.Show();
        }

        private void trongSuốtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.8;

        }

        private void maToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = 1;

        }

        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Users\\DELL\\AppData\\Local\\Microsoft\\WindowsApps\\mspaint.exe");
        }

        private void cmdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("\"C:\\Windows\\System32\\cmd.exe\"");
        }

        private void notePadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Windows\\System32\\notepad.exe");
        }

        private void máyTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Windows\\System32\\calc.exe");
        }

        private void microsoftWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("\"C:\\Program Files\\Microsoft Office\\root\\Office16\\WINWORD.EXE\"");
        }

        private void tiếngAnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hệThốngToolStripMenuItem.Text = "System";
            quảnLýTàiKhoảnAdminToolStripMenuItem.Text = "Manage Account Admin";
            quảnLýTàiKhoảnTrưởngKhoaToolStripMenuItem.Text = "Manage Account Dean";
            quảnLýTàiKhoảnGiáoViênToolStripMenuItem.Text = "Manage Account Teacher";
            quảnLýTàiKhoảnUserToolStripMenuItem.Text = "Manage Account User";
            khóaToolStripMenuItem.Text = "Lock";
            đổiMậtKhẩuToolStripMenuItem.Text = "Change Password";
            xóaToolStripMenuItem.Text = "Logout";
            thôngTinToolStripMenuItem.Text = "Information";
            nhânViênToolStripMenuItem.Text = "Teacher";
            sinhViênToolStripMenuItem.Text = "Student";
            mônHọcToolStripMenuItem.Text = "Subject";
            điểmToolStripMenuItem.Text = "Scores";
            tìmKiếmToolStripMenuItem.Text = "Search";
            giáoViênToolStripMenuItem.Text = "Teacher";
            sinhViênToolStripMenuItem1.Text = "Student";
            mônHọcToolStripMenuItem1.Text = "Subject";
            quảnLýToolStripMenuItem.Text = "Manage";
            giáoViênToolStripMenuItem1.Text = "Teacher";
            sinhViênToolStripMenuItem2.Text = "Student";
            mônHọcToolStripMenuItem2.Text = "Subject";
            điểmToolStripMenuItem2.Text = "Scores";
            hiểnThịToolStripMenuItem.Text = "Display";
            kiểuXemToolStripMenuItem.Text = "View Type";
            trongSuốtToolStripMenuItem.Text = "Transparent";
            maToolStripMenuItem.Text = "Default";
            ngônNgữToolStripMenuItem.Text = "Language";
            tiếngAnhToolStripMenuItem.Text = "English";
            tiếngViệtToolStripMenuItem.Text = "Vietnamese";
            tiệnÍchToolStripMenuItem.Text = "Utilities";
            máyTínhToolStripMenuItem.Text = "Calculator";
            thoátToolStripMenuItem.Text = "Exit";
        }

        private void tiếngViệtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hệThốngToolStripMenuItem.Text = "Hệ Thống";
            quảnLýTàiKhoảnAdminToolStripMenuItem.Text = "Quản lý tài khoản Admin";
            quảnLýTàiKhoảnTrưởngKhoaToolStripMenuItem.Text = "Quản lý tài khoản trưởng khoa";
            quảnLýTàiKhoảnGiáoViênToolStripMenuItem.Text = "Quản lý tài khoản giáo viên";
            quảnLýTàiKhoảnUserToolStripMenuItem.Text = "Quản lý tài khoản người dùng";
            khóaToolStripMenuItem.Text = "Khóa";
            đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            xóaToolStripMenuItem.Text = "Đăng xuất";
            thôngTinToolStripMenuItem.Text = "Thông Tin";
            nhânViênToolStripMenuItem.Text = "Giáo viên";
            sinhViênToolStripMenuItem.Text = "Sinh viên";
            mônHọcToolStripMenuItem.Text = "Môn học";
            điểmToolStripMenuItem.Text = "Điểm";
            tìmKiếmToolStripMenuItem.Text = "Tìm Kiếm";
            giáoViênToolStripMenuItem.Text = "Giáo viên";
            sinhViênToolStripMenuItem1.Text = "Sinh viên";
            mônHọcToolStripMenuItem1.Text = "Môn học";
            quảnLýToolStripMenuItem.Text = "Quản Lý";
            giáoViênToolStripMenuItem1.Text = "Giáo viên";
            sinhViênToolStripMenuItem2.Text = "Sinh viên";
            mônHọcToolStripMenuItem2.Text = "Môn học";
            điểmToolStripMenuItem2.Text = "Điểm";
            hiểnThịToolStripMenuItem.Text = "Hiển Thị";
            kiểuXemToolStripMenuItem.Text = "Kiểu xem";
            trongSuốtToolStripMenuItem.Text = "Trong suốt";
            maToolStripMenuItem.Text = "Mặc định";
            ngônNgữToolStripMenuItem.Text = "Ngôn ngữ";
            tiếngAnhToolStripMenuItem.Text = "Tiếng Anh";
            tiếngViệtToolStripMenuItem.Text = "Tiếng Việt";
            tiệnÍchToolStripMenuItem.Text = "Tiện Ích";
            máyTínhToolStripMenuItem.Text = "Máy tính";
            thoátToolStripMenuItem.Text = "Thoát";
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frm_tt_gv frm_Tt_Gv = new frm_tt_gv();
            frm_Tt_Gv.Show();
        }


        public string getTenDN()
        {
            
            return tentaikhoan;
        }





        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_tt_monhoc frm_Tt_Monhoc = new frm_tt_monhoc();
            frm_Tt_Monhoc.Show();
        }


        private void điểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChartDiem chartDiem = new ChartDiem();
            chartDiem.Show();// Or use the correct property for MaSV
            frm_tt_diem frmDiem = new frm_tt_diem(this.tentaikhoan,this.HoTen); // Or use the correct property for MaSV
            frmDiem.Show();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            this.Close();

        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Users\\DELL\\Documents\\HelpNDoc\\Output\\chm\\laptrinhnet.chm");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            hệThốngToolStripMenuItem.Text = "System";
            quảnLýTàiKhoảnAdminToolStripMenuItem.Text = "Manage Account Admin";
            quảnLýTàiKhoảnTrưởngKhoaToolStripMenuItem.Text = "Manage Account Dean";
            quảnLýTàiKhoảnGiáoViênToolStripMenuItem.Text = "Manage Account Teacher";
            quảnLýTàiKhoảnUserToolStripMenuItem.Text = "Manage Account User";
            khóaToolStripMenuItem.Text = "Lock";
            đổiMậtKhẩuToolStripMenuItem.Text = "Change Password";
            xóaToolStripMenuItem.Text = "Logout";
            thôngTinToolStripMenuItem.Text = "Information";
            nhânViênToolStripMenuItem.Text = "Teacher";
            sinhViênToolStripMenuItem.Text = "Student";
            mônHọcToolStripMenuItem.Text = "Subject";
            điểmToolStripMenuItem.Text = "Scores";
            tìmKiếmToolStripMenuItem.Text = "Search";
            giáoViênToolStripMenuItem.Text = "Teacher";
            sinhViênToolStripMenuItem1.Text = "Student";
            mônHọcToolStripMenuItem1.Text = "Subject";
            quảnLýToolStripMenuItem.Text = "Manage";
            giáoViênToolStripMenuItem1.Text = "Teacher";
            sinhViênToolStripMenuItem2.Text = "Student";
            mônHọcToolStripMenuItem2.Text = "Subject";
            điểmToolStripMenuItem2.Text = "Scores";
            hiểnThịToolStripMenuItem.Text = "Display";
            kiểuXemToolStripMenuItem.Text = "View Type";
            trongSuốtToolStripMenuItem.Text = "Transparent";
            maToolStripMenuItem.Text = "Default";
            ngônNgữToolStripMenuItem.Text = "Language";
            tiếngAnhToolStripMenuItem.Text = "English";
            tiếngViệtToolStripMenuItem.Text = "Vietnamese";
            tiệnÍchToolStripMenuItem.Text = "Utilities";
            máyTínhToolStripMenuItem.Text = "Calculator";
            thoátToolStripMenuItem.Text = "Exit";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            hệThốngToolStripMenuItem.Text = "Hệ Thống";
            quảnLýTàiKhoảnAdminToolStripMenuItem.Text = "Quản lý tài khoản Admin";
            quảnLýTàiKhoảnTrưởngKhoaToolStripMenuItem.Text = "Quản lý tài khoản trưởng khoa";
            quảnLýTàiKhoảnGiáoViênToolStripMenuItem.Text = "Quản lý tài khoản giáo viên";
            quảnLýTàiKhoảnUserToolStripMenuItem.Text = "Quản lý tài khoản người dùng";
            khóaToolStripMenuItem.Text = "Khóa";
            đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            xóaToolStripMenuItem.Text = "Đăng xuất";
            thôngTinToolStripMenuItem.Text = "Thông Tin";
            nhânViênToolStripMenuItem.Text = "Giáo viên";
            sinhViênToolStripMenuItem.Text = "Sinh viên";
            mônHọcToolStripMenuItem.Text = "Môn học";
            điểmToolStripMenuItem.Text = "Điểm";
            tìmKiếmToolStripMenuItem.Text = "Tìm Kiếm";
            giáoViênToolStripMenuItem.Text = "Giáo viên";
            sinhViênToolStripMenuItem1.Text = "Sinh viên";
            mônHọcToolStripMenuItem1.Text = "Môn học";
            quảnLýToolStripMenuItem.Text = "Quản Lý";
            giáoViênToolStripMenuItem1.Text = "Giáo viên";
            sinhViênToolStripMenuItem2.Text = "Sinh viên";
            mônHọcToolStripMenuItem2.Text = "Môn học";
            điểmToolStripMenuItem2.Text = "Điểm";
            hiểnThịToolStripMenuItem.Text = "Hiển Thị";
            kiểuXemToolStripMenuItem.Text = "Kiểu xem";
            trongSuốtToolStripMenuItem.Text = "Trong suốt";
            maToolStripMenuItem.Text = "Mặc định";
            ngônNgữToolStripMenuItem.Text = "Ngôn ngữ";
            tiếngAnhToolStripMenuItem.Text = "Tiếng Anh";
            tiếngViệtToolStripMenuItem.Text = "Tiếng Việt";
            tiệnÍchToolStripMenuItem.Text = "Tiện Ích";
            máyTínhToolStripMenuItem.Text = "Máy tính";
            thoátToolStripMenuItem.Text = "Thoát";
        }

        private void khóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSuspendState(false, true, true);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýTàiKhoảnPhụHuynhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_qltk_ph frm_Qltk_PhuHuynh = new frm_qltk_ph();
            frm_Qltk_PhuHuynh.Show();
        }

        private void hồSơPhụHuynhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_tt_ph frm_Tt_Ph = new frm_tt_ph();
            frm_Tt_Ph.Show();
        }

        private void hồSơBảnThânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm_HoSo = new Form1();
            frm_HoSo.Show();
        }

        private void phụHuynhToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frm_ql_ph frm_Ql_Ph = new frm_ql_ph();
            frm_Ql_Ph.Show();
        }

        private void traCứuCôngNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_tt_cn frm_Tt_HocPhi = new frm_tt_cn(); // Hoặc sử dụng thuộc tính MaSV phù hợp
            frm_Tt_HocPhi.Show();
        }

        private void côngNợSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ql_cn frm_Ql_CongNo = new frm_ql_cn();
            frm_Ql_CongNo.Show();
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tk_sinhvien frm_Tk_Sinhvien = new tk_sinhvien();
            frm_Tk_Sinhvien.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}

