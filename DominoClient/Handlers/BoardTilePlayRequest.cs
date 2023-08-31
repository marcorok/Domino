using DominoClient.Controllers;
using DominoClient.GraphicElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClient.Handlers
{
    internal class BoardTilePlayRequest
    {
        internal DominoTile PlayedTile { get; set; }
        internal DominoTile TileToConnectWith { get; set; }
        internal BoardController BoardController { get; set; }
    }

    internal class BoardMoveTileRequest : BoardTilePlayRequest
    { 
    
    }
}
