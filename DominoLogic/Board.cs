using System;
using System.Collections.Generic;
using System.Linq;

namespace DominoGame.GameElements
{
    public class Board
    {
        private Player P1 { get; set; }
        private Player P2 { get; set; }

        public LinkedList<Tile> BoneYard { get; private set; }
        public LinkedList<Tile> TilesInBoard { get; private set; }
        public LinkedList<Tile> TilesAvailableToConnectWith { get; private set; }

        public Board(Player p1, Player p2)
        {
            this.P1 = p1;
            this.P2 = p2;
            BoneYard = new LinkedList<Tile>();
            TilesInBoard = new LinkedList<Tile>();
            TilesAvailableToConnectWith = new LinkedList<Tile>();
            InitializeGame();
        }

        /**Intializes the board by creating calling the method CreateTiles()**/
        private void InitializeGame()
        {
            CreateTiles();
            DistributeTiles(P1);
            DistributeTiles(P2);
        }

        #region PlayTile
        public void PlayRound(Player p, Tile t) { 
            p.PlayTile(t);
            TilesInBoard.AddLast(t);
            TilesAvailableToConnectWith.AddLast(t);
            t.IsAvailableForSelection = false;
        }

        public bool ValidatePlayRound(Player p, Tile t) {

            if (TilesInBoard.Count == 0) return true;
            return false;
        }

        #endregion

        /**
         * Gets a random tile from the BoneYard 
         * **/

        public Tile GetTileFromBoneYardForPlayer(Player p)
        {
            throw new NotImplementedException();
        }

        private Tile GetTileFromBoneYard()
        {
            throw new NotImplementedException();
        }

        /*For tests*/
        public LinkedList<Tile> GetBoneYard() => BoneYard;

        #region GameStarters
        /**
         * Contains logic to create all tiles for the board
         * Initially all tiles go to the boneyard  
         **/
        private void CreateTiles()
        {
            for (int i = 0; i <= 6; i++)
            {
                for (int j = i; j <= 6; j++)
                {
                    BoneYard.AddLast(new Tile(string.Format("piece_{0}_{1}", i, j), i, j));
                }
            }
        }
        /**Distributes the first 7 tiles for each player**/
        private void DistributeTiles(Player p)
        {
            LinkedList<Tile> list = new LinkedList<Tile>();
            for (int i = 1; i <= 7; i++) {
                int rndIndex = new Random().Next(0,BoneYard.Count);
                Tile t = BoneYard.ElementAt(rndIndex);
                list.AddFirst(t);
                BoneYard.Remove(t); 
            }
            p.AddTiles(list);
        }
        #endregion GameStarters
    }
}