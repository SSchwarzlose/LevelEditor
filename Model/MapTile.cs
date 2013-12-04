/******************************
** Autor: Sascha Schawrzlose **
** File: MapTile.cs          **
******************************/

namespace LevelEditor.Model
{
    public class MapTile
    {
        public Vector2I Position { get; private set; }
        public string Type { get; private set; }

        public MapTile()
        {
        }

        public MapTile(int x, int y, string tileType)
            : this(new Vector2I(x, y), tileType)
        {
        }

        public MapTile(Vector2I position, string type)
        {
            this.Position = position;
            this.Type = type;
        }
    }
}