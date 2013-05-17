using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival;

namespace KingSurvivalTest
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void TestPlayerEnumarationKing()
        {
            string invMove = "King";
            Assert.AreEqual(invMove, Player.King.ToString());
        }

        [TestMethod]
        public void TestPlayerEnumarationPawn()
        {
            string invMove = "Pawn";
            Assert.AreEqual(invMove, Player.Pawn.ToString());
        }
    }
}
