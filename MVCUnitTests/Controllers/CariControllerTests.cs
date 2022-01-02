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
            var controller = new CariController();
            var result = controller.YeniCari() as ViewResult;
            Assert.AreEqual("", result.ViewName);
        }
    }
}