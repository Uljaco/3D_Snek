using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _3DSnek
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        ColllisionDetector collisionDetector;
        InputManager inputManager;
        Player player;
        Bounds bounds;
        VisualOutputManager visualOutputManager;
        PointSystem pointSystem;
        double gameTickTimer;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();

            collisionDetector = new ColllisionDetector();
            inputManager = new InputManager();
            player = new Player();
            bounds.set(1,1,20,20);//size of the map's grid
            pointSystem = new PointSystem();
            visualOutputManager = new VisualOutputManager(graphics, Content);
            gameTickTimer = 0;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic 
            inputManager.manageInput(player);//player can always change direction/camera

            gameTickTimer += gameTime.ElapsedGameTime.Milliseconds;//accumulate time until we can update again
            if (gameTickTimer > 600)//If it has been long enough since last update
            {
                //Move the snake and check for collisions
                //if player dies, trigger the "You Lost" event sequence

                gameTickTimer = 0; //reset for timing the next gameTick
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            visualOutputManager.draw(player);

            base.Draw(gameTime);
        }
    }
}
