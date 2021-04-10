using System;
using Xunit;
using MineRoverKata;

namespace MineRoverKataTests
{
    public class ArenaTests
    {
        [Fact]
        public void widthSetterAndGetter()
        {
            Arena arena = new Arena();
            int width = 5;
            arena.SetWidth(width);
            Assert.Equal(width, arena.GetWidth());

            width = 11;
            arena.SetWidth(width);
            Assert.Equal(width, arena.GetWidth());
            arena.SetWidth(-1);
        }
    }
}
