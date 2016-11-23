using Microsoft.Xna.Framework;

namespace _3DSnek
{
    class ColllisionDetector
    {
        private int gridSpaceFactor;

        public ColllisionDetector(int newSpaceFactor)
        {
            gridSpaceFactor = newSpaceFactor;
        }

        public bool checkAgainstTail(Player player)
        {
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