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
            addEmptyRobotsToList(robots, inputData.GetNrOfRobots());
            List<string> commandStreams = new List<string>();

            ConsumeInputPhaseExecutor.Run(inputData, arena, robots, commandStreams);

            int nrOfRobots = inputData.GetNrOfRobots();

            for (int robotIndex = 0; robotIndex < nrOfRobots; robotIndex++)
            {
                ExecuteCommands.Run(robots[robotIndex], commandStreams[robotIndex]);
            }

            for (int robotIndex = 0; robotIndex < nrOfRobots; robotIndex++)
            {
                int[] finalPosition = robots[robotIndex].GetPosition();
                char finalOrientation = robots[robotIndex].GetOrientationAsChar();
                Console.WriteLine(finalPosition[0] + " " + finalPosition[1] + " "  + finalOrientation);
            }
        }

        private static void addEmptyRobotsToList(List<Robot> robots, int finalSize)
        {
            for (int i = 0; i < finalSize; i++)
            {
                robots.Add(new Robot());
            }
        }
}
}
