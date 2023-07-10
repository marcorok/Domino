using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominoClient.GraphicElements
{
    internal class AnchorPoint
    {
        internal int DominoTileValue { get; }
        internal Point Position { get; set; }
        //internal Elipsis GravitiyField { get; }
        
        public AnchorPoint(int dominoTileValue, Point position)
        {
            DominoTileValue = dominoTileValue;
            Position = position;
        }
    }
}
