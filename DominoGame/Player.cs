using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DominoGame.GameElements
{
    public class Player
    {
        private LinkedList<Tile> PlayableTiles;
        private LinkedList<Tile> PlayedTiles;
        public Player() { 
            this.PlayableTiles = new LinkedList<Tile>(); 
            this.PlayedTiles = new LinkedList<Tile>();  
        }

        internal void AddTiles(LinkedList<Tile> tilesToAdd) => PlayableTiles = tilesToAdd;
        internal void MarkTileAsPlayed(Tile tile) {
            PlayedTiles.AddLast(tile);
            PlayableTiles.Remove(tile);
        }
        internal void AddTile(Tile tile) => PlayableTiles.AddLast(tile);

        //TestMethods
        public LinkedList<Tile> GetPlayableTiles()
        {
            return PlayableTiles;
        }
    }
}
