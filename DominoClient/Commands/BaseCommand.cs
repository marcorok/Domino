using DominoGame.GameElements;
using DominoClient.GraphicElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominoClient.Controllers;

namespace DominoClient.Commands
{
    public abstract class BaseCommand
    {
        protected DominoTile _graphicTile;
        protected Board _board;
        protected Player _player;
        protected BoardController _boardController;

        public BaseCommand(BoardController  boardController, TileSelectionAndMovementController tileSelectionAndMovementController)
        {
            _graphicTile = tileSelectionAndMovementController.MovingElement;
            _board = boardController.Board;
            _player = boardController.Player1;
            _boardController = boardController;

        }
        public abstract void Execute();

        public abstract void Undo();

    }
}
