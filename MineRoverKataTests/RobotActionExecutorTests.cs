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
    }
}
