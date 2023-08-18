using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DominoGame.GameElements
{
    public class Tile {
        public string TileImageName { get; }
        private bool _isAvailableForSelection;
        public bool IsAvailableForSelection { 
            get => _isAvailableForSelection;
            set => _isAvailableForSelection = _isAvailableForSelection ? value : false; }
        
        public int ValueA { get; }
        public int ValueB { get; }

        public Tile(string tileImageName, int valueA, int valueB) {
            TileImageName = tileImageName;
            ValueA = valueA;
            ValueB = valueB;
            _isAvailableForSelection = true;
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
