using DominoGame.GameElements;
using PlayingWithGraphicsFramework.GraphicElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWithGraphicsFramework.Commands
{
    internal abstract class BaseCommand
    {
        protected DominoTile _graphicTile;
        protected Board _board;
        protected Player _player;
        protected FormBoard _boardForm;

        public BaseCommand(DominoTile graphicTile, Board board, Player player, FormBoard boardForm)
        {
            _graphicTile = graphicTile;
            _board = board;
            _player = player;
            _boardForm = boardForm;

        }
        public abstract void Execute();


    }
}
