using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// A simple class for storing X and Y values, to represent a tile/coordinate.
    /// Makes it easier to store and work with.
    /// </summary>
    class Coordinate
    {
        int _x, _y;
        int _width, _height; // Only used to specify walls

        /// <summary>
        /// Store X and Y values which represent the coordinate position
        /// </summary>
        /// <param name="x">The coordinate's point along the x axis</param>
        /// <param name="y">The coordinate's point along the y axis</param>
        public Coordinate(int x, int y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Used to create walls of varying sizes
        /// </summary>
        /// <param name="x">The wall's starting point along the x axis, starting from left side</param>
        /// <param name="y">The wall's point along the y axis, starting from top side</param>
        /// <param name="width">The width of the wall</param>
        /// <param name="height">The height of the wall</param>
        public Coordinate(int x, int y, int width, int height)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }


        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
    }
}
