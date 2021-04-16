using System;
using System.Collections.Generic;
using System.Text;

namespace MineRoverKata
{
    static class InputDataTranslator
    {

        public static Dimensions TranslateSizeOfArena(string sizeOfArenaString)
        {
            var sizeOfArena = new Dimensions();
            string[] dimensions = sizeOfArenaString.Split(' ');
            bool widthIsValid = Int32.TryParse(dimensions[0], out sizeOfArena.Width);
            bool heightIsValid = Int32.TryParse(dimensions[1], out sizeOfArena.Height);
            if (!widthIsValid || !heightIsValid)
            {
                sizeOfArena = null;
            }
            return sizeOfArena;
        }

        public static InitialPositionAndOrientation TranslateInitialPositionAndOrientation(string initPosAndOrient)
        {
            var initPosAndOrientTranslated = new InitialPositionAndOrientation();
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
