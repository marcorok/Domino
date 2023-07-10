namespace DominoGame.GameElements
{
    public class Board
    {
        private Player P1 { get; set; }
        private Player P2 { get; set; }

        private LinkedList<Tile> BoneYard { get; set; }

        public Board(Player p1, Player p2)
        {
            this.P1 = p1;
            this.P2 = p2;
            BoneYard = new LinkedList<Tile>();
        }

        /**Intializes the board by creating calling the method CreateTiles()**/
        public void InitializeGame()
        {
            CreateTiles();
            DistributeTiles(P1);
            DistributeTiles(P2);
        }


        public void PlayRound(Player p, Tile t) => throw new NotImplementedException();

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
                    BoneYard.AddLast(new Tile(string.Format("piece_{0}_{1}.png", i, j), i, j));
                }
            }
        }
        /**Distributes the first 7 tiles for each player**/
        private void DistributeTiles(Player p)
        {
            LinkedList<Tile> list = new LinkedList<Tile>();
            for (int i = 0; i <= 7; i++) {
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