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
        public static void runTest()
        {
            int nrOfRobots = 3;
            var mockDataInput = new Mock<IInputDataBuffer>();
            string mockedSizeOfArena = "10 25";
            mockDataInput.Setup(x => x.GetSizeOfArena()).Returns(mockedSizeOfArena);
            mockDataInput.Setup(x => x.GetNrOfRobots()).Returns(nrOfRobots);
            mockDataInput.Setup(x => x.GetInitialPositionAndOrientation(0)).Returns("0 0 E");
            mockDataInput.Setup(x => x.GetInitialPositionAndOrientation(1)).Returns("2 1 W");
            mockDataInput.Setup(x => x.GetInitialPositionAndOrientation(2)).Returns("10 25 S");
            string[] mockedCommandStreams = { "LRLRLR", "LMMLMMLMMLMM", "RRMLMLMRR" };
            for (int i = 0; i < nrOfRobots; i++)
            {
                mockDataInput.Setup(x => x.GetCommandStream(i)).Returns(mockedCommandStreams[i]);
            }

            var mockArena = new Mock<IArena>();
            mockArena.Setup(x => x.GetWidth()).Returns(10);
            mockArena.Setup(x => x.GetHeight()).Returns(25);

            List<Robot> robots = new List<Robot>();
            for (int i = 0; i < nrOfRobots; i++)
            {
                robots.Add(new Robot());

            }
            List<string> commandStreams = new List<string>();

            ConsumeInputPhaseExecutor.Run(mockDataInput.Object, mockArena.Object, robots, commandStreams);

            int[] expectedPosition0 = { 0, 0 };
            int[] expectedPosition1 = { 2, 1 };
            int[] expectedPosition2 = { 10, 25 };
            int[][] expectedPositions = { expectedPosition0, expectedPosition1, expectedPosition2};

            char[] expectedOrientations = { 'E', 'W', 'S' };
            for (int i=0; i< nrOfRobots; i++)
            {
                Assert.Equal(expectedPositions[i], robots[i].GetPosition());
                Assert.Equal(expectedOrientations[i], robots[i].GetOrientationAsChar());
                Assert.Equal(mockedCommandStreams[i], commandStreams[i]);
            }
            mockArena.Verify(x => x.SetWidth(10), Times.Once());
            mockArena.Verify(x => x.SetHeight(25), Times.Once());
        }
    }
}
