using System;
using Xunit;
using MineRoverKata;

namespace MineRoverKataTests
{
    public class OrientationValidatorTests
    {
        [Fact]
        public static void checkOrientationCharacter()
        {
            Assert.True(OrientationValidator.checkCharacter('E'));
            Assert.True(OrientationValidator.checkCharacter('W'));
            Assert.True(OrientationValidator.checkCharacter('S'));
            Assert.True(OrientationValidator.checkCharacter('N'));
            Assert.False(OrientationValidator.checkCharacter('e'));
            Assert.False(OrientationValidator.checkCharacter('a'));
            Assert.False(OrientationValidator.checkCharacter('T'));
            Assert.False(OrientationValidator.checkCharacter('0'));
        }
    }
}
