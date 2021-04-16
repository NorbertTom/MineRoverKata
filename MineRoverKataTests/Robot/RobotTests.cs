using System;
using Xunit;
using MineRoverKata;

namespace MineRoverKataTests
{
    public class RobotTests
    {
        [Theory]
        [InlineData(2, 5)]
        [InlineData(15,11)]
        [InlineData(100,250)]
        public static void SettingAndGettingPosition(int posX, int posY)
        {
            var robot = new Robot();
            int[] position = { posX, posY };
            robot.SetPosition(posX, posY);
            Assert.Equal(position, robot.GetPosition());
        }

        [Theory]
        [InlineData('E')]
        [InlineData('W')]
        [InlineData('S')]
        [InlineData('N')]
        public static void SettingAndGettingOrientationAsChar(char orientation)
        {
            var robot = new Robot();
            robot.SetOrientation(orientation);
            Assert.Equal(orientation, robot.GetOrientationAsChar());
        }

        [Theory]
        [InlineData(RobotOrientation.North, 'N')]
        [InlineData(RobotOrientation.East, 'E')]
        [InlineData(RobotOrientation.West, 'W')]
        [InlineData(RobotOrientation.South, 'S')]
        public static void SettingAndGettingOrientation(RobotOrientation orientation, char orientationChar)
        {
            var robot = new Robot();
            robot.SetOrientation(orientation);
            Assert.Equal(orientation, robot.GetOrientation());
            Assert.Equal(orientationChar, robot.GetOrientationAsChar());
        }
    }
}
