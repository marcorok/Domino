using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithGraphicsFramework.GraphicElements.AnchorPointsFactories
{
    internal interface IAnchorPointsFactory
    {
        LinkedList<AnchorPoint> CreateAnchorPoints(DominoTile dominoTile);
    }
}
