using System;
using System.Collections.Generic;
using System.Text;

namespace MineRoverKata
{
    static class InputDataTranslator
    {

        public static SizeOfArenaTranslated TranslateSizeOfArena(string sizeOfArenaString)
        {
            var sizeOfArena = new SizeOfArenaTranslated();
            string[] dimensions = sizeOfArenaString.Split(' ');
            bool widthIsValid = Int32.TryParse(dimensions[0], out sizeOfArena.Width);
            bool heightIsValid = Int32.TryParse(dimensions[1], out sizeOfArena.Height);
            if (!widthIsValid || !heightIsValid)
            {
                sizeOfArena = null;
            }
            return sizeOfArena;
        }

        public static InitialPositionAndOrientationTranslated TranslateInitialPositionAndOrientation(string initPosAndOrient)
        {
            var initPosAndOrientTranslated = new InitialPositionAndOrientationTranslated();
            string[] dataChunk = initPosAndOrient.Split(' ');
            bool xIsValid = Int32.TryParse(dataChunk[0], out initPosAndOrientTranslated.X);
            bool yIsValid = Int32.TryParse(dataChunk[1], out initPosAndOrientTranslated.Y);
            initPosAndOrientTranslated.Orientation = dataChunk[2][0];
            if (!xIsValid || !yIsValid)
            {
                initPosAndOrientTranslated = null;
            }
            return initPosAndOrientTranslated;
        }
    }
}
