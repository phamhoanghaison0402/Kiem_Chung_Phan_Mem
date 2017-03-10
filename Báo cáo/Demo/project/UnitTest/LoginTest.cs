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
    public class LoginTest
    {
        // Test TTDangNhap DTO
        // Test get set mã nhân viên
        [TestMethod]
        public void Test_MaNhanVien()
        {
            TTDangNhap ttdn = new TTDangNhap() { MaNhanVien = "thu" };

            Assert.AreEqual("thu", ttdn.MaNhanVien);

        }
        // Test get set tên nhân viên
        [TestMethod]
        public void Test_TenNhanVien()
        {
            TTDangNhap ttdn = new TTDangNhap() { TenNhanVien = "thu" };

            Assert.AreEqual("thu", ttdn.TenNhanVien);

        }
        // Test get set phòng ban
        [TestMethod]
        public void Test_PhongBan()
        {
            TTDangNhap ttdn = new TTDangNhap() { PhongBan = "PB001" };

            Assert.AreEqual("PB001", ttdn.PhongBan);

        }     

        // Test DangNhap BLL
        // Test hàm đăng nhập đúng BLL
        [TestMethod]
        public void Test_DangNhap()
        {

            TTDangNhap tt = new TTDangNhap();
            tt.TenNhanVien = "Nguyễn Vũ Xuân Thu";
            tt.MaNhanVien = "NV002";
            string mk = DangNhapBll.GetMD5("thu");
            TTDangNhap tt2 = DangNhapBll.LayThongTinDangNhap("thu",mk);
            Assert.AreEqual(tt.MaNhanVien , tt2.MaNhanVien);
            Assert.AreEqual(tt.TenNhanVien, tt2.TenNhanVien);
        }
        // Test hàm đăng nhập BLL khi để trống tài khoản và mật khẩu
        [TestMethod]
        public void Test_DangNhapSai2()
        {

            TTDangNhap tt = new TTDangNhap();
            tt.TenNhanVien = "Nguyễn Vũ Xuân Thu";
            tt.MaNhanVien = "NV002";
            TTDangNhap tt2 = DangNhapBll.LayThongTinDangNhap("", "");
            Assert.AreNotEqual(tt.MaNhanVien, tt2.MaNhanVien);
            Assert.AreNotEqual(tt.TenNhanVien, tt2.TenNhanVien);
        }
        // Test hàm đăng nhập sai BLL
        [TestMethod]
        public void Test_DangNhapSai()
        {

            TTDangNhap tt = new TTDangNhap();
            tt.TenNhanVien = "Nguyễn Vũ Xuân Thu";
            tt.MaNhanVien = "NV002";
            string mk = DangNhapBll.GetMD5("abc");
            TTDangNhap tt2 = DangNhapBll.LayThongTinDangNhap("bcd", mk);
            Assert.AreNotEqual(tt.MaNhanVien, tt2.MaNhanVien);
            Assert.AreNotEqual(tt.TenNhanVien, tt2.TenNhanVien);
        }
    }
}
