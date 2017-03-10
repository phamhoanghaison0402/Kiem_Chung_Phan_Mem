using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using QuanLySieuThiDienThoai.BLL;
using QuanLySieuThiDienThoai.DTO;
using System.IO;
using DAO;


namespace UnitTest
{
    [TestClass]
    public class IntegrationTest
    {
        //Test Thêm nhân viên xong sửa nhân viên
        [TestMethod]
        public void Test_ThemSuaNhanVien()
        {
            NhanVienBll nvbll = new NhanVienBll();
            NhanVien nv = new NhanVien("NV007");
            nv.TenNhanVien = "Nguyen Ngoc Han";
            nv.GioiTinh = "Nam";
            nv.NgaySinh = new DateTime(1992, 02, 03).Date;
            nv.PhongBan = "Quản Trị";
            nv.DiaChi = "TPHCM";
            nv.SDT = "0928138293";
            nv.CMND = "098217321";
            nv.TenDangNhap = "hannn";
            nv.MatKhau = "12345";
            byte[] Hinh = new byte[0];
            nv.Hinh = Hinh;
            Assert.AreEqual(1, nvbll.InsertNhanVien(nv));

            nv.TenNhanVien = "Nguyen Ngoc Tan";
            Assert.AreEqual(1, nvbll.UpdateNhanVien(nv));
        }
        // Test thêm nhân viên xong xoá nhân viên
        [TestMethod]
        public void Test_ThemXoaNhanVien()
        {
            NhanVienBll nvbll = new NhanVienBll();
            NhanVien nv = new NhanVien("NV008");
            nv.TenNhanVien = "Nguyen Ngoc Han";
            nv.GioiTinh = "Nam";
            nv.NgaySinh = new DateTime(1992, 02, 03).Date;
            nv.PhongBan = "Quản Trị";
            nv.DiaChi = "TPHCM";
            nv.SDT = "0928138293";
            nv.CMND = "098217321";
            nv.TenDangNhap = "hannn";
            nv.MatKhau = "12345";
            byte[] Hinh = new byte[0];
            nv.Hinh = Hinh;
            Assert.AreEqual(1, nvbll.InsertNhanVien(nv));

            Assert.AreEqual(1, nvbll.DeleteNhanVien(nv));
        }
       
        // Test thêm nhân viên xong đăng nhập
        [TestMethod]
        public void Test_ThemNhanVienDangNhap()
        {
            NhanVienBll nvbll = new NhanVienBll();
            NhanVien nv = new NhanVien("NV010");
            nv.TenNhanVien = "Tran Hoang Hai";
            nv.GioiTinh = "Nam";
            nv.NgaySinh = new DateTime(1994, 06, 02).Date;
            nv.PhongBan = "Bán Hàng";
            nv.DiaChi = "TPHCM";
            nv.SDT = "0912383829";
            nv.CMND = "238741883";
            nv.TenDangNhap = "haitn";
            nv.MatKhau = "12345";
            byte[] Hinh = new byte[0];
            nv.Hinh = Hinh;
            Assert.AreEqual(1, nvbll.InsertNhanVien(nv));


            TTDangNhap tt = new TTDangNhap();
            tt.TenNhanVien = "Tran Hoang Hai";
            tt.MaNhanVien = "NV010";
            string mk = "12345";
            TTDangNhap tt2 = DangNhapBll.LayThongTinDangNhap("haitn", mk);
            Assert.AreEqual(tt.MaNhanVien, tt2.MaNhanVien);
            Assert.AreEqual(tt.TenNhanVien, tt2.TenNhanVien);
        }

        // Test đăng nhập xong thêm nhân viên
        [TestMethod]
        public void Test_DangNhapThemNhanVien()
        {
            TTDangNhap tt = new TTDangNhap();
            tt.TenNhanVien = "Tran Hoang Hai";
            tt.MaNhanVien = "NV010";
            string mk = "12345";
            TTDangNhap tt2 = DangNhapBll.LayThongTinDangNhap("haitn", mk);
            Assert.AreEqual(tt.MaNhanVien, tt2.MaNhanVien);
            Assert.AreEqual(tt.TenNhanVien, tt2.TenNhanVien);

            NhanVienBll nvbll = new NhanVienBll();
            NhanVien nv = new NhanVien("NV011");
            nv.TenNhanVien = "Hoang Thai Son";
            nv.GioiTinh = "Nam";
            nv.NgaySinh = new DateTime(1989, 11, 28).Date;
            nv.PhongBan = "Bán Hàng";
            nv.DiaChi = "Q3";
            nv.SDT = "0923481233";
            nv.CMND = "938487263";
            nv.TenDangNhap = "sonht";
            nv.MatKhau = "12345";
            byte[] Hinh = new byte[0];
            nv.Hinh = Hinh;
            Assert.AreEqual(1, nvbll.InsertNhanVien(nv));
        }
        // Test đăng nhập xong sửa nhân viên
        [TestMethod]
        public void Test_DangNhapSuaNhanVien()
        {
            TTDangNhap tt = new TTDangNhap();
            tt.TenNhanVien = "Tran Hoang Hai";
            tt.MaNhanVien = "NV010";
            string mk = "12345";
            TTDangNhap tt2 = DangNhapBll.LayThongTinDangNhap("haitn", mk);
            Assert.AreEqual(tt.MaNhanVien, tt2.MaNhanVien);
            Assert.AreEqual(tt.TenNhanVien, tt2.TenNhanVien);

            NhanVienBll nvbll = new NhanVienBll();
            NhanVien nv = new NhanVien("NV010");
            nv.TenNhanVien = "Tran Hoang Hao";
            nv.GioiTinh = "Nam";
            nv.NgaySinh = new DateTime(1994, 06, 02).Date;
            nv.PhongBan = "Quản Trị";
            nv.DiaChi = "Q2";
            nv.SDT = "0912383829";
            nv.CMND = "238741883";
            nv.TenDangNhap = "haoth";
            nv.MatKhau = "12345";
            byte[] Hinh = new byte[0];
            nv.Hinh = Hinh;
            Assert.AreEqual(1, nvbll.UpdateNhanVien(nv));
        }
        // Test đăng nhập xong xoá nhân viên
        [TestMethod]
        public void Test_DangNhapXoaNhanVien()
        {
            TTDangNhap tt = new TTDangNhap();
            tt.TenNhanVien = "Hoang Thai Son";
            tt.MaNhanVien = "NV011";
            string mk = "12345";
            TTDangNhap tt2 = DangNhapBll.LayThongTinDangNhap("sonht", mk);
            Assert.AreEqual(tt.MaNhanVien, tt2.MaNhanVien);
            Assert.AreEqual(tt.TenNhanVien, tt2.TenNhanVien);

            NhanVienBll nvbll = new NhanVienBll();
            NhanVien nv = new NhanVien("NV011");
            Assert.AreEqual(1, nvbll.DeleteNhanVien(nv));
        }
        // Test đăng nhập xong thêm phiếu nhập hàng
        [TestMethod]
        public void Test_DangNhapThemPhieuNhap()
        {
            TTDangNhap tt = new TTDangNhap();
            tt.TenNhanVien = "Nguyễn Vũ Xuân Thu";
            tt.MaNhanVien = "NV002";
            string mk = DangNhapBll.GetMD5("thu");
            TTDangNhap tt2 = DangNhapBll.LayThongTinDangNhap("thu", mk);
            Assert.AreEqual(tt.MaNhanVien, tt2.MaNhanVien);
            Assert.AreEqual(tt.TenNhanVien, tt2.TenNhanVien);

            Assert.AreEqual(true, themPN("NV002", "PN031", new DateTime(2015, 3, 1)));

            CTPhieuNhap info = new CTPhieuNhap();
            info.MaMatHang = "MH003";
            info.MaNCC = "NCC001";
            info.MaPhieuNhap = "PN031";
            info.SoLuong = 3;
            Assert.AreEqual(true, themCTPN(info));
        }
        //Test Thêm nhân viên xong thêm phiếu nhập
        [TestMethod]
        public void Test_ThemNhanVienThemPhieuNhap()
        {
            NhanVienBll nvbll = new NhanVienBll();
            NhanVien nv = new NhanVien("NV020");
            nv.TenNhanVien = "Cao Hoang Phuc";
            nv.GioiTinh = "Nam";
            nv.NgaySinh = new DateTime(1991, 12, 13).Date;
            nv.PhongBan = "Bán Hàng";
            nv.DiaChi = "TPHCM";
            nv.SDT = "0983728172";
            nv.CMND = "083746153";
            nv.TenDangNhap = "phucch";
            nv.MatKhau = "12345";
            byte[] Hinh = new byte[0];
            nv.Hinh = Hinh;
            Assert.AreEqual(1, nvbll.InsertNhanVien(nv));

            Assert.AreEqual(true, themPN("NV020", "PN032", new DateTime(2015, 4, 1)));

            CTPhieuNhap info = new CTPhieuNhap();
            info.MaMatHang = "MH002";
            info.MaNCC = "NCC002";
            info.MaPhieuNhap = "PN032";
            info.SoLuong = 3;
            Assert.AreEqual(true, themCTPN(info));
        }
		// Test thêm giới tính xong sửa giới tính
        [TestMethod]
        public void Test_ThemSuaGioiTinh()
        {
            GioiTinhBll gtbll = new GioiTinhBll();
            GioiTinh gioiTinh = new GioiTinh("GT004", "Không xác định");
            Assert.AreEqual(1, gtbll.InsertGioiTinh(gioiTinh));

            gioiTinh.TenGioiTinh = "Không";
            Assert.AreEqual(1, gtbll.UpdateGioiTinh(gioiTinh));
        }
        // Test Thêm giới tính xong xoá giới tính
        [TestMethod]
        public void Test_ThemXoaGioiTinh()
        {
            GioiTinhBll gtbll = new GioiTinhBll();
            GioiTinh gioiTinh = new GioiTinh("GT005", "Không xác định");
            Assert.AreEqual(1, gtbll.InsertGioiTinh(gioiTinh));

            Assert.AreEqual(1, gtbll.DeleteGioiTinh(gioiTinh));
        }

        // Test thêm giới tính xong thêm nhân viên
        [TestMethod]
        public void Test_ThemGioiTinhThemNhanVien()
        {
            GioiTinhBll gtbll = new GioiTinhBll();
            GioiTinh gioiTinh = new GioiTinh("GT005", "BD");
            Assert.AreEqual(1, gtbll.InsertGioiTinh(gioiTinh));

            NhanVienBll nvbll = new NhanVienBll();
            NhanVien nv = new NhanVien("NV009");
            nv.TenNhanVien = "Nguyen Ngoc Van";
            nv.GioiTinh = "BD";
            nv.NgaySinh = new DateTime(1990, 09, 01).Date;
            nv.PhongBan = "Quản Trị";
            nv.DiaChi = "TPHCM";
            nv.SDT = "0928374282";
            nv.CMND = "827348190";
            nv.TenDangNhap = "vannn";
            nv.MatKhau = "12345";
            byte[] Hinh = new byte[0];
            nv.Hinh = Hinh;
            Assert.AreEqual(1, nvbll.InsertNhanVien(nv));
        }
		// Test đăng nhập xong thêm giới tính
        [TestMethod]
        public void Test_DangNhapThemGioiTinh()
        {
            TTDangNhap tt = new TTDangNhap();
            tt.TenNhanVien = "Nguyễn Vũ Xuân Thu";
            tt.MaNhanVien = "NV002";
            string mk = DangNhapBll.GetMD5("thu");
            TTDangNhap tt2 = DangNhapBll.LayThongTinDangNhap("thu", mk);
            Assert.AreEqual(tt.MaNhanVien, tt2.MaNhanVien);
            Assert.AreEqual(tt.TenNhanVien, tt2.TenNhanVien);

            GioiTinhBll gtbll = new GioiTinhBll();
            GioiTinh gioiTinh = new GioiTinh("GT006", "abc");
            Assert.AreEqual(1, gtbll.InsertGioiTinh(gioiTinh));
        }
        // Test đăng nhập xong sửa giới tính
        [TestMethod]
        public void Test_DangNhapSuaGioiTinh()
        {
            TTDangNhap tt = new TTDangNhap();
            tt.TenNhanVien = "Nguyễn Vũ Xuân Thu";
            tt.MaNhanVien = "NV002";
            string mk = DangNhapBll.GetMD5("thu");
            TTDangNhap tt2 = DangNhapBll.LayThongTinDangNhap("thu", mk);
            Assert.AreEqual(tt.MaNhanVien, tt2.MaNhanVien);
            Assert.AreEqual(tt.TenNhanVien, tt2.TenNhanVien);

            GioiTinhBll gtbll = new GioiTinhBll();
            GioiTinh gioiTinh = new GioiTinh("GT005", "BĐ");
            Assert.AreEqual(1, gtbll.UpdateGioiTinh(gioiTinh));
        }
        // Test đăng nhập xong xoá giới tính
        [TestMethod]
        public void Test_DangNhapXoaGioiTinh()
        {
            TTDangNhap tt = new TTDangNhap();
            tt.TenNhanVien = "Nguyễn Vũ Xuân Thu";
            tt.MaNhanVien = "NV002";
            string mk = DangNhapBll.GetMD5("thu");
            TTDangNhap tt2 = DangNhapBll.LayThongTinDangNhap("thu", mk);
            Assert.AreEqual(tt.MaNhanVien, tt2.MaNhanVien);
            Assert.AreEqual(tt.TenNhanVien, tt2.TenNhanVien);

            GioiTinhBll gtbll = new GioiTinhBll();
            GioiTinh gioiTinh = new GioiTinh("GT004");
            Assert.AreEqual(1, gtbll.DeleteGioiTinh(gioiTinh));
        }
		
        public bool themPN(string maNV, string maPN, DateTime ngay)
        {
            PhieuNhapDao pnd = new PhieuNhapDao();
            PhieuNhap info = new PhieuNhap();
            info.MaNhanVien = maNV;
            info.MaPhieuNhap = maPN;
            info.NgayHoaDon = ngay;
            pnd.ThemPN(info);
            return true;
        }

        public bool themCTPN(QuanLySieuThiDienThoai.DTO.CTPhieuNhap info)
        {
            PhieuNhapDao pnd = new PhieuNhapDao();
            pnd.ThemCTPN(info);
            return true;
        }
    }
}
