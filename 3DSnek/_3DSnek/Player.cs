using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DSnek
{
    public class Player
    {
        public Vector3 coords { get; set; }   //xyz coordinates, maybe just need xz if we keep y uniform, but keeping in 3d vector might make it easier to compute?
        LinkedList<TailPiece> tail { get; } //contains the player's recent previous locations (which are the current locations of the tail)
        //TailPiece as opposed to just xy coordinates because we might want to make different tail pieces appear differently
        //but maybe even then we could use just xy and implement the different appearance as function of how long the tail is to begin with
        Vector3 currentDirection { get; set; }   //player's current velocity/motion vector
        //int tailLength? just tail.length
        private int gridSpaceFactor;//the dist from one grid location to the next (displacement when moving)

        public Player(int gridSpaceFactor)
        {
            //Player spawns in middle of map
            coords = Vector3.Zero;
            currentDirection = Vector3.Backward;
            this.gridSpaceFactor = gridSpaceFactor;
        }

        public void move()//Vector3 movementVector)
        {
            //update player and tail coordinates
            coords += currentDirection * gridSpaceFactor;
        }

        /// <summary>
        /// Change the player's current direction. Take a boolean (true if turning left, false if right) and update player's direction
        /// based on the previous currentDirection and which way they are turning.
        /// </summary>
        public void changeDirection(bool toLeft)//if not to the left, then it is to the right (can only change direction in 2 ways L/R)
        {
            if (toLeft)//if turning LEFT
            {
                if (currentDirection.Equals(Vector3.Backward))
                {
                    currentDirection = Vector3.Right;
                }else if (currentDirection.Equals(Vector3.Forward))
                {
                    currentDirection = Vector3.Left;
                }else if (currentDirection.Equals(Vector3.Left))
                {
                    currentDirection = Vector3.Backward;
                }else if (currentDirection.Equals(Vector3.Right))
                {
                    currentDirection = Vector3.Forward;
                }
            }
            else//if turning RIGHT
            {
                if (currentDirection.Equals(Vector3.Backward))
                {
                    currentDirection = Vector3.Left;
                }
                else if (currentDirection.Equals(Vector3.Forward))
                {
                    currentDirection = Vector3.Right;
                }
                else if (currentDirection.Equals(Vector3.Left))
                {
                    currentDirection = Vector3.Forward;
                }
                else if (currentDirection.Equals(Vector3.Right))
                {
                    currentDirection = Vector3.Backward;
                }
            }
        }

        public void addTailPiece()
        {
            
        }

    }

    class TailPiece
    {
        Vector3 coords { set; get; }

        public TailPiece(Vector3 coordinates)
        {
            coords = coordinates;
        }
    }
}
