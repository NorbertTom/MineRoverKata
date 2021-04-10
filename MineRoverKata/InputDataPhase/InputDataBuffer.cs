using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace MineRoverKata
{
    class InputDataBuffer : IInputDataBuffer
    {
        public InputDataBuffer()
        { }

        public void SetSizeOfArena(string sizeOfArena)
        {
            this.sizeOfArena = sizeOfArena;
        }

        public string GetSizeOfArena()
        {
            return sizeOfArena;
        }

        public void AddInitialPositionAndOrientation(string initialPositionAndOrientation)
        {
            this.initialPostionAndOrientation.Add(initialPositionAndOrientation);
        }

        public string GetInitialPositionAndOrientation(int index)
        {
            Debug.Assert(index >= 0, "Index has to be >= 0");
            Debug.Assert(index < initialPostionAndOrientation.Count, "Index has to be smaller than size of the List");

            return initialPostionAndOrientation[index];
        }

        public void AddCommandStream(string commandStream)
        {
            this.commandStream.Add(commandStream);
        }

        public string GetCommandStream(int index)
        {
            Debug.Assert(index >= 0, "Index has to be >= 0");
            Debug.Assert(index < commandStream.Count, "Index has to be smaller than size of the List");

            return commandStream[index];
        }


        private string sizeOfArena;
        private List<string> initialPostionAndOrientation = new List<string>();
        private List<string> commandStream = new List<string>();
    }
}
