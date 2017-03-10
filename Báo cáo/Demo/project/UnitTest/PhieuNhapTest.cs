using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLySieuThiDienThoai.DTO;
using QuanLySieuThiDienThoai.DAO;
using DAO;
using DTO;
using QuanLySieuThiDienThoai;
using QuanLySieuThiDienThoai.BLL;

namespace UnitTest
{
    [TestClass]
    public class PhieuNhapTest
    {
        [TestMethod]
        public void Test_maNhanVien_1()
        {
            PhieuNhap pn = new PhieuNhap();
            pn.MaNhanVien = "NV001";
            Assert.AreEqual("NV001", pn.MaNhanVien);
        }
        [TestMethod]
        public void Test_maNhanVien_2()
        {
            PhieuNhap pn = new PhieuNhap();
            pn.MaNhanVien = "NV001~@!";
            Assert.AreEqual("NV001~@!", pn.MaNhanVien);
        }
        [TestMethod]
        public void Test_maNhanVien_3()
        {
            PhieuNhap pn = new PhieuNhap();
            pn.MaNhanVien = "...NV001~@!";
            Assert.AreEqual("...NV001~@!", pn.MaNhanVien);
        }
        [TestMethod]
        public void Test_maPhieuNhap_1()
        {
            PhieuNhap pn = new PhieuNhap();
            pn.MaPhieuNhap = "PN003";
            Assert.AreEqual("PN003", pn.MaPhieuNhap);
        }
        [TestMethod]
        public void Test_maPhieuNhap_2()
        {
            PhieuNhap pn = new PhieuNhap();
            pn.MaPhieuNhap = "PN003!@#";
            Assert.AreEqual("PN003!@#", pn.MaPhieuNhap);
        }
        [TestMethod]
        public void Test_maPhieuNhap_3()
        {
            PhieuNhap pn = new PhieuNhap();
            pn.MaPhieuNhap = "....PN003!@#";
            Assert.AreEqual("....PN003!@#", pn.MaPhieuNhap);
        }

        [TestMethod]
        public void Test_ngayHoaDon_1()
        {
            PhieuNhap pn = new PhieuNhap();
            pn.NgayHoaDon = new DateTime(2015,1,3);
            Assert.AreEqual(2015, pn.NgayHoaDon.Year);
            Assert.AreEqual(1, pn.NgayHoaDon.Month);
            Assert.AreEqual(3, pn.NgayHoaDon.Day);
        }

        [TestMethod]
        public void Test_ngayHoaDon_2()
        {
            PhieuNhap pn = new PhieuNhap();
            pn.NgayHoaDon = new DateTime(201, 12, 3);
            Assert.AreNotEqual(-1999, pn.NgayHoaDon.Year);
            Assert.AreNotEqual(13, pn.NgayHoaDon.Month);
            Assert.AreNotEqual(32, pn.NgayHoaDon.Day);
        }

        [TestMethod]
        public void Test_ngayHoaDon_3()
        {
            PhieuNhap pn = new PhieuNhap();
            pn.NgayHoaDon = new DateTime(2145, 2, 28);
            Assert.AreEqual(2145, pn.NgayHoaDon.Year);
            Assert.AreNotEqual(-3, pn.NgayHoaDon.Month);
            Assert.AreNotEqual(29, pn.NgayHoaDon.Day);
        }
    }
}
