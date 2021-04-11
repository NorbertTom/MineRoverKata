using System;
using System.Collections.Generic;
using System.Text;

namespace MineRoverKata
{
    static class RobotActionExecutor
    {
        public static void Execute(IRobot robot, char action)
        {
            switch (action)
            {
                case 'L':
                    turnLeft(robot);
                    break;
                case 'R':
                    turnRight(robot);
                    break;
                case 'M':
                    move(robot);
                    break;
            }
        }
        
        private static void turnLeft(IRobot robot)
        {
            RobotOrientation orientation = robot.GetOrientation();
            if (orientation == RobotOrientation.North)
            {
                orientation = RobotOrientation.West;
            }
            else
            {
                orientation--;
            }
            robot.SetOrientation(orientation);
        }

        private static void turnRight(IRobot robot)
        {
            RobotOrientation orientation = robot.GetOrientation();
            if (orientation == RobotOrientation.West)
            {
                orientation = RobotOrientation.North;
            }
            else
            {
                orientation++;
            }
            robot.SetOrientation(orientation);
        }

        private static void move(IRobot robot)
        {
            var orientation = robot.GetOrientation();
            int[] robotDisplacement = MoveRobot.GetRobotDisplacement(orientation);
            int[] currentPosition = robot.GetPosition();
            int[] finalPosition = { currentPosition[0] + robotDisplacement[0], currentPosition[1] + robotDisplacement[1] };
            robot.SetPosition(finalPosition[0], finalPosition[1]);
        }
    }
}
