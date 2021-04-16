using System;
using Xunit;
using MineRoverKata;

namespace MineRoverKataTests
{
    public class InputDataTranslatorTests
    {
        [Theory]
        [InlineData("5 10", 5, 10)]
        [InlineData("25 200", 25, 200)]
        [InlineData("1 17", 1, 17)]
        public static void TranslateSizeOfArena_validValues(string sizeOfArenaString,
                                                            int expectedWidth, int expectedHeight)
        {
            Dimensions sizeOfArenaTranslated = InputDataTranslator.TranslateSizeOfArena(sizeOfArenaString);
            Assert.Equal(expectedWidth, sizeOfArenaTranslated.Width);
            Assert.Equal(expectedHeight, sizeOfArenaTranslated.Height);
        }

        [Theory]
        [InlineData("24 asd")]
        [InlineData("24as d")]
        [InlineData("ax 2")]
        [InlineData("0 x")]
        public static void TranslateSizeOfArena_invalidValues(string sizeOfArenaString)
        {
            Dimensions sizeOfArenaTranslated = InputDataTranslator.TranslateSizeOfArena(sizeOfArenaString);
            Assert.Null(sizeOfArenaTranslated);
        }

        [Theory]
        [InlineData("5 3 E", 5, 3, 'E')]
        [InlineData("15 32 N", 15, 32, 'N')]
        [InlineData("33 10 W", 33, 10, 'W')]
        [InlineData("1 6 S", 1, 6, 'S')]
        public static void TranslateInitPositionAndOrientation_validValues1(string initPosAndOrientString,
                                                                            int expectedX, int expectedY,
                                                                            int expectedOrient)
        {
            InitialPositionAndOrientation initPosAndOrientTranslated =
                InputDataTranslator.TranslateInitialPositionAndOrientation(initPosAndOrientString);
            Assert.Equal(expectedX, initPosAndOrientTranslated.X);
            Assert.Equal(expectedY, initPosAndOrientTranslated.Y);
            Assert.Equal(expectedOrient, initPosAndOrientTranslated.Orientation);
        }

        [Theory]
        [InlineData("15 esad N")]
        [InlineData("d 23 N")]
        [InlineData("w P a")]
        public static void TranslateInitPositionAndOrientation_invalidValues(string initPosAndOrientString)
        {
            InitialPositionAndOrientation initPosAndOrientTranslated =
                InputDataTranslator.TranslateInitialPositionAndOrientation(initPosAndOrientString);
            Assert.Null(initPosAndOrientTranslated);
        }
    }
}
