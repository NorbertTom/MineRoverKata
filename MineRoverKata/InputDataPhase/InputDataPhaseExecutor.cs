using System;
using System.Collections.Generic;
using System.Text;

namespace MineRoverKata
{
    static class InputDataPhaseExecutor // untestable - user input needed
    {
        public static void Run(IInputDataBuffer inputDataBuffer)
        {
            UIMessages.OpeningMessage();
            InputSizeOfArena(inputDataBuffer);
            InputRobotsData(inputDataBuffer);
        }

        private static void InputSizeOfArena(IInputDataBuffer inputDataBuffer)
        {
            UIMessages.InputSizeOfArenaMessage();
            string inputSizeOfArena = Console.ReadLine();
            inputDataBuffer.SetSizeOfArena(inputSizeOfArena);
        }

        private static void InputRobotsData(IInputDataBuffer inputDataBuffer)
        {
            bool keepAddingRobots = true;
            while (keepAddingRobots)
            {
                keepAddingRobots = InputInitialPositionAndOrientation(inputDataBuffer);

                if (keepAddingRobots)
                {
                    InputCommandStream(inputDataBuffer);
                }
            }
        }

        private static bool InputInitialPositionAndOrientation(IInputDataBuffer inputDataBuffer)
        {
            bool keepAddingRobots = true;

            UIMessages.InputInitialPositionAndOrientationMessage();
            string inputInitPositionAndOrientation = Console.ReadLine();
            
            if (inputInitPositionAndOrientation == "")
            {
                keepAddingRobots = false;
            }
            else
            {
                inputDataBuffer.AddInitialPositionAndOrientation(inputInitPositionAndOrientation);
            }

            return keepAddingRobots;
        }

        private static void InputCommandStream(IInputDataBuffer inputDataBuffer)
        {
            UIMessages.InputCommandStreamMessage();
            string inputCommandStream = Console.ReadLine();
            inputDataBuffer.AddCommandStream(inputCommandStream);
        }
    }
}