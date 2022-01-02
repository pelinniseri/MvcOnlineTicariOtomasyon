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
    public class GaleriControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            var controller = new GaleriController();
            var result = controller.Index() as ViewResult;
            var degerler = result.ViewData.Model;
            Assert.IsNotNull(degerler);

        }
    }
}