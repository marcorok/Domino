using DominoGame.GameElements;
using DominoClient.GraphicElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClient.Commands
{
    internal abstract class BaseCommand
    {
        protected DominoTile _graphicTile;
        protected Board _board;
        protected Player _player;
        protected FormBoard _boardForm;

        public BaseCommand(FormBoard boardForm)
        {
            _graphicTile = boardForm.MovingElement;
            _board = boardForm.Board;
            _player = boardForm.P1;
            _boardForm = boardForm;

        }
        public abstract void Execute();

        public abstract void Undo();

    }
}
