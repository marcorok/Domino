using DominoClient.Commands;
using DominoClient.GraphicElements;
using DominoClient.Helpers;
using DominoClient.Properties;
using DominoGame.GameElements;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClient.Controllers
{
    public class BoardController
    {

        public LinkedList<DominoTile> TilesList { get; private set; }
        public Stack<BaseCommand> CommandsHistory { get; private set; }

        //Board and Players
        public Player Player2 { get; private set; }
        public Player Player1 { get; private set; }
        public Board Board { get; private set; }

        //Controllers
        internal PaintElementsController PaintElementsController { get; private set; }
        internal TileSelectionAndMovementController TileSelectionAndMovementController { get; private set; }

        public BoardController(PaintElementsController paintElementsController, TileSelectionAndMovementController tileSelectionAndMovementController)
        {
            CommandsHistory = new Stack<BaseCommand>();
            PaintElementsController = paintElementsController;
            TileSelectionAndMovementController = tileSelectionAndMovementController;
        }

        public void SetupBoard()
        {
            TilesList = new LinkedList<DominoTile>();

            Player1 = new Player();
            Player2 = new Player();
            Board = new Board(Player1, Player2);

            CreateCurrentPlayerTiles(Player1);
        }

        public void ApplyPlay()
        {
            PlayTileInBoardCommand c = new PlayTileInBoardCommand(this, TileSelectionAndMovementController);
            c.Execute();
        }

        public void Undo()
        {
            if (CommandsHistory.Count > 0)
            {
                BaseCommand c = CommandsHistory.Pop();
                c?.Undo();
            }
        }

        private void CreateCurrentPlayerTiles(Player p)
        {
            var rmgr = Resources.ResourceManager;
            var listOfTiles = p.GetPlayableTiles();
            Point tilePosition = PaintLocationHelpers.GetPositionForFirstTile(listOfTiles.Count, true);

            foreach (var tile in listOfTiles)
            {
                DominoTile dt = new DominoTile(rmgr.GetObject(tile.TileImageName) as Image, tilePosition, tile);
                TilesList.AddFirst(dt);
                tilePosition = PaintLocationHelpers.CalculateNextPosition(tilePosition);
            }
        }

        
    }
}
