using System;
using System.Collections.Generic;
using System.Text;

namespace MineRoverKata
{
    static class PositionValidator
    {
        public static void SetMaxX(int arenaMaxX)
        {
            limitX = arenaMaxX;
        }

        public static void SetMaxY(int arenaMaxY)
        {
            limitY = arenaMaxY;
        }

        public static bool checkPosition(int x, int y)
        {
            return !(x < 0 || y < 0 || x > limitX || y > limitY);
         }

        private static int limitX;
        private static int limitY;
    }
}
