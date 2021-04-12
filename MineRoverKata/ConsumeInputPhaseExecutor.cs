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
            PositionValidator.SetMaxX(arena.GetWidth());
            PositionValidator.SetMaxY(arena.GetHeight());
        }

        private static void createRobots(IInputDataBuffer inputData, List<Robot> robots)
        {
            int nrOfRobots = inputData.GetNrOfRobots();
            for (int robotIndex = 0; robotIndex < nrOfRobots; robotIndex++)
            {
                string initPosAndOrientString = inputData.GetInitialPositionAndOrientation(robotIndex);
                var initPosAndOrient = InputDataTranslator.TranslateInitialPositionAndOrientation(
                                                                            initPosAndOrientString);
                validateInitialPositionAndOrientation(initPosAndOrient);

                robots[robotIndex].SetPosition(initPosAndOrient.X, initPosAndOrient.Y);
                robots[robotIndex].SetOrientation(initPosAndOrient.Orientation);
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
        
        private static void validateInitialPositionAndOrientation(InitialPositionAndOrientationTranslated initPosAndOrient)
        {
            bool isPositionValid = PositionValidator.checkPosition(initPosAndOrient.X, initPosAndOrient.Y);
            bool isOrientationValid = OrientationValidator.checkCharacter(initPosAndOrient.Orientation);

            if (!isPositionValid)
            {
                throw new Exception("Initial position invalid");
            }
            if (!isOrientationValid)
            {
                throw new Exception("Initial orientation invalid");
            }
        }
    }
}
