using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClient.Handlers
{
    internal class BoardTilePlayValidationHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request is BoardTilePlayRequest)
            {
                BoardTilePlayRequest boardRequest = request as BoardTilePlayRequest;
                if (!boardRequest.FormBoard.Board.ValidatePlayRound(boardRequest.FormBoard.P1, boardRequest.PlayedTile.Tile)) {
                    return null;
                }

            }
            else {
                throw new Exception(String.Format("{0} - Handle, expects an object from type {1}",
                    this.GetType().ToString(),
                    new BoardTilePlayRequest().GetType().ToString()));
            }

            return base.Handle(request);
        }
    }
}
