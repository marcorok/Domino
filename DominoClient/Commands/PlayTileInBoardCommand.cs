using DominoGame.GameElements;
using DominoClient.GraphicElements;
using DominoClient.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DominoClient.Commands
{
    internal class PlayTileInBoardCommand : BaseCommand
    {
        private Point _originalPosition;

        public PlayTileInBoardCommand(FormBoard formBoard, Point originalPosition) : base(formBoard)
        {
            _originalPosition = originalPosition;
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
        }

        public override void Undo() {
            _graphicTile.UpdatePosition(_originalPosition);
        }
    }
}
