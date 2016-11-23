using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace _3DSnek
{
    class InputManager
    {
        /// <summary>
        /// Change player direction using WASD / arrow keys
        /// </summary>
        public void handleMotionControl(Player player)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            //Just turning left and right -> Just A and D keys
            Keys [] keys = keyboardState.GetPressedKeys();
            if (keys.Contains<Keys>(Keys.A))
            {
                player.changeDirection(true);//turn left
            }
            else if (keys.Contains<Keys>(Keys.D))
            {
                player.changeDirection(false);//turn right
            }
        }

        /// <summary>
        /// Rotate and angle camera based on mouse? Probably easier to use arrow keys for this
        /// </summary>
        public void handleCameraControl(Player player, VisualOutputManager vom)//maybe camera control only needs player's current direction? not whole object reference
        {
            //MouseState mouseState = Mouse.GetState();//or use arrow keys
            Keys[] keys = Keyboard.GetState().GetPressedKeys();
            
            if (keys.Contains<Keys>(Keys.Left))
            {
                vom.yaw += .05f;
            }
            else if (keys.Contains<Keys>(Keys.Right))
            {
                vom.yaw -= .05f;
            }
            if (keys.Contains<Keys>(Keys.Up))
            {
                vom.pitch += .03f;
            }
            else if (keys.Contains<Keys>(Keys.Down))
            {
                vom.pitch -= .03f;
            }
            //Refactor this stuff over to the VisualOutputManager class
            Vector3 position = Vector3.Transform(Vector3.Backward, Matrix.CreateFromYawPitchRoll(vom.yaw, vom.pitch, 0f));
            position *= 6000f;
            position += vom.cameraLookAt;

            vom.cameraPosition = position;
        }
    }
}
