using System;
using System.Collections.Generic;
using System.Text;

namespace MineRoverKata
{
    enum RobotOrientation
    {
        North = 0,
        East,
        South,
        West
    }

    interface IRobot
    {
        public void SetPosition(int x, int y);
        public int[] GetPosition();
        public void SetOrientation(RobotOrientation orientation);
        public RobotOrientation GetOrientation();
        public void SetOrientation(char orientationChar);
        public char GetOrientationAsChar();
    }
}
