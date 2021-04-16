using System;
using System.Collections.Generic;
using Xunit;
using MineRoverKata;

namespace MineRoverKataTests
{
    public class ExampleInputTests
    {
        [Fact]
        public static void GivenExampleIntput_RetursCorrectOutput()
        {
            var inputData = new InputDataBuffer();

            inputData.SetSizeOfArena("5 5");
            inputData.AddInitialPositionAndOrientation("1 2 N");
            inputData.AddCommandStream("LMLMLMLMM");
            inputData.AddInitialPositionAndOrientation("3 3 E");
            inputData.AddCommandStream("MMRMMRMRRM");

            int nrOfRobots = inputData.NrOfRobots;

            var mineRovers = new MineRovers(nrOfRobots);

            var inputConsumer = new ConsumeInputPhaseExecutor(inputData, mineRovers);
            inputConsumer.Run();

            for (int robotIndex = 0; robotIndex < nrOfRobots; robotIndex++)
            {
                var robotActionExecutor = new RobotActionExecutor(mineRovers.Robots[robotIndex],
                                                                  mineRovers.CommandStreams[robotIndex],
                                                                  mineRovers.arena);
                robotActionExecutor.ExecuteAllActions();
            }

            string[] resultOutputs = new string[2];
            for (int robotIndex = 0; robotIndex < nrOfRobots; robotIndex++)
            {
                int[] finalPosition = mineRovers.Robots[robotIndex].GetPosition();
                char finalOrientation = mineRovers.Robots[robotIndex].GetOrientationAsChar();
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
