using System;
using System.Collections.Generic;
using System.Text;

namespace MineRoverKata
{
    class RobotActionExecutor
    {
        public RobotActionExecutor(IRobot robot, string commandStream, IArena arena)
        {
            this.robot = robot;
            this.commandStream = commandStream;
            this.arena = arena;
        }

        public void ExecuteAllActions()
        {
            for (int commandIndex = 0; commandIndex < commandStream.Length; commandIndex++)
            {
                ExecuteSingleAction(commandStream[commandIndex]);
            }
        }

        private void ExecuteSingleAction(char action)
        {
            switch (action)
            {
                case 'L':
                    TurnLeft();
                    break;
                case 'R':
                    TurnRight();
                    break;
                case 'M':
                    Move();
                    break;
            }
        }

        private void TurnLeft()
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

        private void TurnRight()
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

        private void Move()
        {
            RobotOrientation orientation = robot.GetOrientation();
            int[] robotDisplacement = MoveRobot.GetRobotDisplacement(orientation);
            int[] currentPosition = robot.GetPosition();
            int[] finalPosition = { currentPosition[0] + robotDisplacement[0],
                                    currentPosition[1] + robotDisplacement[1] };
            
            if (!arena.CheckPosition(finalPosition[0], finalPosition[1]))
            {
                throw new Exception("Move puts robot out of the arena");
            }

            robot.SetPosition(finalPosition[0], finalPosition[1]);
        }

        private IRobot robot;
        private string commandStream;
        private IArena arena;
        
    }
}
