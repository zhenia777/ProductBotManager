using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductBotManager.Services.UpcitemdbService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.UpcitemdbService.Tests
{
    [TestClass()]
    public class UpcitemdbServiceTests
    {
        [TestMethod()]
        public void GetTest()
        {
            string expected = "4x 100 Gr - Milka White Chocolate Bars - White Milk Chocolates - Delicious";
            UpcitemdbService service = new UpcitemdbService();
            string actual = service.Get("4025700001962").Result.Name;
            Assert.AreEqual(expected, actual);

        }
    }
}