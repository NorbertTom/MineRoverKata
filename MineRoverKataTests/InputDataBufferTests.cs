using System;
using Xunit;
using MineRoverKata;

namespace MineRoverKataTests
{
    public class InputDataBufferTests
    {
        [Fact]
        public void sizeOfArenaSetterAndGetter()
        {
            string sizeOfArena = "4 7";
            var inputDataBuffer = new InputDataBuffer();
            inputDataBuffer.SetSizeOfArena(sizeOfArena);

            Assert.Equal(sizeOfArena, inputDataBuffer.GetSizeOfArena());

            sizeOfArena = "5 2";
            inputDataBuffer.SetSizeOfArena(sizeOfArena);
            Assert.Equal(sizeOfArena, inputDataBuffer.GetSizeOfArena());

            sizeOfArena = "10 100";
            inputDataBuffer.SetSizeOfArena(sizeOfArena);
            Assert.Equal(sizeOfArena, inputDataBuffer.GetSizeOfArena());
        }

        [Fact]
        public void initialPositionAndOrientationAdderAndGetter_MultipleAdds()
        {
            var inputDataBuffer = new InputDataBuffer();
            string[] initPositionAndOrientation = { "3 0 N", "2 1 E", "5 5 W", "10 2 S", "0 0 E" };
            for (int i = 0; i < initPositionAndOrientation.Length; i++)
            {
                inputDataBuffer.AddInitialPositionAndOrientation(initPositionAndOrientation[i]);
            }
            for (int i = 0; i < initPositionAndOrientation.Length; i++)
            {
                Assert.Equal(initPositionAndOrientation[i], inputDataBuffer.GetInitialPositionAndOrientation(i));
            }
        }

        [Fact]
        public void commandStreamAdderAndGetter()
        {
            var inputDataBuffer = new InputDataBuffer();
            string[] inputCommandStream = { "LLLMLMLRLR", "LLMMMRRML", "L", "R", "MMRRMM" };
            for (int i = 0; i < inputCommandStream.Length; i++)
            {
                inputDataBuffer.AddCommandStream(inputCommandStream[i]);
            }
            for (int i = 0; i < inputCommandStream.Length; i++)
            {
                Assert.Equal(inputCommandStream[i], inputDataBuffer.GetCommandStream(i));
            }
        }

        [Fact]
        public void getNrOfRobots()
        {
            var inputDataBuffer = new InputDataBuffer();
            string[] initialPositions = { "1 5 E", "2 5 W", "5 1 N", "10 20 S" };
            for (int i=0; i<initialPositions.Length; i++)
            {
                inputDataBuffer.AddInitialPositionAndOrientation(initialPositions[i]);
            }

            int expectedNrOfRobots = initialPositions.Length;
            Assert.Equal(expectedNrOfRobots, inputDataBuffer.GetNrOfRobots());
        }
    }
}
