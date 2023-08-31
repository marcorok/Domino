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
        
        public TileValue ValueA { get; }
        public TileValue ValueB { get; }

        public Tile(string tileImageName, int valueA, int valueB) {
            TileImageName = tileImageName;
            ValueA = new TileValue { Value = valueA, IsAvailableForPlaying = true };
            ValueB = new TileValue { Value = valueB, IsAvailableForPlaying = true };
            _isAvailableForSelection = true;
        }

        public override string ToString()
        {
            return "TileImageName: " + TileImageName + " value A: " + ValueA + " value B: " + ValueB;
        }

        public bool ValuesMatch()
        {
            return ValueA.Value == ValueB.Value;
        }
    }

    public class TileValue {
        public int Value { get; internal set; }
        public bool IsAvailableForPlaying { get; internal set; }
    }
}
