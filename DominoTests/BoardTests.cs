using Microsoft.VisualStudio.TestTools.UnitTesting;
using DominoGame.GameElements;
using System;
using System.Collections.Generic;

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

        [TestMethod]
        public void Domino_CreateTiles_TilesAreCreatedWSuccess() {
            //Arrange & Act
            SetUpTest();

            //Assert
            //Player 1 - has 7 tiles
            Assert.AreEqual<int>(7,p1.GetPlayableTiles().Count);
            //Player 2 - has 7 tiles
            Assert.AreEqual<int>(7,p2.GetPlayableTiles().Count);
            
            //Player 1 tiles are all available to be played
            Assert.IsTrue(TilesAreAllAvailableForSelection(p1.GetPlayableTiles()));

            //Player 2 tiles are all available to be played
            Assert.IsTrue(TilesAreAllAvailableForSelection(p2.GetPlayableTiles()));

            //P1 and P2 tiles have both values available
            Assert.IsTrue(AllTilesHaveBothValuesAvailable(p1.GetPlayableTiles()));
            Assert.IsTrue(AllTilesHaveBothValuesAvailable(p2.GetPlayableTiles()));

            //Board is empty
            Assert.AreEqual(0, b.TilesInBoard.Count);
            //BoneYard is not empty
            Assert.IsTrue(b.BoneYard.Count > 0);
        }

        private bool AllTilesHaveBothValuesAvailable(LinkedList<Tile> tiles)
        {
            foreach(Tile t in tiles)
            {
                if (!t.ValueA.IsAvailableForPlaying)
                    return false;
            }
            return true;
        }

        private bool TilesAreAllAvailableForSelection(LinkedList<Tile> tiles)
        {
            foreach (Tile t in tiles) {
                if (!t.IsAvailableForSelection)
                    return false;
            }
            return true;
        }


        private void SetUpTest()
        {
            p1 = new Player();
            p2 = new Player();
            b = new Board(p1, p2);
        }

    }
}
