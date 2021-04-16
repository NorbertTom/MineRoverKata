using System;
using Xunit;
using MineRoverKata;

namespace MineRoverKataTests
{
    public class InputDataBufferTests
    {
        [Theory]
        [InlineData("4 7")]
        [InlineData("5 2")]
        [InlineData("10 100")]
        public void SizeOfArenaSetterAndGetter(string sizeOfArena)
        {
            var inputDataBuffer = new InputDataBuffer();
            inputDataBuffer.SetSizeOfArena(sizeOfArena);

            Assert.Equal(sizeOfArena, inputDataBuffer.GetSizeOfArena());
        }

        [Fact]
        public void InitialPositionAndOrientationAdderAndGetter_MultipleAdds()
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
        public void CommandStreamAdderAndGetter()
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
        public void GetNrOfRobots()
        {
            var inputDataBuffer = new InputDataBuffer();
            string[] initialPositions = { "1 5 E", "2 5 W", "5 1 N", "10 20 S" };
            for (int i=0; i<initialPositions.Length; i++)
            {
                inputDataBuffer.AddInitialPositionAndOrientation(initialPositions[i]);
            }

            int expectedNrOfRobots = initialPositions.Length;
            Assert.Equal(expectedNrOfRobots, inputDataBuffer.NrOfRobots);
        }
    }
}
