﻿using System;
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
            //        move(robot);
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
    }
}