

using Andromeda2D.System;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Andromeda.Canvas
{
    public class AndromedaCanvas : UserControl
    {
        private Andromeda2D.System.Application _application;
        internal AndromedaCanvasApplication _controller;

        protected void InitializeComponent()
        {

        }

        protected void Start()
        {

        }

        public AndromedaCanvas()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_controller == null)
                base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (_controller == null)
                base.OnPaintBackground(pevent);
        }
    }
}
