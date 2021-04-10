using System;
using System.Collections.Generic;
using System.Text;

namespace MineRoverKata
{
    static class InputDataPhaseExecutor
    {
        public static InputDataBuffer Run()
        {
            InputDataBuffer inputDataBuffer = new InputDataBuffer();
            
            UIMessages.OpeningMessage();

            InputSizeOfArena(inputDataBuffer);
            InputRobotsData(inputDataBuffer);

            return inputDataBuffer;
        }

        private static void InputSizeOfArena(InputDataBuffer inputDataBuffer)
        {
            UIMessages.InputSizeOfArenaMessage();
            string inputSizeOfArena = Console.ReadLine();
            inputDataBuffer.SetSizeOfArena(inputSizeOfArena);
        }

        private static void InputRobotsData(InputDataBuffer inputDataBuffer)
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
