using System;
using System.Diagnostics;

namespace MineRoverKata
{
    class Arena : IArena
    {
        public Arena(Dimensions dimensions)
        {
            if (dimensions.Width <= 0)
            {
                throw new Exception("Width cannot be less or equal to 0");
            }
            if (dimensions.Height <= 0)
            {
                throw new Exception("Height cannot be less or equal to 0");
            }
            Width = dimensions.Width;
            Height = dimensions.Height;
        }

        public bool CheckPosition(int x, int y)
        {
            return !(x < 0 || y < 0 || x > Width || y > Height);
        }

        public int Width { get; private set; }
        public int Height { get; private set; }
    }
}
