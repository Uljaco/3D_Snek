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
        Vector3 foodLocation;
        VisualOutputManager visualOutputManager;
        PointSystem pointSystem;
        Random rand;
        double gameTickTimer;//used for determining when a game tick should happen
        private int gridSpaceFactor;//the dist from one grid location to the next (displacement when player moves)

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
            rand = new Random();
            gridSpaceFactor = 140;
            player = new Player(gridSpaceFactor);
            collisionDetector = new ColllisionDetector(gridSpaceFactor);
            inputManager = new InputManager();
            bounds.set(13, -13, 13, -13);//boundaries of the map grid (might need to change these to 14 if it does not look right)
            //bounds.set(10, -10, 10, -10);
            setFoodPosition();
            pointSystem = new PointSystem();
            visualOutputManager = new VisualOutputManager(graphics, Content);
            gameTickTimer = 0;
            //System.Media.SoundPlayer startSoundPlayer2 = new System.Media.SoundPlayer(@"C:\Users\the_y\Music\ElevatorMusic.wav");
            //startSoundPlayer2.Play();
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
            System.Media.SoundPlayer startSoundPlayer = new System.Media.SoundPlayer(@"C:\Users\the_y\Music\Bite1.wav");
            System.Media.SoundPlayer startSoundPlayer2 = new System.Media.SoundPlayer(@"C:\Users\the_y\Music\whah.wav");
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            int gameOver = 0;
            inputManager.handleCameraControl(visualOutputManager);
            gameTickTimer += gameTime.ElapsedGameTime.Milliseconds;//accumulate time until we can update again
            if (gameTickTimer > 300)//If it has been long enough since last update
            {
                inputManager.handleMotionControl(player);//player must be holding key down in the appropriate cycle for it to be processed
                //Move the snake and check for collisions
                player.move();
                if (collisionDetector.checkAgainstWalls(player, bounds))
                {
                    //System.Windows.Forms.MessageBox.Show("Game Over! \nYou ran into a wall!");
                    Console.Out.WriteLine("Player hit wall and DIED");
                    gameOver = 1;
                }
                if (collisionDetector.checkAgainstTail(player))//this check needs to happen before checking food collection so that adding first tail piece does not cause this to return true
                {
                    //System.Windows.Forms.MessageBox.Show("Game Over! \nYou ran into your tail!");
                    Console.Out.WriteLine("Play ran into its tail");
                    gameOver = 1;
                }
                if(gameOver == 1)
                {
                    startSoundPlayer2.Play();
                    //System.Windows.Forms.MessageBox.Show("Game Over");
                    const string message = "                              GAME OVER!\nPress Retry to try again or Cancel to quit game";
                    const string caption = "End Of Game";
                    var result = System.Windows.Forms.MessageBox.Show(message, caption,
                                                 System.Windows.Forms.MessageBoxButtons.RetryCancel,
                                                 System.Windows.Forms.MessageBoxIcon.None);

                    if (result == System.Windows.Forms.DialogResult.Cancel)
                    {
                        
                        Exit();
                    }

                    if (result == System.Windows.Forms.DialogResult.Retry)
                    {
                        //System.Windows.Forms.Application.Restart();
                        Program.ShouldRestart = true;
                        this.Initialize();

                    }

                    gameOver = 0;
                }
                if (collisionDetector.checkIfCollectingFood(player, foodLocation))
                {
                    startSoundPlayer.Play();
                    Console.Out.WriteLine("Collected food yo");
                    setFoodPosition();
                    player.addTailPiece();
                }

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
            GraphicsDevice.Clear(Color.CornflowerBlue);//could replace with black when player has died lel

            visualOutputManager.draw(player, foodLocation);

            base.Draw(gameTime);
        }

        /// <summary>
        /// Set the new food to a valid position.
        /// </summary>
        private void setFoodPosition()
        {
            int newx, newz;
            newx = rand.Next(bounds.xmin, bounds.xmax + 1);
            newz = rand.Next(bounds.zmin, bounds.zmax + 1);
            Vector3 newFoodPosition = new Vector3(newx * gridSpaceFactor, 0, newz * gridSpaceFactor);

            while(!collisionDetector.validFoodPosition(player, newFoodPosition))//until the rng provides a valid food location (a bad implementation lel)
            {
                newx = rand.Next(bounds.xmin, bounds.xmax + 1);
                newz = rand.Next(bounds.zmin, bounds.zmax + 1);
                newFoodPosition = new Vector3(newx * gridSpaceFactor, 0, newz * gridSpaceFactor);
            }

            foodLocation = newFoodPosition;
        }
    }
}
