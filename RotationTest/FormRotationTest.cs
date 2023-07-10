using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotationTest
{
    public partial class RotationTest : Form
    {
        public RotationTest()
        {
            InitializeComponent();
        }

        private void RotationTest_Paint(object sender, PaintEventArgs pe) {
            var g = pe.Graphics;
            var clientSize = ClientSize;
            var center = new Point(clientSize.Width / 2, clientSize.Height / 2);
            var squareSize = new Size(100, 200);

            g.TranslateTransform(center.X, center.Y);

            var squareLocation = new Point(-squareSize.Width/2, -squareSize.Height /2);
            var squareBounds = new Rectangle(squareLocation, squareSize);
            var pen = Pens.Blue;

            //for (int i = 1; i <= 3; i++) {
            g.RotateTransform(90);
            g.DrawRectangle(pen, squareBounds);
                
                //g.ScaleTransform(0.5F, 0.5F);
            //}
            g.ResetTransform();
        }

        private void RotationTest_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
