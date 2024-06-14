using System;
using System.Collections.Generic;

// Khai báo interface NhanVien
interface INhanVien
{
    // Khai báo các hàm get, set
    string HoTen { get; set; }
    int NamSinh { get; set; }
    string BangCap { get; set; }
    // Khai báo phương thức tính lương
    decimal TinhLuong();
}

// Cho class NhaQuanLy kế thừa lại class INhanVien
class NhaQuanLy : INhanVien
{
    // Implements lại các phương thức và khởi tạo thêm các phương thức khác
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public string BangCap { get; set; }
    public string ChucVu { get; set; }
    public int SoNgayCongTrongThang { get; set; }
    public decimal BacLuong { get; set; }

    // Overiding lại phương thức tính lương theo công thức
    public virtual decimal TinhLuong()
    {
        return SoNgayCongTrongThang * BacLuong * 100000;
    }
}

// Cho class NhaKhoaHoc kế thừa lại class NhaQuanLy vì đa số các thuộc tính của chúng là giống nhau chẳng qua bổ sung thêm thuộc tính
// số bài báo đã công bố

class NhaKhoaHoc : NhaQuanLy
{
    // Khởi tạo hàm get set
    public int SoBaiBaoDaCongBo { get; set; }

    // Không cần override TinhLuong() vì đã kế thừa từ class NhaQuanLy và chúng có cùng công thức
}

// Cho NhanVienPhongThiNghiem kế thừa lại Interface NhanVien
class NhanVienPhongThiNghiem : INhanVien
{
    // Implements ra tất cả các hàm get, set của các thuộc tính và bổ sung phần lương trong tháng
    public string HoTen { get; set; }
    public int NamSinh { get; set; }
    public string BangCap { get; set; }
    public decimal LuongTrongThang { get; set; }

    // Khởi tạo phương thức tính lương
    public decimal TinhLuong()
    {
        return LuongTrongThang;
    }
}

// Khởi tạo một List để lưu trữ các đối tượng làm trong viện khoa học
class VienKhoaHoc
{
    // Khai báo một List
    private List<INhanVien> danhSachNhanVien;

    // Khai báo hàm khởi tạo
    public VienKhoaHoc()
    {
        danhSachNhanVien = new List<INhanVien>();
    }
    // Khởi tạo một phương thức nhập nhân viên
    public void NhapNhanVien(INhanVien nv)
    {
        danhSachNhanVien.Add(nv);
    }

    // Khởi tạo phương thức in ra màn hình danh sách nhân viên
    public void XuatDanhSachNhanVien()
    {
        foreach (var nv in danhSachNhanVien)
        {
            Console.WriteLine($"Ho ten: {nv.HoTen}, Nam sinh: {nv.NamSinh},Bang cap: {nv.BangCap}, Luong: {nv.TinhLuong()}");
        }
    }

    // Khởi tạo hàm tính mức lương của từng nhóm riêng
    public void TongLuongTungLoai()
    {
        decimal tongLuongNhaKhoaHoc = 0;
        decimal tongLuongNhaQuanLy = 0;
        decimal tongLuongNhanVienPhongThiNghiem = 0;

        foreach (var nv in danhSachNhanVien)
        {
            if (nv is NhaKhoaHoc)
            {
                tongLuongNhaKhoaHoc += nv.TinhLuong();
            }
            else if (nv is NhaQuanLy)
            {
                tongLuongNhaQuanLy += nv.TinhLuong();
            }
            else if (nv is NhanVienPhongThiNghiem)
            {
                tongLuongNhanVienPhongThiNghiem += nv.TinhLuong();
            }
        }

        Console.WriteLine($"Tong luong nha khoa hoc la: {tongLuongNhaKhoaHoc}");
        Console.WriteLine($"Tong luong nha quan ly la: {tongLuongNhaQuanLy}");
        Console.WriteLine($"Tong luong nhan vien phong thi nghiem la: {tongLuongNhanVienPhongThiNghiem}");
    }
}
// Khởi tạo hàm Main để có thể triển khai được các class
class Program
{
    static void Main(string[] args)
    {
        VienKhoaHoc vien = new VienKhoaHoc();

        while (true)
        {
            Console.WriteLine("Chon loai nhan vien ban muon nhap dang so (1: Nha khoa hoc, 2: Nha quan ly, 3: Nhan vien phong thi nghiem, 0: Thoat): ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 0)
                break;

            switch (choice)
            {
                case 1:
                    // Khởi tạo đối tượng nhà khoa học và nhập thông tin cho nó
                    NhaKhoaHoc nhaKhoaHoc = new NhaKhoaHoc();
                    NhapThongTinChung(nhaKhoaHoc);
                    Console.Write("Moi nhap chuc vu: ");
                    nhaKhoaHoc.ChucVu = Console.ReadLine();
                    Console.Write("Moi nhap so bai bao da cong bo: ");
                    nhaKhoaHoc.SoBaiBaoDaCongBo = int.Parse(Console.ReadLine());
                    Console.Write("Moi nhap so ngay cong trong thang: ");
                    nhaKhoaHoc.SoNgayCongTrongThang = int.Parse(Console.ReadLine());
                    Console.Write("Moi nhap bac luong: ");
                    nhaKhoaHoc.BacLuong = decimal.Parse(Console.ReadLine());

                    vien.NhapNhanVien(nhaKhoaHoc);
                    break;

                case 2:
                    // Khởi tạo đối tượng nhà quản lý và nhập thông tin cho nó
                    NhaQuanLy nhaQuanLy = new NhaQuanLy();
                    NhapThongTinChung(nhaQuanLy);
                    Console.Write("Moi nhap chuc vu: ");
                    nhaQuanLy.ChucVu = Console.ReadLine();
                    Console.Write("Moi nhap so ngay cong trong thang: ");
                    nhaQuanLy.SoNgayCongTrongThang = int.Parse(Console.ReadLine());
                    Console.Write("Moi nhap bac luong: ");
                    nhaQuanLy.BacLuong = decimal.Parse(Console.ReadLine());

                    vien.NhapNhanVien(nhaQuanLy);
                    break;

                case 3:
                    // Khởi tạo nhân viên phòng thí nghiệm và nhập thông tin cho nó
                    NhanVienPhongThiNghiem nvPhongThiNghiem = new NhanVienPhongThiNghiem();
                    NhapThongTinChung(nvPhongThiNghiem);
                    Console.Write("Moi nhap muc luong trong thang: ");
                    nvPhongThiNghiem.LuongTrongThang = decimal.Parse(Console.ReadLine());

                    vien.NhapNhanVien(nvPhongThiNghiem);
                    break;

                default:
                    Console.WriteLine("Lua chon khong hop le.");
                    break;
            }
        }
        // In ra màn hình kết quả cuối cùng

        Console.WriteLine("Danh sach nhan vien:");
        vien.XuatDanhSachNhanVien();

        Console.WriteLine("\nTong luong da chi tra la:");
        vien.TongLuongTungLoai();
    }

    // Khởi tạo phương thức nhập vào dữ liệu từ bàn phím
    static void NhapThongTinChung(INhanVien nhanVien)
    {
        Console.Write("Moi nhap Ho va Ten: ");
        nhanVien.HoTen = Console.ReadLine();
        Console.Write("Moi nhap nam sinh: ");
        nhanVien.NamSinh = int.Parse(Console.ReadLine());
        Console.Write("Moi nhap bang cap: ");
        nhanVien.BangCap = Console.ReadLine();
    }
}
