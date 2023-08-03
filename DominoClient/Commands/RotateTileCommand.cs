using DominoClient.GraphicElements;
using DominoGame.GameElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClient.Commands
{
    internal class RotateTileCommand : BaseCommand
    {
        private int _originalRotation;

        public RotateTileCommand(FormBoard boardForm) : base(boardForm)
        {
            _originalRotation = _graphicTile.RotationAngle;
        }

        public override void Execute()
        {
            _graphicTile.RotateTile();
        }

        public override void Undo()
        {
            _graphicTile.RotationAngle = _originalRotation; 
            _graphicTile.RefreshPosition();
        }
    }
}
