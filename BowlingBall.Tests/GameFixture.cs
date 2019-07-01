using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingBall;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        Game game = new Game();
        private void RollMany(int n, int pins)
        {
            for (var i = 0; i < n; i++)
                game.Roll(pins);
        }

        private void RollMany(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
                game.Roll(arr[i]);
        }


        [TestMethod]
        public void TestZeroRoll()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void TestAllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, game.GetScore());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            game.Roll(6);
            game.Roll(4);
            game.Roll(3);
            RollMany(17, 3);
            Assert.AreEqual(67, game.GetScore());
        }

        [TestMethod]
        public void TestOneStrike()
        {
            game.Roll(10);
            game.Roll(3);
            RollMany(17, 3);
            Assert.AreEqual(70, game.GetScore());
        }

        [TestMethod]
        public void TestAllSpare()
        {
            RollMany(new int[] { 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4, 6, 4 });
            game.Roll(6);
            Assert.AreEqual(160, game.GetScore());
        }

        [TestMethod]
        public void TestAllStrike()
        {
            RollMany(10, 10);
            game.Roll(10);
            game.Roll(10);
            Assert.AreEqual(300, game.GetScore());
        }

        [TestMethod]

        public void TestWithNoSpareAndStrike()
        {
            RollMany(10, 4);
            RollMany(10, 3);
            Assert.AreEqual(70, game.GetScore());
        }
    }
}
