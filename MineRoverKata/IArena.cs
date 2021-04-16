
namespace MineRoverKata
{
    interface IArena
    {
        public bool CheckPosition(int x, int y);
        public int Width { get; }
        public int Height { get; }
    }
}
