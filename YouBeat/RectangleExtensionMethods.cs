using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouBeat
{
    public static class RectangleExtensionMethods
    {
        public static Vector2 PercentagePoint(this Rectangle rect, float x, float y)
        {
            return new Vector2(rect.Width * x + rect.X, rect.Height * y + rect.Y);
        }
        public static Rectangle PercentagePoint(this Rectangle rect, float x, float y, float w, float h)
        {
            return new Rectangle((int)(rect.Width * x) + rect.X, (int)(rect.Height * y) + rect.Y, (int)(rect.Width * w), (int)(rect.Height * h));
        }
    }
}
