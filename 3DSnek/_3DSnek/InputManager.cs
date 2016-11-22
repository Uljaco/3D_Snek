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
            //Just turning left and right -> Just A and D keys?
            Keys [] keys = keyboardState.GetPressedKeys();
            if (keys.Contains<Keys>(Keys.A))
            {
                Console.Out.WriteLine("Pressed A");
                player.changeDirection(true);//left
            }
            else if (keys.Contains<Keys>(Keys.D))
            {
                Console.Out.WriteLine("Pressed D");
                player.changeDirection(false);//right
            }
        }

        /// <summary>
        /// Rotate and angle camera based on mouse?
        /// </summary>
        public void handleCameraControl(Player player)//maybe camera control only needs player's current direction? not whole object reference
        {
            MouseState mouseState = Mouse.GetState();

        }
    }
}
