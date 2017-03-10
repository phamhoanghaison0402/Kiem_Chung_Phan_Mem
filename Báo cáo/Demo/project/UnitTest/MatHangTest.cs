using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using QuanLySieuThiDienThoai.DTO;

namespace UnitTest
{
    [TestClass]
    public class MatHangTest
    {

        public void Test_MaMatHang(string expected, string actual)
        {
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_MaMatHang_1()
        {
            MatHang obj = new MatHang("MH001");
            string expected = "MH001";
            Test_MaMatHang(expected, obj.MaMatHang);
        }
        [TestMethod]
        public void Test_MaMatHang_2()
        {
            MatHang obj = new MatHang("MH00141");
            string expected = "MH00141";
            Test_MaMatHang(expected, obj.MaMatHang);
        }
        [TestMethod]
        public void Test_MaMatHang_3()
        {
            MatHang obj = new MatHang("~MH00141");
            string expected = "~MH00141";
            Test_MaMatHang(expected, obj.MaMatHang);
        }
        [TestMethod]
        public void Test_TenMatHang_1()
        {
            MatHang obj = new MatHang("MH001", "DienThoai", "Apple", new Byte[12341], 4, 8, 100000, 320000);
            string expected = "DienThoai";
            Assert.AreEqual(expected, obj.TenMatHang);
        }
        [TestMethod]
        public void Test_TenMatHang_2()
        {
            MatHang obj = new MatHang("MH001", "DienThoai", "Apple", new Byte[12341], 4, 8, 100000, 320000);
            string actual = "DienThoaiA";
            Assert.AreNotEqual(obj.TenMatHang, actual);
        }
        [TestMethod]
        public void Test_TenMatHang_3()
        {
            MatHang obj = new MatHang("MH001", "DienThoai", "Apple", new Byte[12341], 4, 8, 100000, 320000);
            string actual = "  DienThoai";
            Assert.AreNotEqual(obj.TenMatHang, actual);
        }
    }
}
