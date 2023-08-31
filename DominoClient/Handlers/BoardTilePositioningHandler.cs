﻿using DominoClient.Controllers;
using DominoGame.GameElements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClient.Handlers
{
    internal class BoardTilePositioningHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request is BoardTilePlayRequest)
            {
                var positioningRequest = (BoardTilePlayRequest)request;
                if (positioningRequest.TileToConnectWith != null)
                {
                    //relocate the tile according to the anchor point to which it was connected
                    throw new NotImplementedException();
                }
                else if (positioningRequest.TileToConnectWith == null &&
                    positioningRequest.BoardController.PaintElementsController.IsTileInBoardArea(positioningRequest.PlayedTile))
                {
                    //Position tile in the center of the board
                    Point center = positioningRequest.BoardController.PaintElementsController.GetBoardCenterPosition();
                    positioningRequest.PlayedTile.UpdatePositionOnMoveWithCenteredMousePoint(center);
                }
                else
                {
                    return null;
                }
            }
            return base.Handle(request);
        }
    }
}
