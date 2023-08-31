using DominoClient.GraphicElements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClient.Helpers
{
    internal class PaintLocationHelpers
    {
        internal static Point GetPositionForFirstTile(int count, bool isCurrentPlayer)
        {
            int totalTilesSize = count * (DominoTile.INITIAL_WIDTH + DominoTile.SIDE_SPACE);
            int centerX = FormConstants.FormSize.Width / 2;
            int initialX = centerX - (totalTilesSize / 2);

            int initialY;

            if (isCurrentPlayer)
                initialY = FormConstants.FormSize.Height - (DominoTile.BOTTOM_SPACE + DominoTile.INITIAL_HEIGTH);
            else
            {
                initialY = (DominoTile.BOTTOM_SPACE + FormConstants.TopControlsPanelHeight);
            }

            return new Point(initialX, initialY);
        }


        internal static Point CalculateNextPosition(Point firstTilePosition)
        {
            return new Point(firstTilePosition.X + DominoTile.INITIAL_WIDTH + DominoTile.SIDE_SPACE, firstTilePosition.Y);
        }
    }
}
