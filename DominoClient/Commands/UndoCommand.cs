using DominoGame.GameElements;
using DominoClient.GraphicElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClient.Commands
{
    internal class UndoCommand : BaseCommand
    {
        public UndoCommand(DominoTile graphicTile, Board board, Player player, FormBoard formBoard) : base(graphicTile, board, player, formBoard)
        {
        }

        public override void Execute()
        {
            /*
             * This will undo the tile movement, placing the tile in its original position.
             * **/
            
            throw new NotImplementedException();
        }
    }
}
