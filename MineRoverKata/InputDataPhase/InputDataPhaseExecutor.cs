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
            while (true)
            {
                UIMessages.InputInitialPositionAndOrientationMessage();
                string inputInitPositionAndOrientation = Console.ReadLine();
                if (inputInitPositionAndOrientation == "")
                {
                    break;
                }
                inputDataBuffer.AddInitialPositionAndOrientation(inputInitPositionAndOrientation);

                UIMessages.InputCommandStreamMessage();
                string inputCommandStream = Console.ReadLine();
                inputDataBuffer.AddCommandStream(inputCommandStream);
            }
        }
    }
}
