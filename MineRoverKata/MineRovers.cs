using System;
using System.Collections.Generic;

namespace MineRoverKata
{
    class MineRovers
    {
        public MineRovers(int NrOfRobots)
        {
            CommandStreams = new List<string>();
            Robots = new List<Robot>();
            AddEmptyRobotsToList(Robots, NrOfRobots);
        }

        public IArena arena { get; set; }
        public List<Robot> Robots { get; private set; }
        public List<string> CommandStreams { get; private set; }

        private void AddEmptyRobotsToList(List<Robot> robots, int finalSize)
        {
            for (int i = 0; i < finalSize; i++)
            {
                robots.Add(new Robot());
            }
        }

    }
}
