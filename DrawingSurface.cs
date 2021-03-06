﻿

using Andromeda2D.System;
using SFML.System;
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

        public delegate void SurfaceResizedEvent(Vector2i size);
        public event SurfaceResizedEvent Resized;

        protected override void OnResize(EventArgs e)
        {
            Resized?.Invoke(Size.ToSFML());
        }

        public Vector2i SFMLSize
        {
            get => Size.ToSFML();
            set => value.FromSFML();
        }
    }
}
