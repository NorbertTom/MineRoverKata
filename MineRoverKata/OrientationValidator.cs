using System;
using System.Collections.Generic;
using System.Text;

namespace MineRoverKata
{
    static class OrientationValidator
    {
        public static bool checkCharacter(char input)
        {
            return (input == 'E' || input == 'N' || input == 'S' || input == 'W');
        }
    }
}
