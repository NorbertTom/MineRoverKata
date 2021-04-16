using System;
using Xunit;
using MineRoverKata;

namespace MineRoverKataTests
{
    public class MoveRobotTests
    {
        [Theory]
        [InlineData(RobotOrientation.North, 0, 1)]
        [InlineData(RobotOrientation.South, 0, -1)]
        [InlineData(RobotOrientation.East, 1, 0)]
        [InlineData(RobotOrientation.West, -1,0)]
        public static void testMovingMoving(RobotOrientation orientation, int expectedX, int expectedY)
        {
            int[] expectedResult = { expectedX, expectedY };
            int[] actualResult = MoveRobot.GetRobotDisplacement(orientation);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
