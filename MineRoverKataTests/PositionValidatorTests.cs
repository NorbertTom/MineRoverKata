using System;
using Xunit;
using MineRoverKata;

namespace MineRoverKataTests
{
    public class PositionValidatorTests
    {
        [Fact]
        public static void ifPositionIsValid()
        {
            PositionValidator.SetMaxX(10);
            PositionValidator.SetMaxY(100);
            Assert.True(PositionValidator.checkPosition(0, 0));
            Assert.True(PositionValidator.checkPosition(9, 99));
            Assert.True(PositionValidator.checkPosition(10, 100));
            Assert.False(PositionValidator.checkPosition(-1, 2));
            Assert.False(PositionValidator.checkPosition(1, -2));
            Assert.False(PositionValidator.checkPosition(-1, -2));
            Assert.False(PositionValidator.checkPosition(9, 101));
            Assert.False(PositionValidator.checkPosition(11, 10));
            Assert.False(PositionValidator.checkPosition(11, 102));
        }
    }
}