using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DSnek
{
    class VisualOutputManager
    {
        private ContentManager Content;
        private GraphicsDeviceManager graphics;
        private float aspectRatio;
        //private SpriteBatch spriteBatch;//Will only need if we want 2D text/images to be displayed

        private Model snekTextModel, snekTextSquareModel;

        private Vector3 cameraPosition, cameraLookAt;

        public VisualOutputManager(GraphicsDeviceManager gdm, ContentManager content)
        {
            Content = content;
            graphics = gdm;
            aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;//required data for 3D rendering
            //spriteBatch = new SpriteBatch(GraphicsDevice);
            graphics.PreferredBackBufferHeight = 850;//set viewing window dimensions
            graphics.PreferredBackBufferWidth = 1000;
            graphics.ApplyChanges();//need to explicitly apply the changes since we are outside the Game constructor

            cameraLookAt = Vector3.Zero;//origin
            cameraPosition = new Vector3(700, 500, -400);

            loadModels();
        }

        private void loadModels()
        {
            snekTextModel = Content.Load<Model>("Models/3DSnekText");
            snekTextSquareModel = Content.Load<Model>("Models/3DSnekSquareText");
        }

        public void draw()
        {
            graphics.GraphicsDevice.Clear(Color.Aquamarine);//Set background color
            drawModel(snekTextSquareModel, Vector3.Zero, Color.BlanchedAlmond.ToVector3());
        }

        private void drawModel(Model model, Vector3 modelPosition, Vector3 color)
        {
            // Copy any parent transforms.
            Matrix[] transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);
            foreach (ModelMesh mesh in model.Meshes)
            {
                // This is where the mesh orientation is set, as well 
                // as our camera and projection.
                foreach (BasicEffect effect in mesh.Effects)
                {   //TO-DO: precalculate anything that does not change
                    effect.EnableDefaultLighting();
                    effect.DiffuseColor = color;
                    effect.DirectionalLight0.Direction = new Vector3(0f, 0.0f, 0.0f);
                    effect.World = transforms[mesh.ParentBone.Index] * Matrix.CreateTranslation(modelPosition);//change the position of the model in the world
                    effect.View = Matrix.CreateLookAt(cameraPosition, cameraLookAt, Vector3.Up); //change the position and direction of the camera
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(
                        MathHelper.ToRadians(45.0f), aspectRatio,
                        1.0f, 10000.0f);//control how the view of the 3D world is turned into a 2D image
                }
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }
        }

    }
}
