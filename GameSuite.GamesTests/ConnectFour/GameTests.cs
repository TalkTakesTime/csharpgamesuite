using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameSuite.Games.ConnectFour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.IsFalse(b.Play(-1, 1));
            Assert.IsFalse(b.Play(10, 1));

            // test invalid players
            Assert.IsFalse(b.Play(2, 0));
            Assert.IsFalse(b.Play(2, 3));

            // and try some correct plays
            Assert.IsTrue(b.Play(0, 1));
            Assert.IsTrue(b.Play(2, 2));

            // fill a column
            for (int i = 0; i < b.Height; i++)
            {
                Assert.IsTrue(b.Play(4, 1));
            }
            // a move into a full column should be rejected
            Assert.IsFalse(b.Play(4, 1));
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var b = new Game();
            b.Play(1, 2);
            b.Play(4, 1);
            b.Play(4, 2);
            b.Play(3, 1);

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