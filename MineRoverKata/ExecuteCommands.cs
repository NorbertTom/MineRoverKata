using System;
using System.Collections.Generic;
using System.Text;

namespace MineRoverKata
{
    static class ExecuteCommands
    {
        public static void Run(IRobot robot, string commandStream)
        {
            for (int commandIndex = 0; commandIndex < commandStream.Length; commandIndex++)
            {
                RobotActionExecutor.Execute(robot, commandStream[commandIndex]);
            }
        }
    }
}
