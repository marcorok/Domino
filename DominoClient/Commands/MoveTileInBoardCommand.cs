using DominoGame.GameElements;
using DominoClient.GraphicElements;
using DominoClient.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DominoClient.Controllers;

namespace DominoClient.Commands
{
    internal class MoveTileInBoardCommand : BaseCommand
    {
        private Point _originalPosition;

        public MoveTileInBoardCommand(BoardController boardController, TileSelectionAndMovementController tileSelectionAndMovementController) : base(boardController, tileSelectionAndMovementController)
        {
            _originalPosition = tileSelectionAndMovementController.TilePositionBeforeMove;
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
            BoardMoveTileRequest request = new BoardMoveTileRequest
            {
                BoardController = _boardController,
                PlayedTile = _graphicTile,
                TileToConnectWith = null
            };

            var tilePositioningHandler = new BoardTilePositioningHandler();
            tilePositioningHandler.Handle(request);
        }

        public override void Undo() {
            _graphicTile.UpdatePosition(_originalPosition);
        }
    }
}
