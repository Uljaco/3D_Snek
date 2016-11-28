using System;

namespace _3DSnek
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static bool ShouldRestart = false;
        static void Main(string[] args)
        {
            
            using (Game1 game = new Game1())
            {
                
                game.Run();
            }
            
            
        }
    }
#endif
}

