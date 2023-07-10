using DominoGame.GameElements;
using PlayingWithGraphicsFramework.GraphicElements;
using PlayingWithGraphicsFramework.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithGraphicsFramework.Commands
{
    internal class PlayTileInBoardCommand : BaseCommand
    {
        public PlayTileInBoardCommand(DominoTile graphicTile, Board board, Player player, FormBoard formBoard) : base(graphicTile, board, player, formBoard)
        {
        }

        public override void Execute()
        {
            /*
             *
             *It is highly likely that we'll need a Chain of responsibilities here
             *  1 - Validate if play is possible
             *  2 - Rearrage tile in the board if needed
             *  3 - Commit changes to board
             */
            var tilePositioningHandler = new BoardTilePositioningHandler();
            tilePositioningHandler.Handle(new BoardTilePositioningRequest
            {
                FormBoard = _boardForm,
                PlayedTile = _graphicTile,
                TileToConnectWith = null
            }) ;
            
            //throw new NotImplementedException();
        }
    }
}
