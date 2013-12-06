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

        public int X
        {
            get
            {
                return this.x;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            
        }

        public Vector2I(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}