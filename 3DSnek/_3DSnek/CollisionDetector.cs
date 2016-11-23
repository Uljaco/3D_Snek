using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _3DSnek
{
    class ColllisionDetector
    {
        private int gridSpaceFactor;

        public ColllisionDetector(int newSpaceFactor)
        {
            gridSpaceFactor = newSpaceFactor;
        }

        /// <summary>
        /// Return true if the player has collided with its own tail.
        /// </summary>
        public bool checkAgainstTail(Player player)
        {
            Vector3 pcoords = player.coords;
            LinkedListNode<TailPiece> currentTailPiece = player.tail.First;
            while (currentTailPiece != null)
            {
                if (pcoords.Equals(currentTailPiece.Value.coords))//if player coords are same as the current tail piece's coords
                {
                    return true;
                }
                currentTailPiece = currentTailPiece.Next;
            }
            return false;
        }

        /// <summary>
        /// Return true if the player has collided with (and collected) a piece of food.
        /// </summary>
        public bool checkIfCollectingFood(Player player, Vector3 foodLocation)
        {
            if (player.coords.Equals(foodLocation))
            {
                return true;
            }
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