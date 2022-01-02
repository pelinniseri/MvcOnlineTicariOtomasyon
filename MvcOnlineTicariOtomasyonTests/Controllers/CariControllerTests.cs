using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcOnlineTicariOtomasyon.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers.Tests
{
    [TestClass()]
    public class CariControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            CariController objCariController = new CariController();
            ViewResult objViewResult = objCariController.Index() as ViewResult;
            Assert.AreEqual("Index", objViewResult.ViewName);
        }

        [TestMethod()]
        public void YeniCariTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void YeniCariTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CarisilTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CariGetirTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CariGuncelleTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MusteriSatisTest()
        {
            Assert.Fail();
        }
    }
}