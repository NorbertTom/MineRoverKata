using System;
using Xunit;
using MineRoverKata;

namespace MineRoverKataTests
{
    public class ArenaTests
    {
        [Fact]
        public void ArenaConstructor()
        {
            var dimensions = new Dimensions
            {
                Width = 5,
                Height = 11
            };

            Arena arena = new Arena(dimensions);

            Assert.Equal(dimensions.Width, arena.Width);
            Assert.Equal(dimensions.Height, arena.Height);

            dimensions.Width = 10;
            dimensions.Height = 3;

            arena = new Arena(dimensions);

            Assert.Equal(dimensions.Width, arena.Width);
            Assert.Equal(dimensions.Height, arena.Height);
        }

        [Fact]
        public void IfPositionIsValid()
        {
            var dimensions = new Dimensions 
            {
                Width = 10,
                Height = 100
            };
            var arena = new Arena(dimensions);

            Assert.True(arena.CheckPosition(0, 0));
            Assert.True(arena.CheckPosition(9, 99));
            Assert.True(arena.CheckPosition(10, 100));
            Assert.False(arena.CheckPosition(-1, 2));
            Assert.False(arena.CheckPosition(1, -2));
            Assert.False(arena.CheckPosition(-1, -2));
            Assert.False(arena.CheckPosition(9, 101));
            Assert.False(arena.CheckPosition(11, 10));
            Assert.False(arena.CheckPosition(11, 102));
        }
    }
}
