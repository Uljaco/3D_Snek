using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DSnek
{
    class InputManager
    {
        public void manageInput(Player player)
        {
            //Process input and/or delegate to appropriate private methods?
            handleMotionControl(player);
            handleCameraControl(player);
        }

        /// <summary>
        /// Change player direction using WASD / arrow keys
        /// </summary>
        private void handleMotionControl(Player player)
        {
            KeyboardState keyboardState = Keyboard.GetState();

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
