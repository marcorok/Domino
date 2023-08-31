﻿using DominoClient.Controllers;
using DominoClient.GraphicElements;
using DominoClient.Handlers;
using System.Drawing;

namespace DominoClient.Commands
{
    internal class PlayTileInBoardCommand : BaseCommand
    {
        private Point _originalPosition;

        public PlayTileInBoardCommand(BoardController boardController, TileSelectionAndMovementController tileSelectionAndMovementController) : base(boardController, tileSelectionAndMovementController)
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
            BoardTilePlayRequest request = new BoardTilePlayRequest
            {
                BoardController = _boardController,
                PlayedTile = _graphicTile,
                TileToConnectWith = null
            };

            var tilePlayValidationHandler = new BoardTilePlayValidationHandler();
            var tileApplyPlayHandler = new BoardTileApplyPlayHandler();
            var tilePositioningHandler = new BoardTilePositioningHandler();
            var tileClearSelectionHandler = new BoardTileClearSelectionHandler();
            var tileCreateAnchorPointsElipsis = new BoardTileCreateAnchorPointsElipsisHandler();
            tilePlayValidationHandler.SetNext(tileApplyPlayHandler).SetNext(tilePositioningHandler).SetNext(tileClearSelectionHandler).SetNext(tileCreateAnchorPointsElipsis);
            tilePlayValidationHandler.Handle(request);
            
        }

        public override void Undo() {
            _graphicTile.UpdatePosition(_originalPosition);
        }
    }
}
