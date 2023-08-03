using DominoGame.GameElements;
using DominoClient.Properties;
using DominoClient.GraphicElements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominoClient
{
    public partial class FormBoard : Form
    {
        //Board and Players
        private Player _p2;
        internal Player P1 { get; private set; }
        internal Board Board { get; private set; }

        private LinkedList<DominoTile> TilesList;

        private void SetupBoard()
        {
            TilesList = new LinkedList<DominoTile>();

            P1 = new Player();
            _p2 = new Player();
            Board = new Board(P1, _p2);

            CreateBoardArea();
            CreateCurrentPlayerTiles(P1);
        }

        private void CreateBoardArea()
        {
            var playerTilesSectionHeight = (_topControlsPanelHeight + DominoTile.BOTTOM_SPACE + DominoTile.INITIAL_HEIGTH + 10);
            Point boardLocation = new Point(0, playerTilesSectionHeight);
            Size boardSize = new Size(ClientSize.Width, ClientSize.Height - playerTilesSectionHeight * 2 - 10);
            _boardArea = new Rectangle(boardLocation, boardSize);
        }

        private void CreateCurrentPlayerTiles(Player p)
        {
            var rmgr = Resources.ResourceManager;
            var listOfTiles = p.GetPlayableTiles();
            //Calculate position point (x,y) for tile
            //Calculate position for first tile
            Point tilePosition = GetPositionForFirstTile(listOfTiles.Count, true);

            foreach (var tile in listOfTiles)
            {
                DominoTile dt = new DominoTile(rmgr.GetObject(tile.TileImageName) as Image, tilePosition,tile);
                TilesList.AddFirst(dt);
                tilePosition = CalculateNextPosition(tilePosition);
            }

        }

        private Point CalculateNextPosition(Point firstTilePosition)
        {
            return new Point(firstTilePosition.X + DominoTile.INITIAL_WIDTH + DominoTile.SIDE_SPACE, firstTilePosition.Y);
        }

        private Point GetPositionForFirstTile(int count, bool isCurrentPlayer)
        {
            int totalTilesSize = count * (DominoTile.INITIAL_WIDTH + DominoTile.SIDE_SPACE);
            int centerX = ClientSize.Width / 2;
            int initialX = centerX - (totalTilesSize / 2);

            int initialY;

            if (isCurrentPlayer) 
                initialY = ClientSize.Height - (DominoTile.BOTTOM_SPACE + DominoTile.INITIAL_HEIGTH);
            else
            {
                initialY = (DominoTile.BOTTOM_SPACE + _topControlsPanelHeight);
            }

            return new Point(initialX, initialY);
        }

        private DominoTile GetClickedDT(Point mousePosition)
        {
            foreach (var dt in TilesList)
            {
                if (dt.Rect.Contains(mousePosition))
                    return dt;
            }
            return null;
        }

        #region Painting methods
        private void PaintOponentTiles(Graphics g, PaintEventArgs pe)
        {
            var rmg = Resources.ResourceManager;
            int tilesCount = _p2.GetPlayableTilesCount();
            Point tilePosition = GetPositionForFirstTile(tilesCount, false);

            for (int i = 0; i != tilesCount; i++) {
                g.DrawImage(rmg.GetObject(DominoTile.OponentTile) as Image, tilePosition.X, tilePosition.Y, DominoTile.INITIAL_WIDTH, DominoTile.INITIAL_HEIGTH);
                tilePosition = CalculateNextPosition(tilePosition);
            }
        }

        private void PaintCurrentPlayerTiles(Graphics g, PaintEventArgs pe)
        {
            foreach (DominoTile dt in TilesList)
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
                if (dt == MovingElement)
                {
                    PaintSelectionBorder(g);
                    _rotateControl = PaintRotateControl(pe, dt);
                }

                if (SHOW_ANCHOR_POINTS_IN_DOMINO_TILES)
                {
                    //Paint Anchor Points TODO: This should become a feature flag for debugging enabled from the application config
                    foreach (AnchorPoint ap in dt.AnchorPoints)
                    {
                        PaintAnchorPoint(pe, ap, dt);
                    }
                }
            }
        }

        internal bool IsTileInBoardArea(DominoTile dt) {
            return _boardArea.Contains(dt.Rect);
        }

        /*Just for debugging purposes*/
        private void PaintBoardArea(Graphics g) {
            g.DrawRectangle(Pens.Aqua, _boardArea);
        }

        private void PaintAnchorPoint(PaintEventArgs pe, AnchorPoint ap, DominoTile dt)
        {
            Pen pen = Pens.YellowGreen;
            // Draw a rectangle with rotatePen.
            //Rectangle rPlaceHolder = new Rectangle(location, new Size(dt.width + borderSize, dt.height + borderSize));
            pe.Graphics.DrawRectangle(pen, new Rectangle(ap.Position,new Size(4,4)));
        }

        #endregion Paiting methods

    }
}
