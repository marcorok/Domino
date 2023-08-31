﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClient.Handlers
{
    internal class BoardTileApplyPlayHandler : AbstractHandler
    {

        public override object Handle(object request)
        {
            if (request is BoardTilePlayRequest)
            {
                BoardTilePlayRequest boardRequest = request as BoardTilePlayRequest;
                boardRequest.BoardController.Board.PlayRound(boardRequest.BoardController.Player1, boardRequest.PlayedTile.Tile);
            }
            else
            {
                throw new Exception(String.Format("{0} - Handle, expects an object from type {1}",
                    this.GetType().ToString(),
                    new BoardTilePlayRequest().GetType().ToString()));
            }

            return base.Handle(request);
        }
    }
}
