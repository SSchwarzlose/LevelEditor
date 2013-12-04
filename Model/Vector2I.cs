/******************************
** Autor: Sascha Schawrzlose **
** File: Vector2I.cs          **
******************************/

namespace LevelEditor.Model
{
    public class Vector2I
    {
        private readonly int x;

        private readonly int y;

        public int X { get; private set; }
        public int Y { get; private set; }

        public Vector2I(int x, int y)
        {
            if (x >= 0)
            {
                this.x = x;
            }
            if (y >= 0)
            {
                this.y = y;
            }
        }
    }
}