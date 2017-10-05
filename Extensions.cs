
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndromedaCanvas.Canvas
{
    public static class Extensions
    {
        public static SFML.System.Vector2i ToSFML(this System.Drawing.Size size)
        {
            return new SFML.System.Vector2i(size.Width, size.Height);
        }

        public static System.Drawing.Size FromSFML(this SFML.System.Vector2i size)
        {
            return new System.Drawing.Size(size.X, size.Y);
        }
    }
}
