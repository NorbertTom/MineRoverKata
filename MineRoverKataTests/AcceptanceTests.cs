using System;
using System.Collections.Generic;
using Xunit;
using MineRoverKata;

namespace MineRoverKataTests
{
    public class AcceptanceTests
    {
        [Fact]
        public static void acceptanceTest1()
        {
            var inputData = new InputDataBuffer();

            inputData.SetSizeOfArena("5 5");
            inputData.AddInitialPositionAndOrientation("1 2 N");
            inputData.AddCommandStream("LMLMLMLMM");
            inputData.AddInitialPositionAndOrientation("3 3 E");
            inputData.AddCommandStream("MMRMMRMRRM");

            int nrOfRobots = inputData.GetNrOfRobots();
            var arena = new Arena();
            List<Robot> robots = new List<Robot>();
            for (int i = 0; i < nrOfRobots; i++)
            {
                robots.Add(new Robot());
            }
            List<string> commandStreams = new List<string>();

            ConsumeInputPhaseExecutor.Run(inputData, arena, robots, commandStreams);

            for (int robotIndex = 0; robotIndex < nrOfRobots; robotIndex++)
            {
                ExecuteCommands.Run(robots[robotIndex], commandStreams[robotIndex]);
            }

            string[] resultOutputs = new string[2];
            for (int robotIndex = 0; robotIndex < nrOfRobots; robotIndex++)
            {
                int[] finalPosition = robots[robotIndex].GetPosition();
                char finalOrientation = robots[robotIndex].GetOrientationAsChar();
                resultOutputs[robotIndex] = finalPosition[0] + " " + finalPosition[1] + " " + finalOrientation;
            }
            string[] expectedOutputs = { "1 3 N", "5 1 E" };
            for (int i = 0; i < nrOfRobots; i++)
            {
                Assert.Equal(expectedOutputs[i], resultOutputs[i]);
            }
        } 
    }
}
