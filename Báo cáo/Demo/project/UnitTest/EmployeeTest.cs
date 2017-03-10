using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Drawing;
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
    public class EmployeeTest
    {
        //Test NhanVien DTO
        // Test get set mã nhân viên
        [TestMethod]
        public void Test_maNhanVien()
        {
            NhanVien nv = new NhanVien("NV002");

            Assert.AreEqual(nv.MaNhanVien, "NV002");
        }
        // Test get set tên nhân viên
        [TestMethod]
        public void Test_tenNhanVien()
        {
            NhanVien nv = new NhanVien("NV002") { TenNhanVien = "Nguyễn Vũ Xuân Thu" };

            Assert.AreEqual("Nguyễn Vũ Xuân Thu", nv.TenNhanVien);
        }
        // Test get set ngay sinh   
        [TestMethod]
        public void Test_NgaySinh()
        {
            NhanVien nv = new NhanVien("NV002") { NgaySinh = new DateTime(1992, 09, 10) };

            Assert.AreEqual(new DateTime(1992, 09, 10), nv.NgaySinh);
        }
        // Test get set giới tính
        [TestMethod]
        public void Test_gioiTinh()
        {
            NhanVien nv = new NhanVien("NV002") { GioiTinh = "Nữ" };

            Assert.AreEqual("Nữ", nv.GioiTinh);
        }
        // Test get set CMND
        [TestMethod]
        public void Test_CMND()
        {
            NhanVien nv = new NhanVien("NV002") { CMND = "123456789" };

            Assert.AreEqual("123456789", nv.CMND);
        }
        // Test getset địa chỉ
        [TestMethod]
        public void Test_DiaChi()
        {
            NhanVien nv = new NhanVien("NV002") { DiaChi = "Daklak" };

            Assert.AreEqual("Daklak", nv.DiaChi);
        }
        // Test get set số điện thoại
        [TestMethod]
        public void Test_SDT()
        {
            NhanVien nv = new NhanVien("NV002") { SDT = "1234567890" };

            Assert.AreEqual("1234567890", nv.SDT);
        }
        // Test get set phòng ban
        [TestMethod]
        public void Test_phongBan()
        {
            NhanVien nv = new NhanVien("NV002") { PhongBan = "PB001" };

            Assert.AreEqual("PB001", nv.PhongBan);
        }
        // Test get set tên đăng nhập
        [TestMethod]
        public void Test_tenDangNhap()
        {
            NhanVien nv = new NhanVien("NV002") { TenDangNhap = "Thu" };

            Assert.AreEqual("Thu", nv.TenDangNhap);
        }

        // Test NhanVien BLL
        //Test lấy danh sách tìm kiếm nhân viên
        [TestMethod]
        public void Test_SearchNhanVien()
        {
            NhanVienBll nvbll = new NhanVienBll();
            DataTable table = new DataTable();
            table.Columns.Add("MaNhanVien", typeof(System.String));
            table.Columns.Add("TenNhanVien", typeof(System.String));
            table.Columns.Add("NgaySinh", typeof(System.DateTime));
            table.Columns.Add("GioiTinh", typeof(System.String));
            table.Columns.Add("CMND", typeof(System.String));
            table.Columns.Add("DiaChi", typeof(System.String));
            table.Columns.Add("SDT", typeof(System.String));
            table.Columns.Add("Hinh", typeof(System.Byte[]));
            table.Columns.Add("PhongBan", typeof(System.String));
            table.Columns.Add("TenDangNhap", typeof(System.String));
            table.Columns.Add("MatKhau", typeof(System.String));

            DataRow dataRow1 = table.NewRow();
            dataRow1["MaNhanVien"] = "NV004";
            dataRow1["TenNhanVien"] = "Phùng Duy Lương";
            dataRow1["NgaySinh"] = new DateTime(1994, 11, 11).Date;
            dataRow1["GioiTinh"] = "Nam";
            dataRow1["CMND"] = "4324324324";
            dataRow1["DiaChi"] = "HCM";
            dataRow1["SDT"] = "4324532";
            dataRow1["Hinh"] = null;
            dataRow1["PhongBan"] = "Quản Trị";
            dataRow1["TenDangNhap"] = "Luong";
            dataRow1["MatKhau"] = "Luong";
            table.Rows.Add(dataRow1);

            Assert.AreEqual(true, CompareDataTables(table, nvbll.SearchNhanVien("NV004")));
        }
        // Test hàm thêm nhân viên đúng BLL
        [TestMethod]
        public void Test_ThemNhanVien()
        {
            NhanVienBll nvbll = new NhanVienBll();
            NhanVien nv = new NhanVien("NV006");
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
        }
        // Test hàm thêm nhân viên sai BLL khi để trống các trường dữ liệu
        [TestMethod]
        public void Test_ThemNhanVienSai()
        {
            NhanVienBll nvbll = new NhanVienBll();
            NhanVien nv = new NhanVien("NV006");
            nv.TenNhanVien = "";
            nv.GioiTinh = "";
            nv.NgaySinh = new DateTime(1992, 02, 03).Date;
            nv.PhongBan = "";
            nv.DiaChi = "";
            nv.SDT = "";
            nv.CMND = "";
            nv.TenDangNhap = "";
            nv.MatKhau = "";
            byte[] Hinh = new byte[0];
            nv.Hinh = Hinh;
            Assert.AreEqual(-1, nvbll.InsertNhanVien(nv));
        }
        // Test hàm thêm nhân viên sai BLL khi trùng mã nhân viên
        [TestMethod]
        public void Test_ThemNhanVienSai2()
        {
            NhanVienBll nvbll = new NhanVienBll();
            NhanVien nv = new NhanVien("NV005");
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
            Assert.AreEqual(-1, nvbll.InsertNhanVien(nv));
        }
        // Test hàm update nhân viên đúng BLL
        [TestMethod]
        public void Test_SuaNhanVien()
        {
            NhanVienBll nvbll = new NhanVienBll();
            NhanVien nv = new NhanVien("NV006");
            nv.TenNhanVien = "Nguyen Ngoc Han";
            nv.GioiTinh = "Nữ";
            nv.NgaySinh = new DateTime(1992, 02, 03).Date;
            nv.PhongBan = "Quản Trị";
            nv.DiaChi = "Vũng Tàu";
            nv.SDT = "0928138293";
            nv.CMND = "098217321";
            nv.TenDangNhap = "hannn";
            nv.MatKhau = "12345";
            byte[] Hinh = new byte[0];
            nv.Hinh = Hinh;
            Assert.AreEqual(1, nvbll.UpdateNhanVien(nv));
        }
        // Test hàm update nhân viên sai BLL
        [TestMethod]
        public void Test_SuaNhanVienSai()
        {
            NhanVienBll nvbll = new NhanVienBll();
            NhanVien nv = new NhanVien("NV006");
            nv.TenNhanVien = "Nguyen Ngoc Han";
            nv.GioiTinh = "123";
            nv.NgaySinh = new DateTime(1992, 02, 03).Date;
            nv.PhongBan = "123";
            nv.DiaChi = "Vũng Tàu";
            nv.SDT = "qwww";
            nv.CMND = "ddd";
            nv.TenDangNhap = "hannn";
            nv.MatKhau = "12345";
            byte[] Hinh = new byte[0];
            nv.Hinh = Hinh;
            Assert.AreEqual(-1, nvbll.UpdateNhanVien(nv));
        }
        // Test hàm update nhân viên sai BLL khi bỏ trống dữ liệu
        [TestMethod]
        public void Test_SuaNhanVienSai2()
        {
            NhanVienBll nvbll = new NhanVienBll();
            NhanVien nv = new NhanVien("NV006");
            nv.TenNhanVien = null;
            nv.GioiTinh = "Nam";
            nv.NgaySinh = new DateTime(1992, 02, 03).Date;
            nv.PhongBan = "Quản Trị";
            nv.DiaChi = "";
            nv.SDT = "";
            nv.CMND = null;
            nv.TenDangNhap = null;
            nv.MatKhau = null;
            byte[] Hinh = new byte[0];
            nv.Hinh = Hinh;
            Assert.AreEqual(-1, nvbll.UpdateNhanVien(nv));
        }
        // Test hàm xoá nhân viên đúng BLL
        [TestMethod]
        public void Test_XoaNhanVien()
        {
            NhanVienBll nvbll = new NhanVienBll();
            NhanVien nv = new NhanVien("NV006");
            Assert.AreEqual(1, nvbll.DeleteNhanVien(nv));
        }

        // Hàm so sánh 2 datatable
        private bool CompareDataTables(DataTable DT1, DataTable DT2)
        {
            if ((DT1 == null) && (DT2 == null))
                return true;
            else if ((DT1 != null) && (DT2 != null))
            {
                if (DT1.Rows.Count == DT2.Rows.Count)
                {
                    if (DT1.Columns.Count == DT2.Columns.Count)
                    {
                        for (int i = 0; i < DT1.Rows.Count; i++)
                        {
                            for (int j = 0; j < DT1.Columns.Count; j++)
                            {
                                if (DT1.Rows[i][j].ToString() != DT2.Rows[i][j].ToString())
                                    return false;
                            }
                        }
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}
