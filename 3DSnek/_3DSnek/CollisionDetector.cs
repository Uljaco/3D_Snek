using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DSnek
{
    class ColllisionDetector
    {
        private int gridSpaceFactor;

        public ColllisionDetector(int newSpaceFactor)
        {
            gridSpaceFactor = newSpaceFactor;
        }

        public bool checkAgainstTail(Player player)//, LinkedList<TailPiece> tail)
        {
            return false;
        }

        public bool checkIfCollectingFood(Player player)//, Food food) do we want food to be represented just by a location on the grid?
        {
            return false;
        }

        /// <summary>
        /// Return true if the player has collided with a boundary/wall.
        /// </summary>
        public bool checkAgainstWalls(Player player, Bounds bounds)
        {
            if(player.coords.X > bounds.xmax * gridSpaceFactor || player.coords.X < bounds.xmin * gridSpaceFactor ||
                player.coords.Z > bounds.zmax * gridSpaceFactor || player.coords.Z < bounds.zmin * gridSpaceFactor)
            {
                return true;
            }
            return false;
        }
    }
}