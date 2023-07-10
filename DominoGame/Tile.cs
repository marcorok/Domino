using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoGame.GameElements
{
    public class Tile {
        private string TileImageName { get; set; }
        public int ValueA { get; set; }
        private int ValueB { get; set; }

        public Tile(string tileImageName, int valueA, int valueB) {
            TileImageName = tileImageName;
            ValueA = valueA;
            ValueB = valueB;
        }

        public override string ToString()
        {
            return "TileImageName: " + TileImageName + " value A: " + ValueA + " value B: " + ValueB;
        }
    }
}
