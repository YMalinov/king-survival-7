using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival;

namespace KingSurvivalTest
{
    [TestClass]
    public class MessageTest
    {
        [TestMethod]
        public void MassageTest1()
        {
            string invMove = "InvalidMove";
            Assert.AreEqual(invMove, Message.InvalidMove.ToString());
        }

        [TestMethod]
        public void MassageTest2()
        {
            string invMove = "KingWin";
            Assert.AreEqual(invMove, Message.KingWin.ToString());
        }

        [TestMethod]
        public void MassageTest3()
        {
            string invMove = "KingLose";
            Assert.AreEqual(invMove, Message.KingLose.ToString());
        }
    }
}
