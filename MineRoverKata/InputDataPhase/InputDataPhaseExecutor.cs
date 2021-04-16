using System;
using System.Collections.Generic;
using System.Text;

namespace MineRoverKata
{
    class InputDataPhaseExecutor
    {
        public InputDataPhaseExecutor(IInputDataBuffer inputDataBuffer)
        {
            this.inputDataBuffer = inputDataBuffer;
        }

        public void Run()
        {
            UIMessages.OpeningMessage();
            InputSizeOfArena();
            InputRobotsData();
        }

        private void InputSizeOfArena()
        {
            UIMessages.InputSizeOfArenaMessage();
            string inputSizeOfArena = Console.ReadLine();
            inputDataBuffer.SetSizeOfArena(inputSizeOfArena);
        }

        private void InputRobotsData()
        {
            bool keepAddingRobots = true;
            while (keepAddingRobots)
            {
                keepAddingRobots = InputInitialPositionAndOrientation();

                if (keepAddingRobots)
                {
                    InputCommandStream();
                }
            }
        }

        private bool InputInitialPositionAndOrientation()
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

        private void InputCommandStream()
        {
            UIMessages.InputCommandStreamMessage();
            string inputCommandStream = Console.ReadLine();
            inputDataBuffer.AddCommandStream(inputCommandStream);
        }

        IInputDataBuffer inputDataBuffer;
    }
}