using System;
using Xunit;
using Moq;
using MineRoverKata;


namespace MineRoverKataTests
{
    public class RobotActionExecutorTests
    {
        [Fact]
        public static void TurningLeft()
        {
            var arenaMock = new Mock<IArena>();
            var robotMock = new Mock<IRobot>();
            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.East);
            string commandStream = "L";

            var robotActionExecutor = new RobotActionExecutor(robotMock.Object, commandStream, arenaMock.Object);
            robotActionExecutor.ExecuteAllActions();
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.North), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.East), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.South), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.West), Times.Never());

            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.North);

            robotActionExecutor.ExecuteAllActions();
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.North), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.East), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.South), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.West), Times.Once());

            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.West);

            robotActionExecutor.ExecuteAllActions();
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.North), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.East), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.South), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.West), Times.Once());

            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.South);

            robotActionExecutor.ExecuteAllActions();
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.North), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.East), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.South), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.West), Times.Once());
        }

        [Fact]
        public static void TurningRight()
        {
            var arenaMock = new Mock<IArena>();
            var robotMock = new Mock<IRobot>();
            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.South);
            string commandStream = "R";

            var robotActionExecutor = new RobotActionExecutor(robotMock.Object, commandStream, arenaMock.Object);
            robotActionExecutor.ExecuteAllActions();
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.North), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.East), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.South), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.West), Times.Once());

            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.West);

            robotActionExecutor.ExecuteAllActions();
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.North), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.East), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.South), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.West), Times.Once());

            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.North);

            robotActionExecutor.ExecuteAllActions();
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.North), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.East), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.South), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.West), Times.Once());

            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.North);

            robotActionExecutor.ExecuteAllActions();
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.North), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.East), Times.Exactly(2));
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.South), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.West), Times.Once());
        }

        [Theory]
        [InlineData(4, 0, RobotOrientation.South)]
        [InlineData(4, 2, RobotOrientation.North)]
        [InlineData(3, 1, RobotOrientation.West)]
        [InlineData(5, 1, RobotOrientation.East)]
        public static void Moving(int endPositionX, int endPositionY, RobotOrientation orientation)
        {
            var arenaMock = new Mock<IArena>();
            var robotMock = new Mock<IRobot>();
            int[] mockGetPositionReturn = { 4, 1 };
            arenaMock.Setup(x => x.CheckPosition(endPositionX, endPositionY)).Returns(true);
            robotMock.Setup(x => x.GetOrientation()).Returns(orientation);
            robotMock.Setup(x => x.GetPosition()).Returns(mockGetPositionReturn);
            string commandStream = "M";

            var robotActionExecutor = new RobotActionExecutor(robotMock.Object, commandStream, arenaMock.Object);
            robotActionExecutor.ExecuteAllActions();

            robotMock.Verify(x => x.SetPosition(endPositionX, endPositionY), Times.Once());
        }
    }
}
