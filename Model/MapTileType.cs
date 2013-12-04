/******************************
** Autor: Sascha Schawrzlose **
** File: MapTileType.cs          **
******************************/

namespace LevelEditor.Model
{
    public class MapTileType
    {
        public string Name { get; private set; }
        public int MovementCost { get; private set; }

        public MapTileType(int movementCost, string name)
        {
            this.Name = name;

            this.MovementCost = movementCost;
        }
    }
}