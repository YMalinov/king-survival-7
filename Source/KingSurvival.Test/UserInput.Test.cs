using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival;

namespace KingSurvivalTest
{
    [TestClass]
    public class UserInputTest
    {
        [TestMethod]
        public void TestInputTestKing()
        {
            Player King = Player.King;
            string expected = "KUL";
            Console.SetIn(new System.IO.StringReader("kul"));
            string received = UserInput.GetInput(King);
            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void TestInputTestPawn()
        {
            Player King = Player.Pawn;
            string expected = "BDL";
            Console.SetIn(new System.IO.StringReader("bdl"));
            string received = UserInput.GetInput(King);
            Assert.AreEqual(expected, received);
        }
    }
}
