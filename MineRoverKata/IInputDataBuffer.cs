using System;
using System.Collections.Generic;
using System.Text;

namespace MineRoverKata
{
    interface IInputDataBuffer
    {
        public void SetSizeOfArena(string sizeOfArena);
        public string GetSizeOfArena();

        public void AddInitialPositionAndOrientation(string initialPositionAndOrientation);
        public string GetInitialPositionAndOrientation(int index);

        public void AddCommandStream(string commandStream);
        public string GetCommandStream(int index);
    }
}
