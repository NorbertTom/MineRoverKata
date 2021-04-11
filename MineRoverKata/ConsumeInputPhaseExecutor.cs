using System;
using System.Collections.Generic;
using System.Text;

namespace MineRoverKata
{
    static class ConsumeInputPhaseExecutor
    {
        public static void Run(IInputDataBuffer inputData, IArena arena, List<Robot> robots, List<string> commandStreams)
        {
            setSizeOfArena(inputData, arena);
            setLimitsForRobotMovement(arena);
            createRobots(inputData, robots);
            getCommandStreams(inputData, commandStreams);
        }

        private static void setSizeOfArena(IInputDataBuffer inputData, IArena arena)
        {
            var sizeOfArena = InputDataTranslator.TranslateSizeOfArena(inputData.GetSizeOfArena());
            arena.SetWidth(sizeOfArena.Width);
            arena.SetHeight(sizeOfArena.Height);
        }

        private static void setLimitsForRobotMovement(IArena arena)
        {
            RobotActionExecutor.SetMaxX(arena.GetWidth());
            RobotActionExecutor.SetMaxY(arena.GetHeight());
        }

        private static void createRobots(IInputDataBuffer inputData, List<Robot> robots)
        {
            int nrOfRobots = inputData.GetNrOfRobots();
            for (int robotIndex = 0; robotIndex < nrOfRobots; robotIndex++)
            {
                var initialPositionAndOrientation = InputDataTranslator.TranslateInitialPositionAndOrientation(
                                                        inputData.GetInitialPositionAndOrientation(robotIndex));
                bool isPositionValid = RobotActionExecutor.IsPositionValid(
                                                                    initialPositionAndOrientation.X,
                                                                    initialPositionAndOrientation.Y);
                if (!isPositionValid)
                {
                    throw new Exception("Initial position invalid");
                }
                
                robots[robotIndex].SetPosition(initialPositionAndOrientation.X, initialPositionAndOrientation.Y);
                robots[robotIndex].SetOrientation(initialPositionAndOrientation.Orientation);
            }
        }

        private static void getCommandStreams(IInputDataBuffer inputData, List<string> commandStreams)
        {
            int nrOfRobots = inputData.GetNrOfRobots();
            for (int i = 0; i < nrOfRobots; i++)
            {
                commandStreams.Add(inputData.GetCommandStream(i));
            }
        }
    }
}
