using DominoGame.GameElements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace DominoClient.GraphicElements.AnchorPointsFactories
{
    internal class TileOnSidePositionAnchorPointsFactory : IAnchorPointsFactory
    {
        private int _rightSideValue;
        private int _leftSideValue;
        
        public LinkedList<AnchorPoint> CreateAnchorPoints(DominoTile dominoTile)
        {
            var anchorPoints = new LinkedList<AnchorPoint>();
            int posX = dominoTile.Rect.X;
            int posY = dominoTile.Rect.Y;
            SetLeftAndRigthValues(dominoTile.RotationAngle, dominoTile.Tile);

            var midleOfTheHeight = dominoTile.Width / 2; //Width and Height don't change in the DominoTile. They represent always the size in the original position
            var quarterOfWidth = dominoTile.Height / 4;
            //Scenario for 6 AP's
            //Create (Left side of the tile) AP's
            anchorPoints.AddFirst(new AnchorPoint(_leftSideValue, new Point(posX, posY + midleOfTheHeight)));
            //top
            anchorPoints.AddFirst(new AnchorPoint(_leftSideValue, new Point(posX + quarterOfWidth, posY)));
            //bottom
            anchorPoints.AddFirst(new AnchorPoint(_leftSideValue, new Point(posX + quarterOfWidth, posY + dominoTile.Width)));
            //Create (rigth side of the tile) AP's
            //middle
            anchorPoints.AddFirst(new AnchorPoint(_rightSideValue, new Point(posX + dominoTile.Height, posY + midleOfTheHeight)));
            //top
            anchorPoints.AddFirst(new AnchorPoint(_rightSideValue, new Point(posX + quarterOfWidth * 3, posY )));
            //bottom
            anchorPoints.AddFirst(new AnchorPoint(_rightSideValue, new Point(posX + quarterOfWidth * 3, posY + dominoTile.Width)));

            if (dominoTile.Tile.ValuesMatch())
            {
                var middleWidth = dominoTile.Height / 2;
                anchorPoints.AddFirst(new AnchorPoint(_leftSideValue, new Point(posX + middleWidth, posY)));
                anchorPoints.AddFirst(new AnchorPoint(_leftSideValue, new Point(posX + middleWidth, posY + dominoTile.Width)));
            }

            return anchorPoints;
        }

        private void SetLeftAndRigthValues(int rotationAngle, Tile tile)
        {
            _rightSideValue = rotationAngle == 90 ? tile.ValueA.Value : tile.ValueB.Value;
            _leftSideValue = rotationAngle == 90 ? tile.ValueB.Value : tile.ValueA.Value;
        }
    }
}
