using System;
using System.Collections.Generic;
using System.Text;

namespace MineRoverKata
{
    static class MoveRobot
    {
        public static int[] GetRobotDisplacement(RobotOrientation orientation)
        {
            int[] robotDisplacement = { 0, 0 };
            switch (orientation)
            {
                case RobotOrientation.North:
                    robotDisplacement = North();
                    break;
                case RobotOrientation.East:
                    robotDisplacement = East();
                    break;
                case RobotOrientation.South:
                    robotDisplacement = South();
                    break;
                case RobotOrientation.West:
                    robotDisplacement = West();
                    break;
            }
            return robotDisplacement;
        }
           
        private static int[] North()
        {
            int[] result = { 0, 1 };
            return result;
        }

        private static int[] East()
        {
            int[] result = { 1, 0 };
            return result;
        }

        private static int[] South()
        {
            int[] result = { 0, -1 };
            return result;
        }

        private static int[] West()
        {
            int[] result = { -1, 0 };
            return result;
        }
    }
}
