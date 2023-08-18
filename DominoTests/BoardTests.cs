using Microsoft.VisualStudio.TestTools.UnitTesting;
using DominoGame.GameElements;
using System;

namespace DominoTests
{
    [TestClass]
    public class BoardTests
    {
        Player p1;
        Player p2;
        Board b;


        [TestMethod]
        public void Domino_PlayerPlaysFirstTile_Success()
        {
            SetUpTest();
            Tile tileToPlay = p1.GetPlayableTiles().First.Value;
            b.PlayRound(p1, tileToPlay);

            //Tile has to be moved to Player Played tiles
            Assert.IsFalse(p1.GetPlayableTiles().Contains(tileToPlay));
            //Tile has to be added to board played tiles
            Assert.IsTrue(p1.GetPlayedTiles().Contains(tileToPlay));
            //Tile has to be added to board available tiles
            Assert.IsTrue(b.TilesAvailableToConnectWith.Contains(tileToPlay));
            Assert.IsTrue(b.TilesInBoard.Contains(tileToPlay));
            Assert.IsFalse(tileToPlay.IsAvailableForSelection);
        }

        [TestMethod]
        public void Domino_PlayerPlaysFirstTileValidation_Success()
        {
            SetUpTest();
            var t = p1.GetPlayableTiles().First.Value;
            Assert.IsTrue(b.ValidatePlayRound(p1, t));
        }

        private void SetUpTest()
        {
            p1 = new Player();
            p2 = new Player();
            b = new Board(p1, p2);
        }

    }
}
