using System;
using System.Collections.Generic;


namespace MineRoverKata
{
    class Program
    {
        static void Main(string[] args)
        {

            var inputData = new InputDataBuffer();
            InputDataPhaseExecutor.Run(inputData);

            var arena = new Arena();
            List<Robot> robots = new List<Robot>();
            List<string> commandStreams = new List<string>();
            prepareLists(robots, commandStreams, inputData.GetNrOfRobots());


            // Engine
            // execute commands
            // output final position
        }

        private static void prepareLists(List<Robot> robots, List<string> commandStreams, int finalSize)
        {
            for (int i = 0; i < finalSize; i++)
            {
                robots.Add(new Robot());
            }
        }
}
}
