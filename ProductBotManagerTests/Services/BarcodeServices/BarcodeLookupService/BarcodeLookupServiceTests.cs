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
        int expected = 10;

        //logic
        int actual = 10;
        Assert.AreEqual(expected,actual, $"Expected: {expected}, but actual:{actual}");
    }
}