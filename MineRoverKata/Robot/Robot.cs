using System;
using System.Collections.Generic;
using System.Text;

namespace MineRoverKata
{


    class Robot : IRobot
    {
        public Robot()
        {}

        public void SetPosition(int x, int y)
        {
            currentX = x;
            currentY = y;
        }

        public int[] GetPosition()
        {
            int[] currentPosition = { currentX, currentY };
            return currentPosition;
        }

        public void SetOrientation(RobotOrientation orientation)
        {
            this.orientation = orientation;
        }

        public RobotOrientation GetOrientation()
        {
            return orientation;
        }
        
        
        public void SetOrientation(char orientationChar)
        {

            this.orientation = getRobotOrientationFromChar(orientationChar);
        }

        public char GetOrientationAsChar()
        {
            char result = ' ';
            switch (orientation)
            {
                case RobotOrientation.North:
                        result = 'N';
                        break;
                case RobotOrientation.West:
                        result = 'W';
                        break;
                case RobotOrientation.South:
                        result = 'S';
                        break;
                case RobotOrientation.East:
                        result = 'E';
                        break;
            }
            return result;
        }

        private RobotOrientation getRobotOrientationFromChar(char orientationChar)
        {
            RobotOrientation result = RobotOrientation.North;
            switch (orientationChar)
            {
                case 'N':
                    result = RobotOrientation.North;
                    break;
                case 'W':
                    result = RobotOrientation.West;
                    break;
                case 'S':
                    result = RobotOrientation.South;
                    break;
                case 'E':
                    result = RobotOrientation.East;
                    break;
            }
            return result;
        }

        private int currentX;
        private int currentY;
        RobotOrientation orientation;
    }
}
