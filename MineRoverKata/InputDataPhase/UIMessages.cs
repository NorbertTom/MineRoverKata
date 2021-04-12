using System;
using System.Collections.Generic;
using System.Text;

namespace MineRoverKata
{
    static class UIMessages
    {
        public static void OpeningMessage()
        {
            Console.WriteLine("Welcome to MineRoverKata");
        }

        public static void InputSizeOfArenaMessage()
        {
            Console.WriteLine("\nPlease enter coordinates of upper right corner of the arena separated by space\n" +
                                "Example: 4 10");
        }

        public static void InputInitialPositionAndOrientationMessage()
        {
            Console.WriteLine("\nPlease enter coordinates of initial position of the robot and direction it faces\n" +
                                "Please separate all data with spaces\n" +
                                "Example: 1 4 W\n" +
                                "If you do not want to input another robot please just hit ENTER");
        }

        public static void InputCommandStreamMessage()
        {
            Console.WriteLine("\nPlease enter commands given to the robot\n" +
                                "Please do not separate them with spaces\n" +
                                "Example: LLRMMRRMRLM");
        }
    }
}