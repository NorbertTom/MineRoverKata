using System;
using Xunit;
using Moq;
using MineRoverKata;


namespace MineRoverKataTests
{
    public class RobotActionExecutorTests
    {
        [Fact]
        public static void turningLeft()
        {
            var robotMock = new Mock<IRobot>();
            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.East);
            
            RobotActionExecutor.Execute(robotMock.Object, 'L');
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.North), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.East), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.South), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.West), Times.Never());

            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.North);

            RobotActionExecutor.Execute(robotMock.Object, 'L');
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.North), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.East), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.South), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.West), Times.Once());

            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.West);

            RobotActionExecutor.Execute(robotMock.Object, 'L');
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.North), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.East), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.South), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.West), Times.Once());

            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.South);

            RobotActionExecutor.Execute(robotMock.Object, 'L');
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.North), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.East), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.South), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.West), Times.Once());
        }

        [Fact]
        public static void turningRight()
        {
            var robotMock = new Mock<IRobot>();
            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.South);

            RobotActionExecutor.Execute(robotMock.Object, 'R');
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.North), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.East), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.South), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.West), Times.Once());

            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.West);

            RobotActionExecutor.Execute(robotMock.Object, 'R');
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.North), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.East), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.South), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.West), Times.Once());

            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.North);

            RobotActionExecutor.Execute(robotMock.Object, 'R');
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.North), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.East), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.South), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.West), Times.Once());

            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.North);

            RobotActionExecutor.Execute(robotMock.Object, 'R');
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.North), Times.Once());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.East), Times.Exactly(2));
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.South), Times.Never());
            robotMock.Verify(x => x.SetOrientation(RobotOrientation.West), Times.Once());
        }

        [Fact]
        public static void movingEast()
        {
            PositionValidator.SetMaxX(10);
            PositionValidator.SetMaxY(5);
            var robotMock = new Mock<IRobot>();
            int[] mockGetPositionReturn = { 5, 4 };
            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.East);
            robotMock.Setup(x => x.GetPosition()).Returns(mockGetPositionReturn);

            RobotActionExecutor.Execute(robotMock.Object, 'M');
            
            robotMock.Verify(x => x.SetPosition(6, 4), Times.Once());
        }

        [Fact]
        public static void movingWest()
        {
            PositionValidator.SetMaxX(10);
            PositionValidator.SetMaxY(5);
            var robotMock = new Mock<IRobot>();
            int[] mockGetPositionReturn = { 10, 1 };
            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.West);
            robotMock.Setup(x => x.GetPosition()).Returns(mockGetPositionReturn);

            RobotActionExecutor.Execute(robotMock.Object, 'M');

            robotMock.Verify(x => x.SetPosition(9, 1), Times.Once());
        }

        [Fact]
        public static void movingNorth()
        {
            PositionValidator.SetMaxX(2);
            PositionValidator.SetMaxY(1);
            var robotMock = new Mock<IRobot>();
            int[] mockGetPositionReturn = { 2, 0 };
            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.North);
            robotMock.Setup(x => x.GetPosition()).Returns(mockGetPositionReturn);

            RobotActionExecutor.Execute(robotMock.Object, 'M');

            robotMock.Verify(x => x.SetPosition(2, 1), Times.Once());
        }

        [Fact]
        public static void movingSouth()
        {
            PositionValidator.SetMaxX(4);
            PositionValidator.SetMaxY(1);
            var robotMock = new Mock<IRobot>();
            int[] mockGetPositionReturn = { 4, 1 };
            robotMock.Setup(x => x.GetOrientation()).Returns(RobotOrientation.South);
            robotMock.Setup(x => x.GetPosition()).Returns(mockGetPositionReturn);

            RobotActionExecutor.Execute(robotMock.Object, 'M');

            robotMock.Verify(x => x.SetPosition(4, 0), Times.Once());
        }
    }
}
