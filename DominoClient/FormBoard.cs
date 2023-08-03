using DominoGame.GameElements;
using DominoClient.Commands;
using DominoClient.GraphicElements;
using DominoClient.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominoClient
{
    public partial class FormBoard : Form
    {

        private readonly bool SHOW_ANCHOR_POINTS_IN_DOMINO_TILES = bool.Parse(ConfigurationManager.AppSettings["ShowAnchorPointsOnDominoTiles"]);
        internal DominoTile MovingElement { get; private set; }
        
        private Rectangle _boardArea;
        private bool _isDragging = false;
        private Rectangle _rotateControl;
        private Point _tilePositionBeforeMove;

        private Stack<BaseCommand> _commandsHistory = new Stack<BaseCommand>();

        public FormBoard()
        {
            InitializeComponent();
            SetupBoard();
        }

        private void FormBoard_Paint(object sender, PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            PaintCurrentPlayerTiles(g, pe);
            PaintOponentTiles(g, pe);
            //Just for debugging purposes
            PaintBoardArea(g);
        }

        #region Events
        private void FormBoard_MouseDown(object sender, MouseEventArgs e)
        {
            
            Point mousePosition = new Point(e.X, e.Y);

            DominoTile clickedDT = GetClickedDT(mousePosition);

            if (!_isDragging && clickedDT != null)
            {
                _isDragging = true;
                MovingElement = clickedDT;
                _tilePositionBeforeMove = new Point(clickedDT.Rect.X, clickedDT.Rect.Y);
            }
            else if (_rotateControl.Contains(mousePosition))
            {
                BaseCommand c = new RotateTileCommand(this);
                _commandsHistory.Push(c);
                c.Execute();
            }
            else
            {
                _rotateControl = new Rectangle();
                MovingElement = null;
            }
        }
    
        private void FormBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                //update graphic element positions
                MovingElement.UpdatePositionOnMoveWithCenteredMousePoint(e.Location);
                
            }
        }
         
        private void FormBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                _isDragging = false;
                BaseCommand c = new PlayTileInBoardCommand(this, _tilePositionBeforeMove);
                _commandsHistory.Push(c);
                c.Execute();
            }
        }

        private void FormBoard_TimerEvent(object sender, EventArgs e)
        {
           
            this.Invalidate();
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            if (_commandsHistory.Count > 0)
            {
                BaseCommand c = _commandsHistory.Pop();
                c?.Undo();
            }
        }
        #endregion Events

        #region Paint related methods
        private Rectangle PaintRotateControl(PaintEventArgs pe, DominoTile tile)
        {
            Rectangle rPlaceHolder = new Rectangle(tile.Position.X + tile.Width + 2, tile.Position.Y, 20, 20);
            pe.Graphics.DrawImage(Resources.rotate, rPlaceHolder);
            return rPlaceHolder;
        }

        private void PaintSelectionBorder(Graphics g)
        {
            Pen pen = Pens.Blue;
            g.DrawRectangle(pen, MovingElement.Rect);
            //g.DrawRectangle(pen, _movingElement.Position.X, _movingElement.Position.Y, _movingElement.Width, _movingElement.Height);
        }

        #endregion Paint related methods

    }
}

