using DominoClient.GraphicElements;
using DominoClient.Helpers;
using DominoClient.Properties;
using System.Configuration;
using System.Drawing;

namespace DominoClient.Controllers
{
    public class PaintElementsController
    {
        private readonly bool SHOW_ANCHOR_POINTS_IN_DOMINO_TILES = bool.Parse(ConfigurationManager.AppSettings["ShowAnchorPointsOnDominoTiles"]);
        private Rectangle BoardArea { get; set; }

        public PaintElementsController(Rectangle boardArea)
        {
            BoardArea = boardArea;
        }

        internal bool IsTileInBoardArea(DominoTile dt)
        {
            return BoardArea.Contains(dt.Rect);
        }

        #region Painting methods
        public void PaintBoard(Graphics g, BoardController boardController)
        {
            PaintCurrentPlayerTiles(g, boardController);
            PaintOponentTiles(g, boardController);
            //Just for debugging purposes
            PaintBoardArea(g);
        }

        private void PaintOponentTiles(Graphics g, BoardController boardController)
        {
            var rmg = Resources.ResourceManager;
            int tilesCount = boardController.Player2.GetPlayableTilesCount();
            Point tilePosition = PaintLocationHelpers.GetPositionForFirstTile(tilesCount, false);

            for (int i = 0; i != tilesCount; i++)
            {
                g.DrawImage(rmg.GetObject(DominoTile.OponentTile) as Image, tilePosition.X, tilePosition.Y, DominoTile.INITIAL_WIDTH, DominoTile.INITIAL_HEIGTH);
                tilePosition = PaintLocationHelpers.CalculateNextPosition(tilePosition);
            }
        }

        private void PaintCurrentPlayerTiles(Graphics g, BoardController boardController)
        {
            foreach (DominoTile dt in boardController.TilesList)
            {
                Point newLocation;
                if (dt.RotationAngle > 0)
                {
                    g.TranslateTransform(dt.Position.X + (dt.Width / 2), dt.Position.Y + (dt.Height / 2));
                    g.RotateTransform(dt.RotationAngle);
                    newLocation = new Point(-dt.Width / 2, -dt.Height / 2);
                }
                else
                {
                    newLocation = new Point(dt.Position.X, dt.Position.Y);
                }

                g.DrawImage(dt.TileImage, newLocation.X, newLocation.Y, dt.Width, dt.Height);
                g.ResetTransform();
                if (dt == boardController.TileSelectionAndMovementController.MovingElement)
                {
                    PaintSelectionBorder(g, boardController);
                    boardController.TileSelectionAndMovementController.RotateControl = PaintRotateControl(g, dt);
                }

                if (SHOW_ANCHOR_POINTS_IN_DOMINO_TILES)
                {
                    //Paint Anchor Points TODO: This should become a feature flag for debugging enabled from the application config
                    foreach (AnchorPoint ap in dt.AnchorPoints)
                    {
                        PaintAnchorPoint(g, ap);
                    }
                }
            }
        }

        private Rectangle PaintRotateControl(Graphics g, DominoTile tile)
        {
            Rectangle rPlaceHolder = new Rectangle(tile.Position.X + tile.Width + 2, tile.Position.Y, 20, 20);
            g.DrawImage(Resources.rotate, rPlaceHolder);
            return rPlaceHolder;
        }

        /*Just for debugging purposes*/
        private void PaintBoardArea(Graphics g)
        {
            g.DrawRectangle(Pens.Aqua, BoardArea);
        }

        private void PaintAnchorPoint(Graphics g, AnchorPoint ap)
        {
            Pen pen = Pens.YellowGreen;
            // Draw a rectangle with rotatePen.
            //Rectangle rPlaceHolder = new Rectangle(location, new Size(dt.width + borderSize, dt.height + borderSize));
            g.DrawRectangle(pen, new Rectangle(ap.Position, new Size(4, 4)));
        }

        private void PaintSelectionBorder(Graphics g, BoardController boardController)
        {
            Pen pen = Pens.Blue;
            g.DrawRectangle(pen, boardController.TileSelectionAndMovementController.MovingElement.Rect);
        }

        public Point GetBoardCenterPosition()
        {
            return new Point(FormConstants.FormSize.Width / 2, FormConstants.FormSize.Height / 2);
        }
        #endregion Paiting methods

    }
}
