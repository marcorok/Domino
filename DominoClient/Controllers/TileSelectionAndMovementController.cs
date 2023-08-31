using DominoClient.Commands;
using DominoClient.GraphicElements;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominoClient.Controllers
{
    public class TileSelectionAndMovementController
    {
        private bool _isDragging = false;
        internal Rectangle RotateControl { get; set; }
        internal Point TilePositionBeforeMove { get; private set; }
        internal DominoTile MovingElement { get; private set; }
        
        //Mouse Down
        public void MouseDownOnBoard(MouseEventArgs e, BoardController boardController)
        {
            Point mousePosition = new Point(e.X, e.Y);

            DominoTile clickedDT = GetClickedDominoTile(mousePosition, boardController);

            if (!_isDragging && clickedDT != null && clickedDT.Tile.IsAvailableForSelection)
            {
                _isDragging = true;
                MovingElement = clickedDT;
                TilePositionBeforeMove = new Point(clickedDT.Rect.X, clickedDT.Rect.Y);
            }
            else if (RotateControl.Contains(mousePosition))
            {
                BaseCommand c = new RotateTileCommand(boardController, this);
                boardController.CommandsHistory.Push(c);
                c.Execute();
            }
            else
            {
                RotateControl = new Rectangle();
                MovingElement = null;
            }
            //Check if click was on a tile
            //If tile, check if tile is available for selection
            //Check if click was on RotateTileCommand
        }

        //Mouse Move
        public void MouseMoveOnBoard(MouseEventArgs e)
        {
            if (_isDragging)
            {
                //update graphic element positions
                MovingElement.UpdatePositionOnMoveWithCenteredMousePoint(e.Location);

            }
        }
        //Mouse Up
        public void MouseUpOnBoard(MouseEventArgs e, BoardController boardController)
        {
            if (_isDragging)
            {
                _isDragging = false;
                BaseCommand c = new MoveTileInBoardCommand(boardController, this);
                boardController.CommandsHistory.Push(c);
                c.Execute();
            }
        }

        internal void ClearSelectedTile()
        {
            MovingElement = null;
        }

        private DominoTile GetClickedDominoTile(Point mousePosition, BoardController boardController)
        {
            foreach (var dt in boardController.TilesList)
            {
                if (dt.Rect.Contains(mousePosition))
                    return dt;
            }
            return null;
        }
    }
}
