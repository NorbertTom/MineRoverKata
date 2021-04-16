using System;
using System.Collections.Generic;


namespace MineRoverKata
{
    class Program
    {
        static void Main(string[] args)
        {

            var inputData = new InputDataBuffer();
            var inputDataPhaseExecutor = new InputDataPhaseExecutor(inputData);
            inputDataPhaseExecutor.Run();

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

            for (int robotIndex = 0; robotIndex < nrOfRobots; robotIndex++)
            {
                int[] finalPosition = mineRovers.Robots[robotIndex].GetPosition();
                char finalOrientation = mineRovers.Robots[robotIndex].GetOrientationAsChar();
                Console.WriteLine(finalPosition[0] + " " + finalPosition[1] + " "  + finalOrientation);
            }
        }
    }
}
