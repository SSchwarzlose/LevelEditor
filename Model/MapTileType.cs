/******************************
** Autor: Sascha Schawrzlose **
** File: MapTileType.cs          **
******************************/

namespace LevelEditor.Model
{
    using System;

    public class MapTileType
    {
        public MapTileType(int movementCost, string name)
        {
            if (movementCost <= 0)
            {
                throw new ArgumentOutOfRangeException("movementCost", "Movementcost must be greater than 0.");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            this.Name = name;

            this.MovementCost = movementCost;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        public int MovementCost { get; private set; }
    }
}