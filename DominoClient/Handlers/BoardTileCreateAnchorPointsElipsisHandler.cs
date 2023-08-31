using DominoClient.Handlers;
using System;

namespace DominoClient.Commands
{
    internal class BoardTileCreateAnchorPointsElipsisHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if (request is BoardTilePlayRequest)
            {
                (request as BoardTilePlayRequest).PlayedTile.CreateAnchorPointsElipsis();
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