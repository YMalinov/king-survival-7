using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingSurvival;

namespace KingSurvivalTest
{
    [TestClass]
    public class ChessPieceTest
    {
        [TestMethod]
        public void TestChestPieceConstructorX()
        {
            char excpected = 'K';
            Coordinates newCoordinates = new Coordinates(2,3);
            int x = newCoordinates.X;
            int y = newCoordinates.Y;
            ChessPiece testPiece = new ChessPiece(excpected,newCoordinates);
            Assert.AreEqual(x, testPiece.X);
        }

        [TestMethod]
        public void TestChestPieceConstructorY()
        {
            char excpected = 'K';
            Coordinates newCoordinates = new Coordinates(2, 3);
            int x = newCoordinates.X;
            int y = newCoordinates.Y;
            ChessPiece testPiece = new ChessPiece(excpected, newCoordinates);
            Assert.AreEqual(y, testPiece.Y);
        }

        [TestMethod]
        public void TestChestPieceSecondaryConstructorX()
        {
            char excpected = 'K';            
            ChessPiece testPiece = new ChessPiece(excpected, 2 ,3);
            int x = 2;
            Assert.AreEqual(x, testPiece.X);
        }

        [TestMethod]
        public void TestChestPieceSecondaryConstructorY()
        {
            char excpected = 'K';
            ChessPiece testPiece = new ChessPiece(excpected, 2, 3);
            int y = 3;
            Assert.AreEqual(y, testPiece.Y);
        }
    }
}
