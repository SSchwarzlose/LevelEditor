/******************************
** Autor: Sascha Schawrzlose **
** File: Map.cs          **
******************************/

namespace LevelEditor.Model
{
    using System;
    using System.Windows.Markup.Primitives;

    public class Map
    {
        private int width;
        private int height;

        public MapTile[,] Tiles { get; private set; }

        public Map()
        {
        }

        public Map(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException("width", "Width must be greater than 0.");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException("height", "height must be greater than 0.");
            }

            this.width = width;
            this.height = height;

            this.Tiles = new MapTile[width, height];
        }

        public MapTile this[int x, int y]
        {
            get
            {
                return this.Tiles[x, y];
            }
            set
            {
                this.Tiles[x, y] = value;
            }
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public MapTile this[Vector2I position]
        {
            get
            {
                return this.Tiles[position.X, position.Y];
            }

            set
            {
                this.Tiles[position.X, position.Y] = value;
            }
        }
    }
}