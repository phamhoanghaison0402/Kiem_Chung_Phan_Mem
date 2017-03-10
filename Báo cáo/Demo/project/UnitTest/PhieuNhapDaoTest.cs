using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO;
using DTO;
using QuanLySieuThiDienThoai.DTO;
using QuanLySieuThiDienThoai.DAO;

namespace UnitTest
{
    [TestClass]
    public class PhieuNhapDaoTest
    {
        [TestMethod]
        public void Test_ThemPN_1()
        {
            Assert.AreEqual(true, themPN("NV002", "PN3131", new DateTime(2015, 3, 1)));
            
            //Assert.AreEqual(1, );
        }

        [TestMethod]
        public void Test_ThemPN_2()
        {
            Assert.AreNotEqual(true, themPN("00NV002", "PN3131", new DateTime(2015, 3, 1)));
            
            //Assert.AreEqual(1, );
        }

        [TestMethod]
        public void Test_ThemPN_3()
        {
            Assert.AreNotEqual(true, themPN("NVB$#001", "PN3131113", new DateTime(2015, 3, 1)));
            //Assert.AreEqual(1, );
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

        [TestMethod]
        public void Test_ThemCTPN_1()
        {
            CTPhieuNhap info = new CTPhieuNhap();
            info.MaMatHang = "MH003";
            info.MaNCC = "NCC001";
            info.MaPhieuNhap = "PN002";
            info.SoLuong = 3;
            Assert.AreEqual(true, themCTPN(info));
        }
        [TestMethod]
        public void Test_ThemCTPN_2()
        {
            CTPhieuNhap info = new CTPhieuNhap();
            info.MaMatHang = "MH005";
            info.MaNCC = "NCC0010";
            info.MaPhieuNhap = "PN002241";
            info.SoLuong = 3;
            Assert.AreNotEqual(true, themCTPN(info));
        }
        [TestMethod]
        public void Test_ThemCTPN_3()
        {
            CTPhieuNhap info = new CTPhieuNhap();
            info.MaMatHang = "MH0403";
            info.MaNCC = "bxsNCC001";
            info.MaPhieuNhap = "123`PN002";
            info.SoLuong = 3;
            Assert.AreNotEqual(true, themCTPN(info));
        }
        [TestMethod]
        public void Test_LayMaPhieuNhapMax_1()
        {
            String expected = "PN3131";
            PhieuNhapDao obj = new PhieuNhapDao();
            String actual = obj.LayMaPhieuNhapMax();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_LayMaPhieuNhapMax_2()
        {
            String expected = "PN3131414";
            PhieuNhapDao obj = new PhieuNhapDao();
            String actual = obj.LayMaPhieuNhapMax();
            Assert.AreNotEqual(expected, actual);
        }
        [TestMethod]
        public void Test_LayMaPhieuNhapMax_3()
        {
            String expected = "PN31";
            PhieuNhapDao obj = new PhieuNhapDao();
            String actual = obj.LayMaPhieuNhapMax();
            Assert.AreNotEqual(expected, actual);
        }
    }
}
