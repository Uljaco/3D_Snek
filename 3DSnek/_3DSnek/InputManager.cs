using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;

namespace _3DSnek
{
    class InputManager
    {

        public void manageInput(Player player)
        {
            handleMotionControl(player);
            handleCameraControl(player);
        }

        /// <summary>
        /// Change player direction using WASD / arrow keys
        /// </summary>
        private void handleMotionControl(Player player)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            //Just turning left and right -> Just A and D keys?
            Keys [] keys = keyboardState.GetPressedKeys();
            if (keys.Contains<Keys>(Keys.A))
            {
                Console.Out.WriteLine("Pressed A");
            }
            else if (keys.Contains<Keys>(Keys.D))
            {
                Console.Out.WriteLine("Pressed D");
            }
        }

        /// <summary>
        /// Rotate and angle camera based on mouse?
        /// </summary>
        private void handleCameraControl(Player player)//maybe camera control only needs player's current direction? not whole object reference
        {
            MouseState mouseState = Mouse.GetState();

        }
    }
}
