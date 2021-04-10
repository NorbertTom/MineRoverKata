using System;
using System.Diagnostics;

namespace MineRoverKata
{
    class Arena
    {
        public Arena()
        {}

        public void SetWidth(int width)
        {
            Debug.Assert(width > 0, "Width cannot be less or equal to 0");
            
            this.width = width;
        }

        public int GetWidth()
        {
            return width;
        }

        private int width;
    }
}
