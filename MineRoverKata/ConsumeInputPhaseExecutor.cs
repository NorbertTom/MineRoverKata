using System;

namespace MineRoverKata
{
    class ConsumeInputPhaseExecutor
    {
        public ConsumeInputPhaseExecutor (IInputDataBuffer inputData, MineRovers mineRovers)
        {
            this.inputData = inputData;
            this.mineRovers = mineRovers;
        }

        public void Run()
        {
            SetSizeOfArena();
            CreateRobots();
            GetCommandStreams();
        }

        private void SetSizeOfArena()
        {
            var sizeOfArena = InputDataTranslator.TranslateSizeOfArena(inputData.GetSizeOfArena());
            mineRovers.arena = new Arena(sizeOfArena);
        }

        private void CreateRobots()
        {
            int nrOfRobots = inputData.NrOfRobots;
            for (int robotIndex = 0; robotIndex < nrOfRobots; robotIndex++)
            {
                string initPosAndOrientString = inputData.GetInitialPositionAndOrientation(robotIndex);
                var initPosAndOrient = InputDataTranslator.TranslateInitialPositionAndOrientation(
                                                                            initPosAndOrientString);
                ValidateInitialPositionAndOrientation(initPosAndOrient);

                mineRovers.Robots[robotIndex].SetPosition(initPosAndOrient.X, initPosAndOrient.Y);
                mineRovers.Robots[robotIndex].SetOrientation(initPosAndOrient.Orientation);
            }
        }

        private void GetCommandStreams()
        {
            int nrOfRobots = inputData.NrOfRobots;
            for (int i = 0; i < nrOfRobots; i++)
            {
                mineRovers.CommandStreams.Add(inputData.GetCommandStream(i));
            }
        }
        
        private void ValidateInitialPositionAndOrientation(InitialPositionAndOrientation initPosAndOrient)
        {
            bool isPositionValid = mineRovers.arena.CheckPosition(initPosAndOrient.X, initPosAndOrient.Y);
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

        private IInputDataBuffer inputData;
        private MineRovers mineRovers;
    }
}
