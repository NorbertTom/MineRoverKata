using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using MineRoverKata;

namespace MineRoverKataTests
{
    public class ConsumeInputPhaseExecutorTest
    {
        [Fact]
        public static void RunTest()
        {
            int nrOfRobots = 3;
            var mockDataInput = new Mock<IInputDataBuffer>();
            string mockedSizeOfArena = "10 25";
            mockDataInput.Setup(x => x.GetSizeOfArena()).Returns(mockedSizeOfArena);
            mockDataInput.Setup(x => x.NrOfRobots).Returns(nrOfRobots);
            mockDataInput.Setup(x => x.GetInitialPositionAndOrientation(0)).Returns("0 0 E");
            mockDataInput.Setup(x => x.GetInitialPositionAndOrientation(1)).Returns("2 1 W");
            mockDataInput.Setup(x => x.GetInitialPositionAndOrientation(2)).Returns("10 25 S");
            string[] mockedCommandStreams = { "LRLRLR", "LMMLMMLMMLMM", "RRMLMLMRR" };
            for (int i = 0; i < nrOfRobots; i++)
            {
                mockDataInput.Setup(x => x.GetCommandStream(i)).Returns(mockedCommandStreams[i]);
            }

            var mineRovers = new MineRovers(nrOfRobots);

            var inputConsumer = new ConsumeInputPhaseExecutor(mockDataInput.Object, mineRovers);
            inputConsumer.Run();

            int[] expectedPosition0 = { 0, 0 };
            int[] expectedPosition1 = { 2, 1 };
            int[] expectedPosition2 = { 10, 25 };
            int[][] expectedPositions = { expectedPosition0, expectedPosition1, expectedPosition2};

            char[] expectedOrientations = { 'E', 'W', 'S' };
            for (int i=0; i< nrOfRobots; i++)
            {
                Assert.Equal(10, mineRovers.arena.Width);
                Assert.Equal(25, mineRovers.arena.Height);
                Assert.Equal(expectedPositions[i], mineRovers.Robots[i].GetPosition());
                Assert.Equal(expectedOrientations[i], mineRovers.Robots[i].GetOrientationAsChar());
                Assert.Equal(mockedCommandStreams[i], mineRovers.CommandStreams[i]);
            }
        }
    }
}
