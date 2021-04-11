using System;
using System.Diagnostics;

namespace MineRoverKata
{
    class Arena : IArena
    {
        public Arena()
        {}

        public void SetWidth(int width)
        {
            Debug.Assert(width > 0, "Width cannot be less then or equal to 0");
            
            this.width = width;
        }

        public int GetWidth()
        {
            return width;
        }

        public void SetHeight(int height)
        {
            Debug.Assert(height > 0, "Height cannot be less then or equal to 0");

            this.height = height;
        }

        public int GetHeight()
        {
            return height;
        }

        private int width;
        private int height;
    }
}
