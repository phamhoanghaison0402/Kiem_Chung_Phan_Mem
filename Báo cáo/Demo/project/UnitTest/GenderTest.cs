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
using System.Data;
using System.Xml;

namespace UnitTest
{
    [TestClass]
    public class GenderTest
    {
        // Test Gioi Tinh DTO
        // Test get set mã giới tính
        [TestMethod]
        public void Test_MaGioiTinh()
        {
            GioiTinh gt = new GioiTinh("GT001");

            Assert.AreEqual("GT001", gt.MaGioiTinh);
        }
        // Test get set tên giới tính
        [TestMethod]
        public void Test_TenGioiTinh()
        {
            GioiTinh gt = new GioiTinh("GT001") { TenGioiTinh = "Nam" };

            Assert.AreEqual("Nam", gt.TenGioiTinh);
        }
        // Test hàm khởi tạo giới tính
        [TestMethod]
        public void Test_HamKhoiTaoGioiTinh()
        {
            GioiTinh gt = new GioiTinh("GT001", "Nam");

            Assert.AreEqual("GT001", gt.MaGioiTinh);
            Assert.AreEqual("Nam", gt.TenGioiTinh);
        }

        // Test GioiTinh BLL
        //Test lấy danh sách giới tính
        [TestMethod]
        public void Test_SelectAllGioiTinh()
        {
            GioiTinhBll gtbll = new GioiTinhBll();
            DataTable table = new DataTable();
            table.Columns.Add("MaGioiTinh", typeof(System.String));
            table.Columns.Add("TenGioiTinh", typeof(System.String));

            DataRow dataRow1 = table.NewRow();
            dataRow1["MaGioiTinh"] = "GT001";
            dataRow1["TenGioiTinh"] = "Nam";
            table.Rows.Add(dataRow1);

            DataRow dataRow2 = table.NewRow();
            dataRow2["MaGioiTinh"] = "GT002";
            dataRow2["TenGioiTinh"] = "Nữ";
            table.Rows.Add(dataRow2);

            Assert.AreEqual(true, CompareDataTables(table, gtbll.SelectAllGioiTinh()));
        }
        //Test lấy danh sách tên giới tính
        [TestMethod]
        public void Test_SelectTenGioiTinh()
        {
            GioiTinhBll gtbll = new GioiTinhBll();
            DataTable table = new DataTable();
            table.Columns.Add("TenGioiTinh", typeof(System.String));

            DataRow dataRow1 = table.NewRow();
            dataRow1["TenGioiTinh"] = "Nam";
            table.Rows.Add(dataRow1);

            DataRow dataRow2 = table.NewRow();
            dataRow2["TenGioiTinh"] = "Nữ";
            table.Rows.Add(dataRow2);

            Assert.AreEqual(true, CompareDataTables(table, gtbll.SelectTenGioiTinh()));
        }
        // Test hàm thêm giới tính đúng BLL
        [TestMethod]
        public void Test_ThemGioiTinh()
        {
            GioiTinhBll gtbll = new GioiTinhBll();
            GioiTinh gioiTinh = new GioiTinh("GT003", "Không xác định");
            Assert.AreEqual(1, gtbll.InsertGioiTinh(gioiTinh));
        }
        // Test hàm thêm giới tính sai BLL
        [TestMethod]
        public void Test_ThemGioiTinhSai()
        {
            GioiTinhBll gtbll = new GioiTinhBll();
            GioiTinh gioiTinh = new GioiTinh("GT001", "");
            Assert.AreEqual(-1, gtbll.InsertGioiTinh(gioiTinh));
        }
        // Test hàm thêm giới tính sai BLL
        [TestMethod]
        public void Test_ThemGioiTinhSai2()
        {
            GioiTinhBll gtbll = new GioiTinhBll();
            GioiTinh gioiTinh = new GioiTinh("GT004", null);
            Assert.AreEqual(-1, gtbll.InsertGioiTinh(gioiTinh));
        }
        // Test hàm update giới tính sai BLL
        [TestMethod]
        public void Test_UpdateGioiTinhSai()
        {

            GioiTinhBll gtbll = new GioiTinhBll();
            GioiTinh gt = new GioiTinh("GT003", null);
            Assert.AreEqual(-1, gtbll.UpdateGioiTinh(gt));
        }

        // Test hàm update giới tính đúng BLL
        [TestMethod]
        public void Test_UpdateGioiTinh()
        {

            GioiTinhBll gtbll = new GioiTinhBll();
            GioiTinh gt = new GioiTinh("GT003");
            gt.TenGioiTinh = "Không";
            Assert.AreEqual(1, gtbll.UpdateGioiTinh(gt));
        }

        // Test hàm xoá giới tính đúng BLL
        [TestMethod]
        public void Test_DeleteGioiTinh()
        {
            GioiTinhBll gtbll = new GioiTinhBll();
            GioiTinh gt = new GioiTinh("GT003");
            Assert.AreEqual(1, gtbll.DeleteGioiTinh(gt));
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
