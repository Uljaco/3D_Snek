using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DSnek
{
    class Player
    {
        Vector3 playerCoords;   //xyz coordinates, maybe just need xy if we keep z uniform, but keeping in 3d vector might make it easier to compute?
        LinkedList<TailPiece> tail; //contains the player's recent previous locations (which are the current locations of the tail)
        //TailPiece as opposed to just xy coordinates because we might want to make different tail pieces appear differently
        //but maybe even then we could use just xy and implement the different appearance as function of how long the tail is to begin with
        Vector3 currentDirection;   //player's current velocity/motion vector
        //int tailLength? just tail.length

        public Player()
        {
            //Player spawns in middle of map
        }

    }

    class TailPiece
    {

    }
}
