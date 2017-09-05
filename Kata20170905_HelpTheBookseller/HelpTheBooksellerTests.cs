using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata20170905_HelpTheBookseller
{
    [TestClass]
    public class HelpTheBooksellerTests
    {
        [TestMethod]
        public void input_ABC_1_and_A_should_return_A_1()
        {
            StockSummaryShouldBe("(A : 1)", new[] { "ABC 1" }, new[] { "A" });
        }

        [TestMethod]
        public void input_ABC_2_and_A_should_return_A_2()
        {
            StockSummaryShouldBe("(A : 2)", new[] { "ABC 2" }, new[] { "A" });
        }

        [TestMethod]
        public void input_BC_2_and_A_should_return_A_0()
        {
            StockSummaryShouldBe("(A : 0)", new[] { "BC 2" }, new[] { "A" });
        }

        [TestMethod]
        public void input_AB_2_AC_1_and_A_should_return_A_3()
        {
            StockSummaryShouldBe("(A : 3)", new[] { "AB 2", "AC 1" }, new[] { "A" });
        }

        private static void StockSummaryShouldBe(string expected, string[] lstOfArt, string[] lstOf1StLetter)
        {
            var stockList = new StockList();
            var actual = stockList.stockSummary(lstOfArt, lstOf1StLetter);
            Assert.AreEqual(expected, actual);
        }
    }

    public class StockList
    {
        public string stockSummary(string[] lstOfArt, string[] lstOf1stLetter)
        {
            var artKey = lstOf1stLetter[0];
            var sum = 0;
            foreach (var art in lstOfArt)
            {
                var artKv = art.Split(' ');
                sum += artKv[0].First().ToString() == artKey ? int.Parse(artKv[1]) : 0;
            }

            return $"({artKey} : {sum})";
        }
    }
}
