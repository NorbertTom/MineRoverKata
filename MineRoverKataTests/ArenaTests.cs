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
        }

        [Fact]
        public void heightSetterAndGetter()
        {
            Arena arena = new Arena();
            int height = 12;
            arena.SetHeight(height);
            Assert.Equal(height, arena.GetHeight());

            height = 20;
            arena.SetHeight(height);
            Assert.Equal(height, arena.GetHeight());
        }
    }
}
