using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoGame.GameElements
{
    public class Tile {
        public string TileImageName { get; }
        public int ValueA { get; }
        public int ValueB { get; }

        public Tile(string tileImageName, int valueA, int valueB) {
            TileImageName = tileImageName;
            ValueA = valueA;
            ValueB = valueB;
        }

        public override string ToString()
        {
            return "TileImageName: " + TileImageName + " value A: " + ValueA + " value B: " + ValueB;
        }

        public bool ValuesMatch()
        {
            return ValueA == ValueB;
        }
    }
}
