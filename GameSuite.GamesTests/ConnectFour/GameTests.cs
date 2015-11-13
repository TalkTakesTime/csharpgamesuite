using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameSuite.Games.ConnectFour.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void GameTest()
        {
            var b = new Game();
            Assert.IsTrue(b.Height == 6);
            Assert.IsTrue(b.Width == 7);
        }

        [TestMethod()]
        public void GameTest1()
        {
            var b = new Game(2, 5);
            Assert.IsTrue(b.Height == 2);
            Assert.IsTrue(b.Width == 5);
        }

        [TestMethod()]
        public void PlayTest()
        {
            var b = new Game();

            // test playing in invalid columns
            Assert.IsFalse(b.Play(new Move(1, 10)));

            // test invalid players
            Assert.IsFalse(b.Play(new Move(0, 3)));
            Assert.IsFalse(b.Play(new Move(3, 0)));

            // and try some correct plays
            Assert.IsTrue(b.Play(new Move(1, 0)));
            Assert.IsTrue(b.Play(new Move(2, 2)));

            // fill a column
            for (int i = 0; i < b.Height; i++)
            {
                Assert.IsTrue(b.Play(new Move(1, 4)));
            }
            // a move into a full column should be rejected
            Assert.IsFalse(b.Play(new Move(1, 4)));
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var b = new Game();
            b.Play(new Move(2, 1));
            b.Play(new Move(1, 4));
            b.Play(new Move(2, 4));
            b.Play(new Move(1, 3));

            Console.WriteLine(b.ToString());

            // this one is probably more likely to be checked by eye for now
            Assert.Inconclusive();
        }

        [TestMethod()]
        public void CanPlayTest()
        {
            Assert.Fail();
        }
    }
}