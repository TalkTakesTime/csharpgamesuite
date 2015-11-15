using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace GameSuite.Games.ConnectFour.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void GameTest()
        {
            var g = new Game();
            Assert.IsTrue(g.Height == 6);
            Assert.IsTrue(g.Width == 7);
        }

        [TestMethod()]
        public void GameTest1()
        {
            var g = new Game(2, 5);
            Assert.IsTrue(g.Height == 2);
            Assert.IsTrue(g.Width == 5);
        }

        [TestMethod()]
        public void GameTest2()
        {
            var moves = new Stack<Move>();
            moves.Push(new Move(1, 3));
            moves.Push(new Move(2, 3));
            moves.Push(new Move(1, 4));
            moves.Push(new Move(2, 5));

            var g = new Game(6, 7, moves);
            Assert.AreEqual(@"+---------------+
| _ _ _ _ _ _ _ |
| _ _ _ _ _ _ _ |
| _ _ _ _ _ _ _ |
| _ _ _ _ _ _ _ |
| _ _ _ x _ _ _ |
| _ _ _ o o x _ |
+---------------+", g.ToString());
        }

        [TestMethod()]
        public void PlayTest()
        {
            var g = new Game();

            // test playing in invalid columns
            Assert.IsFalse(g.Play(new Move(1, 10)));

            // test invalid players
            Assert.IsFalse(g.Play(new Move(0, 3)));
            Assert.IsFalse(g.Play(new Move(3, 0)));
            // player 1 must go first so this should fail
            Assert.IsFalse(g.Play(new Move(2, 1)));

            // and try some correct plays
            Assert.IsTrue(g.Play(new Move(1, 0)));
            Assert.IsTrue(g.Play(new Move(2, 2)));

            // fill a column
            byte i = 0;
            for (; i < g.Height; i++)
            {
                Assert.IsTrue(g.Play(new Move((byte) (i % 2 + 1), 4)));
            }
            // a move into a full column should be rejected
            Assert.IsFalse(g.Play(new Move((byte) (i % 2 + 1), 4)));
        }

        [TestMethod()]
        public void ToStringTest()
        {
            var g = new Game();
            g.Play(new Move(1, 4));
            g.Play(new Move(2, 4));
            g.Play(new Move(1, 3));
            g.Play(new Move(2, 1));

            Assert.AreEqual(@"+---------------+
| _ _ _ _ _ _ _ |
| _ _ _ _ _ _ _ |
| _ _ _ _ _ _ _ |
| _ _ _ _ _ _ _ |
| _ _ _ _ x _ _ |
| _ x _ o o _ _ |
+---------------+", g.ToString());
        }

        [TestMethod()]
        public void CanPlayTest()
        {
            var g = new Game();
            Move m;

            // test invalid column
            Assert.IsFalse(g.Play(new Move(1, 10)));

            // fill a column
            for (int i = 0; i < g.Height; i++)
            {
                m = new Move((byte) (i % 2 + 1), 4);
                Assert.IsTrue(g.CanPlay(m));
                Assert.IsTrue(g.Play(m));
            }

            m = new Move(1, 4);
            Assert.IsFalse(g.CanPlay(m));
        }

        [TestMethod()]
        public void GenerateMovesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GenerateChildTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EvaluateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UndoTest()
        {
            Assert.Fail();
        }
    }
}
