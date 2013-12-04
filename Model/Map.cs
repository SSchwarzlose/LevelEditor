/******************************
** Autor: Sascha Schawrzlose **
** File: Map.cs          **
******************************/

namespace LevelEditor.Model
{
    using System.Windows.Markup.Primitives;

    public class Map
    {
        public MapTile[,] Tiles { get; private set; }

        public Map()
        {
        }
    }
}