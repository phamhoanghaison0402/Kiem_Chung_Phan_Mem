using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace AutomationTest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest
    {
        public CodedUITest()
        {

        }
        //----------Login--------//
        // Automation Test Login đúng
        [TestMethod]
        public void Test_Login()
        {
            this.UIMap.Login();
        }
        // Automation Test Login sai khi để trống
        [TestMethod]
        public void Test_LoginEmpty()
        {
            this.UIMap.LoginEmpty();
        }
        // Automation Test Login sai khi nhập sai tên tài khoản hoặc mật khẩu
        [TestMethod]
        public void Test_LoginError()
        {
            this.UIMap.LoginError();
        }       


        //----------Nhân viên--------//
        // Automation Test thêm nhân viên đúng
        [TestMethod]
        public void Test_AddEmployee()
        {
            this.UIMap.AddEmployee();
        }
        // Automation Test thêm nhân viên sai khi bỏ trống các trường dữ liệu
        [TestMethod]
        public void Test_AddEmployeeEmpty()
        {
            this.UIMap.AddEmployeeEmpty();
        }
        // Automation Test thêm nhân viên sai khi nhập sai kiểu dữ liệu của các trường dữ liệu
        [TestMethod]
        public void Test_AddEmployeeError()
        {
            this.UIMap.AddEmployeeError();
        }
        // Automation Test sửa nhân viên đúng
        [TestMethod]
        public void Test_UpdateEmployee()
        {
            this.UIMap.UpdateEmployee();
        }
        // Automation Test sửa nhân viên sai khi bỏ trống các trường
        [TestMethod]
        public void Test_UpdateEmployeeEmpty()
        {
            this.UIMap.UpdateEmployeeEmpty();
        }
        // Automation Test sửa nhân viên sai khi nhập sai kiểu dữ liệu các trường
        [TestMethod]
        public void Test_UpdateEmployeeError()
        {
            this.UIMap.UpdateEmployeeError();
        }
        // Automation Test xoá nhân viên đúng
        [TestMethod]
        public void Test_DeleteEmployee()
        {
            this.UIMap.DeleteEmployee();
        }

        // Automation Test thêm nhập hàng đúng
        [TestMethod]
        public void Test_ThemNhapHang()
        {

            this.UIMap.ThemPhieuNhapHang();

        }
        // Automation Test thêm nhập hàng sai
        [TestMethod]
        public void Test_ThemNhapHangSai()
        {
            this.UIMap.ThemPhieuNhapHangSai();
        }
        // Automation Test in phiếu nhập hàng sai
        [TestMethod]
        public void Test_InPhieuNhapHang()
        {

            this.UIMap.InPhieuNhapHang();

        }

        // Automation Test Thêm giới tính đúng
        [TestMethod]
        public void Test_AddGender()
        {

            this.UIMap.AddGender();

        }
        // Automation Test Thêm giới tính sai
        [TestMethod]
        public void Test_AddGenderError()
        {

            this.UIMap.AddGenderError();

        }
        // Automation Test Sửa giới tính đúng
        [TestMethod]
        public void Test_UpdateGender()
        {

            this.UIMap.UpdateGender();

        }
        // Automation Test Sửa giới tính sai
        [TestMethod]
        public void Test_UpdateGenderError()
        {

            this.UIMap.UpdateGenderError();

        }
        // Automation Test Xoá giới tính đúng
        [TestMethod]
        public void Test_DeleteGender()
        {

            this.UIMap.DeleteGender();

        }
        // Automation Test Xoá giới tính sai
        [TestMethod]
        public void Test_DeleteGenderError()
        {

            this.UIMap.DeleteGenderError();

        }


        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
