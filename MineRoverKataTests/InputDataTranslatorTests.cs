using System;
using Xunit;
using MineRoverKata;

namespace MineRoverKataTests
{
    public class InputDataTranslatorTests
    {
        [Fact]
        public static void translateSizeOfArena_validValues()
        {
            string sizeOfArenaString = "5 10";
            SizeOfArenaTranslated sizeOfArenaTranslated = InputDataTranslator.TranslateSizeOfArena(sizeOfArenaString);
            Assert.Equal(5, sizeOfArenaTranslated.Width);
            Assert.Equal(10, sizeOfArenaTranslated.Height);

            sizeOfArenaString = "25 200";
            sizeOfArenaTranslated = InputDataTranslator.TranslateSizeOfArena(sizeOfArenaString);
            Assert.Equal(25, sizeOfArenaTranslated.Width);
            Assert.Equal(200, sizeOfArenaTranslated.Height);

        }

        [Fact]
        public static void translateSizeOfArena_invalidValues()
        {
            string sizeOfArenaString = "asd vcx";
            SizeOfArenaTranslated sizeOfArenaTranslated = InputDataTranslator.TranslateSizeOfArena(sizeOfArenaString);
            Assert.Null(sizeOfArenaTranslated);

            sizeOfArenaString = "24 as";
            sizeOfArenaTranslated = InputDataTranslator.TranslateSizeOfArena(sizeOfArenaString);
            Assert.Null(sizeOfArenaTranslated);

            sizeOfArenaString = "x 4";
            sizeOfArenaTranslated = InputDataTranslator.TranslateSizeOfArena(sizeOfArenaString);
            Assert.Null(sizeOfArenaTranslated);
        }

        [Fact]
        public static void translateInitPositionAndOrientation_validValues1()
        {
            string initPosAndOrientString = "5 3 E";
            InitialPositionAndOrientationTranslated initPosAndOrientTranslated =
                InputDataTranslator.TranslateInitialPositionAndOrientation(initPosAndOrientString);
            Assert.Equal(5, initPosAndOrientTranslated.X);
            Assert.Equal(3, initPosAndOrientTranslated.Y);
            Assert.Equal('E', initPosAndOrientTranslated.Orientation);
        }

        [Fact]
        public static void translateInitPositionAndOrientation_validValues2()
        {
            string initPosAndOrientString = "15 32 N";
            InitialPositionAndOrientationTranslated initPosAndOrientTranslated =
                InputDataTranslator.TranslateInitialPositionAndOrientation(initPosAndOrientString);
            Assert.Equal(15, initPosAndOrientTranslated.X);
            Assert.Equal(32, initPosAndOrientTranslated.Y);
            Assert.Equal('N', initPosAndOrientTranslated.Orientation);
        }

        [Fact]
        public static void translateInitPositionAndOrientation_invalidValues()
        {
            string initPosAndOrientString = "15 esad N";
            InitialPositionAndOrientationTranslated initPosAndOrientTranslated =
                InputDataTranslator.TranslateInitialPositionAndOrientation(initPosAndOrientString);
            Assert.Null(initPosAndOrientTranslated);

            initPosAndOrientString = "d 23 N";
            initPosAndOrientTranslated = InputDataTranslator.TranslateInitialPositionAndOrientation(initPosAndOrientString);
            Assert.Null(initPosAndOrientTranslated);

        }
    }
}
