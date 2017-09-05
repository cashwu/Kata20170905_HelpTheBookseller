using System;
using System.Collections.Generic;
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

        [TestMethod]
        public void input_AB_2_BC_1_and_A_B_should_return_A_2_B_1()
        {
            StockSummaryShouldBe("(A : 2) - (B : 1)", new[] { "AB 2", "BC 1" }, new[] { "A", "B" });
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
            var result = lstOf1stLetter
                .Select(letter => $"({letter} : {SumOfLetter(lstOfArt, letter)})");

            return string.Join(" - ", result);
        }

        private static int SumOfLetter(string[] lstOfArt, string letter)
        {
            return lstOfArt.Where(a => a.StartsWith(letter)).Sum(a => int.Parse(a.Split(' ')[1]));
        }
    }
}
