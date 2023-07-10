using System;
using System.Windows.Forms;

namespace PlayingWithGraphicsFramework
{
    partial class FormBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private readonly int _topControlsPanelHeight = 30;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.FormBoard_TimerEvent);
            // 
            // FormBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.DoubleBuffered = true;
            this.Name = "FormBoard";
            this.Text = "Domino";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormBoard_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormBoard_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormBoard_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormBoard_MouseUp);

            AddTopBarButtons();
            this.ResumeLayout(false);
        }

        private void AddTopBarButtons()
        {
            //Top button bar
            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.FlowDirection = FlowDirection.RightToLeft;
            flp.Height = _topControlsPanelHeight;
            flp.Width = this.ClientSize.Width;
            //Apply btn
            Button btnApply = new Button();
            btnApply.Text = "Apply";
            btnApply.Click += new System.EventHandler(this.BtnApply_Click);

            flp.Controls.Add(btnApply);
            //Undo btn
            Button btnUndo = new Button();
            btnUndo.Text = "Undo";
            btnUndo.Click += new System.EventHandler(this.BtnUndo_Click);
            flp.Controls.Add(btnUndo);

            this.Controls.Add(flp);
        }
        #endregion

        private Timer timer1;
    }
}

