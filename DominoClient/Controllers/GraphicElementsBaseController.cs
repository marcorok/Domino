using DominoClient.GraphicElements;
using DominoClient.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClient.Controllers
{
    public class GraphicElementsBaseController
    {
        protected BoardController BoardController { get; private set; }
        protected Rectangle BoardArea { get; private set; }
        
        public GraphicElementsBaseController(BoardController boardController, Rectangle boardArea)
        {
            BoardController = boardController;
            BoardArea = boardArea;
        }

        
    }
}
