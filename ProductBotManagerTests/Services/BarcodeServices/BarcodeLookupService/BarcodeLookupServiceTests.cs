using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductBotManager.Services.BarcodeServices.BarcodeLookupService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBotManager.Services.BarcodeServices.BarcodeLookupService.Tests;

[TestClass()]
public class BarcodeLookupServiceTests
{
    [TestMethod()]
    public void GetTest()
    {
        string expected = "3 Pack Schedro Ketchup Delicate GMO Free 9 OZ / 250 Gr Product of Ukraine";

        //logic
        BarcodeLookupService service = new ();

        string actual = service.Get("4823097405932").Result.Name;
        Assert.AreEqual(expected,actual, $"Expected: {expected}, but actual:{actual}");
    }
}