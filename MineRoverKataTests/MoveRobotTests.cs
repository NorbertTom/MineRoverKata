using System;
using Xunit;
using MineRoverKata;

namespace MineRoverKataTests
{
    public class MoveRobotTests
    {
        [Fact]
        public static void testMovingNorth()
        {
            RobotOrientation orientation = RobotOrientation.North;
            int[] expectedResult = { 0, 1 };
            int[] actualResult = MoveRobot.GetRobotDisplacement(orientation);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public static void testMovingEast()
        {
            RobotOrientation orientation = RobotOrientation.East;
            int[] expectedResult = { 1, 0 };
            int[] actualResult = MoveRobot.GetRobotDisplacement(orientation);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public static void testMovingSouth()
        {
            RobotOrientation orientation = RobotOrientation.South;
            int[] expectedResult = { 0, -1 };
            int[] actualResult = MoveRobot.GetRobotDisplacement(orientation);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public static void testMovingWest()
        {
            RobotOrientation orientation = RobotOrientation.West;
            int[] expectedResult = { -1, 0 };
            int[] actualResult = MoveRobot.GetRobotDisplacement(orientation);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
