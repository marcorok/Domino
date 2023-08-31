using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClient.Handlers
{
    internal class BoardTileClearSelectionHandler : AbstractHandler
    {

        public override object Handle(object request)
        {
            if (request is BoardTilePlayRequest)
            {
                BoardTilePlayRequest selectionRequest = request as BoardTilePlayRequest;
                selectionRequest.BoardController.TileSelectionAndMovementController.ClearSelectedTile();
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
