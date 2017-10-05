

using Andromeda2D.System;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AndromedaCanvas.Canvas
{
    public class DrawingSurface : Control
    {
        bool _customRendering = false;
        internal bool CustomRenderingEnabled
        {
            get => _customRendering;
            set => _customRendering = value;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!CustomRenderingEnabled)
                base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (!CustomRenderingEnabled)
                base.OnPaintBackground(pevent);
        }
    }
}
