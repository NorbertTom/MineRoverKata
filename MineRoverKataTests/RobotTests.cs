using System;
using Xunit;
using MineRoverKata;

namespace MineRoverKataTests
{
    public class RobotTests
    {
        [Fact]
        public static void SettingAndGettingPosition()
        {
            var robot = new Robot();
            int posX = 2;
            int posY = 5;
            int[] position = { posX, posY };
            robot.SetPosition(posX, posY);
            Assert.Equal(position, robot.GetPosition());

            posX = 15;
            posY = 11;
            position[0] = posX;
            position[1] = posY;
            robot.SetPosition(posX, posY);
            Assert.Equal(position, robot.GetPosition());
        }

        [Fact]
        public static void SettingAndGettingOrientationAsChar()
        {
            var robot = new Robot();
            char orientation = 'E';
            robot.SetOrientation(orientation);
            Assert.Equal(orientation, robot.GetOrientationAsChar());

            orientation = 'W';
            robot.SetOrientation(orientation);
            Assert.Equal(orientation, robot.GetOrientationAsChar());
        }

        [Fact]
        public static void SettingAndGettingOrientation()
        {
            var robot = new Robot();
            RobotOrientation orientation = RobotOrientation.South;
            robot.SetOrientation(orientation);
            Assert.Equal(RobotOrientation.South, robot.GetOrientation());
            Assert.Equal('S', robot.GetOrientationAsChar());
        }
    }
}
