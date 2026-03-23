Đây là ứng dụng quản lý thông tin sinh viên được xây dựng trên nền tảng .NET WinForms, sử dụng cơ sở dữ liệu SQL Server. Dự án tập trung vào các thao tác quản lý dữ liệu cơ bản (CRUD) và giao diện người dùng trực quan.


báo cáo đồ án:
https://docs.google.com/document/d/1HNT2amRK0cOjBFS5GODB-zQwgP34zm48/edit?usp=sharing&ouid=118306648873789996927&rtpof=true&sd=true


 **Chức năng chính**

 
Quản lý hồ sơ: Thêm mới, chỉnh sửa thông tin và xóa sinh viên.

Tìm kiếm: Tra cứu sinh viên nhanh theo Mã SV hoặc Họ tên.

Danh sách: Hiển thị toàn bộ sinh viên dưới dạng bảng (DataGridView) trực quan.

Kết nối CSDL: Kết nối trực tiếp với SQL Server để lưu trữ dữ liệu bền vững.

 **Công nghệ sử dụng**

 
Ngôn ngữ: C# (.NET Framework)

Giao diện: Windows Forms (WinForms)

Cơ sở dữ liệu: Microsoft SQL Server 2019+

Công cụ: Visual Studio 2019/2022

**Hướng dẫn cài đặt**


Để chạy dự án này trên máy cục bộ, bạn thực hiện các bước sau:

1. Chuẩn bị Cơ sở dữ liệu
Mở SQL Server Management Studio (SSMS).

Chạy file script SQL (thường là file .sql đi kèm trong thư mục dự án) để tạo Database và các bảng cần thiết.

Nếu không có file script, hãy tạo Database tên là QuanLySinhVien.

2. Cấu hình Connection String
Mở mã nguồn trong Visual Studio, tìm file chứa chuỗi kết nối (thường trong App.config hoặc class kết nối Database) và sửa lại cho phù hợp với máy của bạn:

C#
"Data Source=YOUR_SERVER_NAME;Initial Catalog=QuanLySinhVien;Integrated Security=True"
3. Chạy ứng dụng
Mở file .sln bằng Visual Studio.

Nhấn F5 hoặc nút Start để build và chạy ứng dụng.

4. Cấu trúc dự án
/bin: Chứa các file thực thi sau khi build.

/Models: Các lớp đối tượng (SinhVien, Lop...).

/Views: Các Form giao diện.

/Controller hoặc /DAL: Xử lý logic và kết nối CSDL.

5. Đóng góp
Nếu bạn có ý tưởng cải thiện dự án, vui lòng:

Fork dự án.

Tạo nhánh mới (git checkout -b feature/AmazingFeature).

Commit thay đổi (git commit -m 'Add some AmazingFeature').

Push lên nhánh (git push origin feature/AmazingFeature).

Mở một Pull Request.
