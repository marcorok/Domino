using DominoGame.GameElements;
using DominoClient.GraphicElements.AnchorPointsFactories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClient.GraphicElements.anchorPointsFactories
{

    internal class TileNormalPositionAnchorPointsFactory : IAnchorPointsFactory
    {
        private int _upValue;
        private int _downValue;

        public LinkedList<AnchorPoint> CreateAnchorPoints(DominoTile dominoTile)
        {
            var anchorPoints = new LinkedList<AnchorPoint>();

            SetUpAndDownValues(dominoTile.RotationAngle, dominoTile.Tile);

            var topAndBottomMidle = dominoTile.Width / 2;
            var quarterOfHeight = dominoTile.Height / 4;
            //Scenario for 6 AP's
            //Create (top side of the tile) AP's
            //top
            anchorPoints.AddFirst(new AnchorPoint(_upValue, new Point(dominoTile.Position.X + topAndBottomMidle, dominoTile.Position.Y)));
            //left
            anchorPoints.AddFirst(new AnchorPoint(_upValue, new Point(dominoTile.Position.X, dominoTile.Position.Y + quarterOfHeight)));
            //rigth
            anchorPoints.AddFirst(new AnchorPoint(_upValue, new Point(dominoTile.Position.X + dominoTile.Width, dominoTile.Position.Y + quarterOfHeight)));

            //Create (bottom side of the tile) AP's
            anchorPoints.AddFirst(new AnchorPoint(_downValue, new Point(dominoTile.Position.X + topAndBottomMidle, dominoTile.Position.Y + dominoTile.Height)));
            //left
            anchorPoints.AddFirst(new AnchorPoint(_downValue, new Point(dominoTile.Position.X, dominoTile.Position.Y + quarterOfHeight * 3)));
            //Right
            anchorPoints.AddFirst(new AnchorPoint(_downValue, new Point(dominoTile.Position.X + dominoTile.Width, dominoTile.Position.Y + quarterOfHeight * 3)));

            if (dominoTile.Tile.ValuesMatch())
            {
                var middleHeight = dominoTile.Height / 2;
                anchorPoints.AddFirst(new AnchorPoint(_upValue, new Point(dominoTile.Position.X, dominoTile.Position.Y + middleHeight)));
                anchorPoints.AddFirst(new AnchorPoint(_upValue, new Point(dominoTile.Position.X +  dominoTile.Width, dominoTile.Position.Y + middleHeight)));
            }

            return anchorPoints;
        }

        private void SetUpAndDownValues(int rotationAngle, Tile tile)
        {
            _upValue = rotationAngle == 0 ? tile.ValueA : tile.ValueB;
            _downValue = rotationAngle == 0 ? tile.ValueB : tile.ValueA;
        }
    }
}
