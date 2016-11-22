using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DSnek
{
    class ColllisionDetector
    {
        public bool checkAgainstTail(Player player)//, LinkedList<TailPiece> tail)
        {
            return false;
        }

        public bool checkIfCollectingFood(Player player)//, Food food) do we want food to be represented just by a location on the grid?
        {
            return false;
        }

        public bool checkAgainstWalls(Player player, Bounds bounds)
        {
            return false;
        }
    }
}