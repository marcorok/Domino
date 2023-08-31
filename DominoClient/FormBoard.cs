using DominoClient.Controllers;
using DominoClient.GraphicElements;
using DominoClient.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DominoClient
{
    public partial class FormBoard : Form
    {

        private BoardController _boardController;
        private TileSelectionAndMovementController _tileSelectionAndMovementController;
        private PaintElementsController _paintElementsController;

        private bool _setupPerformed = false;

        public FormBoard()
        {
            InitializeComponent();
            SetupControllers();
        }

        private void SetupControllers()
        {

            Rectangle boardArea = CreateBoardArea();
            _tileSelectionAndMovementController = new TileSelectionAndMovementController();
            _paintElementsController = new PaintElementsController(boardArea);
            _boardController = new BoardController(_paintElementsController, _tileSelectionAndMovementController);
            _boardController.SetupBoard();
            _setupPerformed = true;
        }

        private void FormBoard_Paint(object sender, PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            if (_boardController != null && _setupPerformed)
                _paintElementsController.PaintBoard(g, _boardController);
        }

        #region Events
        private void FormBoard_MouseDown(object sender, MouseEventArgs e)
        {
            _tileSelectionAndMovementController.MouseDownOnBoard(e, _boardController);
        }

        private void FormBoard_MouseMove(object sender, MouseEventArgs e)
        {
            _tileSelectionAndMovementController.MouseMoveOnBoard(e);
        }

        private void FormBoard_MouseUp(object sender, MouseEventArgs e)
        {
            _tileSelectionAndMovementController.MouseUpOnBoard(e, _boardController);
        }

        private void FormBoard_TimerEvent(object sender, EventArgs e)
        {

            this.Invalidate();
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            _boardController.ApplyPlay();
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            _boardController.Undo();
        }
        #endregion Events

        #region Paint related methods


        private Rectangle CreateBoardArea()
        {
            var playerTilesSectionHeight = (FormConstants.TopControlsPanelHeight + DominoTile.BOTTOM_SPACE + DominoTile.INITIAL_HEIGTH + 10);
            Point boardLocation = new Point(0, playerTilesSectionHeight);
            Size boardSize = new Size(FormConstants.FormSize.Width,
                                        FormConstants.FormSize.Height - playerTilesSectionHeight * 2 - 10);
            return new Rectangle(boardLocation, boardSize);
        }



        #endregion Paint related methods

    }
}

