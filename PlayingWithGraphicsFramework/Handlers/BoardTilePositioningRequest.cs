using PlayingWithGraphicsFramework.GraphicElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithGraphicsFramework.Handlers
{
    internal class BoardTilePositioningRequest
    {
        internal DominoTile PlayedTile { get; set; }
        internal DominoTile TileToConnectWith { get; set; }
        internal FormBoard FormBoard { get; set; }
    }
}
