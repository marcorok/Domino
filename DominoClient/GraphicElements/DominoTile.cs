using DominoGame.GameElements;
using DominoClient.GraphicElements.anchorPointsFactories;
using DominoClient.GraphicElements.AnchorPointsFactories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClient.GraphicElements
{
    internal class DominoTile
    {
        internal const int INITIAL_WIDTH = 45;
        internal const int INITIAL_HEIGTH = 90;
        internal const int BOTTOM_SPACE = 10;
        internal const int SIDE_SPACE = 10;
        internal const string OponentTile = "piece_opo";

        internal Tile Tile { get; }
        internal Image TileImage { get; }
        internal int Width { get { return INITIAL_WIDTH; } }
        internal int Height { get { return INITIAL_HEIGTH; } }
        internal int BottomSpace { get { return BOTTOM_SPACE; } }
        internal int SideSpace { get { return SIDE_SPACE; } }
        internal LinkedList<AnchorPoint> AnchorPoints { get; set; }
        internal Point Position { get => _position; }
        private Point _position = new Point();

        internal int RotationAngle = 0;

        internal bool Active = false;

        private Rectangle _rect;
        internal Rectangle Rect { get => _rect; }


        public DominoTile(Image image, Point point, Tile tile)
        {
            TileImage = image;
            _position = point;
            _rect = new Rectangle(point, new Size(Width + 2, Height + 2));
            Tile = tile;
            AnchorPoints = new LinkedList<AnchorPoint>();
            CreateAnchorPoints();
        }

        private void CreateAnchorPoints()
        {
            IAnchorPointsFactory factory;
            if (RotationAngle == 0 || RotationAngle == 180)
            {
                factory = new TileNormalPositionAnchorPointsFactory();
            }
            else
            {
                factory = new TileOnSidePositionAnchorPointsFactory();
            }
            AnchorPoints = factory.CreateAnchorPoints(this);
        }

        internal void RotateTile()
        {
            //Update rotationAngle
            RotationAngle = RotationAngle == 270 ? 0 : RotationAngle + 90;
            RefreshPosition();
        }

        internal void UpdateRectPosition()
        {
            //Update position
            if (RotationAngle == 90 || RotationAngle == 270)
            {
                _rect.Y += Height / 4;
                _rect.X -= Width / 2;
                _rect.Width = Height;
                _rect.Height = Width;
            }
            else
            {
                _rect.X = Position.X;
                _rect.Y = Position.Y;
                _rect.Width = Width;
                _rect.Height = Height;
            }
        }

        internal void UpdateAnchorPointsPosition()
        {
            AnchorPoints = new LinkedList<AnchorPoint>();
            CreateAnchorPoints();
        }

        internal void UpdatePosition(Point originalPosition)
        {
            _position.X = originalPosition.X;
            _position.Y = originalPosition.Y;
            _rect.X = Position.X;
            _rect.Y = Position.Y;
            RefreshPosition();
        }

        internal void UpdatePositionOnMoveWithCenteredMousePoint(Point newLocation)
        {
            _position.X = newLocation.X - (Width / 2);
            _position.Y = newLocation.Y - (Height / 2);
            _rect.X = Position.X;
            _rect.Y = Position.Y;
            RefreshPosition();
        }

        internal void RefreshPosition() {
            UpdateRectPosition();
            UpdateAnchorPointsPosition();
        }
    }
}
